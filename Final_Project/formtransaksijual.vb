Imports System.Data.Odbc

Public Class formtransaksijual

    Dim tglMySQL As String

    Sub kondisiawal()
        lblnamaplg.Text = ""
        lblalamatplg.Text = ""
        lblteleponplg.Text = ""
        lbltanggal.Text = Today
        lbladmin.Text = formutama.STLabel4.Text
        lblkembali.Text = ""
        lblstokbarang.Text = ""
        TextBox2.Text = ""
        lblnamabrg.Text = ""
        lblhargabrg.Text = ""
        TextBox3.Text = ""
        TextBox3.Enabled = False
        lblitem.Text = ""
        Call munculkodepelanggan()
        Call nomorotomatis()
        Call kolombelumisi()
        lbluangttl.Text = 0
        TextBox1.Text = ""

    End Sub

    Sub nomorotomatis()
        cmd = New OdbcCommand("SELECT CASE WHEN MAX(CONVERT(SUBSTRING(nojual,3,9), SIGNED INTEGER))+1 is null THEN 1 ELSE MAX(CONVERT(SUBSTRING(nojual,5,7), SIGNED INTEGER))+1 END FROM jual", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        lblnojual.Text = rd.Item(0)
        lblnojual.Text = "JL000000" + lblnojual.Text
        rd.Close()
        cmd.Dispose()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbljam.Text = TimeOfDay
    End Sub

    Private Sub formtransaksijual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()

    End Sub

    Sub munculkodepelanggan()
        Call koneksi()
        ComboBox1.Items.Clear()
        cmd = New OdbcCommand("select * from pelanggan", conn)
        rd = cmd.ExecuteReader
        Do While rd.Read
            ComboBox1.Items.Add(rd.Item(0))
        Loop
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        cmd = New OdbcCommand("select * from pelanggan where kodepelanggan='" & ComboBox1.Text & "'", conn)
        rd = cmd.ExecuteReader
        rd.Read()
        'ComboBox1.Items.Clear()
        If rd.HasRows Then
            lblnamaplg.Text = rd!namapelanggan
            lblalamatplg.Text = rd!alamatpelanggan
            lblteleponplg.Text = rd!teleponpelanggan
        End If
    End Sub

    Sub kolombelumisi()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("Kode", "Kode")
        DataGridView1.Columns.Add("Nama", "Nama Barang")
        DataGridView1.Columns.Add("Harga", "harga")
        DataGridView1.Columns.Add("Jumlah", "Jumlah")
        DataGridView1.Columns.Add("Subtotal", "Subtotal")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        lblkembali.Text = Val(TextBox1.Text) - Val(lbluangttl.Text)
        If lblkembali.Text < 0 Then
            lblkembali.Text = "Uang Kurang"
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New OdbcCommand("Select * From barang Where kodebarang ='" & TextBox2.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("kode harus dimasukkan")
            Else
                TextBox2.Text = rd.Item("kodebarang")
                lblnamabrg.Text = rd.Item("namabarang")
                lblstokbarang.Text = rd.Item("jumlahbarang")
                lblhargabrg.Text = rd.Item("hargabarang")
                TextBox3.Enabled = True
                TextBox3.Focus()
            End If
        End If
    End Sub

    Private Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
        If lblnamabrg.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Silahkan isi kode terus enter dan tambahkan jumlah barang")
        Else
            If Val(lblstokbarang.Text) < Val(TextBox3.Text) Then
                MsgBox("Stok Barang Kurang")
            Else
                DataGridView1.Rows.Add(New String() {TextBox2.Text, lblnamabrg.Text, lblhargabrg.Text, TextBox3.Text, Val(lblhargabrg.Text) * Val(TextBox3.Text)})
                Call rumustotal()
                TextBox2.Text = ""
                lblnamabrg.Text = ""
                lblhargabrg.Text = ""
                TextBox3.Text = ""
                TextBox3.Enabled = False
                Call rumusitem()
            End If
        End If
    End Sub

    Sub rumustotal()
        Dim hitung As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            hitung = hitung + DataGridView1.Rows(i).Cells(4).Value
            lbluangttl.Text = hitung
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or lblnamaplg.Text = "" Or lblitem.Text = "" Then
            MsgBox("transaksi tidak ada, silahkan lakukan transaksi terlebih dahulu")
        ElseIf Val(TextBox1.Text) < Val(lbluangttl.Text) Then
            MsgBox("Pembayaran Kurang")
        Else
            tglMySQL = Format(Today, "yyyy-MM-dd")
            Dim simpanjual As String = "Insert into jual values ('" & lblnojual.Text & "','" & tglMySQL & "','" & lbljam.Text & "','" & lblitem.Text & "','" & lbluangttl.Text & "','" & TextBox1.Text & "','" & lblkembali.Text & "','" & ComboBox1.Text & "','" & formutama.STLabel2.Text & "')"
            cmd = New OdbcCommand(simpanjual, conn)
            cmd.ExecuteNonQuery()

            For baris As Integer = 0 To DataGridView1.Rows.Count - 2
                Dim detailjual As String = "Insert into detailjual values('" & lblnojual.Text & "','" & DataGridView1.Rows(baris).Cells(0).Value & "','" & DataGridView1.Rows(baris).Cells(1).Value & "','" & DataGridView1.Rows(baris).Cells(2).Value & "','" & DataGridView1.Rows(baris).Cells(3).Value & "','" & DataGridView1.Rows(baris).Cells(4).Value & "')"
                cmd = New OdbcCommand(detailjual, conn)
                cmd.ExecuteNonQuery()

                cmd = New OdbcCommand("Select * from barang where kodebarang='" & DataGridView1.Rows(baris).Cells(0).Value & "'", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                Dim kurangistok As String = "Update barang set jumlahbarang = '" & rd.Item("jumlahbarang") - DataGridView1.Rows(baris).Cells(3).Value & "' where kodebarang='" & DataGridView1.Rows(baris).Cells(0).Value & "'"
                cmd = New OdbcCommand(kurangistok, conn)
                cmd.ExecuteNonQuery()

            Next

            If MessageBox.Show("Apakah Ingin Cetak Struk ?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                strukjual.ShowDialog()
            End If

            Call kondisiawal()
                MsgBox("Transaksi Telah Berhasil")

            End If
    End Sub

    Sub rumusitem()
        Dim hitungitem As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            hitungitem = hitungitem + DataGridView1.Rows(i).Cells(3).Value
            lblitem.Text = hitungitem
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If e.KeyChar = Chr(13) Then
            insert.Focus()
        End If
    End Sub
End Class