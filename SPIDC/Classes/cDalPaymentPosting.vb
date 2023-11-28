#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext
Imports System.Security.Cryptography
Imports System.Net
Imports RestSharp
Imports System.Web.Script.Serialization
Imports RPTIMS_DLL
Imports System.Threading.Tasks


#End Region
Public Class cDalPaymentPosting

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Public _Dataset As DataSet
    Public Taxpayer_Email As String
#End Region
#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region
    Public Function Get_eORno(ByVal acctno As String, ByVal Taxtype As String) As String
        Dim result As String = Nothing
        Try
            Dim _nQuery As String = Nothing

            If Taxtype = "RPT" Then
                _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
                _nQuery = "select maxORNO from OnlinePaymentRefno where acctno='" & acctno & "'"
            ElseIf Taxtype = "BP" Then
                _mSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                _nQuery = ""
            End If


            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    result = _mSqlDataReader("maxORNO")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
        End Try
        Return result
    End Function
    Public Sub Print_eOR(ByVal eORNO As String, Optional ByRef err As String = Nothing, Optional ByRef qry As String = Nothing, Optional ByVal isTaxpayer As Boolean = False)
        Try
            Dim _class As New eOR
            If eOR.isEORSaved(eORNO, err) = False Then
                If String.IsNullOrEmpty(err) = False Then
                    'show err
                Else
                    err = Nothing
                    'Dim rand As New Random()
                    'Task.Delay((rand.Next(1, 3)) * 1000).Wait()

             
                    eOR.Insert_eOR(eORNO, err, qry)
                    If String.IsNullOrEmpty(err) = False Then
                        err += ";Insert_eOR:" & err
                        Exit Sub
                    End If

                    eOR.Insert_eOR_EXTN(Process.TransactionType, eORNO, Process.SRS, Process.SEQ, Process.ACCTNO, err)
                    If String.IsNullOrEmpty(err) = False Then
                        err += ";Insert_eOR_EXTN:" & err
                        Exit Sub
                    End If

                    eOR.Update_eOR(eORNO, err)
                    If String.IsNullOrEmpty(err) = False Then
                        err += ";Update_eOR:" & err
                        Exit Sub
                    End If
                End If
            End If

        

        Catch ex As Exception

        End Try
    End Sub
    Public Function get_SRS() As String
        Dim result As String = Nothing
        Try
            Dim _nQuery As String = Nothing
            _mSqlCon = cGlobalConnections._pSqlCxn_TOIMS
            _nQuery = "select top 1 srs from gen_or where Form_Use='eor' and year(OR_Date)=year(GETDATE())"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    result = _mSqlDataReader("srs")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception

        End Try
        Return result
    End Function
#Region "RPT POSTING"
    Sub do_process(ByVal AssessmentNo As String, ByVal PaymentRefNo As String, ByVal Gateway As String, ByVal or_no As String, ByVal series As String, ByVal bookno As String, ByVal _User As String, Optional ByRef err As String = Nothing, Optional ByRef strCheck As String = Nothing)
        Try
            Dim _nclass As New cDalPDSRPTAS
            Dim _nclass2 As New cDalGetDate
            _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            '    _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            _nclass._pSubGetSpecificRecord_getid()
            _msubGetServerDate()
            _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue

            Dim cls_rptas As New clsRPT
            'set TOIMS CONNECTION
            cls_rptas.TOIMS_Server = cGlobalConnections._pSqlCxn_TOIMS.DataSource
            cls_rptas.TOIMS_xDataBase = cGlobalConnections._pSqlCxn_TOIMS.Database
            cls_rptas.TOIMS_xUID = _mSubUIPW("UI", "TOIMS")
            cls_rptas.TOIMS_xPW = _mSubUIPWWEB("PW")
            'SET OAIMS CONNECTION
            cls_rptas.RPTASOAIMS_xDataBase = cGlobalConnections._pSqlCxn_OAIMS.Database

            cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource
            cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource
            cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database
            cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database

            cls_rptas.RPTASTEMP_xDataBase = cGlobalConnections._pSqlCxn_RPTAS_T.Database

            cls_rptas.Quater_set = "4"
            cls_rptas.RPTAS_ForYear = _nclass2._GetYear

            cls_rptas.RPTAS_xUID = _mSubUIPW("UI", "RPTAS")
            cls_rptas.RPTASWEB_xUID = _mSubUIPWWEB("UI")
            cls_rptas.RPTAS_xPW = _mSubUIPW("PW", "RPTAS")
            cls_rptas.RPTASWEB_xPW = _mSubUIPWWEB("PW")
            cls_rptas.Region_TMP = _mSubREGION()
            Taxpayer_Email = Taxpayer_Email.Replace(".", "")
            Taxpayer_Email = Taxpayer_Email.Replace("-", "")
            cls_rptas.User_TMP = Taxpayer_Email 'remove the "." 

            cls_rptas.MultiTDN = 1
            ' cls_rptas.Tdn = ""
            cls_rptas.bill_date = CDate(_nclass2._GetDate_MMddyyyy())

            '   cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
            cls_rptas.SvrDateValue = _nclass._mctr_no
         
            strCheck = ";strCheck:" _
              & ";TOIMS_Server:" & cGlobalConnections._pSqlCxn_TOIMS.DataSource _
              & ";TOIMS_xDataBase:" & cGlobalConnections._pSqlCxn_TOIMS.Database _
              & ";TOIMS_xUID:" & _mSubUIPW("UI", "TOIMS") _
              & ";TOIMS_xPW:" & _mSubUIPWWEB("PW") _
              & ";RPTAS_SERVER:" & cGlobalConnections._pSqlCxn_RPTAS.DataSource _
              & ";RPTAS_xDataBase:" & cGlobalConnections._pSqlCxn_RPTAS.Database _
              & ";RPTAS_xUID:" & _mSubUIPW("UI", "RPTAS") _
              & ";RPTAS_xPW:" & _mSubUIPW("PW", "RPTAS") _
              & ";RPTASWEB_SERVER:" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource _
              & ";RPTASWEB_xDataBase:" & cGlobalConnections._pSqlCxn_RPTIMS.Database _
              & ";RPTASTEMP_xDataBase:" & cGlobalConnections._pSqlCxn_RPTAS_T.Database _
              & ";RPTASOAIMS_xDataBase:" & cGlobalConnections._pSqlCxn_OAIMS.Database _
              & ";CR:" & cGlobalConnections._pSqlCxn_CR.Database _
              & ";Region_TMP:" & _mSubREGION()

            cls_rptas.TOIMSPOSTING(AssessmentNo, PaymentRefNo, Gateway, or_no, series, bookno, _User)

        Catch ex As Exception
            err = ex.Message
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
#End Region


End Class
