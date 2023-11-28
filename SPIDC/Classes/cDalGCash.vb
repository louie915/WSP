
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext


#End Region

Public Class cDalGCash

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mQuery As String = Nothing
    Private _mSqlDataReader As SqlDataReader
    Private _mDataTable As DataTable
#End Region

#Region "Variables Field"
    '---------For Entry---------------------
    Private _mPublicKey_XML As String
    Private _mPrivateKey_XML As String
    Private _mPublicKey_PEM As String
    Private _mPrivateKey_PEM As String
    Private _mClientId As String 'added by Archie 20220310
    Private _mClientSecret As String
    Private _mMerchantID As String
    Private _mProductCode As String
    Private _mGCASH_PublicKey_PEM As String    

#End Region

#Region "Properties Field"    
    Public Property _pPublicKey_XML As String
        Get
            Return _mPublicKey_XML
        End Get
        Set(value As String)
            _mPublicKey_XML = value
        End Set
    End Property


    Public Property _pPrivateKey_XML As String
        Get
            Return _mPrivateKey_XML
        End Get
        Set(value As String)
            _mPrivateKey_XML = value
        End Set
    End Property
    Public Property _pPrivateKey_PEM As String
        Get
            Return _mPrivateKey_PEM
        End Get
        Set(value As String)
            _mPrivateKey_PEM = value
        End Set
    End Property
    Public Property _pPublicKey_PEM As String
        Get
            Return _mPublicKey_PEM
        End Get
        Set(value As String)
            _mPublicKey_PEM = value
        End Set
    End Property
    Public Property _pClientId As String
        Get
            Return _mClientId
        End Get
        Set(value As String)
            _mClientId = value
        End Set
    End Property
    Public Property _pClientSecret As String
        Get
            Return _mClientSecret
        End Get
        Set(value As String)
            _mClientSecret = value
        End Set
    End Property
    Public Property _pMerchantID As String
        Get
            Return _mMerchantID
        End Get
        Set(value As String)
            _mMerchantID = value
        End Set
    End Property

    Public Property _pProductCode As String
        Get
            Return _mProductCode
        End Get
        Set(value As String)
            _mProductCode = value
        End Set
    End Property
    Public Property _pGCASH_PublicKey_PEM As String
        Get
            Return _mGCASH_PublicKey_PEM
        End Get
        Set(value As String)
            _mGCASH_PublicKey_PEM = value
        End Set
    End Property    
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


#Region "Properties Field Original"

#End Region

#Region "Routine Command"


    Public Sub loadcredentials()
        Try
            Dim _nQuery As String

            _nQuery = "SELECT [PublicKey_XML],[PrivateKey_XML],[PublicKey_PEM],[PrivateKey_PEM],[clientId],[clientSecret],[merchantID],[productCode],[GCASH_PublicKey_PEM] FROM GCASH_Credentials"

            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader()

            Do Until _mSqlDataReader.Read = False
                _pPublicKey_XML = _mSqlDataReader.Item(0).ToString()
                _pPrivateKey_XML = _mSqlDataReader.Item(1).ToString()
                _pPublicKey_PEM = _mSqlDataReader.Item(2).ToString()
                _pPrivateKey_PEM = _mSqlDataReader.Item(3).ToString()
                _pClientId = _mSqlDataReader.Item(4).ToString()
                _pClientSecret = _mSqlDataReader.Item(5).ToString()                
                _pMerchantID = _mSqlDataReader.Item(6).ToString()
                _pProductCode = _mSqlDataReader.Item(7).ToString()
                _pGCASH_PublicKey_PEM = _mSqlDataReader.Item(8).ToString()
            Loop

            _mSqlCmd.Dispose()
            _mSqlDataReader.Close()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Generate_ReqMsgID(ByVal SPIDCRefNo As String, ByRef ReqMsgId As String)
        Try
            Dim _nQuery As String
            _nQuery = "SELECT REPLACE(STR((select count(*) from OnlinePaymentRefno where via='GCASH'),5),' ','0')"
            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader()

            Do Until _mSqlDataReader.Read = False
                ReqMsgId = SPIDCRefNo & _mSqlDataReader.Item(0).ToString()
            Loop

            _mSqlCmd.Dispose()
            _mSqlDataReader.Close()
        Catch ex As Exception

        End Try

    End Sub

    Function Gen_MD5(ByVal strVal As String) As String
        Dim result As String = Nothing
        Try
            Dim _nQuery As String
            _nQuery = "SELECT REPLACE(STR((select count(*) from OnlinePaymentRefno where via='GCASH'),5),' ','0')"
            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader()

            Do Until _mSqlDataReader.Read = False
                result = strVal & _mSqlDataReader.Item(0).ToString()
            Loop

            _mSqlCmd.Dispose()
            _mSqlDataReader.Close()
        Catch ex As Exception

        End Try


        Return result
    End Function

#End Region



End Class










