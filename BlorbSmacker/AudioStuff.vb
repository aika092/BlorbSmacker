Imports System.IO

Partial Public Class MainForm

    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    'audio file stuff


    'show audio file in the flow layout panel
    Private Sub ShowAudioFilesButton_Click(sender As Object, e As EventArgs) Handles Button_ShowAudioFiles.Click

        Dim name As String = ""
        Dim type As String = ""

        Panel_AudioFlowLayout.Controls.Clear()

        For Each ch In chunkList
            type = FormatBytes(ch.chunkname, "Text")
            'DebugScreen("type: " + type)

            If (type.Trim = "FORM" Or type.Trim = "OGGV" Or type.Trim = "MOD") Then
                name = ch.indexnumber
                'DebugScreen("name: " + name)
                Dim pbx As New PictureBox
                pbx.AllowDrop = True
                pbx.Width = 300
                pbx.Height = 75
                pbx.Name = name 'this is really the index number
                pbx.BorderStyle = BorderStyle.Fixed3D

                'create an image to represent the file
                Dim newImage As New Bitmap(150, 150) 'blank image
                Dim gr As Graphics = Graphics.FromImage(newImage)
                Dim myFontLabels As New Font("Arial", 10)
                Dim myBrushLabels As New SolidBrush(Color.Black)
                gr.DrawString(type.Trim + name, myFontLabels, myBrushLabels, 1, 1) '# last 2 number are X and Y coords.
                pbx.Image = newImage
                AddHandler pbx.DragEnter, AddressOf picdest_DragEnter
                AddHandler pbx.DragDrop, AddressOf audiodest_DragDropIntoGameAudio
                Panel_AudioFlowLayout.Controls.Add(pbx)

            End If
        Next
    End Sub


    'start the drag operation from replacementimage panel for audio
    Private Sub audio_MouseMoveFromReplacementPanel(ByVal sender As Object, e As EventArgs)
        Dim pic As PictureBox = DirectCast(sender, PictureBox)
        Dim bytes() As Byte = File.ReadAllBytes(pic.Name)

        If m_MouseIsDown Then
            DebugLog("file name: " + pic.Name)
            DebugScreen("file name: " + pic.Name)
            pic.DoDragDrop(pic.Name, DragDropEffects.Copy) 'send the file name to the reciever
        End If
        m_MouseIsDown = False
    End Sub


    'drop operation for destination into the game images panel
    Private Sub audiodest_DragDropIntoGameAudio(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
        ' Assign the image to the PictureBox.
        DebugLog("audio file dropped")
        DebugScreen("audio file dropped")
        Dim pic As PictureBox = DirectCast(sender, PictureBox)
        Dim chunkNumber = pic.Name  'get the chunk number
        DebugLog("chunk number: " + chunkNumber + " modified")
        DebugLog("chunk number: " + chunkNumber + " modified")
        DebugScreen("chunk number: " + chunkNumber + " modified")


        'now find the chunk with that number
        For Each ch In chunkList
            If chunkNumber = ch.indexnumber Then

                Dim fileName As String = e.Data.GetData(DataFormats.Text)
                Dim bytes() = File.ReadAllBytes(fileName)

                ReDim ch.chunkdata(bytes.Length - 1)

                ch.chunksize = DecimalTo4ByteArray(bytes.Length)
                ch.chunkdata = bytes
                DebugLog("audio length: " + FormatBytes(ch.chunksize, "Hex"))
                DebugScreen("audio length: " + FormatBytes(ch.chunksize, "Hex"))
                Exit For
            End If
        Next

    End Sub

End Class
