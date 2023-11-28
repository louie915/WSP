Imports System.Data.SqlClient

Public Class CDalGenPaymentBusline
#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Public Shared _mSqllocalcon As SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mQuery As String = Nothing
    Private _mSqlDataReader As SqlDataReader
    Private _mDataTable As DataTable
    Private Shared _mQtr As String
    Private _mLocServer As String
    Private _mLocDB As String
#End Region
#Region "Properties Data"
    Public Property _pSqlCon As SqlConnection
        Get
            Return _mSqlCon
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property

    Public Property _pSqlCmd As SqlCommand
        Get
            Return _mSqlCmd
        End Get
        Set(value As SqlCommand)
            _mSqlCmd = value
        End Set
    End Property

    Public Property _pQuery As String
        Get
            Return _mQuery
        End Get
        Set(value As String)
            _mQuery = value
        End Set
    End Property

    Public Property _pLocServer As String
        Get
            Return _mLocServer
        End Get
        Set(value As String)
            _mLocServer = value
        End Set
    End Property
    Public Property _pLocDB As String
        Get
            Return _mLocDB
        End Get
        Set(value As String)
            _mLocDB = value
        End Set
    End Property

    Shared Property _pQtr As String
        Get
            Return _mQtr
        End Get
        Set(value As String)
            _mQtr = value
        End Set
    End Property
    Public Property _pSqlDataReader As SqlDataReader
        Get
            Return _mSqlDataReader
        End Get
        Set(value As SqlDataReader)
            _mSqlDataReader = value
        End Set
    End Property

    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_pSqlCmd)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

    '        DECLARE	@return_value int

    'EXEC	@return_value = [dbo].[SP_GETPAYMENTBUSLINE]
    '		@ACCTNO = N'1-00084',
    '		@FORYEAR = N'2020',
    '		@BP_SERVERDB = N'TEXAS\MSSQL2014',
    '		@BP_LOCALDB = N'BPLTAS_SANJUAN_WEB',
    '		@TEMPTBL = N'spidctaxpayer1@gmail_com_SP_GETPAYMENTBUSLINE'

    'SELECT	'Return Value' = @return_value
    Public Sub _pGeneratepaymentBusline(acctno, foryear, BP_SERVERDB, BP_LOCALDB, TEMPTBL)
        Try
            Dim _nQuery As String = Nothing
            Dim where As String = Nothing

            _nQuery = "" &
                "DECLARE @return_value int " &
                " exec  @return_value = [dbo].[SP_GETPAYMENTBUSLINE] " &
                " @ACCTNO = N'" & acctno & "'," &
                " @FORYEAR = N'" & foryear & "'," &
                " @BP_SERVERDB = N'" & BP_SERVERDB & "'," &
                " @BP_LOCALDB = N'" & BP_LOCALDB & "'," &
                " @TEMPTBL = N'" & TEMPTBL & "_SP_GETPAYMENTBUSLINE'" &
              " SELECT	'Return Value' = @return_value "


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pGetPenalty(acctno, foryear, BP_SERVERDB, BP_LOCALDB, TEMPTBL, Month, Qtr, SUBDATE)
        Try
            Dim _nQuery As String = Nothing
            Dim where As String = Nothing
            Dim QtrPay As String = Nothing
            Dim Buscode As String = Nothing



            _nQuery = ("Select BusCode from [" & TEMPTBL & "_SP_GETPAYMENTBUSLINE] ")
            Dim sqlcmd As New SqlCommand(_nQuery, _mSqlCon)
            Dim SqlDtr As SqlDataReader = sqlcmd.ExecuteReader
            _nQuery = ""
            While SqlDtr.Read
                Buscode = SqlDtr.Item("BusCode")
                If Buscode <> "" Then
                    _nQuery = "" &
                 "DECLARE @return_value int " &
                 " exec  @return_value = [dbo].[SP_GETPAYMENTBUSLINE_GETPENALTY] " &
                 " @ACCTNO = N'" & acctno & "'," &
                 " @FORYEAR = N'" & foryear & "'," &
                 " @BusCode = N'" & Buscode & "'," &
                 " @Month = N'" & Month & "'," &
                 " @BP_SERVERDB = N'" & BP_SERVERDB & "'," &
                 " @BP_LOCALDB = N'" & BP_LOCALDB & "'," &
                  "@QTR = N'" & Qtr & "'," &
                       "@DATE = N'" & SUBDATE & "'," &
                 " @TEMPTBL = N'" & TEMPTBL & "_SP_GETPAYMENTBUSLINE'" &
               " SELECT	'Return Value' = @return_value "


                    Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

                    '----------------------------------
                    _nSqlCommand.ExecuteNonQuery()
                    _nSqlCommand.Dispose()
                End If
            End While
            SqlDtr.Dispose()


            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _GetApplBusinessPermitDetail()
        Dim _nSubDate As String = FormatDateTime(Now, DateFormat.ShortDate)
        Try

            _mSqlCmd = New SqlCommand(" IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME='" & cSessionUser._pUserID & "_SP_GETPAYMENTBUSLINE') DROP TABLE  [" & cSessionUser._pUserID & "_SP_GETPAYMENTBUSLINE]" &
                                       "; SELECT TOP 0 * INTO  [" & cSessionUser._pUserID & "_SP_GETPAYMENTBUSLINE] FROM PAYMENT ", _mSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader
            _mSqlCmd.Dispose()
            _mSqlDataReader.Dispose()


            Dim _nNEWSW As String = Nothing
            Dim _nHasRow As String = Nothing
            _mSqlCmd = New SqlCommand("SELECT ISNULL(NEWSW,0) NEWSW FROM [" & _pLocServer & "].[" & _pLocDB & "].dbo.BUSLINE " &
                                        " WHERE ACCTNO='" & cSessionLoader._pAccountNo & "' and isnull(newsw,0)=1 AND Foryear=Year(GetDate()) AND STATCODE<>'C'", _mSqllocalCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader


            If _mSqlDataReader.HasRows Then
                _nHasRow = "1"
            Else
                _nHasRow = "0"
            End If

            _mSqlCmd.Dispose()
            _mSqlDataReader.Dispose()

            If _nHasRow = "1" Then
                _pGeneratepaymentBusline(cSessionLoader._pAccountNo, Year(_nSubDate), _pLocServer, _pLocDB, cSessionUser._pUserID)

            Else




                _mSqlCmd = New SqlCommand("INSERT INTO   [" & cSessionUser._pUserID & "_SP_GETPAYMENTBUSLINE]" &
                                          " SELECT * FROM [temp_" & cCookieUser._pUserID.Replace(".", "") & "]  WHERE ACCTNO='" & cSessionLoader._pAccountNo & "' AND Foryear=Year(GetDate())", _mSqlCon)
                _mSqlDataReader = _mSqlCmd.ExecuteReader
                _mSqlCmd.Dispose()
                _mSqlDataReader.Dispose()

            End If


        Catch ex As Exception

        End Try
    End Sub
End Class
