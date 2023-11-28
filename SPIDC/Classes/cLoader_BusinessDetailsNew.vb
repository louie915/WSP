Imports System.Web.HttpContext

Public Class cLoader_BusinessDetailsNew

    Private Const _sscPrefix As String = "cLoader_BusinessDetailsNew."

    Private Const _ssc_BusinessID As String = _sscPrefix & "_ssc_BusinessID"
    Private Const _ssc_CatCode As String = _sscPrefix & "_ssc_CatCode"
    Private Const _ssc_Category As String = _sscPrefix & "_ssc_Category"
    Private Const _ssc_Area As String = _sscPrefix & "_ssc_Area"
    Private Const _ssc_ProductsServices As String = _sscPrefix & "_ssc_ProductsServices"
    Private Const _ssc_Capital As String = _sscPrefix & "_ssc_Capital"
    Private Const _ssc_Vehicles As String = _sscPrefix & "_ssc_Vehicles"
    Private Const _ssc_Capacity As String = _sscPrefix & "_ssc_Capacity"
    Private Const _ssc_Asset As String = _sscPrefix & "_ssc_Asset"


#Region "BusinessDetailsNew"
    Shared Property _pBusinessID() As String
        Get
            Return Current.Session(_ssc_BusinessID)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BusinessID) = value
        End Set
    End Property

    Shared Property _pCatCode() As String
        Get
            Return Current.Session(_ssc_CatCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CatCode) = value
        End Set
    End Property

    Shared Property _pCategory() As String
        Get
            Return Current.Session(_ssc_Category)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Category) = value
        End Set
    End Property

    Shared Property _pArea() As String
        Get
            Return Current.Session(_ssc_Area)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Area) = value
        End Set
    End Property

    Shared Property _pProductsServices() As String
        Get
            Return Current.Session(_ssc_ProductsServices)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_ProductsServices) = value
        End Set
    End Property

    Shared Property _pCapital() As String
        Get
            Return Current.Session(_ssc_Capital)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Capital) = value
        End Set
    End Property

    Shared Property _pVehicles() As String
        Get
            Return Current.Session(_ssc_Vehicles)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Vehicles) = value
        End Set
    End Property

    Shared Property _pCapacity() As String
        Get
            Return Current.Session(_ssc_Capacity)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Capacity) = value
        End Set
    End Property

    Shared Property _pAsset() As String
        Get
            Return Current.Session(_ssc_Asset)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Asset) = value
        End Set
    End Property


#End Region




End Class
