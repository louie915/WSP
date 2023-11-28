Imports System.Data.SqlClient
Imports VB.NET.Methods

Public Class cDalAIF
#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mStrCon As String

    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Private Shared _mQuery As String = Nothing

#End Region

#Region "Properties Data"

    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property

    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Property _pSqlCon() As SqlConnection
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

    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                '_mSqlDataReader = Nothing
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                ' _mSqlCommand.Dispose()
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Variables Field"

    Private _mLocked As String
    Private _mFNAME As String

#End Region

#Region "Properties Field"

    Public Property _pLocked() As Boolean
        Get
            Return _mLocked
        End Get
        Set(ByVal value As Boolean)
            _mLocked = value
        End Set
    End Property

    Public Property _pFNAME() As String
        Get
            Return _mFNAME
        End Get
        Set(ByVal value As String)
            _mFNAME = value
        End Set
    End Property

#End Region


#Region "Routine Command"

    Public Sub _pSubUpdate(ByVal _nAcctno As String, _
                          ByVal _nForyear As String, _
                           ByVal _nZone As String, _
                           ByVal _nPNP As String, _
                           ByVal _nRTC As String, _
                           ByVal _nFISCAL As String, _
                           ByVal _nMEDICAL As String, _
                           ByVal _nWMEASURES As String, _
                           ByVal _nSTICKER As String, _
                           ByVal _nBUILDING As String, _
                           ByVal _nMECHANICAL As String, _
                           ByVal _nPLUMBING As String, _
                           ByVal _nELECTRICAL As String, _
                           ByVal _nSIGNBILL As String, _
                           ByVal _nFIRECODE As String, _
                           ByVal _nOTHER As String, _
                           ByVal _nRF1 As String, _
                           ByVal _nRF2 As String, _
                           ByVal _nRF3 As String, _
                           ByVal _nRF4 As String, _
                           ByVal _nRF5 As String, _
                           ByVal _nRF6 As String, _
                           ByVal _nRF7 As String, _
                           ByVal _nRF8 As String, _
                           ByVal _nRF9 As String, _
                           ByVal _nRF10 As String, _
                           ByVal _nRF11 As String, _
                           ByVal _nRF12 As String, _
                           ByVal _nRF13 As String, _
                           ByVal _nRF14 As String, _
                           ByVal _nRF15 As String, _
                           ByVal _nRF16 As String _
                           )
        Try
            _mQuery = " Update BUSEXTN SET " & _
                        "ZONE =  '" & _nZone & "'" & _
                        ",PNP =  '" & _nPNP & "'" & _
                        ",RTC =  '" & _nRTC & "'" & _
                        ",FISCAL =  '" & _nFISCAL & "'" & _
                        ",MEDICAL =  '" & _nMEDICAL & "'" & _
                        ",WMEASURES =  '" & _nWMEASURES & "'" & _
                        ",STICKER =  '" & _nSTICKER & "'" & _
                        ",BUILDING =  '" & _nBUILDING & "'" & _
                        ",MECHANICAL =  '" & _nMECHANICAL & "'" & _
                        ",PLUMBING =  '" & _nPLUMBING & "'" & _
                        ",ELECTRICAL =  '" & _nELECTRICAL & "'" & _
                        ",SIGNBILL =  '" & _nSIGNBILL & "'" & _
                        ",FIRECODE =  '" & _nFIRECODE & "'" & _
                        ",OTHER =  '" & _nOTHER & "'" & _
                        ",RF1 =  '" & _nRF1 & "'" & _
                        ",RF2 =  '" & _nRF2 & "'" & _
                        ",RF3 =  '" & _nRF3 & "'" & _
                        ",RF4 =  '" & _nRF4 & "'" & _
                        ",RF5 =  '" & _nRF5 & "'" & _
                        ",RF6 =  '" & _nRF6 & "'" & _
                        ",RF7 =  '" & _nRF7 & "'" & _
                        ",RF8 =  '" & _nRF8 & "'" & _
                        ",RF9 =  '" & _nRF9 & "'" & _
                        ",RF10 =  '" & _nRF10 & "'" & _
                        ",RF11 =  '" & _nRF11 & "'" & _
                        ",RF12 =  '" & _nRF12 & "'" & _
                        ",RF13 =  '" & _nRF13 & "'" & _
                        ",RF14 =  '" & _nRF14 & "'" & _
                        ",RF15 =  '" & _nRF15 & "'" & _
                        ",RF16 =  '" & _nRF16 & "'" & _
                       " WHERE ACCTNO = '" & _nAcctno & "' AND FORYEAR = YEAR(GETDATE()) "

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _nSqlDataAdapter.SelectCommand.ExecuteNonQuery()

            _nSqlDataAdapter.Dispose()

        Catch ex As Exception

        End Try
    End Sub

   

#End Region


End Class
