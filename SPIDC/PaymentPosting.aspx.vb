Imports RPTIMS_DLL

Public Class PaymentPosting
    Inherits System.Web.UI.Page
    Public TDNBIN As String
    Public RPT_AssessNo As String
    Public Fee_type As String
    Dim usertmp As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Fee_type = "RPT" Then
                do_process(RPT_AssessNo)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub do_process(ByVal AssessmentNo As String)
        Dim getdate As Date
        Try
            Dim _nclass As New cDalPDSRPTAS
            Dim _nclass2 As New cDalGetDate
            _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            _nclass._pSubGetSpecificRecord_getid()
            _msubGetServerDate()
            _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue
        
            Dim cls_rptas As New clsRPT

            cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource
            cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource
            cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database
            cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database

            cls_rptas.TOIMS_Server = cGlobalConnections._pSqlCxn_TOIMS.DataSource
            cls_rptas.TOIMS_xDataBase = cGlobalConnections._pSqlCxn_TOIMS.Database
            cls_rptas.TOIMS_xUID = _mSubUIPW("UI", "TOIMS")
            cls_rptas.TOIMS_xPW = _mSubUIPWWEB("UI")

            cls_rptas.RPTAS_xUID = _mSubUIPW("UI", "RPTAS")
            cls_rptas.RPTASWEB_xUID = _mSubUIPWWEB("UI")
            cls_rptas.RPTAS_xPW = _mSubUIPW("PW", "RPTAS")
            cls_rptas.RPTASWEB_xPW = _mSubUIPWWEB("PW")
            cls_rptas.Region_TMP = _mSubREGION()
            usertmp = cSessionUser._pUserID.Replace(".", "")
            usertmp = usertmp.Replace("-", "")
            cls_rptas.User_TMP = usertmp 'remove the "." 
            cls_rptas.MultiTDN = 1
            cls_rptas.Tdn = ""
            cls_rptas.bill_date = CDate(_nclass2._GetDate_MMddyyyy())


            cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
        
            'If RadioButton1.Checked = True Then
            '    cls_rptas.Quater_set = "1"
            'End If
            'If RadioButton2.Checked = True Then
            '    cls_rptas.Quater_set = "2"
            'End If
            'If RadioButton3.Checked = True Then
            '    cls_rptas.Quater_set = "3"
            'End If
            'If RadioButton4.Checked = True Then
            '    cls_rptas.Quater_set = "4"
            'End If

            '  cls_rptas.RPTAS_ForYear = _radYear.Text

            cls_rptas.SvrDateValue = _nclass._mctr_no

            cls_rptas.LoadForm()
            '    cls_rptas.TOIMSPOSTING(AssessmentNo)

        Catch ex As Exception
         
        End Try




    End Sub

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

    Private Sub _msubGetServerDate()
        Dim _nclass As New cDalPDSRPTAS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        ''_nclass._pSubGetSpecificRecord_getid().
        _nclass._pSubGetServerDate()

        Dim _nDataTable As New DataTable
        _nDataTable = _nclass._pDataTable

        Try
            '----------------------------------
            If _nDataTable.Rows.Count > 0 Then

                _nclass._mctr_no = _nDataTable.Rows("0").Item("ServerDateTime").ToString
                cPageSession_Billing_EntryView._pOrigSrvDateValue = _nclass._mctr_no
            Else
                ' _mSubShowBlankApplicationProcess()

            End If


            '_mSubGetApplicationAddress()
            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

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
End Class