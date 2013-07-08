Imports System.ComponentModel

Public Class ListviewBackgroundText
    Inherits System.Windows.Forms.ListView

    Private _b As Boolean = True
    Private _msg As String = ""

    <Description("The text to be displayed when no items are in the listview")> _
    Public Property BackgroundText() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
            Me.Invalidate()
        End Set
    End Property

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Control overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)

        'Add your custom paint code here
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        MyBase.WndProc(m)
        If (m.Msg = 20) Then
            If (Me.Items.Count = 0) Then
                _b = True
                Dim g As Graphics = Me.CreateGraphics()
                Dim w As Integer = CInt((Me.Width - g.MeasureString(_msg, Me.Font).ToSize().Width) / 2)

                g.DrawString(_msg, Me.Font, SystemBrushes.ControlText, w, 30)
            Else
                If (_b) Then
                    Me.Invalidate()
                    _b = False
                End If
            End If
        End If

        If (m.Msg = 4127) Then Me.Invalidate()
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        If (_b) Then Invalidate()
    End Sub
End Class
