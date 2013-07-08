Namespace My

    ' The following events are availble for MyApplication:
    ' 
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            Const WhatHappened As String = "There was an unexpected error in (app)."
            Const HowUserAffected As String = "The action you requested was not performed."
            Const WhatUserCanDo As String = "Restart (app), and try repeating your last action.  If the problem continues please contact Helpdesk. When reporting this error please click the More Information button below and copy the details within that box into your support request."

            'Display the exception form
            ExceptionDialog1.ShowDialog(WhatHappened, HowUserAffected, WhatUserCanDo, _
            e.Exception, MessageBoxButtons.OK, MessageBoxIcon.Stop)

            e.ExitApplication = False
        End Sub
    End Class

End Namespace

