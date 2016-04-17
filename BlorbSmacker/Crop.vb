Partial Public Class MainForm


    'http://www.dotnetheaven.com/article/crop-an-image-using-vb.net
    Private Sub Button_CropToWorkImage_Click(sender As Object, e As EventArgs) Handles Button_CropToWorkImage.Click
        Dim rect As Rectangle = New Rectangle(cropX, cropY, cropBoxWidth, cropBoxHeight)
        Dim bit As Bitmap = New Bitmap(PictureBox_Crop.Image, PictureBox_Crop.Width, PictureBox_Crop.Height)

        Dim cropBitmap = New Bitmap(cropBoxWidth, cropBoxHeight)
        Dim g As Graphics = Graphics.FromImage(cropBitmap)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)

        PictureBox_ImageWork.Image = cropBitmap
    End Sub



    Private Sub PictureBox_Crop_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Crop.MouseDown

        If PictureBox_Crop Is Nothing Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Left Then
            'get our starting position for the crop
            cropX = e.X
            cropY = e.Y

            drawingPen = New Pen(Brushes.Red, 2)
            drawingPen.DashStyle = Drawing2D.DashStyle.Dash
            Cursor = Cursors.Cross
        End If
        'refresh the window
        PictureBox_Crop.Refresh()

    End Sub


    Private Sub PictureBox_Crop_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Crop.MouseMove

        If PictureBox_Crop Is Nothing Then Exit Sub

        'if we are moving the mouse, figure out the size of the box to draw
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PictureBox_Crop.Refresh()
            cropBoxWidth = e.X - cropX
            cropBoxHeight = e.Y - cropY
            PictureBox_Crop.CreateGraphics.DrawRectangle(drawingPen, cropX, cropY, cropBoxWidth, cropBoxHeight)
        End If

    End Sub


    Private Sub PictureBox_Crop_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Crop.MouseUp
        Cursor = Cursors.Default
    End Sub


End Class
