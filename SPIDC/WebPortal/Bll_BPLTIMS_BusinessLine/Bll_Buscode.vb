Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Data
Imports System.Configuration

Partial Public Class BPLTIMSNewBusinessApplication

    <WebMethod()> _
    Public Shared Function GetData(CatCode As String) As DetailsClass()
        Dim Detail As List(Of DetailsClass) = New List(Of DetailsClass)()
        Dim SelectString As String = "SELECT  BUS_CODE,[DESCRIPTION],CATEGORY FROM BUSCODE where CATEGORY = '" & CatCode & "'"
        Dim cn As SqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        Dim cmd As SqlCommand = New SqlCommand(SelectString, cn)
        'cn.Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtGetData As DataTable = New DataTable()
        da.Fill(dtGetData)

        For Each dtRow As DataRow In dtGetData.Rows
            Dim DataObj As DetailsClass = New DetailsClass()
            DataObj.BusCode = dtRow("BUS_CODE").ToString()
            DataObj.Description = dtRow("DESCRIPTION").ToString()
            DataObj.Category = dtRow("CATEGORY").ToString()
        Next

        Return Detail.ToArray()
    End Function

    Public Class DetailsClass
        Public Property BusCode As String
        Public Property Description As String
        Public Property Category As String
    End Class

    <WebMethod()>
    Public Shared Function GetCustomers() As String
        Dim constr As String = cGlobalConnections._pStrCxn_BPLTAS
        Using con As SqlConnection = New SqlConnection(constr)
            Using cmd As SqlCommand = New SqlCommand()
                cmd.CommandText = "SELECT  BUS_CODE,[DESCRIPTION],CATEGORY FROM BUSCODE "
                cmd.Connection = con
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    Dim ds As DataSet = New DataSet()
                    sda.Fill(ds)
                    Return ds.GetXml()
                End Using
            End Using
        End Using
    End Function

    Public Sub GetDataBusline(CatCode As String)

        Dim constr As String = cGlobalConnections._pStrCxn_BPLTAS
        Dim dt As DataTable = New DataTable()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT  BUS_CODE,[DESCRIPTION],CATEGORY FROM BUSCODE where CATEGORY = '" & CatCode & "'", connection)
        Dim sqlDa As SqlDataAdapter = New SqlDataAdapter()
        sqlDa.SelectCommand = sqlCmd
        sqlDa.Fill(dt)

        If dt.Rows.Count > 0 Then
            For Each dtRow As DataRow In dt.Rows
                CheckBoxList1.DataSource = dt
                CheckBoxList1.DataTextField = "DESCRIPTION"
                CheckBoxList1.DataValueField = "BUS_CODE"
                CheckBoxList1.DataBind()
            Next
        End If

        connection.Close()
    End Sub

End Class
