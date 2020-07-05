Imports System.Data.Odbc

Module Module1
    Public conn As New OdbcConnection
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public rd As OdbcDataReader
    Public cmd As OdbcCommand
    Public mydb As String
    Public Sub koneksi()
        mydb = "Driver={Mysql ODBC 8.0 Unicode Driver};Database=final_project_pdekstop;server=localhost;uid=root"
        conn = New OdbcConnection(mydb)
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
End Module
