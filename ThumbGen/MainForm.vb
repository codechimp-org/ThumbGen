Imports System.Drawing
Imports System.Drawing.Imaging

Public Class MainForm

    Private m_FileAppendMode As String
    Private m_FileAppendName As String
    Private m_FileReSizeMode As String
    Private m_ResizeWidths As Integer
    Private m_ResizeHeights As Integer
    Private m_ResizeExactlyWidth As Integer
    Private m_ResizeExactlyHeight As Integer
    Private m_ResizeResolution As Size
    Private m_FileType As FileType
    Private m_FileTypes As Generic.Dictionary(Of Integer, FileType)

    Private IsLoading As Boolean = True

    Private Class ScreenResolution
        Public Width As Integer
        Public Height As Integer
        Public Description As String

        Public Sub New()
            Width = 0
            Height = 0
            Description = ""
        End Sub

        Public Sub New(ByVal newWidth As Integer, ByVal newHeight As Integer)
            Width = newWidth
            Height = newHeight
            Description = ""
        End Sub

        Public Sub New(ByVal newWidth As Integer, ByVal newHeight As Integer, ByVal newDescription As String)
            Width = newWidth
            Height = newHeight
            Description = newDescription
        End Sub

        Public Overrides Function ToString() As String
            If Description.Trim.Length > 0 Then
                Return String.Format("{0}x{1} - {2}", Width, Height, Description)
            Else
                Return String.Format("{0}x{1}", Width, Height)
            End If
        End Function

        Public Function MatchesScreen(ByVal resolution As System.Drawing.Rectangle) As Boolean
            Return Width = resolution.Width And Height = resolution.Height
        End Function

        Public ReadOnly Property ResolutionSize() As Size
            Get
                Return New Size(Width, Height)
            End Get
        End Property
    End Class

    Private Class FileSizeMode
        Public Const Widths As String = "Widths"
        Public Const Heights As String = "Heights"
        Public Const Exactly As String = "Exactly"
        Public Const Screen As String = "Screen"
    End Class

    Private Class FileAppendMode
        Public Const Prefix As String = "Prefix"
        Public Const Suffix As String = "Suffix"
    End Class

    Private Class FileType
        Public ID As Integer
        Public Extension As String
        Public Format As ImageFormat

        Public Sub New(ByVal newID As Integer, ByVal newExtension As String, ByVal newFormat As ImageFormat)
            ID = newID
            Extension = newExtension
            Format = newFormat
        End Sub

        Public Overrides Function ToString() As String
            Return Extension
        End Function
    End Class

    Private Sub LoadSettings()
        'Check to see if this is the first time weve loaded the My.Settings for this version, if so then upgrade.
        If My.Settings.CallUpgrade = True Then
            My.Settings.Upgrade()
            My.Settings.CallUpgrade = False
        End If

        'Load a windows location from settings, default to design time preferred
        'location if not specified.
        If Not My.Settings.MainWindowLocation.X = 0 Then
            Me.Location = My.Settings.MainWindowLocation
        End If

        'Load a windows location from settings, default to design time preferred
        'location if not specified.
        If Not My.Settings.MainWindowSize.Width = 0 Then
            Me.Size = My.Settings.MainWindowSize
        End If

        Me.WindowState = My.Settings.MainWindowState

        If Me.Location.X + Me.Width > My.Computer.Screen.Bounds.Width Then
            Me.Left = 50 'Default
        End If

        If Me.Location.Y + Me.Height > My.Computer.Screen.Bounds.Height Then
            Me.Top = 50 'Default
        End If

        m_FileAppendMode = My.Settings.FileAppendMode
        m_FileReSizeMode = My.Settings.ResizeMode
        m_FileAppendName = My.Settings.FileAppendName

        m_ResizeExactlyHeight = CInt(My.Settings.ResizeExactlyHeight)
        m_ResizeExactlyWidth = CInt(My.Settings.ResizeExactlyWidth)
        m_ResizeWidths = CInt(My.Settings.ResizeWidths)
        m_ResizeHeights = CInt(My.Settings.ResizeHeights)
        m_ResizeResolution = My.Settings.ResizeResolution

        m_FileType = m_FileTypes.Item(My.Settings.FileType)
    End Sub

    Private Sub DataToScreen()
        Me.IsLoading = True

        Me.RadioButtonWidths.Checked = (m_FileReSizeMode = FileSizeMode.Widths)
        Me.RadioButtonHeights.Checked = (m_FileReSizeMode = FileSizeMode.Heights)
        Me.RadioButtonExactly.Checked = (m_FileReSizeMode = FileSizeMode.Exactly)
        Me.RadioButtonScreen.Checked = (m_FileReSizeMode = FileSizeMode.Screen)

        Me.TextBoxWidths.Enabled = (m_FileReSizeMode = FileSizeMode.Widths)
        Me.TextBoxHeights.Enabled = (m_FileReSizeMode = FileSizeMode.Heights)
        Me.TextBoxExactlyWidth.Enabled = (m_FileReSizeMode = FileSizeMode.Exactly)
        Me.TextBoxExactlyHeight.Enabled = (m_FileReSizeMode = FileSizeMode.Exactly)
        Me.ComboBoxScreenSize.Enabled = (m_FileReSizeMode = FileSizeMode.Screen)

        RadioButtonFilePrefix.Checked = m_FileAppendMode = FileAppendMode.Prefix
        RadioButtonFileSuffix.Checked = m_FileAppendMode = FileAppendMode.Suffix

        Me.TextBoxExactlyHeight.Text = m_ResizeExactlyHeight.ToString
        Me.TextBoxExactlyWidth.Text = m_ResizeExactlyWidth.ToString
        Me.TextBoxWidths.Text = m_ResizeWidths.ToString
        Me.TextBoxHeights.Text = m_ResizeHeights.ToString

        For Each sr As ScreenResolution In Me.ComboBoxScreenSize.Items
            If sr.ResolutionSize = m_ResizeResolution Then
                Me.ComboBoxScreenSize.SelectedItem = sr
                Exit For
            End If
        Next

        CalculateFileAppendName()

        Me.TextBoxFilename.Text = m_FileAppendName

        Me.ComboBoxFileTypes.SelectedIndex = m_FileType.ID

        ValidateCreation()

        Me.IsLoading = False
    End Sub

    Private Sub CalculateFileAppendName()
        If Not IsLoading Then
            If m_FileAppendMode = FileAppendMode.Prefix Then
                If m_FileAppendName.StartsWith("_") Or m_FileAppendName.StartsWith("-") Then
                    m_FileAppendName = m_FileAppendName.Substring(1, m_FileAppendName.Length - 1) & m_FileAppendName.Substring(0, 1)
                End If
            End If

            If m_FileAppendMode = FileAppendMode.Suffix Then
                If m_FileAppendName.EndsWith("_") Or m_FileAppendName.EndsWith("-") Then
                    m_FileAppendName = m_FileAppendName.Substring(m_FileAppendName.Length - 1, 1) & m_FileAppendName.Substring(0, m_FileAppendName.Length - 1)
                End If
            End If
        End If
    End Sub

    Private Sub ScreenToData()
        If Me.RadioButtonWidths.Checked Then
            m_FileReSizeMode = FileSizeMode.Widths
        End If

        If Me.RadioButtonHeights.Checked Then
            m_FileReSizeMode = FileSizeMode.Heights
        End If

        If Me.RadioButtonExactly.Checked Then
            m_FileReSizeMode = FileSizeMode.Exactly
        End If

        If RadioButtonFilePrefix.Checked Then
            m_FileAppendMode = FileAppendMode.Prefix
        End If

        If RadioButtonFileSuffix.Checked Then
            m_FileAppendMode = FileAppendMode.Suffix
        End If

        m_ResizeExactlyHeight = CInt(Me.TextBoxExactlyHeight.Text)
        m_ResizeExactlyWidth = CInt(Me.TextBoxExactlyWidth.Text)
        m_ResizeHeights = CInt(Me.TextBoxHeights.Text)
        m_ResizeWidths = CInt(Me.TextBoxWidths.Text)
        m_ResizeResolution = CType(Me.ComboBoxScreenSize.SelectedItem, ScreenResolution).ResolutionSize

        m_FileType = CType(Me.ComboBoxFileTypes.SelectedItem, FileType)

        m_FileAppendName = TextBoxFilename.Text

    End Sub

    Private Sub SaveSettings()
        ScreenToData()

        My.Settings.MainWindowState = Me.WindowState

        'Saves a windows location to settings if it is in a normal state.
        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.MainWindowLocation = Me.Location
        End If

        'Saves a windows size to settings if it is in a normal state.
        If Me.WindowState = FormWindowState.Normal Then
            My.Settings.MainWindowSize = Me.Size
        End If

        My.Settings.FileAppendMode = m_FileAppendMode
        My.Settings.ResizeMode = m_FileReSizeMode
        My.Settings.FileAppendName = m_FileAppendName

        My.Settings.FileType = m_FileType.ID

        My.Settings.ResizeExactlyHeight = Me.TextBoxExactlyHeight.Text
        My.Settings.ResizeExactlyWidth = Me.TextBoxExactlyWidth.Text
        My.Settings.ResizeWidths = Me.TextBoxWidths.Text
        My.Settings.ResizeHeights = Me.TextBoxHeights.Text
        My.Settings.ResizeResolution = CType(Me.ComboBoxScreenSize.SelectedItem, ScreenResolution).ResolutionSize

        My.Settings.Save()
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ScreenToData()
        SaveSettings()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        IsLoading = True

        'Setup static data
        SetupFileTypes()
        SetupCombos()

        'Setup key handlers
        AddHandler Me.TextBoxExactlyHeight.KeyPress, AddressOf NumericKeyPressHandler
        AddHandler Me.TextBoxExactlyWidth.KeyPress, AddressOf NumericKeyPressHandler
        AddHandler Me.TextBoxHeights.KeyPress, AddressOf NumericKeyPressHandler
        AddHandler Me.TextBoxWidths.KeyPress, AddressOf NumericKeyPressHandler

        AddHandler Me.TextBoxExactlyHeight.TextChanged, AddressOf NumericChangedHandler
        AddHandler Me.TextBoxExactlyWidth.TextChanged, AddressOf NumericChangedHandler
        AddHandler Me.TextBoxHeights.TextChanged, AddressOf NumericChangedHandler
        AddHandler Me.TextBoxWidths.TextChanged, AddressOf NumericChangedHandler

        LoadSettings()
        DataToScreen()
        SetupListviewColumns()

        IsLoading = False
    End Sub

    Private Sub SetupFileTypes()
        m_FileTypes = New Generic.Dictionary(Of Integer, FileType)
        m_FileTypes.Add(0, New FileType(0, "jpg", ImageFormat.Jpeg))
        m_FileTypes.Add(1, New FileType(1, "gif", ImageFormat.Gif))
        m_FileTypes.Add(2, New FileType(2, "bmp", ImageFormat.Bmp))
        m_FileTypes.Add(3, New FileType(3, "png", ImageFormat.Png))
    End Sub

    Private Sub SetupCombos()

        'Screen Sizes
        Me.ComboBoxScreenSize.Items.Clear()
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(320, 200, "CGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(320, 240, "QVGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(640, 480, "VGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(720, 480, "DVD"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(800, 480, "WVGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(800, 600, "SVGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1024, 768, "XGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1280, 720, "HD 720"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1280, 800, "WXGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1280, 1024, "SXGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1400, 1050, "SXGA+"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1600, 1200, "UGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1680, 1050, "WSXGA+"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1920, 1080, "HD 1080"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(2048, 1536, "QXGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(1920, 1200, "WUXGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(2560, 1600, "WQXGA"))
        Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(2560, 2048, "QSXGA"))

        For Each sr As ScreenResolution In Me.ComboBoxScreenSize.Items
            If sr.MatchesScreen(My.Computer.Screen.Bounds) Then
                Me.ComboBoxScreenSize.SelectedItem = sr
                Exit For
            End If
        Next

        If Me.ComboBoxScreenSize.SelectedIndex = -1 Then
            Me.ComboBoxScreenSize.Items.Add(New ScreenResolution(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height, "Custom"))
            Me.ComboBoxScreenSize.SelectedIndex = Me.ComboBoxScreenSize.Items.Count - 1
        End If

        'File Types
        Me.ComboBoxFileTypes.Items.Clear()

        For Each ft As FileType In m_FileTypes.Values
            Me.ComboBoxFileTypes.Items.Add(ft)
        Next

        Me.ComboBoxFileTypes.SelectedIndex = 0
    End Sub


    Private Sub SetupListviewColumns()
        Me.ListViewFiles.Columns.Add("Files", CInt(ListViewFiles.Width / 100 * 95), HorizontalAlignment.Left)
    End Sub

    Private Sub ResizeListviewColumns()
        If Me.ListViewFiles.Columns.Count > 0 Then
            Me.ListViewFiles.Columns(0).Width = CInt(ListViewFiles.Width / 100 * 95)
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim a As New EnhancedAboutBox1
        a.Icon = Me.Icon
        a.ShowIcon = True
        a.AppMoreInfo = My.Resources.MoreInfo
        a.ShowDialog()
    End Sub

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeListviewColumns()
    End Sub

    Private Sub ClearFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemClearFiles.Click
        ClearListview()
    End Sub

    Private Sub ClearListview()

        Dim proceed As Boolean = True
        Dim processed As Boolean = True

        For Each li As ListViewItem In Me.ListViewFiles.Items
            If li.ImageIndex < 0 Then
                processed = False
                Exit For
            End If
        Next

        If Not processed Then
            If Not MessageBox.Show("Thumbnails have not been created from the selected files." & ControlChars.NewLine & "Are you sure you want to clear the list of files.", "ThumbGen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                proceed = False
            End If
        End If

        If proceed Then
            Me.ListViewFiles.Items.Clear()
            Me.UpdateFileCount()
            Me.ValidateCreation()
        End If

    End Sub

    Private Sub ButtonClearFileList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearFileList.Click
        ClearListview()
    End Sub

    Private Sub radioButtonSize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        RadioButtonWidths.CheckedChanged, RadioButtonHeights.CheckedChanged, RadioButtonExactly.CheckedChanged, RadioButtonScreen.CheckedChanged

        If Not IsLoading Then
            ScreenToData()

            Select Case DirectCast(sender, Control).Name
                Case RadioButtonWidths.Name
                    m_FileReSizeMode = FileSizeMode.Widths

                Case RadioButtonHeights.Name
                    m_FileReSizeMode = FileSizeMode.Heights

                Case RadioButtonExactly.Name
                    m_FileReSizeMode = FileSizeMode.Exactly

                Case RadioButtonScreen.Name
                    m_FileReSizeMode = FileSizeMode.Screen
            End Select

            DataToScreen()

            Me.ValidateCreation()
        End If
    End Sub

    Private Sub radioButtonFilename_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        RadioButtonFilePrefix.CheckedChanged, RadioButtonFileSuffix.CheckedChanged

        If Not IsLoading Then

            m_FileAppendName = Me.TextBoxFilename.Text

            Select Case DirectCast(sender, Control).Name
                Case RadioButtonFilePrefix.Name
                    m_FileAppendMode = FileAppendMode.Prefix

                Case RadioButtonFileSuffix.Name
                    m_FileAppendMode = FileAppendMode.Suffix
            End Select

            CalculateFileAppendName()

            Me.TextBoxFilename.Text = m_FileAppendName
        End If
    End Sub

    Private Sub ValidateCreation()

        Dim valid As Boolean = True

        If Me.RadioButtonWidths.Checked And Val(Me.TextBoxWidths.Text) <= 0 Then
            Me.ErrorProvider1.SetError(Me.LabelWidthPixels, "Value must be greater than 0")
            valid = False
        Else
            Me.ErrorProvider1.SetError(Me.LabelWidthPixels, "")
        End If

        If Me.RadioButtonHeights.Checked And Val(Me.TextBoxHeights.Text) <= 0 Then
            Me.ErrorProvider1.SetError(Me.LabelHeightPixels, "Value must be greater than 0")
            valid = False
        Else
            Me.ErrorProvider1.SetError(Me.LabelHeightPixels, "")
        End If

        If Me.RadioButtonExactly.Checked And Val(Me.TextBoxExactlyHeight.Text) <= 0 Then
            Me.ErrorProvider1.SetError(Me.LabelExactPixelsHigh, "Value must be greater than 0")
            valid = False
        Else
            Me.ErrorProvider1.SetError(Me.LabelExactPixelsHigh, "")
        End If

        If Me.RadioButtonExactly.Checked And Val(Me.TextBoxExactlyWidth.Text) <= 0 Then
            Me.ErrorProvider1.SetError(Me.LabelExactPixelsWide, "Value must be greater than 0")
            valid = False
        Else
            Me.ErrorProvider1.SetError(Me.LabelExactPixelsWide, "")
        End If

        If Me.TextBoxFilename.Text.Trim.Length = 0 Then
            Me.ErrorProvider1.SetError(Me.TextBoxFilename, "Filename append not complete")
            valid = False
        Else
            Me.ErrorProvider1.SetError(Me.TextBoxFilename, "")
        End If

        Me.ToolStripMenuItemClearFiles.Enabled = (Me.ListViewFiles.Items.Count > 0)
        Me.ButtonClearFileList.Enabled = (Me.ListViewFiles.Items.Count > 0)
        Me.ButtonCreateThumbnails.Enabled = (Me.ListViewFiles.Items.Count > 0)
    End Sub

    Private Sub NumericKeyPressHandler(ByVal Sender As Object, ByVal e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub NumericChangedHandler(ByVal Sender As Object, ByVal e As System.EventArgs)
        ValidateCreation()
    End Sub

    Private Sub UpdateFileCount()
        If Me.ListViewFiles.Items.Count = 0 Then
            Me.ToolStripStatusLabelMessage.Text = "Ready"
        Else
            Me.ToolStripStatusLabelMessage.Text = Me.ListViewFiles.Items.Count & " files"
        End If
    End Sub

    Private Function ValidExtension(ByVal extension As String) As Boolean
        Select Case extension.ToLower
            Case ".jpg", ".jpeg", ".gif", ".bmp", ".png"
                ValidExtension = True
            Case Else
                ValidExtension = False
        End Select
    End Function

    Private Sub CreateThumbnails()
        Dim InputFilename As String


        Me.ButtonCreateThumbnails.Enabled = False
        Me.ButtonClearFileList.Enabled = False

        Me.ToolStripProgressBar1.Minimum = 0
        Me.ToolStripProgressBar1.Maximum = Me.ListViewFiles.Items.Count

        ScreenToData()

        'Reset ticks if present
        For i As Integer = 0 To Me.ListViewFiles.Items.Count - 1
            Me.ListViewFiles.Items(i).ImageIndex = -1
        Next

        'Process files
        For i As Integer = 0 To Me.ListViewFiles.Items.Count - 1

            InputFilename = Me.ListViewFiles.Items(i).Text.ToString()

            Me.ToolStripProgressBar1.Value = i + 1
            Me.ToolStripStatusLabelMessage.Text = "Processing " & InputFilename
            Me.ToolStripStatusLabelCounter.Text = String.Format("{0} of {1}", i + 1, Me.ListViewFiles.Items.Count)
            Application.DoEvents()

            If ProcessFile(InputFilename, m_FileReSizeMode, m_ResizeWidths, m_ResizeHeights, m_ResizeExactlyWidth, m_ResizeExactlyHeight, m_ResizeResolution, m_FileAppendMode, m_FileAppendName, m_FileType) Then
                Me.ListViewFiles.Items(i).ImageIndex = 0
            End If
        Next

        Me.ValidateCreation()

        Me.ToolStripProgressBar1.Value = 0
        Me.ToolStripStatusLabelCounter.Text = ""
        Me.ToolStripStatusLabelMessage.Text = "Ready"

    End Sub

    Private Function ProcessFile(ByVal inputFileName As String, ByVal resizeMode As String, ByVal resizeWidths As Integer, ByVal resizeHeights As Integer, ByVal resizeExactWidth As Integer, ByVal resizeExactHeight As Integer, ByVal resizeResolution As System.Drawing.Size, ByVal appendMode As String, ByVal appendName As String, ByVal outputType As FileType) As Boolean
        Dim ret As Boolean = True

        Dim InputFile As Bitmap
        Dim InputSize As SizeF
        Dim OutputFile As Bitmap
        Dim OutputFilename As String

        Dim NewX As Integer
        Dim NewY As Integer

        Dim AspectRatio As Single
        Dim ImageLargestDimension As Int16
        Dim ScreenLargestDimension As Int16

        If resizeResolution.Width > resizeResolution.Height Then
            ScreenLargestDimension = 1 'Width
        Else
            ScreenLargestDimension = 2 'Height
        End If

        InputFile = New Bitmap(inputFileName)
        InputSize = InputFile.PhysicalDimension

        If InputSize.Width > InputSize.Height Then
            ImageLargestDimension = 1 'Width
            AspectRatio = InputSize.Width / InputSize.Height
        Else
            ImageLargestDimension = 2 'Height
            AspectRatio = InputSize.Height / InputSize.Width
        End If

        Select Case resizeMode
            Case FileSizeMode.Widths
                If ImageLargestDimension = 2 Then 'Height
                    NewY = CInt(resizeWidths * AspectRatio)
                Else 'Width
                    NewY = CInt(resizeWidths / AspectRatio)
                End If
                NewX = resizeWidths

                OutputFile = New Bitmap(InputFile, NewX, NewY)

            Case FileSizeMode.Heights
                If ImageLargestDimension = 1 Then 'Width
                    NewX = CInt(resizeHeights * AspectRatio)
                Else 'Height
                    NewX = CInt(resizeHeights / AspectRatio)
                End If
                NewY = resizeHeights

                OutputFile = New Bitmap(InputFile, NewX, NewY)

            Case FileSizeMode.Screen
                If ScreenLargestDimension = 1 And ImageLargestDimension = 1 Then
                    'Make width of image match screen width, height proportional
                    NewY = CInt(resizeResolution.Width / AspectRatio)
                    NewX = resizeResolution.Width
                    OutputFile = New Bitmap(InputFile, NewX, NewY)

                ElseIf ScreenLargestDimension = 2 And ImageLargestDimension = 2 Then
                    'Make height of image match screen height, width proportional
                    NewX = CInt(resizeResolution.Height / AspectRatio)
                    NewY = resizeResolution.Height
                    OutputFile = New Bitmap(InputFile, NewX, NewY)
                Else
                    'Make the image  height or width match that of the smallest dimension of the screen
                    If ScreenLargestDimension = 1 Then
                        'Width
                        NewX = CInt(resizeResolution.Height / AspectRatio)
                        NewY = resizeResolution.Height
                        OutputFile = New Bitmap(InputFile, NewX, NewY)
                    Else
                        'Height
                        NewY = CInt(resizeResolution.Width / AspectRatio)
                        NewX = resizeResolution.Width
                        OutputFile = New Bitmap(InputFile, NewX, NewY)
                    End If
                End If


            Case Else 'Exactly
                NewX = resizeExactWidth
                NewY = resizeExactHeight

                OutputFile = New Bitmap(InputFile, NewX, NewY)
        End Select

        If appendMode = FileAppendMode.Prefix Then
            OutputFilename = System.IO.Path.Combine(FilePath(inputFileName), appendName & Filename(inputFileName) & ".")
        Else
            OutputFilename = System.IO.Path.Combine(FilePath(inputFileName), Filename(inputFileName) & appendName & ".")
        End If

        Try
            OutputFilename = OutputFilename & outputType.Extension
            OutputFile.Save(OutputFilename, outputType.Format)
        Catch e As Exception
            MsgBox("Unable to write file " & OutputFilename & vbCrLf & e.Message(), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation)
            ret = False
        End Try

        InputFile.Dispose()
        OutputFile.Dispose()

        InputFile = Nothing
        OutputFile = Nothing

        Return ret
    End Function

    Private Function FileExtension(ByVal fileName As String) As String
        Dim fi As New System.IO.FileInfo(fileName)
        Return fi.Extension()
    End Function

    Private Function FilePath(ByVal fileName As String) As String
        Dim fi As New System.IO.FileInfo(fileName)
        Return fi.DirectoryName
    End Function

    Private Function Filename(ByVal fullPath As String) As String
        Dim ret As String
        Dim fi As New System.IO.FileInfo(fullPath)
        ret = fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length)
        Return ret
    End Function

    Private Sub ListViewFiles_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewFiles.DragDrop
        Dim s() As String
        Dim i As Integer

        s = CType(e.Data.GetData("FileDrop", False), String())

        For i = 0 To s.Length - 1
            If ValidExtension(FileExtension(s(i))) Then
                Me.ListViewFiles.Items.Add(s(i))
            End If
        Next i

        Me.UpdateFileCount()
        Me.ValidateCreation()
    End Sub

    Private Sub ListViewFiles_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListViewFiles.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ListViewFiles_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewFiles.KeyUp
        If e.KeyCode = Keys.Delete Then
            While Me.ListViewFiles.SelectedItems.Count > 0
                Me.ListViewFiles.Items.Remove(Me.ListViewFiles.SelectedItems.Item(0))
            End While

            Me.UpdateFileCount()
            Me.ValidateCreation()
        End If
    End Sub

    Private Sub ToolStripMenuItemAddFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemAddFiles.Click
        ShowAddFileDialog()
    End Sub

    Private Sub ShowAddFileDialog()
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Images (*.jpg,*.jpeg,*.gif,*.png,*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp"
        Me.OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyPictures
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each fn As String In Me.OpenFileDialog1.FileNames
                If ValidExtension(Me.FileExtension(fn)) Then
                    Me.ListViewFiles.Items.Add(fn)
                End If
            Next
            Me.UpdateFileCount()
            Me.ValidateCreation()
        End If
    End Sub

    Private Sub ButtonCreateThumbnails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonCreateThumbnails.Click

        Me.CreateThumbnails()
    End Sub

    Private Sub TextBoxFilename_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxFilename.TextChanged
        ValidateCreation()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxScreenSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxScreenSize.SelectedIndexChanged
        m_ResizeResolution = CType(Me.ComboBoxScreenSize.SelectedItem, ScreenResolution).ResolutionSize
    End Sub
End Class
