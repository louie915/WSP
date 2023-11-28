#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
#End Region



Public Class cDalBusMastExtn

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing

    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
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

#Region "Variable Field"

    Private _mAdd As Boolean
    Private _mACCTNO As String
    Private _mAUTHO_REP As String
    Private _mAUTHO_REP_POS As String
    Private _mBLDG As String
    Private _mBRGY As String
    Private _mCITY As String
    Private _mDOWNLOADED As String
    Private _mEMAIL As String
    Private _mEMRGNCY_CONTACT As String
    Private _mEMRGNCY_EMAIL As String
    Private _mEMRGNCY_MOBILE As String
    Private _mEMRGNCY_TEL As String
    Private _mFIRSTNAME As String
    Private _mFORYEAR As String
    Private _mIF_WITH_TAX As String
    Private _mLASTNAME As String
    Private _mMIDDLENAME As String
    Private _mNO_EMP_F As String
    Private _mNO_EMP_LGU As String
    Private _mNO_EMP_M As String
    Private _mP_Gender As String
    Private _mP_Treasurer As String
    Private _mPres_FName As String
    Private _mPRES_GENDER As String
    Private _mPres_LName As String
    Private _mPres_MName As String
    Private _mPRES_NAME As String
    Private _mPROVINCE As String
    Private _mRowId As String
    Private _mSTREET As String
    Private _mSUBD As String
    Private _mTAX_INDIC As String
    Private _mTEL As String
    Private _mTREAS_NAME As String
    Private _mUPLOADED As String

#End Region
#Region "Property Field"

    Public Property _pACCTNO() As String
        Get
            Return _mACCTNO
        End Get
        Set(value As String)
            _mACCTNO = value
        End Set
    End Property

    Public Property _pAUTHO_REP() As String
        Get
            Return _mAUTHO_REP
        End Get
        Set(value As String)
            _mAUTHO_REP = value
        End Set
    End Property

    Public Property _pAUTHO_REP_POS() As String
        Get
            Return _mAUTHO_REP_POS
        End Get
        Set(value As String)
            _mAUTHO_REP_POS = value
        End Set
    End Property

    Public Property _pBLDG() As String
        Get
            Return _mBLDG
        End Get
        Set(value As String)
            _mBLDG = value
        End Set
    End Property

    Public Property _pBRGY() As String
        Get
            Return _mBRGY
        End Get
        Set(value As String)
            _mBRGY = value
        End Set
    End Property

    Public Property _pCITY() As String
        Get
            Return _mCITY
        End Get
        Set(value As String)
            _mCITY = value
        End Set
    End Property

    Public Property _pDOWNLOADED() As String
        Get
            Return _mDOWNLOADED
        End Get
        Set(value As String)
            _mDOWNLOADED = value
        End Set
    End Property

    Public Property _pEMAIL() As String
        Get
            Return _mEMAIL
        End Get
        Set(value As String)
            _mEMAIL = value
        End Set
    End Property

    Public Property _pEMRGNCY_CONTACT() As String
        Get
            Return _mEMRGNCY_CONTACT
        End Get
        Set(value As String)
            _mEMRGNCY_CONTACT = value
        End Set
    End Property

    Public Property _pEMRGNCY_EMAIL() As String
        Get
            Return _mEMRGNCY_EMAIL
        End Get
        Set(value As String)
            _mEMRGNCY_EMAIL = value
        End Set
    End Property

    Public Property _pEMRGNCY_MOBILE() As String
        Get
            Return _mEMRGNCY_MOBILE
        End Get
        Set(value As String)
            _mEMRGNCY_MOBILE = value
        End Set
    End Property

    Public Property _pEMRGNCY_TEL() As String
        Get
            Return _mEMRGNCY_TEL
        End Get
        Set(value As String)
            _mEMRGNCY_TEL = value
        End Set
    End Property

    Public Property _pFIRSTNAME() As String
        Get
            Return _mFIRSTNAME
        End Get
        Set(value As String)
            _mFIRSTNAME = value
        End Set
    End Property

    Public Property _pFORYEAR() As String
        Get
            Return _mFORYEAR
        End Get
        Set(value As String)
            _mFORYEAR = value
        End Set
    End Property

    Public Property _pIF_WITH_TAX() As String
        Get
            Return _mIF_WITH_TAX
        End Get
        Set(value As String)
            _mIF_WITH_TAX = value
        End Set
    End Property

    Public Property _pLASTNAME() As String
        Get
            Return _mLASTNAME
        End Get
        Set(value As String)
            _mLASTNAME = value
        End Set
    End Property

    Public Property _pMIDDLENAME() As String
        Get
            Return _mMIDDLENAME
        End Get
        Set(value As String)
            _mMIDDLENAME = value
        End Set
    End Property

    Public Property _pNO_EMP_F() As String
        Get
            Return _mNO_EMP_F
        End Get
        Set(value As String)
            _mNO_EMP_F = value
        End Set
    End Property

    Public Property _pNO_EMP_LGU() As String
        Get
            Return _mNO_EMP_LGU
        End Get
        Set(value As String)
            _mNO_EMP_LGU = value
        End Set
    End Property

    Public Property _pNO_EMP_M() As String
        Get
            Return _mNO_EMP_M
        End Get
        Set(value As String)
            _mNO_EMP_M = value
        End Set
    End Property

    Public Property _pP_Gender() As String
        Get
            Return _mP_Gender
        End Get
        Set(value As String)
            _mP_Gender = value
        End Set
    End Property

    Public Property _pP_Treasurer() As String
        Get
            Return _mP_Treasurer
        End Get
        Set(value As String)
            _mP_Treasurer = value
        End Set
    End Property

    Public Property _pPres_FName() As String
        Get
            Return _mPres_FName
        End Get
        Set(value As String)
            _mPres_FName = value
        End Set
    End Property

    Public Property _pPRES_GENDER() As String
        Get
            Return _mPRES_GENDER
        End Get
        Set(value As String)
            _mPRES_GENDER = value
        End Set
    End Property

    Public Property _pPres_LName() As String
        Get
            Return _mPres_LName
        End Get
        Set(value As String)
            _mPres_LName = value
        End Set
    End Property

    Public Property _pPres_MName() As String
        Get
            Return _mPres_MName
        End Get
        Set(value As String)
            _mPres_MName = value
        End Set
    End Property

    Public Property _pPRES_NAME() As String
        Get
            Return _mPRES_NAME
        End Get
        Set(value As String)
            _mPRES_NAME = value
        End Set
    End Property

    Public Property _pPROVINCE() As String
        Get
            Return _mPROVINCE
        End Get
        Set(value As String)
            _mPROVINCE = value
        End Set
    End Property

    Public Property _pRowId() As String
        Get
            Return _mRowId
        End Get
        Set(value As String)
            _mRowId = value
        End Set
    End Property

    Public Property _pSTREET() As String
        Get
            Return _mSTREET
        End Get
        Set(value As String)
            _mSTREET = value
        End Set
    End Property

    Public Property _pSUBD() As String
        Get
            Return _mSUBD
        End Get
        Set(value As String)
            _mSUBD = value
        End Set
    End Property

    Public Property _pTAX_INDIC() As String
        Get
            Return _mTAX_INDIC
        End Get
        Set(value As String)
            _mTAX_INDIC = value
        End Set
    End Property

    Public Property _pTEL() As String
        Get
            Return _mTEL
        End Get
        Set(value As String)
            _mTEL = value
        End Set
    End Property

    Public Property _pTREAS_NAME() As String
        Get
            Return _mTREAS_NAME
        End Get
        Set(value As String)
            _mTREAS_NAME = value
        End Set
    End Property

    Public Property _pUPLOADED() As String
        Get
            Return _mUPLOADED
        End Get
        Set(value As String)
            _mUPLOADED = value
        End Set
    End Property


#End Region


#Region "Routine Data"

    Public Sub _pSubInsert(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            _nSuccessful = True

            Dim _nQuery As String = Nothing
            _nQuery = _
                "INSERT INTO " & _
                "[BUSMASTEXTN] " & _
                "(" & _
                     IIf(String.IsNullOrWhiteSpace(_mACCTNO), "", "[ACCTNO]") & _
                     IIf(String.IsNullOrWhiteSpace(_mPRES_NAME), "", ", [PRES_NAME]") & _
                     IIf(String.IsNullOrWhiteSpace(_mPres_LName), "", ", [Pres_LName]") & _
                     IIf(String.IsNullOrWhiteSpace(_mPres_FName), "", ", [Pres_FName]") & _
                     IIf(String.IsNullOrWhiteSpace(_mPres_MName), "", ", [Pres_MName]") & _
                     IIf(String.IsNullOrWhiteSpace(_mPRES_GENDER), "", ", [Pres_Gender]") & _
                     IIf(String.IsNullOrWhiteSpace(_mTREAS_NAME), "", ", [TREAS_NAME]") & _
                     IIf(String.IsNullOrWhiteSpace(_mAUTHO_REP), "", ", [AUTHO_REP]") & _
                     IIf(String.IsNullOrWhiteSpace(_mAUTHO_REP_POS), "", ", [AUTHO_REP_POS]") & _
                     IIf(String.IsNullOrWhiteSpace(_mNO_EMP_M), "", ", [NO_EMP_M]") & _
                     IIf(String.IsNullOrWhiteSpace(_mNO_EMP_F), "", ", [NO_EMP_F]") & _
                     IIf(String.IsNullOrWhiteSpace(_mTAX_INDIC), "", ", [TAX_INDIC]") & _
                     IIf(String.IsNullOrWhiteSpace(_mIF_WITH_TAX), "", ", [IF_WITH_TAX]") & _
                     IIf(String.IsNullOrWhiteSpace(_mNO_EMP_LGU), "", ", [NO_EMP_LGU]") & _
                     IIf(String.IsNullOrWhiteSpace(_mFIRSTNAME), "", ", [FIRSTNAME]") & _
                     IIf(String.IsNullOrWhiteSpace(_mMIDDLENAME), "", ", [MIDDLENAME]") & _
                     IIf(String.IsNullOrWhiteSpace(_mLASTNAME), "", ", [LASTNAME]") & _
                     IIf(String.IsNullOrWhiteSpace(_mBLDG), "", ", [BLDG]") & _
                     IIf(String.IsNullOrWhiteSpace(_mSTREET), "", ", [STREET]") & _
                     IIf(String.IsNullOrWhiteSpace(_mCITY), "", ", [CITY]") & _
                     IIf(String.IsNullOrWhiteSpace(_mBRGY), "", ", [BRGY]") & _
                     IIf(String.IsNullOrWhiteSpace(_mSUBD), "", ", [SUBD]") & _
                     IIf(String.IsNullOrWhiteSpace(_mPROVINCE), "", ", [PROVINCE]") & _
                     IIf(String.IsNullOrWhiteSpace(_mTEL), "", ", [TEL]") & _
                     IIf(String.IsNullOrWhiteSpace(_mEMAIL), "", ", [EMAIL]") & _
                     IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_CONTACT), "", ", [EMRGNCY_CONTACT]") & _
                     IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_TEL), "", ", [EMRGNCY_TEL]") & _
                     IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_MOBILE), "", ", [EMRGNCY_MOBILE]") & _
                     IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_EMAIL), "", ", [EMRGNCY_EMAIL]") & _
                     IIf(String.IsNullOrWhiteSpace(_mFORYEAR), "", ", [FORYEAR]") & _
                    ") " & _
                    "VALUES " & _
                    "(" & _
                    IIf(String.IsNullOrWhiteSpace(_mACCTNO), "", " @_mACCTNO") & _
                    IIf(String.IsNullOrWhiteSpace(_mPRES_NAME), "", ", @_mPRES_NAME") & _
                    IIf(String.IsNullOrWhiteSpace(_mPres_LName), "", ", @_mPres_LName") & _
                    IIf(String.IsNullOrWhiteSpace(_mPres_FName), "", ", @_mPres_FName") & _
                    IIf(String.IsNullOrWhiteSpace(_mPres_MName), "", ", @_mPres_MName") & _
                    IIf(String.IsNullOrWhiteSpace(_mPRES_GENDER), "", ", @_mPRES_GENDER") & _
                    IIf(String.IsNullOrWhiteSpace(_mTREAS_NAME), "", ", @_mTREAS_NAME") & _
                    IIf(String.IsNullOrWhiteSpace(_mAUTHO_REP), "", ", @_mAUTHO_REP") & _
                    IIf(String.IsNullOrWhiteSpace(_mAUTHO_REP_POS), "", ", @_mAUTHO_REP_POS") & _
                    IIf(String.IsNullOrWhiteSpace(_mNO_EMP_M), "", ", @_mNO_EMP_M") & _
                    IIf(String.IsNullOrWhiteSpace(_mNO_EMP_F), "", ", @_mNO_EMP_F") & _
                    IIf(String.IsNullOrWhiteSpace(_mTAX_INDIC), "", ", @_mTAX_INDIC") & _
                    IIf(String.IsNullOrWhiteSpace(_mIF_WITH_TAX), "", ", @_mIF_WITH_TAX") & _
                    IIf(String.IsNullOrWhiteSpace(_mNO_EMP_LGU), "", ", @_mNO_EMP_LGU") & _
                    IIf(String.IsNullOrWhiteSpace(_mFIRSTNAME), "", ", @_mFIRSTNAME") & _
                    IIf(String.IsNullOrWhiteSpace(_mMIDDLENAME), "", ", @_mMIDDLENAME") & _
                    IIf(String.IsNullOrWhiteSpace(_mLASTNAME), "", ", @_mLASTNAME") & _
                    IIf(String.IsNullOrWhiteSpace(_mBLDG), "", ", @_mBLDG") & _
                    IIf(String.IsNullOrWhiteSpace(_mSTREET), "", ", @_mSTREET") & _
                    IIf(String.IsNullOrWhiteSpace(_mCITY), "", ", @_mCITY") & _
                    IIf(String.IsNullOrWhiteSpace(_mBRGY), "", ", @_mBRGY") & _
                    IIf(String.IsNullOrWhiteSpace(_mSUBD), "", ", @_mSUBD") & _
                    IIf(String.IsNullOrWhiteSpace(_mPROVINCE), "", ", @_mPROVINCE") & _
                    IIf(String.IsNullOrWhiteSpace(_mTEL), "", ", @_mTEL") & _
                    IIf(String.IsNullOrWhiteSpace(_mEMAIL), "", ", @_mEMAIL") & _
                    IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_CONTACT), "", ", @_mEMRGNCY_CONTACT") & _
                    IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_TEL), "", ", @_mEMRGNCY_TEL") & _
                    IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_MOBILE), "", ", @_mEMRGNCY_MOBILE") & _
                    IIf(String.IsNullOrWhiteSpace(_mEMRGNCY_EMAIL), "", ", @_mEMRGNCY_EMAIL") & _
                    IIf(String.IsNullOrWhiteSpace(_mFORYEAR), "", ", @_mFORYEAR") & _
                ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(")

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mACCTNO) Then .AddWithValue("@_mACCTNO", _mACCTNO)
                If Not String.IsNullOrWhiteSpace(_mPRES_NAME) Then .AddWithValue("@_mPRES_NAME", _mPRES_NAME)
                If Not String.IsNullOrWhiteSpace(_mPres_LName) Then .AddWithValue("@_mPres_LName", _mPres_LName)
                If Not String.IsNullOrWhiteSpace(_mPres_FName) Then .AddWithValue("@_mPres_FName", _mPres_FName)
                If Not String.IsNullOrWhiteSpace(_mPres_MName) Then .AddWithValue("@_mPres_MName", _mPres_MName)
                If Not String.IsNullOrWhiteSpace(_mPRES_GENDER) Then .AddWithValue("@_mPRES_GENDER", _mPRES_GENDER)
                If Not String.IsNullOrWhiteSpace(_mTREAS_NAME) Then .AddWithValue("@_mTREAS_NAME", _mTREAS_NAME)
                If Not String.IsNullOrWhiteSpace(_mAUTHO_REP) Then .AddWithValue("@_mAUTHO_REP", _mAUTHO_REP)
                If Not String.IsNullOrWhiteSpace(_mAUTHO_REP_POS) Then .AddWithValue("@_mAUTHO_REP_POS", _mAUTHO_REP_POS)
                If Not String.IsNullOrWhiteSpace(_mNO_EMP_M) Then .AddWithValue("@_mNO_EMP_M", _mNO_EMP_M)
                If Not String.IsNullOrWhiteSpace(_mNO_EMP_F) Then .AddWithValue("@_mNO_EMP_F", _mNO_EMP_F)
                If Not String.IsNullOrWhiteSpace(_mTAX_INDIC) Then .AddWithValue("@_mTAX_INDIC", _mTAX_INDIC)
                If Not String.IsNullOrWhiteSpace(_mIF_WITH_TAX) Then .AddWithValue("@_mIF_WITH_TAX", _mIF_WITH_TAX)
                If Not String.IsNullOrWhiteSpace(_mNO_EMP_LGU) Then .AddWithValue("@_mNO_EMP_LGU", _mNO_EMP_LGU)
                If Not String.IsNullOrWhiteSpace(_mFIRSTNAME) Then .AddWithValue("@_mFIRSTNAME", _mFIRSTNAME)
                If Not String.IsNullOrWhiteSpace(_mMIDDLENAME) Then .AddWithValue("@_mMIDDLENAME", _mMIDDLENAME)
                If Not String.IsNullOrWhiteSpace(_mLASTNAME) Then .AddWithValue("@_mLASTNAME", _mLASTNAME)
                If Not String.IsNullOrWhiteSpace(_mBLDG) Then .AddWithValue("@_mBLDG", _mBLDG)
                If Not String.IsNullOrWhiteSpace(_mSTREET) Then .AddWithValue("@_mSTREET", _mSTREET)
                If Not String.IsNullOrWhiteSpace(_mCITY) Then .AddWithValue("@_mCITY", _mCITY)
                If Not String.IsNullOrWhiteSpace(_mBRGY) Then .AddWithValue("@_mBRGY", _mBRGY)
                If Not String.IsNullOrWhiteSpace(_mSUBD) Then .AddWithValue("@_mSUBD", _mSUBD)
                If Not String.IsNullOrWhiteSpace(_mPROVINCE) Then .AddWithValue("@_mPROVINCE", _mPROVINCE)
                If Not String.IsNullOrWhiteSpace(_mTEL) Then .AddWithValue("@_mTEL", _mTEL)
                If Not String.IsNullOrWhiteSpace(_mEMAIL) Then .AddWithValue("@_mEMAIL", _mEMAIL)
                If Not String.IsNullOrWhiteSpace(_mEMRGNCY_CONTACT) Then .AddWithValue("@_mEMRGNCY_CONTACT", _mEMRGNCY_CONTACT)
                If Not String.IsNullOrWhiteSpace(_mEMRGNCY_TEL) Then .AddWithValue("@_mEMRGNCY_TEL", _mEMRGNCY_TEL)
                If Not String.IsNullOrWhiteSpace(_mEMRGNCY_MOBILE) Then .AddWithValue("@_mEMRGNCY_MOBILE", _mEMRGNCY_MOBILE)
                If Not String.IsNullOrWhiteSpace(_mEMRGNCY_EMAIL) Then .AddWithValue("@_mEMRGNCY_EMAIL", _mEMRGNCY_EMAIL)
                If Not String.IsNullOrWhiteSpace(_mFORYEAR) Then .AddWithValue("@_mFORYEAR", _mFORYEAR)
            End With
            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            _nSuccessful = False
            _nErrMsg = ex.Message
        End Try
    End Sub

#End Region

End Class
