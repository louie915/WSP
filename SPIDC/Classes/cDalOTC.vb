Imports System.Data.SqlClient

Public Class cDalOTC

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCmd As SqlCommand
    Private _mSqlDataReader As SqlDataReader
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

    Public Property _pQuery As String
        Get
            Return _mQuery
        End Get
        Set(value As String)
            _mQuery = value
        End Set
    End Property

    Public ReadOnly Property _pSqlCmd As SqlCommand
        Get
            Return _mSqlCmd
        End Get
    End Property

    Public Property _pSqlDataReader As SqlDataReader
        Get
            Return _mSqlDataReader
        End Get
        Set(value As SqlDataReader)
            _mSqlDataReader = value
        End Set
    End Property
#End Region

#Region "Variables Field"
    Private _mPaymentChannel As String
    Private _mTransactionNo As String
    Private _mAmount As String
    Private _mORNumber As String
#End Region

#Region "Properties Field"
    Public Property _pPaymentChannel As String
        Get
            Return _mPaymentChannel
        End Get
        Set(value As String)
            _mPaymentChannel = value
        End Set
    End Property

    Public Property _pTransactionNo As String
        Get
            Return _mTransactionNo
        End Get
        Set(value As String)
            _mTransactionNo = value
        End Set
    End Property

    Public Property _pAmount As String
        Get
            Return _mAmount
        End Get
        Set(value As String)
            _mAmount = value
        End Set
    End Property

    Public Property _pOrNumber As String
        Get
            Return _mORNumber
        End Get
        Set(value As String)
            _mORNumber = value
        End Set
    End Property
#End Region

    Public Sub saveOTC()
        Dim _nQuery As String
        'Dim em As String = "theglitch0710@gmail.com"
        'Dim acct As String = "200316-00002"

        _nQuery = "INSERT INTO OnlinePaymentRefno" & _
            " (TXNREFNO, EMAILADDR, PAYMENTCHANNEL, GateWayRefNo, TotAmount, TRXDATE, acctno, strDate, status, type, rawAmount)" & _
            " VALUES" & _
            " ('" & _mTransactionNo & "','" & cSessionUser._pUserID & "','" & _mPaymentChannel & "','" & _mORNumber & "','" & _mAmount & "','" & Format(Date.Now, "MM/dd/yyyy hh:mm:ss") & "','" & cSessionLoader._pAccountNo & "','" & Format(Date.Now, "yyMMdd") & "','For Verification','RPT','" & _mAmount & "')"

        _mQuery = _nQuery

        _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
        _mSqlCmd.ExecuteNonQuery()
        _mSqlCmd.Dispose()
    End Sub

    Public Function checkTransOTC() As Boolean
        Dim _nQuery As String
        Dim res As Boolean

        _nQuery = "SELECT TXNREFNO" & _
            " FROM OnlinePaymentRefNo" & _
            " WHERE TXNREFNO = '" & _mTransactionNo & "'"

        _mQuery = _nQuery
        _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
        _mSqlDataReader = _mSqlCmd.ExecuteReader()

        If _mSqlDataReader.HasRows = True Then
            res = True
        Else
            res = False
        End If

        _mSqlCmd.Dispose()
        _mSqlDataReader.Close()

        Return res
    End Function

    Public Sub populateSelect(ByVal combo As HtmlSelect)
        Dim _nQuery As String = Nothing

        _nQuery = "SELECT * FROM OnlinePaymentRefNo WHERE via='OTC'" & _
            " AND EMAILADDR = '" & cSessionUser._pUserID & "'"

        _pQuery = _nQuery

        _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
        _mSqlDataReader = _mSqlCmd.ExecuteReader

        combo.Items.Clear()

        Do Until _mSqlDataReader.Read = False
            combo.Items.Add(_mSqlDataReader("TXNREFNO"))
        Loop

        _mSqlDataReader.Close()
        _mSqlCmd.Dispose()
    End Sub

End Class
