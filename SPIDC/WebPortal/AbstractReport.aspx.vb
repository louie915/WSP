Imports System.Data.SqlClient
Imports System.Drawing

Public Class AbstractReport
    Inherits System.Web.UI.Page
    Dim cdal As cDalHRIMS


    Public Shared daterange As String
    Public Shared dateFrom As String
    Public Shared ReportType As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            Select Case action
                Case "view"

                    Dim seq_code = "03" & _oCmbSelectReport.SelectedValue
                    Dim tmptabl As String = "tempAbstract_" & cSessionUser._pIDNo

                    Execute("exec [SP_GENERATE_REPORT] '" & _oDtpFrom.Value & "','" & _oDtpTo.Value & "','" & _oCmbAllfunds.SelectedValue & "','" & tmptabl & "','" + seq_code + "','" & cSessionUser._pIDNo & "','" & _oChkPresent.Checked & "'")

                    gt.InnerText = "Total: " & Format(getRow("gt", "sum(amount) gt", "[" & tmptabl & "]"), "standard")

                    LabelPos.InnerText = IIf(_oChkPresent.Checked, "City Collection", _oCmbSelectReport.SelectedItem().Text) & " - " & _oCmbAllfunds.SelectedItem().Text

                    ReportType = LabelPos.InnerText
                    daterange = _oDtpFrom.Value & " - " & _oDtpTo.Value

                    PopulateRecords(_oGridViewAppList, "accno,dname,sum(amount)AMOUNT", "[" & tmptabl & "]", "", " accno,dname", "[amount] desc")

                    If _oGridViewAppList.Visible Then
                        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "HidePopup();", True)
                    Else
                        snackbar(False, "No record found!")
                    End If

                    Exit Sub
                Case Else
                    Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=TIMS_Abstract','_blank');</script>")
                    Exit Sub
            End Select


     
        End If

        InsertItemInDropdown(_oCmbSelectReport, 1, "Code", "Description", "Description,Code", "Tables", "Seq = '03' order by code desc")
        InsertItemInDropdown(_oCmbAllfunds, 1, "Code2", "Description", "Description,Code2", "tabextn", "Seq+code1 = '02006' Order By Code2")
    End Sub

    Public Sub InsertItemInDropdown(obj As DropDownList, StartPos As Integer, Code As String, Desc As String, _fields As String, _table As String, Optional _condition As String = "")
        Try
            Dim getquery As String = IIf(_fields.Trim <> "", " SELECT " & _fields.Trim, "") & "  " & IIf(_table.Trim <> "", " FROM " & _table.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")


            Dim _TempCmd As New SqlCommand(getquery, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader

            If _TempReader.HasRows Then
                For index = 1 To obj.Items.Count
                    If obj.Items.Count = 1 Then GoTo hop
                    obj.Items.RemoveAt(1)
hop:
                Next
                While _TempReader.Read
                    obj.Items.Insert(StartPos, "")
                    obj.Items.Item(StartPos).Text = _TempReader.Item(Desc).ToString
                    obj.Items.Item(StartPos).Value = _TempReader.Item(Code).ToString
                End While
                If obj.Items.Item(0).Text.Trim = "" Then obj.Items.RemoveAt(0)
            End If
            obj.Visible = _TempReader.HasRows
            _TempReader.Close()
            _TempCmd.Dispose()


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
            Dim _mSqlCommand As SqlCommand = New SqlCommand(getquery, cGlobalConnections._pSqlCxn_TOIMS)
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

            Dim _mSqlComman As SqlCommand = New SqlCommand(getquery, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(getquery, cGlobalConnections._pSqlCxn_TOIMS)

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