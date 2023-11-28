Imports System.Data.SqlClient



Public Class cSystemObject


    Private Shared _mSqlCommand As SqlCommand
    Public Shared _mSqlDataReader As SqlDataReader
    Public Shared _mDataTable As DataTable
    Private Shared _mDbCon As New SqlConnection
    Public Shared _mSqlCon As SqlConnection


    Public Shared Function _CheckExistence_Table(ByVal xTable As String) As Boolean
        _CheckExistence_Table = False
        Try

            Dim _nQuery As String = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME='" & xTable & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

        Catch ex As Exception


            Return True


        End Try
    End Function

End Class
