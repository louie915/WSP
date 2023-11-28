#Region "Imports"

Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region

Public Class cSessionLGUProfile

#Region "Variable Object"
    Private Shared _mSqlConCR As New SqlConnection
#End Region

#Region "Property Object"
    Public Shared Property _pSqlConCR() As SqlConnection
        Get
            Try
                Return _mSqlConCR
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlConCR = value
        End Set
    End Property
#End Region

    Private Const _sscPrefix As String = "cSessionLGUProfile."

    Private Const _sscLGU_Name As String = _sscPrefix & "_sscLGU_Name"
    Private Const _sscLGU_Address As String = _sscPrefix & "_sscLGU_Address"
    Private Const _sscLGU_Header1 As String = _sscPrefix & "_sscLGU_Header1"
    Private Const _sscLGU_Header2 As String = _sscPrefix & "_sscLGU_Header2"
    Private Const _sscLGU_Header3 As String = _sscPrefix & "_sscLGU_Header3"

    Private Const _sscLGU_TelNo As String = _sscPrefix & "_sscLGU_TelNo"
    Private Const _sscLGU_Website As String = _sscPrefix & "_sscLGU_Website"
    Private Const _sscLGU_EmailAddress As String = _sscPrefix & "_sscLGU_EmailAddress"
    Private Const _sscErrMsg As String = _sscPrefix & "_sscErrMsg"

    Shared Property _pLGU_Name() As String
        Get
            Return Current.Session(_sscLGU_Name)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Name) = value
        End Set
    End Property

    Shared Property _pLGU_Address() As String
        Get
            Return Current.Session(_sscLGU_Address)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Address) = value
        End Set
    End Property

    Shared Property _pLGU_Header1() As String
        Get
            Return Current.Session(_sscLGU_Header1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Header1) = value
        End Set
    End Property

    Shared Property _pLGU_Header2() As String
        Get
            Return Current.Session(_sscLGU_Header2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Header2) = value
        End Set
    End Property

    Shared Property _pLGU_Header3() As String
        Get
            Return Current.Session(_sscLGU_Header3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Header3) = value
        End Set
    End Property

    Shared Property _pLGU_TelNo() As String
        Get
            Return Current.Session(_sscLGU_TelNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_TelNo) = value
        End Set
    End Property

    Shared Property _pLGU_Website() As String
        Get
            Return Current.Session(_sscLGU_Website)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Website) = value
        End Set
    End Property

    Shared Property _pLGU_EmailAddress() As String
        Get
            Return Current.Session(_sscLGU_EmailAddress)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_EmailAddress) = value
        End Set
    End Property

    Shared Property _pErrMsg() As String
        Get
            Return Current.Session(_sscErrMsg)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscErrMsg) = value
        End Set
    End Property

    Public Shared Sub _pGetLGUProfile(ByRef ctr As String)
        Try
            ctr = 1
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            ctr = 2
            Dim _nDal As New cDal_IUD
            ctr = 3
            With _nDal
                ctr = 4
                ._pSqlCon = cGlobalConnections._pSqlCxn_CR
                ctr = 5
                ._pAction = "SELECT"
                ctr = 6
                ._pSelect = "Select * FROM LGU_Profile "
                ctr = 7
                ._pExec(_nSuccess, _nErrMsg)
                ctr = 8
                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _pLGU_Name = _nDataTable.Rows("0").Item("LGU_NAME").ToString
                    _pLGU_Address = _nDataTable.Rows("0").Item("LGU_ADDRESS").ToString
                    _pLGU_Header1 = _nDataTable.Rows("0").Item("Rpt_Header1").ToString
                    _pLGU_Header2 = _nDataTable.Rows("0").Item("Rpt_Header2").ToString
                    _pLGU_Header3 = _nDataTable.Rows("0").Item("Rpt_Header3").ToString
                    _pLGU_TelNo = _nDataTable.Rows("0").Item("LGU_TelNo").ToString
                    _pLGU_EmailAddress = _nDataTable.Rows("0").Item("LGU_Email").ToString
                    _pLGU_Website = _nDataTable.Rows("0").Item("LGU_Website").ToString
                End If

            End With
        Catch ex As Exception
            ctr = ex.Message
            '    cDalLogEvent._pSubLogError(ex)
        End Try




    End Sub
End Class
