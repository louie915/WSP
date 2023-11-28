Imports System.Data.SqlClient

Public Class DocViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Do_View(Request.QueryString("DocID"))
    End Sub

    Sub Do_View(Hash)
        Try
            Dim _nQuery As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim FileType As String
            Dim FileData As Byte()
            Dim FileExt As String
            Dim FileName As String
            _nQuery = "select * from Documents where Hash ='" & Hash & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    FileData = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal("FileData")), Byte())
                    FileType = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal("FileType")))
                    FileName = _nSqlDr.GetValue(_nSqlDr.GetOrdinal("FileName"))
                    FileExt = ".PDF"
                End If
                Response.Clear()
                Response.ContentType = "application/pdf"
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & FileName)
                Response.BinaryWrite(FileData)
                Response.Flush()
                Response.End()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_ServerClick(sender As Object, e As EventArgs) Handles btnSearch.ServerClick
        Do_View(hdnHash.Value)
    End Sub
End Class