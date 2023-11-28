Public Class cLoaderNewBusinessApplication

#Region "Slide_01"

    Private Shared _mOwnershipType As String
    Private Shared _mRent As Boolean

#End Region

#Region "Slide_02"

    Private Shared _mLessorDateRented As String
    Private Shared _mLessorRatePerMonth As String
    Private Shared _mLessorFirstName As String
    Private Shared _mLessorLastName As String
    Private Shared _mLessorBarangay As String
    Private Shared _mLessorStreet As String
    Private Shared _mLessorAddress As String
    Private Shared _mLessorTelNo As String
    Private Shared _mLessorEmail As String
    Private Shared _mBuildingAdministrator As String

#End Region

#Region "Slide_05"

    Private Shared _mGovCDANo As String
    Private Shared _mGovRegDateCDA As String
    Private Shared _mGovDTINo As String
    Private Shared _mGovRegDateDTI As String
    Private Shared _mGovSECNo As String
    Private Shared _mGovRegDateSEC As String
    Private Shared _mGovTINNo As String
    Private Shared _mGovRegDateTIN As String
    Private Shared _mGovSSS As String
    Private Shared _mGovRegDateSSS As String
    Private Shared _mGovBIR As String
    Private Shared _mGovRegDateBIR As String
    Private Shared _mGovBrgyClearance As String
    Private Shared _mGovRegDateBrgyClearance As String

#End Region

#Region "Slide_06"

    Private Shared _mBusBranch As String
    Private Shared _mBusDateEsta As String
    Private Shared _mBusTradeName As String
    Private Shared _mBusMale As String
    Private Shared _mBusFemale As String
    Private Shared _mBusTotal As String
    Private Shared _mBusResident As String

#End Region

#Region "Slide_07"

    Private Shared _mBusBrgy As String
    Private Shared _mBusStrt As String
    Private Shared _mBusAddress As String

#End Region

#Region "Slide_08"

    Private Shared _mOwnerFName As String
    Private Shared _mOwnerLName As String
    Private Shared _mOwnerMName As String
    Private Shared _mOwnerSuffix As String
    Private Shared _mOwnerGender As String
    Private Shared _mOwnerCitizenship As String
    Private Shared _mOwnerCheck As Boolean
    Private Shared _mOwnerAddress As String
    Private Shared _mOwnerTelNo As String
    Private Shared _mOwnerEmail As String
    Private Shared _mOwnerAltEmail As String

#End Region

#Region "Slide_09"

    Private Shared _mIncLName As String
    Private Shared _mIncMName As String
    Private Shared _mIncFName As String
    Private Shared _mIncAddress As String

#End Region

#Region "Slide_10"

    Private Shared _mIncAddTName As String
    Private Shared _mIncAddRName As String
    Private Shared _mIncAddPosition As String

#End Region

#Region "Slide_01"

    Public Shared Property _pOwnershipType() As String
        Get
            Return _mOwnershipType
        End Get
        Set(value As String)
            _mOwnershipType = value
        End Set
    End Property

    Public Shared Property _pRent() As Boolean
        Get
            Return _mRent
        End Get
        Set(value As Boolean)
            _mRent = value
        End Set
    End Property

#End Region

#Region "Slide_02"

    Public Shared Property _pLessorDateRented() As String
        Get
            Return _mLessorDateRented
        End Get
        Set(value As String)
            _mLessorDateRented = value
        End Set
    End Property

    Public Shared Property _pLessorRatePerMonth() As String
        Get
            Return _mLessorRatePerMonth
        End Get
        Set(value As String)
            _mLessorRatePerMonth = value
        End Set
    End Property

    Public Shared Property _pLessorFirstName() As String
        Get
            Return _mLessorFirstName
        End Get
        Set(value As String)
            _mLessorFirstName = value
        End Set
    End Property

    Public Shared Property _pLessorLastName() As String
        Get
            Return _mLessorLastName
        End Get
        Set(value As String)
            _mLessorLastName = value
        End Set
    End Property

    Public Shared Property _pLessorBarangay() As String
        Get
            Return _mLessorBarangay
        End Get
        Set(value As String)
            _mLessorBarangay = value
        End Set
    End Property

    Public Shared Property _pLessorStreet() As String
        Get
            Return _mLessorStreet
        End Get
        Set(value As String)
            _mLessorStreet = value
        End Set
    End Property

    Public Shared Property _pLessorAddress() As String
        Get
            Return _mLessorAddress
        End Get
        Set(value As String)
            _mLessorAddress = value
        End Set
    End Property

    Public Shared Property _pLessorTelNo() As String
        Get
            Return _mLessorTelNo
        End Get
        Set(value As String)
            _mLessorTelNo = value
        End Set
    End Property

    Public Shared Property _pLessorEmail() As String
        Get
            Return _mLessorEmail
        End Get
        Set(value As String)
            _mLessorEmail = value
        End Set
    End Property

    Public Shared Property _pBuildingAdministrator() As String
        Get
            Return _mBuildingAdministrator
        End Get
        Set(value As String)
            _mBuildingAdministrator = value
        End Set
    End Property

#End Region

#Region "Slide_05"

    Public Shared Property _pGovCDANo() As String
        Get
            Return _mGovCDANo
        End Get
        Set(value As String)
            _mGovCDANo = value
        End Set
    End Property

    Public Shared Property _pGovRegDateCDA() As String
        Get
            Return _mGovRegDateCDA
        End Get
        Set(value As String)
            _mGovRegDateCDA = value
        End Set
    End Property

    Public Shared Property _pGovDTINo() As String
        Get
            Return _mGovDTINo
        End Get
        Set(value As String)
            _mGovDTINo = value
        End Set
    End Property

    Public Shared Property _pGovRegDateDTI() As String
        Get
            Return _mGovRegDateDTI
        End Get
        Set(value As String)
            _mGovRegDateDTI = value
        End Set
    End Property

    Public Shared Property _pGovSECNo() As String
        Get
            Return _mGovSECNo
        End Get
        Set(value As String)
            _mGovSECNo = value
        End Set
    End Property

    Public Shared Property _pGovRegDateSEC() As String
        Get
            Return _mGovRegDateSEC
        End Get
        Set(value As String)
            _mGovRegDateSEC = value
        End Set
    End Property

    Public Shared Property _pGovTINNo() As String
        Get
            Return _mGovTINNo
        End Get
        Set(value As String)
            _mGovTINNo = value
        End Set
    End Property

    Public Shared Property _pGovRegDateTIN() As String
        Get
            Return _mGovRegDateTIN
        End Get
        Set(value As String)
            _mGovRegDateTIN = value
        End Set
    End Property

    Public Shared Property _pGovSSS() As String
        Get
            Return _mGovSSS
        End Get
        Set(value As String)
            _mGovSSS = value
        End Set
    End Property

    Public Shared Property _pGovRegDateSSS() As String
        Get
            Return _mGovRegDateSSS
        End Get
        Set(value As String)
            _mGovRegDateSSS = value
        End Set
    End Property

    Public Shared Property _pGovBIR() As String
        Get
            Return _mGovBIR
        End Get
        Set(value As String)
            _mGovBIR = value
        End Set
    End Property

    Public Shared Property _pGovRegDateBIR() As String
        Get
            Return _mGovRegDateBIR
        End Get
        Set(value As String)
            _mGovRegDateBIR = value
        End Set
    End Property

    Public Shared Property _pGovBrgyClearance() As String
        Get
            Return _mGovBrgyClearance
        End Get
        Set(value As String)
            _mGovBrgyClearance = value
        End Set
    End Property

    Public Shared Property _pGovRegDateBrgyClearance() As String
        Get
            Return _mGovRegDateBrgyClearance
        End Get
        Set(value As String)
            _mGovRegDateBrgyClearance = value
        End Set
    End Property

#End Region

#Region "Slide_06"

    Public Shared Property _pBusBranch() As String
        Get
            Return _mBusBranch
        End Get
        Set(value As String)
            _mBusBranch = value
        End Set
    End Property

    Public Shared Property _pBusDateEsta() As String
        Get
            Return _mBusDateEsta
        End Get
        Set(value As String)
            _mBusDateEsta = value
        End Set
    End Property

    Public Shared Property _pBusTradeName() As String
        Get
            Return _mBusTradeName
        End Get
        Set(value As String)
            _mBusTradeName = value
        End Set
    End Property

    Public Shared Property _pBusMale() As String
        Get
            Return _mBusMale
        End Get
        Set(value As String)
            _mBusMale = value
        End Set
    End Property

    Public Shared Property _pBusFemale() As String
        Get
            Return _mBusFemale
        End Get
        Set(value As String)
            _mBusFemale = value
        End Set
    End Property

    Public Shared Property _pBusTotal() As String
        Get
            Return _mBusTotal
        End Get
        Set(value As String)
            _mBusTotal = value
        End Set
    End Property

    Public Shared Property _pBusResident() As String
        Get
            Return _mBusResident
        End Get
        Set(value As String)
            _mBusResident = value
        End Set
    End Property

#End Region

#Region "Slide_07"

    Public Shared Property _pBusBrgy() As String
        Get
            Return _mBusBrgy
        End Get
        Set(value As String)
            _mBusBrgy = value
        End Set
    End Property

    Public Shared Property _pBusStrt() As String
        Get
            Return _mBusStrt
        End Get
        Set(value As String)
            _mBusStrt = value
        End Set
    End Property

    Public Shared Property _pBusAddress() As String
        Get
            Return _mBusAddress
        End Get
        Set(value As String)
            _mBusAddress = value
        End Set
    End Property


#End Region

#Region "Slide_08"

    Public Shared Property _pOwnerFName() As String
        Get
            Return _mOwnerFName
        End Get
        Set(value As String)
            _mOwnerFName = value
        End Set
    End Property

    Public Shared Property _pOwnerLName() As String
        Get
            Return _mOwnerLName
        End Get
        Set(value As String)
            _mOwnerLName = value
        End Set
    End Property

    Public Shared Property _pOwnerMName() As String
        Get
            Return _mOwnerMName
        End Get
        Set(value As String)
            _mOwnerMName = value
        End Set
    End Property

    Public Shared Property _pOwnerSuffix() As String
        Get
            Return _mOwnerSuffix
        End Get
        Set(value As String)
            _mOwnerSuffix = value
        End Set
    End Property

    Public Shared Property _pOwnerGender() As String
        Get
            Return _mOwnerGender
        End Get
        Set(value As String)
            _mOwnerGender = value
        End Set
    End Property

    Public Shared Property _pOwnerCitizenship() As String
        Get
            Return _mOwnerCitizenship
        End Get
        Set(value As String)
            _mOwnerCitizenship = value
        End Set
    End Property

    Public Shared Property _pOwnerCheck() As Boolean
        Get
            Return _mOwnerCheck
        End Get
        Set(value As Boolean)
            _mOwnerCheck = value
        End Set
    End Property

    Public Shared Property _pOwnerAddress() As String
        Get
            Return _mOwnerAddress
        End Get
        Set(value As String)
            _mOwnerAddress = value
        End Set
    End Property

    Public Shared Property _pOwnerTelNo() As String
        Get
            Return _mOwnerTelNo
        End Get
        Set(value As String)
            _mOwnerTelNo = value
        End Set
    End Property

    Public Shared Property _pOwnerEmail() As String
        Get
            Return _mOwnerEmail
        End Get
        Set(value As String)
            _mOwnerEmail = value
        End Set
    End Property

    Public Shared Property _pOwnerAltEmail() As String
        Get
            Return _mOwnerAltEmail
        End Get
        Set(value As String)
            _mOwnerAltEmail = value
        End Set
    End Property

#End Region

#Region "Slide_09"
    Public Shared Property _pIncLName() As String
        Get
            Return _mIncLName
        End Get
        Set(value As String)
            _mIncLName = value
        End Set
    End Property

    Public Shared Property _pIncMName() As String
        Get
            Return _mIncMName
        End Get
        Set(value As String)
            _mIncMName = value
        End Set
    End Property

    Public Shared Property _pIncFName() As String
        Get
            Return _mIncFName
        End Get
        Set(value As String)
            _mIncFName = value
        End Set
    End Property

    Public Shared Property _pIncAddress() As String
        Get
            Return _mIncAddress
        End Get
        Set(value As String)
            _mIncAddress = value
        End Set
    End Property
#End Region

#Region "Slide_10"
    Public Shared Property _pIncAddTName() As String
        Get
            Return _mIncAddTName
        End Get
        Set(value As String)
            _mIncAddTName = value
        End Set
    End Property
    Public Shared Property _pIncAddRName() As String
        Get
            Return _mIncAddRName
        End Get
        Set(value As String)
            _mIncAddRName = value
        End Set
    End Property

    Public Shared Property _pIncAddPosition() As String
        Get
            Return _mIncAddPosition
        End Get
        Set(value As String)
            _mIncAddPosition = value
        End Set
    End Property
#End Region

End Class
