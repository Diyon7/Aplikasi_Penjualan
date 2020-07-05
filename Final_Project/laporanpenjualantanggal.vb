Imports System.Data.Odbc
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class laporanpenjualantanggal
    Dim lpt As New laporanpenjualan
    Private Sub lihat_Click(sender As Object, e As EventArgs) Handles lihat.Click
        ds = New DataSet
        ds.Clear()
        lpt = New laporanpenjualan
        lpt.SetDataSource(ds)
        laporanpenjualanberdasartanggal.SelectionFormula = "totext ({jual1.tgljual}) ='" & tanggallaporan.Text & "'"
        laporanpenjualanberdasartanggal.ReportSource = Nothing
        laporanpenjualanberdasartanggal.RefreshReport()
        laporanpenjualanberdasartanggal.ReportSource = lpt
    End Sub
End Class