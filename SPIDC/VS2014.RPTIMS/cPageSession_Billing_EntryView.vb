

#Region "Imports"

Imports System.Web.HttpContext

#End Region

Public Class cPageSession_Billing_EntryView

#Region "Variables"
    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "cPageSession_ApplicationJobAddress_EntryView."

    Private Const _sscAddMode As String = _sscPrefix & "_sscAddMode"
    Private Const _sscEditMode As String = _sscPrefix & "_sscEditMode"

    Private Const _sscRegionCode As String = _sscPrefix & "_sscRegionCode"
    Private Const _sscProvinceCode As String = _sscPrefix & "_sscProvinceCode"
    Private Const _sscMuniCityCode As String = _sscPrefix & "_sscMuniCityCode"
    Private Const _sscBarangayCode As String = _sscPrefix & "_sscBarangayCode"
    Private Const _sscRegion As String = _sscPrefix & "_sscRegionCode"
    Private Const _sscProvince As String = _sscPrefix & "_sscProvince"
    Private Const _sscMuniCity As String = _sscPrefix & "_sscMuniCity"
    Private Const _sscBarangay As String = _sscPrefix & "_sscBarangay"
    Private Const _sscStreet As String = _sscPrefix & "_sscStreet"
    Private Const _sscZipCode As String = _sscPrefix & "_sscZipCode"
    Private Const _sscTelNo As String = _sscPrefix & "_sscTelNo"
    Private Const _sscEmailAdd As String = _sscPrefix & "_sscEmailAdd"
    Private Const _sscCellnoGlobe As String = _sscPrefix & "_sscCellnoGlobe"
    Private Const _sscCellnoSmart As String = _sscPrefix & "_sscCellnoSmart"
    Private Const _sscCellnoSun As String = _sscPrefix & "_sscCellnoSun"
    Private Const _sscDefault As String = _sscPrefix & "_sscDefault"


    Private Const _sscOrigRegionCode As String = _sscPrefix & "_sscOrigRegionCode"
    Private Const _sscOrigProvinceCode As String = _sscPrefix & "_sscOrigProvinceCode"
    Private Const _sscOrigMuniCityCode As String = _sscPrefix & "_sscOrigMuniCityCode"
    Private Const _sscOrigBarangayCode As String = _sscPrefix & "_sscOrigBarangayCode"
    Private Const _sscOrigRegion As String = _sscPrefix & "_sscOrigRegionCode"
    Private Const _sscOrigProvince As String = _sscPrefix & "_sscOrigProvince"
    Private Const _sscOrigMuniCity As String = _sscPrefix & "_sscOrigMuniCity"
    Private Const _sscOrigBarangay As String = _sscPrefix & "_sscOrigBarangay"
    Private Const _sscOrigStreet As String = _sscPrefix & "_sscOrigStreet"
    Private Const _sscOrigZipCode As String = _sscPrefix & "_sscOrigZipCode"
    Private Const _sscOrigTelNo As String = _sscPrefix & "_sscOrigTelNo"
    Private Const _sscOrigEmailAdd As String = _sscPrefix & "_sscOrigEmailAdd"
    Private Const _sscOrigCellnoGlobe As String = _sscPrefix & "_sscOrigCellnoGlobe"
    Private Const _sscOrigCellnoSmart As String = _sscPrefix & "_sscOrigCellnoSmart"
    Private Const _sscOrigCellnoSun As String = _sscPrefix & "_sscOrigCellnoSun"
    Private Const _sscOrigDefault As String = _sscPrefix & "_sscOrigDefault"

    Private Const _sscOrigSrvDateValue As String = _sscPrefix & "_sscOrigSrvDateValue"


#End Region

#Region "Properties"

    Shared Property _pOrigSrvDateValue() As String
        Get
            Return Current.Session(_sscOrigSrvDateValue)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigSrvDateValue) = value
        End Set
    End Property

    Shared Property _pAddMode() As Boolean
        Get
            Return Current.Session(_sscAddMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscAddMode) = value
        End Set
    End Property

    Shared Property _pEditMode() As Boolean
        Get
            Return Current.Session(_sscEditMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEditMode) = value
        End Set
    End Property
#End Region

#Region "Properties Field"
    Shared Property _pRegionCode() As String
        Get
            Return Current.Session(_sscRegionCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRegionCode) = value
        End Set
    End Property

    Shared Property _pProvinceCode() As String
        Get
            Return Current.Session(_sscProvinceCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscProvinceCode) = value
        End Set
    End Property

    Shared Property _pMuniCityCode() As String
        Get
            Return Current.Session(_sscMuniCityCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMuniCityCode) = value
        End Set
    End Property
    Shared Property _pBarangayCode() As String
        Get
            Return Current.Session(_sscBarangayCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBarangayCode) = value
        End Set
    End Property
    Shared Property _pRegion() As String
        Get
            Return Current.Session(_sscRegion)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRegion) = value
        End Set
    End Property

    Shared Property _pProvince() As String
        Get
            Return Current.Session(_sscProvince)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscProvince) = value
        End Set
    End Property

    Shared Property _pMuniCity() As String
        Get
            Return Current.Session(_sscMuniCity)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMuniCity) = value
        End Set
    End Property
    Shared Property _pBarangay() As String
        Get
            Return Current.Session(_sscBarangay)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBarangay) = value
        End Set
    End Property
    Shared Property _pStreet() As String
        Get
            Return Current.Session(_sscStreet)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscStreet) = value
        End Set
    End Property

    Shared Property _pZipCode() As String
        Get
            Return Current.Session(_sscZipCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscZipCode) = value
        End Set
    End Property

    Shared Property _pTelNo() As String
        Get
            Return Current.Session(_sscTelNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTelNo) = value
        End Set
    End Property
    Shared Property _pEmailAdd() As String
        Get
            Return Current.Session(_sscEmailAdd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEmailAdd) = value
        End Set
    End Property
    Shared Property _pCellnoGlobe() As String
        Get
            Return Current.Session(_sscCellnoGlobe)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscCellnoGlobe) = value
        End Set
    End Property
    Shared Property _pCellnoSmart() As String
        Get
            Return Current.Session(_sscCellnoSmart)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscCellnoSmart) = value
        End Set
    End Property
    Shared Property _pCellnoSun() As String
        Get
            Return Current.Session(_sscCellnoSun)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscCellnoSun) = value
        End Set
    End Property
    Shared Property _pDefault() As String
        Get
            Return Current.Session(_sscDefault)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDefault) = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"
    Shared Property _pOrigRegionCode() As String
        Get
            Return Current.Session(_sscOrigRegionCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigRegionCode) = value
        End Set
    End Property

    Shared Property _pOrigProvinceCode() As String
        Get
            Return Current.Session(_sscOrigProvinceCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigProvinceCode) = value
        End Set
    End Property

    Shared Property _pOrigMuniCityCode() As String
        Get
            Return Current.Session(_sscOrigMuniCityCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigMuniCityCode) = value
        End Set
    End Property
    Shared Property _pOrigBarangayCode() As String
        Get
            Return Current.Session(_sscOrigBarangayCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigBarangayCode) = value
        End Set
    End Property
    Shared Property _pOrigRegion() As String
        Get
            Return Current.Session(_sscOrigRegion)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigRegion) = value
        End Set
    End Property

    Shared Property _pOrigProvince() As String
        Get
            Return Current.Session(_sscOrigProvince)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigProvince) = value
        End Set
    End Property

    Shared Property _pOrigMuniCity() As String
        Get
            Return Current.Session(_sscOrigMuniCity)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigMuniCity) = value
        End Set
    End Property
    Shared Property _pOrigBarangay() As String
        Get
            Return Current.Session(_sscOrigBarangay)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigBarangay) = value
        End Set
    End Property
    Shared Property _pOrigStreet() As String
        Get
            Return Current.Session(_sscOrigStreet)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigStreet) = value
        End Set
    End Property

    Shared Property _pOrigZipCode() As String
        Get
            Return Current.Session(_sscOrigZipCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigZipCode) = value
        End Set
    End Property

    Shared Property _pOrigTelNo() As String
        Get
            Return Current.Session(_sscOrigTelNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigTelNo) = value
        End Set
    End Property
    Shared Property _pOrigEmailAdd() As String
        Get
            Return Current.Session(_sscOrigEmailAdd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigEmailAdd) = value
        End Set
    End Property
    Shared Property _pOrigCellnoGlobe() As String
        Get
            Return Current.Session(_sscOrigCellnoGlobe)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigCellnoGlobe) = value
        End Set
    End Property
    Shared Property _pOrigCellnoSmart() As String
        Get
            Return Current.Session(_sscOrigCellnoSmart)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigCellnoSmart) = value
        End Set
    End Property
    Shared Property _pOrigCellnoSun() As String
        Get
            Return Current.Session(_sscOrigCellnoSun)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigCellnoSun) = value
        End Set
    End Property

    Shared Property _pOrigDefault() As String
        Get
            Return Current.Session(_sscOrigDefault)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigDefault) = value
        End Set
    End Property
#End Region

#Region "Routines"
    Public Shared Sub _pSubSessionClear()
        Try
            '----------------------------------
            'Avoid exposing the Password.
            'Just use the KeyToken to verify Access.

            _pRegionCode = Nothing
            _pProvinceCode = Nothing
            _pMuniCityCode = Nothing
            _pBarangayCode = Nothing
            _pRegion = Nothing
            _pProvince = Nothing
            _pMuniCity = Nothing
            _pBarangay = Nothing
            _pStreet = Nothing
            _pZipCode = Nothing
            _pTelNo = Nothing
            _pEmailAdd = Nothing
            _pCellnoGlobe = Nothing
            _pCellnoSmart = Nothing
            _pCellnoSun = Nothing
            _pDefault = Nothing


            _pOrigRegionCode = Nothing
            _pOrigProvinceCode = Nothing
            _pOrigMuniCityCode = Nothing
            _pOrigBarangayCode = Nothing
            _pOrigRegion = Nothing
            _pOrigProvince = Nothing
            _pOrigMuniCity = Nothing
            _pOrigBarangay = Nothing
            _pOrigStreet = Nothing
            _pOrigZipCode = Nothing
            _pOrigTelNo = Nothing
            _pOrigEmailAdd = Nothing
            _pOrigCellnoGlobe = Nothing
            _pOrigCellnoSmart = Nothing
            _pOrigCellnoSun = Nothing
            _pOrigDefault = Nothing
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
