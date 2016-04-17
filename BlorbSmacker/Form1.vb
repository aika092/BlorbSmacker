Imports System.IO

'v.03 - fixed resize, added scroll via mousewheel to game image panel and replacement image panel. added crop tab.


Public Class MainForm

    'global variables
    Dim buffer() As Byte ' our main buffer to hold the gblorb
    Dim mempointer As Long = 0 'current position we are processing in the byte array
    Dim filelength As Long = 0
    Dim loadFilename As String
    Dim saveFilename As String
    Dim imageSetLoadFilename As String
    Dim imageSetSaveFilename As String
    Dim headerCL As New Header()
    Dim resourceIndexChunk As New ResourceIndexChunk()
    Dim indexList As New List(Of Index)()
    Dim chunkList As New List(Of Chunk)()
    Dim m_MouseIsDown As Boolean
    Dim logFilename As String

    'image set
    Dim imageSet As Hashtable = New Hashtable

    'for work tabs
    Private hadFocus As System.Windows.Forms.Control
    Dim previousTabControl As Integer
    'for crop
    Dim cropX, cropY, cropBoxWidth, cropBoxHeight As Integer
    Dim drawingPen As Pen

    'for align    
    Private handleSize As Integer = 10 'the handles on the corners of the picturebox
    Private overHandle As Boolean
    Private inPB As Boolean = False
    Private resizing As Boolean = False
    Private rc1 As Rectangle
    Private rc2 As Rectangle
    Private rc3 As Rectangle
    Private rc4 As Rectangle
    Private startPoint As Point
    Private endPoint As Point
    Private lastPoint As Point
    Private screenRC As Rectangle
    
    Dim alignLayer0 As Image 'the original image from work - layer 0
    Dim alignLayer1 As Image 'this is the iamge we want to overlay
    Dim alignBitmap As Bitmap
    Dim alignNewBitmap As Bitmap
    Dim cm As New Drawing.Imaging.ColorMatrix
    Dim atr As New Drawing.Imaging.ImageAttributes
    Dim layer1X, layer1Y As Integer
    Dim g As Graphics

    Dim atX As Integer = 0 ' starting image position
    Dim atY As Integer = 0
    Dim mouseDownX As Integer = 0
    Dim mouseDownY As Integer = 0
    Dim drawx As Integer = 0 ' where do we draw layer 1
    Dim drawy As Integer = 0

   




    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    'tab control on work image panel


    'when moving from one tab to another, capture the tab number we are coming from
    Private Sub TabControl_ImageWorkPanel_TabDeselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl_ImageWorkPanel.Deselected
        previousTabControl = e.TabPageIndex
        'DebugScreen("moving from tab: " + previousTabControl.ToString)
    End Sub

    'if we switch into the color blending window, make a copy of the imageworkpicturebox.image
    Private Sub TabControl_ImageWorkPanel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl_ImageWorkPanel.Selected
        'DebugScreen("moving to tab: " + e.TabPageIndex.ToString)
        If PictureBox_ImageWork.Image IsNot Nothing Then 'if we have an image...
            If previousTabControl = 0 And e.TabPageIndex = 1 Then ' tab pages are 0 based
                'if we are moving from Main Image to Color Blend, make a copy of the iamge for the color blend window
                PictureBox_ColorBlend.Image = PictureBox_ImageWork.Image
            ElseIf previousTabControl = 0 And e.TabPageIndex = 2 Then
                'make a copy for the crop window
                PictureBox_Crop.Image = PictureBox_ImageWork.Image
            ElseIf previousTabControl = 0 And e.TabPageIndex = 3 Then
                'make a copy for the align / resize window
                PictureBox_Align.Image = PictureBox_ImageWork.Image
                alignLayer0 = PictureBox_ImageWork.Image
            End If

        End If
    End Sub







    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    'Graphics routines / drag and drop

    'if mouse button is down, set a flag to set us up for drag and drop
    Private Sub pic_MouseDown(ByVal sender As Object, e As MouseEventArgs)

        Dim pic As PictureBox = DirectCast(sender, PictureBox)
        If Not pic.Image Is Nothing Then
            m_MouseIsDown = True
        End If
    End Sub



    'start the drag operation from replacementimage panel for images
    'we'll grab the image from a file so we have a full size copy
    Private Sub pic_MouseMoveFromReplacementPanel(ByVal sender As Object, e As EventArgs)
        Dim pic As PictureBox = DirectCast(sender, PictureBox)
        Dim newImg As Image

        If m_MouseIsDown Then
            If LimitReplacementSizeCheckbox.Checked Then
                newImg = ScaleImage(Image.FromFile(pic.Name), 350, 350) 'grab the full size image (scaled) instead of using the thumbnail
            Else
                newImg = Image.FromFile(pic.Name) ''grab the full size image instead of using the thumbnail
            End If
            pic.DoDragDrop(newImg, DragDropEffects.Copy)
        End If
        m_MouseIsDown = False
    End Sub




    'effect for destination
    Private Sub picdest_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        'f e.Data.GetDataPresent(DataFormats.Bitmap) Then
        e.Effect = DragDropEffects.Copy
        'end If
    End Sub



    'drop operation for destination into the game images panel
    Private Sub picdest_DragDropIntoGameImages(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        ' Assign the image to the PictureBox.

        Dim pic As PictureBox = DirectCast(sender, PictureBox)
        Dim pictureChunkNumber = pic.Name  'get the chunk number
        DebugLog("picture number: " + pictureChunkNumber + " modified")
        DebugScreen("picture number: " + pictureChunkNumber + " modified")

        'scale the image and store in the picturebox
        pic.Image = ScaleImage(e.Data.GetData(DataFormats.Bitmap), 150, 150) 'scaled image
        Dim imgTemp As Image = e.Data.GetData(DataFormats.Bitmap) 'full size image to store in chunk

        'now find the chunk with that number
        For Each ch In chunkList
            If pictureChunkNumber = ch.indexnumber Then
                Dim ms = New MemoryStream()
                imgTemp.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                ReDim ch.chunkdata(ms.Length - 1)
                ch.chunkdata = ms.ToArray()
                ch.chunksize = DecimalTo4ByteArray(ms.Length)
                DebugLog("picture length: " + FormatBytes(ch.chunksize, "Hex"))
                DebugScreen("picture length: " + FormatBytes(ch.chunksize, "Hex"))
                Exit For
            End If
        Next

        'see if the image is already in our imageset
        If imageSet.Contains(pictureChunkNumber) Then 'if it exists already, then replace it
            For Each cnt In Panel_ImageSetFlow.Controls
                If TypeOf cnt Is PictureBox Then
                    If cnt.Name = pictureChunkNumber Then
                        cnt.Image = pic.Image
                        Exit For
                    End If
                End If
            Next
        Else 'otherwise add the new thumbnail image
            imageSet.Add(pictureChunkNumber, "") 'picture name
            Dim pbx As New PictureBox
            pbx.Width = 150
            pbx.Height = 150
            pbx.Name = pic.Name
            pbx.BorderStyle = BorderStyle.FixedSingle
            pbx.Image = pic.Image
            Panel_ImageSetFlow.Controls.Add(pbx)
        End If

        For Each item In imageSet
            DebugLog("Image Set item: " + item.Key.ToString)
            DebugScreen("Image Set item: " + item.Key.ToString)
        Next

    End Sub




    'when you click on an image in the game images panel, launch it inthe work panel
    Private Sub showGamePicture(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim pic As PictureBox = DirectCast(sender, PictureBox)
        Dim ch As New Chunk()

        ch = findChunkByNumber(pic.Name)
        Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream(ch.chunkdata)

        PictureBox_ImageWork.Image = System.Drawing.Image.FromStream(ms)
        PictureBox_ImageWork.Height = PictureBox_ImageWork.Image.Size.Height
        PictureBox_ImageWork.Width = PictureBox_ImageWork.Image.Size.Width

        DebugScreen("picture number: " + pic.Name + "   size: " + PictureBox_ImageWork.Image.Size.Width.ToString + "x" + PictureBox_ImageWork.Image.Size.Height.ToString)

    End Sub




    'when you click on an image in the replacement images panel, launch it in the work panel
    Private Sub showReplacementPicture(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim pic As PictureBox = DirectCast(sender, PictureBox)

        PictureBox_ImageWork.Image = Image.FromFile(pic.Name)
        PictureBox_ImageWork.Height = PictureBox_ImageWork.Image.Size.Height
        PictureBox_ImageWork.Width = PictureBox_ImageWork.Image.Size.Width
        DebugScreen("picture number: " + pic.Name + "   size: " + PictureBox_ImageWork.Image.Size.Width.ToString + "x" + PictureBox_ImageWork.Image.Size.Height.ToString)

    End Sub




    'display images from replacement image directory in replace image panel
    Private Sub ImageDirectoryButton_Click(sender As Object, e As EventArgs) Handles Button_ImageDirectory.Click

        Dim initialDir As String = ""

        initialDir = getRegistryValue("imagesDirectory")
        If initialDir > "" Then
            If Directory.Exists(initialDir + "\") = False Then
                initialDir = "c:\"
            End If
        End If
        DebugScreen("Replacement images directory: " + initialDir)

        FolderBrowserDialog1.Description = "Select the directory that has your replacement images"
        FolderBrowserDialog1.ShowNewFolderButton = False
        FolderBrowserDialog1.SelectedPath = initialDir
        If (FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            setRegistryValue("imagesDirectory", FolderBrowserDialog1.SelectedPath)

            Panel_ReplacementImagesFlow.Controls.Clear()
            Dim extensionList As New List(Of String)(New String() {"*.jpg", "*.png"}) 'ugly syntax!

            For Each ext In extensionList
                For Each fi As FileInfo In New DirectoryInfo(FolderBrowserDialog1.SelectedPath).GetFiles(ext)
                    Dim pbx As New PictureBox
                    pbx.Width = 150
                    pbx.Height = 150
                    pbx.Name = fi.FullName
                    pbx.BorderStyle = BorderStyle.FixedSingle
                    pbx.Image = ScaleImage(Image.FromFile(fi.FullName), pbx.Height, pbx.Width)
                    AddHandler pbx.Click, AddressOf showReplacementPicture 'show the replacement picture full size
                    AddHandler pbx.MouseDown, AddressOf pic_MouseDown
                    AddHandler pbx.MouseMove, AddressOf pic_MouseMoveFromReplacementPanel
                    Panel_ReplacementImagesFlow.Controls.Add(pbx)
                Next 'loop of images of a given extension
            Next 'loop through extensions

            'process audio files
            extensionList = New List(Of String)(New String() {"*.ogg", "*.aiff", "*.mod"}) 'ugly syntax!
            For Each ext In extensionList
                For Each fi As FileInfo In New DirectoryInfo(FolderBrowserDialog1.SelectedPath).GetFiles(ext)
                    Dim pbx As New PictureBox
                    pbx.Width = 300
                    pbx.Height = 75
                    pbx.Name = fi.FullName
                    pbx.BorderStyle = BorderStyle.FixedSingle
                    'create an image to represent the file
                    Dim newImage As New Bitmap(300, 75) 'blank image
                    Dim gr As Graphics = Graphics.FromImage(newImage)
                    Dim myFontLabels As New Font("Arial", 10)
                    Dim myBrushLabels As New SolidBrush(Color.Black)
                    gr.DrawString(pbx.Name, myFontLabels, myBrushLabels, 1, 1) '# last 2 number are X and Y coords.
                    pbx.Image = newImage
                    AddHandler pbx.MouseDown, AddressOf pic_MouseDown
                    AddHandler pbx.MouseMove, AddressOf audio_MouseMoveFromReplacementPanel
                    Panel_ReplacementImagesFlow.Controls.Add(pbx)
                Next 'loop of images of a given extension
            Next 'loop through extensions
        End If

    End Sub




    'grab the games images from memory and display in game images panel
    Private Sub ShowGameImages_Click(sender As Object, e As EventArgs) Handles Button_ShowGameImages.Click

        'Dim listOfPics = chunkList.Skip(252).Take(200) 'testing only...
        Dim listOfPics = chunkList
        Dim name As String = ""
        Dim type As String = ""
        Dim img As Image

        Panel_GameImagesFlow.Controls.Clear()

        For Each pic In listOfPics

            type = FormatBytes(pic.chunkname, "Text")
            'DebugScreen("type: " + type)

            If (type.Trim = "PNG" Or type.Trim = "JPG") Then
                name = pic.indexnumber
                'DebugScreen("name: " + name)

                Using ms As System.IO.MemoryStream = New System.IO.MemoryStream(pic.chunkdata)
                    img = System.Drawing.Image.FromStream(ms)
                End Using

                Dim pbx As New PictureBox
                pbx.AllowDrop = True
                pbx.Width = 150
                pbx.Height = 150
                pbx.BorderStyle = BorderStyle.FixedSingle
                pbx.Name = name 'this is really the index number
                pbx.Image = ScaleImage(img, pbx.Height, pbx.Width)
                img.Dispose()
                AddHandler pbx.Click, AddressOf showGamePicture 'show the game picture full size
                AddHandler pbx.DragEnter, AddressOf picdest_DragEnter
                AddHandler pbx.DragDrop, AddressOf picdest_DragDropIntoGameImages
                Panel_GameImagesFlow.Controls.Add(pbx)
            End If
        Next
    End Sub



    'scale an image
    'http://www.vbforums.com/showthread.php?661547-VB-Net-Simple-Proper-Image-Scaling-in-Correct-Aspect-Ratio
    Public Function ScaleImage(ByVal OldImage As Image, ByVal TargetHeight As Integer, ByVal TargetWidth As Integer) As System.Drawing.Image

        Dim NewHeight As Integer = TargetHeight
        Dim NewWidth As Integer = NewHeight / OldImage.Height * OldImage.Width

        If NewWidth > TargetWidth Then
            NewWidth = TargetWidth
            NewHeight = NewWidth / OldImage.Width * OldImage.Height
        End If

        Return New Bitmap(OldImage, NewWidth, NewHeight)

    End Function


    'allow autoscroll by setting focus on game images panel and replacement images panel

    Private Sub panel_MouseEnter(sender As Object, e As EventArgs) Handles Panel_ReplacementImagesFlow.MouseEnter, Panel_GameImagesFlow.MouseEnter
        sender.Select()
    End Sub













    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        Dim formHeight = Me.Size.Height
        Dim formWidth = Me.Size.Width

        MenuItem_SaveToolStrip.Available = False
        MenuItem_SaveImageSetToolStrip.Available = False
        OpenImageSetToolStripMenuItem.Available = False

        Panel_GameImagesFlow.AllowDrop = True

        'logfile location
        Dim strPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        Dim strFile As String = "BlorbSmacker.Log"
        Dim combinedStr As String = Path.Combine(strPath, strFile)
        logFilename = New Uri(combinedStr).LocalPath.ToString

        'ImageWorkPictureBox setup
        PictureBox_Align.AllowDrop = True
        AddHandler PictureBox_Align.DragEnter, AddressOf picdest_DragEnter
        'AddHandler PictureBox_Align.DragDrop, AddressOf picdest_DragDropIntoAlignPicture

    End Sub








    Private Sub OpenImageSetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenImageSetToolStripMenuItem.Click
        Dim ch As New Chunk()
        Dim chunkSize As Integer
        Dim gameCh As Chunk
        Dim imgNumberBytes() As Byte

        Dim initialDir As String = ""
        initialDir = getRegistryValue("gameLoadDirectory")
        If initialDir > "" Then
            If Directory.Exists(initialDir + "\") = False Then
                initialDir = "c:\"
            End If
        End If
        DebugScreen("ImageSet load directory: " + initialDir)

        OpenFileDialog1.Title = "Select an ImageSet file to open"
        OpenFileDialog1.InitialDirectory = initialDir
        OpenFileDialog1.Filter = "ImageSet | *.imgset"


        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then


            imageSetLoadFilename = OpenFileDialog1.FileName

            Dim fi As New FileInfo(imageSetLoadFilename)
            filelength = fi.Length
            DebugScreen("Filename: " + loadFilename + vbCrLf)
            DebugScreen("File length from file: " + filelength.ToString + vbCrLf)
            ReDim buffer(filelength - 1) 'arrays start at 0
            buffer = File.ReadAllBytes(imageSetLoadFilename) 'we can reuse the in-game buffer
            mempointer = 0

            'check the header
            Dim hdr As String
            hdr = System.Text.ASCIIEncoding.ASCII.GetString(getChunk(20))
            If hdr <> "BlorbSmackerImageSet" Then
                DebugLog("File is not a BlorbSmacker ImageSet.")
                DebugScreen("File is not a BlorbSmacker ImageSet.")
                Exit Sub
            End If

            'go through the image set. for each chunk
            mempointer = 20
            While mempointer < filelength
                imgNumberBytes = ProcessNext4Bytes()

                ch.indexnumber = FormatBytes(imgNumberBytes, "Decimal")
                DebugScreen("Imageset has this index number: " + ch.indexnumber.ToString)
                DebugLog("Imageset has this index number: " + ch.indexnumber.ToString)

                ch.chunkname = ProcessNext4Bytes()
                ch.chunksize = ProcessNext4Bytes()
                chunkSize = FormatBytes(ch.chunksize, "Decimal")
                ReDim ch.chunkdata(chunkSize - 1)
                ch.chunkdata = getChunk(chunkSize)


                'replace the chunk data
                gameCh = findChunkByNumber(ch.indexnumber)
                If gameCh IsNot Nothing Then
                    gameCh.chunkname = ch.chunkname
                    gameCh.chunksize = ch.chunksize
                    ReDim gameCh.chunkdata(chunkSize - 1)
                    gameCh.chunkdata = ch.chunkdata
                End If

                'replace the in-game thumbnail image
                For Each cnt In Panel_GameImagesFlow.Controls
                    If TypeOf cnt Is PictureBox Then
                        If cnt.Name = ch.indexnumber Then
                            Using ms = New System.IO.MemoryStream(ch.chunkdata)
                                cnt.Image = ScaleImage(System.Drawing.Image.FromStream(ms), 150, 150)
                                cnt.Refresh()
                            End Using
                            Exit For
                        End If
                    End If
                Next

                'recreate the image set
                'see if the image is already in our imageset
                If imageSet.Contains(ch.indexnumber.ToString) Then 'if it exists already, then replace it
                    For Each cnt In Panel_ImageSetFlow.Controls
                        If TypeOf cnt Is PictureBox Then
                            If cnt.Name = ch.indexnumber Then
                                Using ms = New System.IO.MemoryStream(ch.chunkdata)
                                    cnt.Image = ScaleImage(System.Drawing.Image.FromStream(ms), 150, 150)
                                End Using
                                'cnt.Image = ch.chunkdata
                                Exit For
                            End If
                        End If
                    Next
                Else 'otherwise add the new thumbnail image
                    imageSet.Add(ch.indexnumber.ToString, "") 'picture name
                    Dim pbx As New PictureBox
                    pbx.Width = 150
                    pbx.Height = 150
                    pbx.Name = ch.indexnumber
                    pbx.BorderStyle = BorderStyle.FixedSingle
                    Using ms = New System.IO.MemoryStream(ch.chunkdata)
                        pbx.Image = ScaleImage(System.Drawing.Image.FromStream(ms), 150, 150)
                    End Using
                    Panel_ImageSetFlow.Controls.Add(pbx)
                End If


            End While

            For Each item In imageSet
                DebugLog("Image Set item: " + item.Key.ToString)
                DebugScreen("Image Set item: " + item.Key.ToString)
            Next

        End If 'OK dialog presses

    End Sub



End Class
