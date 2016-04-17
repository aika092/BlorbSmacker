Partial Public Class MainForm





    Private Sub TrackBar_Red_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Blue.Scroll
        SetBlendingColor()
    End Sub

    Private Sub TrackBar_Green_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Green.Scroll
        SetBlendingColor()
    End Sub

    Private Sub TrackBar_Blue_Scroll(sender As Object, e As EventArgs) Handles TrackBar_Red.Scroll
        SetBlendingColor()
    End Sub


    'Blend the image in the colorblend picture box with a color
    Private Sub SetBlendingColor()

        If PictureBox_ColorBlend.Image IsNot Nothing Then
            Dim red As Integer = TrackBar_Red.Value
            Dim green As Integer = TrackBar_Green.Value
            Dim blue As Integer = TrackBar_Blue.Value
            Dim alpha As Integer = 0

            Dim sr, sg, sb, sa As Single
            'Dim cm As New Drawing.Imaging.ColorMatrix
            'Dim atr As New Drawing.Imaging.ImageAttributes


            'create a bitmap from our original image
            Using origBitmap As New Bitmap(PictureBox_ImageWork.Image)
                Dim cm As New Drawing.Imaging.ColorMatrix
                Dim atr As New Drawing.Imaging.ImageAttributes

                'create a bitmap and graphics object
                Dim newBitmap = New Bitmap(origBitmap.Width, origBitmap.Height)
                Dim colorBoxGraphics As Graphics = Graphics.FromImage(newBitmap)
                Dim r As New Rectangle(0, 0, newBitmap.Width, newBitmap.Height)

                'noramlize the color components to 1
                sr = red / 255
                sg = green / 255
                sb = blue / 255
                sa = alpha / 255

                'create the color matrix
                cm = New Drawing.Imaging.ColorMatrix(New Single()() _
                                   {New Single() {1, 0, 0, 0, 0}, _
                                    New Single() {0, 1, 0, 0, 0}, _
                                    New Single() {0, 0, 1, 0, 0}, _
                                    New Single() {0, 0, 0, 1, 0}, _
                                    New Single() {sr, sg, sb, sa, 1}})
                atr.SetColorMatrix(cm)
                colorBoxGraphics.DrawImage(origBitmap, r, 0, 0, r.Width, r.Height, Drawing.GraphicsUnit.Pixel, atr)

                PictureBox_ColorBlend.Image = newBitmap
                PictureBox_ColorBlend.Height = newBitmap.Height
                PictureBox_ColorBlend.Width = newBitmap.Width
            End Using
            GC.Collect()
        End If
    End Sub


    'copy the image from the color blend tab to the main tab
    Private Sub Button_CopyToMain_Click(sender As Object, e As EventArgs) Handles Button_ColorBlendCopyToWork.Click
        PictureBox_ImageWork.Image = PictureBox_ColorBlend.Image
    End Sub


End Class
