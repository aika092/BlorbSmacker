<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuItem_FileToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_OpenFileToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_SaveToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImageSetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_SaveImageSetToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem_ExtractAllResourcesToolStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button_ImageDirectory = New System.Windows.Forms.Button()
        Me.DebugRTB = New System.Windows.Forms.RichTextBox()
        Me.Panel_Top = New System.Windows.Forms.FlowLayoutPanel()
        Me.LimitReplacementSizeCheckbox = New System.Windows.Forms.CheckBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Button_ShowGameImages = New System.Windows.Forms.Button()
        Me.TabControl_ImagesAudio = New System.Windows.Forms.TabControl()
        Me.TabPage_GameImages = New System.Windows.Forms.TabPage()
        Me.Panel_GameImagesFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel_TabHeaderFlowLayout = New System.Windows.Forms.FlowLayoutPanel()
        Me.TabPage_ImageSet = New System.Windows.Forms.TabPage()
        Me.Panel_ImageSetFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel_ImageSetHeader = New System.Windows.Forms.Panel()
        Me.TabPage_GameAudio = New System.Windows.Forms.TabPage()
        Me.Panel_AudioFlowLayout = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel_AudioHeader = New System.Windows.Forms.Panel()
        Me.Button_ShowAudioFiles = New System.Windows.Forms.Button()
        Me.Panel_ReplacementImagesBase = New System.Windows.Forms.Panel()
        Me.Panel_ReplacementImagesFlow = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel_ReplacementImagesHeader = New System.Windows.Forms.Panel()
        Me.Panel_MainBottomLeft = New System.Windows.Forms.Panel()
        Me.TabControl_ImageWorkPanel = New System.Windows.Forms.TabControl()
        Me.TabPage_WorkImage = New System.Windows.Forms.TabPage()
        Me.Panel_WorkImageFlowLayout = New System.Windows.Forms.FlowLayoutPanel()
        Me.PictureBox_ImageWork = New System.Windows.Forms.PictureBox()
        Me.TabPage_ColorBlend = New System.Windows.Forms.TabPage()
        Me.PictureBox_ColorBlend = New System.Windows.Forms.PictureBox()
        Me.Panel_ColorBlendHeader = New System.Windows.Forms.Panel()
        Me.Button_ColorBlendCopyToWork = New System.Windows.Forms.Button()
        Me.Label_Blue = New System.Windows.Forms.Label()
        Me.TrackBar_Blue = New System.Windows.Forms.TrackBar()
        Me.TrackBar_Green = New System.Windows.Forms.TrackBar()
        Me.Label_Green = New System.Windows.Forms.Label()
        Me.Label_Red = New System.Windows.Forms.Label()
        Me.TrackBar_Red = New System.Windows.Forms.TrackBar()
        Me.TabPage_Crop = New System.Windows.Forms.TabPage()
        Me.Panel_CropFlowLayout = New System.Windows.Forms.FlowLayoutPanel()
        Me.PictureBox_Crop = New System.Windows.Forms.PictureBox()
        Me.Panel_CropHeader = New System.Windows.Forms.Panel()
        Me.Button_CropToWorkImage = New System.Windows.Forms.Button()
        Me.TabPage_Align = New System.Windows.Forms.TabPage()
        Me.PictureBox_Align = New System.Windows.Forms.PictureBox()
        Me.Panel_AlignHeader = New System.Windows.Forms.Panel()
        Me.Button_AlignCopyToWorkImage = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel_Top.SuspendLayout()
        Me.TabControl_ImagesAudio.SuspendLayout()
        Me.TabPage_GameImages.SuspendLayout()
        Me.Panel_TabHeaderFlowLayout.SuspendLayout()
        Me.TabPage_ImageSet.SuspendLayout()
        Me.TabPage_GameAudio.SuspendLayout()
        Me.Panel_AudioHeader.SuspendLayout()
        Me.Panel_ReplacementImagesBase.SuspendLayout()
        Me.Panel_ReplacementImagesHeader.SuspendLayout()
        Me.Panel_MainBottomLeft.SuspendLayout()
        Me.TabControl_ImageWorkPanel.SuspendLayout()
        Me.TabPage_WorkImage.SuspendLayout()
        Me.Panel_WorkImageFlowLayout.SuspendLayout()
        CType(Me.PictureBox_ImageWork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_ColorBlend.SuspendLayout()
        CType(Me.PictureBox_ColorBlend, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_ColorBlendHeader.SuspendLayout()
        CType(Me.TrackBar_Blue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_Green, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_Red, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage_Crop.SuspendLayout()
        Me.Panel_CropFlowLayout.SuspendLayout()
        CType(Me.PictureBox_Crop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_CropHeader.SuspendLayout()
        Me.TabPage_Align.SuspendLayout()
        CType(Me.PictureBox_Align, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_AlignHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_FileToolStrip, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(1489, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuItem_FileToolStrip
        '
        Me.MenuItem_FileToolStrip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_OpenFileToolStrip, Me.MenuItem_SaveToolStrip, Me.OpenImageSetToolStripMenuItem, Me.MenuItem_SaveImageSetToolStrip})
        Me.MenuItem_FileToolStrip.Name = "MenuItem_FileToolStrip"
        Me.MenuItem_FileToolStrip.Size = New System.Drawing.Size(35, 20)
        Me.MenuItem_FileToolStrip.Text = "File"
        '
        'MenuItem_OpenFileToolStrip
        '
        Me.MenuItem_OpenFileToolStrip.Name = "MenuItem_OpenFileToolStrip"
        Me.MenuItem_OpenFileToolStrip.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_OpenFileToolStrip.Text = "Open Blorb"
        '
        'MenuItem_SaveToolStrip
        '
        Me.MenuItem_SaveToolStrip.Name = "MenuItem_SaveToolStrip"
        Me.MenuItem_SaveToolStrip.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_SaveToolStrip.Text = "Save Blorb"
        '
        'OpenImageSetToolStripMenuItem
        '
        Me.OpenImageSetToolStripMenuItem.Name = "OpenImageSetToolStripMenuItem"
        Me.OpenImageSetToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenImageSetToolStripMenuItem.Text = "Open Image Set"
        '
        'MenuItem_SaveImageSetToolStrip
        '
        Me.MenuItem_SaveImageSetToolStrip.Name = "MenuItem_SaveImageSetToolStrip"
        Me.MenuItem_SaveImageSetToolStrip.Size = New System.Drawing.Size(152, 22)
        Me.MenuItem_SaveImageSetToolStrip.Text = "Save Image Set"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_ExtractAllResourcesToolStrip})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'MenuItem_ExtractAllResourcesToolStrip
        '
        Me.MenuItem_ExtractAllResourcesToolStrip.Name = "MenuItem_ExtractAllResourcesToolStrip"
        Me.MenuItem_ExtractAllResourcesToolStrip.Size = New System.Drawing.Size(172, 22)
        Me.MenuItem_ExtractAllResourcesToolStrip.Text = "Extract all resources"
        '
        'Button_ImageDirectory
        '
        Me.Button_ImageDirectory.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Button_ImageDirectory.Location = New System.Drawing.Point(3, 6)
        Me.Button_ImageDirectory.Name = "Button_ImageDirectory"
        Me.Button_ImageDirectory.Size = New System.Drawing.Size(210, 23)
        Me.Button_ImageDirectory.TabIndex = 6
        Me.Button_ImageDirectory.Text = "Open Replacement Resource Directory"
        Me.Button_ImageDirectory.UseVisualStyleBackColor = True
        '
        'DebugRTB
        '
        Me.DebugRTB.BackColor = System.Drawing.SystemColors.Window
        Me.DebugRTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DebugRTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DebugRTB.Location = New System.Drawing.Point(3, 3)
        Me.DebugRTB.Name = "DebugRTB"
        Me.DebugRTB.ReadOnly = True
        Me.DebugRTB.Size = New System.Drawing.Size(821, 104)
        Me.DebugRTB.TabIndex = 0
        Me.DebugRTB.Text = ""
        '
        'Panel_Top
        '
        Me.Panel_Top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Top.Controls.Add(Me.DebugRTB)
        Me.Panel_Top.Controls.Add(Me.LimitReplacementSizeCheckbox)
        Me.Panel_Top.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_Top.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.Panel_Top.Location = New System.Drawing.Point(0, 24)
        Me.Panel_Top.Name = "Panel_Top"
        Me.Panel_Top.Size = New System.Drawing.Size(1489, 119)
        Me.Panel_Top.TabIndex = 10
        '
        'LimitReplacementSizeCheckbox
        '
        Me.LimitReplacementSizeCheckbox.AutoSize = True
        Me.LimitReplacementSizeCheckbox.Location = New System.Drawing.Point(830, 3)
        Me.LimitReplacementSizeCheckbox.Name = "LimitReplacementSizeCheckbox"
        Me.LimitReplacementSizeCheckbox.Size = New System.Drawing.Size(260, 17)
        Me.LimitReplacementSizeCheckbox.TabIndex = 10
        Me.LimitReplacementSizeCheckbox.Text = "Limit replacement images to 350x350 (auto resize)"
        Me.LimitReplacementSizeCheckbox.UseVisualStyleBackColor = True
        '
        'Button_ShowGameImages
        '
        Me.Button_ShowGameImages.Location = New System.Drawing.Point(3, 3)
        Me.Button_ShowGameImages.Name = "Button_ShowGameImages"
        Me.Button_ShowGameImages.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button_ShowGameImages.Size = New System.Drawing.Size(133, 23)
        Me.Button_ShowGameImages.TabIndex = 0
        Me.Button_ShowGameImages.Text = "Show Game Images"
        Me.Button_ShowGameImages.UseVisualStyleBackColor = True
        '
        'TabControl_ImagesAudio
        '
        Me.TabControl_ImagesAudio.Controls.Add(Me.TabPage_GameImages)
        Me.TabControl_ImagesAudio.Controls.Add(Me.TabPage_ImageSet)
        Me.TabControl_ImagesAudio.Controls.Add(Me.TabPage_GameAudio)
        Me.TabControl_ImagesAudio.Dock = System.Windows.Forms.DockStyle.Left
        Me.TabControl_ImagesAudio.Location = New System.Drawing.Point(0, 0)
        Me.TabControl_ImagesAudio.Name = "TabControl_ImagesAudio"
        Me.TabControl_ImagesAudio.SelectedIndex = 0
        Me.TabControl_ImagesAudio.Size = New System.Drawing.Size(1145, 677)
        Me.TabControl_ImagesAudio.TabIndex = 11
        '
        'TabPage_GameImages
        '
        Me.TabPage_GameImages.Controls.Add(Me.Panel_GameImagesFlow)
        Me.TabPage_GameImages.Controls.Add(Me.Panel_TabHeaderFlowLayout)
        Me.TabPage_GameImages.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_GameImages.Name = "TabPage_GameImages"
        Me.TabPage_GameImages.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_GameImages.Size = New System.Drawing.Size(1137, 651)
        Me.TabPage_GameImages.TabIndex = 0
        Me.TabPage_GameImages.Text = "Game Images"
        Me.TabPage_GameImages.UseVisualStyleBackColor = True
        '
        'Panel_GameImagesFlow
        '
        Me.Panel_GameImagesFlow.AutoScroll = True
        Me.Panel_GameImagesFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_GameImagesFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_GameImagesFlow.Location = New System.Drawing.Point(3, 32)
        Me.Panel_GameImagesFlow.Name = "Panel_GameImagesFlow"
        Me.Panel_GameImagesFlow.Size = New System.Drawing.Size(1131, 616)
        Me.Panel_GameImagesFlow.TabIndex = 0
        '
        'Panel_TabHeaderFlowLayout
        '
        Me.Panel_TabHeaderFlowLayout.Controls.Add(Me.Button_ShowGameImages)
        Me.Panel_TabHeaderFlowLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_TabHeaderFlowLayout.Location = New System.Drawing.Point(3, 3)
        Me.Panel_TabHeaderFlowLayout.Name = "Panel_TabHeaderFlowLayout"
        Me.Panel_TabHeaderFlowLayout.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel_TabHeaderFlowLayout.Size = New System.Drawing.Size(1131, 29)
        Me.Panel_TabHeaderFlowLayout.TabIndex = 1
        '
        'TabPage_ImageSet
        '
        Me.TabPage_ImageSet.Controls.Add(Me.Panel_ImageSetFlow)
        Me.TabPage_ImageSet.Controls.Add(Me.Panel_ImageSetHeader)
        Me.TabPage_ImageSet.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_ImageSet.Name = "TabPage_ImageSet"
        Me.TabPage_ImageSet.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_ImageSet.Size = New System.Drawing.Size(1137, 651)
        Me.TabPage_ImageSet.TabIndex = 2
        Me.TabPage_ImageSet.Text = "Image Set"
        Me.TabPage_ImageSet.UseVisualStyleBackColor = True
        '
        'Panel_ImageSetFlow
        '
        Me.Panel_ImageSetFlow.AutoScroll = True
        Me.Panel_ImageSetFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_ImageSetFlow.Location = New System.Drawing.Point(3, 41)
        Me.Panel_ImageSetFlow.Name = "Panel_ImageSetFlow"
        Me.Panel_ImageSetFlow.Size = New System.Drawing.Size(1131, 607)
        Me.Panel_ImageSetFlow.TabIndex = 1
        '
        'Panel_ImageSetHeader
        '
        Me.Panel_ImageSetHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_ImageSetHeader.Location = New System.Drawing.Point(3, 3)
        Me.Panel_ImageSetHeader.Name = "Panel_ImageSetHeader"
        Me.Panel_ImageSetHeader.Size = New System.Drawing.Size(1131, 38)
        Me.Panel_ImageSetHeader.TabIndex = 0
        '
        'TabPage_GameAudio
        '
        Me.TabPage_GameAudio.Controls.Add(Me.Panel_AudioFlowLayout)
        Me.TabPage_GameAudio.Controls.Add(Me.Panel_AudioHeader)
        Me.TabPage_GameAudio.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_GameAudio.Name = "TabPage_GameAudio"
        Me.TabPage_GameAudio.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_GameAudio.Size = New System.Drawing.Size(1137, 651)
        Me.TabPage_GameAudio.TabIndex = 1
        Me.TabPage_GameAudio.Text = "Game Audio"
        Me.TabPage_GameAudio.UseVisualStyleBackColor = True
        '
        'Panel_AudioFlowLayout
        '
        Me.Panel_AudioFlowLayout.AllowDrop = True
        Me.Panel_AudioFlowLayout.AutoScroll = True
        Me.Panel_AudioFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_AudioFlowLayout.Location = New System.Drawing.Point(3, 31)
        Me.Panel_AudioFlowLayout.Name = "Panel_AudioFlowLayout"
        Me.Panel_AudioFlowLayout.Size = New System.Drawing.Size(1131, 617)
        Me.Panel_AudioFlowLayout.TabIndex = 2
        '
        'Panel_AudioHeader
        '
        Me.Panel_AudioHeader.Controls.Add(Me.Button_ShowAudioFiles)
        Me.Panel_AudioHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_AudioHeader.Location = New System.Drawing.Point(3, 3)
        Me.Panel_AudioHeader.Name = "Panel_AudioHeader"
        Me.Panel_AudioHeader.Size = New System.Drawing.Size(1131, 28)
        Me.Panel_AudioHeader.TabIndex = 1
        '
        'Button_ShowAudioFiles
        '
        Me.Button_ShowAudioFiles.Location = New System.Drawing.Point(4, 3)
        Me.Button_ShowAudioFiles.Name = "Button_ShowAudioFiles"
        Me.Button_ShowAudioFiles.Size = New System.Drawing.Size(121, 23)
        Me.Button_ShowAudioFiles.TabIndex = 0
        Me.Button_ShowAudioFiles.Text = "Show Audio Files"
        Me.Button_ShowAudioFiles.UseVisualStyleBackColor = True
        '
        'Panel_ReplacementImagesBase
        '
        Me.Panel_ReplacementImagesBase.Controls.Add(Me.Panel_ReplacementImagesFlow)
        Me.Panel_ReplacementImagesBase.Controls.Add(Me.Panel_ReplacementImagesHeader)
        Me.Panel_ReplacementImagesBase.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel_ReplacementImagesBase.Location = New System.Drawing.Point(1145, 143)
        Me.Panel_ReplacementImagesBase.Name = "Panel_ReplacementImagesBase"
        Me.Panel_ReplacementImagesBase.Size = New System.Drawing.Size(344, 679)
        Me.Panel_ReplacementImagesBase.TabIndex = 12
        '
        'Panel_ReplacementImagesFlow
        '
        Me.Panel_ReplacementImagesFlow.AutoScroll = True
        Me.Panel_ReplacementImagesFlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_ReplacementImagesFlow.Location = New System.Drawing.Point(0, 34)
        Me.Panel_ReplacementImagesFlow.Name = "Panel_ReplacementImagesFlow"
        Me.Panel_ReplacementImagesFlow.Size = New System.Drawing.Size(344, 645)
        Me.Panel_ReplacementImagesFlow.TabIndex = 14
        '
        'Panel_ReplacementImagesHeader
        '
        Me.Panel_ReplacementImagesHeader.Controls.Add(Me.Button_ImageDirectory)
        Me.Panel_ReplacementImagesHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_ReplacementImagesHeader.Location = New System.Drawing.Point(0, 0)
        Me.Panel_ReplacementImagesHeader.Name = "Panel_ReplacementImagesHeader"
        Me.Panel_ReplacementImagesHeader.Size = New System.Drawing.Size(344, 34)
        Me.Panel_ReplacementImagesHeader.TabIndex = 13
        '
        'Panel_MainBottomLeft
        '
        Me.Panel_MainBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_MainBottomLeft.Controls.Add(Me.TabControl_ImageWorkPanel)
        Me.Panel_MainBottomLeft.Controls.Add(Me.TabControl_ImagesAudio)
        Me.Panel_MainBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_MainBottomLeft.Location = New System.Drawing.Point(0, 143)
        Me.Panel_MainBottomLeft.Name = "Panel_MainBottomLeft"
        Me.Panel_MainBottomLeft.Size = New System.Drawing.Size(1145, 679)
        Me.Panel_MainBottomLeft.TabIndex = 13
        '
        'TabControl_ImageWorkPanel
        '
        Me.TabControl_ImageWorkPanel.Controls.Add(Me.TabPage_WorkImage)
        Me.TabControl_ImageWorkPanel.Controls.Add(Me.TabPage_ColorBlend)
        Me.TabControl_ImageWorkPanel.Controls.Add(Me.TabPage_Crop)
        Me.TabControl_ImageWorkPanel.Controls.Add(Me.TabPage_Align)
        Me.TabControl_ImageWorkPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.TabControl_ImageWorkPanel.HotTrack = True
        Me.TabControl_ImageWorkPanel.Location = New System.Drawing.Point(720, 0)
        Me.TabControl_ImageWorkPanel.Name = "TabControl_ImageWorkPanel"
        Me.TabControl_ImageWorkPanel.SelectedIndex = 0
        Me.TabControl_ImageWorkPanel.Size = New System.Drawing.Size(423, 677)
        Me.TabControl_ImageWorkPanel.TabIndex = 1
        '
        'TabPage_WorkImage
        '
        Me.TabPage_WorkImage.Controls.Add(Me.Panel_WorkImageFlowLayout)
        Me.TabPage_WorkImage.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_WorkImage.Name = "TabPage_WorkImage"
        Me.TabPage_WorkImage.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_WorkImage.Size = New System.Drawing.Size(415, 651)
        Me.TabPage_WorkImage.TabIndex = 1
        Me.TabPage_WorkImage.Text = "Work Image"
        Me.TabPage_WorkImage.UseVisualStyleBackColor = True
        '
        'Panel_WorkImageFlowLayout
        '
        Me.Panel_WorkImageFlowLayout.AutoScroll = True
        Me.Panel_WorkImageFlowLayout.Controls.Add(Me.PictureBox_ImageWork)
        Me.Panel_WorkImageFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_WorkImageFlowLayout.Location = New System.Drawing.Point(3, 3)
        Me.Panel_WorkImageFlowLayout.Name = "Panel_WorkImageFlowLayout"
        Me.Panel_WorkImageFlowLayout.Size = New System.Drawing.Size(409, 645)
        Me.Panel_WorkImageFlowLayout.TabIndex = 0
        '
        'PictureBox_ImageWork
        '
        Me.PictureBox_ImageWork.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox_ImageWork.Name = "PictureBox_ImageWork"
        Me.PictureBox_ImageWork.Size = New System.Drawing.Size(403, 626)
        Me.PictureBox_ImageWork.TabIndex = 1
        Me.PictureBox_ImageWork.TabStop = False
        '
        'TabPage_ColorBlend
        '
        Me.TabPage_ColorBlend.Controls.Add(Me.PictureBox_ColorBlend)
        Me.TabPage_ColorBlend.Controls.Add(Me.Panel_ColorBlendHeader)
        Me.TabPage_ColorBlend.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_ColorBlend.Name = "TabPage_ColorBlend"
        Me.TabPage_ColorBlend.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_ColorBlend.Size = New System.Drawing.Size(415, 651)
        Me.TabPage_ColorBlend.TabIndex = 0
        Me.TabPage_ColorBlend.Text = "Color Blend"
        Me.TabPage_ColorBlend.UseVisualStyleBackColor = True
        '
        'PictureBox_ColorBlend
        '
        Me.PictureBox_ColorBlend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_ColorBlend.Location = New System.Drawing.Point(3, 107)
        Me.PictureBox_ColorBlend.Name = "PictureBox_ColorBlend"
        Me.PictureBox_ColorBlend.Size = New System.Drawing.Size(409, 541)
        Me.PictureBox_ColorBlend.TabIndex = 8
        Me.PictureBox_ColorBlend.TabStop = False
        '
        'Panel_ColorBlendHeader
        '
        Me.Panel_ColorBlendHeader.Controls.Add(Me.Button_ColorBlendCopyToWork)
        Me.Panel_ColorBlendHeader.Controls.Add(Me.Label_Blue)
        Me.Panel_ColorBlendHeader.Controls.Add(Me.TrackBar_Blue)
        Me.Panel_ColorBlendHeader.Controls.Add(Me.TrackBar_Green)
        Me.Panel_ColorBlendHeader.Controls.Add(Me.Label_Green)
        Me.Panel_ColorBlendHeader.Controls.Add(Me.Label_Red)
        Me.Panel_ColorBlendHeader.Controls.Add(Me.TrackBar_Red)
        Me.Panel_ColorBlendHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_ColorBlendHeader.Location = New System.Drawing.Point(3, 3)
        Me.Panel_ColorBlendHeader.Name = "Panel_ColorBlendHeader"
        Me.Panel_ColorBlendHeader.Size = New System.Drawing.Size(409, 104)
        Me.Panel_ColorBlendHeader.TabIndex = 7
        '
        'Button_ColorBlendCopyToWork
        '
        Me.Button_ColorBlendCopyToWork.Location = New System.Drawing.Point(259, 18)
        Me.Button_ColorBlendCopyToWork.Name = "Button_ColorBlendCopyToWork"
        Me.Button_ColorBlendCopyToWork.Size = New System.Drawing.Size(124, 23)
        Me.Button_ColorBlendCopyToWork.TabIndex = 20
        Me.Button_ColorBlendCopyToWork.Text = "Copy to Work Image"
        Me.Button_ColorBlendCopyToWork.UseVisualStyleBackColor = True
        '
        'Label_Blue
        '
        Me.Label_Blue.AutoSize = True
        Me.Label_Blue.Location = New System.Drawing.Point(19, 60)
        Me.Label_Blue.Name = "Label_Blue"
        Me.Label_Blue.Size = New System.Drawing.Size(17, 13)
        Me.Label_Blue.TabIndex = 19
        Me.Label_Blue.Text = "B:"
        '
        'TrackBar_Blue
        '
        Me.TrackBar_Blue.Location = New System.Drawing.Point(33, 60)
        Me.TrackBar_Blue.Maximum = 255
        Me.TrackBar_Blue.Name = "TrackBar_Blue"
        Me.TrackBar_Blue.Size = New System.Drawing.Size(206, 42)
        Me.TrackBar_Blue.TabIndex = 18
        '
        'TrackBar_Green
        '
        Me.TrackBar_Green.Location = New System.Drawing.Point(33, 28)
        Me.TrackBar_Green.Maximum = 255
        Me.TrackBar_Green.Name = "TrackBar_Green"
        Me.TrackBar_Green.Size = New System.Drawing.Size(206, 42)
        Me.TrackBar_Green.TabIndex = 17
        '
        'Label_Green
        '
        Me.Label_Green.AutoSize = True
        Me.Label_Green.Location = New System.Drawing.Point(19, 28)
        Me.Label_Green.Name = "Label_Green"
        Me.Label_Green.Size = New System.Drawing.Size(18, 13)
        Me.Label_Green.TabIndex = 16
        Me.Label_Green.Text = "G:"
        '
        'Label_Red
        '
        Me.Label_Red.AutoSize = True
        Me.Label_Red.Location = New System.Drawing.Point(19, -1)
        Me.Label_Red.Name = "Label_Red"
        Me.Label_Red.Size = New System.Drawing.Size(18, 13)
        Me.Label_Red.TabIndex = 15
        Me.Label_Red.Text = "R:"
        '
        'TrackBar_Red
        '
        Me.TrackBar_Red.Location = New System.Drawing.Point(33, -1)
        Me.TrackBar_Red.Maximum = 255
        Me.TrackBar_Red.Name = "TrackBar_Red"
        Me.TrackBar_Red.Size = New System.Drawing.Size(206, 42)
        Me.TrackBar_Red.TabIndex = 14
        '
        'TabPage_Crop
        '
        Me.TabPage_Crop.Controls.Add(Me.Panel_CropFlowLayout)
        Me.TabPage_Crop.Controls.Add(Me.Panel_CropHeader)
        Me.TabPage_Crop.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Crop.Name = "TabPage_Crop"
        Me.TabPage_Crop.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Crop.Size = New System.Drawing.Size(415, 651)
        Me.TabPage_Crop.TabIndex = 3
        Me.TabPage_Crop.Text = "Crop"
        Me.TabPage_Crop.UseVisualStyleBackColor = True
        '
        'Panel_CropFlowLayout
        '
        Me.Panel_CropFlowLayout.AutoScroll = True
        Me.Panel_CropFlowLayout.Controls.Add(Me.PictureBox_Crop)
        Me.Panel_CropFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_CropFlowLayout.Location = New System.Drawing.Point(3, 103)
        Me.Panel_CropFlowLayout.Name = "Panel_CropFlowLayout"
        Me.Panel_CropFlowLayout.Size = New System.Drawing.Size(409, 545)
        Me.Panel_CropFlowLayout.TabIndex = 1
        '
        'PictureBox_Crop
        '
        Me.PictureBox_Crop.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox_Crop.Name = "PictureBox_Crop"
        Me.PictureBox_Crop.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox_Crop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox_Crop.TabIndex = 0
        Me.PictureBox_Crop.TabStop = False
        '
        'Panel_CropHeader
        '
        Me.Panel_CropHeader.Controls.Add(Me.Button_CropToWorkImage)
        Me.Panel_CropHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_CropHeader.Location = New System.Drawing.Point(3, 3)
        Me.Panel_CropHeader.Name = "Panel_CropHeader"
        Me.Panel_CropHeader.Size = New System.Drawing.Size(409, 100)
        Me.Panel_CropHeader.TabIndex = 0
        '
        'Button_CropToWorkImage
        '
        Me.Button_CropToWorkImage.Location = New System.Drawing.Point(3, 6)
        Me.Button_CropToWorkImage.Name = "Button_CropToWorkImage"
        Me.Button_CropToWorkImage.Size = New System.Drawing.Size(136, 23)
        Me.Button_CropToWorkImage.TabIndex = 0
        Me.Button_CropToWorkImage.Text = "Copy to Work Image"
        Me.Button_CropToWorkImage.UseVisualStyleBackColor = True
        '
        'TabPage_Align
        '
        Me.TabPage_Align.Controls.Add(Me.PictureBox_Align)
        Me.TabPage_Align.Controls.Add(Me.Panel_AlignHeader)
        Me.TabPage_Align.Location = New System.Drawing.Point(4, 22)
        Me.TabPage_Align.Name = "TabPage_Align"
        Me.TabPage_Align.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage_Align.Size = New System.Drawing.Size(415, 651)
        Me.TabPage_Align.TabIndex = 2
        Me.TabPage_Align.Text = "Align/Size"
        Me.TabPage_Align.UseVisualStyleBackColor = True
        '
        'PictureBox_Align
        '
        Me.PictureBox_Align.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_Align.Location = New System.Drawing.Point(3, 103)
        Me.PictureBox_Align.Name = "PictureBox_Align"
        Me.PictureBox_Align.Size = New System.Drawing.Size(409, 545)
        Me.PictureBox_Align.TabIndex = 1
        Me.PictureBox_Align.TabStop = False
        '
        'Panel_AlignHeader
        '
        Me.Panel_AlignHeader.Controls.Add(Me.Button_AlignCopyToWorkImage)
        Me.Panel_AlignHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_AlignHeader.Location = New System.Drawing.Point(3, 3)
        Me.Panel_AlignHeader.Name = "Panel_AlignHeader"
        Me.Panel_AlignHeader.Size = New System.Drawing.Size(409, 100)
        Me.Panel_AlignHeader.TabIndex = 0
        '
        'Button_AlignCopyToWorkImage
        '
        Me.Button_AlignCopyToWorkImage.Location = New System.Drawing.Point(3, 3)
        Me.Button_AlignCopyToWorkImage.Name = "Button_AlignCopyToWorkImage"
        Me.Button_AlignCopyToWorkImage.Size = New System.Drawing.Size(116, 23)
        Me.Button_AlignCopyToWorkImage.TabIndex = 0
        Me.Button_AlignCopyToWorkImage.Text = "Copy to Work Image"
        Me.Button_AlignCopyToWorkImage.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1489, 822)
        Me.Controls.Add(Me.Panel_MainBottomLeft)
        Me.Controls.Add(Me.Panel_ReplacementImagesBase)
        Me.Controls.Add(Me.Panel_Top)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "BlorbSmacker v.03"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel_Top.ResumeLayout(False)
        Me.Panel_Top.PerformLayout()
        Me.TabControl_ImagesAudio.ResumeLayout(False)
        Me.TabPage_GameImages.ResumeLayout(False)
        Me.Panel_TabHeaderFlowLayout.ResumeLayout(False)
        Me.TabPage_ImageSet.ResumeLayout(False)
        Me.TabPage_GameAudio.ResumeLayout(False)
        Me.Panel_AudioHeader.ResumeLayout(False)
        Me.Panel_ReplacementImagesBase.ResumeLayout(False)
        Me.Panel_ReplacementImagesHeader.ResumeLayout(False)
        Me.Panel_MainBottomLeft.ResumeLayout(False)
        Me.TabControl_ImageWorkPanel.ResumeLayout(False)
        Me.TabPage_WorkImage.ResumeLayout(False)
        Me.Panel_WorkImageFlowLayout.ResumeLayout(False)
        CType(Me.PictureBox_ImageWork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_ColorBlend.ResumeLayout(False)
        CType(Me.PictureBox_ColorBlend, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_ColorBlendHeader.ResumeLayout(False)
        Me.Panel_ColorBlendHeader.PerformLayout()
        CType(Me.TrackBar_Blue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_Green, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_Red, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage_Crop.ResumeLayout(False)
        Me.Panel_CropFlowLayout.ResumeLayout(False)
        Me.Panel_CropFlowLayout.PerformLayout()
        CType(Me.PictureBox_Crop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_CropHeader.ResumeLayout(False)
        Me.TabPage_Align.ResumeLayout(False)
        CType(Me.PictureBox_Align, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_AlignHeader.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuItem_FileToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_OpenFileToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_SaveToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button_ImageDirectory As System.Windows.Forms.Button
    Friend WithEvents DebugRTB As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel_Top As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LimitReplacementSizeCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Button_ShowGameImages As System.Windows.Forms.Button
    Friend WithEvents TabControl_ImagesAudio As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_GameImages As System.Windows.Forms.TabPage
    Friend WithEvents Panel_ReplacementImagesBase As System.Windows.Forms.Panel
    Friend WithEvents Panel_ReplacementImagesFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel_ReplacementImagesHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel_MainBottomLeft As System.Windows.Forms.Panel
    Friend WithEvents Panel_GameImagesFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel_TabHeaderFlowLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TabPage_GameAudio As System.Windows.Forms.TabPage
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_ExtractAllResourcesToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_AudioFlowLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel_AudioHeader As System.Windows.Forms.Panel
    Friend WithEvents Button_ShowAudioFiles As System.Windows.Forms.Button
    Friend WithEvents TabControl_ImageWorkPanel As System.Windows.Forms.TabControl
    Friend WithEvents TabPage_WorkImage As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox_ImageWork As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage_ColorBlend As System.Windows.Forms.TabPage
    Friend WithEvents Panel_ColorBlendHeader As System.Windows.Forms.Panel
    Friend WithEvents Button_ColorBlendCopyToWork As System.Windows.Forms.Button
    Friend WithEvents Label_Blue As System.Windows.Forms.Label
    Friend WithEvents TrackBar_Blue As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar_Green As System.Windows.Forms.TrackBar
    Friend WithEvents Label_Green As System.Windows.Forms.Label
    Friend WithEvents Label_Red As System.Windows.Forms.Label
    Friend WithEvents TrackBar_Red As System.Windows.Forms.TrackBar
    Friend WithEvents PictureBox_ColorBlend As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage_Align As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox_Align As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_AlignHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel_WorkImageFlowLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TabPage_Crop As System.Windows.Forms.TabPage
    Friend WithEvents Panel_CropHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel_CropFlowLayout As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents PictureBox_Crop As System.Windows.Forms.PictureBox
    Friend WithEvents Button_CropToWorkImage As System.Windows.Forms.Button
    Friend WithEvents OpenImageSetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_SaveImageSetToolStrip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage_ImageSet As System.Windows.Forms.TabPage
    Friend WithEvents Panel_ImageSetHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel_ImageSetFlow As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button_AlignCopyToWorkImage As System.Windows.Forms.Button

End Class
