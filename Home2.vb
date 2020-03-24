Public Class Home2
    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        ReportSO2.Show()
        Hide()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MsgBox("Are you sure want to log out?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Front.Show()
            Close()
        End If
    End Sub
End Class