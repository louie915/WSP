Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Services

Partial Public Class BPLTIMSNewBusinessApplication

    <WebMethod()> _
    Public Shared Function BindCategory() As List(Of ListItem)
        Try
            Dim _nClass As New cDalCATCODE
            Dim _nList As New List(Of ListItem)()
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect("CATCODE, CATDESC")

            Using sdr As SqlDataReader = _nClass._pSqlCommand.ExecuteReader()
                While sdr.Read()
                    _nList.Add(New ListItem() With { _
                      .Value = sdr("CATCODE").ToString(), _
                      .Text = sdr("CATDESC").ToString() _
                    })
                End While
            End Using
            Return _nList

        Catch ex As Exception

        End Try
    End Function

    Private Sub getDataCategory()
        Dim constr As String = cGlobalConnections._pStrCxn_BPLTAS
        Dim dt As DataTable = New DataTable()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT CATCODE, CATDESC FROM CATCODE", connection)
        Dim sqlDa As SqlDataAdapter = New SqlDataAdapter()
        sqlDa.SelectCommand = sqlCmd
        sqlDa.Fill(dt)

        If dt.Rows.Count > 0 Then
            RadioButtonList1.DataSource = dt
            RadioButtonList1.DataTextField = "CATDESC"
            RadioButtonList1.DataValueField = "CATCODE"
            RadioButtonList1.DataBind()
        End If

        connection.Close()
    End Sub

End Class
