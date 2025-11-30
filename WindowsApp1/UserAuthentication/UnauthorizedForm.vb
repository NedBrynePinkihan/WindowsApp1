Public Class UnauthorizedForm
    Private Sub UnauthorizedForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupInactivityTracking(Me)
    End Sub
End Class