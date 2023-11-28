#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
#End Region

Public Class cSessionLoader_NEWBP_Draft

#Region "Variables"


    Private Const _sscPrefix As String = "cSessionLoader."
    Private Const _sscApplication_ID As String = _sscPrefix & "_sscApplication_ID"
    Private Const _sscUserID As String = _sscPrefix & "_sscUserID"
    Private Const _sscA_Ownership As String = _sscPrefix & "_sscA_Ownership"
    Private Const _sscA_DtiSecCda As String = _sscPrefix & "_sscA_DtiSecCda"
    Private Const _sscA_BusName As String = _sscPrefix & "_sscA_BusName"
    Private Const _sscA_TIN As String = _sscPrefix & "_sscA_TIN"
    Private Const _sscB_HouseNo As String = _sscPrefix & "_sscB_HouseNo"
    Private Const _sscB_BldgName As String = _sscPrefix & "_sscB_BldgName"
    Private Const _sscB_LotNo As String = _sscPrefix & "_sscB_LotNo"
    Private Const _sscB_BlockNo As String = _sscPrefix & "_sscB_BlockNo"
    Private Const _sscB_Street As String = _sscPrefix & "_sscB_Street"
    Private Const _sscB_Brgy As String = _sscPrefix & "_sscB_Brgy"
    Private Const _sscB_Subd As String = _sscPrefix & "_sscB_Subd"
    Private Const _sscB_CityMunicipality As String = _sscPrefix & "_sscB_CityMunicipality"
    Private Const _sscB_Province As String = _sscPrefix & "_sscB_Province"
    Private Const _sscB_ZipCode As String = _sscPrefix & "_sscB_ZipCode"
    Private Const _sscC_TelNo As String = _sscPrefix & "_sscC_TelNo"
    Private Const _sscC_MobileNo As String = _sscPrefix & "_sscC_MobileNo"
    Private Const _sscC_Email As String = _sscPrefix & "_sscC_Email"
    Private Const _sscLGU_Name As String = _sscPrefix & "_sscD_Lname"
    Private Const _sscD_Fname As String = _sscPrefix & "_sscD_Fname"
    Private Const _sscD_Mname As String = _sscPrefix & "_sscD_Mname"
    Private Const _sscD_Suffix As String = _sscPrefix & "_sscD_Suffix"
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
#End Region

#Region "Properties"

    Shared Property _pApplication_ID() As String
        Get
            Return Current.Session(_sscApplication_ID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscApplication_ID) = value
        End Set
    End Property

    Shared Property _pUserID() As String
        Get
            Return Current.Session(_sscUserID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUserID) = value
        End Set
    End Property

    Shared Property _pA_Ownership() As String
        Get
            Return Current.Session(_sscA_Ownership)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_Ownership) = value
        End Set
    End Property

    Shared Property _pA_DtiSecCda() As String
        Get
            Return Current.Session(_sscA_DtiSecCda)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_DtiSecCda) = value
        End Set
    End Property

    Shared Property _pA_BusName() As String
        Get
            Return Current.Session(_sscA_BusName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_BusName) = value
        End Set
    End Property

    Shared Property _pA_TIN() As String
        Get
            Return Current.Session(_sscA_TIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscA_TIN) = value
        End Set
    End Property

    Shared Property _pB_HouseNo() As String
        Get
            Return Current.Session(_sscB_HouseNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_HouseNo) = value
        End Set
    End Property

    Shared Property _pB_BldgName() As String
        Get
            Return Current.Session(_sscB_BldgName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_BldgName) = value
        End Set
    End Property

    Shared Property _pB_LotNo() As String
        Get
            Return Current.Session(_sscB_LotNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_LotNo) = value
        End Set
    End Property

    Shared Property _pB_BlockNo() As String
        Get
            Return Current.Session(_sscB_BlockNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_BlockNo) = value
        End Set
    End Property

    Shared Property _pB_Street() As String
        Get
            Return Current.Session(_sscB_Street)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Street) = value
        End Set
    End Property

    Shared Property _pB_Brgy() As String
        Get
            Return Current.Session(_sscB_Brgy)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Brgy) = value
        End Set
    End Property

    Shared Property _pB_Subd() As String
        Get
            Return Current.Session(_sscB_Subd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Subd) = value
        End Set
    End Property

    Shared Property _pB_CityMunicipality() As String
        Get
            Return Current.Session(_sscB_CityMunicipality)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_CityMunicipality) = value
        End Set
    End Property

    Shared Property _pB_Province() As String
        Get
            Return Current.Session(_sscB_Province)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_Province) = value
        End Set
    End Property

    Shared Property _pB_ZipCode() As String
        Get
            Return Current.Session(_sscB_ZipCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscB_ZipCode) = value
        End Set
    End Property

    Shared Property _pC_TelNo() As String
        Get
            Return Current.Session(_sscC_TelNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscC_TelNo) = value
        End Set
    End Property

    Shared Property _pC_MobileNo() As String
        Get
            Return Current.Session(_sscC_MobileNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscC_MobileNo) = value
        End Set
    End Property

    Shared Property _pC_Email() As String
        Get
            Return Current.Session(_sscC_Email)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscC_Email) = value
        End Set
    End Property

    Shared Property _pLGU_Name() As String
        Get
            Return Current.Session(_sscLGU_Name)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Name) = value
        End Set
    End Property

    Shared Property _pD_Fname() As String
        Get
            Return Current.Session(_sscD_Fname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Fname) = value
        End Set
    End Property

    Shared Property _pD_Mname() As String
        Get
            Return Current.Session(_sscD_Mname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Mname) = value
        End Set
    End Property

    Shared Property _pD_Suffix() As String
        Get
            Return Current.Session(_sscD_Suffix)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscD_Suffix) = value
        End Set
    End Property

    Shared Property _pE_Lname() As String
        Get
            Return Current.Session(_sscE_Lname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Lname) = value
        End Set
    End Property

    Shared Property _pE_Fname() As String
        Get
            Return Current.Session(_sscE_Fname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Fname) = value
        End Set
    End Property

    Shared Property _pE_Mname() As String
        Get
            Return Current.Session(_sscE_Mname)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Mname) = value
        End Set
    End Property

    Shared Property _pE_Suffix() As String
        Get
            Return Current.Session(_sscE_Suffix)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Suffix) = value
        End Set
    End Property

    Shared Property _pE_Nationality() As String
        Get
            Return Current.Session(_sscE_Nationality)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscE_Nationality) = value
        End Set
    End Property

    Shared Property _pF_BusArea() As String
        Get
            Return Current.Session(_sscF_BusArea)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_BusArea) = value
        End Set
    End Property

    Shared Property _pF_FlrArea() As String
        Get
            Return Current.Session(_sscF_FlrArea)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_FlrArea) = value
        End Set
    End Property

    Shared Property _pF_MaleEmpNo() As String
        Get
            Return Current.Session(_sscF_MaleEmpNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_MaleEmpNo) = value
        End Set
    End Property

    Shared Property _pF_FemaleEmpNo() As String
        Get
            Return Current.Session(_sscF_FemaleEmpNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_FemaleEmpNo) = value
        End Set
    End Property

    Shared Property _pF_ResideEmpNo() As String
        Get
            Return Current.Session(_sscF_ResideEmpNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_ResideEmpNo) = value
        End Set
    End Property

    Shared Property _pF_VanTruckNo() As String
        Get
            Return Current.Session(_sscF_VanTruckNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_VanTruckNo) = value
        End Set
    End Property

    Shared Property _pF_MotorNo() As String
        Get
            Return Current.Session(_sscF_MotorNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscF_MotorNo) = value
        End Set
    End Property

    Shared Property _pG_HouseNo() As String
        Get
            Return Current.Session(_sscG_HouseNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_HouseNo) = value
        End Set
    End Property

    Shared Property _pG_BldgName() As String
        Get
            Return Current.Session(_sscG_BldgName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_BldgName) = value
        End Set
    End Property

    Shared Property _pG_LotNo() As String
        Get
            Return Current.Session(_sscG_LotNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_LotNo) = value
        End Set
    End Property

    Shared Property _pG_BlockNo() As String
        Get
            Return Current.Session(_sscG_BlockNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_BlockNo) = value
        End Set
    End Property

    Shared Property _pG_Street() As String
        Get
            Return Current.Session(_sscG_Street)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Street) = value
        End Set
    End Property

    Shared Property _pG_Brgy() As String
        Get
            Return Current.Session(_sscG_Brgy)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Brgy) = value
        End Set
    End Property

    Shared Property _pG_Subd() As String
        Get
            Return Current.Session(_sscG_Subd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Subd) = value
        End Set
    End Property

    Shared Property _pG_CityMunicipality() As String
        Get
            Return Current.Session(_sscG_CityMunicipality)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_CityMunicipality) = value
        End Set
    End Property

    Shared Property _pG_Province() As String
        Get
            Return Current.Session(_sscG_Province)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_Province) = value
        End Set
    End Property

    Shared Property _pG_ZipCode() As String
        Get
            Return Current.Session(_sscG_ZipCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscG_ZipCode) = value
        End Set
    End Property

    Shared Property _pH_Capital() As String
        Get
            Return Current.Session(_sscH_Capital)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_Capital) = value
        End Set
    End Property

    Shared Property _pH_Nature() As String
        Get
            Return Current.Session(_sscH_Nature)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_Nature) = value
        End Set
    End Property

    Shared Property _pH_Owned() As String
        Get
            Return Current.Session(_sscH_Owned)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_Owned) = value
        End Set
    End Property

    Shared Property _pH_TDN() As String
        Get
            Return Current.Session(_sscH_TDN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_TDN) = value
        End Set
    End Property

    Shared Property _pH_PIN() As String
        Get
            Return Current.Session(_sscH_PIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_PIN) = value
        End Set
    End Property

    Shared Property _pH_GovIncentive() As String
        Get
            Return Current.Session(_sscH_GovIncentive)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_GovIncentive) = value
        End Set
    End Property

    Shared Property _pH_BusAct() As String
        Get
            Return Current.Session(_sscH_BusAct)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscH_BusAct) = value
        End Set
    End Property

#End Region


End Class


