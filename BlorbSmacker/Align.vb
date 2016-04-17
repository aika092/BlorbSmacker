Partial Public Class MainForm


    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    'align /resize functions for align control


    'when the mouse enters the imageworkpicturebox, update the handles on the corner
    'http://www.experts-exchange.com/questions/22393558/resizing-picturebox-using-mouse-in-vb-net.html
    Private Sub PictureBox_AlignMouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox_Align.MouseEnter

        If alignLayer1 Is Nothing Then Exit Sub

        AlignUpdateHandles()
        inPB = True
        PictureBox_Align.Refresh()

    End Sub

    'create the rectangles that represent grab points in the proper space
    Private Sub AlignUpdateHandles()
        rc1 = New Rectangle(atX, atY, handleSize, handleSize) ' top left
        rc2 = New Rectangle(atX, atY + alignLayer1.Height - handleSize - 2, handleSize, handleSize) ' bottom left
        rc3 = New Rectangle(atX + alignLayer1.Width - handleSize - 2, atY, handleSize, handleSize) ' top right
        rc4 = New Rectangle(atX + alignLayer1.Width - handleSize - 2, atY + alignLayer1.Height - handleSize - 2, handleSize, handleSize) ' bottom right

    End Sub

    'draw the rectangle pointers on the image
    Private Sub PictureBox_AlignPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox_Align.Paint
        If inPB Then
            e.Graphics.FillRectangle(Brushes.Red, rc1)
            e.Graphics.FillRectangle(Brushes.Red, rc2)
            e.Graphics.FillRectangle(Brushes.Red, rc3)
            e.Graphics.FillRectangle(Brushes.Red, rc4)
        End If
    End Sub




    'some of the align code was found on-line... but it's been fairly heavily modified.
    'if the left mouse button is clicked, get the starting position
    Private Sub PictureBox_Align_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Align.MouseDown

        If alignLayer1 Is Nothing Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Left Then
            mouseDownX = e.X
            mouseDownY = e.Y

            'DebugScreen("mouse down layer 1 starts at: " + atX.ToString + " " + atY.ToString)
            'DebugScreen("mouse down location: " + mouseDownX.ToString + " " + mouseDownY.ToString)

            If overHandle Then 'if the mouse button is down and the mouse is over one of our grab points
                resizing = True
                If rc1.Contains(e.X, e.Y) Then
                    startPoint = New Point(atX + alignLayer1.Width, alignLayer1.Height + atY + Panel_AlignHeader.Height)
                    endPoint = New Point(atX, Panel_AlignHeader.Height + atY)
                ElseIf rc2.Contains(e.X, e.Y) Then
                    startPoint = New Point(alignLayer1.Width + atX, atY + Panel_AlignHeader.Height)
                    endPoint = New Point(atX, alignLayer1.Height + atY + Panel_AlignHeader.Height)
                ElseIf rc3.Contains(e.X, e.Y) Then
                    startPoint = New Point(atX, alignLayer1.Height + atY + Panel_AlignHeader.Height)
                    endPoint = New Point(atX + alignLayer1.Width, Panel_AlignHeader.Height + atY)
                ElseIf rc4.Contains(e.X, e.Y) Then
                    startPoint = New Point(atX, atY + Panel_AlignHeader.Height)
                    endPoint = New Point(atX + alignLayer1.Width, Panel_AlignHeader.Height + atY + alignLayer1.Height)
                End If
                lastPoint = New Point(e.X, e.Y)
                screenRC = PictureBox_ImageWork.RectangleToScreen(NormalizedRC(startPoint, endPoint))
                ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
            End If ' mouse over grab point
        End If 'left button clicked
    End Sub



    Private Sub PictureBox_Align_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Align.MouseMove


        If PictureBox_Align.Image Is Nothing Or alignLayer1 Is Nothing Then Exit Sub

        overHandle = rc1.Contains(e.X, e.Y) OrElse rc2.Contains(e.X, e.Y) OrElse rc3.Contains(e.X, e.Y) OrElse rc4.Contains(e.X, e.Y)
        If resizing Then ' if we are resizing
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
            endPoint.X = endPoint.X + (e.X - lastPoint.X)
            endPoint.Y = endPoint.Y + (e.Y - lastPoint.Y)
            lastPoint = New Point(e.X, e.Y)

            screenRC = PictureBox_ImageWork.RectangleToScreen(NormalizedRC(startPoint, endPoint))
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
        Else 'we are panning image
            'if we are moving the mouse, figure out the size of the box to draw
            If e.Button = Windows.Forms.MouseButtons.Left Then
                'DebugScreen("image start x: " + atX.ToString + " mousedown x: " + mouseDownX.ToString + " mouse now x: " + e.X.ToString)
                drawx = atX + (e.X - mouseDownX)
                drawy = atY + (e.Y - mouseDownY)

                'DebugScreen("draw layer 1 at: " + drawx.ToString + " " + drawy.ToString)
                drawLayers(-drawx, -drawy)
            End If
        End If 'finished doing something

    End Sub



    Private Sub PictureBox_Align_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Align.MouseUp
        If alignLayer1 Is Nothing Then Exit Sub

        If resizing Then
            resizing = False
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
            Dim newPosition As Rectangle = Me.RectangleToClient(PictureBox_ImageWork.RectangleToScreen(NormalizedRC(startPoint, endPoint)))
            PictureBox_ImageWork.SuspendLayout()
            'ImageWorkPictureBox.Location = newPosition.Location
            PictureBox_ImageWork.Size = newPosition.Size
            alignLayer1 = ScaleImage(alignLayer1, newPosition.Size.Height, newPosition.Size.Width)
            'DebugScreen("layer1 size: " + alignLayer1.Size.ToString)
            alignBitmap = DirectCast(alignLayer1, Bitmap)
            PictureBox_ImageWork.ResumeLayout()
            UpdateHandles()
            PictureBox_ImageWork.Refresh()
            DebugLog("Image resized to: " + PictureBox_ImageWork.Size.Width.ToString + " x " + PictureBox_ImageWork.Size.Height.ToString)
            DebugScreen("Image resized to: " + PictureBox_ImageWork.Size.Width.ToString + " x " + PictureBox_ImageWork.Size.Height.ToString)
        End If
        'drawLayers(lastPoint.X, lastPoint.Y)
        'set a new starting image position
        atX = drawx
        atY = drawy
        'DebugScreen("mouse up location: " + mouseUpX.ToString + " " + mouseUpY.ToString)
        'DebugScreen("mouse up image starts at: " + atX.ToString + " " + atY.ToString)
        'redraw the resize handles
        drawLayers(-atX, -atY)
        AlignUpdateHandles()
        PictureBox_Align.Refresh()
    End Sub




    Private Sub PictureBox_AlignDragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles PictureBox_Align.DragDrop
        alignLayer1 = e.Data.GetData(DataFormats.Bitmap)
        alignBitmap = DirectCast(alignLayer1, Bitmap)
        alignNewBitmap = New Bitmap(alignLayer0.Width, alignLayer0.Height)
        drawLayers(0, 0)
    End Sub



    Private Sub drawLayers(x As Integer, y As Integer)
        If alignLayer1 Is Nothing Then Exit Sub
        Dim tmppic = New PictureBox()
        tmppic.Image = New Bitmap(PictureBox_Align.Image.Width, PictureBox_Align.Image.Height)

        'Using g As Graphics = Graphics.FromImage(alignNewBitmap)
        Using g As Graphics = Graphics.FromImage(tmppic.Image)
            'g.Clear(Panel_AlignHeader.BackColor)

            'draw the original image with transparency
            cm(3, 3) = 0.3
            atr.SetColorMatrix(cm)
            Dim r As New Rectangle(0, 0, alignLayer0.Width, alignLayer0.Height)
            g.DrawImage(alignLayer0, r, 0, 0, r.Width, r.Height, Drawing.GraphicsUnit.Pixel, atr)

            'draw the new image at given location
            cm(3, 3) = 1
            atr.SetColorMatrix(cm)
            'atX = m_startPanPointX - x
            'atY = m_startPanPointY - y

            'DebugScreen("layer 1 img start: " + atX.ToString + " " + atY.ToString)
            g.DrawImage(alignBitmap, r, x, y, r.Width, r.Height, Drawing.GraphicsUnit.Pixel, atr)


            'PictureBox_Align.Refresh()
            PictureBox_Align.Image = tmppic.Image
            PictureBox_Align.Refresh()
        End Using
        GC.Collect()

    End Sub


    Private Sub Button_AlignCopyToWorkImage_Click(sender As Object, e As EventArgs) Handles Button_AlignCopyToWorkImage.Click

        PictureBox_ImageWork.Size = New Size(alignNewBitmap.Width, alignNewBitmap.Height)
        PictureBox_Align.Size = New Size(alignNewBitmap.Width, alignNewBitmap.Height)
        'DebugScreen("align size: " + PictureBox_Align.Size.Width.ToString + " " + PictureBox_Align.Size.Height.ToString)
        'atr.SetColorKey(Panel_AlignHeader.BackColor, Panel_AlignHeader.BackColor) ' set transparency

        Using g As Graphics = Graphics.FromImage(alignNewBitmap)
            'g.Clear(Panel_AlignHeader.BackColor)

            Dim r As New Rectangle(0, 0, alignLayer0.Width, alignLayer0.Height)
            'DebugScreen("layer 1 img start: " + atX.ToString + " " + atY.ToString)
            'DebugScreen("draw start: " + drawx.ToString + " " + drawy.ToString)
            g.DrawImage(alignBitmap, r, -drawx, -drawy, r.Width, r.Height, Drawing.GraphicsUnit.Pixel, atr)

            PictureBox_ImageWork.Image = alignNewBitmap
            PictureBox_ImageWork.Refresh()
        End Using

    End Sub

End Class
