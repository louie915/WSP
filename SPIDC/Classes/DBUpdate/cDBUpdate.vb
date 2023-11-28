
Imports System.Data.SqlClient
Public Class cDBUpdate



    Public Shared Sub Init_DBUpdate()
        Try
            'TODO:  UPDATE SOS DATABASES

            cDBUpdate_OAIMS.Initialize()
            '       cDBUpdate_SOS_BP.Initialize()

        Catch ex As Exception

        End Try

    End Sub


    Public Shared Sub Update_Table(ByVal xSQLCon As SqlConnection, ByVal xTable As String, Optional xColumn As String = Nothing, Optional xDataType As String = Nothing)

        If DBObject.IsObjectExist(xSQLCon, xTable) = True Then
            If xColumn <> Nothing Then
                DBObject.UpdateTblCol(xSQLCon, xTable, xColumn, xDataType)
            End If
        Else
            DBObject.Create(xSQLCon, xTable)
        End If

    End Sub

    Public Shared Sub Update_Views(ByVal xSQLCon As SqlConnection, ByVal xObjectName As String)

        If DBObject.IsObjectExist(xSQLCon, xObjectName) = True Then
            DBObject.Views_Alter(xSQLCon, xObjectName)
        Else
            DBObject.Views_Create(xSQLCon, xObjectName)
        End If

    End Sub


    Public Shared Sub Update_StoredProc(ByVal xSQLCon As SqlConnection, ByVal xObjectName As String)

        If DBObject.IsObjectExist(xSQLCon, xObjectName) = True Then
            DBObject.Views_Alter(xSQLCon, xObjectName)
        Else
            DBObject.Views_Create(xSQLCon, xObjectName)
        End If

    End Sub






End Class
