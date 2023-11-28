Imports System.Data.SqlClient
Imports System.Reflection.MethodBase
Public Class cValidation


    <System.Web.Services.WebMethod()>
    Public Shared Function CheckifRecordExist(ByVal xDatabase As String, ByVal xTable As String, ByVal xColumn As String, ByVal xValue As String) As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = Get_SQLCon(xDatabase)
                ._pAction = "SELECT"
                ._pSelect = "SELECT " & xColumn & " FROM " & xTable
                ._pCondition = "WHERE UPPER(REPLACE(" & xColumn & ",'' '','''') ) in ( ''" & xValue.ToString.Replace(" ", "").ToUpper & "'' )"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        Catch ex As Exception

        End Try

    End Function

    Public Shared Function Get_SQLCon(ByVal xDatabase As String) As SqlConnection
        Try
            Select Case xDatabase
                Case "CR"
                    Return cGlobalConnections._pSqlCxn_CR
                Case "OAIMS"
                    Return cGlobalConnections._pSqlCxn_OAIMS
                Case "BPLTAS"
                    Return cGlobalConnections._pSqlCxn_BPLTAS
                Case "BPLTIMS"
                    Return cGlobalConnections._pSqlCxn_BPLTIMS

            End Select
        Catch ex As Exception

        End Try
    End Function

End Class
