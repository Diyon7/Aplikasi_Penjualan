Imports System.Data.Odbc
Public Class daftarpelanggan
    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False

        Button2.Enabled = True
        Button3.Enabled = True
        Button1.Text = "tutup"
        Button2.Text = "daftar"
        Button3.Text = "edit"
        Call koneksi()
        da = New OdbcDataAdapter("select * from pelanggan", conn)
        ds = New DataSet
        da.Fill(ds, "pelanggan")
        DataGridView1.DataSource = ds.Tables("pelanggan")
        DataGridView1.ReadOnly = True

    End Sub

    Sub siapisi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
    End Sub

    Private Sub formmasterpelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Dim bant As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "daftar" Then
            Button2.Text = "simpan"
            Button3.Enabled = False
            Button1.Text = "batal"
            Call siapisi()
            bant = ""
            TextBox1.Enabled = False
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()

            Call koneksi()
            TextBox2.Focus()

            cmd = New OdbcCommand("SELECT CASE WHEN MAX(CONVERT(SUBSTRING(kodepelanggan,3,7), SIGNED INTEGER))+1 is null THEN 1 ELSE MAX(CONVERT(SUBSTRING(kodepelanggan,5,7), SIGNED INTEGER))+1 END FROM pelanggan", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            TextBox1.Text = rd.Item(0)
            For i As Integer = 1 To 7 - TextBox1.TextLength
                bant = bant
            Next
            TextBox1.Text = "PLG00" & bant & TextBox1.Text
            rd.Close()
            cmd.Dispose()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                'Call koneksi()
                Dim inputdata As String = "insert into pelanggan values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                cmd = New OdbcCommand(inputdata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("input berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "edit" Then
            Button3.Text = "simpan"
            Button2.Enabled = False
            Button1.Text = "batal"
            Call siapisi()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
                MsgBox("Silahkan Diisi Semua")
            Else
                Call koneksi()
                Dim updatedata As String = "Update pelanggan set namapelanggan='" & TextBox2.Text & "', alamatpelanggan='" & TextBox3.Text & "', teleponpelanggan='" & TextBox4.Text & "' where kodepelanggan='" & TextBox1.Text & "'"
                cmd = New OdbcCommand(updatedata, conn)
                cmd.ExecuteNonQuery()
                MsgBox("update berhasil")
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            cmd = New OdbcCommand("Select * From pelanggan Where kodepelanggan ='" & TextBox1.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                MsgBox("kode harus dimasukkan")
            Else
                TextBox1.Text = rd.Item("kodepelanggan")
                TextBox2.Text = rd.Item("namapelanggan")
                TextBox3.Text = rd.Item("alamatpelanggan")
                TextBox4.Text = rd.Item("teleponpelanggan")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "tutup" Then
            Me.Close()
        Else
            Call kondisiawal()
        End If
    End Sub
End Class