Imports System.Data.SqlClient

Public Class cAdditionalFees


#Region "Variables Data"

    Private Shared _mSqlCon As SqlConnection
    Private Shared _mQuery As String = Nothing
    Private Shared _mSqlCommand As SqlCommand
    Private Shared _mDataTable As DataTable
    Private Shared _mSqlDataReader As SqlDataReader

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

    Public Shared Function TotalAdditionalFee() As Double
        TotalAdditionalFee = 0.0
        _mDataTable = New DataTable
        Try
            Dim _Query As String = "Select  SUM(isnull(Fee,0)) TotalAdditionalFee from AdditionalFees"
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nDataTable As New DataTable
            _nDataTable = _mDataTable

            If _nDataTable.Rows.Count > 0 Then
                Return _nDataTable.Rows(0).Item("TotalAdditionalFee")

            End If

        Catch ex As Exception
            TotalAdditionalFee = 0
        End Try



    End Function


    Public Shared Function GetComputerFee() As Double
        GetComputerFee = 0
        Try
            _mDataTable = New DataTable
            Dim _Query As String = "Select  CONVERT(varchar, CAST( SUM(Isnull(CompFee,0)) AS money), 1)  CompFee from LGUPROFILE where CompFee_sw = 1 "
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_RPTAS)
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nDataTable As New DataTable
            _nDataTable = _mDataTable

            If _nDataTable.Rows.Count > 0 Then
                Dim _nCompFee As Double = _nDataTable.Rows(0).Item("CompFee").ToString.Replace(",", "")
                Return _nCompFee
            End If

        Catch ex As Exception
            Return 0
        End Try

    End Function

    Public Shared Function AdditionalFees() As DataTable

        _mDataTable = New DataTable
        Try
            Dim _Query As String = "Select * from AdditionalFees"
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception
        End Try
        Return _mDataTable

    End Function


    Public Shared Function Str_AdditionalFees() As String
        Str_AdditionalFees = ""
        Try

            Dim _nDataTable As New DataTable

            _nDataTable = AdditionalFees()

            Dim sb = New System.Text.StringBuilder()

            If _nDataTable.Rows.Count > 0 Then

                sb.Append(" <b> Additional Fee    <br /> ")


                Dim x As Integer = 0
                For Each i In _nDataTable.Rows
                    Dim Desc As String = _nDataTable.Rows(x).Item("Description").ToString


                    ' Convert string to double
                    Dim doubleValue As Double = Double.Parse(IIf(_nDataTable.Rows(x).Item("Fee").ToString = Nothing, "0.00", _nDataTable.Rows(x).Item("Fee").ToString))
                    ' Format the double value to two decimal places
                    Dim Fee As String = doubleValue.ToString("0.00")


                    sb.Append(" " & Desc & "       :      " & Fee & "  <br /> ")
                    x = x + 1
                Next

                sb.Append("<br />")

                Return sb.ToString

            End If


        Catch ex As Exception

        End Try

    End Function


    Public Shared Function Str_ComputerFee() As String
        Str_ComputerFee = ""
        Try
            Dim sb = New System.Text.StringBuilder()

            If GetComputerFee() > 0 Then


                Dim Fee As String = GetComputerFee.ToString("0.00")

                sb.Append(" <b> Additional Fee    <br /> ")
                sb.Append("  Computerization Fee       :      " & Fee & "  <br /> ")
                Return sb.ToString
            Else
                Return ""
            End If



         


        Catch ex As Exception
            Return ""
        End Try

    End Function



End Class
