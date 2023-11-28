



#Region "Import"

Imports System.Data.SqlClient
'Imports cReturnDataType

#End Region

Public Class cDalGetCertification

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

    Private _mPackageList As String
    Private _mIndGrpCOA As String
    Private _mIndGrp As String

#End Region

#Region "Property Field"

    Public Property _pPackageList As String
        Get
            Return _mPackageList
        End Get
        Set(value As String)
            _mPackageList = value
        End Set
    End Property
    Public Property _pIndGrpCOA As String
        Get
            Return _mIndGrpCOA
        End Get
        Set(value As String)
            _mIndGrpCOA = value
        End Set
    End Property

    Public Property _pIndGrp As String
        Get
            Return _mIndGrp
        End Get
        Set(value As String)
            _mIndGrp = value
        End Set
    End Property
#End Region

#Region "Routine Command"

    Public Sub _pSubSelectCategory()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------   
            _nQuery = "SELECT * from [GroupFeesM]"

            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectSpecific()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------   
            _nQuery = "SELECT [Description],([GroupCd] +'_'+ [AcctNo] +'_'+[Description] +'_'+cast([Fee] as varchar)) as GroupCd_AcctNo_Description_Fee FROM [GroupFeesS] where [Description] <> '' "

            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    

#End Region

#Region "Routine"



#End Region

End Class
