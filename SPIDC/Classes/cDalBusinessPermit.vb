Imports System.Data.SqlClient

Public Class cDalBusinessPermit
    Inherits System.Web.UI.Page





#Region "Variables Data"
    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTableForReview As DataTable
    Public Shared _mDataTableForApproval As DataTable
    Public Shared _mDataTableApproved As DataTable
    Public Shared _mDataTablePaymentDetails As DataTable
    Public Shared _mDataTableAttachments As DataTable
    Private _mSqlDataReader As SqlDataReader
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String

    Public Shared _mEmail As String
    Public Shared _mDate As String
    Public Shared _mTime As String
    Public Shared _mCheckBoxValue As String
    Public Shared _mTransactionNumber As String
    Public Shared _mTransactionType As String
    Public Shared _mPaymentChannel As String
    Public Shared _mOwner As String
    Public Shared _mAmountPaid As String
    Public Shared _mCountSPIDCPAY As String
    Public Shared _mCountDBP As String
    Public Shared _mCountLandBank As String
    Public Shared _mCountPostedLandBank As String
    Public Shared _mCountPostedDBP As String
    Public Shared _mCountALL As String
    Public Shared _mCountPostedSPIDCPay As String
    Public Shared _mTotalSPIDCPAY As String
    Public Shared _mTotalPostedSPIDCPAY As String
    Public Shared _mTotalPostedDBP As String
    Public Shared _mTotalDBP As String
    Public Shared _mTotalLandBank As String
    Public Shared _mTotalPostedLandBank As String
    Public Shared _mTotalAll As String
    Public Shared _mstrdt As String


#End Region

#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlConnection = value
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
    Public ReadOnly Property _pDataTableForReview() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTableForReview = New DataTable
                _nSqlDataAdapter.Fill(_mDataTableForReview)

                Return _mDataTableForReview
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pDataTableForApproval() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTableForApproval = New DataTable
                _nSqlDataAdapter.Fill(_mDataTableForApproval)

                Return _mDataTableForApproval
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pDataTableApproved() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTableApproved = New DataTable
                _nSqlDataAdapter.Fill(_mDataTableApproved)

                Return _mDataTableApproved
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
                _mSqlCommand.Dispose()
                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Variables Field"


#End Region

#Region "Properties Field"
    Public Shared Property _pEmail() As String
        Get
            Return _mEmail
        End Get
        Set(value As String)
            _mEmail = value
        End Set
    End Property
    Public Shared Property _pDate() As String
        Get
            Return _mDate
        End Get
        Set(value As String)
            _mDate = value
        End Set
    End Property
    Public Shared Property _pTime() As String
        Get
            Return _mTime
        End Get
        Set(value As String)
            _mTime = value
        End Set
    End Property
    Public Property _pCheckBoxValue As String
        Get
            Return _mCheckBoxValue
        End Get
        Set(ByVal value As String)
            _mCheckBoxValue = value
        End Set
    End Property
    Public Property _pTransactionNumber As String
        Get
            Return _mTransactionNumber
        End Get
        Set(ByVal value As String)
            _mTransactionNumber = value
        End Set
    End Property
    Public Property _pTransactionType As String
        Get
            Return _mTransactionType
        End Get
        Set(ByVal value As String)
            _mTransactionType = value
        End Set
    End Property
    Public Property _pOwner As String
        Get
            Return _mOwner
        End Get
        Set(ByVal value As String)
            _mOwner = value
        End Set
    End Property
    Public Property _pAmountPaid As String

        Get

            Return _mAmountPaid

        End Get

        Set(ByVal value As String)

            _mAmountPaid = value

        End Set

    End Property
    Public Property _pPaymentChannel As String

        Get

            Return _mPaymentChannel

        End Get

        Set(ByVal value As String)

            _mPaymentChannel = value

        End Set

    End Property
    Public Property _pTotalSPIDCPAY As String

        Get

            Return _mTotalSPIDCPAY

        End Get

        Set(ByVal value As String)

            _mTotalSPIDCPAY = value

        End Set

    End Property

    Public Property _pTotalDBP As String

        Get

            Return _mTotalDBP

        End Get

        Set(ByVal value As String)

            _mTotalDBP = value

        End Set

    End Property
    Public Property _pTotalLandBank As String

        Get

            Return _mTotalLandBank

        End Get

        Set(ByVal value As String)

            _mTotalLandBank = value

        End Set

    End Property
    Public Property _pTotalPostedLandBank As String

        Get

            Return _mTotalPostedLandBank

        End Get

        Set(ByVal value As String)

            _mTotalPostedLandBank = value

        End Set

    End Property
    Public Property _pTotalPostedSPIDCPay As String

        Get

            Return _mTotalPostedSPIDCPay

        End Get

        Set(ByVal value As String)

            _mTotalPostedSPIDCPay = value

        End Set

    End Property

    Public Property _pTotalPostedDBP As String

        Get

            Return _mTotalPostedDBP

        End Get

        Set(ByVal value As String)

            _mTotalPostedDBP = value

        End Set

    End Property
    Public Property _pTotalAll As String

        Get

            Return _mTotalAll

        End Get

        Set(ByVal value As String)

            _mTotalAll = value

        End Set

    End Property
    Public Property _pCountSPIDCPAY As String

        Get

            Return _mCountSPIDCPAY

        End Get

        Set(ByVal value As String)

            _mCountSPIDCPAY = value

        End Set

    End Property
    Public Property _pCountPostedSPIDCPAY As String

        Get

            Return _mCountPostedSPIDCPAY

        End Get

        Set(ByVal value As String)

            _mCountPostedSPIDCPAY = value

        End Set

    End Property
    Public Property _pCountDBP As String

        Get

            Return _mCountDBP

        End Get

        Set(ByVal value As String)

            _mCountDBP = value

        End Set

    End Property
    Public Property _pCountLandBank As String

        Get

            Return _mCountLandBank

        End Get

        Set(ByVal value As String)

            _mCountLandBank = value

        End Set

    End Property
    Public Property _pCountPostedLandBank As String

        Get

            Return _mCountPostedLandBank

        End Get

        Set(ByVal value As String)

            _mCountPostedLandBank = value

        End Set

    End Property
    Public Property _pCountPostedDBP As String

        Get

            Return _mCountPostedDBP

        End Get

        Set(ByVal value As String)

            _mCountPostedDBP = value

        End Set

    End Property
    Public Property _pCountALL As String

        Get

            Return _mCountALL

        End Get

        Set(ByVal value As String)

            _mCountALL = value

        End Set

    End Property
    Public Property _pstrdt As String

        Get

            Return _mstrdt

        End Get

        Set(ByVal value As String)

            _mstrdt = value

        End Set

    End Property

#End Region
    Public Sub _pSubSelectForReview(ByVal _nFilterBy As String, ByVal _nSearchKey As String)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nYear As String = Nothing

            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader

            '_nSqlCmd = New SqlCommand("SELECT YEAR(GETDATE()) as [YearNow]", cGlobalConnections._pSqlCxn_BPLTAS)
            '_mRdr = _nSqlCmd.ExecuteReader
            '_mRdr.Read()
            'If _mRdr.HasRows Then
            '    _nYear = _mRdr.Item("YearNow").ToString
            'End If
            '_nSqlCmd.Dispose()
            '_mRdr.Dispose()

            If _nFilterBy = "OWNER" Then _nFilterBy = "isnull(OWNERNAME,'')"
            If _nFilterBy = "BIN" Then _nFilterBy = "ACCTNO"
            If _nFilterBy = "TRADE NAME" Then _nFilterBy = "COMMNAME"
            _nWhere = "WHERE " + _nFilterBy + " LIKE " + "'%" + _nSearchKey + "%'"
            If _nSearchKey = "" Then _nWhere = ""
            '----------------------------------                
            _nQuery = "select * from [VW_BPForReview] " + _nWhere
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTableForReview = New DataTable
            _nSqlDataAdapter.Fill(_mDataTableForReview)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
            _mSqlCommand.Dispose()
            _nSqlDataAdapter.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectForApproval(ByVal _nFilterBy As String, ByVal _nSearchKey As String)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nWhere2 As String = Nothing
            Dim _nYear As String = Nothing
            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader

            '_nSqlCmd = New SqlCommand("SELECT YEAR(GETDATE()) as [YearNow]", cGlobalConnections._pSqlCxn_BPLTAS)
            '_mRdr = _nSqlCmd.ExecuteReader
            '_mRdr.Read()
            'If _mRdr.HasRows Then
            '    _nYear = _mRdr.Item("YearNow").ToString
            'End If
            '_nSqlCmd.Dispose()
            '_mRdr.Dispose()

            If _nFilterBy = "OWNER" Then _nFilterBy = "OWNERNAME"
            If _nFilterBy = "BIN" Then _nFilterBy = "ACCTNO"
            If _nFilterBy = "TRADE NAME" Then _nFilterBy = "COMMNAME"
            _nWhere1 = "WHERE ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "]." & cGlobalConnections._pSqlCxn_BPLTIMS.Database & ".dbo.BUSINESSPERMIT)"
            _nWhere2 = " AND " + _nFilterBy + " LIKE " + "'%" + _nSearchKey + "%'"
            If _nSearchKey = "" Then _nWhere2 = ""
            '----------------------------------
            _nQuery = "select * from [VW_BPForApproval] " + _nWhere1 + _nWhere2
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTableForApproval = New DataTable
            _nSqlDataAdapter.Fill(_mDataTableForApproval)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
            _mSqlCommand.Dispose()
            _nSqlDataAdapter.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectApproved(ByVal _nFilterBy As String, ByVal _nSearchKey As String)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nWhere2 As String = Nothing
            Dim _nYear As String = Nothing
            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader

            _nSqlCmd = New SqlCommand("SELECT YEAR(GETDATE()) as [YearNow]", cGlobalConnections._pSqlCxn_BPLTAS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                _nYear = _mRdr.Item("YearNow").ToString
            End If
            _nSqlCmd.Dispose()
            _mRdr.Dispose()

            If _nFilterBy = "OWNER" Then _nFilterBy = "OWNERNAME"
            If _nFilterBy = "BIN" Then _nFilterBy = "ACCTNO"
            If _nFilterBy = "TRADE NAME" Then _nFilterBy = "COMMNAME"
            _nWhere1 = "WHERE ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "]." & cGlobalConnections._pSqlCxn_BPLTIMS.Database & ".dbo.BUSINESSPERMIT)"
            _nWhere2 = " AND " + _nFilterBy + " LIKE " + "'%" + _nSearchKey + "%'"
            If _nSearchKey = "" Then _nWhere2 = ""
            '----------------------------------                
            _nQuery = "select * from [VW_BPApproved] " + _nWhere1 + _nWhere2
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTableApproved = New DataTable
            _nSqlDataAdapter.Fill(_mDataTableApproved)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
            _mSqlCommand.Dispose()
            _nSqlDataAdapter.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectPaymentDetails(ByVal _nmySwitch As String, ByVal _nORNo As String, ByVal _nSRS As String, ByVal _nAcctNo As String)
        Try

            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            'Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL            

            _mStrSql = "Exec OrDetailedPayments @mySwitch ='" & _nmySwitch & "',@OrNumber ='" & _nORNo & "',@SRS ='" & _nSRS & "', @xAcctNo ='" & _nAcctNo & "'"

            _mSqlCmd = New SqlCommand(_mStrSql, _mSqlConnection)

            _mSqlCommand = New SqlCommand(_mStrSql, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mStrSql, _mSqlConnection) '_gDBCon
            _mDataTablePaymentDetails = New DataTable
            _nSqlDataAdapter.Fill(_mDataTablePaymentDetails)
            _nSqlDataAdapter.Dispose()
            _mSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAttachments(ByVal _nAcctNo As String)
        Try

            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            'Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL            

            _mStrSql = "select * from BPFile where AcctNo = '" & _nAcctNo & "'"

            _mSqlCmd = New SqlCommand(_mStrSql, _mSqlConnection)

            _mSqlCommand = New SqlCommand(_mStrSql, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mStrSql, _mSqlConnection) '_gDBCon
            _mDataTableAttachments = New DataTable
            _nSqlDataAdapter.Fill(_mDataTableAttachments)
            _nSqlDataAdapter.Dispose()
            _mSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub
End Class
