Imports System.IO

Partial Public Class MainForm

    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ' Save and Load, Process and write chunks


    'rebuild all the resource index pointers to chunks
    Private Sub AdjustResourceInformation()
        Dim mpointer As Long
        Dim indNumber As Integer
        Dim chSize As Integer

        DebugLog("Adjusting resource index pointers")
        mpointer = (indexList.Count + 2) * 12 ' first chunk will be here. (# indexes + 2) * 12 (12 bytes per index, and header uses 12 and we are 0 based, so add 1 for that)


        For Each ch In chunkList
            DebugLog("Processing chunk with index number: " + ch.indexnumber.ToString)
            'loop through resource indexes and find the resource corresponding to this chunk
            For Each ind In indexList
                indNumber = FormatBytes(ind.indexNumber, "Decimal")
                'update the starting position
                If indNumber = ch.indexnumber Then
                    DebugLog("Found resource index for chunk. Adjusting resource pointer to: " + mpointer.ToString + "(d)")
                    ind.startsAt = DecimalTo4ByteArray(mpointer)
                    Exit For
                End If
            Next
            'Else 'if there is an idex number for a given chunk
            'DebugLog("Chunk has no resource index")
            'End If


            chSize = FormatBytes(ch.chunksize, "Decimal") + 8
            mpointer = mpointer + chSize
            If (mpointer Mod 2) <> 0 Then 'pad to even byte count.
                mpointer += 1
            End If


        Next 'loop through each chunk
        DebugLog("MPointer after adjusting resources: " + mpointer.ToString)
        DebugLog("Adjusting header file size to: " + (mpointer - 8).ToString)
        headerCL.filesize = DecimalTo4ByteArray(mpointer - 8)

    End Sub







    'process initial load of file
    Private Sub processInitialFile()
        'when we assemble later, we will have
        '1) header
        '2) resource index chunk that points to each chunk. All indexes point to a chunk. BUT, not all chunks have indexes. 
        '3) chunks


        'process header
        headerCL.hdr1 = ProcessNext4Bytes()
        headerCL.filesize = ProcessNext4Bytes()
        headerCL.hdr2 = ProcessNext4Bytes()
        DebugLog("header 1: " + FormatBytes(headerCL.hdr1, "Text") + "   header filesize(d): " + FormatBytes(headerCL.filesize, "Decimal") + "   header 2: " + FormatBytes(headerCL.hdr2, "Text") + vbCrLf)


        'chunk 1 MUST be the Resource Index by definition 'http://www.eblong.com/zarf/blorb/blorb.html

        resourceIndexChunk.chunkname = ProcessNext4Bytes()
        resourceIndexChunk.chunklength = ProcessNext4Bytes()
        resourceIndexChunk.numberOfResources = ProcessNext4Bytes()
        DebugLog("chunk name: " + FormatBytes(resourceIndexChunk.chunkname, "Text") + "  chunk length(d): " + FormatBytes(resourceIndexChunk.chunklength, "Decimal") + "   chunk number of resources(d): " + FormatBytes(resourceIndexChunk.numberOfResources, "Decimal") + vbCrLf)

        'the resource chunk has indexes
        Dim chunkName As String = FormatBytes(resourceIndexChunk.chunkname, "Text")
        If chunkName = "RIdx" Then
            Dim indexCount = FormatBytes(resourceIndexChunk.numberOfResources, "Decimal")
            For x As Integer = 0 To indexCount - 1
                Dim index As New Index()
                index.indexName = ProcessNext4Bytes()
                index.indexNumber = ProcessNext4Bytes()
                index.startsAt = ProcessNext4Bytes()
                indexList.Add(index)
                DebugLog("index name: " + FormatBytes(index.indexName, "Text") + "  index number(d): " + FormatBytes(index.indexNumber, "Decimal") + "   starts at(h): " + FormatBytes(index.startsAt, "Hex") + vbCrLf)
            Next
        End If

        'now we start processing all other chunks.

        Dim chunksize As Integer

        While mempointer < filelength
            Dim chunk As New Chunk()
            chunk.indexnumber = getIndexNumber()
            chunk.chunkname = ProcessNext4Bytes()
            chunk.chunksize = ProcessNext4Bytes()
            chunksize = FormatBytes(chunk.chunksize, "Decimal")
            DebugLog("mempointer(d): " + (mempointer - 8).ToString + "   chunk name: " + FormatBytes(chunk.chunkname, "Text") + "   chunk size(h): " + FormatBytes(chunk.chunksize, "Hex") + " chunk size(d): " + chunksize.ToString)
            ReDim chunk.chunkdata(chunksize - 1)
            chunk.chunkdata = getChunk(chunksize)
            DebugLog("new mempointer after getChunkSize(): " + mempointer.ToString + vbCrLf)
            chunkList.Add(chunk)
            If (mempointer Mod 2) <> 0 Then 'if we don't end on an even boundary, bump the pointer by one 
                mempointer = mempointer + 1
            End If
        End While

        DebugLog("Finished processing data structures. Nunber of chunks: " + chunkList.Count.ToString + " Number of indexes: " + indexList.Count.ToString)
        DebugScreen("Finished processing data structures. Nunber of chunks: " + chunkList.Count.ToString + " Number of indexes: " + indexList.Count.ToString)

    End Sub





    ' save file
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItem_SaveToolStrip.Click

        Dim initialDir As String = ""
        initialDir = getRegistryValue("gameSaveDirectory")
        If initialDir > "" Then
            If Directory.Exists(initialDir + "\") = False Then
                initialDir = "c:\"
            End If
        End If
        DebugScreen("Game save directory: " + initialDir)

        SaveFileDialog1.Title = "Select a filename to save as"
        SaveFileDialog1.InitialDirectory = initialDir
        SaveFileDialog1.Filter = "GBlorb File | *.gblorb"
        SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(loadFilename) + " - " + DateTime.Now.ToString("HH-mm-ss") + Path.GetExtension(loadFilename)
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then


            savefilename = SaveFileDialog1.FileName

            Dim s As New System.IO.FileStream(savefilename, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
            Dim wfl As Long = 0 ' write file length
            Dim nullbyte() As Byte = {0}

            Dim fi As New FileInfo(savefilename)
            setRegistryValue("gameSaveDirectory", fi.Directory.FullName.ToString)

            AdjustResourceInformation() 'rebuild all the resource index pointers to chunks

            DebugLog(vbCrLf + "Writing Header")
            DebugScreen(vbCrLf + "Writing Header")
            s.Write(headerCL.hdr1, 0, headerCL.hdr1.Length)
            wfl += headerCL.hdr1.Length
            s.Write(headerCL.filesize, 0, headerCL.filesize.Length)
            wfl += headerCL.filesize.Length
            s.Write(headerCL.hdr2, 0, headerCL.hdr2.Length)
            wfl += headerCL.hdr2.Length
            DebugLog("Wrote: " + wfl.ToString + " total bytes")
            DebugScreen("Wrote: " + wfl.ToString + " total bytes")

            DebugLog("Writing Resoure Index Chunk")
            DebugScreen("Writing Resource Index Chunk")
            DebugLog("Resource index chunk starts at: " + s.Length.ToString)
            s.Write(resourceIndexChunk.chunkname, 0, resourceIndexChunk.chunkname.Length)
            wfl += resourceIndexChunk.chunkname.Length
            s.Write(resourceIndexChunk.chunklength, 0, resourceIndexChunk.chunklength.Length)
            wfl += resourceIndexChunk.chunklength.Length
            s.Write(resourceIndexChunk.numberOfResources, 0, resourceIndexChunk.numberOfResources.Length)
            wfl += resourceIndexChunk.numberOfResources.Length
            DebugScreen("Wrote: " + wfl.ToString + " total bytes")

            DebugLog("Writing Resoure Indexes")
            DebugScreen("Writing Resource Indexes")
            For Each ind In indexList
                DebugLog("Resource Index starts at: " + s.Length.ToString)
                s.Write(ind.indexName, 0, ind.indexName.Length)
                wfl += ind.indexName.Length
                s.Write(ind.indexNumber, 0, ind.indexNumber.Length)
                wfl += ind.indexName.Length
                s.Write(ind.startsAt, 0, ind.startsAt.Length)
                wfl += ind.startsAt.Length
            Next
            DebugScreen("Wrote: " + wfl.ToString + " total bytes")

            DebugLog("Writing All Other Chunks")
            DebugScreen("Writing All Other Chunks")
            For Each ch In chunkList
                DebugLog("Chunk starts at: " + s.Length.ToString)
                s.Write(ch.chunkname, 0, ch.chunkname.Length)
                wfl += ch.chunkname.Length
                DebugLog("chunk name: " + FormatBytes(ch.chunkname, "Text"))
                'DebugLog("Wrote: " + wfl.ToString + " bytes")
                s.Write(ch.chunksize, 0, ch.chunksize.Length)
                DebugLog("chunk length: " + FormatBytes(ch.chunksize, "Decimal"))
                wfl += ch.chunksize.Length
                'DebugLog("Wrote: " + wfl.ToString + " bytes")
                s.Write(ch.chunkdata, 0, ch.chunkdata.Length)
                wfl += ch.chunkdata.Length
                DebugLog("Wrote: " + wfl.ToString + " total bytes")
                If (wfl Mod 2) <> 0 Then
                    DebugLog("Padding chunk with 0 byte()")
                    'DebugScreen("Padding chunk with 0 byte()")
                    wfl += 1
                    s.Write(nullbyte, 0, 1)
                End If
            Next
            DebugLog("Wrote: " + wfl.ToString + " total bytes")
            DebugScreen("Wrote: " + wfl.ToString + " total bytes")
            DebugLog("Finished Writing File")
            DebugScreen("Finished Writing File")

            s.Close()

        End If
    End Sub




    'open file menu
    Private Sub OpenFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItem_OpenFileToolStrip.Click

        Dim initialDir As String = ""
        initialDir = getRegistryValue("gameLoadDirectory")
        If initialDir > "" Then
            If Directory.Exists(initialDir + "\") = False Then
                initialDir = "c:\"
            End If
        End If
        DebugScreen("Game load directory: " + initialDir)

        OpenFileDialog1.Title = "Select a file to open"
        OpenFileDialog1.InitialDirectory = initialDir
        OpenFileDialog1.Filter = "GBlorb File | *.gblorb"
        OpenFileDialog1.FileName = "Trap Quest 160301D.gblorb"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then


            loadFilename = OpenFileDialog1.FileName

            Dim fi As New FileInfo(loadFilename)
            filelength = fi.Length
            DebugScreen("Filename: " + loadFilename + vbCrLf)
            DebugScreen("File length from file: " + filelength.ToString + vbCrLf)
            ReDim buffer(filelength - 1) 'arrays start at 0
            buffer = File.ReadAllBytes(loadFilename)

            Dim strPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
            If File.Exists(logFilename) Then
                File.Delete(logFilename)
            End If

            setRegistryValue("gameLoadDirectory", fi.Directory.FullName.ToString) ' set the default game load directory

            Me.Update() 'remove file open dialog
            DebugScreen("Processing file.. Large files may take a while. I'm too lazy to multithread this, so the UI may appear hung for a bit.")

            processInitialFile()
            MenuItem_OpenFileToolStrip.Available = False
            MenuItem_SaveToolStrip.Available = True
            OpenImageSetToolStripMenuItem.Available = True
            MenuItem_SaveImageSetToolStrip.Available = True
        End If

    End Sub



    'write all chunks to disk
    Private Sub ExtractAllResourcesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItem_ExtractAllResourcesToolStrip.Click

        Dim chunkName As String
        Dim pathName As String
        Dim fileName As String

        'path where we loaded the file from
        pathName = Path.GetDirectoryName(loadFilename)

        For Each ch In chunkList
            chunkName = FormatBytes(ch.chunkname, "Text")
            If ch.indexnumber = 999999 Then
                fileName = chunkName.Trim + "." + chunkName.Trim
            Else
                fileName = chunkName.Trim + ch.indexnumber.ToString + "." + chunkName.Trim
            End If

            fileName = Path.Combine(pathName + "\" + fileName)

            DebugLog("Writing chunk: " + fileName)
            Dim s As New System.IO.FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
            s.Write(ch.chunkdata, 0, FormatBytes(ch.chunksize, "Decimal"))
            s.Close()
        Next
        DebugScreen("Finished extracting resources.")
    End Sub





    'save image set
    Private Sub SaveImageSetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItem_SaveImageSetToolStrip.Click
        Dim imgNumber As Integer
        Dim ch As New Chunk()

        Dim initialDir As String = ""
        initialDir = getRegistryValue("gameSaveDirectory")
        If initialDir > "" Then
            If Directory.Exists(initialDir + "\") = False Then
                initialDir = "c:\"
            End If
        End If
        DebugScreen("ImageSet save directory: " + initialDir)

        SaveFileDialog1.Title = "Select a filename to save as"
        SaveFileDialog1.InitialDirectory = initialDir
        SaveFileDialog1.Filter = "ImageSet | *.imgset"
        SaveFileDialog1.FileName = Path.GetFileNameWithoutExtension(loadFilename) + " - " + DateTime.Now.ToString("HH-mm-ss") + Path.GetExtension(loadFilename)
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            imageSetSaveFilename = SaveFileDialog1.FileName

            Dim s As New System.IO.FileStream(imageSetSaveFilename, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
            Dim nullbyte() As Byte = {0}

            DebugLog(vbCrLf + "Writing ImageSet Header")
            DebugScreen(vbCrLf + "Writing ImageSet Header")
            s.Write(System.Text.Encoding.ASCII.GetBytes("BlorbSmackerImageSet"), 0, 20)

            'this is just a list of image numbers
            For Each img In imageSet
                imgNumber = img.Key
                ch = findChunkByNumber(imgNumber) 'grab our chunk from the in game images
                If ch IsNot Nothing Then ' make sure we got it
                    s.Write(DecimalTo4ByteArray(imgNumber), 0, 4)
                    DebugLog("Chunk index numer: " + ch.indexnumber.ToString)
                    s.Write(ch.chunkname, 0, ch.chunkname.Length) 'PNG, etc
                    DebugLog("chunk name: " + FormatBytes(ch.chunkname, "Text"))
                    s.Write(ch.chunksize, 0, ch.chunksize.Length)
                    DebugLog("chunk length: " + FormatBytes(ch.chunksize, "Decimal"))
                    s.Write(ch.chunkdata, 0, ch.chunkdata.Length)
                End If
            Next
            s.Close()
            DebugLog("Finished writing ImageSet.")
            DebugScreen("Finished writing ImageSet.")
        End If
    End Sub


End Class
