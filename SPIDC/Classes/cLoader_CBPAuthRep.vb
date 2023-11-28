Imports System.Web.HttpContext

Public Class cLoader_CBPAuthRep

    Private Const _sscPrefix As String = "cLoader_CBPAuthRep."
    Private Const _ssc_IsFromCBP As String = _sscPrefix & "_ssc_IsFromCBP"
    Private Const _ssc_cbp_transaction_no As String = _sscPrefix & "_ssc_cbp_transaction_no"
    Private Const _ssc_first_name As String = _sscPrefix & "_ssc_first_name"
    Private Const _ssc_middle_name As String = _sscPrefix & "_ssc_middle_name"
    Private Const _ssc_last_name As String = _sscPrefix & "_ssc_last_name"
    Private Const _ssc_suffix As String = _sscPrefix & "_ssc_suffix"
    Private Const _ssc_sex As String = _sscPrefix & "_ssc_sex"
    Private Const _ssc_birthday As String = _sscPrefix & "_ssc_birthday"
    Private Const _ssc_nationality As String = _sscPrefix & "_ssc_nationality"
    Private Const _ssc_tin_number As String = _sscPrefix & "_ssc_tin_number"
    Private Const _ssc_position As String = _sscPrefix & "_ssc_position"
    Private Const _ssc_role As String = _sscPrefix & "_ssc_role"
    Private Const _ssc_zip_code As String = _sscPrefix & "_ssc_zip_code"
    Private Const _ssc_region As String = _sscPrefix & "_ssc_region"
    Private Const _ssc_province As String = _sscPrefix & "_ssc_province"
    Private Const _ssc_town As String = _sscPrefix & "_ssc_town"
    Private Const _ssc_municipality As String = _sscPrefix & "_ssc_municipality"
    Private Const _ssc_barangay As String = _sscPrefix & "_ssc_barangay"
    Private Const _ssc_subdivision As String = _sscPrefix & "_ssc_subdivision"
    Private Const _ssc_street_name As String = _sscPrefix & "_ssc_street_name"
    Private Const _ssc_bldg_no As String = _sscPrefix & "_ssc_bldg_no"
    Private Const _ssc_bldg_name As String = _sscPrefix & "_ssc_bldg_name"
    Private Const _ssc_house_no As String = _sscPrefix & "_ssc_house_no"
    Private Const _ssc_email_address As String = _sscPrefix & "_ssc_email_address"
    Private Const _ssc_alternate_email_address As String = _sscPrefix & "_ssc_alternate_email_address"
    Private Const _ssc_mobile_no As String = _sscPrefix & "_ssc_mobile_no"
    Private Const _ssc_landline As String = _sscPrefix & "_ssc_landline"
    Private Const _ssc_local As String = _sscPrefix & "_ssc_local"
    Private Const _ssc_country As String = _sscPrefix & "_ssc_country"
    Private Const _ssc_address As String = _sscPrefix & "_ssc_address"
    Private Const _ssc_country_code As String = _sscPrefix & "_ssc_country_code"
    Private Const _ssc_telephone_number As String = _sscPrefix & "_ssc_telephone_number"
    Private Const _ssc_guid As String = _sscPrefix & "_ssc_guid"

    Private Const _ssc_IsRegCBP As String = _sscPrefix & "_ssc_IsRegCBP"
    Private Const _ssc_IsRegOAIMS As String = _sscPrefix & "_ssc_IsRegOAIMS"

    Private Const _ssc_BearerToken As String = _sscPrefix & "_ssc_BearerToken" ' @ Added 20211108 

    Shared Property _pIsFromCBP() As Boolean
        Get
            Return Current.Session(_ssc_IsFromCBP)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_IsFromCBP) = value
        End Set
    End Property

    Shared Property _pcbp_transaction_no() As String
        Get
            Return Current.Session(_ssc_cbp_transaction_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_cbp_transaction_no) = value
        End Set
    End Property

    Shared Property _pfirst_name() As String
        Get
            Return Current.Session(_ssc_first_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_first_name) = value
        End Set
    End Property
    Shared Property _pmiddle_name() As String
        Get
            Return Current.Session(_ssc_middle_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_middle_name) = value
        End Set
    End Property

    Shared Property _plast_name() As String
        Get
            Return Current.Session(_ssc_last_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_last_name) = value
        End Set
    End Property
    Shared Property _psuffix() As String
        Get
            Return Current.Session(_ssc_suffix)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_suffix) = value
        End Set
    End Property
    Shared Property _psex() As String
        Get
            Return Current.Session(_ssc_sex)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_sex) = value
        End Set
    End Property
    Shared Property _pbirthday() As String
        Get
            Return Current.Session(_ssc_birthday)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_birthday) = value
        End Set
    End Property
    Shared Property _pnationality() As String
        Get
            Return Current.Session(_ssc_nationality)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_nationality) = value
        End Set
    End Property
    Shared Property _ptin_number() As String
        Get
            Return Current.Session(_ssc_tin_number)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_tin_number) = value
        End Set
    End Property
    Shared Property _pposition() As String
        Get
            Return Current.Session(_ssc_position)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_position) = value
        End Set
    End Property
    Shared Property _prole() As String
        Get
            Return Current.Session(_ssc_role)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_role) = value
        End Set
    End Property
    Shared Property _pzip_code() As String
        Get
            Return Current.Session(_ssc_zip_code)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_zip_code) = value
        End Set
    End Property
    Shared Property _pregion() As String
        Get
            Return Current.Session(_ssc_region)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_region) = value
        End Set
    End Property
    Shared Property _pprovince() As String
        Get
            Return Current.Session(_ssc_province)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_province) = value
        End Set
    End Property
    Shared Property _ptown() As String
        Get
            Return Current.Session(_ssc_town)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_town) = value
        End Set
    End Property
    Shared Property _pmunicipality() As String
        Get
            Return Current.Session(_ssc_municipality)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_municipality) = value
        End Set
    End Property
    Shared Property _pbarangay() As String
        Get
            Return Current.Session(_ssc_barangay)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_barangay) = value
        End Set
    End Property
    Shared Property _psubdivision() As String
        Get
            Return Current.Session(_ssc_subdivision)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_subdivision) = value
        End Set
    End Property
    Shared Property _pstreet_name() As String
        Get
            Return Current.Session(_ssc_street_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_street_name) = value
        End Set
    End Property
    Shared Property _pbldg_no() As String
        Get
            Return Current.Session(_ssc_bldg_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_bldg_no) = value
        End Set
    End Property
    Shared Property _pbldg_name() As String
        Get
            Return Current.Session(_ssc_bldg_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_bldg_name) = value
        End Set
    End Property
    Shared Property _phouse_no() As String
        Get
            Return Current.Session(_ssc_house_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_house_no) = value
        End Set
    End Property
    Shared Property _pemail_address() As String
        Get
            Return Current.Session(_ssc_email_address)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_email_address) = value
        End Set
    End Property
    Shared Property _palternate_email_address() As String
        Get
            Return Current.Session(_ssc_alternate_email_address)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_alternate_email_address) = value
        End Set
    End Property
    Shared Property _pmobile_no() As String
        Get
            Return Current.Session(_ssc_mobile_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_mobile_no) = value
        End Set
    End Property
    Shared Property _plandline() As String
        Get
            Return Current.Session(_ssc_landline)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_landline) = value
        End Set
    End Property
    Shared Property _plocal() As String
        Get
            Return Current.Session(_ssc_local)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_local) = value
        End Set
    End Property
    Shared Property _pcountry() As String
        Get
            Return Current.Session(_ssc_country)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_country) = value
        End Set
    End Property
    Shared Property _paddress() As String
        Get
            Return Current.Session(_ssc_address)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_address) = value
        End Set
    End Property
    Shared Property _pcountry_code() As String
        Get
            Return Current.Session(_ssc_country_code)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_country_code) = value
        End Set
    End Property
    Shared Property _ptelephone_number() As String
        Get
            Return Current.Session(_ssc_telephone_number)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_telephone_number) = value
        End Set
    End Property
    Shared Property _pguid() As String
        Get
            Return Current.Session(_ssc_guid)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_guid) = value
        End Set
    End Property

    Shared Property _pIsRegCBP() As Boolean
        Get
            Return Current.Session(_ssc_IsRegCBP)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_IsRegCBP) = value
        End Set
    End Property

    Shared Property _pIsRegOAIMS() As Boolean
        Get
            Return Current.Session(_ssc_IsRegOAIMS)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_IsRegOAIMS) = value
        End Set
    End Property

    Shared Property _pBearerToken() As String
        Get
            Return Current.Session(_ssc_BearerToken)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BearerToken) = value
        End Set
    End Property

End Class
