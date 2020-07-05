Public Class formutama
    Sub kunci()
        LoginToolStripMenuItem.Enabled = True
        LogoutToolStripMenuItem.Enabled = False
        MasterToolStripMenuItem.Enabled = False
        TransaksiToolStripMenuItem.Enabled = False
        LaporanToolStripMenuItem.Enabled = False
        STLabel2.Text = ""
        STLabel4.Text = ""
        STLabel6.Text = ""
    End Sub

    Private Sub formutama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kunci()
        STLabel10.Text = Today
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        FormLogin.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Call kunci()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        End
    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        formmasteradmin.ShowDialog()
    End Sub

    Private Sub PelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PelangganToolStripMenuItem.Click
        formmasterpelanggan.ShowDialog()
    End Sub

    Private Sub BarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarangToolStripMenuItem.Click
        formmasterbarang.ShowDialog()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        STLabel8.Text = TimeOfDay
    End Sub

    Private Sub TransaksiPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiPenjualanToolStripMenuItem.Click
        formtransaksijual.ShowDialog()
    End Sub

    Private Sub TransaksiPembelianBahanBakuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransaksiPembelianBahanBakuToolStripMenuItem.Click
        supplier.ShowDialog()
    End Sub

    Private Sub AdminToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem1.Click
        laporanadmin.ShowDialog()
    End Sub

    Private Sub PelangganToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PelangganToolStripMenuItem1.Click
        laporanmember.ShowDialog()
    End Sub

    Private Sub BarangToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BarangToolStripMenuItem1.Click
        laporanbarang.ShowDialog()
    End Sub

    Private Sub LaporanPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanPenjualanToolStripMenuItem.Click
        laporanpenjualantanggal.ShowDialog()
    End Sub

    Private Sub DaftarAnggotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarAnggotaToolStripMenuItem.Click
        daftarpelanggan.ShowDialog()
    End Sub
End Class
