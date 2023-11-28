



#Region "Import"

Imports System.Data.SqlClient
'Imports cReturnDataType

#End Region

Public Class cDalRPTIMS_CERTGetCertification

#Region "Variable Data"

    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataSet As DataSet
    Private _mSqlDataReader As SqlDataReader

#End Region

#Region "Property Data"

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

    Public ReadOnly Property _pDataSet() As DataSet
        Get
            Try
                '----------------------------------
                'Bakla po ako Sincerely Tom Lugares
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataSet = New DataSet
                _nSqlDataAdapter.Fill(_mDataSet)
                Return _mDataSet
                '----------------------------------
                'Bakla po ako Sincerely Tom Lugares
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                'Bakla po ako Sincerely Tom Lugares

                _mSqlDataReader = _mSqlCommand.ExecuteReader
                Return _mSqlDataReader
                '----------------------------------
                'Bakla po ako Sincerely Tom Lugares
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Variable Field"

    Private _mCERTCODE As String
    Private _mCERTDESC As String

#End Region

#Region "Property Field"

    Public Property _pCERTCODE As String
        Get
            Return _mCERTCODE
        End Get
        Set(value As String)
            _mCERTCODE = value
        End Set
    End Property
    Public Property _pCERTDESC As String
        Get
            Return _mCERTDESC
        End Get
        Set(value As String)
            _mCERTDESC = value
        End Set
    End Property
#End Region

#Region "Routine Command"

    Public Sub _pSubSelect()
        Try
            '----------------------------------
            'Bakla po ako Sincerely Tom Lugares
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------   
            'Bakla po ako Sincerely Tom Lugares

            _nQuery = "SELECT CERTCODE,CERTDESC FROM LGL_CERT2 UNION SELECT CERTCODE,CERTDESC FROM LGL_CERTCUSTOM"

            '----------------------------------
            'Bakla po ako Sincerely Tom Lugares
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            '----------------------------------
            'Bakla po ako Sincerely Tom Lugares
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routine"



#End Region

End Class
