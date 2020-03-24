Public Class ReportSO
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        CrystalReportViewer1.SelectionFormula = "month ({tbsalesorder1.tglPesan}) = (" & Month(DateTimePicker1.Text) & ") and year ({tbsalesorder1.tglPesan}) = (" & Year(DateTimePicker1.Text) & ")"
        CrystalReportViewer1.ReportSource = "C:\Users\Dwikky Mardianto\Documents\Visual Studio 2015\Projects\SalesOrder\SalesOrder\CrystalReport1.rpt"
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class