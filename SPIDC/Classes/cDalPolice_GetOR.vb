Imports System.Data.SqlClient
Public Class cDalPolice_GetOR


#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataSet As DataSet
    Private _mSqlDataReader As SqlDataReader
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
    Public ReadOnly Property _pDataSet() As DataSet
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataSet = New DataSet
                _nSqlDataAdapter.Fill(_mDataSet)

                Return _mDataSet
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

#Region "Routine Command"

    Public Sub _pSubSelect()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nDBname As String = "[TOIMS].[dbo]"

            '----------------------------------    
            _nQuery = "  Select distinct " _
                & "gen_or.Setup,gen_or.OR_No,gen_or.Payor,gen_or.Address,gen_or.[user],Gen_Extn.Main_Code,Gen_Extn.Ancestor,Gen_Extn.Acctno,OR_Date,(select description from coa where acctno=Gen_Extn.acctno)description " _
                & "from " _
                & _nDBname & ".gen_or inner join " & _nDBname & ".Gen_Extn on " & _nDBname & ".Gen_Extn.Setup=Gen_Or.Setup where " _
                & "ACCTNo IN (Select ACCTNo from coa where description like '%police clearance%')"



            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region



End Class
