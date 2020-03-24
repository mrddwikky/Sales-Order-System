Imports MySql.Data.MySqlClient
Public Class SalesOrder
    Dim myconn As New MySqlConnection
    Dim myadapter As New MySqlDataAdapter
    Dim mydata As New DataTable
    Dim mycommand As New MySqlCommand

    Sub konek()
        myconn = New MySqlConnection("server='localhost';user id='root';password='';database='salesorder'")
        myconn.Open()
    End Sub

    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        DateTimePicker1.Text = Format(Now)
        DateTimePicker2.Text = Format(Now)
    End Sub

    Sub barang()
        TextBox1.Focus()
        Call konek()
        Dim mydatareader As MySqlDataReader
        mycommand = New MySqlCommand("select * from tbbarang", myconn)
        mydatareader = mycommand.ExecuteReader
        Do While mydatareader.Read
            ComboBox1.Items.Add(mydatareader.Item(0))
        Loop
        myconn.Close()
    End Sub

    Sub customer()
        TextBox1.Focus()
        Call konek()
        Dim mydatareader As MySqlDataReader
        mycommand = New MySqlCommand("select * from tbcustomer", myconn)
        mydatareader = mycommand.ExecuteReader
        Do While mydatareader.Read
            ComboBox2.Items.Add(mydatareader.Item(0))
        Loop
        myconn.Close()
    End Sub

    Sub tampil()
        TextBox1.Focus()
        Call konek()
        myadapter = New MySqlDataAdapter("Select * from tbsalesorder", myconn)
        mydata = New DataTable
        Try
            myadapter.Fill(mydata)
            DataGridView1.DataSource = mydata
            DataGridView1.Columns(0).HeaderText = "SO No."
            DataGridView1.Columns(1).HeaderText = "Input Date"
            DataGridView1.Columns(2).HeaderText = "PO Date"
            DataGridView1.Columns(3).HeaderText = "Product Code"
            DataGridView1.Columns(4).HeaderText = "Product Name"
            DataGridView1.Columns(5).HeaderText = "Selling Price"
            DataGridView1.Columns(6).HeaderText = "Quantity"
            DataGridView1.Columns(7).HeaderText = "PO No."
            DataGridView1.Columns(8).HeaderText = "Delivery Date"
            DataGridView1.Columns(9).HeaderText = "Customer Id"
            DataGridView1.Columns(10).HeaderText = "Customer Name"
            DataGridView1.Columns(11).HeaderText = "Quantity Type"
            DataGridView1.Columns(12).HeaderText = "Price Total"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        myconn.Close()
    End Sub

    Private Sub SalesOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        Call tampil()
        Call barang()
        Call customer()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If TextBox9.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        myadapter = New MySqlDataAdapter("Select * from tbsalesorder where kodeSO Like '%" & TextBox9.Text & "%' or noPO like '%" & TextBox9.Text & "%' or tglInput like '%" & TextBox9.Text & "%' or kodeBrg like '%" & TextBox9.Text & "%' or namaBrg like '%" & TextBox9.Text & "%' or hrgBrg like '%" & TextBox9.Text & "%' or jmlhBrg like '%" & TextBox9.Text & "%' or kodeCust like '%" & TextBox9.Text & "%' or namaCust like '%" & TextBox9.Text & "%' or satuanBrg like '%" & TextBox9.Text & "%' or totalHrg like '%" & TextBox9.Text & "%'", myconn)
        mydata = New DataTable
        myadapter.Fill(mydata)
        DataGridView1.DataSource = mydata
        myconn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim total, harga, qty As Double
        harga = TextBox3.Text
        qty = TextBox4.Text
        total = harga * qty
        TextBox8.Text = total
        '"Rp. "Format(total, "###,###,###")

        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        Else
            Call konek()
            Dim mydatareader As MySqlDataReader
            mycommand = New MySqlCommand("select * from tbsalesorder where kodeSO = '" & TextBox1.Text & "'", myconn)
            mydatareader = mycommand.ExecuteReader
            mydatareader.Read()
            If Not mydatareader.HasRows Then
                Call konek()
                mycommand = New MySqlCommand("insert into tbsalesorder values('" & TextBox1.Text & "','" & Format(DateTimePicker3.Value, "yyyy-MM-dd") & "', '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', '" & ComboBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "', '" & ComboBox2.Text & "', '" & TextBox6.Text & "', '" & TextBox7.Text & "', '" & TextBox8.Text & "' )", myconn)
                mycommand.ExecuteNonQuery()
                myconn.Close()
                Call tampil()
            Else
                MsgBox("OS number code has already recorded!", MsgBoxStyle.Information)
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Home.Show()
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Complete the data!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        If MsgBox("Edit the data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            mycommand = New MySqlCommand("update tbsalesorder set tglPesan = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "', kodeBrg = '" & ComboBox1.Text & "', namaBrg = '" & TextBox2.Text & "', hrgBrg = '" & TextBox3.Text & "', jmlhBrg = '" & TextBox4.Text & "', noPO = '" & TextBox5.Text & "', tglKirim = '" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "', kodeCust = '" & ComboBox2.Text & "', namaCust = '" & TextBox6.Text & "', satuanBrg = '" & TextBox7.Text & "', totalHrg = '" & TextBox8.Text & "'  where kodeSO = '" & TextBox1.Text & "'", myconn)
            mycommand.ExecuteNonQuery()
            myconn.Close()
            MsgBox("Data has been edited", MsgBoxStyle.OkOnly)
            Call tampil()
            Call kosong()
        Else
            MsgBox("No data has been edited", MsgBoxStyle.OkOnly)
            Call tampil()
            Call kosong()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call kosong()
        Call tampil()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Then
            MsgBox("Please complete the OS number!", MsgBoxStyle.Information)
            Exit Sub
        End If

        Call konek()
        If MsgBox("Are you sure want to delete the data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            mycommand = New MySqlCommand("delete from tbsalesorder where kodeSO like '%" & TextBox1.Text & "%'", myconn)
            mycommand.ExecuteNonQuery()
            myconn.Close()
            MsgBox("Data has been deleted", MsgBoxStyle.OkOnly)
            Call tampil()
            Call kosong()
        Else
            MsgBox("No data has been deleted", MsgBoxStyle.OkOnly)
            Call tampil()
            Call kosong()
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call konek()
        Dim mydatareader As MySqlDataReader
        mycommand = New MySqlCommand("select * from tbbarang where kodeBrg = '" & ComboBox1.Text & "'", myconn)
        mydatareader = mycommand.ExecuteReader
        mydatareader.Read()
        If mydatareader.HasRows Then
            TextBox2.Text = mydatareader.Item("namaBrg")
            TextBox3.Text = mydatareader.Item("hrgBrg")
            TextBox2.Focus()
        End If
        myconn.Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call konek()
        Dim mydatareader As MySqlDataReader
        mycommand = New MySqlCommand("select * from tbcustomer where kodeCust = '" & ComboBox2.Text & "'", myconn)
        mydatareader = mycommand.ExecuteReader
        mydatareader.Read()
        If mydatareader.HasRows Then
            TextBox6.Text = mydatareader.Item("namaCust")
            TextBox6.Focus()
        End If
        myconn.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        '' Call konek()
        ''mydata = New DataTable
        ''For Each dr As DataGridViewRow In Me.DataGridView1.Rows
        ''mydata.Rows.Add(dr.Cells("kodeSO").Value)
        ''Next

        ''Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        ''rptDoc = New CrystalReport2
        ''rptDoc.SetDataSource(mydata)

        ''ReportSO.CrystalReportViewer1.ReportSource = rptDoc
        ReportSO.Show()
        ''ReportSO.Dispose()
        Hide()
    End Sub
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
            ErrorProvider1.SetError(TextBox4, "Use number")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub TextBox8_Leave(sender As Object, e As EventArgs) Handles TextBox8.Leave
        Dim total As Double
        total = TextBox8.Text
        TextBox8.Text = total
    End Sub
End Class