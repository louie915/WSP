Imports System.Data.SqlClient

Public Class cLoader_NewProperty
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String


#End Region

#Region "Property Object"
    Public Shared ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public Shared Property _pSqlCon() As SqlConnection
        Get
            Try
                Return _mSqlCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
#End Region

#Region "Variable Field"
    Private Shared _mTDN As String
    Private Shared _mPIN As String
    Private Shared _mCCN As String
    Private Shared _mOwnerName As String
    Private Shared _mOwnerAddress As String
    Private Shared _mAdministrator As String
    Private Shared _mAdministratorAddress As String
    Private Shared _mLocProperty As String
    Private Shared _mBrgy As String
    Private Shared _mDistrict As String
    Private Shared _mOCT As String
    Private Shared _mSurveyNo As String
    Private Shared _mLotNo As String
    Private Shared _mBlkNo As String
    Private Shared _mNorth As String
    Private Shared _mSouth As String
    Private Shared _mEast As String
    Private Shared _mWest As String
    Private Shared _mArea As String
    Private Shared _mAmountSold As String
    Private Shared _mResidential As String
    Private Shared _mCommercial As String
    Private Shared _mDofSName As String
    Private Shared _mDofSType As String
    Private Shared _mDofSData As Byte()
    Private Shared _mCofTName As String
    Private Shared _mCofTType As String
    Private Shared _mCofTData As Byte()
    Private Shared _mPofPName As String
    Private Shared _mPofPType As String
    Private Shared _mPofPData As Byte()
    Private Shared _mTCName As String
    Private Shared _mTCType As String
    Private Shared _mTCData As Byte()
    Private Shared _mDCName As String
    Private Shared _mDCType As String
    Private Shared _mDCData As Byte()
    Private Shared _mCPName As String
    Private Shared _mCPType As String
    Private Shared _mCPData As Byte()
    Private Shared _mVIdName As String
    Private Shared _mVIdType As String
    Private Shared _mVIdData As Byte()
    Private Shared _mPropNewID As String
    Private _mEmail As String
#End Region
#Region "Property Field"
    Public Shared Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(value As String)
            _mTDN = value
        End Set
    End Property

    Public Shared Property _pPIN() As String
        Get
            Return _mPIN
        End Get
        Set(value As String)
            _mPIN = value
        End Set
    End Property

    Public Shared Property _pCCN() As String
        Get
            Return _mCCN
        End Get
        Set(value As String)
            _mCCN = value
        End Set
    End Property

    Public Shared Property _pOwnerName() As String
        Get
            Return _mOwnerName
        End Get
        Set(value As String)
            _mOwnerName = value
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

    Public Shared Property _pAdministrator() As String
        Get
            Return _mAdministrator
        End Get
        Set(value As String)
            _mAdministrator = value
        End Set
    End Property

    Public Shared Property _pAdministratorAddress() As String
        Get
            Return _mAdministratorAddress
        End Get
        Set(value As String)
            _mAdministratorAddress = value
        End Set
    End Property

    Public Shared Property _pLocProperty() As String
        Get
            Return _mLocProperty
        End Get
        Set(value As String)
            _mLocProperty = value
        End Set
    End Property

    Public Shared Property _pBrgy() As String
        Get
            Return _mBrgy
        End Get
        Set(value As String)
            _mBrgy = value
        End Set
    End Property

    Public Shared Property _pDistrict() As String
        Get
            Return _mDistrict
        End Get
        Set(value As String)
            _mDistrict = value
        End Set
    End Property

    Public Shared Property _pOCT() As String
        Get
            Return _mOCT
        End Get
        Set(value As String)
            _mOCT = value
        End Set
    End Property

    Public Shared Property _pSurveyNo() As String
        Get
            Return _mSurveyNo
        End Get
        Set(value As String)
            _mSurveyNo = value
        End Set
    End Property

    Public Shared Property _pLotNo() As String
        Get
            Return _mLotNo
        End Get
        Set(value As String)
            _mLotNo = value
        End Set
    End Property

    Public Shared Property _pBlkNo() As String
        Get
            Return _mBlkNo
        End Get
        Set(value As String)
            _mBlkNo = value
        End Set
    End Property

    Public Shared Property _pNorth() As String
        Get
            Return _mNorth
        End Get
        Set(value As String)
            _mNorth = value
        End Set
    End Property

    Public Shared Property _pSouth() As String
        Get
            Return _mSouth
        End Get
        Set(value As String)
            _mSouth = value
        End Set
    End Property

    Public Shared Property _pEast() As String
        Get
            Return _mEast
        End Get
        Set(value As String)
            _mEast = value
        End Set
    End Property

    Public Shared Property _pWest() As String
        Get
            Return _mWest
        End Get
        Set(value As String)
            _mWest = value
        End Set
    End Property

    Public Shared Property _pArea() As String
        Get
            Return _mArea
        End Get
        Set(value As String)
            _mArea = value
        End Set
    End Property

    Public Shared Property _pAmountSold() As String
        Get
            Return _mAmountSold
        End Get
        Set(value As String)
            _mAmountSold = value
        End Set
    End Property

    Public Shared Property _pResidential() As String
        Get
            Return _mResidential
        End Get
        Set(value As String)
            _mResidential = value
        End Set
    End Property

    Public Shared Property _pCommercial() As String
        Get
            Return _mCommercial
        End Get
        Set(value As String)
            _mCommercial = value
        End Set
    End Property

    Public Shared Property _pDofSName() As String
        Get
            Return _mDofSName
        End Get
        Set(value As String)
            _mDofSName = value
        End Set
    End Property

    Public Shared Property _pDofSType() As String
        Get
            Return _mDofSType
        End Get
        Set(value As String)
            _mDofSType = value
        End Set
    End Property

    Public Shared Property _pDofSData() As Byte()
        Get
            Return _mDofSData
        End Get
        Set(value As Byte())
            _mDofSData = value
        End Set
    End Property
    Public Shared Property _pCofTName() As String
        Get
            Return _mCofTName
        End Get
        Set(value As String)
            _mCofTName = value
        End Set
    End Property
    Public Shared Property _pCofType() As String
        Get
            Return _mCofTType
        End Get
        Set(value As String)
            _mCofTType = value
        End Set
    End Property
    Public Shared Property _pCofData() As Byte()
        Get
            Return _mCofTData
        End Get
        Set(value As Byte())
            _mCofTData = value
        End Set
    End Property

    Public Shared Property _pPofPName() As String
        Get
            Return _mPofPName
        End Get
        Set(value As String)
            _mPofPName = value
        End Set
    End Property

    Public Shared Property _pPofPType() As String
        Get
            Return _mPofPType
        End Get
        Set(value As String)
            _mPofPType = value
        End Set
    End Property

    Public Shared Property _pPofPData() As Byte()
        Get
            Return _mPofPData
        End Get
        Set(value As Byte())
            _mPofPData = value
        End Set
    End Property
    Public Shared Property _pTCName() As String
        Get
            Return _mTCName
        End Get
        Set(value As String)
            _mTCName = value
        End Set
    End Property
    Public Shared Property _pTCType() As String
        Get
            Return _mTCType
        End Get
        Set(value As String)
            _mTCType = value
        End Set
    End Property
    Public Shared Property _pTCData() As Byte()
        Get
            Return _mTCData
        End Get
        Set(value As Byte())
            _mTCData = value
        End Set
    End Property
    Public Shared Property _pDCName() As String
        Get
            Return _mDCName
        End Get
        Set(value As String)
            _mDCName = value
        End Set
    End Property
    Public Shared Property _pDCType() As String
        Get
            Return _mDCType
        End Get
        Set(value As String)
            _mDCType = value
        End Set
    End Property
    Public Shared Property _pDCData() As Byte()
        Get
            Return _mDCData
        End Get
        Set(value As Byte())
            _mDCData = value
        End Set
    End Property
    Public Shared Property _pCPName() As String
        Get
            Return _mCPName
        End Get
        Set(value As String)
            _mCPName = value
        End Set
    End Property
    Public Shared Property _pCPType() As String
        Get
            Return _mCPType
        End Get
        Set(value As String)
            _mCPType = value
        End Set
    End Property
    Public Shared Property _pCPData() As Byte()
        Get
            Return _mCPData
        End Get
        Set(value As Byte())
            _mCPData = value
        End Set
    End Property
    Public Shared Property _pVIdName() As String
        Get
            Return _mVIdName
        End Get
        Set(value As String)
            _mVIdName = value
        End Set
    End Property
    Public Shared Property _pVIdType() As String
        Get
            Return _mVIdType
        End Get
        Set(value As String)
            _mVIdType = value
        End Set
    End Property
    Public Shared Property _pVIdData() As Byte()
        Get
            Return _mVIdData
        End Get
        Set(value As Byte())
            _mVIdData = value
        End Set
    End Property
    Public Property _pEmail() As String
        Get
            Return _mEmail
        End Get
        Set(ByVal value As String)
            _mEmail = value
        End Set
    End Property
#End Region
#Region "Routines"    
#End Region
End Class
