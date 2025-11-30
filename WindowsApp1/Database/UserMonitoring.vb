Module UserMonitoring
    Public LoggedUserId As Integer
    Public LoggedUsername As String
    Public LoggedUserRole As String = ""
    Public LoggedStatus As String

    Public inactivityTimer As New Timer()
    'Public inactivityLimit As Integer = 5 * 60
    Public inactivityLimit As Integer = 60
    Public remainingTime As Integer = inactivityLimit
    Public currentLabel As Label = TimeoutCounterForm.lblTimeoutTimer

    Private LoginFormSingle As LoginForm

    Public Sub SetLoggedUser(UserId As Integer, Username As String, Role As String, Status As String)
        LoggedUserId = UserId
        LoggedUsername = Username
        LoggedUserRole = Role
        LoggedStatus = Status
    End Sub

    Public Sub SetLoginForm(loginForm As LoginForm)
        LoginFormSingle = loginForm
    End Sub

    Public Sub ShowLogin()
        LoginFormSingle.Show()
    End Sub

    Public Sub Logout(form As Form)
        StopTimer()
        AuditLogging.AddEntry("Logged out", "")
        ClearUserCredentials()

        'Form1.Show()
        ShowLogin()
        form.Close()
    End Sub    ' Call this in each form's Load

    Private Sub ClearUserCredentials()
        LoggedUserId = 0
        LoggedUsername = ""
        LoggedUserRole = ""
        LoggedStatus = ""
    End Sub

    Public Sub SetupInactivityTracking(currentForm As Form)

        remainingTime = inactivityLimit


        inactivityTimer.Interval = 1000 ' 1 second
        AddHandler inactivityTimer.Tick, AddressOf TimerTick
        inactivityTimer.Start()


        AddHandler currentForm.MouseMove, Sub() ResetTimer()
        AddHandler currentForm.KeyPress, Sub() ResetTimer()

        AddHandlerToTextboxes(currentForm)
    End Sub

    Private Sub AddHandlerToTextboxes(parent As Control)
        For Each ctrl As Control In parent.Controls
            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = DirectCast(ctrl, TextBox)

                AddHandler tb.TextChanged, Sub() ResetTimer()
                AddHandler tb.KeyPress, Sub() ResetTimer()
                AddHandler tb.MouseDown, Sub() ResetTimer()

            End If


            If ctrl.HasChildren Then
                AddHandlerToTextboxes(ctrl)
            End If
        Next
    End Sub

    Public Sub ResetTimer()
        remainingTime = inactivityLimit
        UpdateLabel()
    End Sub


    Private Sub TimerTick(sender As Object, e As EventArgs)
        remainingTime -= 1
        UpdateLabel()

        If remainingTime <= 0 Then
            inactivityTimer.Stop()
            Logout()
        End If
    End Sub

    Public Sub StopTimer()
        inactivityTimer.Stop()
    End Sub

    Private Sub UpdateLabel()
        If currentLabel IsNot Nothing Then
            Dim minutes As Integer = remainingTime \ 60
            Dim seconds As Integer = remainingTime Mod 60
            currentLabel.Text = $"Auto-logout in {minutes:D2}:{seconds:D2}"
        End If
    End Sub

    Private Sub Logout()
        AuditLogging.AddEntry("Session timeout due to inactivity", "")
        ClearUserCredentials()

        StopTimer()

        ShowLogin()
        Dim loginForm As New LoginForm()
        loginForm.Show()
        ShowLogin()

        Dim openForms() As Form = Application.OpenForms.Cast(Of Form)().ToArray()

        For Each f As Form In openForms
            If f.Name <> "LoginForm" Then
                f.Close()
            End If
        Next

        MessageBox.Show("You have been logged out due to inactivity.", "Session Timeout")
    End Sub
End Module
