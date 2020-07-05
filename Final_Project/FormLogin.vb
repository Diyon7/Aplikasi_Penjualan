Imports System.Data.Odbc

Public Class FormLogin
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
    Sub buka()
        formutama.LoginToolStripMenuItem.Enabled = False
        formutama.LogoutToolStripMenuItem.Enabled = True
        formutama.MasterToolStripMenuItem.Enabled = True
        formutama.TransaksiToolStripMenuItem.Enabled = True
        formutama.LaporanToolStripMenuItem.Enabled = True
    End Sub
    Sub kondisiawal()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Harus Diisi atau Tidak Boleh Kosong")
        Else
            Call koneksi()
            cmd = New OdbcCommand("select * from admin where kodeadmin='" & TextBox1.Text & "' and passwordadmin = '" & TextBox2.Text & "'", conn)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows Then
                Me.Close()
                Call buka()
                formutama.STLabel2.Text = rd!kodeadmin
                formutama.STLabel4.Text = rd!namaadmin
                formutama.STLabel6.Text = rd!leveladmin
                If formutama.STLabel6.Text = "kasir" Or formutama.STLabel6.Text = "gudang" Then
                    formutama.AdminToolStripMenuItem.Enabled = False
                    If formutama.STLabel6.Text = "kasir" Then
                        formutama.BarangToolStripMenuItem.Enabled = False
                    ElseIf formutama.STLabel6.Text = "gudang" Then
                        formutama.TransaksiPenjualanToolStripMenuItem.Enabled = False
                        formutama.PelangganToolStripMenuItem.Enabled = False
                    Else
                        formutama.BarangToolStripMenuItem.Enabled = True
                        formutama.PelangganToolStripMenuItem.Enabled = True
                    End If
                Else
                    formutama.AdminToolStripMenuItem.Enabled = True
                End If
            Else
                MsgBox("kodeadmin atau password salah")
            End If
        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub
End Class