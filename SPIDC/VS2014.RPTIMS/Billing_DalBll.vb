
#Region "Imports"

Imports System.IO

#End Region


Partial Public Class RPTIMSAssessmentBilling

    Private Property _oTextBoxCellnoGlobe As Object

    Private Sub _mSubDataBindApplicationAddress()
        Try
            '----------------------------------
            Dim _nGridView As New GridView
            _nGridView = _oGridViewBillingTemp
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

            '_nClass._pIDNo = "20150806000001"

            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            Dim i As New Integer

            Try


                '----------------------------------
                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()

                ElseIf _nGridView.Rows(0).Cells(0).Text = "No Data Found..." Then
                    _mSubShowBlankApplicationTDN()

                Else
                    _mSubShowBlankApplicationTDN()

                End If




                '_mSubGetApplicationAddress()
                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Sub detailsGridView_RowDataBound(ByVal sender As Object, _
      ByVal e As GridViewRowEventArgs)
        Dim priceTotal As Decimal = 0
        Dim quantityTotal As Integer = 0
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' add the UnitPrice and QuantityTotal to the running total variables
            priceTotal += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, _
              "UnitPrice"))
            quantityTotal += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, _
              "Quantity"))
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Text = "Totals:"
            ' for the Footer, display the running totals
            e.Row.Cells(1).Text = priceTotal.ToString("c")
            e.Row.Cells(2).Text = quantityTotal.ToString("d")

            e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            e.Row.Font.Bold = True
        End If
    End Sub

    Private Sub _msubGetServerDate()
        Dim _nclass As New cDalPDSRPTAS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        ''_nclass._pSubGetSpecificRecord_getid().
        _nclass._pSubgetServerDate()

        Dim _nDataTable As New DataTable
        _nDataTable = _nclass._pDataTable

        Try
            '----------------------------------
            If _nDataTable.Rows.Count > 0 Then

                _nclass._mctr_no = _nDataTable.Rows("0").Item("ServerDateTime").ToString
                cPageSession_Billing_EntryView._pOrigSrvDateValue = _nclass._mctr_no
            Else
                _mSubShowBlankApplicationProcess()

            End If


            '_mSubGetApplicationAddress()
            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub


    'Private Sub _mSubDataBindSearch(xIsPostback As Boolean)
    '    Try
    '        '----------------------------------
    '        Dim _nGridView As New GridView
    '        _nGridView = _oGridViewBillingTemp
    '        _nGridView.DataSourceID = Nothing

    '        Dim _nClass As New cDalPDSRPTAS
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
    '        '_nClass._pIDNo = "20150806000001"
    '        _nClass._pTDN = _oTextBoxTDN.Text
    '        _nClass._pUseTableTmpBill = cPageSession_Billing_EntryView._pOrigSrvDateValue



    '        If xIsPostback = True Then
    '            _nClass._pEmail = cCookieUser._pUserID.Replace(".", "")
    '            _nClass._pSubDataSearchIsPostBack()
    '        Else
    '            _nClass._pSubDataSearch()
    '        End If


    '        Dim _nDataTable As New DataTable
    '        _nDataTable = _nClass._pDataTable


    '        Try
    '            '----------------------------------
    '            If _nDataTable.Rows.Count > 0 Then
    '                _nGridView.DataSource = _nDataTable
    '                _nGridView.DataBind()


    '            Else
    '                _mSubShowBlankApplicationProcess()

    '            End If


    '            '_mSubGetApplicationAddress()
    '            '----------------------------------
    '        Catch ex As Exception

    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub _mSubShowBlankApplicationTDN()
        Try
            '----------------------------------
            Dim _nGridView As New GridView
            _nGridView = _oGridViewRPT
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pTDN = "SPIDC_SAMPLE"
            '----------------------------------

            _nClass._pSubfilter()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable


            If _nDataTable.Rows.Count = 0 Then

                _nDataTable.Rows.Add(_nDataTable.NewRow())
                _nGridView.DataSource = _nDataTable
                _nGridView.DataBind()
                Dim TotalColumns As Integer = _nGridView.Rows(0).Cells.Count
                _nGridView.Rows(0).Cells.Clear()
                _nGridView.Rows(0).Cells.Add(New TableCell())
                _nGridView.Rows(0).Cells(0).ColumnSpan = TotalColumns
                _nGridView.Rows(0).Cells(0).Text = "No Data Found..."



            End If


        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub
    Private Sub _mSubShowBlankApplicationProcess()
        Try
            '----------------------------------
            Dim _nGridView As New GridView
            _nGridView = _oGridViewBillingTemp
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            ''   _nClass._pTDN = "SPIDC_SAMPLE"
            '----------------------------------
            _nClass._pEmail = cCookieUser._pUserID.Replace(".", "")
            _nClass._pSubDataSearchIsPostBack()


            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            If _nDataTable.Rows.Count = 0 Then

                _nDataTable.Rows.Add(_nDataTable.NewRow())
                _nGridView.DataSource = _nDataTable
                _nGridView.DataBind()

                Dim TotalColumns As Integer = _nGridView.Rows(0).Cells.Count
                _nGridView.Rows(0).Cells.Clear()
                _nGridView.Rows(0).Cells.Add(New TableCell())
                _nGridView.Rows(0).Cells(0).ColumnSpan = TotalColumns
                _nGridView.Rows(0).Cells(0).Text = "No Data Found..."

            End If

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub _mSubGetApplicationAddress()
    '    Try
    '        '----------------------------------
    '        Dim _nClass As New cDalPDSAddress
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_HRIMS

    '        _nClass._pIDNo = cCookieUser._pIDNo

    '        _nClass._pSubGetSpecificRecordAddress()




    '        _nClass = Nothing

    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Private Sub _mSubSubmitAddress()
    '    Try
    '        '----------------------------------
    '        Dim _nClass As New cDalPDSAddress
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_HRIMS

    '        '_nClass._pIDNo = ClassSessionUser._pIDNo

    '        _nClass._pIDNo = cCookieUser._pIDNo
    '        '_nClass._pRegionCode = _oLabelRegionCode.Text




    '        '_nClass._pSubSelectTrapIfExist()

    '        Select Case True

    '            Case cPageSession_Billing_EntryView._pAddMode

    '                'Dim _nClass As New ClassDALApplicationAddress
    '                '_nClass._pRegionCode = _oLabelRegionCode.Text



    '                _nClass._pSubInsert()

    '                _nClass = Nothing


    '            Case cPageSession_Billing_EntryView._pEditMode




    '                _nClass._pOrigIDNo = cCookieUser._pIDNo
    '                _nClass._pOrigRegionCode = cPageSession_Billing_EntryView._pOrigRegionCode



    '                _nClass._pSubUpdate()

    '                _nClass = Nothing


    '        End Select


    '        _mSubDataBindApplicationAddress()


    '        cPageSession_Billing_EntryView._pAddMode = False
    '        cPageSession_Billing_EntryView._pEditMode = False

    '        'cPageSession_ApplicationJob_EntryView._pSubSessionClear()

    '        _nClass = Nothing

    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub _mSubDataBindfilter()
    '    Try
    '        '----------------------------------
    '        Dim _nGridView As New GridView
    '        _nGridView = _oGridViewSelect
    '        _nGridView.DataSourceID = Nothing

    '        Dim _nClass As New cDalPDSRPTAS
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

    '        If _oTextBoxSearch.Text = "" Then
    '            _mSubShowBlankApplicationTDN()
    '        Else
    '            _nClass._pTDN = _oTextBoxSearch.Text
    '        End If

    '        _nClass._pEmail = cCookieUser._pUserID

    '        Select Case DropDownListFieldsname.Text
    '            Case "PIN"
    '                _nClass._pFieldsWhere = "R.PIN"
    '            Case "TDN"
    '                _nClass._pFieldsWhere = "R.TDN"
    '            Case "OWNER NO."
    '                _nClass._pFieldsWhere = "O.NAME"


    '        End Select

    '        'DropDownListFieldsname.
    '        _nClass._pSubfilter()

    '        Dim _nDataTable As New DataTable
    '        _nDataTable = _nClass._pDataTable
    '        _psDtMainLoan = _nClass._pDataTable

    '        Try
    '            '----------------------------------
    '            If _nDataTable.Rows.Count > 0 Then
    '                _nGridView.DataSource = _nDataTable
    '                _nGridView.DataBind()

    '            Else
    '                _mSubShowBlankApplicationTDN()

    '            End If


    '            '_mSubGetApplicationAddress()
    '            '----------------------------------
    '        Catch ex As Exception

    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Function _mSubUIPW(cndtn As String, ConDB As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPW(ConDB)

                If cndtn = "UI" Then
                    Return ._pdbUI
                ElseIf cndtn = "PW" Then
                    Return ._pdbPW
                Else
                    Return Nothing
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function _mSubUIPWWEB(cndtn As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPWWEB()

                If cndtn = "UI" Then
                    Return ._pdbUI
                ElseIf cndtn = "PW" Then
                    Return ._pdbPW
                Else
                    Return Nothing
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Function _mSubREGION() As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

                ._pSubREGION()

                Return ._pRegion
            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    'Private Sub _mSubLoadBrHlp()
    '    Try
    '        '----------------------------------
    '        Dim _nGridView As New GridView
    '        _nGridView = _oGridViewSelect
    '        _nGridView.DataSourceID = Nothing

    '        Dim _nClass As New cDalPDSRPTAS
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
    '        usertmp = cCookieUser._pUserID.Replace(".", "")
    '        _nClass._pEmail = usertmp
    '        _nClass._pTDN = _oTextBoxSearch.Text
    '        _nClass._pSubBrHlp()

    '        Dim _nDataTable As New DataTable
    '        _nDataTable = _nClass._pDataTable
    '        _psDtMainLoan = _nClass._pDataTable

    '        Try
    '            '----------------------------------
    '            If _nDataTable.Rows.Count > 0 Then
    '                NoofcountTDN = _nDataTable.Rows.Count
    '            Else
    '                _nClass._pTDN = _oTextBoxSearch.Text()

    '            End If


    '            '_mSubGetApplicationAddress()
    '            '----------------------------------
    '        Catch ex As Exception

    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub _mSubLoadSvrDateValue()
        Try
            '----------------------------------

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T

            _nClass._pSubgetServerDate()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            _psDtMainLoan = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.Rows.Count > 0 Then
                    NoofcountTDN = _nDataTable.Rows.Count
                Else
                    _mSubShowBlankApplicationTDN()

                End If


                '_mSubGetApplicationAddress()
                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    'Private Sub _mSubLoadImages()
    '    Try
    '        '----------------------------------
    '        Dim _nUrl As String = cUrlResource._pUrl

    '        _oImage.ImageUrl = _nUrl & "/images/gif/loading.02.gif"

    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
