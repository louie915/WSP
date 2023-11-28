

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext


#End Region

Public Class cDalNewBP

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
    Private Const _sscPrefix As String = "cDalNewBP."
    Private Const _sscApplication_ID As String = _sscPrefix & "_sscApplication_ID"
    Private Const _sscUserID As String = _sscPrefix & "_sscUserID"
    Private Const _sscDate_Esta As String = _sscPrefix & "_sscDate_Esta"
    Private Const _sscA_Ownership As String = _sscPrefix & "_sscA_Ownership"
    Private Const _sscA_OWNCODE As String = _sscPrefix & "_sscA_OWNCODE"
    Private Const _sscA_DtiSecCda As String = _sscPrefix & "_sscA_DtiSecCda"
    Private Const _sscA_BusName As String = _sscPrefix & "_sscA_BusName"
    Private Const _sscA_TIN As String = _sscPrefix & "_sscA_TIN"

    Private Const _sscB_HouseNo As String = _sscPrefix & "_sscB_HouseNo"
    Private Const _sscB_BldgName As String = _sscPrefix & "_sscB_BldgName"
    Private Const _sscB_LotNo As String = _sscPrefix & "_sscB_LotNo"
    Private Const _sscB_BlockNo As String = _sscPrefix & "_sscB_BlockNo"
    Private Const _sscB_Street As String = _sscPrefix & "_sscB_Street"
    Private Const _sscB_STRTCODE As String = _sscPrefix & "_sscB_STRTCODE"
    Private Const _sscB_Brgy As String = _sscPrefix & "_sscB_Brgy"
    Private Const _sscB_BRGYCODE As String = _sscPrefix & "_sscB_BRGYCODE"
    Private Const _sscB_DISTCODE As String = _sscPrefix & "_sscB_DISTCODE"
    Private Const _sscB_Subd As String = _sscPrefix & "_sscB_Subd"
    Private Const _sscB_CityMunicipality As String = _sscPrefix & "_sscB_CityMunicipality"
    Private Const _sscB_Province As String = _sscPrefix & "_sscB_Province"
    Private Const _sscB_ZipCode As String = _sscPrefix & "_sscB_ZipCode"

    Private Const _sscC_TelNo As String = _sscPrefix & "_sscC_TelNo"
    Private Const _sscC_MobileNo As String = _sscPrefix & "_sscC_MobileNo"
    Private Const _sscC_Email As String = _sscPrefix & "_sscC_Email"

    Private Const _sscD_Lname As String = _sscPrefix & "_sscD_Lname"
    Private Const _sscD_Fname As String = _sscPrefix & "_sscD_Fname"
    Private Const _sscD_Mname As String = _sscPrefix & "_sscD_Mname"
    Private Const _sscD_Suffix As String = _sscPrefix & "_sscD_Suffix"
    Private Const _sscD_CTZNDESC As String = _sscPrefix & "_sscD_CTZNDESC"
    Private Const _sscD_CTZNCODE As String = _sscPrefix & "_sscD_CTZNCODE"

    Private Const _sscE_Lname As String = _sscPrefix & "_sscE_Lname"
    Private Const _sscE_Fname As String = _sscPrefix & "_sscE_Fname"
    Private Const _sscE_Mname As String = _sscPrefix & "_sscE_Mname"
    Private Const _sscE_Suffix As String = _sscPrefix & "_sscE_Suffix"
    Private Const _sscE_Nationality As String = _sscPrefix & "_sscE_Nationality"

    Private Const _sscF_BusArea As String = _sscPrefix & "_sscF_BusArea"
    Private Const _sscF_FlrArea As String = _sscPrefix & "_sscF_FlrArea"
    Private Const _sscF_MaleEmpNo As String = _sscPrefix & "_sscF_MaleEmpNo"
    Private Const _sscF_FemaleEmpNo As String = _sscPrefix & "_sscF_FemaleEmpNo"
    Private Const _sscF_ResideEmpNo As String = _sscPrefix & "_sscF_ResideEmpNo"
    Private Const _sscF_VanTruckNo As String = _sscPrefix & "_sscF_VanTruckNo"
    Private Const _sscF_MotorNo As String = _sscPrefix & "_sscF_MotorNo"

    Private Const _sscG_HouseNo As String = _sscPrefix & "_sscG_HouseNo"
    Private Const _sscG_BldgName As String = _sscPrefix & "_sscG_BldgName"
    Private Const _sscG_LotNo As String = _sscPrefix & "_sscG_LotNo"
    Private Const _sscG_BlockNo As String = _sscPrefix & "_sscG_BlockNo"
    Private Const _sscG_Street As String = _sscPrefix & "_sscG_Street"
    Private Const _sscG_Brgy As String = _sscPrefix & "_sscG_Brgy"
    Private Const _sscG_Subd As String = _sscPrefix & "_sscG_Subd"
    Private Const _sscG_CityMunicipality As String = _sscPrefix & "_sscG_CityMunicipality"
    Private Const _sscG_Province As String = _sscPrefix & "_sscG_Province"
    Private Const _sscG_ZipCode As String = _sscPrefix & "_sscG_ZipCode"

    Private Const _sscH_Capital As String = _sscPrefix & "_sscH_Capital"
    Private Const _sscH_Nature As String = _sscPrefix & "_sscH_Nature"
    Private Const _sscH_Owned As String = _sscPrefix & "_sscH_Owned"
    Private Const _sscH_TDN As String = _sscPrefix & "_sscH_TDN"
    Private Const _sscH_PIN As String = _sscPrefix & "_sscH_PIN"
    Private Const _sscH_GovIncentive As String = _sscPrefix & "_sscH_GovIncentive"
    Private Const _sscH_BusAct As String = _sscPrefix & "_sscH_BusAct"

    Private Const _sscSubmitted As String = _sscPrefix & "_sscSubmitted"
    Private Const _sscDate_Created As String = _sscPrefix & "_sscDate_Created"
    Private Const _sscDate_LastEdit As String = _sscPrefix & "_sscDate_LastEdit"
    Private Const _sscDate_Submitted As String = _sscPrefix & "_sscDate_Submitted"
    Private Const _sscStatus As String = _sscPrefix & "_sscStatus"

#End Region

#Region "Properties Field"
    Shared Property H_Capital() As String
        Get
            Return Current.Session(_sscH_Capital)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_Capital) = value
        End Set
    End Property

    Shared Property H_Nature() As String
        Get
            Return Current.Session(_sscH_Nature)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_Nature) = value
        End Set
    End Property

    Shared Property H_Owned() As String
        Get
            Return Current.Session(_sscH_Owned)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_Owned) = value
        End Set
    End Property

    Shared Property H_TDN() As String
        Get
            Return Current.Session(_sscH_TDN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_TDN) = value
        End Set
    End Property

    Shared Property H_PIN() As String
        Get
            Return Current.Session(_sscH_PIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_PIN) = value
        End Set
    End Property

    Shared Property H_GovIncentive() As String
        Get
            Return Current.Session(_sscH_GovIncentive)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_GovIncentive) = value
        End Set
    End Property

    Shared Property H_BusAct() As String
        Get
            Return Current.Session(_sscH_BusAct)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_BusAct) = value
        End Set
    End Property

    Shared Property Submitted() As Boolean
        Get
            Return Current.Session(_sscSubmitted)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscSubmitted) = value
        End Set
    End Property

    Shared Property Date_Created() As DateTime
        Get
            Return Current.Session(_sscDate_Created)
        End Get
        Set(ByVal value As DateTime)
            Current.Session(_sscDate_Created) = value
        End Set
    End Property

    Shared Property Date_LastEdit() As DateTime
        Get
            Return Current.Session(_sscDate_LastEdit)
        End Get
        Set(ByVal value As DateTime)
            Current.Session(_sscDate_LastEdit) = value
        End Set
    End Property

    Shared Property Date_Submitted() As DateTime
        Get
            Return Current.Session(_sscDate_Submitted)
        End Get
        Set(ByVal value As DateTime)
            Current.Session(_sscDate_Submitted) = value
        End Set
    End Property

    Shared Property Status() As String
        Get
            Return Current.Session(_sscStatus)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscStatus) = value
        End Set
    End Property

    Shared Property G_HouseNo() As String
        Get
            Return Current.Session(_sscG_HouseNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_HouseNo) = value
        End Set
    End Property

    Shared Property G_BldgName() As String
        Get
            Return Current.Session(_sscG_BldgName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_BldgName) = value
        End Set
    End Property

    Shared Property G_LotNo() As String
        Get
            Return Current.Session(_sscG_LotNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_LotNo) = value
        End Set
    End Property

    Shared Property G_BlockNo() As String
        Get
            Return Current.Session(_sscG_BlockNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_BlockNo) = value
        End Set
    End Property

    Shared Property G_Street() As String
        Get
            Return Current.Session(_sscG_Street)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Street) = value
        End Set
    End Property

    Shared Property G_Brgy() As String
        Get
            Return Current.Session(_sscG_Brgy)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Brgy) = value
        End Set
    End Property

    Shared Property G_Subd() As String
        Get
            Return Current.Session(_sscG_Subd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Subd) = value
        End Set
    End Property

    Shared Property G_CityMunicipality() As String
        Get
            Return Current.Session(_sscG_CityMunicipality)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_CityMunicipality) = value
        End Set
    End Property

    Shared Property G_Province() As String
        Get
            Return Current.Session(_sscG_Province)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Province) = value
        End Set
    End Property

    Shared Property G_ZipCode() As String
        Get
            Return Current.Session(_sscG_ZipCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_ZipCode) = value
        End Set
    End Property

    Shared Property F_MotorNo() As String
        Get
            Return Current.Session(_sscF_MotorNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_MotorNo) = value
        End Set
    End Property
    Shared Property F_VanTruckNo() As String
        Get
            Return Current.Session(_sscF_VanTruckNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_VanTruckNo) = value
        End Set
    End Property
    Shared Property F_ResideEmpNo() As String
        Get
            Return Current.Session(_sscF_ResideEmpNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_ResideEmpNo) = value
        End Set
    End Property
    Shared Property F_FemaleEmpNo() As String
        Get
            Return Current.Session(_sscF_FemaleEmpNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_FemaleEmpNo) = value
        End Set
    End Property
    Shared Property F_MaleEmpNo() As String
        Get
            Return Current.Session(_sscF_MaleEmpNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_MaleEmpNo) = value
        End Set
    End Property

    Shared Property F_FlrArea() As String
        Get
            Return Current.Session(_sscF_FlrArea)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_FlrArea) = value
        End Set
    End Property
    Shared Property F_BusArea() As String
        Get
            Return Current.Session(_sscF_BusArea)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_BusArea) = value
        End Set
    End Property
    Shared Property E_Nationality() As String
        Get
            Return Current.Session(_sscE_Nationality)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Nationality) = value
        End Set
    End Property
    Shared Property E_Suffix() As String
        Get
            Return Current.Session(_sscE_Suffix)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Suffix) = value
        End Set
    End Property
    Shared Property E_Mname() As String
        Get
            Return Current.Session(_sscE_Mname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Mname) = value
        End Set
    End Property
    Shared Property E_Fname() As String
        Get
            Return Current.Session(_sscE_Fname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Fname) = value
        End Set
    End Property
    Shared Property E_Lname() As String
        Get
            Return Current.Session(_sscE_Lname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Lname) = value
        End Set
    End Property
    Shared Property D_CTZNCODE() As String
        Get
            Return Current.Session(_sscD_CTZNCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_CTZNCODE) = value
        End Set
    End Property
    Shared Property D_CTZNDESC() As String
        Get
            Return Current.Session(_sscD_CTZNDESC)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_CTZNDESC) = value
        End Set
    End Property
    Shared Property D_Suffix() As String
        Get
            Return Current.Session(_sscD_Suffix)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Suffix) = value
        End Set
    End Property

    Shared Property D_Mname() As String
        Get
            Return Current.Session(_sscD_Mname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Mname) = value
        End Set
    End Property

    Shared Property D_Fname() As String
        Get
            Return Current.Session(_sscD_Fname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Fname) = value
        End Set
    End Property


    Shared Property D_Lname() As String
        Get
            Return Current.Session(_sscD_Lname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Lname) = value
        End Set
    End Property

    Shared Property C_Email() As String
        Get
            Return Current.Session(_sscC_Email)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscC_Email) = value
        End Set
    End Property
    Shared Property C_MobileNo() As String
        Get
            Return Current.Session(_sscC_MobileNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscC_MobileNo) = value
        End Set
    End Property
    Shared Property C_TelNo() As String
        Get
            Return Current.Session(_sscC_TelNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscC_TelNo) = value
        End Set
    End Property
    Shared Property B_ZipCode() As String
        Get
            Return Current.Session(_sscB_ZipCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_ZipCode) = value
        End Set
    End Property
    Shared Property B_Province() As String
        Get
            Return Current.Session(_sscB_Province)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Province) = value
        End Set
    End Property
    Shared Property B_CityMunicipality() As String
        Get
            Return Current.Session(_sscB_CityMunicipality)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_CityMunicipality) = value
        End Set
    End Property
    Shared Property B_Subd() As String
        Get
            Return Current.Session(_sscB_Subd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Subd) = value
        End Set
    End Property
    Shared Property B_DISTCODE() As String
        Get
            Return Current.Session(_sscB_DISTCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_DISTCODE) = value
        End Set
    End Property
    Shared Property B_BRGYCODE() As String
        Get
            Return Current.Session(_sscB_BRGYCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_BRGYCODE) = value
        End Set
    End Property
    Shared Property B_Brgy() As String
        Get
            Return Current.Session(_sscB_Brgy)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Brgy) = value
        End Set
    End Property
    Shared Property B_STRTCODE() As String
        Get
            Return Current.Session(_sscB_STRTCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_STRTCODE) = value
        End Set
    End Property
    Shared Property B_Street() As String
        Get
            Return Current.Session(_sscB_Street)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Street) = value
        End Set
    End Property
    Shared Property B_BlockNo() As String
        Get
            Return Current.Session(_sscB_BlockNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_BlockNo) = value
        End Set
    End Property
    Shared Property B_LotNo() As String
        Get
            Return Current.Session(_sscB_LotNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_LotNo) = value
        End Set
    End Property
    Shared Property B_BldgName() As String
        Get
            Return Current.Session(_sscB_BldgName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_BldgName) = value
        End Set
    End Property
    Shared Property B_HouseNo() As String
        Get
            Return Current.Session(_sscB_HouseNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_HouseNo) = value
        End Set
    End Property
    Shared Property A_TIN() As String
        Get
            Return Current.Session(_sscA_TIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_TIN) = value
        End Set
    End Property
    Shared Property A_BusName() As String
        Get
            Return Current.Session(_sscA_BusName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_BusName) = value
        End Set
    End Property
    Shared Property A_DtiSecCda() As String
        Get
            Return Current.Session(_sscA_DtiSecCda)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_DtiSecCda) = value
        End Set
    End Property
    Shared Property A_OWNCODE() As String
        Get
            Return Current.Session(_sscA_OWNCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_OWNCODE) = value
        End Set
    End Property
    Shared Property A_Ownership() As String
        Get
            Return Current.Session(_sscA_Ownership)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_Ownership) = value
        End Set
    End Property
    Shared Property Date_Esta() As String
        Get
            Return Current.Session(_sscDate_Esta)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDate_Esta) = value
        End Set
    End Property
    Shared Property UserID() As String
        Get
            Return Current.Session(_sscUserID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUserID) = value
        End Set
    End Property
    Shared Property Application_ID() As String
        Get
            Return Current.Session(_sscApplication_ID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscApplication_ID) = value
        End Set
    End Property
#End Region


#Region "Routine Command"

    Public Sub _pSubDisplayInfo(ByVal AppID As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from NewBP_Draft where userID = '" & cSessionUser._pUserID & "'" & _
                      " and Application_ID='" & AppID & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplication_ID As Integer = .GetOrdinal("Application_ID")
                    Dim _iUserID As Integer = .GetOrdinal("UserID")
                    Dim _iDate_Esta As Integer = .GetOrdinal("Date_Esta")
                    Dim _iA_Ownership As Integer = .GetOrdinal("A_Ownership")
                    Dim _iA_OWNCODE As Integer = .GetOrdinal("A_OWNCODE")
                    Dim _iA_DtiSecCda As Integer = .GetOrdinal("A_DtiSecCda")
                    Dim _iA_BusName As Integer = .GetOrdinal("A_BusName")
                    Dim _iA_TIN As Integer = .GetOrdinal("A_TIN")
                    Dim _iB_HouseNo As Integer = .GetOrdinal("B_HouseNo")
                    Dim _iB_BldgName As Integer = .GetOrdinal("B_BldgName")
                    Dim _iB_LotNo As Integer = .GetOrdinal("B_LotNo")
                    Dim _iB_BlockNo As Integer = .GetOrdinal("B_BlockNo")
                    Dim _iB_Street As Integer = .GetOrdinal("B_Street")
                    Dim _iB_STRTCODE As Integer = .GetOrdinal("B_STRTCODE")
                    Dim _iB_Brgy As Integer = .GetOrdinal("B_Brgy")
                    Dim _iB_BRGYCODE As Integer = .GetOrdinal("B_BRGYCODE")
                    Dim _iB_DISTCODE As Integer = .GetOrdinal("B_DISTCODE")
                    Dim _iB_Subd As Integer = .GetOrdinal("B_Subd")
                    Dim _iB_CityMunicipality As Integer = .GetOrdinal("B_CityMunicipality")
                    Dim _iB_Province As Integer = .GetOrdinal("B_Province")
                    Dim _iB_ZipCode As Integer = .GetOrdinal("B_ZipCode")
                    Dim _iC_TelNo As Integer = .GetOrdinal("C_TelNo")
                    Dim _iC_MobileNo As Integer = .GetOrdinal("C_MobileNo")

                    Dim _iD_Lname As Integer = .GetOrdinal("D_Lname")
                    Dim _iD_Fname As Integer = .GetOrdinal("D_Fname")
                    Dim _iD_Mname As Integer = .GetOrdinal("D_Mname")
                    Dim _iD_Suffix As Integer = .GetOrdinal("D_Suffix")
                    Dim _iD_CTZNDESC As Integer = .GetOrdinal("D_CTZNDESC")
                    Dim _iD_CTZNCODE As Integer = .GetOrdinal("D_CTZNCODE")
                    Dim _iE_Lname As Integer = .GetOrdinal("E_Lname")
                    Dim _iE_Fname As Integer = .GetOrdinal("E_Fname")
                    Dim _iE_Mname As Integer = .GetOrdinal("E_Mname")
                    Dim _iE_Suffix As Integer = .GetOrdinal("E_Suffix")
                    Dim _iE_Nationality As Integer = .GetOrdinal("E_Nationality")
                    Dim _iF_BusArea As Integer = .GetOrdinal("F_BusArea")
                    Dim _iF_FlrArea As Integer = .GetOrdinal("F_FlrArea")
                    Dim _iF_MaleEmpNo As Integer = .GetOrdinal("F_MaleEmpNo")
                    Dim _iF_FemaleEmpNo As Integer = .GetOrdinal("F_FemaleEmpNo")
                    Dim _iF_ResideEmpNo As Integer = .GetOrdinal("F_ResideEmpNo")
                    Dim _iF_VanTruckNo As Integer = .GetOrdinal("F_VanTruckNo")
                    Dim _iF_MotorNo As Integer = .GetOrdinal("F_MotorNo")
                    Dim _iG_HouseNo As Integer = .GetOrdinal("G_HouseNo")
                    Dim _iG_BldgName As Integer = .GetOrdinal("G_BldgName")
                    Dim _iG_LotNo As Integer = .GetOrdinal("G_LotNo")
                    Dim _iG_BlockNo As Integer = .GetOrdinal("G_BlockNo")
                    Dim _iG_Street As Integer = .GetOrdinal("G_Street")
                    Dim _iG_Brgy As Integer = .GetOrdinal("G_Brgy")
                    Dim _iG_Subd As Integer = .GetOrdinal("G_Subd")
                    Dim _iG_CityMunicipality As Integer = .GetOrdinal("G_CityMunicipality")
                    Dim _iG_Province As Integer = .GetOrdinal("G_Province")
                    Dim _iG_ZipCode As Integer = .GetOrdinal("G_ZipCode")
                    Dim _iH_Capital As Integer = .GetOrdinal("H_Capital")
                    Dim _iH_Nature As Integer = .GetOrdinal("H_Nature")
                    Dim _iH_Owned As Integer = .GetOrdinal("H_Owned")
                    Dim _iH_TDN As Integer = .GetOrdinal("H_TDN")
                    Dim _iH_PIN As Integer = .GetOrdinal("H_PIN")
                    Dim _iH_GovIncentive As Integer = .GetOrdinal("H_GovIncentive")
                    Dim _iH_BusAct As Integer = .GetOrdinal("H_BusAct")
                    Dim _iSubmitted As Integer = .GetOrdinal("Submitted")
                    Dim _iStatus As Integer = .GetOrdinal("Status")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Application_ID = _nSqlDataReader(_iApplication_ID).ToString
                                Date_Esta = _nSqlDataReader(_iDate_Esta)
                                A_Ownership = _nSqlDataReader(_iA_Ownership).ToString
                                A_OWNCODE = _nSqlDataReader(_iA_OWNCODE).ToString
                                A_DtiSecCda = _nSqlDataReader(_iA_DtiSecCda).ToString
                                A_BusName = _nSqlDataReader(_iA_BusName).ToString
                                A_TIN = _nSqlDataReader(_iA_TIN).ToString

                                B_HouseNo = _nSqlDataReader(_iB_HouseNo).ToString
                                B_BldgName = _nSqlDataReader(_iB_BldgName).ToString
                                B_LotNo = _nSqlDataReader(_iB_LotNo).ToString
                                B_BlockNo = _nSqlDataReader(_iB_BlockNo).ToString
                                B_Street = _nSqlDataReader(_iB_Street).ToString
                                B_STRTCODE = _nSqlDataReader(_iB_STRTCODE).ToString
                                B_Brgy = _nSqlDataReader(_iB_Brgy).ToString
                                B_BRGYCODE = _nSqlDataReader(_iB_BRGYCODE).ToString
                                B_DISTCODE = _nSqlDataReader(_iB_DISTCODE).ToString

                                B_Subd = _nSqlDataReader(_iB_Subd).ToString
                                B_CityMunicipality = _nSqlDataReader(_iB_CityMunicipality).ToString
                                B_Province = _nSqlDataReader(_iB_Province).ToString
                                B_ZipCode = _nSqlDataReader(_iB_ZipCode).ToString

                                C_TelNo = _nSqlDataReader(_iC_TelNo).ToString
                                C_MobileNo = _nSqlDataReader(_iC_MobileNo).ToString

                                D_Lname = _nSqlDataReader(_iD_Lname).ToString
                                D_Fname = _nSqlDataReader(_iD_Fname).ToString
                                D_Mname = _nSqlDataReader(_iD_Mname).ToString
                                D_Suffix = _nSqlDataReader(_iD_Suffix).ToString
                                D_CTZNDESC = _nSqlDataReader(_iD_CTZNDESC).ToString
                                D_CTZNCODE = _nSqlDataReader(_iD_CTZNCODE).ToString

                                E_Lname = _nSqlDataReader(_iE_Lname).ToString
                                E_Fname = _nSqlDataReader(_iE_Fname).ToString
                                E_Mname = _nSqlDataReader(_iE_Mname).ToString
                                E_Suffix = _nSqlDataReader(_iE_Suffix).ToString
                                E_Nationality = _nSqlDataReader(_iE_Nationality).ToString

                                F_BusArea = _nSqlDataReader(_iF_BusArea).ToString
                                F_FlrArea = _nSqlDataReader(_iF_FlrArea).ToString
                                F_MaleEmpNo = _nSqlDataReader(_iF_MaleEmpNo).ToString
                                F_FemaleEmpNo = _nSqlDataReader(_iF_FemaleEmpNo).ToString
                                F_ResideEmpNo = _nSqlDataReader(_iF_ResideEmpNo).ToString
                                F_VanTruckNo = _nSqlDataReader(_iF_VanTruckNo).ToString
                                F_MotorNo = _nSqlDataReader(_iF_MotorNo).ToString

                                G_HouseNo = _nSqlDataReader(_iG_HouseNo).ToString
                                G_BldgName = _nSqlDataReader(_iG_BldgName).ToString
                                G_LotNo = _nSqlDataReader(_iG_LotNo).ToString
                                G_BlockNo = _nSqlDataReader(_iG_BlockNo).ToString
                                G_Street = _nSqlDataReader(_iG_Street).ToString
                                G_Brgy = _nSqlDataReader(_iG_Brgy).ToString
                                G_Subd = _nSqlDataReader(_iG_Subd).ToString
                                G_CityMunicipality = _nSqlDataReader(_iG_CityMunicipality).ToString
                                G_Province = _nSqlDataReader(_iG_Province).ToString
                                G_ZipCode = _nSqlDataReader(_iG_ZipCode).ToString

                                H_Capital = _nSqlDataReader(_iH_Capital).ToString
                                H_Nature = _nSqlDataReader(_iH_Nature).ToString
                                H_Owned = _nSqlDataReader(_iH_Owned).ToString
                                H_TDN = _nSqlDataReader(_iH_TDN).ToString
                                H_PIN = _nSqlDataReader(_iH_PIN).ToString
                                H_GovIncentive = _nSqlDataReader(_iH_GovIncentive).ToString
                                H_BusAct = _nSqlDataReader(_iH_BusAct).ToString

                                Submitted = _nSqlDataReader(_iSubmitted).ToString
                                Status = _nSqlDataReader(_iStatus).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdate_NewSubmit(
               Application_ID, UserID, Date_Esta, A_Ownership, A_OWNCODE, A_DtiSecCda, A_BusName, A_TIN, _
               B_HouseNo, B_BldgName, B_LotNo, B_BlockNo, B_Street, B_STRTCODE, B_Brgy, B_DISTCODE, B_BRGYCODE, B_Subd, B_CityMunicipality, B_Province, B_ZipCode, _
               C_TelNo, C_MobileNo, C_Email, _
               D_Lname, D_Fname, D_Mname, D_Suffix, D_CTZNCODE, D_CTZNDESC, _
               E_Lname, E_Fname, E_Mname, E_Suffix, E_Nationality, _
               F_BusArea, F_FlrArea, F_MaleEmpNo, F_FemaleEmpNo, F_ResideEmpNo, F_VanTruckNo, F_MotorNo, _
               G_HouseNo, G_BldgName, G_LotNo, G_BlockNo, G_Street, G_Brgy, G_Subd, G_CityMunicipality, G_Province, G_ZipCode, _
               H_Capital, H_Nature, H_Owned, H_TDN, H_PIN, H_GovIncentive, H_BusAct, _
               Submitted, Date_Created, Date_LastEdit, Date_Submitted, Status)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft" & _
                "(Application_ID,UserID,Date_Esta,A_Ownership,A_OWNCODE,A_DtiSecCda,A_BusName,A_TIN," & _
                "B_HouseNo,B_BldgName,B_LotNo,B_BlockNo,B_Street,B_STRTCODE,B_Brgy,B_BRGYCODE,B_DISTCODE,B_Subd,B_CityMunicipality,B_Province,B_ZipCode," & _
                "C_TelNo, C_MobileNo, C_Email," & _
                "D_Lname, D_Fname, D_Mname,D_Suffix, D_CTZNCODE, D_CTZNDESC," & _
                "E_Lname, E_Fname, E_Mname,E_Suffix,E_Nationality," & _
                "F_BusArea, F_FlrArea, F_MaleEmpNo,F_FemaleEmpNo,F_ResideEmpNo,F_VanTruckNo,F_MotorNo," & _
                "G_HouseNo, G_BldgName, G_LotNo,G_BlockNo,G_Street,G_Brgy,G_Subd,G_CityMunicipality,G_Province,G_ZipCode," & _
                 "H_Capital, H_Nature, H_Owned,H_TDN,H_PIN,H_GovIncentive,H_BusAct," & _
                 "Submitted, Date_Created, Date_LastEdit,Date_Submitted,Status" & _
                ") VALUES" & _
                "(@Application_ID,@UserID,@Date_Esta,@A_Ownership,@A_OWNCODE,@A_DtiSecCda,@A_BusName,@A_TIN," & _
                "@B_HouseNo,@B_BldgName,@B_LotNo,@B_BlockNo,@B_Street,@B_STRTCODE,@B_Brgy,@B_BRGYCODE,@B_DISTCODE,@B_Subd,@B_CityMunicipality,@B_Province,@B_ZipCode," & _
                "@C_TelNo, @C_MobileNo, @C_Email," & _
                "@D_Lname, @D_Fname, @D_Mname,@D_Suffix,@D_CTZNCODE, @D_CTZNDESC," & _
                "@E_Lname, @E_Fname, @E_Mname,@E_Suffix,@E_Nationality," & _
                "@F_BusArea, @F_FlrArea, @F_MaleEmpNo,@F_FemaleEmpNo,@F_ResideEmpNo,@F_VanTruckNo,@F_MotorNo," & _
                "@G_HouseNo, @G_BldgName, @G_LotNo,@G_BlockNo,@G_Street,@G_Brgy,@G_Subd,@G_CityMunicipality,@G_Province,@G_ZipCode," & _
                  "@H_Capital, @H_Nature, @H_Owned,@H_TDN,@H_PIN,@H_GovIncentive,@H_BusAct," & _
                 "@Submitted, @Date_Created, @Date_LastEdit,@Date_Submitted,@Status" & _
                ")"

            _nQuery = "Update NewBP_Draft SET " & _
              "Date_Esta = @Date_Esta," & _
               "A_Ownership = @A_Ownership," & _
               "A_OWNCODE = @A_OWNCODE," & _
                "A_DtiSecCda = @A_DtiSecCda," & _
               "A_BusName = @A_BusName," & _
               "A_TIN = @A_TIN," & _
               "B_HouseNo = @B_HouseNo," & _
               "B_BldgName = @B_BldgName," & _
               "B_LotNo = @B_LotNo," & _
               "B_BlockNo = @B_BlockNo," & _
               "B_Street = @B_Street," & _
               "B_STRTCODE = @B_STRTCODE," & _
               "B_Brgy = @B_Brgy," & _
               "B_BRGYCODE = @B_BRGYCODE," & _
               "B_DISTCODE = @B_DISTCODE," & _
               "B_Subd = @B_Subd," & _
               "B_CityMunicipality = @B_CityMunicipality," & _
               "B_Province = @B_Province," & _
               "B_ZipCode = @B_ZipCode," & _
               "C_TelNo = @C_TelNo," & _
               "C_MobileNo = @C_MobileNo," & _
               "C_Email = @C_Email," & _
               "D_Lname = @D_Lname," & _
               "D_Fname = @D_Fname," & _
               "D_Mname = @D_Mname," & _
               "D_Suffix = @D_Suffix," & _
               "D_CTZNCODE = @D_CTZNCODE," & _
               "D_CTZNDESC = @D_CTZNDESC," & _
               "E_Lname = @E_Lname," & _
               "E_Fname = @E_Fname," & _
               "E_Mname = @E_Mname," & _
               "E_Suffix = @E_Suffix," & _
               "E_Nationality = @E_Nationality," & _
               "F_BusArea = @F_BusArea," & _
               "F_FlrArea = @F_FlrArea," & _
               "F_MaleEmpNo = @F_MaleEmpNo," & _
               "F_FemaleEmpNo = @F_FemaleEmpNo," & _
               "F_ResideEmpNo = @F_ResideEmpNo," & _
               "F_VanTruckNo = @F_VanTruckNo," & _
               "F_MotorNo = @F_MotorNo," & _
               "G_HouseNo = @G_HouseNo," & _
               "G_BldgName = @G_BldgName," & _
               "G_LotNo = @G_LotNo," & _
               "G_BlockNo = @G_BlockNo," & _
               "G_Street = @G_Street," & _
               "G_Brgy = @G_Brgy," & _
               "G_Subd = @G_Subd," & _
               "G_CityMunicipality = @G_CityMunicipality," & _
               "G_Province = @G_Province," & _
               "G_ZipCode = @G_ZipCode," & _
               "H_Capital = @H_Capital," & _
               "H_Nature = @H_Nature," & _
               "H_Owned = @H_Owned," & _
               "H_TDN = @H_TDN," & _
               "H_PIN = @H_PIN," & _
               "H_GovIncentive = @H_GovIncentive," & _
               "H_BusAct = @H_BusAct," & _
               "Date_LastEdit = @Date_LastEdit" & _
               "Date_Submitted = @Date_Submitted" & _
               "Status = @Status" & _
               " where UserID=@UserID and Application_ID=@Application_ID"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@Date_Esta", Date_Esta)
                .AddWithValue("@A_Ownership", A_Ownership)
                .AddWithValue("@A_OWNCODE", A_OWNCODE)
                .AddWithValue("@A_DtiSecCda", A_DtiSecCda)
                .AddWithValue("@A_BusName", A_BusName)
                .AddWithValue("@A_TIN", A_TIN)
                .AddWithValue("@B_HouseNo", B_HouseNo)
                .AddWithValue("@B_BldgName", B_BldgName)
                .AddWithValue("@B_LotNo", B_LotNo)
                .AddWithValue("@B_BlockNo", B_BlockNo)
                .AddWithValue("@B_Street", B_Street)
                .AddWithValue("@B_STRTCODE", B_STRTCODE)
                .AddWithValue("@B_Brgy", B_Brgy)
                .AddWithValue("@B_BRGYCODE", B_BRGYCODE)
                .AddWithValue("@B_DISTCODE", B_DISTCODE)
                .AddWithValue("@B_Subd", B_Subd)
                .AddWithValue("@B_CityMunicipality", B_CityMunicipality)
                .AddWithValue("@B_Province", B_Province)
                .AddWithValue("@B_ZipCode", B_ZipCode)
                .AddWithValue("@C_TelNo", C_TelNo)
                .AddWithValue("@C_MobileNo", C_MobileNo)
                .AddWithValue("@C_Email", C_Email)
                .AddWithValue("@D_Lname", D_Lname)
                .AddWithValue("@D_Fname", D_Fname)
                .AddWithValue("@D_Mname", D_Mname)
                .AddWithValue("@D_Suffix", D_Suffix)
                .AddWithValue("@D_CTZNCODE", D_CTZNCODE)
                .AddWithValue("@D_CTZNDESC", D_CTZNDESC)
                .AddWithValue("@E_Lname", E_Lname)
                .AddWithValue("@E_Fname", E_Fname)
                .AddWithValue("@E_Mname", E_Mname)
                .AddWithValue("@E_Suffix", E_Suffix)
                .AddWithValue("@E_Nationality", E_Nationality)
                .AddWithValue("@F_BusArea", F_BusArea)
                .AddWithValue("@F_FlrArea", F_FlrArea)
                .AddWithValue("@F_MaleEmpNo", F_MaleEmpNo)
                .AddWithValue("@F_FemaleEmpNo", F_FemaleEmpNo)
                .AddWithValue("@F_ResideEmpNo", F_ResideEmpNo)
                .AddWithValue("@F_VanTruckNo", F_VanTruckNo)
                .AddWithValue("@F_MotorNo", F_MotorNo)
                .AddWithValue("@G_HouseNo", G_HouseNo)
                .AddWithValue("@G_BldgName", G_BldgName)
                .AddWithValue("@G_LotNo", G_LotNo)
                .AddWithValue("@G_BlockNo", G_BlockNo)
                .AddWithValue("@G_Street", G_Street)
                .AddWithValue("@G_Brgy", G_Brgy)
                .AddWithValue("@G_Subd", G_Subd)
                .AddWithValue("@G_CityMunicipality", G_CityMunicipality)
                .AddWithValue("@G_Province", G_Province)
                .AddWithValue("@G_ZipCode", G_ZipCode)
                .AddWithValue("@H_Capital", H_Capital)
                .AddWithValue("@H_Nature", H_Nature)
                .AddWithValue("@H_Owned", H_Owned)
                .AddWithValue("@H_TDN", H_TDN)
                .AddWithValue("@H_PIN", H_PIN)
                .AddWithValue("@H_GovIncentive", H_GovIncentive)
                .AddWithValue("@H_BusAct", H_BusAct)
                .AddWithValue("@Date_LastEdit", Date_LastEdit)
                .AddWithValue("@Date_Submitted", Date_Submitted)
                .AddWithValue("@Status", Status)

            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsert_NewSubmit(
               Application_ID, UserID, Date_Esta, A_Ownership, A_OWNCODE, A_DtiSecCda, A_BusName, A_TIN, _
               B_HouseNo, B_BldgName, B_LotNo, B_BlockNo, B_Street, B_STRTCODE, B_Brgy, B_BRGYCODE, B_DISTCODE, B_Subd, B_CityMunicipality, B_Province, B_ZipCode, _
               C_TelNo, C_MobileNo, C_Email, _
               D_Lname, D_Fname, D_Mname, D_Suffix, D_CTZNCODE, D_CTZNDESC, _
               E_Lname, E_Fname, E_Mname, E_Suffix, E_Nationality, _
               F_BusArea, F_FlrArea, F_MaleEmpNo, F_FemaleEmpNo, F_ResideEmpNo, F_VanTruckNo, F_MotorNo, _
               G_HouseNo, G_BldgName, G_LotNo, G_BlockNo, G_Street, G_Brgy, G_Subd, G_CityMunicipality, G_Province, G_ZipCode, _
               H_Capital, H_Nature, H_Owned, H_TDN, H_PIN, H_GovIncentive, H_BusAct, _
               Submitted, Date_Created, Date_LastEdit, Date_Submitted, Status)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Insert Into NewBP_Draft" & _
                "(Application_ID,UserID,Date_Esta,A_Ownership,A_OWNCODE,A_DtiSecCda,A_BusName,A_TIN," & _
                "B_HouseNo,B_BldgName,B_LotNo,B_BlockNo,B_Street,B_STRTCODE,B_Brgy,B_BRGYCODE,B_DISTCODE,B_Subd,B_CityMunicipality,B_Province,B_ZipCode," & _
                "C_TelNo, C_MobileNo, C_Email," & _
                "D_Lname, D_Fname, D_Mname,D_Suffix, D_CTZNCODE, D_CTZNDESC," & _
                "E_Lname, E_Fname, E_Mname,E_Suffix,E_Nationality," & _
                "F_BusArea, F_FlrArea, F_MaleEmpNo,F_FemaleEmpNo,F_ResideEmpNo,F_VanTruckNo,F_MotorNo," & _
                "G_HouseNo, G_BldgName, G_LotNo,G_BlockNo,G_Street,G_Brgy,G_Subd,G_CityMunicipality,G_Province,G_ZipCode," & _
                 "H_Capital, H_Nature, H_Owned,H_TDN,H_PIN,H_GovIncentive,H_BusAct," & _
                 "Submitted, Date_Created, Date_LastEdit,Date_Submitted,Status" & _
                ") VALUES" & _
                "(@Application_ID,@UserID,@Date_Esta,@A_Ownership,@A_OWNCODE,@A_DtiSecCda,@A_BusName,@A_TIN," & _
                "@B_HouseNo,@B_BldgName,@B_LotNo,@B_BlockNo,@B_Street,@B_STRTCODE,@B_Brgy,@B_BRGYCODE,@B_DISTCODE,@B_Subd,@B_CityMunicipality,@B_Province,@B_ZipCode," & _
                "@C_TelNo, @C_MobileNo, @C_Email," & _
                "@D_Lname, @D_Fname, @D_Mname,@D_Suffix,@D_CTZNCODE, @D_CTZNDESC," & _
                "@E_Lname, @E_Fname, @E_Mname,@E_Suffix,@E_Nationality," & _
                "@F_BusArea, @F_FlrArea, @F_MaleEmpNo,@F_FemaleEmpNo,@F_ResideEmpNo,@F_VanTruckNo,@F_MotorNo," & _
                "@G_HouseNo, @G_BldgName, @G_LotNo,@G_BlockNo,@G_Street,@G_Brgy,@G_Subd,@G_CityMunicipality,@G_Province,@G_ZipCode," & _
                  "@H_Capital, @H_Nature, @H_Owned,@H_TDN,@H_PIN,@H_GovIncentive,@H_BusAct," & _
                 "@Submitted, @Date_Created, @Date_LastEdit,@Date_Submitted,@Status" & _
                ")"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@Date_Esta", Date_Esta)

                .AddWithValue("@A_Ownership", A_Ownership)
                .AddWithValue("@A_OWNCODE", A_OWNCODE)
                .AddWithValue("@A_DtiSecCda", A_DtiSecCda)
                .AddWithValue("@A_BusName", A_BusName)
                .AddWithValue("@A_TIN", A_TIN)

                .AddWithValue("@B_HouseNo", B_HouseNo)
                .AddWithValue("@B_BldgName", B_BldgName)
                .AddWithValue("@B_LotNo", B_LotNo)
                .AddWithValue("@B_BlockNo", B_BlockNo)
                .AddWithValue("@B_Street", B_Street)
                .AddWithValue("@B_STRTCODE", B_STRTCODE)
                .AddWithValue("@B_Brgy", B_Brgy)
                .AddWithValue("@B_BRGYCODE", B_BRGYCODE)
                .AddWithValue("@B_DISTCODE", B_DISTCODE)
                .AddWithValue("@B_Subd", B_Subd)
                .AddWithValue("@B_CityMunicipality", B_CityMunicipality)
                .AddWithValue("@B_Province", B_Province)
                .AddWithValue("@B_ZipCode", B_ZipCode)

                .AddWithValue("@C_TelNo", C_TelNo)
                .AddWithValue("@C_MobileNo", C_MobileNo)
                .AddWithValue("@C_Email", C_Email)

                .AddWithValue("@D_Lname", D_Lname)
                .AddWithValue("@D_Fname", D_Fname)
                .AddWithValue("@D_Mname", D_Mname)
                .AddWithValue("@D_Suffix", D_Suffix)
                .AddWithValue("@D_CTZNCODE", D_CTZNCODE)
                .AddWithValue("@D_CTZNDESC", D_CTZNDESC)

                .AddWithValue("@E_Lname", E_Lname)
                .AddWithValue("@E_Fname", E_Fname)
                .AddWithValue("@E_Mname", E_Mname)
                .AddWithValue("@E_Suffix", E_Suffix)
                .AddWithValue("@E_Nationality", E_Nationality)

                .AddWithValue("@F_BusArea", F_BusArea)
                .AddWithValue("@F_FlrArea", F_FlrArea)
                .AddWithValue("@F_MaleEmpNo", F_MaleEmpNo)
                .AddWithValue("@F_FemaleEmpNo", F_FemaleEmpNo)
                .AddWithValue("@F_ResideEmpNo", F_ResideEmpNo)
                .AddWithValue("@F_VanTruckNo", F_VanTruckNo)
                .AddWithValue("@F_MotorNo", F_MotorNo)

                .AddWithValue("@G_HouseNo", G_HouseNo)
                .AddWithValue("@G_BldgName", G_BldgName)
                .AddWithValue("@G_LotNo", G_LotNo)
                .AddWithValue("@G_BlockNo", G_BlockNo)
                .AddWithValue("@G_Street", G_Street)
                .AddWithValue("@G_Brgy", G_Brgy)
                .AddWithValue("@G_Subd", G_Subd)
                .AddWithValue("@G_CityMunicipality", G_CityMunicipality)
                .AddWithValue("@G_Province", G_Province)
                .AddWithValue("@G_ZipCode", G_ZipCode)

                .AddWithValue("@H_Capital", H_Capital)
                .AddWithValue("@H_Nature", H_Nature)
                .AddWithValue("@H_Owned", H_Owned)
                .AddWithValue("@H_TDN", H_TDN)
                .AddWithValue("@H_PIN", H_PIN)
                .AddWithValue("@H_GovIncentive", H_GovIncentive)
                .AddWithValue("@H_BusAct", H_BusAct)

                .AddWithValue("@Submitted", Submitted)
                .AddWithValue("@Date_Created", Date_Created)
                .AddWithValue("@Date_LastEdit", Date_LastEdit)
                .AddWithValue("@Date_Submitted", Date_Submitted)
                .AddWithValue("@Status", Status)

            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetAbbrv(ByVal office As String, ByRef Result As String)
        Try
            '----------------------------------       
            Dim _nQuery As String = Nothing
            _nQuery = "select top 1 OFABBRV from ofccode where OFABBRV like'%" & office & "%'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iResult As Integer = .GetOrdinal("OFABBRV")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Result = _nSqlDataReader(_iResult).ToString
                            Loop
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Public Sub checkIfNewBP(ByVal ACCTNO As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Select * from NewBP_Draft where ACCTNO ='" & ACCTNO & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Exists = True
                            Loop
                        Else
                            Exists = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectNewBP()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                  " SELECT Application_ID" & _
                  " ,IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OWNER'" & _
                  " , A_BusName" & _
                  " , [Status]" & _
                  " , (replace(replace(replace(B_HouseNo + ' ' + B_BldgName + ' ' + B_LotNo + ' ' + B_BlockNo + ' ' + B_Street + ' ' + B_Brgy + ' ' + B_Subd + ' ' + B_CityMunicipality + ' ' + B_Province + ' ' + B_ZipCode , ' ','<>'),'><',''),'<>',' ')) as 'BusAdd'" & _
                  " ,CASE" & _
                  "     WHEN [Status]= 'Submitted/Pending' THEN 'Cancel'" & _
                  "     WHEN [Status]= 'Approved - For Regulatory'  THEN 'Regulatory'" & _
                  " 	WHEN [Status]= 'Incomplete'  THEN 'Re-Submit'   " & _
                  " END AS Action" & _
                  " FROM NEWBP_DRAFT where UserID='" & cSessionUser._pUserID & "' and Status <> 'Approved - For Payment'"
            '  "SELECT Application_ID,IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OWNER', A_BusName, [Status], (replace(replace(replace(B_HouseNo + ' ' + B_BldgName + ' ' + B_LotNo + ' ' + B_BlockNo + ' ' + B_Street + ' ' + B_Brgy + ' ' + B_Subd + ' ' + B_CityMunicipality + ' ' + B_Province + ' ' + B_ZipCode , ' ','<>'),'><',''),'<>',' ')) as 'BusAdd'" & _
            '  " FROM NEWBP_DRAFT where UserID='" & cSessionUser._pUserID & "' and Status <> 'Approved - For Payment'"




            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)


            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectBP_Permit(ByVal acctno As String, ByRef xFileData As Byte(), ByRef xFileData64 As String, ByRef xFileName As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " select top 1 ARXFile,xFileData64,xFileName from bpfile cross apply (select ARXFile as '*' for xml path('')) T (xFileData64) where acctno='" & acctno & "' order by xFileNo desc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _ixFileData As Integer = .GetOrdinal("ARXFile")
                    Dim _ixFileData64 As Integer = .GetOrdinal("xFileData64")
                    Dim _ixFileName As Integer = .GetOrdinal("xFileName")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                xFileData = _nSqlDataReader(_ixFileData)
                                xFileData64 = _nSqlDataReader(_ixFileData64).ToString
                                xFileName = _nSqlDataReader(_ixFileName).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectClearanceNo(ByVal Acctno As String, ByRef Clearance_no As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select clearance_no from [NewBP_RegulatorySubmitted2] where application_ID=(select top 1 PBN from [BUSMAST] where acctno='" & Acctno & "' order by PBN desc)"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iClearance_no As Integer = .GetOrdinal("Clearance_no")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Clearance_no += _nSqlDataReader(_iClearance_no).ToString & " </br>"
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectNewBP_Issuance_TAXPAYER()
        Try
            Dim _nQuery As String = Nothing
            '  _nQuery = "SELECT BM.ACCTNO, (BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS  ,STUFF((SELECT ' || ' + BC.[DESCRIPTION]   FROM " & _
            '      "[" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[BUSCODE] BC  " & _
            '      "INNER JOIN " & _
            '      "[" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE BL    ON BM.ACCTNO = BL.ACCTNO  WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO   FOR XML PATH('')), 1, 3, '') AS CATEGORY,'NEW' as STATUS  FROM BUSMAST BM  INNER JOIN BUSMASTEXTN BMX  ON BM.ACCTNO = BMX.ACCTNO   where BM.IsForPayment = 0 and BM.isPosted = 1    AND BMX.FORYEAR = YEAR(GETDATE()) AND BM.EMAILADDR = '" & cSessionUser._pUserID & "'  "


            _nQuery = _
            " SELECT   	distinct " & _
            "	BM.ACCTNO, 	 " & _
            "	BD.EMAIL2, 	 " & _
            "	BM.COMMNAME,  	 " & _
            "	convert(varchar, BP.DATEPAID, 107)DATEPAID, 	 " & _
            "	convert(varchar, BP.ISSUANCEDATE, 107)ISSUANCEDATE, 	 " & _
            "	convert(varchar, BP.EXPIRATIONDATE, 107)EXPIRATIONDATE   " & _
            "FROM BUSMAST BM     " & _
            "INNER JOIN BUSINESSPERMIT BP ON BM.ACCTNO=BP.ACCTNO 	 " & _
            "INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[busdetail] BD ON bd.ACCTNO=BP.ACCTNO 	 " & _
            "where bm.ACCTNO in (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[busdetail] where email2='" & cSessionUser._pUserID & "' ) " & _
            "and BP.foryear=year(getdate())  and bd.verified=1 "

            ' " SELECT DISTINCT BM.ACCTNO,SOS.EMAILADDR,BM.COMMNAME, convert(varchar, BP.DATEPAID, 107)DATEPAID,convert(varchar, BP.ISSUANCEDATE, 107)ISSUANCEDATE,convert(varchar, BP.EXPIRATIONDATE, 107)EXPIRATIONDATE  FROM BUSMAST BM" & _
            ' " INNER JOIN PAYFILE PF  ON BM.ACCTNO=PF.ACCTNO AND  PF.FORYEAR=CAST(YEAR(GETDATE()) AS NVARCHAR)" & _
            ' " INNER JOIN BUSINESSPERMIT BP ON PF.ACCTNO=BP.ACCTNO AND BP.FORYEAR=CAST(YEAR(GETDATE()) AS NVARCHAR)" & _
            ' " INNER JOIN [" & cGlobalConnections._pSqlCxn_OAIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].DBO.[ONLINEPAYMENTREFNO] SOS ON SOS.ACCTNO=BP.ACCTNO " & _
            ' " WHERE SOS.EMAILADDR = '" & cSessionUser._pUserID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGet_Concerns()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Select * from WSP_Concern order by Date_Submitted desc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubAdd_Concern(ByVal Name As String, _
                              ByVal LGU_Name As String, _
                              ByVal Url_Used As String, _
                              ByVal Subject As String, _
                              ByVal Concern As String, _
                              ByVal File_Name As String, _
                              ByVal File_Type As String, _
                              ByVal File_Data As Byte()
                              )
        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO WSP_Concern" & _
                "(Name,LGU_Name,Url_Used,Subject,Concern,File_Name,File_Type,File_Data,Status,Date_Submitted) " & _
                "VALUES" & _
                "(@Name,@LGU_Name,@Url_Used,@Subject,@Concern,@File_Name,@File_Type,@File_Data,@Status, getdate())"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@Name", Name)
                .AddWithValue("@LGU_Name", LGU_Name)
                .AddWithValue("@Url_Used", Url_Used)
                .AddWithValue("@Subject", Subject)
                .AddWithValue("@Concern", Concern)
                .AddWithValue("@File_Name", File_Name)
                .AddWithValue("@File_Type", File_Type)
                .AddWithValue("@File_Data", File_Data)
                .AddWithValue("@Status", "PENDING")
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGet_LGU_List()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Select * from WSP_LGU_List order by LGU_Name asc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectBP_Issuance_BPLO()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
            " SELECT   	" & _
            "	BM.ACCTNO, 	 " & _
            "	BD.EMAIL2, 	 " & _
            "	BM.COMMNAME,  	 " & _
            "	convert(varchar, BP.DATEPAID, 107)DATEPAID, 	 " & _
            "	convert(varchar, BP.ISSUANCEDATE, 107)ISSUANCEDATE, 	 " & _
            "	convert(varchar, BP.EXPIRATIONDATE, 107)EXPIRATIONDATE   " & _
            "FROM BUSMAST BM     " & _
            "INNER JOIN BUSINESSPERMIT BP ON BM.ACCTNO=BP.ACCTNO 	 " & _
            "INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[busdetail] BD ON bd.ACCTNO=BP.ACCTNO 	 " & _
            "where bm.ACCTNO in (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[busdetail] where status <> 'Issued/Sent') " & _
            "and BP.foryear=year(getdate()) order by bp.ISSUANCEDATE asc"


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)


            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectBP_Issued_BPLO()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
            " SELECT   	" & _
            "	BM.ACCTNO, 	 " & _
            "	BD.EMAIL2, 	 " & _
            "	BM.COMMNAME,  	 " & _
            "	convert(varchar, BP.DATEPAID, 107)DATEPAID, 	 " & _
            "	convert(varchar, BP.ISSUANCEDATE, 107)ISSUANCEDATE, 	 " & _
            "	convert(varchar, BP.EXPIRATIONDATE, 107)EXPIRATIONDATE   " & _
            "FROM BUSMAST BM     " & _
            "INNER JOIN BUSINESSPERMIT BP ON BM.ACCTNO=BP.ACCTNO 	 " & _
            "INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[busdetail] BD ON bd.ACCTNO=BP.ACCTNO 	 " & _
            "where bm.ACCTNO in (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[busdetail] where status = 'Issued/Sent') " & _
            "and BP.foryear=year(getdate()) order by bp.ISSUANCEDATE asc"


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)


            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRequirements(ByVal Switch As String)
        Try
            Dim _nQuery As String = Nothing
            If Switch = "ALL" Then
                _nQuery = "" & _
     " select A.switch as 'OFCCODE',RS.REQDESC as 'OFCDESC', A.ReqCode,A.ReqDesc, " & _
     "  (SELECT  File_Name FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'File_Name',     " & _
     "  (SELECT  File_Type FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'File_Type',     " & _
     "  (SELECT  File_Data64 FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'File_Data64',   " & _
     "  (SELECT  Status FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'Status',           " & _
     "	(SELECT  Application_ID FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'Application_ID'," & _
     "  (SELECT  Remarks FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'Remarks'          " & _
     "  FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].[req1] A" & _
     "  inner join  [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].[OFCCODE]  OC" & _
     "  on OC.OFABBRV = A.switch " & _
     "  inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].[REQ_SETUP] RS" & _
     "  on OC.OFABBRV = RS.REQCODE " & _
     "  ORDER BY A.switch ASC"

            Else
                _nQuery = "" & _
     " select   ReqCode,ReqDesc," & _
     "  (SELECT  File_Name FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'File_Name',     " & _
     "  (SELECT  File_Type FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'File_Type',     " & _
     "  (SELECT  File_Data64 FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'File_Data64',   " & _
     "  (SELECT  Status FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'Status',           " & _
     "	(SELECT  Application_ID FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'Application_ID'," & _
     "  (SELECT  Remarks FROM NewBP_RegulatorySubmitted where ReqDesc=a.ReqDesc  and Application_ID='" & Application_ID & "') as 'Remarks'          " & _
     "  FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].[req1] A where switch='" & Switch & "'          "

            End If

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Get_RegulatoryReq()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                " select r1.reqcode,r1.reqdesc,(rs.reqdesc)Office from [REQ1] r1" & _
                " inner join [REQ_SETUP] rs on r1.switch=rs.reqcode" & _
                " where ISNULL(r1.COMPLIANT,'0') <> '0'  and rs.reqcode not like '%NEW'" 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectApplicants(ByVal Switch As String, ByVal Status As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  Application_ID,Date_Submitted as 'APP_DATE',userid as 'EMAILADDR',IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OwnerName', A_BusName as 'COMMNAME', [Status] FROM NEWBP_DRAFT a where Status = '" & Status & "'  " & _
                " and EXISTS (SELECT Application_ID FROM [NewBP_RegulatorySubmitted] WHERE Application_ID = a.Application_ID and SWITCH='" & Switch & "')" & _
                " and  (select Assessed_BY FROM [NewBP_RegulatorySubmitted2] WHERE Application_ID = a.Application_ID and SWITCH='" & Switch & "') IS NULL"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectHistory(ByVal Switch As String)
        Try
            Dim _nQuery As String = Nothing
            ' _nQuery = "SELECT * from [NewBP_RegulatorySubmitted2] WHERE SWITCH='" & Switch & "' and  Assessed_BY IS NOT NULL "
            _nQuery = "SELECT reg.*, " & _
                      " IIF(NEWBP_DRAFT.A_OWNERSHIP='Single',NEWBP_DRAFT.D_Lname + ' ' + NEWBP_DRAFT.D_FName +' ' +NEWBP_DRAFT. D_Mname + ' ' + NEWBP_DRAFT.D_Suffix,E_Lname + ' ' + NEWBP_DRAFT.E_FName +' ' + NEWBP_DRAFT.E_Mname + ' ' + NEWBP_DRAFT.E_Suffix) as 'Taxpayer_Name'," & _
                      " NEWBP_DRAFT.A_BusName as 'Business_Trade_Name'" & _
                      " FROM [NewBP_RegulatorySubmitted2] reg" & _
                      " INNER JOIN NEWBP_DRAFT ON reg.Application_ID = NEWBP_DRAFT.Application_ID " & _
                      " where reg.SWITCH='" & Switch & "' and reg.status <> 'Pending' order by reg.Date_Assessed desc"


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectRequirements_Submitted(ByVal AppID As String, ByVal Switch As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_RegulatorySubmitted] " & _
                      "where Switch='" & Switch & "' and Application_ID='" & AppID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetAllRegulatory(ByVal AppID As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                  "  select BPLTIMS.Application_ID,REQ_SETUP.REQCODE,REQ_SETUP.reqDesc, BPLTIMS.Status,BPLTIMS.assessed_by from OFCCODE " & _
                  "  inner join " & _
                  "  [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].[NewBP_RegulatorySubmitted2] BPLTIMS " & _
                  "  on OFCCODE.OFABBRV = BPLTIMS.switch " & _
                  "  inner join " & _
                  "  REQ_SETUP " & _
                  "  on OFCCODE.OFABBRV = REQ_SETUP.REQCODE " & _
                  "  where REQ_SETUP.REQCODE in (select SWITCH from REQ1) and BPLTIMS.application_id='" & AppID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRegulatory_Fees(ByVal AppID As String, ByVal Switch As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_RegulatoryFees] " & _
                      "where Switch='" & Switch & "' and Application_ID='" & AppID & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectRegulatory_Fees2(ByVal AppID As String, ByVal Switch As String, _
                                           ByRef AmtDue As String, _
                                           ByRef Clearance_No As String, _
                                           ByRef Status As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                "SELECT Application_ID,SWITCH," & _
                "sum(cast(feeamt as money)) as 'AmtDue'," & _
                "(Select Clearance_no from [NewBP_RegulatorySubmitted2] where Application_ID = '" & AppID & "' and SWITCH='" & Switch & "' ) as 'Clearance_no'," & _
                "(Select [Status] from [NewBP_RegulatorySubmitted2] where Application_ID = '" & AppID & "' and SWITCH='" & Switch & "') as 'Status'" & _
                "  FROM [NewBP_RegulatoryFees]  where   Application_ID = '" & AppID & "' and SWITCH='" & Switch & "'" & _
                "  group by Application_ID,SWITCH "
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iAmtDue As Integer = .GetOrdinal("AmtDue")
                    Dim _iClearance_No As Integer = .GetOrdinal("Clearance_No")
                    Dim _iStatus As Integer = .GetOrdinal("Status")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                AmtDue = _nSqlDataReader(_iAmtDue).ToString
                                Clearance_No = _nSqlDataReader(_iClearance_No).ToString
                                Status = _nSqlDataReader(_iStatus).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectFees(ByVal Switch As String, ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            '  _nQuery = "select FNAME,DNAME,FDESC,TAXCODE,FORMAT(DEFAMT, 'N') as DEFAMT from (" & _
            '  "select " & _
            '  "isnull((select OFABBRV from OFCCODE where OFCDESC = LABELS.OFCCODE),'') as REQCODE," & _
            '  "* from LABELS" & _
            '  ") as x where REQCODE = '" & Switch & "'"

            _nQuery = "" & _
"DECLARE  " & _
"@colNames  NVARCHAR(MAX) = N'',@colValues NVARCHAR(MAX) = N'',@sql NVARCHAR(MAX) = N''; " & _
"SELECT  @colNames += ',' + QUOTENAME(name), @colValues += ',' + QUOTENAME(name) + ' = CONVERT(VARCHAR(MAX), ' + QUOTENAME(name) + ')' FROM sys.columns WHERE [object_id] = OBJECT_ID('dbo.BUSEXTN') AND name <> 'ACCTNO'; " & _
"SET @sql = N'SELECT * FROM (SELECT ACCTNO, (select OFABBRV from OFCCODE where OFCDESC = (select OFCCODE from Labels where FNAME=up.Property)) as OFCCODE, (select FDESC from  Labels where FNAME=up.Property) as FDESC, Property as FNAME, Value as FeeAmt FROM (SELECT ACCTNO' + @colValues + ' FROM dbo.BUSEXTN where " & _
"ACCTNO = ''" & ACCTNO & "'') AS t UNPIVOT (Value FOR Property IN (' + STUFF(@colNames, 1, 1, '') + ')  ) AS up) AS FTBL WHERE " & _
"OFCCODE = ''" & Switch & "'';';" & _
"EXEC sp_executesql @sql;"





            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectFeesFromBPLTAS(ByVal Switch As String, ByVal acctno As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  * "
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRequirements_Submitted2(ByVal AppID As String, ByVal Switch As String, _
                                                  ByRef Info1 As String, ByRef Info2 As String, _
                                                  ByRef Info3 As String, ByRef Info4 As String, _
                                                  ByRef Info5 As String, ByRef Status As String, _
                                                  ByRef Remarks As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_RegulatorySubmitted2] " & _
                      "where Switch='" & Switch & "' and Application_ID='" & AppID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iInfo1 As Integer = .GetOrdinal("Info1")
                    Dim _iInfo2 As Integer = .GetOrdinal("Info2")
                    Dim _iInfo3 As Integer = .GetOrdinal("Info3")
                    Dim _iInfo4 As Integer = .GetOrdinal("Info4")
                    Dim _iInfo5 As Integer = .GetOrdinal("Info5")
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    Dim _iRemarks As Integer = .GetOrdinal("Remarks")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Info1 = _nSqlDataReader(_iInfo1).ToString
                                Info2 = _nSqlDataReader(_iInfo2).ToString
                                Info3 = _nSqlDataReader(_iInfo3).ToString
                                Info4 = _nSqlDataReader(_iInfo4).ToString
                                Info5 = _nSqlDataReader(_iInfo5).ToString
                                Status = _nSqlDataReader(_iStatus).ToString
                                Remarks = _nSqlDataReader(_iRemarks).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCTC(ByVal ACCTNO As String, _
                           ByRef CTC_AMOUNT As Double,
                           ByRef CTC_REMARK As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select top 1 CTC_REMARK,CTC_AMOUNT from BILLINGTEMP where acctno='" & ACCTNO & "' and foryear=year(getdate())"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iCTC_AMOUNT As Integer = .GetOrdinal("CTC_AMOUNT")
                    Dim _iCTC_REMARK As Integer = .GetOrdinal("CTC_REMARK")


                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                CTC_AMOUNT = _nSqlDataReader(_iCTC_AMOUNT).ToString
                                CTC_REMARK = _nSqlDataReader(_iCTC_REMARK).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectRequirements_Submitted2_History(ByVal AppID As String, ByVal Switch As String, _
                                                  ByRef Info1 As String, ByRef Info2 As String, _
                                                  ByRef Info3 As String, ByRef Info4 As String, _
                                                  ByRef Info5 As String, ByRef Status As String, _
                                                  ByRef Remarks As String, ByRef Date_Assessed As String, _
                                                  ByRef Assessed_By As String, ByRef Clearance_No As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_RegulatorySubmitted2] " & _
                      "where Switch='" & Switch & "' and Application_ID='" & AppID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iInfo1 As Integer = .GetOrdinal("Info1")
                    Dim _iInfo2 As Integer = .GetOrdinal("Info2")
                    Dim _iInfo3 As Integer = .GetOrdinal("Info3")
                    Dim _iInfo4 As Integer = .GetOrdinal("Info4")
                    Dim _iInfo5 As Integer = .GetOrdinal("Info5")
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    Dim _iRemarks As Integer = .GetOrdinal("Remarks")
                    Dim _iDate_Assessed As Integer = .GetOrdinal("Date_Assessed")
                    Dim _iAssessed_By As Integer = .GetOrdinal("Assessed_By")
                    Dim _iClearance_No As Integer = .GetOrdinal("Clearance_No")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Info1 = _nSqlDataReader(_iInfo1).ToString
                                Info2 = _nSqlDataReader(_iInfo2).ToString
                                Info3 = _nSqlDataReader(_iInfo3).ToString
                                Info4 = _nSqlDataReader(_iInfo4).ToString
                                Info5 = _nSqlDataReader(_iInfo5).ToString
                                Status = _nSqlDataReader(_iStatus).ToString
                                Remarks = _nSqlDataReader(_iRemarks).ToString
                                Date_Assessed = _nSqlDataReader(_iDate_Assessed).ToString
                                Assessed_By = _nSqlDataReader(_iAssessed_By).ToString
                                Clearance_No = _nSqlDataReader(_iClearance_No).ToString

                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectNewBPSubmitted()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  Status,Application_ID,Date_Submitted as 'APP_DATE',userid as 'EMAILADDR',IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OwnerName', A_BusName as 'COMMNAME', [Status] FROM NEWBP_DRAFT WHERE ISNULL(STATUS,'')=" & _
                "'Submitted/Pending' order by Date_Submitted asc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectForApproval()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  Application_ID,Date_Submitted as 'APP_DATE',userid as 'EMAILADDR',IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OwnerName', A_BusName as 'COMMNAME', [Status] FROM NEWBP_DRAFT WHERE ISNULL(STATUS,'')=" & _
                "'Approved - For BPLO Approval' order by Date_Submitted asc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Function _pSubExistRegInfo(ByVal Application_ID As String, ByVal OFCCODE As String) As Boolean
        Dim _nQuery As String = Nothing
        _nQuery = "select * from [NewBP_RegulatorySubmitted2] " & _
                  "where Switch='" & OFCCODE & "' and Application_ID='" & Application_ID & "'"

        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                If _nSqlDataReader.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End With
            _nSqlDataReader.Close()
        End Using


    End Function

    Function _pSubExpired(ByVal Acctno As String) As Boolean
        Dim _nQuery As String = Nothing
        _nQuery = "  select top 1 [DATE_EXPIRE] from [BILLINGTEMP] where DATE_EXPIRE < getdate() and  acctno ='" & Acctno & "';"
        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                If _nSqlDataReader.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End With
            _nSqlDataReader.Close()
        End Using


    End Function

    Function _pSubPaidandPosted(ByVal Acctno As String) As Boolean
        Dim _nQuery As String = Nothing
        _nQuery = "select TOP 1 ACCTNO, FORYEAR,ORNO,* from PAYFILE WHERE ACCTNO='" & Acctno & "' and FORYEAR=CAST(YEAR(GETDATE()) AS nvarchar)"
        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                If _nSqlDataReader.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End With
            _nSqlDataReader.Close()
        End Using
    End Function


    Public Sub _pSubSelectForRegulatory()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  Status,Application_ID,Date_Submitted as 'APP_DATE',userid as 'EMAILADDR',IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OwnerName', A_BusName as 'COMMNAME', [Status] FROM NEWBP_DRAFT WHERE ISNULL(STATUS,'')=" & _
                "'Approved - For Regulatory' order by Date_Submitted asc"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectTOP(ByVal acctno As String, _
                              ByRef Sum_TotDue As Decimal _
                              , ByRef Sum_TotPenDue As Decimal _
                              , ByRef Sum_TotTaxDue As Decimal _
                              , ByRef Sum_TotETC As Decimal, ByVal selectedQTR As Integer, Optional ByRef qry As String = Nothing, Optional ByRef err As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            ' _nQuery = "" & _
            ' "select * from (select Acctno, Foryear, Bus_Code, Desc1, Taxbase, Pres , Prev, AssessTotal, Taxcode, Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from (select Acctno, Foryear, Bus_Code, case when xxx is null then Desc1 else XXX end as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, Amt_Pd, Amt_PenPd, Totdue, Discount from ( select Acctno, Foryear, '' as Bus_Code, upper(MainAcctDesc) as Desc1, '' as Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount, subacctcode , (Select taxdesc from acctlink where subacctcode =  billingtemp.SubAcctCode and taxcode = 'BT') as XXX from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) <> 'TaxCredit' and substring(desc1, 1, 8) <> 'Discount' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'bt  '  group by  Acctno, Foryear, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,''), MainAcctDesc, subacctcode) as y) as x group by  Acctno, Foryear, Bus_Code, desc1, taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1 " & _
            ' "Union All " & _
            ' "select Acctno, Foryear, Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(Discount,0)) as Discount from (select Acctno, Foryear, Bus_Code, 'DISCOUNT ON ' + case when xxx is null then Desc1 else XXX end as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, Amt_Pd, Amt_PenPd, Totdue, Discount from ( select Acctno, Foryear, '' as Bus_Code, upper(MainAcctDesc) as Desc1, '' as Taxbase, '' Pres, '' Prev,  'A02' AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount, subacctcode , (Select taxdesc from acctlink where subacctcode =  billingtemp.SubAcctCode and taxcode = 'BT') as XXX from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 8) = 'Discount' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'bt  '  group by  Acctno, Foryear, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,''), MainAcctDesc, subacctcode) as y) as x group by  Acctno, Foryear, Bus_Code, desc1, taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1 " & _
            ' "Union All " & _
            ' "select Acctno, Foryear, Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from (select Acctno, Foryear, Bus_Code, 'TAX CREDIT ON ' + case when xxx is null then Desc1 else XXX end as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, Amt_Pd, Amt_PenPd, Totdue, Discount from ( select Acctno, Foryear, '' as Bus_Code, upper(MainAcctDesc) as Desc1, '' as Taxbase, '' Pres, '' Prev, 'A03' AssessTotal, Taxcode,isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount, subacctcode , (Select taxdesc from acctlink where subacctcode =  billingtemp.SubAcctCode and taxcode = 'BT') as XXX from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) = 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'bt  '  group by  Acctno, Foryear, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,''), MainAcctDesc, subacctcode) as y) as x group by  Acctno, Foryear, Bus_Code, desc1, taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1 " & _
            ' "Union All " & _
            ' "select Acctno, Foryear, '' as Bus_Code, 'MAYORS PERMIT FEES' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'mf  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') " & _
            ' "union all " & _
            ' "select Acctno, Foryear, '' as Bus_Code, 'SANITARY FEES' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'sf  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') " & _
            ' "union all " & _
            ' "select Acctno, Foryear, '' as Bus_Code, 'REFUSE FEE' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'gf  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'')  " & _
            ' "union all " & _
            ' "select Acctno, Foryear, '' as Bus_Code, 'FIRE SAFETY INSP. FEE' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'ff  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') " & _
            ' "union all " & _
            ' "select Acctno, Foryear, '' as Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & acctno & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and not taxcode in ('bt  ','mf  ','sf  ','gf  ','ff  ') group by  Acctno, Foryear, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'')) as xxx order by Foryear desc, AssessTotal, Bus_Code,  Taxbase, isnull(Qtryr1,'x') "

            Dim q_head As String = "select [Acctno],[Foryear],[Bus_Code],[Desc1],[Taxbase],[Annualdue],[Taxdue],[PenDue],[Amt_PenPd],[Discount],[Taxcode],[prevqtr],[Qtryr1],[Qtryr2],[QtrPaid],[Prev],[Statcode],[Newsw],[ModeP],[GradFix],[Capital],[Xsort],[ORNo],[DatePaid],[BrgyCode],[LocaCode],[L_DatePD],[MainAcctCode],[MainAcctDesc],[SubAcctCode],[SubAcctDesc],[Amt_Pd1],[Amt_PenPd1],[NewAmt_Pd],[NewAmt_PenPd],[NewTaxdue],[NewPenDue],[FieldName],[PrevGMonth],[GDateEsta],[GMonthPaid],[DATE_ESTA],[YearPeriod],[NotEdit],[NotDel],[AssessTotal],[UsedTCred],[MainAcctDescPen],[NotDelete],[SubAcctCodePen],[SubAcctDescPen],[MainAcctCodePen],[IsRegBill],[ForClose],[Area],[xTotal],[ADUE],[xSQUENCELocal],[xSQUENCEPen],[xSRS],[xORNO],[xSQUENCE],[RES3],[RES4],[RES5],[RES],[RES1],[RES2],[QAMT],[QDUE],[PenYear],[AAMT],[I_DISCOUNT3],[I_DISCOUNT4],[I_DISCOUNT1],[I_DISCOUNT2],[I_YEAR2],[I_YEAR3],[I_YEAR4],[I_YEAR1],[EDITEDBY],[APPROVED],[DATEAPP],[ForCompromise],[ISPOSTED],[EDITTEDBY],[APPROVEDBY],[TAXBALANCE],[PENBALANCE],[xMainAcctCode],[xMainAcctDesc],[xSubAcctCode],[xSubAcctDesc],[xMainAcctCodePen],[xMainAcctDescPen],[xSubAcctCodePen],[xSubAcctDescPen],[NEW1],[NEW2],[NEW3],[NEW4],[NEW5],[RASSESBY],[Remarks],[Remarks0],[Remarks1],[XDEPT],[ORIGDUEFEEADJ],[TRANSTYPE],[EDPPrinted],[BILLVIEW],[ASSESSNO],[BILLTYPE],[CTC_REMARK],[DATE_EXPIRE],[CTC_AMOUNT],"

            Dim q_footer = " from BILLINGTEMP  where acctno='" & acctno & "' and isregbill='1' order by (case Taxcode when 'bt' then 0 else 1 end)"

            If selectedQTR = 1 Then
                _nQuery = q_head &
                "CASE Taxcode  " &
                "       WHEN 'bt' THEN  ((cast(Annualdue as money) / 4)) " &
                "       WHEN 'gf' THEN  ((cast(Annualdue as money) / 4)) " &
                "       ELSE Amt_Pd" &
                "END Amt_Pd,																			  " &
                "CASE Taxcode" &
                "       WHEN 'bt' THEN (cast(Annualdue as money) / 4) +  [Amt_PenPd] " &
                "       WHEN 'gf' THEN (cast(Annualdue as money) / 4) +  [Amt_PenPd] " &
                "       ELSE Totdue																	  " &
                "END [Totdue],																		      " &
                "pres=STUFF(pres, 3, 1, '1')  														      " &
               q_footer
            ElseIf selectedQTR = 2 Then
                _nQuery = q_head &
                "CASE Taxcode  " &
                "       WHEN 'bt' THEN (cast(Annualdue as money) / 2 ) " &
                "       WHEN 'gf' THEN (cast(Annualdue as money) / 2 ) " &
                "       ELSE Amt_Pd																	  " &
                "END Amt_Pd,																			  " &
                "CASE Taxcode  																		  " &
                "       WHEN 'bt' THEN  (cast(Annualdue as money) / 2 ) +  [Amt_PenPd]  " &
                "       WHEN 'gf' THEN (cast(Annualdue as money) / 2 )  +  [Amt_PenPd] " &
                "       ELSE Totdue																	  " &
                "END [Totdue],																		      " &
                "pres=STUFF(pres, 3, 1, '2')  														      " &
               q_footer
            ElseIf selectedQTR = 3 Then
                _nQuery = q_head &
                "CASE Taxcode  " &
                "       WHEN 'bt' THEN  (cast(Annualdue as money) / 2 ) + (cast(Annualdue as money) / 4)  " &
                "       WHEN 'gf' THEN (cast(Annualdue as money) / 2 ) + (cast(Annualdue as money) / 4)   " &
                "       ELSE Amt_Pd																	  " &
                "END Amt_Pd,																			  " &
                "CASE Taxcode  																		  " &
                "       WHEN 'bt' THEN ((cast(Annualdue as money) / 2 ) + (cast(Annualdue as money) / 4)) +  [Amt_PenPd] " &
                "       WHEN 'gf' THEN ((cast(Annualdue as money) / 2 ) + (cast(Annualdue as money) / 4)) +  [Amt_PenPd] " &
                "       ELSE Totdue																	  " &
                "END [Totdue],																		      " &
                "pres=STUFF(pres, 3, 1, '3')  														      " &
               q_footer
            ElseIf selectedQTR = 4 Then
                _nQuery = q_head &
                "CASE Taxcode  " &
                "       WHEN 'bt' THEN  cast(Annualdue as money)  " &
                "       WHEN 'gf' THEN  cast(Annualdue as money)  " &
                "       ELSE Amt_Pd																	  " &
                "END Amt_Pd,																			  " &
                "CASE Taxcode  																		  " &
                "       WHEN 'bt' THEN (cast(Annualdue as money)) +  [Amt_PenPd] " &
                "       WHEN 'gf' THEN (cast(Annualdue as money)) +  [Amt_PenPd] " &
                "       ELSE Totdue																	  " &
                "END [Totdue],																		      " &
                "pres=STUFF(pres, 3, 1, '4')  														      " &
               q_footer

            Else
                _nQuery = " select * from BILLINGTEMP where ACCTNO='" & acctno & "' and isregbill='1' order by (case Taxcode when 'bt' then 0 else 1 end)"
            End If

            qry = _nQuery
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With

            For Each dr As DataRow In _mDataTable.Rows
                Sum_TotDue += Convert.ToDouble(dr("Totdue"))
                Sum_TotPenDue += Convert.ToDouble(dr("PenDue"))
                Sum_TotTaxDue += Convert.ToDouble(dr("Amt_Pd"))
                Sum_TotETC += Convert.ToDouble(IIf(dr("Discount").ToString.Length = 0, 0, dr("Discount")))
            Next




        Catch ex As Exception
            err = ";_pSubSelectTOP:" & ex.Message

        End Try
    End Sub

    Public Sub _pSubGetAnnualDue(ByRef acctno As String)
        Try
            '----------------------------------       
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT MAX(CASE WHEN TaxCode = 'bt' THEN AnnualDue END) AS BT																" &
                      ",      MAX(CASE WHEN TaxCode = 'gf' THEN AnnualDue END) AS GF																" &
                      "from BILLINGTEMP where ACCTNO='" & acctno & "' and isregbill='1' and (taxcode='bt' or taxcode='gf') and Foryear=year(getdate())	"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iBT As Integer = .GetOrdinal("BT")
                    Dim _iGF As Integer = .GetOrdinal("GF")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                cSessionLoader._pBTAnnualDue = _nSqlDataReader(_iBT).ToString
                                cSessionLoader._pGFAnnualDue = _nSqlDataReader(_iGF).ToString
                            Loop
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGetDate(ByRef getdate As String)
        Try
            '----------------------------------       
            Dim _nQuery As String = Nothing
            _nQuery = "select getdate() as 'getdate'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _igetdate As Integer = .GetOrdinal("getdate")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                getdate = _nSqlDataReader(_igetdate).ToString
                            Loop
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetYear(ByRef getYear As String)
        Try
            '----------------------------------       
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT YEAR(getdate()) as 'getYear'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _igetYear As Integer = .GetOrdinal("getYear")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                getYear = _nSqlDataReader(_igetYear).ToString
                            Loop
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubcheckIfValidInfo( _
        ByVal AppID As String _
      , ByVal Email As String _
      , ByRef OwnershipType As String _
      , ByRef DtiSecCdaNo As String _
      , ByRef TIN As String _
      , ByRef BusName As String _
      , ByRef MainAddress As String _
      , ByRef TelNo As String _
      , ByRef MobNo As String _
      , ByRef OwnerName As String _
      , ByRef Nationality As String _
      , ByRef BusArea As String _
      , ByRef BusFlrArea As String _
      , ByRef NoMaleEmp As String _
      , ByRef NoFemaleEmp As String _
      , ByRef NoEmpResiding As String _
      , ByRef NoVanTruck As String _
      , ByRef NoMotor As String _
      , ByRef BusAddress As String _
      , ByRef Capital As String _
      , ByRef Nature As String _
      , ByRef up_FileData1 As Byte() _
      , ByRef up_FileName1 As String _
      , ByRef up_FileType1 As String _
      , ByRef up_FileStatus1 As String _
      , ByRef up_FileRemarks1 As String _
      , ByRef up_FileData2 As Byte() _
      , ByRef up_FileName2 As String _
      , ByRef up_FileType2 As String _
      , ByRef up_FileStatus2 As String _
      , ByRef up_FileRemarks2 As String _
      , ByRef up_FileData3 As Byte() _
      , ByRef up_FileName3 As String _
      , ByRef up_FileType3 As String _
      , ByRef up_FileStatus3 As String _
      , ByRef up_FileRemarks3 As String _
      , ByRef up_FileData4 As Byte() _
      , ByRef up_FileName4 As String _
      , ByRef up_FileType4 As String _
      , ByRef up_FileStatus4 As String _
      , ByRef up_FileRemarks4 As String _
      , ByRef up_FileData5 As Byte() _
      , ByRef up_FileName5 As String _
      , ByRef up_FileType5 As String _
      , ByRef up_FileStatus5 As String _
      , ByRef up_FileRemarks5 As String _
      , ByRef up_FileData6 As Byte() _
      , ByRef up_FileName6 As String _
      , ByRef up_FileType6 As String _
      , ByRef up_FileStatus6 As String _
      , ByRef up_FileRemarks6 As String _
      , ByRef Status As String, Optional ByRef _err As String = Nothing, Optional ByRef ctr As Integer = 0
)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                "SELECT Application_ID as 'ApplicationNo'," & _
" A_Ownership as 'OwnershipType',A_DtiSecCda as 'DtiSecCdaNo' " & _
" ,A_TIN as 'TIN' " & _
" ,A_BusName as 'BusName' " & _
" ,B_HouseNo + ' ' + B_BldgName + ' ' + B_LotNo + ' ' + B_BlockNo + ' ' +  B_Street + ' ' + B_Brgy + ' ' + B_Subd + ' ' + B_CityMunicipality + ' ' + B_Province + ' ' + B_ZipCode as 'MainAddress'" & _
" ,C_TelNo as 'TelNo'" & _
" ,C_MobileNo as 'MobNo'" & _
" ,D_Lname + ' ' + D_Fname +', ' + D_Mname + ' ' + D_Suffix as 'OwnerName'" & _
" ,E_Nationality as 'Nationality'" & _
" ,F_BusArea as 'BusArea'" & _
" ,F_FlrArea as 'BusFlrArea'" & _
" ,F_MaleEmpNo as 'NoMaleEmp'" & _
" ,F_FemaleEmpNo as 'NoFemaleEmp'" & _
" ,F_ResideEmpNo as 'NoEmpResiding'" & _
" ,F_VanTruckNo as 'NoVanTruck'" & _
" ,F_MotorNo as 'NoMotor'" & _
" ,G_HouseNo + ' ' + G_BldgName + ' ' + G_LotNo + ' ' + G_BlockNo + ' ' +  G_Street + ' ' + G_Brgy + ' ' + G_Subd + ' ' + G_CityMunicipality + ' ' + G_Province + ' ' + G_ZipCode as 'BusAddress'" & _
" ,H_Capital as 'Capital'" & _
" ,H_Nature as 'Nature'" & _
" ,[I_OwnerPicFileData]	  as 'up_FileData1'" & _
" ,[I_OwnerPicFileName]	  as 'up_FileName1'" & _
" ,[I_OwnerPicFileType]	  as 'up_FileType1'" & _
" ,[I_OwnerPicStatus]	  as 'up_FileStatus1'" & _
" ,[I_OwnerPicRemarks]	  as 'up_FileRemarks1'" & _
" ,[I_BusEstPicFileData]  as 'up_FileData2'" & _
" ,[I_BusEstPicFileName]  as 'up_FileName2'" & _
" ,[I_BusEstPicFileType]  as 'up_FileType2'" & _
" ,[I_BusEstPicStatus]	  as 'up_FileStatus2'" & _
" ,[I_BusEstPicRemarks]	  as 'up_FileRemarks2'" & _
" ,[I_BusMapPicFileData]  as 'up_FileData3'" & _
" ,[I_BusMapPicFileName]  as 'up_FileName3'" & _
" ,[I_BusMapPicFileType]  as 'up_FileType3'" & _
" ,[I_BusMapPicStatus]	  as 'up_FileStatus3'" & _
" ,[I_BusMapPicRemarks]	  as 'up_FileRemarks3'" & _
" ,[I_AppFormFileData]	  as 'up_FileData4'" & _
" ,[I_AppFormFileName]	  as 'up_FileName4'" & _
" ,[I_AppFormFileType]	  as 'up_FileType4'" & _
" ,[I_AppFormStatus]	  as 'up_FileStatus4'" & _
" ,[I_AppFormRemarks]	  as 'up_FileRemarks4'" & _
" ,[I_DtiSecCdaFileData]  as 'up_FileData5'" & _
" ,[I_DtiSecCdaFileName]  as 'up_FileName5'" & _
" ,[I_DtiSecCdaFileType]  as 'up_FileType5'" & _
" ,[I_DtiSecCdaFileStatus]  as 'up_FileStatus5'" & _
" ,[I_DtiSecCdaFileRemarks] as 'up_FileRemarks5'" & _
" ,[I_TINFileData]		  as 'up_FileData6'" & _
" ,[I_TINFileName]		  as 'up_FileName6'" & _
" ,[I_TINFileType]		  as 'up_FileType6'" & _
" ,[I_TINFileStatus]		  as 'up_FileStatus6'" & _
" ,[I_TINFileRemarks]		  as 'up_FileRemarks6'," & _
" Status  FROM [NewBP_Draft] where C_Email='" & Email & "' and Application_ID='" & AppID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplicationNo As Integer = .GetOrdinal("ApplicationNo")
                    Dim _iOwnershipType As Integer = .GetOrdinal("OwnershipType")
                    Dim _iDtiSecCdaNo As Integer = .GetOrdinal("DtiSecCdaNo")
                    Dim _iTIN As Integer = .GetOrdinal("TIN")
                    Dim _iBusName As Integer = .GetOrdinal("BusName")
                    Dim _iMainAddress As Integer = .GetOrdinal("MainAddress")
                    Dim _iTelNo As Integer = .GetOrdinal("TelNo")
                    Dim _iMobNo As Integer = .GetOrdinal("MobNo")
                    Dim _iOwnerName As Integer = .GetOrdinal("OwnerName")
                    Dim _iNationality As Integer = .GetOrdinal("Nationality")
                    Dim _iBusArea As Integer = .GetOrdinal("BusArea")
                    Dim _iBusFlrArea As Integer = .GetOrdinal("BusFlrArea")
                    Dim _iNoMaleEmp As Integer = .GetOrdinal("NoMaleEmp")
                    Dim _iNoFemaleEmp As Integer = .GetOrdinal("NoFemaleEmp")
                    Dim _iNoEmpResiding As Integer = .GetOrdinal("NoEmpResiding")
                    Dim _iNoVanTruck As Integer = .GetOrdinal("NoVanTruck")
                    Dim _iNoMotor As Integer = .GetOrdinal("NoMotor")
                    Dim _iBusAddress As Integer = .GetOrdinal("BusAddress")
                    Dim _iCapital As Integer = .GetOrdinal("Capital")
                    Dim _iNature As Integer = .GetOrdinal("Nature")
                    Dim _iup_FileData1 As Integer = .GetOrdinal("up_FileData1")
                    Dim _iup_FileName1 As Integer = .GetOrdinal("up_FileName1")
                    Dim _iup_FileType1 As Integer = .GetOrdinal("up_FileType1")
                    Dim _iup_FileStatus1 As Integer = .GetOrdinal("up_FileStatus1")
                    Dim _iup_FileRemarks1 As Integer = .GetOrdinal("up_FileRemarks1")
                    Dim _iup_FileData2 As Integer = .GetOrdinal("up_FileData2")
                    Dim _iup_FileName2 As Integer = .GetOrdinal("up_FileName2")
                    Dim _iup_FileType2 As Integer = .GetOrdinal("up_FileType2")
                    Dim _iup_FileStatus2 As Integer = .GetOrdinal("up_FileStatus2")
                    Dim _iup_FileRemarks2 As Integer = .GetOrdinal("up_FileRemarks2")
                    Dim _iup_FileData3 As Integer = .GetOrdinal("up_FileData3")
                    Dim _iup_FileName3 As Integer = .GetOrdinal("up_FileName3")
                    Dim _iup_FileType3 As Integer = .GetOrdinal("up_FileType3")
                    Dim _iup_FileStatus3 As Integer = .GetOrdinal("up_FileStatus3")
                    Dim _iup_FileRemarks3 As Integer = .GetOrdinal("up_FileRemarks3")
                    Dim _iup_FileData4 As Integer = .GetOrdinal("up_FileData4")
                    Dim _iup_FileName4 As Integer = .GetOrdinal("up_FileName4")
                    Dim _iup_FileType4 As Integer = .GetOrdinal("up_FileType4")
                    Dim _iup_FileStatus4 As Integer = .GetOrdinal("up_FileStatus4")
                    Dim _iup_FileRemarks4 As Integer = .GetOrdinal("up_FileRemarks4")
                    Dim _iup_FileData5 As Integer = .GetOrdinal("up_FileData5")
                    Dim _iup_FileName5 As Integer = .GetOrdinal("up_FileName5")
                    Dim _iup_FileType5 As Integer = .GetOrdinal("up_FileType5")
                    Dim _iup_FileStatus5 As Integer = .GetOrdinal("up_FileStatus5")
                    Dim _iup_FileRemarks5 As Integer = .GetOrdinal("up_FileRemarks5")
                    Dim _iup_FileData6 As Integer = .GetOrdinal("up_FileData6")
                    Dim _iup_FileName6 As Integer = .GetOrdinal("up_FileName6")
                    Dim _iup_FileType6 As Integer = .GetOrdinal("up_FileType6")
                    Dim _iup_FileStatus6 As Integer = .GetOrdinal("up_FileStatus6")
                    Dim _iup_FileRemarks6 As Integer = .GetOrdinal("up_FileRemarks6")
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    '----------------------------------

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                'Status = _nSqlDataReader(_iStatus).ToString
                                'OwnershipType = _nSqlDataReader(_iOwnershipType).ToString
                                'DtiSecCdaNo = _nSqlDataReader(_iDtiSecCdaNo).ToString
                                'TIN = _nSqlDataReader(_iTIN).ToString
                                'BusName = _nSqlDataReader(_iBusName).ToString
                                'MainAddress = _nSqlDataReader(_iMainAddress).ToString
                                'TelNo = _nSqlDataReader(_iTelNo).ToString
                                'MobNo = _nSqlDataReader(_iMobNo).ToString
                                'OwnerName = _nSqlDataReader(_iOwnerName).ToString
                                'Nationality = _nSqlDataReader(_iNationality).ToString
                                'BusArea = _nSqlDataReader(_iBusArea).ToString
                                'BusFlrArea = _nSqlDataReader(_iBusFlrArea).ToString
                                'NoMaleEmp = _nSqlDataReader(_iNoMaleEmp).ToString
                                'NoFemaleEmp = _nSqlDataReader(_iNoFemaleEmp).ToString
                                'NoEmpResiding = _nSqlDataReader(_iNoEmpResiding).ToString
                                'NoVanTruck = _nSqlDataReader(_iNoVanTruck).ToString
                                'NoMotor = _nSqlDataReader(_iNoMotor).ToString
                                'BusAddress = _nSqlDataReader(_iBusAddress).ToString
                                'Capital = _nSqlDataReader(_iCapital).ToString
                                'Nature = _nSqlDataReader(_iNature).ToString
                                'up_FileData1 = ._pReturnByteArray(_nSqlDataReader(_iup_FileData1).ToString
                                'up_FileName1 = _nSqlDataReader(_iup_FileName1).ToString
                                'up_FileType1 = _nSqlDataReader(_iup_FileType1).ToString
                                'up_FileStatus1 = _nSqlDataReader(_iup_FileStatus1).ToString
                                'up_FileRemarks1 = _nSqlDataReader(_iup_FileRemarks1).ToString
                                'up_FileData2 = ._pReturnByteArray(_nSqlDataReader(_iup_FileData2).ToString
                                'up_FileName2 = _nSqlDataReader(_iup_FileName2).ToString
                                'up_FileType2 = _nSqlDataReader(_iup_FileType2).ToString
                                'up_FileStatus2 = _nSqlDataReader(_iup_FileStatus2).ToString
                                'up_FileRemarks2 = _nSqlDataReader(_iup_FileRemarks2).ToString
                                'up_FileData3 = ._pReturnByteArray(_nSqlDataReader(_iup_FileData3).ToString
                                'up_FileName3 = _nSqlDataReader(_iup_FileName3).ToString
                                'up_FileType3 = _nSqlDataReader(_iup_FileType3).ToString
                                'up_FileStatus3 = _nSqlDataReader(_iup_FileStatus3).ToString
                                'up_FileRemarks3 = _nSqlDataReader(_iup_FileRemarks3).ToString
                                'up_FileData4 = ._pReturnByteArray(_nSqlDataReader(_iup_FileData4).ToString
                                'up_FileName4 = _nSqlDataReader(_iup_FileName4).ToString
                                'up_FileType4 = _nSqlDataReader(_iup_FileType4).ToString
                                'up_FileStatus4 = _nSqlDataReader(_iup_FileStatus4).ToString
                                'up_FileRemarks4 = _nSqlDataReader(_iup_FileRemarks4).ToString
                                'up_FileData5 = ._pReturnByteArray(_nSqlDataReader(_iup_FileData5).ToString
                                'up_FileName5 = _nSqlDataReader(_iup_FileName5).ToString
                                'up_FileType5 = _nSqlDataReader(_iup_FileType5).ToString
                                'up_FileStatus5 = _nSqlDataReader(_iup_FileStatus5).ToString
                                'up_FileRemarks5 = _nSqlDataReader(_iup_FileRemarks5).ToString
                                'up_FileData6 = ._pReturnByteArray(_nSqlDataReader(_iup_FileData6).ToString
                                'up_FileName6 = _nSqlDataReader(_iup_FileName6).ToString
                                'up_FileType6 = _nSqlDataReader(_iup_FileType6).ToString
                                'up_FileStatus6 = _nSqlDataReader(_iup_FileStatus6).ToString
                                'up_FileRemarks6 = _nSqlDataReader(_iup_FileRemarks6).ToString

                                Dim byteArray = New Byte() {} ' Empty byte array or assign any other default value
                                ctr = 1
                                Status = _nSqlDataReader(_iStatus).ToString
                                ctr = 2
                                OwnershipType = _nSqlDataReader(_iOwnershipType).ToString
                                ctr = 3
                                DtiSecCdaNo = _nSqlDataReader(_iDtiSecCdaNo).ToString
                                ctr = 4
                                TIN = _nSqlDataReader(_iTIN).ToString
                                ctr = 5
                                BusName = _nSqlDataReader(_iBusName).ToString
                                ctr = 6
                                MainAddress = _nSqlDataReader(_iMainAddress).ToString
                                ctr = 7
                                TelNo = _nSqlDataReader(_iTelNo).ToString
                                ctr = 8
                                MobNo = _nSqlDataReader(_iMobNo).ToString
                                ctr = 9
                                OwnerName = _nSqlDataReader(_iOwnerName).ToString
                                ctr = 10
                                Nationality = _nSqlDataReader(_iNationality).ToString
                                ctr = 11
                                BusArea = _nSqlDataReader(_iBusArea).ToString
                                ctr = 12
                                BusFlrArea = _nSqlDataReader(_iBusFlrArea).ToString
                                ctr = 13
                                NoMaleEmp = _nSqlDataReader(_iNoMaleEmp).ToString
                                ctr = 14
                                NoFemaleEmp = _nSqlDataReader(_iNoFemaleEmp).ToString
                                ctr = 15
                                NoEmpResiding = _nSqlDataReader(_iNoEmpResiding).ToString
                                ctr = 16
                                NoVanTruck = _nSqlDataReader(_iNoVanTruck).ToString
                                ctr = 17
                                NoMotor = _nSqlDataReader(_iNoMotor).ToString
                                ctr = 18
                                BusAddress = _nSqlDataReader(_iBusAddress).ToString
                                ctr = 19
                                Capital = _nSqlDataReader(_iCapital).ToString
                                ctr = 20
                                Nature = _nSqlDataReader(_iNature).ToString
                                ctr = 21
                                up_FileData1 = IIf(_nSqlDataReader(_iup_FileData1) IsNot DBNull.Value, _nSqlDataReader(_iup_FileData1), byteArray)
                                ctr = 22
                                up_FileName1 = _nSqlDataReader(_iup_FileName1).ToString
                                ctr = 23
                                up_FileType1 = _nSqlDataReader(_iup_FileType1).ToString
                                ctr = 24
                                up_FileStatus1 = _nSqlDataReader(_iup_FileStatus1).ToString
                                ctr = 25
                                up_FileRemarks1 = _nSqlDataReader(_iup_FileRemarks1).ToString
                                ctr = 26
                                up_FileData2 = IIf(_nSqlDataReader(_iup_FileData2) IsNot DBNull.Value, _nSqlDataReader(_iup_FileData2), byteArray)
                                ctr = 27
                                up_FileName2 = _nSqlDataReader(_iup_FileName2).ToString
                                ctr = 28
                                up_FileType2 = _nSqlDataReader(_iup_FileType2).ToString
                                ctr = 29
                                up_FileStatus2 = _nSqlDataReader(_iup_FileStatus2).ToString
                                ctr = 30
                                up_FileRemarks2 = _nSqlDataReader(_iup_FileRemarks2).ToString
                                ctr = 31
                                up_FileData3 = IIf(_nSqlDataReader(_iup_FileData3) IsNot DBNull.Value, _nSqlDataReader(_iup_FileData3), byteArray)
                                ctr = 32
                                up_FileName3 = _nSqlDataReader(_iup_FileName3).ToString
                                ctr = 33
                                up_FileType3 = _nSqlDataReader(_iup_FileType3).ToString
                                ctr = 34
                                up_FileStatus3 = _nSqlDataReader(_iup_FileStatus3).ToString
                                ctr = 35
                                up_FileRemarks3 = _nSqlDataReader(_iup_FileRemarks3).ToString
                                ctr = 36
                                up_FileData4 = IIf(_nSqlDataReader(_iup_FileData4) IsNot DBNull.Value, _nSqlDataReader(_iup_FileData4), byteArray)
                                ctr = 37
                                up_FileName4 = _nSqlDataReader(_iup_FileName4).ToString
                                ctr = 38
                                up_FileType4 = _nSqlDataReader(_iup_FileType4).ToString
                                ctr = 39
                                up_FileStatus4 = _nSqlDataReader(_iup_FileStatus4).ToString
                                ctr = 40
                                up_FileRemarks4 = _nSqlDataReader(_iup_FileRemarks4).ToString
                                ctr = 41
                                up_FileData5 = IIf(_nSqlDataReader(_iup_FileData5) IsNot DBNull.Value, _nSqlDataReader(_iup_FileData5), byteArray)
                                ctr = 42
                                up_FileName5 = _nSqlDataReader(_iup_FileName5).ToString
                                ctr = 43
                                up_FileType5 = _nSqlDataReader(_iup_FileType5).ToString
                                ctr = 44
                                up_FileStatus5 = _nSqlDataReader(_iup_FileStatus5).ToString
                                ctr = 45
                                up_FileRemarks5 = _nSqlDataReader(_iup_FileRemarks5).ToString
                                ctr = 46
                                up_FileData6 = IIf(_nSqlDataReader(_iup_FileData6) IsNot DBNull.Value, _nSqlDataReader(_iup_FileData6), byteArray)
                                ctr = 47
                                up_FileName6 = _nSqlDataReader(_iup_FileName6).ToString
                                ctr = 48
                                up_FileType6 = _nSqlDataReader(_iup_FileType6).ToString
                                ctr = 49
                                up_FileStatus6 = _nSqlDataReader(_iup_FileStatus6).ToString
                                ctr = 50
                                up_FileRemarks6 = _nSqlDataReader(_iup_FileRemarks6).ToString

                            Loop

                            Capital = Capital.Format("{0:n}", Double.Parse(Capital))
                        End If

                    End With
                End With

                _nSqlDataReader.Close()

            End Using
        Catch ex As Exception
            _err += ";_pSubcheckIfValidInfo:" & ex.Message
        End Try
    End Sub



    Public Sub _pSubCheckIfExist(ByRef DraftExists As Boolean, ByRef Application_ID As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from NewBP_Draft where userID = '" & cSessionUser._pUserID & "' and Application_ID='" & Application_ID & "'" ' and Submitted=0"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplication_ID As Integer = .GetOrdinal("Application_ID")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                DraftExists = True
                                Application_ID = _nSqlDataReader(_iApplication_ID).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetPeriodCovered(ByVal ACCTNO As String, _
                                  ByRef PeriodCovered As String, _
                                  ByRef PayMode As String, _
                                  ByRef Foryear As String)
        Try
            Dim _nQuery As String = Nothing
            '  _nQuery = "SELECT top 1 (Pres +' '+ Prev) as 'PeriodCovered', ModeP as 'PayMode',Foryear from [BILLINGTEMP] where acctno ='" & ACCTNO & "';"
            '
            _nQuery = "" &
                      " SELECT top 1 (Pres +' '+ Prev) as 'PeriodCovered', CASE" &
                      " WHEN ModeP='A' THEN 'Annual'" &
                      " WHEN ModeP='S' THEN 'Semi-Annual'" &
                      " WHEN ModeP='Q' THEN 'Quarterly'" &
                      " ELSE ModeP	END " &
                      " as 'PayMode',Foryear from [BILLINGTEMP] 	" &
                      " where acctno ='" & ACCTNO & "'  and taxcode='bt' order by Foryear desc;"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iPeriodCovered As Integer = .GetOrdinal("PeriodCovered")
                    Dim _iPayMode As Integer = .GetOrdinal("PayMode")
                    Dim _iForYear As Integer = .GetOrdinal("ForYear")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                PeriodCovered = _nSqlDataReader(_iPeriodCovered).ToString
                                PayMode = _nSqlDataReader(_iPayMode).ToString
                                Foryear = _nSqlDataReader(_iForYear).ToString
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectSubmitted(ByVal AppID As String, ByVal Email As String, ByVal Switch As String, _
                                    ByRef ClearanceNo As String, _
                                    ByRef Info1 As String, _
                                    ByRef Info2 As String, _
                                    ByRef Info3 As String, _
                                    ByRef Info4 As String, _
                                    ByRef Info5 As String, _
                                    ByRef Status As String,
                                    ByRef Remarks As String, _
                                    ByRef Date_Assessed As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from NewBP_RegulatorySubmitted2 where userID = '" & cSessionUser._pUserID & "' and Application_ID='" & AppID & "' and Switch='" & Switch & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iClearanceNo As Integer = .GetOrdinal("Clearance_No")
                    Dim _iInfo1 As Integer = .GetOrdinal("Info1")
                    Dim _iInfo2 As Integer = .GetOrdinal("Info2")
                    Dim _iInfo3 As Integer = .GetOrdinal("Info3")
                    Dim _iInfo4 As Integer = .GetOrdinal("Info4")
                    Dim _iInfo5 As Integer = .GetOrdinal("Info5")
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    Dim _iRemarks As Integer = .GetOrdinal("Remarks")
                    Dim _iDate_Assessed As Integer = .GetOrdinal("Date_Assessed")


                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                ClearanceNo = _nSqlDataReader(_iClearanceNo).ToString
                                Info1 = _nSqlDataReader(_iInfo1).ToString
                                Info2 = _nSqlDataReader(_iInfo2).ToString
                                Info3 = _nSqlDataReader(_iInfo3).ToString
                                Info4 = _nSqlDataReader(_iInfo4).ToString
                                Info5 = _nSqlDataReader(_iInfo5).ToString
                                Status = _nSqlDataReader(_iStatus).ToString
                                Remarks = _nSqlDataReader(_iRemarks).ToString
                                Date_Assessed = _nSqlDataReader(_iDate_Assessed).ToString
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect4(ByVal AppID As String, ByRef BusName As String, ByRef BusAdd As String, ByRef brgy As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select *,(B_HouseNo + ', ' + B_BldgName + ', ' + B_LotNo + ', ' + B_BlockNo + ', ' + B_Street + ', ' + B_Brgy + ', ' + B_Subd + ', ' + B_CityMunicipality + ', ' + B_Province + ', ' + B_ZipCode) as 'BusAdd' from NewBP_Draft where userID = '" & cSessionUser._pUserID & "' and Application_ID='" & AppID & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iBusName As Integer = .GetOrdinal("A_BusName")
                    Dim _iBusAdd As Integer = .GetOrdinal("BusAdd")
                    Dim _ibrgy As Integer = .GetOrdinal("B_Brgy")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                BusName = _nSqlDataReader(_iBusName).ToString
                                BusAdd = _nSqlDataReader(_iBusAdd).ToString
                                brgy = _nSqlDataReader(_ibrgy).ToString

                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGet_REgulatoryStatus(ByVal AppID As String, ByVal SWITCH As String, ByRef Status As Boolean, ByRef StatusDesc As String, ByRef Remarks As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_RegulatorySubmitted2] where Application_ID='" & AppID & "' and SWITCH='" & SWITCH & "' and Status='Approved'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iRemarks As Integer = .GetOrdinal("Remarks")
                    Dim _iStatusDesc As Integer = .GetOrdinal("Status")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Status = True
                                StatusDesc = _nSqlDataReader(_iStatusDesc).ToString
                                If StatusDesc = "Approved" Then
                                    StatusDesc = "<b style=color:green>Approved</b>"
                                ElseIf StatusDesc = "Rejected" Then
                                    StatusDesc = "<b style=color:red>Rejected</b>"
                                End If
                                Remarks = _nSqlDataReader(_iRemarks).ToString
                            Loop
                        Else
                            Status = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubDisplayExisting(ByVal Application_ID As String, ByVal UserID As String,
                                ByRef A As String, ByRef B As String, ByRef C As String,
                                ByRef D As String, ByRef E As String, ByRef F As String,
                                ByRef G As String, _
                                ByRef H_Capital As String,
                                ByRef H_Nature As String,
                                ByRef H_Owned As String,
                                ByRef H_TDN As String,
                                ByRef H_PIN As String,
                                ByRef H_GovIncentive As String,
                                ByRef H_BusAct As String,
                                ByRef H_D1 As Byte(), ByRef H_N1 As String, ByRef H_T1 As String, _
                                ByRef I_D1 As Byte(), ByRef I_N1 As String, ByRef I_T1 As String, _
                                ByRef I_D2 As Byte(), ByRef I_N2 As String, ByRef I_T2 As String, _
                                ByRef I_D3 As Byte(), ByRef I_N3 As String, ByRef I_T3 As String, _
                                ByRef I_D4 As Byte(), ByRef I_N4 As String, ByRef I_T4 As String, _
                                ByRef I_D5 As Byte(), ByRef I_N5 As String, ByRef I_T5 As String, _
                                ByRef I_D6 As Byte(), ByRef I_N6 As String, ByRef I_T6 As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT  ([A_Ownership] +';'+ [A_DtiSecCda]  +';'+ [A_BusName] +';'+ [A_TIN]) as 'A'" & _
     ",([B_HouseNo] +';'+ [B_BldgName] +';'+ [B_LotNo]  +';'+ [B_BlockNo]+';'+ [B_Street]+';'+ [B_Brgy]+';'+ [B_Subd]+';'+ [B_CityMunicipality]+';'+ [B_Province]+';'+ [B_ZipCode]) as 'B'" & _
     ",([C_TelNo]+';'+[C_MobileNo]+';'+[C_Email]) as 'C'" & _
     ",([D_Lname]+';'+[D_Fname]+';'+[D_Mname]+';'+[D_Suffix]) as 'D'" & _
     ",([E_Lname]+';'+[E_Fname]+';'+[E_Mname]+';'+[E_Suffix]+';'+[E_Nationality]) as 'E'" & _
     ",([F_BusArea]+';'+[F_FlrArea]+';'+[F_MaleEmpNo]+';'+[F_FemaleEmpNo]+';'+[F_ResideEmpNo]+';'+[F_VanTruckNo]+';'+[F_MotorNo]) as 'F'" & _
     ",([G_HouseNo]+';'+[G_BldgName]+';'+[G_LotNo]+';'+[G_BlockNo]+';'+[G_Street]+';'+[G_Brgy]+';'+[G_Subd]+';'+[G_CityMunicipality]+';'+[G_Province]+';'+[G_ZipCode]) as 'G'" & _
     ",* " & _
     "FROM [NewBP_Draft]where userID = '" & cSessionUser._pUserID & "'"


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iA As Integer = .GetOrdinal("A")
                    Dim _iB As Integer = .GetOrdinal("B")
                    Dim _iC As Integer = .GetOrdinal("C")
                    Dim _iD As Integer = .GetOrdinal("D")
                    Dim _iE As Integer = .GetOrdinal("E")
                    Dim _iF As Integer = .GetOrdinal("F")
                    Dim _iG As Integer = .GetOrdinal("G")
                    Dim _iH_Capital As Integer = .GetOrdinal("H_Capital")
                    Dim _iH_Nature As Integer = .GetOrdinal("H_Nature")
                    Dim _iH_Owned As Integer = .GetOrdinal("H_Owned")
                    Dim _iH_TDN As Integer = .GetOrdinal("H_TDN")
                    Dim _iH_PIN As Integer = .GetOrdinal("H_PIN")
                    Dim _iH_GovIncentive As Integer = .GetOrdinal("H_GovIncentive")
                    Dim _iH_BusAct As Integer = .GetOrdinal("H_BusAct")

                    Dim _iH_D1 As Integer = .GetOrdinal("H_GovIncentiveFileData")
                    Dim _iH_N1 As Integer = .GetOrdinal("H_GovIncentiveFileName")
                    Dim _iH_T1 As Integer = .GetOrdinal("H_GovIncentiveFileType")

                    Dim _iI_D1 As Integer = .GetOrdinal("I_OwnerPicFileData")
                    Dim _iI_N1 As Integer = .GetOrdinal("I_OwnerPicFileName")
                    Dim _iI_T1 As Integer = .GetOrdinal("I_OwnerPicFileType")

                    Dim _iI_D2 As Integer = .GetOrdinal("I_BusEstPicFileData")
                    Dim _iI_N2 As Integer = .GetOrdinal("I_BusEstPicFileName")
                    Dim _iI_T2 As Integer = .GetOrdinal("I_BusEstPicFileType")

                    Dim _iI_D3 As Integer = .GetOrdinal("I_BusMapPicFileData")
                    Dim _iI_N3 As Integer = .GetOrdinal("I_BusMapPicFileName")
                    Dim _iI_T3 As Integer = .GetOrdinal("I_BusMapPicFileType")

                    Dim _iI_D4 As Integer = .GetOrdinal("I_AppFormFileData")
                    Dim _iI_N4 As Integer = .GetOrdinal("I_AppFormFileName")
                    Dim _iI_T4 As Integer = .GetOrdinal("I_AppFormFileType")

                    Dim _iI_D5 As Integer = .GetOrdinal("I_DtiSecCdaFileData")
                    Dim _iI_N5 As Integer = .GetOrdinal("I_DtiSecCdaFileName")
                    Dim _iI_T5 As Integer = .GetOrdinal("I_DtiSecCdaFileType")

                    Dim _iI_D6 As Integer = .GetOrdinal("I_TINFileData")
                    Dim _iI_N6 As Integer = .GetOrdinal("I_TINFileName")
                    Dim _iI_T6 As Integer = .GetOrdinal("I_TINFileType")



                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                A = _nSqlDataReader(_iA).ToString
                                B = _nSqlDataReader(_iB).ToString
                                C = _nSqlDataReader(_iC).ToString
                                D = _nSqlDataReader(_iD).ToString
                                E = _nSqlDataReader(_iE).ToString
                                F = _nSqlDataReader(_iF).ToString
                                G = _nSqlDataReader(_iG).ToString

                                H_Capital = _nSqlDataReader(_iH_Capital).ToString
                                H_Nature = _nSqlDataReader(_iH_Nature).ToString
                                H_Owned = _nSqlDataReader(_iH_Owned).ToString
                                H_TDN = _nSqlDataReader(_iH_TDN).ToString
                                H_PIN = _nSqlDataReader(_iH_PIN).ToString
                                H_GovIncentive = _nSqlDataReader(_iH_GovIncentive).ToString
                                H_BusAct = _nSqlDataReader(_iH_BusAct).ToString

                                H_D1 = _nSqlDataReader(_iH_D1)
                                H_N1 = _nSqlDataReader(_iH_N1).ToString
                                H_T1 = _nSqlDataReader(_iH_T1).ToString

                                I_D1 = _nSqlDataReader(_iI_D1)
                                I_N1 = _nSqlDataReader(_iI_N1).ToString
                                I_T1 = _nSqlDataReader(_iI_T1).ToString

                                I_D2 = _nSqlDataReader(_iI_D2)
                                I_N2 = _nSqlDataReader(_iI_N2).ToString
                                I_T2 = _nSqlDataReader(_iI_T2).ToString

                                I_D3 = _nSqlDataReader(_iI_D3)
                                I_N3 = _nSqlDataReader(_iI_N3).ToString
                                I_T3 = _nSqlDataReader(_iI_T3).ToString

                                I_D4 = _nSqlDataReader(_iI_D4)
                                I_N4 = _nSqlDataReader(_iI_N4).ToString
                                I_T4 = _nSqlDataReader(_iI_T4).ToString

                                I_D5 = _nSqlDataReader(_iI_D5)
                                I_N5 = _nSqlDataReader(_iI_N5).ToString
                                I_T5 = _nSqlDataReader(_iI_T5).ToString

                                I_D6 = _nSqlDataReader(_iI_D6)
                                I_N6 = _nSqlDataReader(_iI_N6).ToString
                                I_T6 = _nSqlDataReader(_iI_T6).ToString

                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubApplicationID(ByRef ApplicationID As String)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select 'NBP' + replace(CONVERT(date, getdate()),'-','') +'-'+  REPLACE(STR(CAST((select count(*)+1 from NewBP_Draft) AS nvarchar),5),' ','0') as 'ApplicationID'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplicationID As Integer = .GetOrdinal("ApplicationID")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                ApplicationID = _nSqlDataReader(_iApplicationID).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGet_CityProvince(ByRef City_Municipality As String, ByRef Province As String)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select LGU_NAME as 'City_Municipality', rpt_header1 as 'Province' from LGU_Profile"
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_CR)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iCity_Municipality As Integer = .GetOrdinal("City_Municipality")
                    Dim _iProvince As Integer = .GetOrdinal("Province")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                City_Municipality = _nSqlDataReader(_iCity_Municipality).ToString
                                Province = _nSqlDataReader(_iProvince).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckFastApply(ByRef Status As Boolean)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select Status from ModuleSetup where SubModule='BP_FastApply'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Status = _nSqlDataReader(_iStatus).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGetACCTNO(ByRef acctno As String, Optional ByRef err As String = Nothing)
        Dim _nQuery As String = Nothing
        Try

            _nQuery = "select ACCTNO from busmast where PBN='" & Application_ID & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iacctno As Integer = .GetOrdinal("acctno")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                acctno = _nSqlDataReader(_iacctno).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception
            err = ";_pSubGetACCTNO:" & ex.Message & ":" & _nQuery
        End Try
    End Sub

    Public Sub _pSubGetAppidEmail(ByVal ACCTNO As String, ByRef AppID As String, ByRef Email As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                "select Application_ID,UserID from NewBP_Draft where ACCTNO='" & ACCTNO & "'" & _
                "union select ACCTNO,email2 from BUSDETAIL where ACCTNO='" & ACCTNO & "'"
            '"select Application_ID,UserID from NewBP_Draft where ACCTNO='" & ACCTNO & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iAppID As Integer = .GetOrdinal("Application_ID")
                    Dim _iEmail As Integer = .GetOrdinal("UserID")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                AppID = _nSqlDataReader(_iAppID).ToString
                                Email = _nSqlDataReader(_iEmail).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub checkBusMastStatus(ByRef nStatus As String, ByVal ACCTNO As String, ByRef exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select Remarks from busmast where ACCTNO='" & ACCTNO & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _inStatus As Integer = .GetOrdinal("Remarks")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                exists = True
                                nStatus = _nSqlDataReader(_inStatus).ToString
                            Loop
                        Else
                            exists = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertDraft(ByVal Application_ID As String, ByVal UserID As String,
                                ByVal A() As String, ByVal B() As String, ByVal C() As String,
                                ByVal D() As String, ByVal E() As String, ByVal F() As String,
                                ByVal G() As String, ByVal H() As String, _
                                ByVal H_D1 As Byte(), ByVal H_N1 As String, ByVal H_T1 As String, _
                                ByVal I_D1 As Byte(), ByVal I_N1 As String, ByVal I_T1 As String, _
                                ByVal I_D2 As Byte(), ByVal I_N2 As String, ByVal I_T2 As String, _
                                ByVal I_D3 As Byte(), ByVal I_N3 As String, ByVal I_T3 As String, _
                                ByVal I_D4 As Byte(), ByVal I_N4 As String, ByVal I_T4 As String, _
                                ByVal I_D5 As Byte(), ByVal I_N5 As String, ByVal I_T5 As String, _
                                ByVal I_D6 As Byte(), ByVal I_N6 As String, ByVal I_T6 As String)
        Dim Submitted As Integer = 0
        Dim getdate As Date
        _pSubGetDate(getdate)

        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO NewBP_Draft VALUES(" & _
                       "@Application_ID," & _
                       "@UserID," & _
                       "@A_Ownership," & _
                       "@A_DtiSecCda," & _
                       "@A_BusName," & _
                       "@A_TIN," & _
                       "@B_HouseNo," & _
                       "@B_BldgName," & _
                       "@B_LotNo," & _
                       "@B_BlockNo," & _
                       "@B_Street," & _
                       "@B_Brgy," & _
                       "@B_Subd," & _
                       "@B_CityMunicipality," & _
                       "@B_Province," & _
                       "@B_ZipCode," & _
                       "@C_TelNo," & _
                       "@C_MobileNo," & _
                       "@C_Email," & _
                       "@D_Lname," & _
                       "@D_Fname," & _
                       "@D_Mname," & _
                       "@D_Suffix," & _
                       "@E_Lname," & _
                       "@E_Fname," & _
                       "@E_Mname," & _
                       "@E_Suffix," & _
                       "@E_Nationality," & _
                       "@F_BusArea," & _
                       "@F_FlrArea," & _
                       "@F_MaleEmpNo," & _
                       "@F_FemaleEmpNo," & _
                       "@F_ResideEmpNo," & _
                       "@F_VanTruckNo," & _
                       "@F_MotorNo," & _
                       "@G_HouseNo," & _
                       "@G_BldgName," & _
                       "@G_LotNo," & _
                       "@G_BlockNo," & _
                       "@G_Street," & _
                       "@G_Brgy," & _
                       "@G_Subd," & _
                       "@G_CityMunicipality," & _
                       "@G_Province," & _
                       "@G_ZipCode," & _
                       "@H_Capital," & _
                       "@H_Nature," & _
                       "@H_Owned," & _
                       "@H_TDN," & _
                       "@H_PIN," & _
                       "@H_GovIncentive," & _
                       "@H_GovIncentiveFileData," & _
                       "@H_GovIncentiveFileName," & _
                       "@H_GovIncentiveFileType," & _
                       "@H_BusAct," & _
                       "@I_OwnerPicFileData," & _
                       "@I_OwnerPicFileName," & _
                       "@I_OwnerPicFileType," & _
                       "@I_OwnerPicStatus," & _
                       "@I_OwnerPicRemarks," & _
                       "@I_BusEstPicFileData," & _
                       "@I_BusEstPicFileName," & _
                       "@I_BusEstPicFileType," & _
                       "@I_BusEstPicStatus," & _
                       "@I_BusEstPicRemarks," & _
                       "@I_BusMapPicFileData," & _
                       "@I_BusMapPicFileName," & _
                       "@I_BusMapPicFileType," & _
                       "@I_BusMapPicStatus," & _
                       "@I_BusMapPicRemarks," & _
                       "@I_AppFormFileData," & _
                       "@I_AppFormFileName," & _
                       "@I_AppFormFileType," & _
                       "@I_AppFormStatus," & _
                       "@I_AppFormRemarks," & _
                       "@I_DtiSecCdaFileData," & _
                       "@I_DtiSecCdaFileName," & _
                       "@I_DtiSecCdaFileType," & _
                       "@I_DtiSecCdaFileStatus," & _
                       "@I_DtiSecCdaFileRemarks," & _
                       "@I_TINFileData," & _
                       "@I_TINFileName," & _
                       "@I_TINFileType," & _
                       "@I_TINFileStatus," & _
                       "@I_TINFileRemarks," & _
                       "@Submitted," & _
                       "@Date_Created," & _
                       "@Date_LastEdit," & _
                       "@Date_Submitted," & _
                       "@Status," & _
                       "@Reg_BrgyClarance_Status," & _
                       "@Reg_BrgyClarance_Remarks" & _
                      ")"





            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@A_Ownership", A(0))
                .AddWithValue("@A_DtiSecCda", A(1))
                .AddWithValue("@A_BusName", A(2))
                .AddWithValue("@A_TIN", A(3))
                .AddWithValue("@B_HouseNo", B(0))
                .AddWithValue("@B_BldgName", B(1))
                .AddWithValue("@B_LotNo", B(2))
                .AddWithValue("@B_BlockNo", B(3))
                .AddWithValue("@B_Street", B(4))
                .AddWithValue("@B_Brgy", B(5))
                .AddWithValue("@B_Subd", B(6))
                .AddWithValue("@B_CityMunicipality", B(7))
                .AddWithValue("@B_Province", B(8))
                .AddWithValue("@B_ZipCode", B(9))
                .AddWithValue("@C_TelNo", C(0))
                .AddWithValue("@C_MobileNo", C(1))
                .AddWithValue("@C_Email", C(2))
                .AddWithValue("@D_Lname", D(0))
                .AddWithValue("@D_Fname", D(1))
                .AddWithValue("@D_Mname", D(2))
                .AddWithValue("@D_Suffix", D(3))
                .AddWithValue("@E_Lname", E(0))
                .AddWithValue("@E_Fname", E(1))
                .AddWithValue("@E_Mname", E(2))
                .AddWithValue("@E_Suffix", E(3))
                .AddWithValue("@E_Nationality", E(4))
                .AddWithValue("@F_BusArea", F(0))
                .AddWithValue("@F_FlrArea", F(1))
                .AddWithValue("@F_MaleEmpNo", F(2))
                .AddWithValue("@F_FemaleEmpNo", F(3))
                .AddWithValue("@F_ResideEmpNo", F(4))
                .AddWithValue("@F_VanTruckNo", F(5))
                .AddWithValue("@F_MotorNo", F(6))
                .AddWithValue("@G_HouseNo", G(0))
                .AddWithValue("@G_BldgName", G(1))
                .AddWithValue("@G_LotNo", G(2))
                .AddWithValue("@G_BlockNo", G(3))
                .AddWithValue("@G_Street", G(4))
                .AddWithValue("@G_Brgy", G(5))
                .AddWithValue("@G_Subd", G(6))
                .AddWithValue("@G_CityMunicipality", G(7))
                .AddWithValue("@G_Province", G(8))
                .AddWithValue("@G_ZipCode", G(9))
                .AddWithValue("@H_Capital", H(0))
                .AddWithValue("@H_Nature", H(1))
                .AddWithValue("@H_Owned", H(2))
                .AddWithValue("@H_TDN", H(3))
                .AddWithValue("@H_PIN", H(4))
                .AddWithValue("@H_GovIncentive", H(6))
                .AddWithValue("@H_GovIncentiveFileData", 0)
                .AddWithValue("@H_GovIncentiveFileName", "")
                .AddWithValue("@H_GovIncentiveFileType", "")
                .AddWithValue("@H_BusAct", IIf(H(7) = "Others", H(8), H(7)))
                .AddWithValue("@I_OwnerPicFileData", 0)
                .AddWithValue("@I_OwnerPicFileName", "")
                .AddWithValue("@I_OwnerPicFileType", "")
                .AddWithValue("@I_OwnerPicStatus", "")
                .AddWithValue("@I_OwnerPicRemarks", "")
                .AddWithValue("@I_BusEstPicFileData", 0)
                .AddWithValue("@I_BusEstPicFileName", "")
                .AddWithValue("@I_BusEstPicFileType", "")
                .AddWithValue("@I_BusEstPicStatus", "")
                .AddWithValue("@I_BusEstPicRemarks", "")
                .AddWithValue("@I_BusMapPicFileData", 0)
                .AddWithValue("@I_BusMapPicFileName", "")
                .AddWithValue("@I_BusMapPicFileType", "")
                .AddWithValue("@I_BusMapPicStatus", "")
                .AddWithValue("@I_BusMapPicRemarks", "")
                .AddWithValue("@I_AppFormFileData", 0)
                .AddWithValue("@I_AppFormFileName", "")
                .AddWithValue("@I_AppFormFileType", "")
                .AddWithValue("@I_AppFormStatus", "")
                .AddWithValue("@I_AppFormRemarks", "")
                .AddWithValue("@I_DtiSecCdaFileData", 0)
                .AddWithValue("@I_DtiSecCdaFileName", "")
                .AddWithValue("@I_DtiSecCdaFileType", "")
                .AddWithValue("@I_DtiSecCdaFileStatus", "")
                .AddWithValue("@I_DtiSecCdaFileRemarks", "")
                .AddWithValue("@I_TINFileData", 0)
                .AddWithValue("@I_TINFileName", "")
                .AddWithValue("@I_TINFileType", "")
                .AddWithValue("@I_TINFileStatus", "")
                .AddWithValue("@I_TINFileRemarks", "")
                .AddWithValue("@Submitted", 0)
                .AddWithValue("@Date_Created", getdate)
                .AddWithValue("@Date_LastEdit", "")
                .AddWithValue("@Date_Submitted", "")
                .AddWithValue("@Status", "Incomplete")
                .AddWithValue("@Reg_BrgyClarance_Status", "")
                .AddWithValue("@Reg_BrgyClarance_Remarks", "")
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateSubmit(ByVal Application_ID As String, ByVal UserID As String)

        Dim Submitted As Integer = 1
        Dim getdate As Date
        _pSubGetDate(getdate)


        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                  "Submitted = @Submitted ," & _
                 "Date_LastEdit = @Date_LastEdit ," & _
                "Date_Submitted = @Date_Submitted," & _
                "Status = @Status" & _
                " where UserID=@UserID and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@Submitted", Submitted)
                .AddWithValue("@Date_LastEdit", getdate)
                .AddWithValue("@Date_Submitted", getdate)
                .AddWithValue("@Status", "Submitted/Pending")
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCancelNBP(ByVal AppID As String, ByRef Err As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update NewBP_Draft set UserID='CANCELED - ' + UserID,Status='CANCELED'  where Application_ID='" & AppID & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            Dim _nQuery2 As String = Nothing
            _nQuery2 = "delete from NewBP_RegulatorySubmitted where Application_ID='" & AppID & "'"
            Dim _nSqlCommand2 As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand2.ExecuteNonQuery()

            Err = Nothing

        Catch ex As Exception
            Err = ex.Message
        End Try
    End Sub

    Public Sub _pSubUpdateNewBPPaid(ByVal ACCTNO)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSMAST SET " & _
                  "isForPayment = 0," & _
                 "isPosted = 1" & _
                " where ACCTNO='" & ACCTNO & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateStatusIssued(ByVal ACCTNO)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSDETAIL SET STATUS = 'Issued/Sent'  where ACCTNO='" & ACCTNO & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateTOPONLINE(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " update [BUSLINE] set " & _
                "[APPRV_TOP_ONLINE] = CASE WHEN [APPRV_TOP_ONLINE] = '1' THEN '2' ELSE null END  where acctno='" & ACCTNO & "' and foryear =" & _
                      " (SELECT top 1  [FORYEAR] FROM [BUSLINE]  where acctno='" & ACCTNO & "' order by FORYEAR desc)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateISASSESS(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update BUSDETAIL_TAXPAYER set ISASSESS=0 where acctno='" & ACCTNO & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateDraft(ByVal Application_ID As String, ByVal UserID As String,
                                ByVal A() As String, ByVal B() As String, ByVal C() As String,
                                ByVal D() As String, ByVal E() As String, ByVal F() As String,
                                ByVal G() As String, ByVal H() As String, _
                                ByVal H_D1 As Byte(), ByVal H_N1 As String, ByVal H_T1 As String, _
                                ByVal I_D1 As Byte(), ByVal I_N1 As String, ByVal I_T1 As String, _
                                ByVal I_D2 As Byte(), ByVal I_N2 As String, ByVal I_T2 As String, _
                                ByVal I_D3 As Byte(), ByVal I_N3 As String, ByVal I_T3 As String, _
                                ByVal I_D4 As Byte(), ByVal I_N4 As String, ByVal I_T4 As String, _
                                ByVal I_D5 As Byte(), ByVal I_N5 As String, ByVal I_T5 As String, _
                                ByVal I_D6 As Byte(), ByVal I_N6 As String, ByVal I_T6 As String)
        Try
            Dim getdate As Date
            _pSubGetDate(getdate)

            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                "A_Ownership = @A_Ownership," & _
                "A_DtiSecCda = @A_DtiSecCda," & _
                "A_BusName = @A_BusName," & _
                "A_TIN = @A_TIN," & _
                "B_HouseNo = @B_HouseNo," & _
                "B_BldgName = @B_BldgName," & _
                "B_LotNo = @B_LotNo," & _
                "B_BlockNo = @B_BlockNo," & _
                "B_Street = @B_Street," & _
                "B_Brgy = @B_Brgy," & _
                "B_Subd = @B_Subd," & _
                "B_CityMunicipality = @B_CityMunicipality," & _
                "B_Province = @B_Province," & _
                "B_ZipCode = @B_ZipCode," & _
                "C_TelNo = @C_TelNo," & _
                "C_MobileNo = @C_MobileNo," & _
                "C_Email = @C_Email," & _
                "D_Lname = @D_Lname," & _
                "D_Fname = @D_Fname," & _
                "D_Mname = @D_Mname," & _
                "D_Suffix = @D_Suffix," & _
                "E_Lname = @E_Lname," & _
                "E_Fname = @E_Fname," & _
                "E_Mname = @E_Mname," & _
                "E_Suffix = @E_Suffix," & _
                "E_Nationality = @E_Nationality," & _
                "F_BusArea = @F_BusArea," & _
                "F_FlrArea = @F_FlrArea," & _
                "F_MaleEmpNo = @F_MaleEmpNo," & _
                "F_FemaleEmpNo = @F_FemaleEmpNo," & _
                "F_ResideEmpNo = @F_ResideEmpNo," & _
                "F_VanTruckNo = @F_VanTruckNo," & _
                "F_MotorNo = @F_MotorNo," & _
                "G_HouseNo = @G_HouseNo," & _
                "G_BldgName = @G_BldgName," & _
                "G_LotNo = @G_LotNo," & _
                "G_BlockNo = @G_BlockNo," & _
                "G_Street = @G_Street," & _
                "G_Brgy = @G_Brgy," & _
                "G_Subd = @G_Subd," & _
                "G_CityMunicipality = @G_CityMunicipality," & _
                "G_Province = @G_Province," & _
                "G_ZipCode = @G_ZipCode," & _
                "H_Capital = @H_Capital," & _
                "H_Nature = @H_Nature," & _
                "H_Owned = @H_Owned," & _
                "H_TDN = @H_TDN," & _
                "H_PIN = @H_PIN," & _
                "H_GovIncentive = @H_GovIncentive," & _
                "H_BusAct = @H_BusAct," & _
                "Date_LastEdit = @Date_LastEdit" & _
                " where UserID=@UserID and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@A_Ownership", A(0))
                .AddWithValue("@A_DtiSecCda", A(1))
                .AddWithValue("@A_BusName", A(2))
                .AddWithValue("@A_TIN", A(3))
                .AddWithValue("@B_HouseNo", B(0))
                .AddWithValue("@B_BldgName", B(1))
                .AddWithValue("@B_LotNo", B(2))
                .AddWithValue("@B_BlockNo", B(3))
                .AddWithValue("@B_Street", B(4))
                .AddWithValue("@B_Brgy", B(5))
                .AddWithValue("@B_Subd", B(6))
                .AddWithValue("@B_CityMunicipality", B(7))
                .AddWithValue("@B_Province", B(8))
                .AddWithValue("@B_ZipCode", B(9))
                .AddWithValue("@C_TelNo", C(0))
                .AddWithValue("@C_MobileNo", C(1))
                .AddWithValue("@C_Email", C(2))
                .AddWithValue("@D_Lname", D(0))
                .AddWithValue("@D_Fname", D(1))
                .AddWithValue("@D_Mname", D(2))
                .AddWithValue("@D_Suffix", D(3))
                .AddWithValue("@E_Lname", E(0))
                .AddWithValue("@E_Fname", E(1))
                .AddWithValue("@E_Mname", E(2))
                .AddWithValue("@E_Suffix", E(3))
                .AddWithValue("@E_Nationality", E(4))
                .AddWithValue("@F_BusArea", F(0))
                .AddWithValue("@F_FlrArea", F(1))
                .AddWithValue("@F_MaleEmpNo", F(2))
                .AddWithValue("@F_FemaleEmpNo", F(3))
                .AddWithValue("@F_ResideEmpNo", F(4))
                .AddWithValue("@F_VanTruckNo", F(5))
                .AddWithValue("@F_MotorNo", F(6))
                .AddWithValue("@G_HouseNo", G(0))
                .AddWithValue("@G_BldgName", G(1))
                .AddWithValue("@G_LotNo", G(2))
                .AddWithValue("@G_BlockNo", G(3))
                .AddWithValue("@G_Street", G(4))
                .AddWithValue("@G_Brgy", G(5))
                .AddWithValue("@G_Subd", G(6))
                .AddWithValue("@G_CityMunicipality", G(7))
                .AddWithValue("@G_Province", G(8))
                .AddWithValue("@G_ZipCode", G(9))
                .AddWithValue("@H_Capital", H(0))
                .AddWithValue("@H_Nature", H(1))
                .AddWithValue("@H_Owned", H(2))
                .AddWithValue("@H_TDN", H(3))
                .AddWithValue("@H_PIN", H(4))
                .AddWithValue("@H_GovIncentive", H(6))
                .AddWithValue("@H_BusAct", IIf(H(7) = "Others", H(8), H(7)))
                .AddWithValue("@Date_LastEdit", getdate)

            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAttachment(ByVal DB_FieldData As String, _
                                       ByVal DB_FieldName As String, _
                                       ByVal DB_FieldType As String, _
                                       ByVal UserID As String, _
                                       ByVal Application_ID As String, _
                                       ByVal FileData As Byte(), _
                                       ByVal FileName As String, _
                                       ByVal FileType As String _
                                       )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                 DB_FieldData & " = @" & DB_FieldData & " ," & _
                 DB_FieldName & " = @" & DB_FieldName & " ," & _
                 DB_FieldType & " = @" & DB_FieldType & _
                " where UserID=@UserID and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@UserID", UserID)
                .AddWithValue("@" & DB_FieldData, FileData)
                .AddWithValue("@" & DB_FieldName, FileName)
                .AddWithValue("@" & DB_FieldType, FileType)
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertRegAttachment(ByVal Application_ID As String, _
                                     ByVal SWITCH As String, _
                                     ByVal ReqCode As String, _
                                     ByVal ReqDesc As String, _
                                     ByVal File_Name As String, _
                                     ByVal File_Type As String, _
                                     ByVal File_Data64 As String, _
                                     ByVal Status As String
                                     )
        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO NewBP_RegulatorySubmitted" & _
                "(UserID,Application_ID,SWITCH,ReqCode,ReqDesc,File_Name,File_Type,File_Data64,Status,Date_Submitted) " & _
                "VALUES" & _
                "(@UserID,@Application_ID,@SWITCH,@ReqCode,@ReqDesc,@File_Name,@File_Type,@File_Data64,@Status,  (select getdate()))"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@UserID", cSessionUser._pUserID)
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@SWITCH", SWITCH)
                .AddWithValue("@ReqCode", ReqCode)
                .AddWithValue("@ReqDesc", ReqDesc)
                .AddWithValue("@File_Name", File_Name)
                .AddWithValue("@File_Type", File_Type)
                .AddWithValue("@File_Data64", File_Data64)
                .AddWithValue("@Status", Status)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertRegInfo(ByVal Application_ID As String, _
                                   ByVal SWITCH As String, _
                                   ByVal Info1 As String, _
                                   ByVal Info2 As String, _
                                   ByVal Info3 As String, _
                                   ByVal Info4 As String, _
                                   ByVal Info5 As String, _
                                   ByVal Status As String
                                   )
        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO NewBP_RegulatorySubmitted2" & _
                "(UserID,Application_ID,SWITCH,Info1,Info2,Info3,Info4,Info5,Status,Date_Submitted) " & _
                "VALUES" & _
                "(@UserID,@Application_ID,@SWITCH,@Info1,@Info2,@Info3,@Info4,@Info5,@Status,  (select getdate()))"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@UserID", cSessionUser._pUserID)
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@SWITCH", SWITCH)
                .AddWithValue("@Info1", Info1)
                .AddWithValue("@Info2", Info2)
                .AddWithValue("@Info3", Info3)
                .AddWithValue("@Info4", Info4)
                .AddWithValue("@Info5", Info5)
                .AddWithValue("@Status", Status)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAttachmentStatus(ByVal Application_ID As String, _
                                  ByVal SWITCH As String, _
                                  ByVal ReqCode As String, _
                                  ByVal Status As String, _
                                  ByVal Remarks As String
                                  )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_RegulatorySubmitted SET " & _
                 "Remarks= @Remarks," & _
                 "Status= @Status," & _
                 "Date_Assessed= (select GETDATE())," & _
                 "Assessed_BY= @Assessed_BY" & _
                " where SWITCH=@SWITCH and Application_ID=@Application_ID and ReqCode=@ReqCode"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@SWITCH", SWITCH)
                .AddWithValue("@Remarks", Remarks)
                .AddWithValue("@Status", Status)
                .AddWithValue("@Assessed_BY", cSessionUser._pUserID)
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@ReqCode", ReqCode)
            End With


            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubTempApproveAllRegAttachments(ByVal Application_ID As String, _
                                ByVal Status As String, _
                                ByVal Remarks As String
                                )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_RegulatorySubmitted SET " & _
                 "Remarks= @Remarks," & _
                 "Status= @Status," & _
                 "Date_Assessed= (select GETDATE())," & _
                 "Assessed_BY= @Assessed_BY" & _
                " where Application_ID=@Application_ID and Status <> 'APPROVED'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Remarks", Remarks)
                .AddWithValue("@Status", Status)
                .AddWithValue("@Assessed_BY", cSessionUser._pUserID)
                .AddWithValue("@Application_ID", Application_ID)
            End With


            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_Fees(ByVal Application_ID As String, _
                                 ByVal SWITCH As String, _
                                 ByVal DNAME As String, _
                                 ByRef Exist As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_RegulatoryFees] where DNAME='" & DNAME & "' and Application_ID = '" & Application_ID & "' and SWITCH='" & SWITCH & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Exist = True
                            Loop
                        Else
                            Exist = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGenerate_ClearanceNo(ByVal SWITCH As String, ByRef Clearance_No As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select  '" & SWITCH & "-'+(SELECT CONVERT(VARCHAR(6),GETDATE(),12)) +'-'+ FORMAT((select count(*) from [NewBP_RegulatorySubmitted2] where switch='" & SWITCH & "'), '0000') as Clearance_No"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iClearance_No As Integer = .GetOrdinal("Clearance_No")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Clearance_No = _nSqlDataReader(_iClearance_No).ToString
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Function _pSubNewBPv2() As Boolean
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from ModuleSetup where SubModule='BP_ApplicationV2' and status=1"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        Return True
                    Else
                        Return False
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Sub _pSubCheckIfAllRegReqIsApproved(ByVal AppID As String, ByRef Complete As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                      "select 	BPLTIMS.Application_ID,REQ_SETUP.REQCODE,REQ_SETUP.reqDesc, 	BPLTIMS.Status,BPLTIMS.assessed_by from OFCCODE   " & _
                      "inner join   " & _
                      "[" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].[NewBP_RegulatorySubmitted2] BPLTIMS   on OFCCODE.OFABBRV = BPLTIMS.switch   " & _
                      "inner join   " & _
                      "REQ_SETUP   on OFCCODE.OFABBRV = REQ_SETUP.REQCODE   " & _
                      "where " & _
                      "REQ_SETUP.REQCODE in (select SWITCH from REQ1) and BPLTIMS.application_id='" & AppID & "' " & _
                      "and " & _
                      "(select count(*) from [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].[NewBP_RegulatorySubmitted2] where status like '%APPROVED%' and application_id='" & AppID & "') =  " & _
                      "(select count(*) from OFCCODE inner join REQ_SETUP on OFCCODE.OFABBRV = REQ_SETUP.REQCODE where REQ_SETUP.REQCODE in (select SWITCH from REQ1))"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            Complete = True
                        Loop
                    Else
                        Complete = False
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetContent(ByVal AppID As String, ByRef Content As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
                      "select 	BPLTIMS.Application_ID,REQ_SETUP.REQCODE,REQ_SETUP.reqDesc,BPLTIMS.Status,BPLTIMS.Remarks,BPLTIMS.assessed_by from OFCCODE   " & _
                      "inner join   " & _
                      "[" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].[NewBP_RegulatorySubmitted2] BPLTIMS   on OFCCODE.OFABBRV = BPLTIMS.switch   " & _
                      "inner join   " & _
                      "REQ_SETUP   on OFCCODE.OFABBRV = REQ_SETUP.REQCODE   " & _
                      "where " & _
                      "REQ_SETUP.REQCODE in (select SWITCH from REQ1) and BPLTIMS.application_id='" & AppID & "'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    Dim _iRemarks As Integer = .GetOrdinal("Remarks")
                    Dim _iReqDesc As Integer = .GetOrdinal("ReqDesc")
                    Dim Status As String
                    Dim Remarks As String
                    Dim ReqDesc As String


                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Status = _nSqlDataReader(_iStatus).ToString
                                Remarks = _nSqlDataReader(_iRemarks).ToString
                                ReqDesc = _nSqlDataReader(_iReqDesc).ToString
                                Content &= "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>" & ReqDesc & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & Status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & Remarks & "</td></tr>"
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdate_Fees(ByVal Application_ID As String, _
                                ByVal SWITCH As String, _
                                ByVal FNAME As String, _
                                ByVal FDESC As String, _
                                ByVal DNAME As String, _
                                ByVal TAXCODE As String, _
                                ByVal FeeAMT As String
                                )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_RegulatoryFees SET " & _
                 "FeeAMT= @FeeAMT" & _
                " where SWITCH=@SWITCH and Application_ID=@Application_ID and DNAME=@DNAME and TAXCODE=@TAXCODE and FDESC=@FDESC"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@SWITCH", SWITCH)
                .AddWithValue("@FeeAMT", FeeAMT)
                .AddWithValue("@DNAME", DNAME)
                .AddWithValue("@FDESC", FDESC)
                .AddWithValue("@TAXCODE", TAXCODE)
                .AddWithValue("@Application_ID", Application_ID)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdate_FeesBPLTAS(ByVal ACCTNO As String, ByVal FNAME As String, ByVal FeeAMT As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSEXTN SET " & _
                 FNAME & " = @FeeAMT" & _
                " where ACCTNO = @ACCTNO"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@ACCTNO", ACCTNO)
                .AddWithValue("@FeeAMT", FeeAMT)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdate_BusmastforTOP(ByVal ACCTNO As String, ByVal Remarks As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSMAST SET " & _
                "REMARKS = @Remarks" & _
                " where ACCTNO = @ACCTNO"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@ACCTNO", ACCTNO)
                .AddWithValue("@Remarks", Remarks)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pUpdateNewBPDraft_ACCTNO(ByVal Application_ID As String, ByVal ACCTNO As String, ByVal RequirementAssessment As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Draft SET " & _
                " ACCTNO = @ACCTNO," & _
                " RequirementAssessment = @RequirementAssessment" & _
                " where Application_ID = @Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@ACCTNO", ACCTNO)
                .AddWithValue("@RequirementAssessment", RequirementAssessment)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsert_Fees(ByVal Application_ID As String, _
                                ByVal SWITCH As String, _
                                ByVal FNAME As String, _
                                ByVal FDESC As String, _
                                ByVal DNAME As String, _
                                ByVal TAXCODE As String, _
                                ByVal FeeAMT As String
                                )
        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO NewBP_RegulatoryFees" & _
                "(UserID,Application_ID,SWITCH,FNAME,FDESC,DNAME,TAXCODE,FeeAMT) " & _
                "VALUES" & _
                "(@UserID,@Application_ID,@SWITCH,@FNAME,@FDESC,@DNAME,@TAXCODE,@FeeAMT)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@UserID", cSessionUser._pUserID)
                .AddWithValue("@Application_ID", Application_ID)
                .AddWithValue("@SWITCH", SWITCH)
                .AddWithValue("@FNAME", FNAME)
                .AddWithValue("@FDESC", FDESC)
                .AddWithValue("@DNAME", DNAME)
                .AddWithValue("@TAXCODE", TAXCODE)
                .AddWithValue("@FeeAMT", FeeAMT)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubUpdate_CompleteRegulatory(ByVal Application_ID As String, _
                              ByVal Status As String
                              )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update [NewBP_Draft] SET " & _
                 "Status= @Status " & _
                 "where Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Status", Status)
                .AddWithValue("@Application_ID", Application_ID)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateBUSMAST_CompleteRegulatory(ByVal Application_ID As String, _
                            ByVal Status As String
                            )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update [NewBP_Draft] SET " & _
                 "Status= @Status " & _
                 "where Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Status", Status)
                .AddWithValue("@Application_ID", Application_ID)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateIsForPayment(ByVal ACCTNO As String, ByRef _err As String)
        Dim _nQuery As String = Nothing
        Try

            _nQuery = "Update [BUSMAST] SET " & _
                 " IsForPayment=1" & _
                 " where ACCTNO=@ACCTNO"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@ACCTNO", ACCTNO)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
            _err = "OK"
        Catch ex As Exception
            _err = ex.Message & ":" & _nQuery

        End Try
    End Sub

    Public Sub _pSubUpdateNewBPDraftStatus(ByVal AppID As String, ByVal Status As String, ByRef _err As String)
        Dim _nQuery As String = Nothing
        Try

            _nQuery = "Update [NewBP_Draft] SET " & _
                 " Status=@Status" & _
                 " where Application_ID=@AppID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@AppID", AppID)
                .AddWithValue("@Status", Status)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            _err = "OK"
            '----------------------------------
        Catch ex As Exception
            _err = ex.Message & ":" & _nQuery
        End Try
    End Sub

    Public Sub _pSubInsertToBUSDETAIL(ByVal Email As String, ByVal Acctno As String, ByVal Status As String, ByRef _err As String)
        Dim _nQuery As String = Nothing
        Try
            _nQuery =
                " INSERT INTO BUSDETAIL(EMAIL,ACCTNO,OWNER,BUSNAME,BUSADDRESS,CATEGORY,CATEGORY1,VERIFIED, ORNO, REQDATE,EMAIL2,Status,VerifiedBy,VerifiedDate,MOP)" &
                " SELECT  @Email,ACCTNO,BUSOWNER,BUSNAME,BUSADDRESS,CATEGORY,CATEGORY1, 1 AS VERIFIED, null AS ORNO, GETDATE() AS REQDATE,@Email2,@Status,@VerifiedBy,GETDATE(), " &
                " (select top 1 " &
                " CASE" &
                " WHEN modep='A' THEN 'Annually'" &
                " WHEN modep='Q' THEN 'Quarterly'" &
                " WHEN modep='S' THEN 'Semi-Annual'" &
                " END modep" &
                " from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[billingtemp] " &
                " where acctno=@Acctno order by modep desc)" &
                " FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.VW_BUSDETAIL " &
                " WHERE ACCTNO = @Acctno"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Email", Email.Replace(".", ""))
                .AddWithValue("@Email2", Email)
                .AddWithValue("@Acctno", Acctno)
                .AddWithValue("@Status", Status)
                .AddWithValue("@VerifiedBy", cSessionUser._pUserID)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()

            _err = "OK"
            '----------------------------------
        Catch ex As Exception
            _err = ex.Message & ":" & _nQuery
        End Try
    End Sub

    Public Sub _pSubUpdate_Status(ByVal Application_ID As String, _
                                 ByVal SWITCH As String, _
                                 ByVal Status As String, _
                                 ByVal Clearance_No As String, _
                                 ByVal Remarks As String
                                 )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_RegulatorySubmitted2 SET " & _
                 "Remarks= @Remarks," & _
                 "Status= @Status," & _
                 "Date_Assessed= (select GETDATE())," & _
                 "Assessed_BY= @Assessed_BY ," & _
                 "Clearance_No= @Clearance_no" & _
                " where SWITCH=@SWITCH and Application_ID=@Application_ID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@SWITCH", SWITCH)
                .AddWithValue("@Remarks", Remarks)
                .AddWithValue("@Status", Status)
                .AddWithValue("@Clearance_No", Clearance_No)
                .AddWithValue("@Assessed_BY", cSessionUser._pUserID)
                .AddWithValue("@Application_ID", Application_ID)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pInsertBrgy(ByVal AppID As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "insert into [NewBP_Regulatory]([UserID],[Application_ID],[Clearance],[Status]) values" & _
                "('" & cSessionUser._pUserID & "','" & AppID & "','Barangay Clearance','For Verification')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckIfValid(ByRef Exists As Boolean, ByVal ApplicationNo As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from NewBP_Draft where UserID = '" & cSessionUser._pUserID & "' and Application_ID='" & ApplicationNo & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Exists = True
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pCheckifBrgyExists(ByRef Exists As Boolean, ByVal ApplicationNo As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from [NewBP_Regulatory] where UserID = '" & cSessionUser._pUserID & "' and Application_ID='" & ApplicationNo & "' and Clearance='Barangay Clearance'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Exists = True
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub
    '---------------------------------------------
    Public Sub _pSubCheckIfExist2(ByRef DraftExists As Boolean, ByRef ApplicationNo As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from NewBP_Taxpayer_Draft where Email = '" & cSessionUser._pUserID & "' and Status = 'Incomplete'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplicationNo As Integer = .GetOrdinal("ApplicationNo")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                DraftExists = True
                                ApplicationNo = _nSqlDataReader(_iApplicationNo).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubApplicationNo(ByRef ApplicationNo As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select 'NBP' + replace(CONVERT(date, getdate()),'-','') +'-'+  REPLACE(STR(CAST((select count(*)+1 from NewBP_Taxpayer_Draft) AS nvarchar),5),' ','0') as 'ApplicationNo'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplicationNo As Integer = .GetOrdinal("ApplicationNo")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                ApplicationNo = _nSqlDataReader(_iApplicationNo).ToString
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertDraft2(ApplicationNo, Bus_Name, Capital, Area, Bus_Address, _
                                 Bus_Brgy, Bus_Street, Bus_Nature, DtiSecCda_No, TIN_No, _
                                 SSS_No, Contact_No, Email, FName, LName, MName, Resident, _
                                 Own_Address, Own_Brgy, Own_Street, Own_CityMun, Status)

        Dim getdate As Date
        _pSubGetDate(getdate)

        Try

            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO NewBP_Taxpayer_Draft" & _
                "(ApplicationNo," & _
            "Bus_Name, " & _
            "Capital, " & _
            "Area, " & _
            "Bus_Address, " & _
            "Bus_Brgy, " & _
            "Bus_Street, " & _
            "Bus_Nature, " & _
            "DtiSecCda_No, " & _
            "TIN_No, " & _
            "SSS_No, " & _
            "Contact_No, " & _
            "Email, " & _
            "FName, " & _
            "LName, " & _
            "MName, " & _
            "Resident, " & _
            "Own_Address, " & _
            "Own_Brgy, " & _
            "Own_Street, " & _
            "Own_CityMun, " & _
            "Date_Created, " & _
            "Last_Edit, " & _
            "Date_Submitted, " & _
            "Status) " & _
                "VALUES(" & _
                       "@ApplicationNo," & _
                       "@Bus_Name," & _
                       "@Capital," & _
                       "@Area," & _
                       "@Bus_Address," & _
                       "@Bus_Brgy," & _
                       "@Bus_Street," & _
                       "@Bus_Nature," & _
                       "@DtiSecCda_No," & _
                       "@TIN_No," & _
                       "@SSS_No," & _
                       "@Contact_No," & _
                       "@Email," & _
                       "@FName," & _
                       "@LName," & _
                       "@MName," & _
                       "@Resident," & _
                       "@Own_Address," & _
                       "@Own_Brgy," & _
                       "@Own_Street," & _
                       "@Own_CityMun," & _
                       "@Date_Created," & _
                       "@Last_Edit," & _
                       "@Date_Submitted," & _
                       "@Status" & _
                      ")"


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@ApplicationNo", ApplicationNo)
                .AddWithValue("@Bus_Name", Bus_Name)
                .AddWithValue("@Capital", Capital)
                .AddWithValue("@Area", Area)
                .AddWithValue("@Bus_Address", Bus_Address)
                .AddWithValue("@Bus_Brgy", Bus_Brgy)
                .AddWithValue("@Bus_Street", Bus_Street)
                .AddWithValue("@Bus_Nature", Bus_Nature)
                .AddWithValue("@DtiSecCda_No", DtiSecCda_No)
                .AddWithValue("@TIN_No", TIN_No)
                .AddWithValue("@SSS_No", SSS_No)
                .AddWithValue("@Contact_No", Contact_No)
                .AddWithValue("@Email", Email)
                .AddWithValue("@FName", FName)
                .AddWithValue("@LName", LName)
                .AddWithValue("@MName", MName)
                .AddWithValue("@Resident", Resident)
                .AddWithValue("@Own_Address", Own_Address)
                .AddWithValue("@Own_Brgy", Own_Brgy)
                .AddWithValue("@Own_Street", Own_Street)
                .AddWithValue("@Own_CityMun", Own_CityMun)
                .AddWithValue("@Date_Created", getdate)
                .AddWithValue("@Last_Edit", getdate)
                .AddWithValue("@Date_Submitted", vbNull)
                .AddWithValue("@Status", Status)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateDraft2(ApplicationNo, Bus_Name, Capital, Area, Bus_Address, _
                                 Bus_Brgy, Bus_Street, Bus_Nature, DtiSecCda_No, TIN_No, _
                                 SSS_No, Contact_No, Email, FName, LName, MName, Resident, _
                                 Own_Address, Own_Brgy, Own_Street, Own_CityMun, Status)
        Try
            Dim getdate As Date
            _pSubGetDate(getdate)

            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Taxpayer_Draft SET " & _
                "Bus_Name = @Bus_Name," & _
                "Capital = @Capital," & _
                "Area = @Area," & _
                "Bus_Address = @Bus_Address," & _
                "Bus_Brgy = @Bus_Brgy," & _
                "Bus_Street = @Bus_Street," & _
                "Bus_Nature = @Bus_Nature," & _
                "DtiSecCda_No = @DtiSecCda_No," & _
                "TIN_No = @TIN_No," & _
                "SSS_No = @SSS_No," & _
                "Contact_No = @Contact_No," & _
                "FName = @FName," & _
                "LName = @LName," & _
                "MName = @MName," & _
                "Resident = @Resident," & _
                "Own_Address = @Own_Address," & _
                "Own_Brgy = @Own_Brgy," & _
                "Own_Street = @Own_Street," & _
                "Own_CityMun = @Own_CityMun," & _
                "Last_Edit = @Last_Edit" & _
                " where Email=@Email and ApplicationNo=@ApplicationNo"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@ApplicationNo", ApplicationNo)
                .AddWithValue("@Bus_Name", Bus_Name)
                .AddWithValue("@Capital", Capital)
                .AddWithValue("@Area", Area)
                .AddWithValue("@Bus_Address", Bus_Address)
                .AddWithValue("@Bus_Brgy", Bus_Brgy)
                .AddWithValue("@Bus_Street", Bus_Street)
                .AddWithValue("@Bus_Nature", Bus_Nature)
                .AddWithValue("@DtiSecCda_No", DtiSecCda_No)
                .AddWithValue("@TIN_No", TIN_No)
                .AddWithValue("@SSS_No", SSS_No)
                .AddWithValue("@Contact_No", Contact_No)
                .AddWithValue("@Email", Email)
                .AddWithValue("@FName", FName)
                .AddWithValue("@LName", LName)
                .AddWithValue("@MName", MName)
                .AddWithValue("@Resident", Resident)
                .AddWithValue("@Own_Address", Own_Address)
                .AddWithValue("@Own_Brgy", Own_Brgy)
                .AddWithValue("@Own_Street", Own_Street)
                .AddWithValue("@Own_CityMun", Own_CityMun)
                .AddWithValue("@Last_Edit", getdate)
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAttachment2(ByVal ctr As Integer, _
                                     ByVal Email As String, _
                                     ByVal ApplicationNo As String, _
                                     ByVal FileData As Byte(), _
                                     ByVal FileName As String, _
                                     ByVal FileType As String _
                                     )
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Taxpayer_Draft SET " & _
                 "up_FileData" & ctr & "= @FileData," & _
                 "up_FileName" & ctr & "= @FileName," & _
                 "up_FileType" & ctr & "= @FileType" & _
                " where Email=@Email and ApplicationNo=@ApplicationNo"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@ApplicationNo", ApplicationNo)
                .AddWithValue("@Email", Email)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateSubmit2(ByVal ApplicationNo As String, ByVal Email As String, ByVal Status As String)
        Dim getdate As Date
        _pSubGetDate(getdate)


        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update NewBP_Taxpayer_Draft SET " & _
                  "Status = @Status ," & _
                 "Last_Edit = @Last_Edit ," & _
                "Date_Submitted = @Date_Submitted," & _
                " where Email=@Email and ApplicationNo=@ApplicationNo"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@ApplicationNo", ApplicationNo)
                .AddWithValue("@Email", Email)
                .AddWithValue("@Status", Status)
                .AddWithValue("@Last_Edit", getdate)
                .AddWithValue("@Date_Submitted", getdate)
                .AddWithValue("@Status", Status)
            End With

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectNewBP3()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
            "SELECT * FROM NEWBP_Taxpayer"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        Catch ex As Exception

        End Try



    End Sub

    Public Sub _pSubSelectARX(ByVal ACCTNO As String, ByRef ARXFile As Byte())
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Select top 1  xDate, xTime,ForYear,AcctNo,ARXFile,xFileNo,xFilename from (  Select xFilename ,ForYear,AcctNo,ARXFile,xFileNo  ,convert(datetime, SubString(substring(Right(xFileName,19),1,6), 1, 2) + '/' +  SubString(substring(Right(xFileName,19),1,6), 3, 2) + '/' +  left(year(Getdate()),2) +  SubString(substring(Right(xFileName,19),1,6), 5, 2)) as xDate, left(Right(xFileName,12),8) as xTime  From TOPFile ) as tblARXFile  where AcctNo = '" & ACCTNO & "' order by xDate desc,xTime desc,Acctno,xFileName"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iARXFile As Integer = .GetOrdinal("ARXFile")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                ARXFile = _nSqlDataReader(_iARXFile)
                            Loop
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectNewBP2( _
        ByRef ApplicationNo As String _
      , ByRef Bus_Name As String _
      , ByRef Capital As String _
      , ByRef Area As String _
      , ByRef Bus_Address As String _
      , ByRef Bus_Brgy As String _
      , ByRef Bus_Street As String _
      , ByRef Bus_Nature As String _
      , ByRef DtiSecCda_No As String _
      , ByRef TIN_No As String _
      , ByRef SSS_No As String _
      , ByRef Contact_No As String _
      , ByRef Email As String _
      , ByRef FName As String _
      , ByRef LName As String _
      , ByRef MName As String _
      , ByRef Resident As Boolean _
      , ByRef Own_Address As String _
      , ByRef Own_Brgy As String _
      , ByRef Own_Street As String _
      , ByRef Own_CityMun As String _
      , ByRef up_FileData1 As Byte() _
      , ByRef up_FileName1 As String _
      , ByRef up_FileType1 As String _
      , ByRef up_FileStatus1 As String _
      , ByRef up_FileRemarks1 As String _
      , ByRef up_FileData2 As Byte() _
      , ByRef up_FileName2 As String _
      , ByRef up_FileType2 As String _
      , ByRef up_FileStatus2 As String _
      , ByRef up_FileRemarks2 As String _
      , ByRef up_FileData3 As Byte() _
      , ByRef up_FileName3 As String _
      , ByRef up_FileType3 As String _
      , ByRef up_FileStatus3 As String _
      , ByRef up_FileRemarks3 As String _
      , ByRef up_FileData4 As Byte() _
      , ByRef up_FileName4 As String _
      , ByRef up_FileType4 As String _
      , ByRef up_FileStatus4 As String _
      , ByRef up_FileRemarks4 As String _
      , ByRef up_FileData5 As Byte() _
      , ByRef up_FileName5 As String _
      , ByRef up_FileType5 As String _
      , ByRef up_FileStatus5 As String _
      , ByRef up_FileRemarks5 As String _
      , ByRef up_FileData6 As Byte() _
      , ByRef up_FileName6 As String _
      , ByRef up_FileType6 As String _
      , ByRef up_FileStatus6 As String _
      , ByRef up_FileRemarks6 As String _
      , ByRef Date_Created As Date _
      , ByRef Last_Edit As Date _
      , ByRef Date_Submitted As Date _
      , ByRef Status As String
)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" & _
            "SELECT * FROM NEWBP_Taxpayer_DRAFT where Email='" & cSessionUser._pUserID & "' and status='Incomplete'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iApplicationNo As Integer = .GetOrdinal("ApplicationNo")
                    Dim _iBus_Name As Integer = .GetOrdinal("Bus_Name")
                    Dim _iCapital As Integer = .GetOrdinal("Capital")
                    Dim _iArea As Integer = .GetOrdinal("Area")
                    Dim _iBus_Address As Integer = .GetOrdinal("Bus_Address")
                    Dim _iBus_Brgy As Integer = .GetOrdinal("Bus_Brgy")
                    Dim _iBus_Street As Integer = .GetOrdinal("Bus_Street")
                    Dim _iBus_Nature As Integer = .GetOrdinal("Bus_Nature")
                    Dim _iDtiSecCda_No As Integer = .GetOrdinal("DtiSecCda_No")
                    Dim _iTIN_No As Integer = .GetOrdinal("TIN_No")
                    Dim _iSSS_No As Integer = .GetOrdinal("SSS_No")
                    Dim _iContact_No As Integer = .GetOrdinal("Contact_No")
                    Dim _iEmail As Integer = .GetOrdinal("Email")
                    Dim _iFName As Integer = .GetOrdinal("FName")
                    Dim _iLName As Integer = .GetOrdinal("LName")
                    Dim _iMName As Integer = .GetOrdinal("MName")
                    Dim _iResident As Integer = .GetOrdinal("Resident")
                    Dim _iOwn_Address As Integer = .GetOrdinal("Own_Address")
                    Dim _iOwn_Brgy As Integer = .GetOrdinal("Own_Brgy")
                    Dim _iOwn_Street As Integer = .GetOrdinal("Own_Street")
                    Dim _iOwn_CityMun As Integer = .GetOrdinal("Own_CityMun")
                    Dim _iup_FileData1 As Integer = .GetOrdinal("up_FileData1")
                    Dim _iup_FileName1 As Integer = .GetOrdinal("up_FileName1")
                    Dim _iup_FileType1 As Integer = .GetOrdinal("up_FileType1")
                    Dim _iup_FileStatus1 As Integer = .GetOrdinal("up_FileStatus1")
                    Dim _iup_FileRemarks1 As Integer = .GetOrdinal("up_FileRemarks1")
                    Dim _iup_FileData2 As Integer = .GetOrdinal("up_FileData2")
                    Dim _iup_FileName2 As Integer = .GetOrdinal("up_FileName2")
                    Dim _iup_FileType2 As Integer = .GetOrdinal("up_FileType2")
                    Dim _iup_FileStatus2 As Integer = .GetOrdinal("up_FileStatus2")
                    Dim _iup_FileRemarks2 As Integer = .GetOrdinal("up_FileRemarks2")
                    Dim _iup_FileData3 As Integer = .GetOrdinal("up_FileData3")
                    Dim _iup_FileName3 As Integer = .GetOrdinal("up_FileName3")
                    Dim _iup_FileType3 As Integer = .GetOrdinal("up_FileType3")
                    Dim _iup_FileStatus3 As Integer = .GetOrdinal("up_FileStatus3")
                    Dim _iup_FileRemarks3 As Integer = .GetOrdinal("up_FileRemarks3")
                    Dim _iup_FileData4 As Integer = .GetOrdinal("up_FileData4")
                    Dim _iup_FileName4 As Integer = .GetOrdinal("up_FileName4")
                    Dim _iup_FileType4 As Integer = .GetOrdinal("up_FileType4")
                    Dim _iup_FileStatus4 As Integer = .GetOrdinal("up_FileStatus4")
                    Dim _iup_FileRemarks4 As Integer = .GetOrdinal("up_FileRemarks4")
                    Dim _iup_FileData5 As Integer = .GetOrdinal("up_FileData5")
                    Dim _iup_FileName5 As Integer = .GetOrdinal("up_FileName5")
                    Dim _iup_FileType5 As Integer = .GetOrdinal("up_FileType5")
                    Dim _iup_FileStatus5 As Integer = .GetOrdinal("up_FileStatus5")
                    Dim _iup_FileRemarks5 As Integer = .GetOrdinal("up_FileRemarks5")
                    Dim _iup_FileData6 As Integer = .GetOrdinal("up_FileData6")
                    Dim _iup_FileName6 As Integer = .GetOrdinal("up_FileName6")
                    Dim _iup_FileType6 As Integer = .GetOrdinal("up_FileType6")
                    Dim _iup_FileStatus6 As Integer = .GetOrdinal("up_FileStatus6")
                    Dim _iup_FileRemarks6 As Integer = .GetOrdinal("up_FileRemarks6")
                    Dim _iDate_Created As Integer = .GetOrdinal("Date_Created")
                    Dim _iLast_Edit As Integer = .GetOrdinal("Last_Edit")
                    Dim _iDate_Submitted As Integer = .GetOrdinal("Date_Submitted")
                    Dim _iStatus As Integer = .GetOrdinal("Status")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                ApplicationNo = _nSqlDataReader(_iApplicationNo).ToString
                                Bus_Name = _nSqlDataReader(_iBus_Name).ToString
                                Capital = _nSqlDataReader(_iCapital).ToString
                                Area = _nSqlDataReader(_iArea).ToString
                                Bus_Address = _nSqlDataReader(_iBus_Address).ToString
                                Bus_Brgy = _nSqlDataReader(_iBus_Brgy).ToString
                                Bus_Street = _nSqlDataReader(_iBus_Street).ToString
                                Bus_Nature = _nSqlDataReader(_iBus_Nature).ToString
                                DtiSecCda_No = _nSqlDataReader(_iDtiSecCda_No).ToString
                                TIN_No = _nSqlDataReader(_iTIN_No).ToString
                                SSS_No = _nSqlDataReader(_iSSS_No).ToString
                                Contact_No = _nSqlDataReader(_iContact_No).ToString
                                Email = _nSqlDataReader(_iEmail).ToString
                                FName = _nSqlDataReader(_iFName).ToString
                                LName = _nSqlDataReader(_iLName).ToString
                                MName = _nSqlDataReader(_iMName).ToString
                                Resident = _nSqlDataReader(_iResident).ToString
                                Own_Address = _nSqlDataReader(_iOwn_Address).ToString
                                Own_Brgy = _nSqlDataReader(_iOwn_Brgy).ToString
                                Own_Street = _nSqlDataReader(_iOwn_Street).ToString
                                Own_CityMun = _nSqlDataReader(_iOwn_CityMun).ToString
                                up_FileData1 = _nSqlDataReader(_iup_FileData1)
                                up_FileName1 = _nSqlDataReader(_iup_FileName1).ToString
                                up_FileType1 = _nSqlDataReader(_iup_FileType1).ToString
                                up_FileStatus1 = _nSqlDataReader(_iup_FileStatus1).ToString
                                up_FileRemarks1 = _nSqlDataReader(_iup_FileRemarks1).ToString
                                up_FileData2 = _nSqlDataReader(_iup_FileData2)
                                up_FileName2 = _nSqlDataReader(_iup_FileName2).ToString
                                up_FileType2 = _nSqlDataReader(_iup_FileType2).ToString
                                up_FileStatus2 = _nSqlDataReader(_iup_FileStatus2).ToString
                                up_FileRemarks2 = _nSqlDataReader(_iup_FileRemarks2).ToString
                                up_FileData3 = _nSqlDataReader(_iup_FileData3)
                                up_FileName3 = _nSqlDataReader(_iup_FileName3).ToString
                                up_FileType3 = _nSqlDataReader(_iup_FileType3).ToString
                                up_FileStatus3 = _nSqlDataReader(_iup_FileStatus3).ToString
                                up_FileRemarks3 = _nSqlDataReader(_iup_FileRemarks3).ToString
                                up_FileData4 = _nSqlDataReader(_iup_FileData4)
                                up_FileName4 = _nSqlDataReader(_iup_FileName4).ToString
                                up_FileType4 = _nSqlDataReader(_iup_FileType4).ToString
                                up_FileStatus4 = _nSqlDataReader(_iup_FileStatus4).ToString
                                up_FileRemarks4 = _nSqlDataReader(_iup_FileRemarks4).ToString
                                up_FileData5 = _nSqlDataReader(_iup_FileData5)
                                up_FileName5 = _nSqlDataReader(_iup_FileName5).ToString
                                up_FileType5 = _nSqlDataReader(_iup_FileType5).ToString
                                up_FileStatus5 = _nSqlDataReader(_iup_FileStatus5).ToString
                                up_FileRemarks5 = _nSqlDataReader(_iup_FileRemarks5).ToString
                                up_FileData6 = _nSqlDataReader(_iup_FileData6)
                                up_FileName6 = _nSqlDataReader(_iup_FileName6).ToString
                                up_FileType6 = _nSqlDataReader(_iup_FileType6).ToString
                                up_FileStatus6 = _nSqlDataReader(_iup_FileStatus6).ToString
                                up_FileRemarks6 = _nSqlDataReader(_iup_FileRemarks6).ToString
                                Date_Created = _nSqlDataReader(_iDate_Created).ToString
                                Last_Edit = _nSqlDataReader(_iLast_Edit).ToString
                                Date_Submitted = _nSqlDataReader(_iDate_Submitted).ToString
                                Status = _nSqlDataReader(_iStatus).ToString
                            Loop
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Function Get_NewBPInfo(ByVal AppID As String) As Boolean
        Try
            Dim _nQuery As String = _
            " select  " &
            " Application_ID,Status,A_Ownership,A_DtiSecCda,A_TIN,A_BusName,Date_Esta," &
            " B_HouseNo,isnull(B_BldgName,'')B_BldgName,isnull(B_LotNo,'')B_LotNo,isnull(B_BlockNo,'')B_BlockNo,B_Brgy,B_Street,isnull(B_Subd,'')B_Subd,B_CityMunicipality,B_Province,B_ZipCode," &
            " isnull(C_TelNo,'')C_TelNo,C_MobileNo,D_CTZNDESC,E_Lname,E_Fname,isnull(E_Mname,'')E_Mname,isnull(E_Suffix,'')E_Suffix," &
            " G_HouseNo,isnull(G_BldgName,'')G_BldgName,isnull(G_LotNo,'')G_LotNo,isnull(G_BlockNo,'')G_BlockNo,G_Brgy,G_Street,isnull(G_Subd,'')G_Subd,G_CityMunicipality,G_Province,G_ZipCode," &
            " isnull(F_MaleEmpNo,'0')F_MaleEmpNo,isnull(F_feMaleEmpNo,'0')F_feMaleEmpNo,isnull(F_ResideEmpNo,'0')F_ResideEmpNo,isnull(F_VanTruckNo,'0')F_VanTruckNo,isnull(F_MotorNo,'0')F_MotorNo," &
            " H_Nature" &
            " from NewBP_Draft where Application_ID='" & AppID & "'"

            Dim ReqDesc As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    Application_ID = _nSqlDr.Item("Application_ID")
                    Status = _nSqlDr.Item("Status")

                    A_Ownership = _nSqlDr.Item("A_Ownership")
                    A_DtiSecCda = _nSqlDr.Item("A_DtiSecCda")
                    A_TIN = _nSqlDr.Item("A_TIN")
                    A_BusName = _nSqlDr.Item("A_BusName")
                    Date_Esta = _nSqlDr.Item("Date_Esta")

                    B_HouseNo = _nSqlDr.Item("B_HouseNo")
                    B_BldgName = _nSqlDr.Item("B_BldgName")
                    B_LotNo = _nSqlDr.Item("B_LotNo")
                    B_BlockNo = _nSqlDr.Item("B_BlockNo")
                    B_Brgy = _nSqlDr.Item("B_Brgy")
                    B_Street = _nSqlDr.Item("B_Street")
                    B_Subd = _nSqlDr.Item("B_Subd")
                    B_CityMunicipality = _nSqlDr.Item("B_CityMunicipality")
                    B_Province = _nSqlDr.Item("B_Province")
                    B_ZipCode = _nSqlDr.Item("B_ZipCode")

                    C_TelNo = _nSqlDr.Item("C_TelNo")
                    C_MobileNo = _nSqlDr.Item("C_MobileNo")
                    D_CTZNDESC = _nSqlDr.Item("D_CTZNDESC")


                    E_Lname = _nSqlDr.Item("E_Lname")
                    E_Fname = _nSqlDr.Item("E_Fname")
                    E_Mname = _nSqlDr.Item("E_Mname")
                    E_Suffix = _nSqlDr.Item("E_Suffix")

                    G_HouseNo = _nSqlDr.Item("G_HouseNo")
                    G_BldgName = _nSqlDr.Item("G_BldgName")
                    G_LotNo = _nSqlDr.Item("G_LotNo")
                    G_BlockNo = _nSqlDr.Item("G_BlockNo")
                    G_Brgy = _nSqlDr.Item("G_Brgy")
                    G_Street = _nSqlDr.Item("G_Street")
                    G_Subd = _nSqlDr.Item("G_Subd")
                    G_CityMunicipality = _nSqlDr.Item("G_CityMunicipality")
                    G_Province = _nSqlDr.Item("G_Province")
                    G_ZipCode = _nSqlDr.Item("G_ZipCode")

                    F_MaleEmpNo = _nSqlDr.Item("F_MaleEmpNo")
                    F_FemaleEmpNo = _nSqlDr.Item("F_feMaleEmpNo")
                    F_ResideEmpNo = _nSqlDr.Item("F_ResideEmpNo")
                    F_VanTruckNo = _nSqlDr.Item("F_VanTruckNo")
                    F_MotorNo = _nSqlDr.Item("F_MotorNo")

                    H_Nature = _nSqlDr.Item("H_Nature")
                End If
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function Get_UploadedAttachments(ByVal AppID As String) As Boolean
        Try

        Catch ex As Exception

        End Try
    End Function

#End Region

End Class
