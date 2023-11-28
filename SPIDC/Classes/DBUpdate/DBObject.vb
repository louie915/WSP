Imports System.Data.SqlClient
Public Class DBObject


    Private Shared _mQuery As String = Nothing
    Private Shared _mSqlCommand As SqlCommand
    Private Shared _mSqlDataReader As SqlDataReader
    Public Shared _mDataTable As DataTable
    Public Shared _mSqlCon As SqlConnection

    Public Shared Function IsObjectExist(ByVal xSQLCon As SqlConnection, ByVal xTable As String) As Boolean
        IsObjectExist = True
        Try
            Dim _nQuery As String = Nothing
            _mQuery = " Select name from sys.objects  where [name] = '" & xTable & "'"
            '----------------------------------  
            _mSqlCommand = New SqlCommand(_mQuery, xSQLCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, xSQLCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            If _mDataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Function

    Public Shared Sub Create(ByVal xSQLCon As SqlConnection, ByVal xTable As String)
        Try

            Dim _nQuery As String = Nothing

            _nQuery = cDBScript.DBObject(xTable)

            Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub UpdateTblCol(ByVal xSQLCon As SqlConnection, ByVal xTable As String, ByVal xColumn As String, ByVal xDataType As String)
        Try
            If IsColumnExist(xSQLCon, xTable, xColumn, xDataType) = True Then
                UpdateColumn(xSQLCon, xTable, xColumn, xDataType)
            Else
                AddColumn(xSQLCon, xTable, xColumn, xDataType)
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub Views_Alter(ByVal xSQLCon As SqlConnection, ByVal xTable As String)
        Try

            Try

                Dim _nQuery As String = Nothing
                cDBScript.IsExist = True
                _nQuery = cDBScript.DBObject(xTable)

                Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub Views_Create(ByVal xSQLCon As SqlConnection, ByVal xTable As String)
        Try

            Try

                Dim _nQuery As String = Nothing
                cDBScript.IsExist = False
                _nQuery = cDBScript.DBObject(xTable)

                Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub StoredProc_Create(ByVal xSQLCon As SqlConnection, ByVal xTable As String)
        Try

            Try

                Dim _nQuery As String = Nothing

                _nQuery = cDBScript.DBObject(xTable)

                Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub StoredProc_Alter(ByVal xSQLCon As SqlConnection, ByVal xTable As String)
        Try

            Try

                Dim _nQuery As String = Nothing

                _nQuery = cDBScript.DBObject(xTable)

                Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
                '----------------------------------
                _nSqlCommand.ExecuteNonQuery()
                '----------------------------------
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub UpdateColumn(ByVal xSQLCon As SqlConnection, ByVal xTable As String, ByVal xColumn As String, ByVal xDataType As String)
        Try

            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE " & xTable & _
                   " ALTER Column " & xColumn & " " & xDataType

            Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Sub AddColumn(ByVal xSQLCon As SqlConnection, ByVal xTable As String, ByVal xColumn As String, ByVal xDataType As String)
        Try

            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE " & xTable & _
                   " ADD  " & xColumn & " " & xDataType

            Dim _nSqlCommand As New SqlCommand(_nQuery, xSQLCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Public Shared Function IsColumnExist(ByVal xSQLCon As SqlConnection, ByVal xTable As String, ByVal xColumn As String, ByVal xDataType As String) As Boolean
        IsColumnExist = True
        Try
            Dim _nQuery As String = Nothing
            _mQuery = "  SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS  where TABLE_NAME  = '" & xTable & "' and COLUMN_NAME = '" & xColumn & "' "
            '----------------------------------  
            _mSqlCommand = New SqlCommand(_mQuery, xSQLCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, xSQLCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            If _mDataTable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Function

   
End Class
