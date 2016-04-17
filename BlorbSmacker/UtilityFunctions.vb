Imports System.IO

Partial Public Class MainForm

    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    'Misc utility functions


    'this will get xx bytes belonging to a chunk and set the mempointer ahead
    Private Function getChunk(s As Integer) As Byte()
        Dim b(s - 1) As Byte
        For x As Integer = 0 To s - 1
            b(x) = buffer(mempointer + x)
        Next
        mempointer += s
        DebugLog("chunk size: " + b.Length.ToString + "  current mempointer(d): " + mempointer.ToString + " adding bytes: " + s.ToString)
        Return b

    End Function




    'using our filepointer, grab the next 4 bytes and increase the pointer
    Private Function ProcessNext4Bytes() As Byte()
        Dim smallbuf(3) As Byte
        smallbuf(0) = buffer(mempointer)
        smallbuf(1) = buffer(mempointer + 1)
        smallbuf(2) = buffer(mempointer + 2)
        smallbuf(3) = buffer(mempointer + 3)

        mempointer = mempointer + 4
        Return smallbuf
    End Function




    'given a series of 4 bytes, convert them to a string of decimal, hex or text
    Private Function FormatBytes(b As Byte(), display As String) As String
        Dim returnval As String = ""

        If (display = "Hex") Then
            returnval = b(0).ToString("X2") + b(1).ToString("X2") + b(2).ToString("X2") + b(3).ToString("X2")
        ElseIf (display = "Decimal") Then
            Dim tempstr As String = b(0).ToString("X2") + b(1).ToString("X2") + b(2).ToString("X2") + b(3).ToString("X2")
            returnval = Integer.Parse(tempstr, System.Globalization.NumberStyles.HexNumber).ToString
        ElseIf (display = "Text") Then
            returnval = Convert.ToChar(b(0)) + Convert.ToChar(b(1)) + Convert.ToChar(b(2)) + Convert.ToChar(b(3))
        End If
        Return returnval
    End Function



    'write a line to our debug file
    Private Sub DebugLog(s As String)
        Using sw As New StreamWriter(File.Open(logFilename, FileMode.Append))
            sw.WriteLine(s)
        End Using

    End Sub



    'write a line to our debug screen box
    Private Sub DebugScreen(s As String)
        DebugRTB.AppendText(s + vbCrLf)
        DebugRTB.Refresh()
        DebugRTB.SelectionStart = DebugRTB.TextLength
        DebugRTB.ScrollToCaret()

    End Sub





    'read a key from the registry
    Private Function getRegistryValue(key As String) As String
        Dim value As String = ""

        Dim regkey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\BlorbSmacker\")
        If regkey IsNot Nothing Then
            value = regkey.GetValue(key)
        End If

        Return value
    End Function



    'set a key in the registry
    Private Sub setRegistryValue(key As String, data As String)
        Dim regkey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\BlorbSmacker\") 'make sure that our subkey exists
        regkey.SetValue(key, data)
    End Sub




    Private Function DecimalTo4ByteArray(x As Integer) As Byte()
        Dim b(3) As Byte

        Dim str As String = x.ToString("X8")
        'DebugScreen("size str: " + str)
        b(0) = CInt("&H" & str.Substring(0, 2))
        b(1) = CInt("&H" & str.Substring(2, 2))
        b(2) = CInt("&H" & str.Substring(4, 2))
        b(3) = CInt("&H" & str.Substring(6, 2))
        Return b
    End Function




    'given a memory location, check the indexList List and see if that memory location exists. If it does, return a byte array that has the index number containing that memory location
    Private Function getIndexNumber()

        Dim memptrstr As String
        Dim indptr As String
        Dim indexNumber = 999999

        'take mempointer and convert it to a 4 byte hex array
        memptrstr = mempointer.ToString("X8")

        For Each x In indexList
            indptr = FormatBytes(x.startsAt, "Hex")
            'DebugLog("comparing memptr: " + memptrstr + " indstr: " + indptr)
            If indptr = memptrstr Then
                DebugLog("found match: " + indptr + " setting index(d) to: " + FormatBytes(x.indexNumber, "Decimal"))
                indexNumber = FormatBytes(x.indexNumber, "Decimal")
                Exit For
            End If
        Next

        Return indexNumber
    End Function



    'given an index number, return that chunk
    Private Function findChunkByNumber(imgnumber) As Chunk

        Dim ch As New Chunk()

        For Each c In chunkList
            'DebugScreen("imagenumber: " + imgnumber.ToString + " chunk imgno: " + imgno)
            If c.indexnumber = imgnumber Then
                'DebugScreen("found chunk")
                ch = c
                Exit For
            End If
        Next

        Return ch
    End Function

End Class
