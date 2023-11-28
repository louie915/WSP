

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalStpCtcInd

#Region "Variables Data"
    Public Shared _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Public Shared _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader




#End Region

#Region "Properties Data"
    Shared _nSuccessful As Object

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

    Private Shared _mAddress_Left As String
    Private Shared _mAddress_Top As String
    Private Shared _mBasicAmount_Left As String
    Private Shared _mBasicAmount_Top As String
    Private Shared _mBirthPlace_Left As String
    Private Shared _mBirthPlace_Top As String
    Private Shared _mBusIncome_Left As String
    Private Shared _mBusIncome_Top As String
    Private Shared _mBusIncomeComputation_Left As String
    Private Shared _mBusIncomeComputation_Top As String
    Private Shared _mCitizenship_Left As String
    Private Shared _mCitizenship_Top As String
    Private Shared _mCivilStatus_Left As String
    Private Shared _mCivilStatus_Top As String
    Private Shared _mDateIssued_Left As String
    Private Shared _mDateIssued_Top As String
    Private Shared _mFirstName_Left As String
    Private Shared _mFirstName_Top As String
    Private Shared _mGender_Left As String
    Private Shared _mGender_Top As String
    Private Shared _mLastName_Left As String
    Private Shared _mLastName_Top As String
    Private Shared _mLguProfile_Left As String
    Private Shared _mLguProfile_Top As String
    Private Shared _mMiddleName_Left As String
    Private Shared _mMiddleName_Top As String
    Private Shared _mOccupation_Left As String
    Private Shared _mOccupation_Top As String
    Private Shared _mOrNumber_Left As String
    Private Shared _mOrNumber_Top As String
    Private Shared _mPenalty_Left As String
    Private Shared _mPenalty_Top As String
    Private Shared _mProfIncome_Left As String
    Private Shared _mProfIncome_Top As String
    Private Shared _mProfIncomeComputation_Left As String
    Private Shared _mProfIncomeComputation_Top As String
    Private Shared _mRPTIncome_Left As String
    Private Shared _mRPTIncome_Top As String
    Private Shared _mRPTIncomeComputation_Top As String
    Private Shared _mRPTIncomeComputationLeft As String
    Private Shared _mSRS_Left As String
    Private Shared _mSRS_Top As String
    Private Shared _mTaxAmount_Left As String
    Private Shared _mTaxAmount_Top As String
    Private Shared _mTIN_Left As String
    Private Shared _mTIN_Top As String
    Private Shared _mTotalAmount_Left As String
    Private Shared _mTotalAmount_Top As String
    Private Shared _mYear_Left As String
    Private Shared _mYear_Top As String




#End Region

#Region "Properties Field"

    Public Shared Property _pAddress_Left() As String
        Get
            Return _mAddress_Left
        End Get
        Set(value As String)
            _mAddress_Left = value
        End Set
    End Property

    Public Shared Property _pAddress_Top() As String
        Get
            Return _mAddress_Top
        End Get
        Set(value As String)
            _mAddress_Top = value
        End Set
    End Property

    Public Shared Property _pBasicAmount_Left() As String
        Get
            Return _mBasicAmount_Left
        End Get
        Set(value As String)
            _mBasicAmount_Left = value
        End Set
    End Property

    Public Shared Property _pBasicAmount_Top() As String
        Get
            Return _mBasicAmount_Top
        End Get
        Set(value As String)
            _mBasicAmount_Top = value
        End Set
    End Property

    Public Shared Property _pBirthPlace_Left() As String
        Get
            Return _mBirthPlace_Left
        End Get
        Set(value As String)
            _mBirthPlace_Left = value
        End Set
    End Property

    Public Shared Property _pBirthPlace_Top() As String
        Get
            Return _mBirthPlace_Top
        End Get
        Set(value As String)
            _mBirthPlace_Top = value
        End Set
    End Property

    Public Shared Property _pBusIncome_Left() As String
        Get
            Return _mBusIncome_Left
        End Get
        Set(value As String)
            _mBusIncome_Left = value
        End Set
    End Property

    Public Shared Property _pBusIncome_Top() As String
        Get
            Return _mBusIncome_Top
        End Get
        Set(value As String)
            _mBusIncome_Top = value
        End Set
    End Property

    Public Shared Property _pBusIncomeComputation_Left() As String
        Get
            Return _mBusIncomeComputation_Left
        End Get
        Set(value As String)
            _mBusIncomeComputation_Left = value
        End Set
    End Property

    Public Shared Property _pBusIncomeComputation_Top() As String
        Get
            Return _mBusIncomeComputation_Top
        End Get
        Set(value As String)
            _mBusIncomeComputation_Top = value
        End Set
    End Property

    Public Shared Property _pCitizenship_Left() As String
        Get
            Return _mCitizenship_Left
        End Get
        Set(value As String)
            _mCitizenship_Left = value
        End Set
    End Property

    Public Shared Property _pCitizenship_Top() As String
        Get
            Return _mCitizenship_Top
        End Get
        Set(value As String)
            _mCitizenship_Top = value
        End Set
    End Property

    Public Shared Property _pCivilStatus_Left() As String
        Get
            Return _mCivilStatus_Left
        End Get
        Set(value As String)
            _mCivilStatus_Left = value
        End Set
    End Property

    Public Shared Property _pCivilStatus_Top() As String
        Get
            Return _mCivilStatus_Top
        End Get
        Set(value As String)
            _mCivilStatus_Top = value
        End Set
    End Property

    Public Shared Property _pDateIssued_Left() As String
        Get
            Return _mDateIssued_Left
        End Get
        Set(value As String)
            _mDateIssued_Left = value
        End Set
    End Property

    Public Shared Property _pDateIssued_Top() As String
        Get
            Return _mDateIssued_Top
        End Get
        Set(value As String)
            _mDateIssued_Top = value
        End Set
    End Property

    Public Shared Property _pFirstName_Left() As String
        Get
            Return _mFirstName_Left
        End Get
        Set(value As String)
            _mFirstName_Left = value
        End Set
    End Property

    Public Shared Property _pFirstName_Top() As String
        Get
            Return _mFirstName_Top
        End Get
        Set(value As String)
            _mFirstName_Top = value
        End Set
    End Property

    Public Shared Property _pGender_Left() As String
        Get
            Return _mGender_Left
        End Get
        Set(value As String)
            _mGender_Left = value
        End Set
    End Property

    Public Shared Property _pGender_Top() As String
        Get
            Return _mGender_Top
        End Get
        Set(value As String)
            _mGender_Top = value
        End Set
    End Property

    Public Shared Property _pLastName_Left() As String
        Get
            Return _mLastName_Left
        End Get
        Set(value As String)
            _mLastName_Left = value
        End Set
    End Property

    Public Shared Property _pLastName_Top() As String
        Get
            Return _mLastName_Top
        End Get
        Set(value As String)
            _mLastName_Top = value
        End Set
    End Property

    Public Shared Property _pLguProfile_Left() As String
        Get
            Return _mLguProfile_Left
        End Get
        Set(value As String)
            _mLguProfile_Left = value
        End Set
    End Property

    Public Shared Property _pLguProfile_Top() As String
        Get
            Return _mLguProfile_Top
        End Get
        Set(value As String)
            _mLguProfile_Top = value
        End Set
    End Property

    Public Shared Property _pMiddleName_Left() As String
        Get
            Return _mMiddleName_Left
        End Get
        Set(value As String)
            _mMiddleName_Left = value
        End Set
    End Property

    Public Shared Property _pMiddleName_Top() As String
        Get
            Return _mMiddleName_Top
        End Get
        Set(value As String)
            _mMiddleName_Top = value
        End Set
    End Property

    Public Shared Property _pOccupation_Left() As String
        Get
            Return _mOccupation_Left
        End Get
        Set(value As String)
            _mOccupation_Left = value
        End Set
    End Property

    Public Shared Property _pOccupation_Top() As String
        Get
            Return _mOccupation_Top
        End Get
        Set(value As String)
            _mOccupation_Top = value
        End Set
    End Property

    Public Shared Property _pOrNumber_Left() As String
        Get
            Return _mOrNumber_Left
        End Get
        Set(value As String)
            _mOrNumber_Left = value
        End Set
    End Property

    Public Shared Property _pOrNumber_Top() As String
        Get
            Return _mOrNumber_Top
        End Get
        Set(value As String)
            _mOrNumber_Top = value
        End Set
    End Property

    Public Shared Property _pPenalty_Left() As String
        Get
            Return _mPenalty_Left
        End Get
        Set(value As String)
            _mPenalty_Left = value
        End Set
    End Property

    Public Shared Property _pPenalty_Top() As String
        Get
            Return _mPenalty_Top
        End Get
        Set(value As String)
            _mPenalty_Top = value
        End Set
    End Property

    Public Shared Property _pProfIncome_Left() As String
        Get
            Return _mProfIncome_Left
        End Get
        Set(value As String)
            _mProfIncome_Left = value
        End Set
    End Property

    Public Shared Property _pProfIncome_Top() As String
        Get
            Return _mProfIncome_Top
        End Get
        Set(value As String)
            _mProfIncome_Top = value
        End Set
    End Property

    Public Shared Property _pProfIncomeComputation_Left() As String
        Get
            Return _mProfIncomeComputation_Left
        End Get
        Set(value As String)
            _mProfIncomeComputation_Left = value
        End Set
    End Property

    Public Shared Property _pProfIncomeComputation_Top() As String
        Get
            Return _mProfIncomeComputation_Top
        End Get
        Set(value As String)
            _mProfIncomeComputation_Top = value
        End Set
    End Property

    Public Shared Property _pRPTIncome_Left() As String
        Get
            Return _mRPTIncome_Left
        End Get
        Set(value As String)
            _mRPTIncome_Left = value
        End Set
    End Property

    Public Shared Property _pRPTIncome_Top() As String
        Get
            Return _mRPTIncome_Top
        End Get
        Set(value As String)
            _mRPTIncome_Top = value
        End Set
    End Property

    Public Shared Property _pRPTIncomeComputation_Top() As String
        Get
            Return _mRPTIncomeComputation_Top
        End Get
        Set(value As String)
            _mRPTIncomeComputation_Top = value
        End Set
    End Property

    Public Shared Property _pRPTIncomeComputationLeft() As String
        Get
            Return _mRPTIncomeComputationLeft
        End Get
        Set(value As String)
            _mRPTIncomeComputationLeft = value
        End Set
    End Property

    Public Shared Property _pSRS_Left() As String
        Get
            Return _mSRS_Left
        End Get
        Set(value As String)
            _mSRS_Left = value
        End Set
    End Property

    Public Shared Property _pSRS_Top() As String
        Get
            Return _mSRS_Top
        End Get
        Set(value As String)
            _mSRS_Top = value
        End Set
    End Property

    Public Shared Property _pTaxAmount_Left() As String
        Get
            Return _mTaxAmount_Left
        End Get
        Set(value As String)
            _mTaxAmount_Left = value
        End Set
    End Property

    Public Shared Property _pTaxAmount_Top() As String
        Get
            Return _mTaxAmount_Top
        End Get
        Set(value As String)
            _mTaxAmount_Top = value
        End Set
    End Property

    Public Shared Property _pTIN_Left() As String
        Get
            Return _mTIN_Left
        End Get
        Set(value As String)
            _mTIN_Left = value
        End Set
    End Property

    Public Shared Property _pTIN_Top() As String
        Get
            Return _mTIN_Top
        End Get
        Set(value As String)
            _mTIN_Top = value
        End Set
    End Property

    Public Shared Property _pTotalAmount_Left() As String
        Get
            Return _mTotalAmount_Left
        End Get
        Set(value As String)
            _mTotalAmount_Left = value
        End Set
    End Property

    Public Shared Property _pTotalAmount_Top() As String
        Get
            Return _mTotalAmount_Top
        End Get
        Set(value As String)
            _mTotalAmount_Top = value
        End Set
    End Property

    Public Shared Property _pYear_Left() As String
        Get
            Return _mYear_Left
        End Get
        Set(value As String)
            _mYear_Left = value
        End Set
    End Property

    Public Shared Property _pYear_Top() As String
        Get
            Return _mYear_Top
        End Get
        Set(value As String)
            _mYear_Top = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"

    Public Sub _pSubReqinsert()
        Try
            Dim _nQuery As String = Nothing ' For For Requirements module 20161114

            _nQuery = _
                "sp_stpctcind_IUD " & _
                " " & _
                "@Action= 'INSERT' " & _
                IIf(_mAddress_Left = "", "", ",@Address_Left= N'" & _mAddress_Left & "' ") & _
                IIf(_mAddress_Top = "", "", ",@Address_Top= N'" & _mAddress_Top & "' ") & _
                IIf(_mBasicAmount_Left = "", "", ",@BasicAmount_Left= N'" & _mBasicAmount_Left & "' ") & _
                IIf(_mBasicAmount_Top = "", "", ",@BasicAmount_Top= N'" & _mBasicAmount_Top & "' ") & _
                IIf(_mBirthPlace_Left = "", "", ",@BirthPlace_Left= N'" & _mBirthPlace_Left & "' ") & _
                IIf(_mBirthPlace_Top = "", "", ",@BirthPlace_Top= N'" & _mBirthPlace_Top & "' ") & _
                IIf(_mBusIncome_Left = "", "", ",@BusIncome_Left= N'" & _mBusIncome_Left & "' ") & _
                IIf(_mBusIncome_Top = "", "", ",@BusIncome_Top= N'" & _mBusIncome_Top & "' ") & _
                IIf(_mBusIncomeComputation_Left = "", "", ",@BusIncomeComputation_Left= N'" & _mBusIncomeComputation_Left & "' ") & _
                IIf(_mBusIncomeComputation_Top = "", "", ",@BusIncomeComputation_Top= N'" & _mBusIncomeComputation_Top & "' ") & _
                IIf(_mCitizenship_Left = "", "", ",@Citizenship_Left= N'" & _mCitizenship_Left & "' ") & _
                IIf(_mCitizenship_Top = "", "", ",@Citizenship_Top= N'" & _mCitizenship_Top & "' ") & _
                IIf(_mCivilStatus_Left = "", "", ",@CivilStatus_Left= N'" & _mCivilStatus_Left & "' ") & _
                IIf(_mCivilStatus_Top = "", "", ",@CivilStatus_Top= N'" & _mCivilStatus_Top & "' ") & _
                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                IIf(_mFirstName_Left = "", "", ",@FirstName_Left= N'" & _mFirstName_Left & "' ") & _
                IIf(_mFirstName_Top = "", "", ",@FirstName_Top= N'" & _mFirstName_Top & "' ") & _
                IIf(_mGender_Left = "", "", ",@Gender_Left= N'" & _mGender_Left & "' ") & _
                IIf(_mGender_Top = "", "", ",@Gender_Top= N'" & _mGender_Top & "' ") & _
                IIf(_mLastName_Left = "", "", ",@LastName_Left= N'" & _mLastName_Left & "' ") & _
                IIf(_mLastName_Top = "", "", ",@LastName_Top= N'" & _mLastName_Top & "' ") & _
                IIf(_mLguProfile_Left = "", "", ",@LguProfile_Left= N'" & _mLguProfile_Left & "' ") & _
                IIf(_mLguProfile_Top = "", "", ",@LguProfile_Top= N'" & _mLguProfile_Top & "' ") & _
                IIf(_mMiddleName_Left = "", "", ",@MiddleName_Left= N'" & _mMiddleName_Left & "' ") & _
                IIf(_mMiddleName_Top = "", "", ",@MiddleName_Top= N'" & _mMiddleName_Top & "' ") & _
                IIf(_mOccupation_Left = "", "", ",@Occupation_Left= N'" & _mOccupation_Left & "' ") & _
                IIf(_mOccupation_Top = "", "", ",@Occupation_Top= N'" & _mOccupation_Top & "' ") & _
                IIf(_mOrNumber_Left = "", "", ",@OrNumber_Left= N'" & _mOrNumber_Left & "' ") & _
                IIf(_mOrNumber_Top = "", "", ",@OrNumber_Top= N'" & _mOrNumber_Top & "' ") & _
                IIf(_mPenalty_Left = "", "", ",@Penalty_Left= N'" & _mPenalty_Left & "' ") & _
                IIf(_mPenalty_Top = "", "", ",@Penalty_Top= N'" & _mPenalty_Top & "' ") & _
                IIf(_mProfIncome_Left = "", "", ",@ProfIncome_Left= N'" & _mProfIncome_Left & "' ") & _
                IIf(_mProfIncome_Top = "", "", ",@ProfIncome_Top= N'" & _mProfIncome_Top & "' ") & _
                IIf(_mProfIncomeComputation_Left = "", "", ",@ProfIncomeComputation_Left= N'" & _mProfIncomeComputation_Left & "' ") & _
                IIf(_mProfIncomeComputation_Top = "", "", ",@ProfIncomeComputation_Top= N'" & _mProfIncomeComputation_Top & "' ") & _
                IIf(_mRPTIncome_Left = "", "", ",@RPTIncome_Left= N'" & _mRPTIncome_Left & "' ") & _
                IIf(_mRPTIncome_Top = "", "", ",@RPTIncome_Top= N'" & _mRPTIncome_Top & "' ") & _
                IIf(_mRPTIncomeComputation_Top = "", "", ",@RPTIncomeComputation_Top= N'" & _mRPTIncomeComputation_Top & "' ") & _
                IIf(_mRPTIncomeComputationLeft = "", "", ",@RPTIncomeComputationLeft= N'" & _mRPTIncomeComputationLeft & "' ") & _
                IIf(_mSRS_Left = "", "", ",@SRS_Left= N'" & _mSRS_Left & "' ") & _
                IIf(_mSRS_Top = "", "", ",@SRS_Top= N'" & _mSRS_Top & "' ") & _
                IIf(_mTaxAmount_Left = "", "", ",@TaxAmount_Left= N'" & _mTaxAmount_Left & "' ") & _
                IIf(_mTaxAmount_Top = "", "", ",@TaxAmount_Top= N'" & _mTaxAmount_Top & "' ") & _
                IIf(_mTIN_Left = "", "", ",@TIN_Left= N'" & _mTIN_Left & "' ") & _
                IIf(_mTIN_Top = "", "", ",@TIN_Top= N'" & _mTIN_Top & "' ") & _
                IIf(_mTotalAmount_Left = "", "", ",@TotalAmount_Left= N'" & _mTotalAmount_Left & "' ") & _
                IIf(_mTotalAmount_Top = "", "", ",@TotalAmount_Top= N'" & _mTotalAmount_Top & "' ") & _
                IIf(_mYear_Left = "", "", ",@Year_Left= N'" & _mYear_Left & "' ") & _
                IIf(_mYear_Top = "", "", ",@Year_Top= N'" & _mYear_Top & "' ") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSMAST_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters
            '    If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            'End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubSelectDetails()
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            '_mStrSql = Nothing
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String
            'Dim _nCntQuery As String = Nothing
            Dim _nQuery As String = Nothing
            'Dim _nStartRowIndex As Integer
            '_nStartRowIndex = (_nPageIndex * _nPageSize) + 1

            _nSelectCond = ""

            _nStrSql = " EXEC [sp_StpCtcInd_IUD] " & _
                        " @Action = 'SELECT'" & _
                        ",@SelectCond = N'" & _nSelectCond & "'" & _
                        ",@Successful = @Successful output " & _
                        ",@ErrMsg = @ErrMsg output " & _
                        ""



            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)
            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output



            'set paramater Error Msg
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                'If _nSqlDr.HasRows Then
                Do While _nSqlDr.Read


                    If IsDBNull(_nSqlDr.Item("Address_Left").ToString) Then
                        _mAddress_Left = ""
                    Else
                        _mAddress_Left = UCase(_nSqlDr.Item("Address_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Address_Top").ToString) Then
                        _mAddress_Top = ""
                    Else
                        _mAddress_Top = UCase(_nSqlDr.Item("Address_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BasicAmount_Left").ToString) Then
                        _mBasicAmount_Left = ""
                    Else
                        _mBasicAmount_Left = UCase(_nSqlDr.Item("BasicAmount_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BasicAmount_Top").ToString) Then
                        _mBasicAmount_Top = ""
                    Else
                        _mBasicAmount_Top = UCase(_nSqlDr.Item("BasicAmount_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BirthPlace_Left").ToString) Then
                        _mBirthPlace_Left = ""
                    Else
                        _mBirthPlace_Left = UCase(_nSqlDr.Item("BirthPlace_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BirthPlace_Top").ToString) Then
                        _mBirthPlace_Top = ""
                    Else
                        _mBirthPlace_Top = UCase(_nSqlDr.Item("BirthPlace_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BusIncome_Left").ToString) Then
                        _mBusIncome_Left = ""
                    Else
                        _mBusIncome_Left = UCase(_nSqlDr.Item("BusIncome_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BusIncome_Top").ToString) Then
                        _mBusIncome_Top = ""
                    Else
                        _mBusIncome_Top = UCase(_nSqlDr.Item("BusIncome_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BusIncomeComputation_Left").ToString) Then
                        _mBusIncomeComputation_Left = ""
                    Else
                        _mBusIncomeComputation_Left = UCase(_nSqlDr.Item("BusIncomeComputation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("BusIncomeComputation_Top").ToString) Then
                        _mBusIncomeComputation_Top = ""
                    Else
                        _mBusIncomeComputation_Top = UCase(_nSqlDr.Item("BusIncomeComputation_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Citizenship_Left").ToString) Then
                        _mCitizenship_Left = ""
                    Else
                        _mCitizenship_Left = UCase(_nSqlDr.Item("Citizenship_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Citizenship_Top").ToString) Then
                        _mCitizenship_Top = ""
                    Else
                        _mCitizenship_Top = UCase(_nSqlDr.Item("Citizenship_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("CivilStatus_Left").ToString) Then
                        _mCivilStatus_Left = ""
                    Else
                        _mCivilStatus_Left = UCase(_nSqlDr.Item("CivilStatus_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("CivilStatus_Top").ToString) Then
                        _mCivilStatus_Top = ""
                    Else
                        _mCivilStatus_Top = UCase(_nSqlDr.Item("CivilStatus_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DateIssued_Left").ToString) Then
                        _mDateIssued_Left = ""
                    Else
                        _mDateIssued_Left = UCase(_nSqlDr.Item("DateIssued_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DateIssued_Top").ToString) Then
                        _mDateIssued_Top = ""
                    Else
                        _mDateIssued_Top = UCase(_nSqlDr.Item("DateIssued_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("FirstName_Left").ToString) Then
                        _mFirstName_Left = ""
                    Else
                        _mFirstName_Left = UCase(_nSqlDr.Item("FirstName_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("FirstName_Top").ToString) Then
                        _mFirstName_Top = ""
                    Else
                        _mFirstName_Top = UCase(_nSqlDr.Item("FirstName_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Gender_Left").ToString) Then
                        _mGender_Left = ""
                    Else
                        _mGender_Left = UCase(_nSqlDr.Item("Gender_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Gender_Top").ToString) Then
                        _mGender_Top = ""
                    Else
                        _mGender_Top = UCase(_nSqlDr.Item("Gender_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LastName_Left").ToString) Then
                        _mLastName_Left = ""
                    Else
                        _mLastName_Left = UCase(_nSqlDr.Item("LastName_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LastName_Top").ToString) Then
                        _mLastName_Top = ""
                    Else
                        _mLastName_Top = UCase(_nSqlDr.Item("LastName_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LguProfile_Left").ToString) Then
                        _mLguProfile_Left = ""
                    Else
                        _mLguProfile_Left = UCase(_nSqlDr.Item("LguProfile_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LguProfile_Top").ToString) Then
                        _mLguProfile_Top = ""
                    Else
                        _mLguProfile_Top = UCase(_nSqlDr.Item("LguProfile_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("MiddleName_Left").ToString) Then
                        _mMiddleName_Left = ""
                    Else
                        _mMiddleName_Left = UCase(_nSqlDr.Item("MiddleName_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("MiddleName_Top").ToString) Then
                        _mMiddleName_Top = ""
                    Else
                        _mMiddleName_Top = UCase(_nSqlDr.Item("MiddleName_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Occupation_Left").ToString) Then
                        _mOccupation_Left = ""
                    Else
                        _mOccupation_Left = UCase(_nSqlDr.Item("Occupation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Occupation_Top").ToString) Then
                        _mOccupation_Top = ""
                    Else
                        _mOccupation_Top = UCase(_nSqlDr.Item("Occupation_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("OrNumber_Left").ToString) Then
                        _mOrNumber_Left = ""
                    Else
                        _mOrNumber_Left = UCase(_nSqlDr.Item("OrNumber_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("OrNumber_Top").ToString) Then
                        _mOrNumber_Top = ""
                    Else
                        _mOrNumber_Top = UCase(_nSqlDr.Item("OrNumber_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Penalty_Left").ToString) Then
                        _mPenalty_Left = ""
                    Else
                        _mPenalty_Left = UCase(_nSqlDr.Item("Penalty_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Penalty_Top").ToString) Then
                        _mPenalty_Top = ""
                    Else
                        _mPenalty_Top = UCase(_nSqlDr.Item("Penalty_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("ProfIncome_Left").ToString) Then
                        _mProfIncome_Left = ""
                    Else
                        _mProfIncome_Left = UCase(_nSqlDr.Item("ProfIncome_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("ProfIncome_Top").ToString) Then
                        _mProfIncome_Top = ""
                    Else
                        _mProfIncome_Top = UCase(_nSqlDr.Item("ProfIncome_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("ProfIncomeComputation_Left").ToString) Then
                        _mProfIncomeComputation_Left = ""
                    Else
                        _mProfIncomeComputation_Left = UCase(_nSqlDr.Item("ProfIncomeComputation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("ProfIncomeComputation_Top").ToString) Then
                        _mProfIncomeComputation_Top = ""
                    Else
                        _mProfIncomeComputation_Top = UCase(_nSqlDr.Item("ProfIncomeComputation_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("RPTIncome_Left").ToString) Then
                        _mRPTIncome_Left = ""
                    Else
                        _mRPTIncome_Left = UCase(_nSqlDr.Item("RPTIncome_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("RPTIncome_Top").ToString) Then
                        _mRPTIncome_Top = ""
                    Else
                        _mRPTIncome_Top = UCase(_nSqlDr.Item("RPTIncome_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("RPTIncomeComputation_Top").ToString) Then
                        _mRPTIncomeComputation_Top = ""
                    Else
                        _mRPTIncomeComputation_Top = UCase(_nSqlDr.Item("RPTIncomeComputation_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("RPTIncomeComputationLeft").ToString) Then
                        _mRPTIncomeComputationLeft = ""
                    Else
                        _mRPTIncomeComputationLeft = UCase(_nSqlDr.Item("RPTIncomeComputationLeft").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("SRS_Left").ToString) Then
                        _mSRS_Left = ""
                    Else
                        _mSRS_Left = UCase(_nSqlDr.Item("SRS_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("SRS_Top").ToString) Then
                        _mSRS_Top = ""
                    Else
                        _mSRS_Top = UCase(_nSqlDr.Item("SRS_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TaxAmount_Left").ToString) Then
                        _mTaxAmount_Left = ""
                    Else
                        _mTaxAmount_Left = UCase(_nSqlDr.Item("TaxAmount_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TaxAmount_Top").ToString) Then
                        _mTaxAmount_Top = ""
                    Else
                        _mTaxAmount_Top = UCase(_nSqlDr.Item("TaxAmount_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TIN_Left").ToString) Then
                        _mTIN_Left = ""
                    Else
                        _mTIN_Left = UCase(_nSqlDr.Item("TIN_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TIN_Top").ToString) Then
                        _mTIN_Top = ""
                    Else
                        _mTIN_Top = UCase(_nSqlDr.Item("TIN_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TotalAmount_Left").ToString) Then
                        _mTotalAmount_Left = ""
                    Else
                        _mTotalAmount_Left = UCase(_nSqlDr.Item("TotalAmount_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TotalAmount_Top").ToString) Then
                        _mTotalAmount_Top = ""
                    Else
                        _mTotalAmount_Top = UCase(_nSqlDr.Item("TotalAmount_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Year_Left").ToString) Then
                        _mYear_Left = ""
                    Else
                        _mYear_Left = UCase(_nSqlDr.Item("Year_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Year_Top").ToString) Then
                        _mYear_Top = ""
                    Else
                        _mYear_Top = UCase(_nSqlDr.Item("Year_Top").ToString)
                    End If


                Loop
                'End If
            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _nErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value

            _mSqlCommand.Dispose()


        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub _pSubUpdateStp()
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String = ""
            Dim _nSelectCond As String = ""
            'Initialize String SQL


            _nStrSql = " EXEC [sp_StpCtcInd_IUD] @Action = 'UPDATE'" & _
                                IIf(_mAddress_Left = "", "", ",@Address_Left= N'" & _mAddress_Left & "' ") & _
                                IIf(_mAddress_Top = "", "", ",@Address_Top= N'" & _mAddress_Top & "' ") & _
                                IIf(_mBasicAmount_Left = "", "", ",@BasicAmount_Left= N'" & _mBasicAmount_Left & "' ") & _
                                IIf(_mBasicAmount_Top = "", "", ",@BasicAmount_Top= N'" & _mBasicAmount_Top & "' ") & _
                                IIf(_mBirthPlace_Left = "", "", ",@BirthPlace_Left= N'" & _mBirthPlace_Left & "' ") & _
                                IIf(_mBirthPlace_Top = "", "", ",@BirthPlace_Top= N'" & _mBirthPlace_Top & "' ") & _
                                IIf(_mBusIncome_Left = "", "", ",@BusIncome_Left= N'" & _mBusIncome_Left & "' ") & _
                                IIf(_mBusIncome_Top = "", "", ",@BusIncome_Top= N'" & _mBusIncome_Top & "' ") & _
                                IIf(_mBusIncomeComputation_Left = "", "", ",@BusIncomeComputation_Left= N'" & _mBusIncomeComputation_Left & "' ") & _
                                IIf(_mBusIncomeComputation_Top = "", "", ",@BusIncomeComputation_Top= N'" & _mBusIncomeComputation_Top & "' ") & _
                                IIf(_mCitizenship_Left = "", "", ",@Citizenship_Left= N'" & _mCitizenship_Left & "' ") & _
                                IIf(_mCitizenship_Top = "", "", ",@Citizenship_Top= N'" & _mCitizenship_Top & "' ") & _
                                IIf(_mCivilStatus_Left = "", "", ",@CivilStatus_Left= N'" & _mCivilStatus_Left & "' ") & _
                                IIf(_mCivilStatus_Top = "", "", ",@CivilStatus_Top= N'" & _mCivilStatus_Top & "' ") & _
                                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                                IIf(_mFirstName_Left = "", "", ",@FirstName_Left= N'" & _mFirstName_Left & "' ") & _
                                IIf(_mFirstName_Top = "", "", ",@FirstName_Top= N'" & _mFirstName_Top & "' ") & _
                                IIf(_mGender_Left = "", "", ",@Gender_Left= N'" & _mGender_Left & "' ") & _
                                IIf(_mGender_Top = "", "", ",@Gender_Top= N'" & _mGender_Top & "' ") & _
                                IIf(_mLastName_Left = "", "", ",@LastName_Left= N'" & _mLastName_Left & "' ") & _
                                IIf(_mLastName_Top = "", "", ",@LastName_Top= N'" & _mLastName_Top & "' ") & _
                                IIf(_mLguProfile_Left = "", "", ",@LguProfile_Left= N'" & _mLguProfile_Left & "' ") & _
                                IIf(_mLguProfile_Top = "", "", ",@LguProfile_Top= N'" & _mLguProfile_Top & "' ") & _
                                IIf(_mMiddleName_Left = "", "", ",@MiddleName_Left= N'" & _mMiddleName_Left & "' ") & _
                                IIf(_mMiddleName_Top = "", "", ",@MiddleName_Top= N'" & _mMiddleName_Top & "' ") & _
                                IIf(_mOccupation_Left = "", "", ",@Occupation_Left= N'" & _mOccupation_Left & "' ") & _
                                IIf(_mOccupation_Top = "", "", ",@Occupation_Top= N'" & _mOccupation_Top & "' ") & _
                                IIf(_mOrNumber_Left = "", "", ",@OrNumber_Left= N'" & _mOrNumber_Left & "' ") & _
                                IIf(_mOrNumber_Top = "", "", ",@OrNumber_Top= N'" & _mOrNumber_Top & "' ") & _
                                IIf(_mPenalty_Left = "", "", ",@Penalty_Left= N'" & _mPenalty_Left & "' ") & _
                                IIf(_mPenalty_Top = "", "", ",@Penalty_Top= N'" & _mPenalty_Top & "' ") & _
                                IIf(_mProfIncome_Left = "", "", ",@ProfIncome_Left= N'" & _mProfIncome_Left & "' ") & _
                                IIf(_mProfIncome_Top = "", "", ",@ProfIncome_Top= N'" & _mProfIncome_Top & "' ") & _
                                IIf(_mProfIncomeComputation_Left = "", "", ",@ProfIncomeComputation_Left= N'" & _mProfIncomeComputation_Left & "' ") & _
                                IIf(_mProfIncomeComputation_Top = "", "", ",@ProfIncomeComputation_Top= N'" & _mProfIncomeComputation_Top & "' ") & _
                                IIf(_mRPTIncome_Left = "", "", ",@RPTIncome_Left= N'" & _mRPTIncome_Left & "' ") & _
                                IIf(_mRPTIncome_Top = "", "", ",@RPTIncome_Top= N'" & _mRPTIncome_Top & "' ") & _
                                IIf(_mRPTIncomeComputation_Top = "", "", ",@RPTIncomeComputation_Top= N'" & _mRPTIncomeComputation_Top & "' ") & _
                                IIf(_mRPTIncomeComputationLeft = "", "", ",@RPTIncomeComputationLeft= N'" & _mRPTIncomeComputationLeft & "' ") & _
                                IIf(_mSRS_Left = "", "", ",@SRS_Left= N'" & _mSRS_Left & "' ") & _
                                IIf(_mSRS_Top = "", "", ",@SRS_Top= N'" & _mSRS_Top & "' ") & _
                                IIf(_mTaxAmount_Left = "", "", ",@TaxAmount_Left= N'" & _mTaxAmount_Left & "' ") & _
                                IIf(_mTaxAmount_Top = "", "", ",@TaxAmount_Top= N'" & _mTaxAmount_Top & "' ") & _
                                IIf(_mTIN_Left = "", "", ",@TIN_Left= N'" & _mTIN_Left & "' ") & _
                                IIf(_mTIN_Top = "", "", ",@TIN_Top= N'" & _mTIN_Top & "' ") & _
                                IIf(_mTotalAmount_Left = "", "", ",@TotalAmount_Left= N'" & _mTotalAmount_Left & "' ") & _
                                IIf(_mTotalAmount_Top = "", "", ",@TotalAmount_Top= N'" & _mTotalAmount_Top & "' ") & _
                                IIf(_mYear_Left = "", "", ",@Year_Left= N'" & _mYear_Left & "' ") & _
                                IIf(_mYear_Top = "", "", ",@Year_Top= N'" & _mYear_Top & "' ") & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  "



            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'set paramater COde


            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If

            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _nErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
            _mSqlCommand.Dispose()



        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubInsert()
        Try
            Dim _nErrMsg As String = ""
            Dim _nOutput As String = ""
            Dim _nStrSql As String = ""


            _nStrSql = " EXEC [sp_StpCtcInd_IUD] @Action = 'INSERT'" & _
                                IIf(_mAddress_Left = "", "", ",@Address_Left= N'" & _mAddress_Left & "' ") & _
                                IIf(_mAddress_Top = "", "", ",@Address_Top= N'" & _mAddress_Top & "' ") & _
                                IIf(_mBasicAmount_Left = "", "", ",@BasicAmount_Left= N'" & _mBasicAmount_Left & "' ") & _
                                IIf(_mBasicAmount_Top = "", "", ",@BasicAmount_Top= N'" & _mBasicAmount_Top & "' ") & _
                                IIf(_mBirthPlace_Left = "", "", ",@BirthPlace_Left= N'" & _mBirthPlace_Left & "' ") & _
                                IIf(_mBirthPlace_Top = "", "", ",@BirthPlace_Top= N'" & _mBirthPlace_Top & "' ") & _
                                IIf(_mBusIncome_Left = "", "", ",@BusIncome_Left= N'" & _mBusIncome_Left & "' ") & _
                                IIf(_mBusIncome_Top = "", "", ",@BusIncome_Top= N'" & _mBusIncome_Top & "' ") & _
                                IIf(_mBusIncomeComputation_Left = "", "", ",@BusIncomeComputation_Left= N'" & _mBusIncomeComputation_Left & "' ") & _
                                IIf(_mBusIncomeComputation_Top = "", "", ",@BusIncomeComputation_Top= N'" & _mBusIncomeComputation_Top & "' ") & _
                                IIf(_mCitizenship_Left = "", "", ",@Citizenship_Left= N'" & _mCitizenship_Left & "' ") & _
                                IIf(_mCitizenship_Top = "", "", ",@Citizenship_Top= N'" & _mCitizenship_Top & "' ") & _
                                IIf(_mCivilStatus_Left = "", "", ",@CivilStatus_Left= N'" & _mCivilStatus_Left & "' ") & _
                                IIf(_mCivilStatus_Top = "", "", ",@CivilStatus_Top= N'" & _mCivilStatus_Top & "' ") & _
                                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                                IIf(_mFirstName_Left = "", "", ",@FirstName_Left= N'" & _mFirstName_Left & "' ") & _
                                IIf(_mFirstName_Top = "", "", ",@FirstName_Top= N'" & _mFirstName_Top & "' ") & _
                                IIf(_mGender_Left = "", "", ",@Gender_Left= N'" & _mGender_Left & "' ") & _
                                IIf(_mGender_Top = "", "", ",@Gender_Top= N'" & _mGender_Top & "' ") & _
                                IIf(_mLastName_Left = "", "", ",@LastName_Left= N'" & _mLastName_Left & "' ") & _
                                IIf(_mLastName_Top = "", "", ",@LastName_Top= N'" & _mLastName_Top & "' ") & _
                                IIf(_mLguProfile_Left = "", "", ",@LguProfile_Left= N'" & _mLguProfile_Left & "' ") & _
                                IIf(_mLguProfile_Top = "", "", ",@LguProfile_Top= N'" & _mLguProfile_Top & "' ") & _
                                IIf(_mMiddleName_Left = "", "", ",@MiddleName_Left= N'" & _mMiddleName_Left & "' ") & _
                                IIf(_mMiddleName_Top = "", "", ",@MiddleName_Top= N'" & _mMiddleName_Top & "' ") & _
                                IIf(_mOccupation_Left = "", "", ",@Occupation_Left= N'" & _mOccupation_Left & "' ") & _
                                IIf(_mOccupation_Top = "", "", ",@Occupation_Top= N'" & _mOccupation_Top & "' ") & _
                                IIf(_mOrNumber_Left = "", "", ",@OrNumber_Left= N'" & _mOrNumber_Left & "' ") & _
                                IIf(_mOrNumber_Top = "", "", ",@OrNumber_Top= N'" & _mOrNumber_Top & "' ") & _
                                IIf(_mPenalty_Left = "", "", ",@Penalty_Left= N'" & _mPenalty_Left & "' ") & _
                                IIf(_mPenalty_Top = "", "", ",@Penalty_Top= N'" & _mPenalty_Top & "' ") & _
                                IIf(_mProfIncome_Left = "", "", ",@ProfIncome_Left= N'" & _mProfIncome_Left & "' ") & _
                                IIf(_mProfIncome_Top = "", "", ",@ProfIncome_Top= N'" & _mProfIncome_Top & "' ") & _
                                IIf(_mProfIncomeComputation_Left = "", "", ",@ProfIncomeComputation_Left= N'" & _mProfIncomeComputation_Left & "' ") & _
                                IIf(_mProfIncomeComputation_Top = "", "", ",@ProfIncomeComputation_Top= N'" & _mProfIncomeComputation_Top & "' ") & _
                                IIf(_mRPTIncome_Left = "", "", ",@RPTIncome_Left= N'" & _mRPTIncome_Left & "' ") & _
                                IIf(_mRPTIncome_Top = "", "", ",@RPTIncome_Top= N'" & _mRPTIncome_Top & "' ") & _
                                IIf(_mRPTIncomeComputation_Top = "", "", ",@RPTIncomeComputation_Top= N'" & _mRPTIncomeComputation_Top & "' ") & _
                                IIf(_mRPTIncomeComputationLeft = "", "", ",@RPTIncomeComputationLeft= N'" & _mRPTIncomeComputationLeft & "' ") & _
                                IIf(_mSRS_Left = "", "", ",@SRS_Left= N'" & _mSRS_Left & "' ") & _
                                IIf(_mSRS_Top = "", "", ",@SRS_Top= N'" & _mSRS_Top & "' ") & _
                                IIf(_mTaxAmount_Left = "", "", ",@TaxAmount_Left= N'" & _mTaxAmount_Left & "' ") & _
                                IIf(_mTaxAmount_Top = "", "", ",@TaxAmount_Top= N'" & _mTaxAmount_Top & "' ") & _
                                IIf(_mTIN_Left = "", "", ",@TIN_Left= N'" & _mTIN_Left & "' ") & _
                                IIf(_mTIN_Top = "", "", ",@TIN_Top= N'" & _mTIN_Top & "' ") & _
                                IIf(_mTotalAmount_Left = "", "", ",@TotalAmount_Left= N'" & _mTotalAmount_Left & "' ") & _
                                IIf(_mTotalAmount_Top = "", "", ",@TotalAmount_Top= N'" & _mTotalAmount_Top & "' ") & _
                                IIf(_mYear_Left = "", "", ",@Year_Left= N'" & _mYear_Left & "' ") & _
                                IIf(_mYear_Top = "", "", ",@Year_Top= N'" & _mYear_Top & "' ") & _
                                ",@Successful = @Successful output " & _
                                ",@ErrMsg = @ErrMsg output  " & _
                                " "





            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If

            End Using
            'Get values of parameter output

            _nErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
            '_mCode = _mSqlCommand.Parameters("@Code").Value

            _mSqlCommand.Dispose()

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mStrSql, _mSqlCon) '_gDBCon
            '_nSqlDataAdapter.SelectCommand.ExecuteNonQuery()

            '_nSqlDataAdapter.Dispose()

        Catch ex As Exception

        End Try
    End Sub


#End Region
End Class

