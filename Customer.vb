Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class Customer
    Dim myconn As New MySqlConnection
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim mycommand As New MySqlCommand

    Sub konek()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='salesorder'")
        myconn.Open()
    End Sub

    Sub kosong()
        RichTextBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Sub tampil()
        Call konek()
        myadapter = New MySqlDataAdapter("select * from tbcustomer", myconn)
        mydata = New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        DataGridView1.Columns(0).HeaderText = "Customer Id"
        DataGridView1.Columns(1).HeaderText = "Customer Name"
        DataGridView1.Columns(2).HeaderText = "Address"
        DataGridView1.Columns(3).HeaderText = "Telephone"
        myconn.Close()

        TextBox1.Focus()
    End Sub

    Private Sub DataCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampil()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        Else
            Call konek()
            Dim mydatareader As MySqlDataReader
            mycommand = New MySqlCommand("select * from tbcustomer where kodeCust = '" & TextBox1.Text & "'", myconn)
            mydatareader = mycommand.ExecuteReader
            mydatareader.Read()
            If Not mydatareader.HasRows Then
                Call konek()
                mycommand = New MySqlCommand("insert into tbcustomer values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & RichTextBox1.Text & "', '" & TextBox3.Text & "')", myconn)
                mycommand.ExecuteNonQuery()
                myconn.Close()
                MsgBox("Data has been saved", MsgBoxStyle.OkOnly)
                Call kosong()
                Call tampil()
            Else
                MsgBox("Customer id has already recorded!", MsgBoxStyle.Information)
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        If MsgBox("Edit the data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            mycommand = New MySqlCommand("update tbcustomer set namaCust = '" & TextBox2.Text & "', alamatCust = '" & RichTextBox1.Text & "', telpCust = '" & TextBox3.Text & "' where kodeCust = '" & TextBox1.Text & "'", myconn)
            mycommand.ExecuteNonQuery()
            myconn.Close()
            MsgBox("Data has been edited", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        Else
            MsgBox("No data has been edited", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call kosong()
        Call tampil()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or RichTextBox1.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        If MsgBox("Are you sure want to delete the data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            mycommand = New MySqlCommand("delete from tbcustomer where kodeCust = '" & TextBox1.Text & "'", myconn)
            mycommand.ExecuteNonQuery()
            myconn.Close()
            MsgBox("Data has been deleted", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        Else
            MsgBox("No data has been deleted", MsgBoxStyle.OkOnly)
            Call kosong()
            Call tampil()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If TextBox4.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        myadapter = New MySqlDataAdapter("select * from tbcustomer where kodeCust like '%" & TextBox4.Text & "%' or namaCust like '%" & TextBox4.Text & "%' or alamatCust like '%" & TextBox4.Text & "%' or telpCust like '%" & TextBox4.Text & "%'", myconn)
        mydata = New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        myconn.Close()
        Call kosong()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
            ErrorProvider1.SetError(TextBox3, "Use number")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class