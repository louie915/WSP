Imports System.Data.SqlClient
Imports System.Drawing

Public Class BusinessComparativeCollection
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
        Else



            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")
            Dim isCaloocan As Boolean = cGlobalConnections._pSqlCxn_BPLTAS.Database.ToUpper.Contains("CALOOCAN")
            Dim isNoFire As Boolean = Not _oChkPresent.Checked

            'If Year(_oDtpFrom.Value) <> Year(_oDtpTo.Value) Then snackbar(False, "Exclusive year should have the same year..") : Exit Sub

            Execute("exec [sp_Compare_2yrs_Collections] '" & _oDtpFrom.Value & "','" & _oDtpTo.Value & "'," & isCaloocan & "," & isNoFire & "")
            'gt.InnerText = "Total: " & Format(getRow("gt", "sum(amount) gt", "[" & tmptabl & "]"), "standard")
            LabelPos.InnerText = "Business Comparative Collection"

            PopulateRecords(_oGridViewAppList, "Particular,Prev,Pres,Diff", "[TEMPTBL_BP]", "", "", "")

            If _oGridViewAppList.Visible Then
                'For index = 1 To 2
                '    _oGridViewAppList.Rows(1).Cells(index).Text = 111 '.ToString("{R}")
                '    _oGridViewAppList.Rows(2).Cells(index).Text = _oGridViewAppList.Rows(2).Cells(index).Text '.ToString("{R}")
                'Next
                ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "HidePopup();", True)
            Else
                snackbar(False, "No record found!")
            End If
            Exit Sub


        End If
    End Sub

    Protected Sub _oGridViewAppList_RowDataBound(sender As Object, e As GridViewRowEventArgs)
        Try

            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(1).Text = Year(_oDtpFrom.Value) - 1
                e.Row.Cells(2).Text = Year(_oDtpFrom.Value)
            End If

        Catch ex As Exception

        End Try
    End Sub




    Public Function getRow(FieldToGet As String, field As String, table As String, Optional condField As String = "") As String
        Try
            Dim val As String
            Dim cond As String = IIf(condField.Trim <> "", " where " & condField, "")
            Dim getQuer As String = "select " & field.ToUpper & " from " & table & cond
            Dim _TempCmd As New SqlCommand(getQuer, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            _TempReader.Read()
            val = IIf(_TempReader.HasRows, _TempReader.Item(FieldToGet).ToString, "")
            _TempReader.Close()
            _TempCmd.Dispose()
            getRow = val
        Catch ex As Exception
            getRow = ""
        End Try
    End Function

    Public Sub Execute(str As String)
        Try
            Dim getquery As String = str

            Dim _pSqlConnection As SqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            Dim _mSqlCommand As SqlCommand = New SqlCommand(getquery, _pSqlConnection)
            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub NavigatePage(Pos, page)
        Try
            Select Case Pos
                Case "<"
                    Write("window.history.go(-1);", page)
                Case Else
                    page.Response.Redirect(Pos & ".aspx")
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PopulateRecords(dg As GridView, _fields As String, _table As String, Optional _condition As String = "", Optional _groupBy As String = "", Optional _orderBy As String = "")
        Try
            Dim getquery As String = IIf(_fields.Trim <> "", " SELECT " & _fields.Trim, "") & "  " & IIf(_table.Trim <> "", " FROM " & _table.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "") & IIf(_groupBy.Trim <> "", " GROUP BY " & _groupBy.Trim, "") & IIf(_orderBy.Trim <> "", " ORDER BY " & _orderBy.Trim, "")

            Dim _mSqlComman As SqlCommand = New SqlCommand(getquery, cGlobalConnections._pSqlCxn_BPLTAS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(getquery, cGlobalConnections._pSqlCxn_BPLTAS)

            Dim _mDataTable As DataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            dg.Visible = _mSqlComman.ExecuteReader.HasRows

            dg.DataSource = _mDataTable
            dg.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CUD(action As String, _fields As String, _table As String, Optional _condition As String = "")
        Try
            Dim getquery As String = ""

            Select Case action
                Case "C" ' IF SPECIFIC YUNG FIELD SA INSERT INCLUED IT BESIDE _table parameter ' CARL20190802
                    getquery = "INSERT INTO " & IIf(_table.Trim <> "", _table.Trim, "") & " VALUES(" & IIf(_fields.Trim <> "", _fields.Trim, "") & ")"
                Case "U"
                    getquery = "UPDATE " & IIf(_table.Trim <> "", _table.Trim, "") & " set " & IIf(_fields.Trim <> "", _fields.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
                Case "D"
                    getquery = "DELETE " & IIf(_table.Trim <> "", _table.Trim, "") & " " & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
                Case Else
            End Select
            Dim _pSqlConnection = cGlobalConnections._pSqlCxn_TOIMS
            Dim _mSqlCommand = New SqlCommand(getquery, _pSqlConnection)
            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub MessageBox(Text, page)
        Try
            page.Response.Write("<script>try{alert('" & Text & "');}catch(e){alert(e.message);}</script>")
        Catch ex As Exception
            page.Response.Write("<script>try{alert('" & ex.Message & "');}catch(e){alert(e.message);}</script>")
        End Try
    End Sub

    Sub snackbar(success As Boolean, Caption As String)
        Select Case success
            Case True
                _oLabelSnackbargreen.Text = Caption
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
            Case False
                _oLabelSnackbar.Text = Caption
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)
        End Select

    End Sub

End Class