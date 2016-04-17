Partial Public Class MainForm

    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    'resize routines for the image work picture box

    'when the mouse enters the imageworkpicturebox, update the handles on the corner
    'http://www.experts-exchange.com/questions/22393558/resizing-picturebox-using-mouse-in-vb-net.html
    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox_ImageWork.MouseEnter
        If PictureBox_ImageWork.Focused() Then 'if our work panel has focus, show handles for resizing
            PictureBox_ImageWork.Focus()
            UpdateHandles()
            inPB = True
            PictureBox_ImageWork.Refresh()
        End If
    End Sub

    'create the rectangles that represent grab points in the proper space
    Private Sub UpdateHandles()
        rc1 = New Rectangle(0, 0, handleSize, handleSize)
        rc2 = New Rectangle(0, PictureBox_ImageWork.Image.Height - handleSize - 2, handleSize, handleSize)
        rc3 = New Rectangle(PictureBox_ImageWork.Image.Width - handleSize - 2, 0, handleSize, handleSize)
        rc4 = New Rectangle(PictureBox_ImageWork.Image.Width - handleSize - 2, PictureBox_ImageWork.Image.Height - handleSize - 2, handleSize, handleSize)
    End Sub

    'draw the rectangle pointers on the image
    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox_ImageWork.Paint
        If inPB Then
            e.Graphics.FillRectangle(Brushes.Red, rc1)
            e.Graphics.FillRectangle(Brushes.Red, rc2)
            e.Graphics.FillRectangle(Brushes.Red, rc3)
            e.Graphics.FillRectangle(Brushes.Red, rc4)
        End If
    End Sub


    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_ImageWork.MouseDown

        Dim pic As PictureBox = DirectCast(sender, PictureBox)

        If e.Button = Windows.Forms.MouseButtons.Left AndAlso overHandle Then 'if the mouse button is down and the mouse is over one of our grab points
            resizing = True
            If rc1.Contains(e.X, e.Y) Then
                startPoint = New Point(PictureBox_ImageWork.Image.Width, PictureBox_ImageWork.Image.Height)
                endPoint = New Point(0, 0)
            ElseIf rc2.Contains(e.X, e.Y) Then
                startPoint = New Point(PictureBox_ImageWork.Image.Width, 0)
                endPoint = New Point(0, PictureBox_ImageWork.Image.Height)
            ElseIf rc3.Contains(e.X, e.Y) Then
                startPoint = New Point(0, PictureBox_ImageWork.Image.Height)
                endPoint = New Point(PictureBox_ImageWork.Image.Width, 0)
            ElseIf rc4.Contains(e.X, e.Y) Then
                startPoint = New Point(0, 0)
                endPoint = New Point(PictureBox_ImageWork.Image.Width, PictureBox_ImageWork.Image.Height)
            End If
            lastPoint = New Point(e.X, e.Y)
            screenRC = PictureBox_ImageWork.RectangleToScreen(NormalizedRC(startPoint, endPoint))
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)

        Else 'set us up for drag and drop OR give focus to the window for resizing
            If Not pic.Image Is Nothing Then
                m_MouseIsDown = True
                hadFocus = Me.ActiveControl 'give 
                PictureBox_ImageWork.Focus()
            End If
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_ImageWork.MouseMove
        overHandle = rc1.Contains(e.X, e.Y) OrElse rc2.Contains(e.X, e.Y) OrElse rc3.Contains(e.X, e.Y) OrElse rc4.Contains(e.X, e.Y)
        If resizing Then ' if we are resizing
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
            endPoint.X = endPoint.X + (e.X - lastPoint.X)
            endPoint.Y = endPoint.Y + (e.Y - lastPoint.Y)
            lastPoint = New Point(e.X, e.Y)

            screenRC = PictureBox_ImageWork.RectangleToScreen(NormalizedRC(startPoint, endPoint))
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
            'ImageWorkPanel.Refresh()

        Else
            'start the drag operation from image work panel
            'just copy the bytes from the workpanel
            If m_MouseIsDown Then ' start the drag operation from image work panel - just copy the bytes from the workpanel
                Dim pic As PictureBox = DirectCast(sender, PictureBox)
                pic.DoDragDrop(pic.Image, DragDropEffects.Copy)
            End If
            m_MouseIsDown = False
        End If



    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_ImageWork.MouseUp
        If resizing Then
            resizing = False
            ControlPaint.DrawReversibleFrame(screenRC, PictureBox_ImageWork.BackColor, FrameStyle.Thick)
            Dim newPosition As Rectangle = Me.RectangleToClient(PictureBox_ImageWork.RectangleToScreen(NormalizedRC(startPoint, endPoint)))
            PictureBox_ImageWork.SuspendLayout()
            'ImageWorkPictureBox.Location = newPosition.Location
            PictureBox_ImageWork.Size = newPosition.Size
            PictureBox_ImageWork.Image = ScaleImage(PictureBox_ImageWork.Image, newPosition.Size.Height, newPosition.Size.Width)
            PictureBox_ImageWork.ResumeLayout()
            UpdateHandles()
            PictureBox_ImageWork.Refresh()
            DebugLog("Image resized to: " + PictureBox_ImageWork.Size.Width.ToString + " x " + PictureBox_ImageWork.Size.Height.ToString)
            DebugScreen("Image resized to: " + PictureBox_ImageWork.Size.Width.ToString + " x " + PictureBox_ImageWork.Size.Height.ToString)
        End If

    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox_ImageWork.MouseLeave
        inPB = False
        PictureBox_ImageWork.Refresh()
    End Sub

    Private Function NormalizedRC(ByVal ptA As Point, ByVal ptB As Point) As Rectangle
        Return New Rectangle(Math.Min(ptA.X, ptB.X), Math.Min(ptA.Y, ptB.Y), Math.Abs(ptA.X - ptB.X), Math.Abs(ptA.Y - ptB.Y))
    End Function

End Class


