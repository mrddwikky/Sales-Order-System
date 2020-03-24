Public Class Home
    Private Sub CustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerToolStripMenuItem.Click
        Customer.Show()
        Hide()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductToolStripMenuItem.Click
        Product.Show()
        Hide()
    End Sub

    Private Sub SalesOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesOrderToolStripMenuItem.Click
        SalesOrder.Show()
        Hide()
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        ReportSO.Show()
        Hide()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        If MsgBox("Are you sure want to log out?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Front.Show()
            Close()
        End If
    End Sub
End Class