

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext


#End Region

Public Class cDalNewCedula

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
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

#Region "Variables Field"

#End Region

#Region "Properties Field"

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"
    Sub _pSubGetBasicAmount(ByVal Type As String, ByVal Form_Use As String, ByRef Amount As Double)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT CTCSETUPCODE.Form_Use, CTCSETUPCODE.AccountCd, coa.main_code, Amount FROM CTCSETUPCODE " & _
                      " LEFT OUTER JOIN coa ON CTCSETUPCODE.AccountCd = coa.acctno " & _
                      " WHERE CTCSETUPCODE.Form_Use = '" & Form_Use & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iAmount As Integer = .GetOrdinal("Amount")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Amount = ._pReturnString(_nSqlDataReader(_iAmount))
                            Loop
                        Else
                            If Type = "Individual" Then
                                Amount = 5.0
                            ElseIf Type = "Corporation" Then
                                Amount = 500
                            End If

                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Sub _pSubGetGrossMultiplier(ByVal Type As String, ByRef Amount As Double)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT top 1 Value23 From SETTINGPERMOD where frmname='" & Type & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iAmount As Integer = .GetOrdinal("Value23")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Amount = ._pReturnString(_nSqlDataReader(_iAmount))
                            Loop
                        Else
                            If Type = "CTCINDIVIDUAL" Then
                                Amount = 1.0
                            ElseIf Type = "CTCCORPORATION" Then
                                Amount = 2.0
                            End If

                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsertCedula(ByVal Email As String, _
                                 ByVal ControlNo As String, _
                                 ByVal CTC_Type As String, _
                                 ByVal FName As String, _
                                 ByVal MName As String, _
                                 ByVal LName As String, _
                                 ByVal OrgKind As String, _
                                 ByVal Address As String, _
                                 ByVal BirthPlace As String, _
                                 ByVal BirthDate As String, _
                                 ByVal CivilStatus As String, _
                                 ByVal Citizenship As String, _
                                 ByVal Gender As String, _
                                 ByVal Occupation As String, _
                                 ByVal TIN As String, _
                                 ByVal BusIncome As String, _
                                 ByVal ProfIncome As String, _
                                 ByVal RPTIncome As String, _
                                 ByVal BasicAmount As String, _
                                 ByVal TaxAmount As String, _
                                 ByVal Penalty As String, _
                                 ByVal DelFee As String, _
                                 ByVal TotAmount As String, _
                                 ByVal Status As String, _
                                 ByVal RefNo As String, _
                                 ByVal Height As String, _
                                 ByVal Weight As String, _
                                 ByVal OTC As String
                                 )
        Try

            Dim _nQuery As String = Nothing
            _nQuery = " INSERT INTO CTC_Online" & _
                " (EMAIL,ControlNo,CTC_Type,ForYear,FirstName,MiddleName,LastName,OrgKind,Address,BirthPlace,BirthDate,CivilStatus,Citizenship,Gender,Occupation,TIN,BusIncome,ProfIncome,RPTIncome,BasicAmount,TaxAmount,Penalty,DelFee,TotAmount,TransDate,Status,RefNo,Height,Weight,OTC) " & _
                " VALUES" & _
                " (@EMAIL,@ControlNo,@CTC_Type,YEAR(GETDATE()),@FirstName,@MiddleName,@LastName,@OrgKind,@Address,@BirthPlace,@BirthDate,@CivilStatus,@Citizenship,@Gender,@Occupation,@TIN,@BusIncome,@ProfIncome,@RPTIncome,@BasicAmount,@TaxAmount,@Penalty,@DelFee,@TotAmount,GETDATE(),@Status,@RefNo,@Height,@Weight,@OTC) "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@EMAIL", Email)
                .AddWithValue("@ControlNo", ControlNo)
                .AddWithValue("@CTC_Type", CTC_Type)
                .AddWithValue("@FirstName", FName)
                .AddWithValue("@MiddleName", MName)
                .AddWithValue("@LastName", LName)
                .AddWithValue("@OrgKind", OrgKind)
                .AddWithValue("@Address", Address)
                .AddWithValue("@BirthPlace", BirthPlace)
                .AddWithValue("@BirthDate", BirthDate)
                .AddWithValue("@CivilStatus", CivilStatus)
                .AddWithValue("@Citizenship", Citizenship)
                .AddWithValue("@Gender", Gender)
                .AddWithValue("@Occupation", Occupation)
                .AddWithValue("@TIN", TIN)
                .AddWithValue("@BusIncome", BusIncome)
                .AddWithValue("@ProfIncome", ProfIncome)
                .AddWithValue("@RPTIncome", RPTIncome)
                .AddWithValue("@BasicAmount", BasicAmount)
                .AddWithValue("@TaxAmount", TaxAmount)
                .AddWithValue("@Penalty", Penalty)
                .AddWithValue("@DelFee", DelFee)
                .AddWithValue("@TotAmount", TotAmount)
                .AddWithValue("@Status", Status)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@Height", Height)
                .AddWithValue("@Weight", Weight)
                .AddWithValue("@OTC", OTC)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Function _pSubGetInterestMultiplier() As Double
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                " SELECT " & _
                " CASE" & _
                " WHEN (CtcMonth) > MONTH(getdate()) THEN 0" & _
                " WHEN (CtcMonth) = MONTH(getdate()) THEN CtcInterest" & _
                " WHEN (CtcMonth) < MONTH(getdate()) THEN CtcInterest + 	((MONTH(getdate()) - (CtcMonth))*(CtcSucceed))" & _
                " END AS 'InterestMultiplier'" & _
                " from CTCInterest;"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iInterestMultiplier As Integer = .GetOrdinal("InterestMultiplier")
                    Dim InterestMultiplier As Double
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                InterestMultiplier = ._pReturnString(_nSqlDataReader(_iInterestMultiplier))
                                InterestMultiplier = InterestMultiplier * 0.1
                                Return Format(InterestMultiplier, "STANDARD")
                            Loop
                        Else
                            Return 0
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Function

    Function _pSubGetNewBPMinAmount(ByVal ctcType As String) As Double
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT Value21 From SETTINGPERMOD WHERE (frmname = '" & ctcType & "')"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iMinAmount As Integer = .GetOrdinal("Value21")
                    Dim InterestMultiplier As Double
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Return ._pReturnDecimal(_nSqlDataReader(_iMinAmount))
                            Loop
                        Else
                            Return 0
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Function


#End Region

End Class
