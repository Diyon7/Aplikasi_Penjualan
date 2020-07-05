Imports System.Data.Odbc
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class laporanadmin
    Dim cetakadmin As laporandataadmin
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        ds = New DataSet
        ds.Clear()
        cetakadmin = New laporandataadmin
        cetakadmin.SetDataSource(ds)
        CrystalReportViewer1.RefreshReport()
        CrystalReportViewer1.ReportSource = cetakadmin
    End Sub
End Class