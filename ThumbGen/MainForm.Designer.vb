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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabelMessage = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabelCounter = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemAddFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemClearFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBoxOutputFile = New System.Windows.Forms.GroupBox
        Me.ComboBoxFileTypes = New System.Windows.Forms.ComboBox
        Me.TextBoxFilename = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioButtonFileSuffix = New System.Windows.Forms.RadioButton
        Me.RadioButtonFilePrefix = New System.Windows.Forms.RadioButton
        Me.GroupBoxResizeMethod = New System.Windows.Forms.GroupBox
        Me.ComboBoxScreenSize = New System.Windows.Forms.ComboBox
        Me.RadioButtonScreen = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LabelExactPixelsHigh = New System.Windows.Forms.Label
        Me.TextBoxExactlyHeight = New System.Windows.Forms.TextBox
        Me.LabelExactPixelsWide = New System.Windows.Forms.Label
        Me.TextBoxExactlyWidth = New System.Windows.Forms.TextBox
        Me.LabelHeightPixels = New System.Windows.Forms.Label
        Me.TextBoxHeights = New System.Windows.Forms.TextBox
        Me.LabelWidthPixels = New System.Windows.Forms.Label
        Me.TextBoxWidths = New System.Windows.Forms.TextBox
        Me.RadioButtonExactly = New System.Windows.Forms.RadioButton
        Me.RadioButtonHeights = New System.Windows.Forms.RadioButton
        Me.RadioButtonWidths = New System.Windows.Forms.RadioButton
        Me.ButtonCreateThumbnails = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ButtonClearFileList = New System.Windows.Forms.Button
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ListViewFiles = New ThumbGen.ListviewBackgroundText
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBoxOutputFile.SuspendLayout()
        Me.GroupBoxResizeMethod.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelMessage, Me.ToolStripStatusLabelCounter, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 494)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(632, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelMessage
        '
        Me.ToolStripStatusLabelMessage.Name = "ToolStripStatusLabelMessage"
        Me.ToolStripStatusLabelMessage.Size = New System.Drawing.Size(445, 17)
        Me.ToolStripStatusLabelMessage.Spring = True
        Me.ToolStripStatusLabelMessage.Text = "Ready"
        Me.ToolStripStatusLabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabelCounter
        '
        Me.ToolStripStatusLabelCounter.AutoSize = False
        Me.ToolStripStatusLabelCounter.Name = "ToolStripStatusLabelCounter"
        Me.ToolStripStatusLabelCounter.Size = New System.Drawing.Size(70, 17)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(632, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAddFiles, Me.ToolStripMenuItemClearFiles, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripMenuItemAddFiles
        '
        Me.ToolStripMenuItemAddFiles.Name = "ToolStripMenuItemAddFiles"
        Me.ToolStripMenuItemAddFiles.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripMenuItemAddFiles.Text = "&Add Files..."
        '
        'ToolStripMenuItemClearFiles
        '
        Me.ToolStripMenuItemClearFiles.Name = "ToolStripMenuItemClearFiles"
        Me.ToolStripMenuItemClearFiles.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripMenuItemClearFiles.Text = "&Clear Files"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(137, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.AboutToolStripMenuItem.Text = "A&bout..."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Controls.Add(Me.GroupBoxOutputFile)
        Me.Panel1.Controls.Add(Me.GroupBoxResizeMethod)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(173, 470)
        Me.Panel1.TabIndex = 1
        '
        'GroupBoxOutputFile
        '
        Me.GroupBoxOutputFile.Controls.Add(Me.ComboBoxFileTypes)
        Me.GroupBoxOutputFile.Controls.Add(Me.TextBoxFilename)
        Me.GroupBoxOutputFile.Controls.Add(Me.Label1)
        Me.GroupBoxOutputFile.Controls.Add(Me.RadioButtonFileSuffix)
        Me.GroupBoxOutputFile.Controls.Add(Me.RadioButtonFilePrefix)
        Me.GroupBoxOutputFile.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBoxOutputFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxOutputFile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBoxOutputFile.Location = New System.Drawing.Point(4, 322)
        Me.GroupBoxOutputFile.Name = "GroupBoxOutputFile"
        Me.GroupBoxOutputFile.Size = New System.Drawing.Size(163, 142)
        Me.GroupBoxOutputFile.TabIndex = 1
        Me.GroupBoxOutputFile.TabStop = False
        Me.GroupBoxOutputFile.Text = "Thumbnails"
        '
        'ComboBoxFileTypes
        '
        Me.ComboBoxFileTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFileTypes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxFileTypes.Items.AddRange(New Object() {"jpg", "gif", "bmp", "png"})
        Me.ComboBoxFileTypes.Location = New System.Drawing.Point(12, 113)
        Me.ComboBoxFileTypes.Name = "ComboBoxFileTypes"
        Me.ComboBoxFileTypes.Size = New System.Drawing.Size(145, 21)
        Me.ComboBoxFileTypes.TabIndex = 4
        '
        'TextBoxFilename
        '
        Me.TextBoxFilename.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFilename.Location = New System.Drawing.Point(12, 65)
        Me.TextBoxFilename.Name = "TextBoxFilename"
        Me.TextBoxFilename.Size = New System.Drawing.Size(145, 21)
        Me.TextBoxFilename.TabIndex = 2
        Me.TextBoxFilename.Text = "thumb_"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File Type:"
        '
        'RadioButtonFileSuffix
        '
        Me.RadioButtonFileSuffix.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonFileSuffix.Location = New System.Drawing.Point(12, 42)
        Me.RadioButtonFileSuffix.Name = "RadioButtonFileSuffix"
        Me.RadioButtonFileSuffix.Size = New System.Drawing.Size(116, 16)
        Me.RadioButtonFileSuffix.TabIndex = 1
        Me.RadioButtonFileSuffix.Text = "Suffix"
        '
        'RadioButtonFilePrefix
        '
        Me.RadioButtonFilePrefix.Checked = True
        Me.RadioButtonFilePrefix.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonFilePrefix.Location = New System.Drawing.Point(12, 21)
        Me.RadioButtonFilePrefix.Name = "RadioButtonFilePrefix"
        Me.RadioButtonFilePrefix.Size = New System.Drawing.Size(116, 16)
        Me.RadioButtonFilePrefix.TabIndex = 0
        Me.RadioButtonFilePrefix.TabStop = True
        Me.RadioButtonFilePrefix.Text = "Prefix"
        '
        'GroupBoxResizeMethod
        '
        Me.GroupBoxResizeMethod.Controls.Add(Me.ComboBoxScreenSize)
        Me.GroupBoxResizeMethod.Controls.Add(Me.RadioButtonScreen)
        Me.GroupBoxResizeMethod.Controls.Add(Me.Label2)
        Me.GroupBoxResizeMethod.Controls.Add(Me.Label6)
        Me.GroupBoxResizeMethod.Controls.Add(Me.Label5)
        Me.GroupBoxResizeMethod.Controls.Add(Me.LabelExactPixelsHigh)
        Me.GroupBoxResizeMethod.Controls.Add(Me.TextBoxExactlyHeight)
        Me.GroupBoxResizeMethod.Controls.Add(Me.LabelExactPixelsWide)
        Me.GroupBoxResizeMethod.Controls.Add(Me.TextBoxExactlyWidth)
        Me.GroupBoxResizeMethod.Controls.Add(Me.LabelHeightPixels)
        Me.GroupBoxResizeMethod.Controls.Add(Me.TextBoxHeights)
        Me.GroupBoxResizeMethod.Controls.Add(Me.LabelWidthPixels)
        Me.GroupBoxResizeMethod.Controls.Add(Me.TextBoxWidths)
        Me.GroupBoxResizeMethod.Controls.Add(Me.RadioButtonExactly)
        Me.GroupBoxResizeMethod.Controls.Add(Me.RadioButtonHeights)
        Me.GroupBoxResizeMethod.Controls.Add(Me.RadioButtonWidths)
        Me.GroupBoxResizeMethod.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBoxResizeMethod.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxResizeMethod.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBoxResizeMethod.Location = New System.Drawing.Point(4, 5)
        Me.GroupBoxResizeMethod.Name = "GroupBoxResizeMethod"
        Me.GroupBoxResizeMethod.Size = New System.Drawing.Size(163, 311)
        Me.GroupBoxResizeMethod.TabIndex = 0
        Me.GroupBoxResizeMethod.TabStop = False
        Me.GroupBoxResizeMethod.Text = "Resize Method"
        '
        'ComboBoxScreenSize
        '
        Me.ComboBoxScreenSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxScreenSize.FormattingEnabled = True
        Me.ComboBoxScreenSize.Location = New System.Drawing.Point(12, 254)
        Me.ComboBoxScreenSize.Name = "ComboBoxScreenSize"
        Me.ComboBoxScreenSize.Size = New System.Drawing.Size(145, 21)
        Me.ComboBoxScreenSize.TabIndex = 14
        '
        'RadioButtonScreen
        '
        Me.RadioButtonScreen.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.RadioButtonScreen.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonScreen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonScreen.Location = New System.Drawing.Point(10, 230)
        Me.RadioButtonScreen.Name = "RadioButtonScreen"
        Me.RadioButtonScreen.Size = New System.Drawing.Size(133, 24)
        Me.RadioButtonScreen.TabIndex = 13
        Me.RadioButtonScreen.Text = "Common Screen Size:"
        Me.RadioButtonScreen.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 278)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 30)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "resize image proportionally for best fit to screen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(12, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "width in proportion"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(12, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "height in proportion"
        '
        'LabelExactPixelsHigh
        '
        Me.LabelExactPixelsHigh.AutoSize = True
        Me.LabelExactPixelsHigh.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LabelExactPixelsHigh.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExactPixelsHigh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelExactPixelsHigh.Location = New System.Drawing.Point(60, 207)
        Me.LabelExactPixelsHigh.Name = "LabelExactPixelsHigh"
        Me.LabelExactPixelsHigh.Size = New System.Drawing.Size(58, 13)
        Me.LabelExactPixelsHigh.TabIndex = 12
        Me.LabelExactPixelsHigh.Text = "Pixels High"
        '
        'TextBoxExactlyHeight
        '
        Me.TextBoxExactlyHeight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExactlyHeight.Location = New System.Drawing.Point(12, 203)
        Me.TextBoxExactlyHeight.Name = "TextBoxExactlyHeight"
        Me.TextBoxExactlyHeight.Size = New System.Drawing.Size(44, 21)
        Me.TextBoxExactlyHeight.TabIndex = 11
        Me.TextBoxExactlyHeight.Text = "72"
        '
        'LabelExactPixelsWide
        '
        Me.LabelExactPixelsWide.AutoSize = True
        Me.LabelExactPixelsWide.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LabelExactPixelsWide.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExactPixelsWide.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelExactPixelsWide.Location = New System.Drawing.Point(60, 184)
        Me.LabelExactPixelsWide.Name = "LabelExactPixelsWide"
        Me.LabelExactPixelsWide.Size = New System.Drawing.Size(61, 13)
        Me.LabelExactPixelsWide.TabIndex = 10
        Me.LabelExactPixelsWide.Text = "Pixels Wide"
        '
        'TextBoxExactlyWidth
        '
        Me.TextBoxExactlyWidth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExactlyWidth.Location = New System.Drawing.Point(12, 180)
        Me.TextBoxExactlyWidth.Name = "TextBoxExactlyWidth"
        Me.TextBoxExactlyWidth.Size = New System.Drawing.Size(44, 21)
        Me.TextBoxExactlyWidth.TabIndex = 9
        Me.TextBoxExactlyWidth.Text = "92"
        '
        'LabelHeightPixels
        '
        Me.LabelHeightPixels.AutoSize = True
        Me.LabelHeightPixels.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LabelHeightPixels.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeightPixels.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelHeightPixels.Location = New System.Drawing.Point(60, 114)
        Me.LabelHeightPixels.Name = "LabelHeightPixels"
        Me.LabelHeightPixels.Size = New System.Drawing.Size(34, 13)
        Me.LabelHeightPixels.TabIndex = 6
        Me.LabelHeightPixels.Text = "Pixels"
        '
        'TextBoxHeights
        '
        Me.TextBoxHeights.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxHeights.Location = New System.Drawing.Point(12, 110)
        Me.TextBoxHeights.Name = "TextBoxHeights"
        Me.TextBoxHeights.Size = New System.Drawing.Size(44, 21)
        Me.TextBoxHeights.TabIndex = 5
        Me.TextBoxHeights.Text = "72"
        '
        'LabelWidthPixels
        '
        Me.LabelWidthPixels.AutoSize = True
        Me.LabelWidthPixels.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LabelWidthPixels.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWidthPixels.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelWidthPixels.Location = New System.Drawing.Point(60, 43)
        Me.LabelWidthPixels.Name = "LabelWidthPixels"
        Me.LabelWidthPixels.Size = New System.Drawing.Size(34, 13)
        Me.LabelWidthPixels.TabIndex = 2
        Me.LabelWidthPixels.Text = "Pixels"
        '
        'TextBoxWidths
        '
        Me.TextBoxWidths.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxWidths.Location = New System.Drawing.Point(12, 39)
        Me.TextBoxWidths.Name = "TextBoxWidths"
        Me.TextBoxWidths.Size = New System.Drawing.Size(44, 21)
        Me.TextBoxWidths.TabIndex = 1
        Me.TextBoxWidths.Text = "92"
        '
        'RadioButtonExactly
        '
        Me.RadioButtonExactly.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.RadioButtonExactly.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonExactly.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonExactly.Location = New System.Drawing.Point(10, 156)
        Me.RadioButtonExactly.Name = "RadioButtonExactly"
        Me.RadioButtonExactly.Size = New System.Drawing.Size(104, 24)
        Me.RadioButtonExactly.TabIndex = 8
        Me.RadioButtonExactly.Text = "Make Exactly:"
        Me.RadioButtonExactly.UseVisualStyleBackColor = False
        '
        'RadioButtonHeights
        '
        Me.RadioButtonHeights.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.RadioButtonHeights.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonHeights.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonHeights.Location = New System.Drawing.Point(10, 86)
        Me.RadioButtonHeights.Name = "RadioButtonHeights"
        Me.RadioButtonHeights.Size = New System.Drawing.Size(115, 24)
        Me.RadioButtonHeights.TabIndex = 4
        Me.RadioButtonHeights.Text = "Make All Heights:"
        Me.RadioButtonHeights.UseVisualStyleBackColor = False
        '
        'RadioButtonWidths
        '
        Me.RadioButtonWidths.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.RadioButtonWidths.Checked = True
        Me.RadioButtonWidths.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonWidths.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadioButtonWidths.Location = New System.Drawing.Point(10, 16)
        Me.RadioButtonWidths.Name = "RadioButtonWidths"
        Me.RadioButtonWidths.Size = New System.Drawing.Size(104, 24)
        Me.RadioButtonWidths.TabIndex = 0
        Me.RadioButtonWidths.TabStop = True
        Me.RadioButtonWidths.Text = "Make All Widths:"
        Me.RadioButtonWidths.UseVisualStyleBackColor = False
        '
        'ButtonCreateThumbnails
        '
        Me.ButtonCreateThumbnails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCreateThumbnails.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonCreateThumbnails.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonCreateThumbnails.Enabled = False
        Me.ButtonCreateThumbnails.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCreateThumbnails.Image = Global.ThumbGen.My.Resources.Resources.Go
        Me.ButtonCreateThumbnails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCreateThumbnails.Location = New System.Drawing.Point(320, 3)
        Me.ButtonCreateThumbnails.Name = "ButtonCreateThumbnails"
        Me.ButtonCreateThumbnails.Size = New System.Drawing.Size(136, 37)
        Me.ButtonCreateThumbnails.TabIndex = 1
        Me.ButtonCreateThumbnails.Text = "Create Thumbnails"
        Me.ButtonCreateThumbnails.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.ButtonCreateThumbnails.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel2.Controls.Add(Me.ButtonClearFileList)
        Me.Panel2.Controls.Add(Me.ButtonCreateThumbnails)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(173, 451)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(459, 43)
        Me.Panel2.TabIndex = 3
        '
        'ButtonClearFileList
        '
        Me.ButtonClearFileList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClearFileList.BackColor = System.Drawing.SystemColors.Control
        Me.ButtonClearFileList.Enabled = False
        Me.ButtonClearFileList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearFileList.Location = New System.Drawing.Point(210, 3)
        Me.ButtonClearFileList.Name = "ButtonClearFileList"
        Me.ButtonClearFileList.Size = New System.Drawing.Size(104, 37)
        Me.ButtonClearFileList.TabIndex = 0
        Me.ButtonClearFileList.Text = "Clear File List"
        Me.ButtonClearFileList.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Tick1.png")
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Add Files"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ListViewFiles
        '
        Me.ListViewFiles.AllowDrop = True
        Me.ListViewFiles.BackgroundText = "Drag files here to create thumbnails"
        Me.ListViewFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFiles.Location = New System.Drawing.Point(173, 24)
        Me.ListViewFiles.Name = "ListViewFiles"
        Me.ListViewFiles.Size = New System.Drawing.Size(459, 427)
        Me.ListViewFiles.SmallImageList = Me.ImageList1
        Me.ListViewFiles.TabIndex = 2
        Me.ListViewFiles.UseCompatibleStateImageBehavior = False
        Me.ListViewFiles.View = System.Windows.Forms.View.Details
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 516)
        Me.Controls.Add(Me.ListViewFiles)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(640, 545)
        Me.Name = "MainForm"
        Me.Text = "ThumbGen"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBoxOutputFile.ResumeLayout(False)
        Me.GroupBoxOutputFile.PerformLayout()
        Me.GroupBoxResizeMethod.ResumeLayout(False)
        Me.GroupBoxResizeMethod.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabelMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripMenuItemAddFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemClearFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxFileTypes As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxOutputFile As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxFilename As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonFileSuffix As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonFilePrefix As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBoxResizeMethod As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LabelExactPixelsHigh As System.Windows.Forms.Label
    Friend WithEvents TextBoxExactlyHeight As System.Windows.Forms.TextBox
    Friend WithEvents LabelExactPixelsWide As System.Windows.Forms.Label
    Friend WithEvents TextBoxExactlyWidth As System.Windows.Forms.TextBox
    Friend WithEvents LabelHeightPixels As System.Windows.Forms.Label
    Friend WithEvents TextBoxHeights As System.Windows.Forms.TextBox
    Friend WithEvents LabelWidthPixels As System.Windows.Forms.Label
    Friend WithEvents TextBoxWidths As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonExactly As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonHeights As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonWidths As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonCreateThumbnails As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonClearFileList As System.Windows.Forms.Button
    Friend WithEvents ToolStripStatusLabelCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ListViewFiles As ThumbGen.ListviewBackgroundText
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBoxScreenSize As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButtonScreen As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
