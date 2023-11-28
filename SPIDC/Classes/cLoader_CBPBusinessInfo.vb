Imports System.Web.HttpContext
Public Class cLoader_CBPBusinessInfo

    Private Const _sscPrefix As String = "cLoader_CBPBusinessInfo."
    Private Const _ssc_cbp_transaction_no As String = _sscPrefix & "_ssc_cbp_transaction_no"
    Private Const _ssc_verified_company_name As String = _sscPrefix & "_ssc_verified_company_name"
    Private Const _ssc_company_registration_no As String = _sscPrefix & "_ssc_company_registration_no"
    Private Const _ssc_tradename As String = _sscPrefix & "_ssc_tradename"
    Private Const _ssc_statement As String = _sscPrefix & "_ssc_statement"
    Private Const _ssc_type_of_business As String = _sscPrefix & "_ssc_type_of_business"
    Private Const _ssc_company_type As String = _sscPrefix & "_ssc_company_type"
    Private Const _ssc_company_sub_type As String = _sscPrefix & "_ssc_company_sub_type"
    Private Const _ssc_company_classification As String = _sscPrefix & "_ssc_company_classification"
    Private Const _ssc_economic_zone As String = _sscPrefix & "_ssc_economic_zone"
    Private Const _ssc_economic_zone_location As String = _sscPrefix & "_ssc_economic_zone_location"
    Private Const _ssc_enterprise_type As String = _sscPrefix & "_ssc_enterprise_type"
    Private Const _ssc_tin_number As String = _sscPrefix & "_ssc_tin_number"
    Private Const _ssc_zip_code As String = _sscPrefix & "_ssc_zip_code"
    Private Const _ssc_region_code As String = _sscPrefix & "_ssc_region_code"
    Private Const _ssc_province_code As String = _sscPrefix & "_ssc_province_code"
    Private Const _ssc_city_code As String = _sscPrefix & "_ssc_city_code"
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
    Private Const _ssc_landline As String = _sscPrefix & "_ssc_landline"
    Private Const _ssc_local As String = _sscPrefix & "_ssc_local"
    Private Const _ssc_mobile_no As String = _sscPrefix & "_ssc_mobile_no"
    Private Const _ssc_email_address As String = _sscPrefix & "_ssc_email_address"
    Private Const _ssc_territorial_region As String = _sscPrefix & "_ssc_territorial_region"
    Private Const _ssc_territorial_city As String = _sscPrefix & "_ssc_territorial_city"
    Private Const _ssc_territorial_barangay As String = _sscPrefix & "_ssc_territorial_barangay"
    Private Const _ssc_dominant_name As String = _sscPrefix & "_ssc_dominant_name"
    Private Const _ssc_date_of_birth As String = _sscPrefix & "_ssc_date_of_birth"
    Private Const _ssc_business_name_number As String = _sscPrefix & "_ssc_business_name_number"
    Private Const _ssc_authorized_capital_stock As String = _sscPrefix & "_ssc_authorized_capital_stock"
    Private Const _ssc_with_par_value_per_share As String = _sscPrefix & "_ssc_with_par_value_per_share"
    Private Const _ssc_without_par_value_per_share As String = _sscPrefix & "_ssc_without_par_value_per_share"
    Private Const _ssc_with_and_without_par_value_per_share As String = _sscPrefix & "_ssc_with_and_without_par_value_per_share"
    Private Const _ssc_subscribed_capital_stock As String = _sscPrefix & "_ssc_subscribed_capital_stock"
    Private Const _ssc_paid_up_capital_stock As String = _sscPrefix & "_ssc_paid_up_capital_stock"
    Private Const _ssc_total_contribution As String = _sscPrefix & "_ssc_total_contribution"
    Private Const _ssc_industry_classification_division As String = _sscPrefix & "_ssc_industry_classification_division"
    Private Const _ssc_industry_classification_group As String = _sscPrefix & "_ssc_industry_classification_group"
    Private Const _ssc_primary_purpose As String = _sscPrefix & "_ssc_primary_purpose"
    Private Const _ssc_secondary_purpose As String = _sscPrefix & "_ssc_secondary_purpose"
    Private Const _ssc_business_activities As String = _sscPrefix & "_ssc_business_activities"


    Shared Property _pcbp_transaction_no() As String
        Get
            Return Current.Session(_ssc_cbp_transaction_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_cbp_transaction_no) = value
        End Set
    End Property
    Shared Property _pverified_company_name() As String
        Get
            Return Current.Session(_ssc_verified_company_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_verified_company_name) = value
        End Set
    End Property

    Shared Property _pcompany_registration_no() As String
        Get
            Return Current.Session(_ssc_company_registration_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_company_registration_no) = value
        End Set
    End Property

    Shared Property _ptradename() As String
        Get
            Return Current.Session(_ssc_tradename)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_tradename) = value
        End Set
    End Property

    Shared Property _pstatement() As String
        Get
            Return Current.Session(_ssc_statement)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_statement) = value
        End Set
    End Property

    Shared Property _ptype_of_business() As String
        Get
            Return Current.Session(_ssc_type_of_business)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_type_of_business) = value
        End Set
    End Property

    Shared Property _pcompany_type() As String
        Get
            Return Current.Session(_ssc_company_type)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_company_type) = value
        End Set
    End Property

    Shared Property _pcompany_sub_type() As String
        Get
            Return Current.Session(_ssc_company_sub_type)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_company_sub_type) = value
        End Set
    End Property
    Shared Property _pcompany_classification() As String
        Get
            Return Current.Session(_ssc_company_classification)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_company_classification) = value
        End Set
    End Property
    Shared Property _peconomic_zone() As String
        Get
            Return Current.Session(_ssc_economic_zone)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_economic_zone) = value
        End Set
    End Property

    Shared Property _penterprise_type() As String
        Get
            Return Current.Session(_ssc_enterprise_type)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_enterprise_type) = value
        End Set
    End Property

    Shared Property _peconomic_zone_location() As String
        Get
            Return Current.Session(_ssc_economic_zone_location)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_economic_zone_location) = value
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
    Shared Property _pzip_code() As String
        Get
            Return Current.Session(_ssc_zip_code)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_zip_code) = value
        End Set
    End Property
    Shared Property _pregion_code() As String
        Get
            Return Current.Session(_ssc_region_code)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_region_code) = value
        End Set
    End Property
    Shared Property _pprovince_code() As String
        Get
            Return Current.Session(_ssc_province_code)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_province_code) = value
        End Set
    End Property
    Shared Property _pcity_code() As String
        Get
            Return Current.Session(_ssc_city_code)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_city_code) = value
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
    Shared Property _pmobile_no() As String
        Get
            Return Current.Session(_ssc_mobile_no)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_mobile_no) = value
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
    Shared Property _pterritorial_region() As String
        Get
            Return Current.Session(_ssc_territorial_region)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_territorial_region) = value
        End Set
    End Property
    Shared Property _pterritorial_city() As String
        Get
            Return Current.Session(_ssc_territorial_city)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_territorial_city) = value
        End Set
    End Property
    Shared Property _pterritorial_barangay() As String
        Get
            Return Current.Session(_ssc_territorial_barangay)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_territorial_barangay) = value
        End Set
    End Property
    Shared Property _pdominant_name() As String
        Get
            Return Current.Session(_ssc_dominant_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_dominant_name) = value
        End Set
    End Property
    Shared Property _pdate_of_birth() As String
        Get
            Return Current.Session(_ssc_date_of_birth)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_date_of_birth) = value
        End Set
    End Property
    Shared Property _pbusiness_name_number() As String
        Get
            Return Current.Session(_ssc_business_name_number)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_business_name_number) = value
        End Set
    End Property
    Shared Property _pauthorized_capital_stock() As String
        Get
            Return Current.Session(_ssc_authorized_capital_stock)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_authorized_capital_stock) = value
        End Set
    End Property
    Shared Property _pwith_par_value_per_share() As String
        Get
            Return Current.Session(_ssc_with_par_value_per_share)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_with_par_value_per_share) = value
        End Set
    End Property
    Shared Property _pwithout_par_value_per_share() As String
        Get
            Return Current.Session(_ssc_without_par_value_per_share)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_without_par_value_per_share) = value
        End Set
    End Property
    Shared Property _pwith_and_without_par_value_per_share() As String
        Get
            Return Current.Session(_ssc_with_and_without_par_value_per_share)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_with_and_without_par_value_per_share) = value
        End Set
    End Property
    Shared Property _psubscribed_capital_stock() As String
        Get
            Return Current.Session(_ssc_subscribed_capital_stock)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_subscribed_capital_stock) = value
        End Set
    End Property
    Shared Property _ppaid_up_capital_stock() As String
        Get
            Return Current.Session(_ssc_paid_up_capital_stock)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_paid_up_capital_stock) = value
        End Set
    End Property
    Shared Property _ptotal_contribution() As String
        Get
            Return Current.Session(_ssc_total_contribution)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_total_contribution) = value
        End Set
    End Property
    Shared Property _pindustry_classification_division() As String
        Get
            Return Current.Session(_ssc_industry_classification_division)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_industry_classification_division) = value
        End Set
    End Property
    Shared Property _pindustry_classification_group() As String
        Get
            Return Current.Session(_ssc_industry_classification_group)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_industry_classification_group) = value
        End Set
    End Property
    Shared Property _pprimary_purpose() As String
        Get
            Return Current.Session(_ssc_primary_purpose)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_primary_purpose) = value
        End Set
    End Property
    Shared Property _psecondary_purpose() As String
        Get
            Return Current.Session(_ssc_secondary_purpose)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_secondary_purpose) = value
        End Set
    End Property
    Shared Property _pbusiness_activities() As String
        Get
            Return Current.Session(_ssc_business_activities)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_business_activities) = value
        End Set
    End Property




End Class
