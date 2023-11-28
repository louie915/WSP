Imports System.Data.SqlClient

Public Class cDalCertificationAss

#Region "Variables Data"
    Private Shared _mSqlCon As SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mSqlQuery As String = Nothing
    Private Shared _mSqlDataReader As SqlDataReader
#End Region

#Region "Variables Field"
    Private Shared _mEmail As String
    Private Shared _mTDN As String
    Private Shared _mCertType As String
    Private Shared _mNoOfCopies As Integer
    Private Shared _mAmount As String
    Private Shared _mDelFee As String
    Private Shared _mStatus As String
    Private Shared _mBIN As String
    Private Shared _mFullname As String
    Private Shared _mGender As String
    Private Shared _mContactNo As String
    Private Shared _mAddress As String
    Private Shared _mOwner As String
    Private Shared _mRefNo As String
    Private Shared _mUniqueID As String
    Private Shared id As String
#End Region

#Region "Properties Data"
    Public Shared Property _pSqlCon As SqlConnection
        Get
            Return _mSqlCon
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property

    Public Shared Property _pSqlCmd As SqlCommand
        Get
            Return _mSqlCmd
        End Get
        Set(value As SqlCommand)
            _mSqlCmd = value
        End Set
    End Property

    Public Shared Property _pSqlQuery As String
        Get
            Return _mSqlQuery
        End Get
        Set(value As String)
            _mSqlQuery = value
        End Set
    End Property

    Public Shared Property _pSqlDataReader As SqlDataReader
        Get
            Return _mSqlDataReader
        End Get
        Set(value As SqlDataReader)
            _mSqlDataReader = value
        End Set
    End Property
#End Region

#Region "Properties Field"
    Public Shared Property _pEmail As String
        Get
            Return _mEmail
        End Get
        Set(value As String)
            _mEmail = value
        End Set
    End Property

    Public Shared Property _pTDN As String
        Get
            Return _mTDN
        End Get
        Set(value As String)
            _mTDN = value
        End Set
    End Property

    Public Shared Property _pBIN As String
        Get
            Return _mBIN
        End Get
        Set(value As String)
            _mBIN = value
        End Set
    End Property

    Public Shared Property _pCertType As String
        Get
            Return _mCertType
        End Get
        Set(value As String)
            _mCertType = value
        End Set
    End Property

    Public Shared Property _pNoOfCopies As Integer
        Get
            Return _mNoOfCopies
        End Get
        Set(value As Integer)
            _mNoOfCopies = value
        End Set
    End Property

    Public Shared Property _pAmount As String
        Get
            Return _mAmount
        End Get
        Set(value As String)
            _mAmount = value
        End Set
    End Property

    Public Shared Property _pDelFee As String
        Get
            Return _mDelFee
        End Get
        Set(value As String)
            _mDelFee = value
        End Set
    End Property

    Public Shared Property _pStatus As String
        Get
            Return _mStatus
        End Get
        Set(value As String)
            _mStatus = value
        End Set
    End Property

    Public Shared Property _pFullname As String
        Get
            Return _mFullname
        End Get
        Set(value As String)
            _mFullname = value
        End Set
    End Property

    Public Shared Property _pGender As String
        Get
            Return _mGender
        End Get
        Set(value As String)
            _mGender = value
        End Set
    End Property

    Public Shared Property _pContactNo As String
        Get
            Return _mContactNo
        End Get
        Set(value As String)
            _mContactNo = value
        End Set
    End Property

    Public Shared Property _pAddress As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
        End Set
    End Property

    Public Shared Property _pOwner As String
        Get
            Return _mOwner
        End Get
        Set(value As String)
            _mOwner = value
        End Set
    End Property

    Public Shared Property _pUnique As String
        Get
            Return _mUniqueID
        End Get
        Set(value As String)
            _mUniqueID = value
        End Set
    End Property

    Public Shared Property _pRefNo As String
        Get
            Return _mRefNo
        End Get
        Set(value As String)
            _mRefNo = value
        End Set
    End Property
#End Region

#Region "Routine"
    Public Shared Sub saveRPTCertRequest()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = "INSERT INTO RPT_CERT" & _
                " (EMAIL, TDN, CERTTYPE, COPIES, AMOUNT, DELFEE, STATUS, TRANSDATE, OWNER, REFNO)" & _
                " VALUES" & _
                " ('" & _pEmail & "','" & _pTDN & "','" & _pCertType & "','" & _pNoOfCopies & "','" & _pAmount & "','" & _pDelFee & "','" & _pStatus & "','" & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "','" & _pOwner & "','" & _pRefNo & "')"

            _pSqlQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub saveBPCertRequest()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = "INSERT INTO BP_CERT" & _
                " (EMAIL, BIN, CERTTYPE, COPIES, AMOUNT, DELFEE, TRANSDATE, STATUS, OWNER, REFNO)" & _
                " VALUES" & _
                " ('" & _pEmail & "','" & _pBIN & "','" & _pCertType & "','" & _pNoOfCopies & "','" & _pAmount & "','" & _pDelFee & "','" & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "','" & _pStatus & "','" & _pOwner & "','" & _pRefNo & "')"

            _pSqlQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub saveCertRequestNoRPBP(ByVal swtch As String)
        Try
            Dim _nQuery As String = Nothing

            If swtch = "RPT" Then
                _nQuery = "INSERT INTO RPT_CERT" & _
                    " (FULLNAME, EMAIL, GENDER, CONTACTNO, ADDRESS, COPIES, AMOUNT, DELFEE, TDN, CERTTYPE, TRANSDATE, STATUS, REFNO)" & _
                    " VALUES" & _
                    " ('" & _pFullname & "','" & _pEmail & "','" & _pGender & "','" & _pContactNo & "','" & _pAddress & "','" & _pNoOfCopies & "','" & _pAmount & "','" & _pDelFee & "','" & _pTDN & "','" & _pCertType & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & _pStatus & "','" & _pRefNo & "')"
            ElseIf swtch = "BP" Then
                _nQuery = "INSERT INTO BP_CERT" & _
                    " (FULLNAME, EMAIL, GENDER, CONTACTNO, ADDRESS, COPIES, AMOUNT, DELFEE, BIN, CERTTYPE, TRANSDATE, STATUS, REFNO)" & _
                    " VALUES" & _
                    " ('" & _pFullname & "','" & _pEmail & "','" & _pGender & "','" & _pContactNo & "','" & _pAddress & "','" & _pNoOfCopies & "','" & _pAmount & "','" & _pDelFee & "','" & _pBIN & "','" & _pCertType & "','" & Format(Date.Now, "yyyy-MM-dd") & "','" & _pStatus & "','" & _pRefNo & "')"
            End If

            _pSqlQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub updateRecordNoBPRPT(ByVal swtch As String)
        Try
            Dim _nQuery As String = Nothing
            Dim last As Integer = getLastCertID(swtch)

            If swtch = "RPT" Then
                _nQuery = "UPDATE RPT_CERT" & _
                    " SET REFNO = '" & _pRefNo & "'," & _
                    " STATUS = '" & _pStatus & "'" & _
                    " WHERE CERTID = " & last
            ElseIf swtch = "BP" Then
                _nQuery = "UPDATE BP_CERT" & _
                    " SET REFNO = '" & _pRefNo & "'," & _
                    " STATUS = '" & _pStatus & "'" & _
                    " WHERE CERTID = " & last
            End If

            _pSqlQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub updateNoBPRPTCertificate(ByVal swtch As String)
        Try
            Dim _nQuery As String = Nothing
            Dim last As Integer = getLastCertID(swtch)

            If swtch = "RPT" Then
                _nQuery = "UPDATE RPT_CERT SET TDN = 'NORPT" & last & "' WHERE CERTID = " & last
                id = "NORPT" & last
            ElseIf swtch = "BP" Then
                _nQuery = "UPDATE BP_CERT SET BIN = 'NOBP" & last & "' WHERE CERTID = " & last
                id = "NOBP" & last
            End If

            _pUnique = id

            _pSqlQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function getBusinessOwner(ByVal acctNo As String) As String
        Dim res As String = Nothing

        Dim _nQuery = "SELECT OWNER FROM BUSDETAIL WHERE ACCTNO = '" & acctNo & "'"

        _pSqlQuery = _nQuery

        _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
        _mSqlDataReader = _mSqlCmd.ExecuteReader

        Do Until _mSqlDataReader.Read = False
            res = _mSqlDataReader("OWNER")
        Loop

        _mSqlDataReader.Close()
        _mSqlCmd.Dispose()


        Return res
    End Function

    Private Shared Function getLastCertID(ByVal swtch As String) As Integer
        Dim res As Integer = Nothing

        Dim _nQuery As String = Nothing

        If swtch = "RPT" Then
            _nQuery = "SELECT MAX(CERTID) AS LASTID FROM RPT_CERT"
        ElseIf swtch = "BP" Then
            _nQuery = "SELECT MAX(CERTID) AS LASTID FROM BP_CERT"
        End If

        _pSqlQuery = _nQuery

        _mSqlCmd = New SqlCommand(_pSqlQuery, _mSqlCon)
        _mSqlDataReader = _mSqlCmd.ExecuteReader

        Do Until _mSqlDataReader.Read = False
            res = _mSqlDataReader("LASTID")
        Loop

        _mSqlDataReader.Close()
        _mSqlCmd.Dispose()

        Return res
    End Function

#End Region

End Class
