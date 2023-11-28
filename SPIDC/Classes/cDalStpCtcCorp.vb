

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalStpCtcCorp

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
    Private Shared _mBusIncome_Left As String
    Private Shared _mBusIncome_Top As String
    Private Shared _mBusIncomeComputation_Left As String
    Private Shared _mBusIncomeComputation_Top As String
    Private Shared _mCompanyName_Left As String
    Private Shared _mCompanyName_Top As String
    Private Shared _mDateIssued_Left As String
    Private Shared _mDateIssued_Top As String
    Private Shared _mDateofIncorporation_Left As String
    Private Shared _mDateofIncorporation_Top As String
    Private Shared _mDelFee_Left As String
    Private Shared _mDelFee_Top As String
    Private Shared _mLGUProfile_Left As String
    Private Shared _mLGUProfile_Top As String
    Private Shared _mOr_Number_Left As String
    Private Shared _mOr_Number_Top As String
    Private Shared _mOrgKind_Left As String
    Private Shared _mOrgKind_Top As String
    Private Shared _mPenalty_Left As String
    Private Shared _mPenalty_Top As String
    Private Shared _mPlaceofIncorporation_Left As String
    Private Shared _mPlaceofIncorporation_Top As String
    Private Shared _mRPTIncome_Left As String
    Private Shared _mRPTIncome_Top As String
    Private Shared _mRPTIncomeComputation_Left As String
    Private Shared _mRPTIncomeComputation_Top As String
    Private Shared _mSRS_Left As String
    Private Shared _mSRS_Top As String
    Private Shared _mTaxAmount_Left As String
    Private Shared _mTaxAmount_Top As String
    Private Shared _mTIN_Left As String
    Private Shared _mTIN_Top As String
    Private Shared _mTotAmount_Left As String
    Private Shared _mTotAmount_Top As String
    Private Shared _mYear_Left As String
    Private Shared _mYear_Top As String




#End Region

#Region "Properties Field"
    Public Shared Pro
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

    Public Shared Property _pCompanyName_Left() As String
        Get
            Return _mCompanyName_Left
        End Get
        Set(value As String)
            _mCompanyName_Left = value
        End Set
    End Property

    Public Shared Property _pCompanyName_Top() As String
        Get
            Return _mCompanyName_Top
        End Get
        Set(value As String)
            _mCompanyName_Top = value
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
    Public Shared Property _pDateofIncorporation_Left() As String
        Get
            Return _mDateofIncorporation_Left
        End Get
        Set(value As String)
            _mDateofIncorporation_Left = value
        End Set
    End Property

    Public Shared Property _pDateofIncorporation_Top() As String
        Get
            Return _mDateofIncorporation_Top
        End Get
        Set(value As String)
            _mDateofIncorporation_Top = value
        End Set
    End Property

    Public Shared Property _pDelFee_Left() As String
        Get
            Return _mDelFee_Left
        End Get
        Set(value As String)
            _mDelFee_Left = value
        End Set
    End Property

    Public Shared Property _pDelFee_Top() As String
        Get
            Return _mDelFee_Top
        End Get
        Set(value As String)
            _mDelFee_Top = value
        End Set
    End Property

    Public Shared Property _pLGUProfile_Left() As String
        Get
            Return _mLGUProfile_Left
        End Get
        Set(value As String)
            _mLGUProfile_Left = value
        End Set
    End Property

    Public Shared Property _pLGUProfile_Top() As String
        Get
            Return _mLGUProfile_Top
        End Get
        Set(value As String)
            _mLGUProfile_Top = value
        End Set
    End Property

    Public Shared Property _pOr_Number_Left() As String
        Get
            Return _mOr_Number_Left
        End Get
        Set(value As String)
            _mOr_Number_Left = value
        End Set
    End Property

    Public Shared Property _pOr_Number_Top() As String
        Get
            Return _mOr_Number_Top
        End Get
        Set(value As String)
            _mOr_Number_Top = value
        End Set
    End Property

    Public Shared Property _pOrgKind_Left() As String
        Get
            Return _mOrgKind_Left
        End Get
        Set(value As String)
            _mOrgKind_Left = value
        End Set
    End Property

    Public Shared Property _pOrgKind_Top() As String
        Get
            Return _mOrgKind_Top
        End Get
        Set(value As String)
            _mOrgKind_Top = value
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

    Public Shared Property _pPlaceofIncorporation_Left() As String
        Get
            Return _mPlaceofIncorporation_Left
        End Get
        Set(value As String)
            _mPlaceofIncorporation_Left = value
        End Set
    End Property

    Public Shared Property _pPlaceofIncorporation_Top() As String
        Get
            Return _mPlaceofIncorporation_Top
        End Get
        Set(value As String)
            _mPlaceofIncorporation_Top = value
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

    Public Shared Property _pRPTIncomeComputation_Left() As String
        Get
            Return _mRPTIncomeComputation_Left
        End Get
        Set(value As String)
            _mRPTIncomeComputation_Left = value
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

    Public Shared Property _pTotAmount_Left() As String
        Get
            Return _mTotAmount_Left
        End Get
        Set(value As String)
            _mTotAmount_Left = value
        End Set
    End Property

    Public Shared Property _pTotAmount_Top() As String
        Get
            Return _mTotAmount_Top
        End Get
        Set(value As String)
            _mTotAmount_Top = value
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
                "sp_stpctccorp_IUD " & _
                " " & _
                "@Action= 'INSERT' " & _
            IIf(_mAddress_Left = "", "", ",@_mAddress_Left= N'" & _mAddress_Left & "' ") & _
            IIf(_mAddress_Top = "", "", ",@_mAddress_Top= N'" & _mAddress_Top & "' ") & _
            IIf(_mBasicAmount_Left = "", "", ",@BasicAmount_Left= N'" & _mBasicAmount_Left & "' ") & _
            IIf(_mBasicAmount_Top = "", "", ",@BasicAmount_Top= N'" & _mBasicAmount_Top & "' ") & _
            IIf(_mBusIncome_Left = "", "", ",@BusIncome_Left= N'" & _mBusIncome_Left & "' ") & _
            IIf(_mBusIncome_Top = "", "", ",@BusIncome_Top= N'" & _mBusIncome_Top & "' ") & _
            IIf(_mBusIncomeComputation_Left = "", "", ",@BusIncomeComputation_Left= N'" & _mBusIncomeComputation_Left & "' ") & _
            IIf(_mBusIncomeComputation_Top = "", "", ",@BusIncomeComputation_Top= N'" & _mBusIncomeComputation_Top & "' ") & _
            IIf(_mCompanyName_Left = "", "", ",@CompanyName_Left= N'" & _mCompanyName_Left & "' ") & _
            IIf(_mCompanyName_Top = "", "", ",@CompanyName_Top= N'" & _mCompanyName_Top & "' ") & _
            IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
            IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
            IIf(_mDateofIncorporation_Left = "", "", ",@DateofIncorporation_Left= N'" & _mDateofIncorporation_Left & "' ") & _
            IIf(_mDateofIncorporation_Top = "", "", ",@DateofIncorporation_Top= N'" & _mDateofIncorporation_Top & "' ") & _
            IIf(_mDelFee_Left = "", "", ",@DelFee_Left= N'" & _mDelFee_Left & "' ") & _
            IIf(_mDelFee_Top = "", "", ",@DelFee_Top= N'" & _mDelFee_Top & "' ") & _
            IIf(_mLGUProfile_Left = "", "", ",@LGUProfile_Left= N'" & _mLGUProfile_Left & "' ") & _
            IIf(_mLGUProfile_Top = "", "", ",@LGUProfile_Top= N'" & _mLGUProfile_Top & "' ") & _
            IIf(_mOr_Number_Left = "", "", ",@Or_Number_Left= N'" & _mOr_Number_Left & "' ") & _
            IIf(_mOr_Number_Top = "", "", ",@Or_Number_Top= N'" & _mOr_Number_Top & "' ") & _
            IIf(_mOrgKind_Left = "", "", ",@OrgKind_Left= N'" & _mOrgKind_Left & "' ") & _
            IIf(_mOrgKind_Top = "", "", ",@OrgKind_Top= N'" & _mOrgKind_Top & "' ") & _
            IIf(_mPenalty_Left = "", "", ",@Penalty_Left= N'" & _mPenalty_Left & "' ") & _
            IIf(_mPenalty_Top = "", "", ",@Penalty_Top= N'" & _mPenalty_Top & "' ") & _
            IIf(_mPlaceofIncorporation_Left = "", "", ",@PlaceofIncorporation_Left= N'" & _mPlaceofIncorporation_Left & "' ") & _
            IIf(_mPlaceofIncorporation_Top = "", "", ",@PlaceofIncorporation_Top= N'" & _mPlaceofIncorporation_Top & "' ") & _
            IIf(_mRPTIncome_Left = "", "", ",@RPTIncome_Left= N'" & _mRPTIncome_Left & "' ") & _
            IIf(_mRPTIncome_Top = "", "", ",@RPTIncome_Top= N'" & _mRPTIncome_Top & "' ") & _
            IIf(_mRPTIncomeComputation_Left = "", "", ",@RPTIncomeComputation_Left= N'" & _mRPTIncomeComputation_Left & "' ") & _
            IIf(_mRPTIncomeComputation_Top = "", "", ",@RPTIncomeComputation_Top= N'" & _mRPTIncomeComputation_Top & "' ") & _
            IIf(_mSRS_Left = "", "", ",@SRS_Left= N'" & _mSRS_Left & "' ") & _
            IIf(_mSRS_Top = "", "", ",@SRS_Top= N'" & _mSRS_Top & "' ") & _
            IIf(_mTaxAmount_Left = "", "", ",@TaxAmount_Left= N'" & _mTaxAmount_Left & "' ") & _
            IIf(_mTaxAmount_Top = "", "", ",@TaxAmount_Top= N'" & _mTaxAmount_Top & "' ") & _
            IIf(_mTIN_Left = "", "", ",@TIN_Left= N'" & _mTIN_Left & "' ") & _
            IIf(_mTIN_Top = "", "", ",@TIN_Top= N'" & _mTIN_Top & "' ") & _
            IIf(_mTotAmount_Left = "", "", ",@TotAmount_Left= N'" & _mTotAmount_Left & "' ") & _
            IIf(_mTotAmount_Top = "", "", ",@TotAmount_Top= N'" & _mTotAmount_Top & "' ") & _
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

            _nStrSql = " EXEC [sp_StpCtcCorp_IUD] " & _
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

                    If IsDBNull(_nSqlDr.Item("CompanyName_Left").ToString) Then
                        _mCompanyName_Left = ""
                    Else
                        _mCompanyName_Left = UCase(_nSqlDr.Item("CompanyName_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("CompanyName_Top").ToString) Then
                        _mCompanyName_Top = ""
                    Else
                        _mCompanyName_Top = UCase(_nSqlDr.Item("CompanyName_Top").ToString)
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

                    If IsDBNull(_nSqlDr.Item("DateofIncorporation_Left").ToString) Then
                        _mDateofIncorporation_Left = ""
                    Else
                        _mDateofIncorporation_Left = UCase(_nSqlDr.Item("DateofIncorporation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DateofIncorporation_Top").ToString) Then
                        _mDateofIncorporation_Top = ""
                    Else
                        _mDateofIncorporation_Top = UCase(_nSqlDr.Item("DateofIncorporation_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DelFee_Left").ToString) Then
                        _mDelFee_Left = ""
                    Else
                        _mDelFee_Left = UCase(_nSqlDr.Item("DelFee_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DelFee_Top").ToString) Then
                        _mDelFee_Top = ""
                    Else
                        _mDelFee_Top = UCase(_nSqlDr.Item("DelFee_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LGUProfile_Left").ToString) Then
                        _mLGUProfile_Left = ""
                    Else
                        _mLGUProfile_Left = UCase(_nSqlDr.Item("LGUProfile_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LGUProfile_Top").ToString) Then
                        _mLGUProfile_Top = ""
                    Else
                        _mLGUProfile_Top = UCase(_nSqlDr.Item("LGUProfile_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Or_Number_Left").ToString) Then
                        _mOr_Number_Left = ""
                    Else
                        _mOr_Number_Left = UCase(_nSqlDr.Item("Or_Number_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Or_Number_Top").ToString) Then
                        _mOr_Number_Top = ""
                    Else
                        _mOr_Number_Top = UCase(_nSqlDr.Item("Or_Number_Top").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("OrgKind_Left").ToString) Then
                        _mOrgKind_Left = ""
                    Else
                        _mOrgKind_Left = UCase(_nSqlDr.Item("OrgKind_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("OrgKind_Top").ToString) Then
                        _mOrgKind_Top = ""
                    Else
                        _mOrgKind_Top = UCase(_nSqlDr.Item("OrgKind_Top").ToString)
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

                    If IsDBNull(_nSqlDr.Item("PlaceofIncorporation_Left").ToString) Then
                        _mPlaceofIncorporation_Left = ""
                    Else
                        _mPlaceofIncorporation_Left = UCase(_nSqlDr.Item("PlaceofIncorporation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("PlaceofIncorporation_Top").ToString) Then
                        _mPlaceofIncorporation_Top = ""
                    Else
                        _mPlaceofIncorporation_Top = UCase(_nSqlDr.Item("PlaceofIncorporation_Top").ToString)
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

                    If IsDBNull(_nSqlDr.Item("RPTIncomeComputation_Left").ToString) Then
                        _mRPTIncomeComputation_Left = ""
                    Else
                        _mRPTIncomeComputation_Left = UCase(_nSqlDr.Item("RPTIncomeComputation_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("RPTIncomeComputation_Top").ToString) Then
                        _mRPTIncomeComputation_Top = ""
                    Else
                        _mRPTIncomeComputation_Top = UCase(_nSqlDr.Item("RPTIncomeComputation_Top").ToString)
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

                    If IsDBNull(_nSqlDr.Item("TotAmount_Left").ToString) Then
                        _mTotAmount_Left = ""
                    Else
                        _mTotAmount_Left = UCase(_nSqlDr.Item("TotAmount_Left").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TotAmount_Top").ToString) Then
                        _mTotAmount_Top = ""
                    Else
                        _mTotAmount_Top = UCase(_nSqlDr.Item("TotAmount_Top").ToString)
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


            _nStrSql = " EXEC [sp_StpCtcCorp_IUD] @Action = 'UPDATE'" & _
                        IIf(_mAddress_Left = "", "", ",@Address_Left= N'" & _mAddress_Left & "' ") & _
                        IIf(_mAddress_Top = "", "", ",@Address_Top= N'" & _mAddress_Top & "' ") & _
                        IIf(_mBasicAmount_Left = "", "", ",@BasicAmount_Left= N'" & _mBasicAmount_Left & "' ") & _
                        IIf(_mBasicAmount_Top = "", "", ",@BasicAmount_Top= N'" & _mBasicAmount_Top & "' ") & _
                        IIf(_mBusIncome_Left = "", "", ",@BusIncome_Left= N'" & _mBusIncome_Left & "' ") & _
                        IIf(_mBusIncome_Top = "", "", ",@BusIncome_Top= N'" & _mBusIncome_Top & "' ") & _
                        IIf(_mBusIncomeComputation_Left = "", "", ",@BusIncomeComputation_Left= N'" & _mBusIncomeComputation_Left & "' ") & _
                        IIf(_mBusIncomeComputation_Top = "", "", ",@BusIncomeComputation_Top= N'" & _mBusIncomeComputation_Top & "' ") & _
                        IIf(_mCompanyName_Left = "", "", ",@CompanyName_Left= N'" & _mCompanyName_Left & "' ") & _
                        IIf(_mCompanyName_Top = "", "", ",@CompanyName_Top= N'" & _mCompanyName_Top & "' ") & _
                        IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                        IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                        IIf(_mDateofIncorporation_Left = "", "", ",@DateofIncorporation_Left= N'" & _mDateofIncorporation_Left & "' ") & _
                        IIf(_mDateofIncorporation_Top = "", "", ",@DateofIncorporation_Top= N'" & _mDateofIncorporation_Top & "' ") & _
                        IIf(_mDelFee_Left = "", "", ",@DelFee_Left= N'" & _mDelFee_Left & "' ") & _
                        IIf(_mDelFee_Top = "", "", ",@DelFee_Top= N'" & _mDelFee_Top & "' ") & _
                        IIf(_mLGUProfile_Left = "", "", ",@LGUProfile_Left= N'" & _mLGUProfile_Left & "' ") & _
                        IIf(_mLGUProfile_Top = "", "", ",@LGUProfile_Top= N'" & _mLGUProfile_Top & "' ") & _
                        IIf(_mOr_Number_Left = "", "", ",@Or_Number_Left= N'" & _mOr_Number_Left & "' ") & _
                        IIf(_mOr_Number_Top = "", "", ",@Or_Number_Top= N'" & _mOr_Number_Top & "' ") & _
                        IIf(_mOrgKind_Left = "", "", ",@OrgKind_Left= N'" & _mOrgKind_Left & "' ") & _
                        IIf(_mOrgKind_Top = "", "", ",@OrgKind_Top= N'" & _mOrgKind_Top & "' ") & _
                        IIf(_mPenalty_Left = "", "", ",@Penalty_Left= N'" & _mPenalty_Left & "' ") & _
                        IIf(_mPenalty_Top = "", "", ",@Penalty_Top= N'" & _mPenalty_Top & "' ") & _
                        IIf(_mPlaceofIncorporation_Left = "", "", ",@PlaceofIncorporation_Left= N'" & _mPlaceofIncorporation_Left & "' ") & _
                        IIf(_mPlaceofIncorporation_Top = "", "", ",@PlaceofIncorporation_Top= N'" & _mPlaceofIncorporation_Top & "' ") & _
                        IIf(_mRPTIncome_Left = "", "", ",@RPTIncome_Left= N'" & _mRPTIncome_Left & "' ") & _
                        IIf(_mRPTIncome_Top = "", "", ",@RPTIncome_Top= N'" & _mRPTIncome_Top & "' ") & _
                        IIf(_mRPTIncomeComputation_Left = "", "", ",@RPTIncomeComputation_Left= N'" & _mRPTIncomeComputation_Left & "' ") & _
                        IIf(_mRPTIncomeComputation_Top = "", "", ",@RPTIncomeComputation_Top= N'" & _mRPTIncomeComputation_Top & "' ") & _
                        IIf(_mSRS_Left = "", "", ",@SRS_Left= N'" & _mSRS_Left & "' ") & _
                        IIf(_mSRS_Top = "", "", ",@SRS_Top= N'" & _mSRS_Top & "' ") & _
                        IIf(_mTaxAmount_Left = "", "", ",@TaxAmount_Left= N'" & _mTaxAmount_Left & "' ") & _
                        IIf(_mTaxAmount_Top = "", "", ",@TaxAmount_Top= N'" & _mTaxAmount_Top & "' ") & _
                        IIf(_mTIN_Left = "", "", ",@TIN_Left= N'" & _mTIN_Left & "' ") & _
                        IIf(_mTIN_Top = "", "", ",@TIN_Top= N'" & _mTIN_Top & "' ") & _
                        IIf(_mTotAmount_Left = "", "", ",@TotAmount_Left= N'" & _mTotAmount_Left & "' ") & _
                        IIf(_mTotAmount_Top = "", "", ",@TotAmount_Top= N'" & _mTotAmount_Top & "' ") & _
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


            _nStrSql = " EXEC [sp_StpCtcCorp_IUD] @Action = 'INSERT'" & _
                                IIf(_mAddress_Left = "", "", ",@Address_Left= N'" & _mAddress_Left & "' ") & _
                                IIf(_mAddress_Top = "", "", ",@Address_Top= N'" & _mAddress_Top & "' ") & _
                                IIf(_mBasicAmount_Left = "", "", ",@BasicAmount_Left= N'" & _mBasicAmount_Left & "' ") & _
                                IIf(_mBasicAmount_Top = "", "", ",@BasicAmount_Top= N'" & _mBasicAmount_Top & "' ") & _
                                IIf(_mBusIncome_Left = "", "", ",@BusIncome_Left= N'" & _mBusIncome_Left & "' ") & _
                                IIf(_mBusIncome_Top = "", "", ",@BusIncome_Top= N'" & _mBusIncome_Top & "' ") & _
                                IIf(_mBusIncomeComputation_Left = "", "", ",@BusIncomeComputation_Left= N'" & _mBusIncomeComputation_Left & "' ") & _
                                IIf(_mBusIncomeComputation_Top = "", "", ",@BusIncomeComputation_Top= N'" & _mBusIncomeComputation_Top & "' ") & _
                                IIf(_mCompanyName_Left = "", "", ",@CompanyName_Left= N'" & _mCompanyName_Left & "' ") & _
                                IIf(_mCompanyName_Top = "", "", ",@CompanyName_Top= N'" & _mCompanyName_Top & "' ") & _
                                IIf(_mDateIssued_Left = "", "", ",@DateIssued_Left= N'" & _mDateIssued_Left & "' ") & _
                                IIf(_mDateIssued_Top = "", "", ",@DateIssued_Top= N'" & _mDateIssued_Top & "' ") & _
                                IIf(_mDateofIncorporation_Left = "", "", ",@DateofIncorporation_Left= N'" & _mDateofIncorporation_Left & "' ") & _
                                IIf(_mDateofIncorporation_Top = "", "", ",@DateofIncorporation_Top= N'" & _mDateofIncorporation_Top & "' ") & _
                                IIf(_mDelFee_Left = "", "", ",@DelFee_Left= N'" & _mDelFee_Left & "' ") & _
                                IIf(_mDelFee_Top = "", "", ",@DelFee_Top= N'" & _mDelFee_Top & "' ") & _
                                IIf(_mLGUProfile_Left = "", "", ",@LGUProfile_Left= N'" & _mLGUProfile_Left & "' ") & _
                                IIf(_mLGUProfile_Top = "", "", ",@LGUProfile_Top= N'" & _mLGUProfile_Top & "' ") & _
                                IIf(_mOr_Number_Left = "", "", ",@Or_Number_Left= N'" & _mOr_Number_Left & "' ") & _
                                IIf(_mOr_Number_Top = "", "", ",@Or_Number_Top= N'" & _mOr_Number_Top & "' ") & _
                                IIf(_mOrgKind_Left = "", "", ",@OrgKind_Left= N'" & _mOrgKind_Left & "' ") & _
                                IIf(_mOrgKind_Top = "", "", ",@OrgKind_Top= N'" & _mOrgKind_Top & "' ") & _
                                IIf(_mPenalty_Left = "", "", ",@Penalty_Left= N'" & _mPenalty_Left & "' ") & _
                                IIf(_mPenalty_Top = "", "", ",@Penalty_Top= N'" & _mPenalty_Top & "' ") & _
                                IIf(_mPlaceofIncorporation_Left = "", "", ",@PlaceofIncorporation_Left= N'" & _mPlaceofIncorporation_Left & "' ") & _
                                IIf(_mPlaceofIncorporation_Top = "", "", ",@PlaceofIncorporation_Top= N'" & _mPlaceofIncorporation_Top & "' ") & _
                                IIf(_mRPTIncome_Left = "", "", ",@RPTIncome_Left= N'" & _mRPTIncome_Left & "' ") & _
                                IIf(_mRPTIncome_Top = "", "", ",@RPTIncome_Top= N'" & _mRPTIncome_Top & "' ") & _
                                IIf(_mRPTIncomeComputation_Left = "", "", ",@RPTIncomeComputation_Left= N'" & _mRPTIncomeComputation_Left & "' ") & _
                                IIf(_mRPTIncomeComputation_Top = "", "", ",@RPTIncomeComputation_Top= N'" & _mRPTIncomeComputation_Top & "' ") & _
                                IIf(_mSRS_Left = "", "", ",@SRS_Left= N'" & _mSRS_Left & "' ") & _
                                IIf(_mSRS_Top = "", "", ",@SRS_Top= N'" & _mSRS_Top & "' ") & _
                                IIf(_mTaxAmount_Left = "", "", ",@TaxAmount_Left= N'" & _mTaxAmount_Left & "' ") & _
                                IIf(_mTaxAmount_Top = "", "", ",@TaxAmount_Top= N'" & _mTaxAmount_Top & "' ") & _
                                IIf(_mTIN_Left = "", "", ",@TIN_Left= N'" & _mTIN_Left & "' ") & _
                                IIf(_mTIN_Top = "", "", ",@TIN_Top= N'" & _mTIN_Top & "' ") & _
                                IIf(_mTotAmount_Left = "", "", ",@TotAmount_Left= N'" & _mTotAmount_Left & "' ") & _
                                IIf(_mTotAmount_Top = "", "", ",@TotAmount_Top= N'" & _mTotAmount_Top & "' ") & _
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

