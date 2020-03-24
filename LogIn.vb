Imports MySql.Data.MySqlClient
Public Class LogIn
    Dim myconn As New MySqlConnection
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable

    Sub konek()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='salesorder'")
        myconn.Open()
    End Sub

    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub HomeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HomeToolStripMenuItem.Click
        Front.Show()
        Hide()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        SignUp.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call konek()
        myadapter = New MySqlDataAdapter("select * from tbadmin where namaAdm = '" & TextBox1.Text & "'", myconn)
        mydata = New DataTable
        myadapter.Fill(mydata)
        If mydata.Rows.Count > 0 Then
            If mydata.Rows(0)("passAdm") = TextBox2.Text Then
                If mydata.Rows(0)("level") = "Admin" Then
                    MsgBox("Anda berhasil login", MsgBoxStyle.Information)
                    Home.Show()
                    Hide()
                    Call kosong()
                Else
                    MsgBox("Anda berhasil login", MsgBoxStyle.Information)
                    Home2.Show()
                    Hide()
                    Call kosong()
                End If
            Else
                MsgBox("Masukkan nama dan password anda dengan benar", MsgBoxStyle.Information)
                TextBox1.Focus()
                Call kosong()
            End If
        End If
        myconn.Close()
    End Sub
End Class