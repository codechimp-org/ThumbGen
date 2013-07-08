Imports System.Windows.Forms

Public Class ExceptionDialog1

    Public Enum UserErrorDefaultButton
        [Default] = 0
        Button1 = 1
        Button2 = 2
        Button3 = 3
    End Enum

    Private Const _strDefaultMore As String = "No further information is available. If the problem persists, contact the helpdesk."
    Private Shared _blnHaveException As Boolean = False
    Private Shared _objParentAssembly As System.Reflection.Assembly = Nothing
    Private Shared _strException As String
    Private Shared _strExceptionType As String

    Private Shared Function AssemblyBuildDate(ByVal objAssembly As System.Reflection.Assembly, _
                                       Optional ByVal blnForceFileDate As Boolean = False) As DateTime

        '-- returns build datetime of assembly
        '-- assumes default assembly value in AssemblyInfo:
        '-- <Assembly: AssemblyVersion("1.0.*")> 
        '--
        '-- filesystem create time is used, if revision and build were overridden by user
        Dim objVersion As System.Version = objAssembly.GetName.Version
        Dim dtBuild As DateTime

        If blnForceFileDate Then
            dtBuild = AssemblyFileTime(objAssembly)
        Else
            dtBuild = CType("01/01/2000", DateTime). _
                AddDays(objVersion.Build). _
                AddSeconds(objVersion.Revision * 2)
            If TimeZone.IsDaylightSavingTime(DateTime.Now, TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.Now.Year)) Then
                dtBuild = dtBuild.AddHours(1)
            End If
            If dtBuild > DateTime.Now Or objVersion.Build < 730 Or objVersion.Revision = 0 Then
                dtBuild = AssemblyFileTime(objAssembly)
            End If
        End If

        Return dtBuild
    End Function

    Private Shared Function AssemblyFileTime(ByVal objAssembly As System.Reflection.Assembly) As DateTime
        '-- exception-safe file attrib retrieval; we don't care if this fails
        Try
            Return System.IO.File.GetLastWriteTime(objAssembly.Location)
        Catch ex As Exception
            Return DateTime.MaxValue
        End Try
    End Function

    Private Overloads Shared Function EnhancedStackTrace(ByVal objStackTrace As StackTrace, _
        Optional ByVal strSkipClassName As String = "") As String
        '-- enhanced stack trace generator

        Dim intFrame As Integer

        Dim sb As New System.Text.StringBuilder

        sb.Append(Environment.NewLine)
        sb.Append("---- Stack Trace ----")
        sb.Append(Environment.NewLine)

        For intFrame = 0 To objStackTrace.FrameCount - 1
            Dim sf As StackFrame = objStackTrace.GetFrame(intFrame)
            Dim mi As Reflection.MemberInfo = sf.GetMethod

            If strSkipClassName <> "" AndAlso mi.DeclaringType.Name.IndexOf(strSkipClassName) > -1 Then
                '-- don't include frames with this name
            Else
                sb.Append(StackFrameToString(sf))
            End If
        Next
        sb.Append(Environment.NewLine)

        Return sb.ToString
    End Function


    Private Overloads Shared Function EnhancedStackTrace(ByVal objException As Exception) As String
        '-- enhanced stack trace generator (exception)
        Dim objStackTrace As New StackTrace(objException, True)
        Return EnhancedStackTrace(objStackTrace)
    End Function


    Private Overloads Shared Function EnhancedStackTrace() As String
        '-- enhanced stack trace generator (no params)
        Dim objStackTrace As New StackTrace(True)
        Return EnhancedStackTrace(objStackTrace, "ExceptionManager")
    End Function

    Private Shared Function ExceptionToMore(ByVal objException As System.Exception) As String
        '-- translate exception object to string, with additional system info
        '-- converts exception to a formatted "more" string

        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("Detailed technical information follows: " + Environment.NewLine)
            .Append("---" + Environment.NewLine)
            Dim x As String = ExceptionToString(objException)
            .Append(x)
        End With
        Return sb.ToString
    End Function

    Friend Shared Function ExceptionToString(ByVal objException As Exception) As String
        Dim objStringBuilder As New System.Text.StringBuilder

        If Not (objException.InnerException Is Nothing) Then
            '-- sometimes the original exception is wrapped in a more relevant outer exception
            '-- the detail exception is the "inner" exception
            '-- see http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dnbda/html/exceptdotnet.asp
            With objStringBuilder
                .Append("(Inner Exception)")
                .Append(Environment.NewLine)
                .Append(ExceptionToString(objException.InnerException))
                .Append(Environment.NewLine)
                .Append("(Outer Exception)")
                .Append(Environment.NewLine)
            End With
        End If
        With objStringBuilder
            '-- get general system and app information
            .Append(SysInfoToString)

            '-- get exception-specific information
            .Append("Exception Source:      ")
            Try
                .Append(objException.Source)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("Exception Type:        ")
            Try
                .Append(objException.GetType.FullName)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("Exception Message:     ")
            Try
                .Append(objException.Message)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("Exception Target Site: ")
            Try
                .Append(objException.TargetSite.Name)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            Try
                Dim x As String = EnhancedStackTrace(objException)
                .Append(x)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)
        End With

        Return objStringBuilder.ToString
    End Function

    '--
    '-- get IP address of this machine
    '-- not an ideal method for a number of reasons (guess why!)
    '-- but the alternatives are very ugly
    '--
    Private Shared Function GetCurrentIP() As String
        Try
            Dim strIP As String = _
                System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList(0).ToString()
            Return strIP
        Catch ex As Exception
            Return "127.0.0.1"
        End Try
    End Function


    Private Shared Function GetDefaultMore(ByVal strMoreDetails As String) As String
        '-- make sure "More" text is populated with something useful
        If strMoreDetails = "" Then
            Dim objStringBuilder As New System.Text.StringBuilder
            With objStringBuilder
                .Append(_strDefaultMore)
                .Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Basic technical information follows: " + Environment.NewLine)
                .Append("---" + Environment.NewLine)
                .Append(SysInfoToString(True))
            End With
            Return objStringBuilder.ToString
        Else
            Return strMoreDetails
        End If
    End Function

    Private Shared Function ParentAssembly() As System.Reflection.Assembly
        If _objParentAssembly Is Nothing Then
            If System.Reflection.Assembly.GetEntryAssembly Is Nothing Then
                _objParentAssembly = System.Reflection.Assembly.GetCallingAssembly
            Else
                _objParentAssembly = System.Reflection.Assembly.GetEntryAssembly
            End If
        End If
        Return _objParentAssembly
    End Function


    Private Shared Function ReplaceStringVals(ByVal strOutput As String) As String
        '-- replace generic constants in strings with specific values
        Dim strTemp As String
        If strOutput Is Nothing Then
            strTemp = ""
        Else
            strTemp = strOutput
        End If
        strTemp = strTemp.Replace("(app)", My.Application.Info.ProductName)
        Return strTemp
    End Function

    Public Overloads Shared Function ShowDialog(ByVal whatHappened As String, _
                                                ByVal howUserAffected As String, _
                                                ByVal whatUserCanDo As String) As DialogResult
        '-- simplest possible error dialog

        _blnHaveException = False
        Return ShowDialogInternal(whatHappened, howUserAffected, whatUserCanDo, "", MessageBoxButtons.OK, MessageBoxIcon.Warning, UserErrorDefaultButton.Default)
    End Function

    Public Overloads Shared Function ShowDialog(ByVal whatHappened As String, _
        ByVal strHowUserAffected As String, _
        ByVal strWhatUserCanDo As String, _
        ByVal objException As System.Exception, _
        Optional ByVal Buttons As MessageBoxButtons = MessageBoxButtons.OK, _
        Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.Warning, _
        Optional ByVal DefaultButton As UserErrorDefaultButton = UserErrorDefaultButton.Default) As DialogResult

        '-- advanced error dialog with Exception object

        _blnHaveException = True
        _strExceptionType = objException.GetType.FullName
        Return ShowDialogInternal(whatHappened, strHowUserAffected, strWhatUserCanDo, _
            ExceptionToMore(objException), Buttons, Icon, DefaultButton)
    End Function

    Public Overloads Shared Function ShowDialog(ByVal whatHappened As String, _
        ByVal howUserAffected As String, _
        ByVal whatUserCanDo As String, _
        ByVal moreDetails As String, _
        Optional ByVal Buttons As MessageBoxButtons = MessageBoxButtons.OK, _
        Optional ByVal Icon As MessageBoxIcon = MessageBoxIcon.Warning, _
        Optional ByVal DefaultButton As UserErrorDefaultButton = UserErrorDefaultButton.Default _
        ) As DialogResult

        '-- advanced error dialog with More string
        '-- leave "more" string blank to get the default

        _blnHaveException = False
        Return ShowDialogInternal(whatHappened, howUserAffected, whatUserCanDo, moreDetails, _
            Buttons, Icon, DefaultButton)
    End Function

    Private Shared Function ShowDialogInternal(ByVal whatHappened As String, _
                ByVal howUserAffected As String, _
                ByVal whatUserCanDo As String, _
                ByVal moreDetails As String, _
                ByVal Buttons As MessageBoxButtons, _
                ByVal Icon As MessageBoxIcon, _
                ByVal DefaultButton As UserErrorDefaultButton) As DialogResult

        '-- internal method to show error dialog

        '-- set default values, etc
        ProcessStrings(whatHappened, howUserAffected, whatUserCanDo, moreDetails)

        Dim objForm As New ExceptionDialog1
        With objForm
            .Text = ReplaceStringVals(objForm.Text)
            .RichTextBoxErrorMessage.Text = whatHappened
            .RichTextBoxScope.Text = howUserAffected
            .RichTextBoxAction.Text = whatUserCanDo
            .TextBoxMore.Text = moreDetails
        End With

        '-- determine what button text, visibility, and defaults are
        With objForm
            Select Case Buttons
                Case MessageBoxButtons.AbortRetryIgnore
                    .Button1.Text = "&Abort"
                    .Button2.Text = "&Retry"
                    .Button3.Text = "&Ignore"
                    .AcceptButton = objForm.Button2
                    .CancelButton = objForm.Button3
                Case MessageBoxButtons.OK
                    .Button3.Text = "OK"
                    .Button2.Visible = False
                    .Button1.Visible = False
                    .AcceptButton = objForm.Button3
                Case MessageBoxButtons.OKCancel
                    .Button3.Text = "Cancel"
                    .Button2.Text = "OK"
                    .Button1.Visible = False
                    .AcceptButton = objForm.Button2
                    .CancelButton = objForm.Button3
                Case MessageBoxButtons.RetryCancel
                    .Button3.Text = "Cancel"
                    .Button2.Text = "&Retry"
                    .Button1.Visible = False
                    .AcceptButton = objForm.Button2
                    .CancelButton = objForm.Button3
                Case MessageBoxButtons.YesNo
                    .Button3.Text = "&No"
                    .Button2.Text = "&Yes"
                    .Button1.Visible = False
                Case MessageBoxButtons.YesNoCancel
                    .Button3.Text = "Cancel"
                    .Button2.Text = "&No"
                    .Button1.Text = "&Yes"
                    .CancelButton = objForm.Button3
            End Select
        End With

        '-- set the proper dialog icon
        Select Case Icon
            Case MessageBoxIcon.Error
                objForm.PictureBox1.Image = System.Drawing.SystemIcons.Error.ToBitmap
            Case MessageBoxIcon.Stop
                objForm.PictureBox1.Image = System.Drawing.SystemIcons.Error.ToBitmap
            Case MessageBoxIcon.Exclamation
                objForm.PictureBox1.Image = System.Drawing.SystemIcons.Exclamation.ToBitmap
            Case MessageBoxIcon.Information
                objForm.PictureBox1.Image = System.Drawing.SystemIcons.Information.ToBitmap
            Case MessageBoxIcon.Question
                objForm.PictureBox1.Image = System.Drawing.SystemIcons.Question.ToBitmap
            Case Else
                objForm.PictureBox1.Image = System.Drawing.SystemIcons.Error.ToBitmap
        End Select

        '-- override the default button
        Select Case DefaultButton
            Case UserErrorDefaultButton.Button1
                objForm.AcceptButton = objForm.Button1
                objForm.Button1.TabIndex = 0
            Case UserErrorDefaultButton.Button2
                objForm.AcceptButton = objForm.Button2
                objForm.Button2.TabIndex = 0
            Case UserErrorDefaultButton.Button3
                objForm.AcceptButton = objForm.Button3
                objForm.Button3.TabIndex = 0
        End Select

        '-- show the user our error dialog
        Return objForm.ShowDialog()
    End Function

    Private Shared Function StackFrameToString(ByVal sf As StackFrame) As String
        '-- turns a single stack frame object into an informative string
        Dim sb As New System.Text.StringBuilder
        Dim intParam As Integer
        Dim mi As Reflection.MemberInfo = sf.GetMethod

        With sb
            '-- build method name
            .Append("   ")
            .Append(mi.DeclaringType.Namespace)
            .Append(".")
            .Append(mi.DeclaringType.Name)
            .Append(".")
            .Append(mi.Name)

            '-- build method params
            Dim objParameters() As Reflection.ParameterInfo = sf.GetMethod.GetParameters()
            Dim objParameter As Reflection.ParameterInfo
            .Append("(")
            intParam = 0
            For Each objParameter In objParameters
                intParam += 1
                If intParam > 1 Then .Append(", ")
                .Append(objParameter.Name)
                .Append(" As ")
                .Append(objParameter.ParameterType.Name)
            Next
            .Append(")")
            .Append(Environment.NewLine)

            '-- if source code is available, append location info
            .Append("       ")
            If sf.GetFileName Is Nothing OrElse sf.GetFileName.Length = 0 Then
                .Append(System.IO.Path.GetFileName(ParentAssembly.CodeBase))
                '-- native code offset is always available
                .Append(": N ")
                .Append(String.Format("{0:#00000}", sf.GetNativeOffset))

            Else
                .Append(System.IO.Path.GetFileName(sf.GetFileName))
                .Append(": line ")
                .Append(String.Format("{0:#0000}", sf.GetFileLineNumber))
                .Append(", col ")
                .Append(String.Format("{0:#00}", sf.GetFileColumnNumber))
                '-- if IL is available, append IL location info
                If sf.GetILOffset <> StackFrame.OFFSET_UNKNOWN Then
                    .Append(", IL ")
                    .Append(String.Format("{0:#0000}", sf.GetILOffset))
                End If
            End If
            .Append(Environment.NewLine)
        End With
        Return sb.ToString
    End Function

    Friend Shared Function SysInfoToString(Optional ByVal blnIncludeStackTrace As Boolean = False) As String
        '-- gather some system information that is helpful to diagnosing
        '-- exception

        Dim objStringBuilder As New System.Text.StringBuilder

        With objStringBuilder

            .Append("Date and Time:         ")
            .Append(DateTime.Now)
            .Append(Environment.NewLine)

            .Append("Machine Name:          ")
            Try
                .Append(Environment.MachineName)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("IP Address:            ")
            .Append(GetCurrentIP)
            .Append(Environment.NewLine)

            .Append("Current User:          ")
            .Append(My.User.Name)
            .Append(Environment.NewLine)
            .Append(Environment.NewLine)

            .Append("Application Domain:    ")
            Try
                .Append(System.AppDomain.CurrentDomain.FriendlyName())
            Catch e As Exception
                .Append(e.Message)
            End Try

            .Append(Environment.NewLine)
            .Append("Assembly Codebase:     ")
            Try
                .Append(ParentAssembly.CodeBase())
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("Assembly Full Name:    ")
            Try
                .Append(ParentAssembly.FullName)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("Assembly Version:      ")
            Try
                .Append(ParentAssembly.GetName().Version().ToString)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)

            .Append("Assembly Build Date:   ")
            Try
                .Append(AssemblyBuildDate(ParentAssembly).ToString)
            Catch e As Exception
                .Append(e.Message)
            End Try
            .Append(Environment.NewLine)
            .Append(Environment.NewLine)

            If blnIncludeStackTrace Then
                .Append(EnhancedStackTrace())
            End If

        End With

        Return objStringBuilder.ToString
    End Function

#Region "Form Handling Code"

    Const _intSpacing As Integer = 10

    Private Function DetermineDialogResult(ByVal strButtonText As String) As Windows.Forms.DialogResult
        '-- strip any accelerator keys we might have
        strButtonText = strButtonText.Replace("&", "")
        Select Case strButtonText.ToLower
            Case "abort"
                Return Windows.Forms.DialogResult.Abort
            Case "cancel"
                Return Windows.Forms.DialogResult.Cancel
            Case "ignore"
                Return Windows.Forms.DialogResult.Ignore
            Case "no"
                Return Windows.Forms.DialogResult.No
            Case "none"
                Return Windows.Forms.DialogResult.None
            Case "ok"
                Return Windows.Forms.DialogResult.OK
            Case "retry"
                Return Windows.Forms.DialogResult.Retry
            Case "yes"
                Return Windows.Forms.DialogResult.Yes
        End Select
    End Function

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click
        Me.DialogResult = DetermineDialogResult(DirectCast(sender, Button).Text)
        Me.Close()
    End Sub

    Private Sub ButtonMore_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonMore.Click
        If ButtonMore.Text = ">>" Then
            Me.Height = Me.Height + 300
            With TextBoxMore
                .Location = New System.Drawing.Point(LabelMoreHeading.Left, LabelMoreHeading.Top + LabelMoreHeading.Height + _intSpacing)
                .Height = Me.ClientSize.Height - TextBoxMore.Top - 45
                .Width = Me.ClientSize.Width - 2 * _intSpacing
                .Anchor = Windows.Forms.AnchorStyles.Top Or Windows.Forms.AnchorStyles.Bottom _
                            Or Windows.Forms.AnchorStyles.Left Or Windows.Forms.AnchorStyles.Right
                .Visible = True
            End With
            Button3.Focus()
            ButtonMore.Text = "<<"
        Else
            Me.SuspendLayout()
            ButtonMore.Text = ">>"
            Me.Height = ButtonMore.Top + ButtonMore.Height + _intSpacing + 45
            TextBoxMore.Visible = False
            TextBoxMore.Anchor = Windows.Forms.AnchorStyles.None
            Me.ResumeLayout()
        End If
    End Sub

    Private Sub ExceptionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '-- make sure our window is on top
        Me.TopMost = True
        Me.TopMost = False

        '-- More >> has to be expanded
        Me.TextBoxMore.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBoxMore.Visible = False

        '-- size the labels' height to accommodate the amount of text in them
        SizeBox(RichTextBoxScope)
        SizeBox(RichTextBoxAction)
        SizeBox(RichTextBoxErrorMessage)

        '-- now shift everything up
        LabelScopeHeading.Top = RichTextBoxErrorMessage.Top + RichTextBoxErrorMessage.Height + _intSpacing
        RichTextBoxScope.Top = LabelScopeHeading.Top + LabelScopeHeading.Height + _intSpacing

        LabelActionHeading.Top = RichTextBoxScope.Top + RichTextBoxScope.Height + _intSpacing
        RichTextBoxAction.Top = LabelActionHeading.Top + LabelActionHeading.Height + _intSpacing

        LabelMoreHeading.Top = RichTextBoxAction.Top + RichTextBoxAction.Height + _intSpacing
        ButtonMore.Top = LabelMoreHeading.Top - 3

        Me.Height = ButtonMore.Top + ButtonMore.Height + _intSpacing + 45

        Me.CenterToParent()

    End Sub

    Private Sub LaunchLink(ByVal strUrl As String)
        Try
            System.Diagnostics.Process.Start(strUrl)
        Catch ex As System.Security.SecurityException
            '-- do nothing; we can't launch without full trust.
        End Try
    End Sub

    Private Sub RichTextBoxLinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles RichTextBoxScope.LinkClicked, RichTextBoxAction.LinkClicked, RichTextBoxErrorMessage.LinkClicked
        LaunchLink(e.LinkText)
    End Sub

    Private Sub SizeBox(ByVal ctl As System.Windows.Forms.RichTextBox)
        Dim g As Graphics = Nothing
        Try
            '-- note that the height is taken as MAXIMUM, so size the label for maximum desired height!
            g = Graphics.FromHwnd(ctl.Handle)
            Dim objSizeF As SizeF = g.MeasureString(ctl.Text, ctl.Font, New SizeF(ctl.Width, ctl.Height))
            g.Dispose()
            ctl.Height = Convert.ToInt32(objSizeF.Height) + 5
        Catch ex As System.Security.SecurityException
            '-- do nothing; we can't set control sizes without full trust
        Finally
            If Not g Is Nothing Then g.Dispose()
        End Try
    End Sub
#End Region




    Private Shared Sub ProcessStrings(ByRef strWhatHappened As String, _
        ByRef strHowUserAffected As String, _
        ByRef strWhatUserCanDo As String, _
        ByRef strMoreDetails As String)

        '-- perform our string replacements for (app) and (contact), etc etc
        '-- also make sure More has default values if it is blank.

        strWhatHappened = ReplaceStringVals(strWhatHappened)
        strHowUserAffected = ReplaceStringVals(strHowUserAffected)
        strWhatUserCanDo = ReplaceStringVals(strWhatUserCanDo)
        strMoreDetails = ReplaceStringVals(GetDefaultMore(strMoreDetails))
    End Sub
End Class
