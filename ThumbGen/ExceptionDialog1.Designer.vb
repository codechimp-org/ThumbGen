<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExceptionDialog1
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LabelErrorHeading = New System.Windows.Forms.Label
        Me.RichTextBoxErrorMessage = New System.Windows.Forms.RichTextBox
        Me.LabelScopeHeading = New System.Windows.Forms.Label
        Me.RichTextBoxScope = New System.Windows.Forms.RichTextBox
        Me.LabelActionHeading = New System.Windows.Forms.Label
        Me.RichTextBoxAction = New System.Windows.Forms.RichTextBox
        Me.LabelMoreHeading = New System.Windows.Forms.Label
        Me.ButtonMore = New System.Windows.Forms.Button
        Me.TextBoxMore = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(275, 476)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(217, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button2.Location = New System.Drawing.Point(79, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(57, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Button2"
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(66, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button3.Location = New System.Drawing.Point(147, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(67, 23)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Button3"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'LabelErrorHeading
        '
        Me.LabelErrorHeading.AutoSize = True
        Me.LabelErrorHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelErrorHeading.Location = New System.Drawing.Point(54, 12)
        Me.LabelErrorHeading.Name = "LabelErrorHeading"
        Me.LabelErrorHeading.Size = New System.Drawing.Size(101, 13)
        Me.LabelErrorHeading.TabIndex = 2
        Me.LabelErrorHeading.Text = "What happened:"
        '
        'RichTextBoxErrorMessage
        '
        Me.RichTextBoxErrorMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxErrorMessage.Location = New System.Drawing.Point(57, 28)
        Me.RichTextBoxErrorMessage.Name = "RichTextBoxErrorMessage"
        Me.RichTextBoxErrorMessage.ReadOnly = True
        Me.RichTextBoxErrorMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBoxErrorMessage.Size = New System.Drawing.Size(435, 72)
        Me.RichTextBoxErrorMessage.TabIndex = 3
        Me.RichTextBoxErrorMessage.Text = ""
        '
        'LabelScopeHeading
        '
        Me.LabelScopeHeading.AutoSize = True
        Me.LabelScopeHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelScopeHeading.Location = New System.Drawing.Point(9, 103)
        Me.LabelScopeHeading.Name = "LabelScopeHeading"
        Me.LabelScopeHeading.Size = New System.Drawing.Size(143, 13)
        Me.LabelScopeHeading.TabIndex = 4
        Me.LabelScopeHeading.Text = "How this will affect you:"
        '
        'RichTextBoxScope
        '
        Me.RichTextBoxScope.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxScope.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxScope.Location = New System.Drawing.Point(12, 119)
        Me.RichTextBoxScope.Name = "RichTextBoxScope"
        Me.RichTextBoxScope.ReadOnly = True
        Me.RichTextBoxScope.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBoxScope.Size = New System.Drawing.Size(480, 72)
        Me.RichTextBoxScope.TabIndex = 5
        Me.RichTextBoxScope.Text = ""
        '
        'LabelActionHeading
        '
        Me.LabelActionHeading.AutoSize = True
        Me.LabelActionHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelActionHeading.Location = New System.Drawing.Point(9, 194)
        Me.LabelActionHeading.Name = "LabelActionHeading"
        Me.LabelActionHeading.Size = New System.Drawing.Size(155, 13)
        Me.LabelActionHeading.TabIndex = 6
        Me.LabelActionHeading.Text = "What you can do about it:"
        '
        'RichTextBoxAction
        '
        Me.RichTextBoxAction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBoxAction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBoxAction.Location = New System.Drawing.Point(12, 210)
        Me.RichTextBoxAction.Name = "RichTextBoxAction"
        Me.RichTextBoxAction.ReadOnly = True
        Me.RichTextBoxAction.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBoxAction.Size = New System.Drawing.Size(480, 72)
        Me.RichTextBoxAction.TabIndex = 7
        Me.RichTextBoxAction.Text = ""
        '
        'LabelMoreHeading
        '
        Me.LabelMoreHeading.AutoSize = True
        Me.LabelMoreHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMoreHeading.Location = New System.Drawing.Point(12, 293)
        Me.LabelMoreHeading.Name = "LabelMoreHeading"
        Me.LabelMoreHeading.Size = New System.Drawing.Size(101, 13)
        Me.LabelMoreHeading.TabIndex = 8
        Me.LabelMoreHeading.Text = "More information"
        '
        'ButtonMore
        '
        Me.ButtonMore.Location = New System.Drawing.Point(123, 288)
        Me.ButtonMore.Name = "ButtonMore"
        Me.ButtonMore.Size = New System.Drawing.Size(41, 23)
        Me.ButtonMore.TabIndex = 9
        Me.ButtonMore.Text = ">>"
        Me.ButtonMore.UseVisualStyleBackColor = True
        '
        'TextBoxMore
        '
        Me.TextBoxMore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxMore.Location = New System.Drawing.Point(12, 317)
        Me.TextBoxMore.Multiline = True
        Me.TextBoxMore.Name = "TextBoxMore"
        Me.TextBoxMore.ReadOnly = True
        Me.TextBoxMore.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxMore.Size = New System.Drawing.Size(480, 153)
        Me.TextBoxMore.TabIndex = 10
        '
        'ExceptionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 517)
        Me.Controls.Add(Me.TextBoxMore)
        Me.Controls.Add(Me.ButtonMore)
        Me.Controls.Add(Me.LabelMoreHeading)
        Me.Controls.Add(Me.RichTextBoxAction)
        Me.Controls.Add(Me.LabelActionHeading)
        Me.Controls.Add(Me.RichTextBoxScope)
        Me.Controls.Add(Me.LabelScopeHeading)
        Me.Controls.Add(Me.RichTextBoxErrorMessage)
        Me.Controls.Add(Me.LabelErrorHeading)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExceptionDialog"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "(app) has encountered a problem"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelErrorHeading As System.Windows.Forms.Label
    Friend WithEvents RichTextBoxErrorMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents LabelScopeHeading As System.Windows.Forms.Label
    Friend WithEvents RichTextBoxScope As System.Windows.Forms.RichTextBox
    Friend WithEvents LabelActionHeading As System.Windows.Forms.Label
    Friend WithEvents RichTextBoxAction As System.Windows.Forms.RichTextBox
    Friend WithEvents LabelMoreHeading As System.Windows.Forms.Label
    Friend WithEvents ButtonMore As System.Windows.Forms.Button
    Friend WithEvents TextBoxMore As System.Windows.Forms.TextBox

End Class
