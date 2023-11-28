Imports System.Data.SqlClient
Public Class cDalVerifications

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mQuery As String
    Private _mSqlDataReader As SqlDataReader
    Private _mDataTable As DataTable
    Private _mDataAdapter As SqlDataAdapter
    Private _mDataTable1 As DataTable
    Private _mDataTable2 As DataTable
    Private _mDataTable3 As DataTable
    Private _mDataAdapter1 As SqlDataAdapter
    Private _mDataAdapter2 As SqlDataAdapter


    Public Shared _mSubQuery As String
    Public Shared _mRecordCount As Integer
#End Region

#Region "Variables Field"
    Private _mUserEmail As String
    Private _mAccountNo As String
    Private _mOrNo As String
    Private _mVerifiedBy As String
    Private _mVerifiedDate As String
    Private _mRemarks As String
    Private _mUserFullname As String
    Private _mErr As Boolean = False
    Private _mLocalDb As String
    Private _mLocalServer As String
    Private _mLocalDb1 As String
    Private _mLocalServer1 As String
    Private Shared _mGIdName As String
    Private Shared _mGIdType As String
    Private Shared _mGIdData As Byte()
    Private Shared _mSPAName As String
    Private Shared _mSPAType As String
    Private Shared _mSPAData As Byte()
    Private Shared _mBRSecName As String
    Private Shared _mBRSecType As String
    Private Shared _mBRSecData As Byte()
    Private Shared _mCheckGId As Boolean = False
    Private Shared _mCheckSPA As Boolean = False
    Private Shared _mCheckBRSec As Boolean = False
#End Region

#Region "Properties Field"

    Public Property _pLocalDb As String
        Get
            Return _mLocalDb
        End Get
        Set(value As String)
            _mLocalDb = value
        End Set
    End Property

    Public Property _pLocalServer As String
        Get
            Return _mLocalServer
        End Get
        Set(value As String)
            _mLocalServer = value
        End Set
    End Property

    Public Property _pLocalDb1 As String
        Get
            Return _mLocalDb1
        End Get
        Set(value As String)
            _mLocalDb1 = value
        End Set
    End Property

    Public Property _pLocalServer1 As String
        Get
            Return _mLocalServer1
        End Get
        Set(value As String)
            _mLocalServer1 = value
        End Set
    End Property

    Public Property _pUserEmail As String
        Get
            Return _mUserEmail
        End Get
        Set(value As String)
            _mUserEmail = value
        End Set
    End Property

    Public Property _pAccountNo As String
        Get
            Return _mAccountNo
        End Get
        Set(value As String)
            _mAccountNo = value
        End Set
    End Property

    Public Property _pOrNo As String
        Get
            Return _mOrNo
        End Get
        Set(value As String)
            _mOrNo = value
        End Set
    End Property

    Public Property _pVerifiedBy As String
        Get
            Return _mVerifiedBy
        End Get
        Set(value As String)
            _mVerifiedBy = value
        End Set
    End Property

    Public ReadOnly Property _pVerifiedDate As String
        Get
            Return "GETDATE()"
        End Get
    End Property

    Public Property _pRemarks As String
        Get
            Return _mRemarks
        End Get
        Set(value As String)
            _mRemarks = value
        End Set
    End Property

    Public ReadOnly Property _pUserFullname As String
        Get
            Return cSessionUser._pUserID
        End Get
    End Property

    Public Property _pErr As Boolean
        Get
            Return _mErr
        End Get
        Set(value As Boolean)
            _mErr = value
        End Set
    End Property

    Public Shared Property _pGIdName() As String
        Get
            Return _mGIdName
        End Get
        Set(value As String)
            _mGIdName = value
        End Set
    End Property

    Public Shared Property _pGIdType() As String
        Get
            Return _mGIdType
        End Get
        Set(value As String)
            _mGIdType = value
        End Set
    End Property

    Public Shared Property _pGIdData() As Byte()
        Get
            Return _mGIdData
        End Get
        Set(value As Byte())
            _mGIdData = value
        End Set
    End Property

    Public Shared Property _pSPAName() As String
        Get
            Return _mSPAName
        End Get
        Set(value As String)
            _mSPAName = value
        End Set
    End Property

    Public Shared Property _pSPAType() As String
        Get
            Return _mSPAType
        End Get
        Set(value As String)
            _mSPAType = value
        End Set
    End Property

    Public Shared Property _pSPAData() As Byte()
        Get
            Return _mSPAData
        End Get
        Set(value As Byte())
            _mSPAData = value
        End Set
    End Property

    Public Shared Property _pCheckGId() As String
        Get
            Return _mCheckGId
        End Get
        Set(value As String)
            _mCheckGId = value
        End Set
    End Property
    Public Shared Property _pCheckSPA() As String
        Get
            Return _mCheckSPA
        End Get
        Set(value As String)
            _mCheckSPA = value
        End Set
    End Property

    Public Shared Property _pBRSecName() As String
        Get
            Return _mBRSecName
        End Get
        Set(value As String)
            _mBRSecName = value
        End Set
    End Property

    Public Shared Property _pBRSecType() As String
        Get
            Return _mBRSecType
        End Get
        Set(value As String)
            _mBRSecType = value
        End Set
    End Property

    Public Shared Property _pBRSecData() As Byte()
        Get
            Return _mBRSecData
        End Get
        Set(value As Byte())
            _mBRSecData = value
        End Set
    End Property

    Public Shared Property _pCheckBRSec() As String
        Get
            Return _mCheckBRSec
        End Get
        Set(value As String)
            _mCheckBRSec = value
        End Set
    End Property
#End Region

#Region "Properties Data"
    Public Property _pSqlCon As SqlConnection
        Get
            Return _mSqlCon
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property

    Public Property _pSqlCmd As SqlCommand
        Get
            Return _mSqlCmd
        End Get
        Set(value As SqlCommand)
            _mSqlCmd = value
        End Set
    End Property

    Public Property _pQuery As String
        Get
            Return _mQuery
        End Get
        Set(value As String)
            _mQuery = value
        End Set
    End Property

    Public Property _pSqlDataReader As SqlDataReader
        Get
            Return _mSqlDataReader
        End Get
        Set(value As SqlDataReader)
            _mSqlDataReader = value
        End Set
    End Property

    Public Property _pDataTable As DataTable
        Get
            Return _mDataTable
        End Get
        Set(value As DataTable)
            _mDataTable = value
        End Set
    End Property

    Public Property _pDataTable1 As DataTable
        Get
            Return _mDataTable1
        End Get
        Set(value As DataTable)
            _mDataTable1 = value
        End Set
    End Property

    Public Property _pDataTable2 As DataTable
        Get
            Return _mDataTable2
        End Get
        Set(value As DataTable)
            _mDataTable2 = value
        End Set
    End Property

    Public Property _pDataTable3 As DataTable
        Get
            Return _mDataTable3
        End Get
        Set(value As DataTable)
            _mDataTable3 = value
        End Set
    End Property

    Public Property _pDataAdapter As SqlDataAdapter
        Get
            Return _mDataAdapter
        End Get
        Set(value As SqlDataAdapter)
            _mDataAdapter = value
        End Set
    End Property

    Public Property _pDataAdapter1 As SqlDataAdapter
        Get
            Return _mDataAdapter1
        End Get
        Set(value As SqlDataAdapter)
            _mDataAdapter1 = value
        End Set
    End Property

    Public Property _pDataAdapter2 As SqlDataAdapter
        Get
            Return _mDataAdapter2
        End Get
        Set(value As SqlDataAdapter)
            _mDataAdapter2 = value
        End Set
    End Property
#End Region


#Region "Routine"
    Public Sub _pLoadApplicationRecords()
        Try
            '_pQuery = "SELECT * FROM SOS_BP_20200703.dbo.BUSDETAIL b INNER JOIN SOS_OAIMS_20200703.dbo.Registered r ON b.EMAIL = REPLACE(r.UserID,'.','') WHERE b.Verified = '0' or b.Verified IS NULL ORDER BY REQDATE"

            _pQuery = "SELECT *, " & _
                " CASE WHEN GENDER = 'M' THEN 'Male' " & _
                " ELSE 'Female'" & _
                " END AS GENDERCOMPLETE, " & _
                " FORMAT(BIRTHDATE, 'MMM dd, yyyy') AS BIRTHDAY" & _
                " FROM " & _pLocalDb & ".dbo.BUSDETAIL b INNER JOIN " & _pLocalDb1 & ".dbo.Registered r ON b.EMAIL2 = r.UserID WHERE b.Verified = '0' or b.Verified IS NULL ORDER BY REQDATE"

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader
            _mSubQuery = _pQuery
            If _pSqlDataReader.HasRows Then
                _mDataAdapter1 = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable1 = New DataTable
                _mDataAdapter1.Fill(_mDataTable1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadApplicationRecordsAssessor()
        Try
            _pQuery = "SELECT *, " & _
                " CASE WHEN GENDER = 'M' THEN 'Male' " & _
                " ELSE 'Female'" & _
                " END AS GENDERCOMPLETE" & _
                " FROM " & _pLocalDb & ".dbo.RPTDETAIL b INNER JOIN " & _pLocalDb1 & ".dbo.Registered r ON b.EMAIL2 = r.UserID WHERE b.Verified = '0' or b.Verified IS NULL ORDER BY REQDATE"

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter1 = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable1 = New DataTable
                _mDataAdapter1.Fill(_mDataTable1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadVerificationHistoryRecords()
        Try
            _pQuery = "SELECT  VERIFIEDDATE, EMAIL2 as EMAIL, ACCTNO, OWNER, [STATUS], REMARKS, VERIFIEDBY FROM BUSDETAIL WHERE VERIFIED = '1' " & _
                " UNION" & _
                " SELECT  VERIFIEDDATE, EMAIL, ACCTNO, OWNER, [STATUS], REMARKS,VERIFIEDBY FROM BUSDETAIL_HISTORY " & _
                " ORDER BY VERIFIEDDATE DESC"

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable = New DataTable
                _mDataAdapter.Fill(_mDataTable)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadVerificationHistoryRecordsAssessor()
        Try
            _pQuery = "SELECT  VERIFIEDDATE, EMAIL2 as EMAIL, TDN, OWNERNAME, [STATUS], REMARKS, VerifiedBy FROM RPTDETAIL WHERE VERIFIED = '1'" & _
                " UNION" & _
                " SELECT  VERIFIEDDATE, EMAIL, TDN, OWNERNAME, [STATUS], REMARKS, VerifiedBy FROM RPTDETAIL_HISTORY" & _
                " ORDER BY VERIFIEDDATE DESC"

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable = New DataTable
                _mDataAdapter.Fill(_mDataTable)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadNewBusinessApplication()
        Try
            _pQuery = "SELECT  B.ACCTNO, B.cbp_transaction_no ,B.REMARKS,B.COMMNAME,B.APP_DATE, BM.FORYEAR ,EMAILADDR  " & _
                " ,CASE WHEN ISNULL(B.STATCODE,'N') = 'N' " & _
                " then '[NEW]' " & _
                " ELSE '[RENEWAL]' " & _
                " END  as STATCODE " & _
                "  FROM BUSMAST AS B " & _
                " INNER JOIN" & _
               " BUSMASTEXTN BM  " & _
                "  ON B.ACCTNO = BM.AcctNo " & _
                " where B.REMARKS = 'FOR REVIEW' " & _
                " AND isnull(BM.FORYEAR,'')= YEAR(GETDATE())  " & _
                " AND STATCODE  = 'N' " & _
                " ORDER BY B.APP_DATE ASC "

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter2 = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable2 = New DataTable
                _mDataAdapter2.Fill(_mDataTable2)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadNewBusinessApplicationHistory()
        Try
            _pQuery = "SELECT  B.ACCTNO,B.REMARKS,B.COMMNAME,B.APP_DATE, BM.FORYEAR ,EMAILADDR  " & _
                " ,CASE WHEN ISNULL(B.STATCODE,'N') = 'N' " & _
                " then '[NEW]' " & _
                " ELSE '[RENEWAL]' " & _
                " END  as STATCODE " & _
                "  FROM BUSMAST AS B " & _
                " INNER JOIN" & _
               " BUSMASTEXTN BM  " & _
                "  ON B.ACCTNO = BM.AcctNo " & _
                " where B.REMARKS = 'Reviewed/ For Assessment Billing' " & _
                " AND isnull(BM.FORYEAR,'')= YEAR(GETDATE())  " & _
                " AND STATCODE  = 'N' " & _
                " ORDER BY B.APP_DATE ASC "

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter2 = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable3 = New DataTable
                _mDataAdapter2.Fill(_mDataTable3)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pUpdateVerification(ByVal approve As Boolean, ByVal Approver As String)

        Try
            If approve Then
                _pQuery = "UPDATE BUSDETAIL SET Verified = '1', VERIFIEDBY = '" & Approver & "', VERIFIEDDATE = " & _pVerifiedDate & ", REMARKS = '" & _pRemarks & "', STATUS = 'Approved'" & _
                    " WHERE EMAIL2 = '" & _pUserEmail & "'" & _
                    " AND ACCTNO = '" & _pAccountNo & "'" & _
                    " AND ORNO = '" & _pOrNo & "'"

                _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
                _pSqlCmd.ExecuteNonQuery()

                _fNotifyTaxPayer("Business", _pAccountNo, "Approved", _pUserEmail)
                _pErr = True
            Else
                _pQuery = "INSERT INTO BUSDETAIL_HISTORY (EMAIL, ACCTNO, REQDATE, ORNO, [OWNER], BUSNAME, BUSADDRESS, CATEGORY, VERIFIED, VERIFIEDBY, VERIFIEDDATE, REMARKS, STATUS)" & _
                    "(SELECT EMAIL2, ACCTNO, REQDATE, ORNO, [OWNER], BUSNAME, BUSADDRESS, CATEGORY, VERIFIED, '" & Approver & "' AS VERIFIEDBY, " & _pVerifiedDate & " AS VERIFIEDDATE, '" & _pRemarks & "' AS REMARKS, 'Disapproved' AS STATUS FROM BUSDETAIL WHERE EMAIL2 = '" & _pUserEmail & "' AND ACCTNO = '" & _pAccountNo & "' AND ORNO = '" & _pOrNo & "')"

                _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
                _pSqlCmd.ExecuteNonQuery()

                _pQuery = "DELETE FROM BUSDETAIL WHERE EMAIL2 = '" & _pUserEmail & "' AND ACCTNO = '" & _pAccountNo & "' AND ORNO = '" & _pOrNo & "'"

                _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
                _pSqlCmd.ExecuteNonQuery()

                _fNotifyTaxPayer("Business", _pAccountNo, "Disapproved", _pUserEmail)
                _pErr = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pUpdateVerificationAssessor(ByVal approve As Boolean, ByVal Approver As String, Optional ByRef ERR As String = Nothing, Optional ByRef QRY As String = Nothing)

        Try
            If approve Then
                _pQuery = "UPDATE RPTDETAIL SET Verified = '1', VERIFIEDBY = '" & Approver & "', VERIFIEDDATE = " & _pVerifiedDate & ", REMARKS = '" & _pRemarks & "', STATUS = 'Approved'" & _
                    " WHERE EMAIL2 = '" & _pUserEmail & "'" & _
                    " AND TDN = '" & _pAccountNo & "'" & _
                    " AND ORNO = '" & _pOrNo & "'"
                QRY = _pQuery
                _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
                _pSqlCmd.ExecuteNonQuery()

                _fNotifyTaxPayer("Property", _pAccountNo, "Approved", _pUserEmail)
                _pErr = True
            Else
                _pQuery = "INSERT INTO RPTDETAIL_HISTORY (EMAIL, TDN, REQDATE, ORNO, PIN, OWNERNAME , LOCATION, VERIFIED, VERIFIEDBY, VERIFIEDDATE, REMARKS, STATUS)" & _
                    "(SELECT EMAIL2, TDN, REQDATE, ORNO, PIN, OWNERNAME, LOCATION, VERIFIED, '" & Approver & "' AS VERIFIEDBY, " & _pVerifiedDate & " AS VERIFIEDDATE, '" & _pRemarks & "' AS REMARKS, 'Disapproved' AS STATUS FROM RPTDETAIL WHERE EMAIL2 = '" & _pUserEmail & "' AND TDN = '" & _pAccountNo & "' AND ORNO = '" & _pOrNo & "')"
                QRY = _pQuery
                _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
                _pSqlCmd.ExecuteNonQuery()

                _pQuery = "DELETE FROM RPTDETAIL WHERE EMAIL2 = '" & _pUserEmail & "' AND TDN = '" & _pAccountNo & "' AND ORNO = '" & _pOrNo & "'"

                _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
                _pSqlCmd.ExecuteNonQuery()

                _fNotifyTaxPayer("Property", _pAccountNo, "Disapproved", _pUserEmail)
                _pErr = False
            End If

        Catch ex As Exception
            ERR = ex.Message
        End Try
    End Sub

    Public Sub _fNotifyTaxPayer(ByVal swtch As String, ByVal no As String, ByVal resultVerification As String, ByVal usermail As String)
        Dim Sent As Boolean
        Dim Subject As String
        Dim Body As String
        Dim remarks As String

        'Dim _nClass2 As New cDalVerifications
        'remarks = _nClass2._pRemarks
        remarks = _mRemarks

        Select Case swtch

            Case "Business"
                Dim _nClass3 As New cHardwareInformation
                Dim _nMachineName As String = _nClass3._pMachineName.ToUpper

                '      usermail = getEmail(usermail, "" & _pLocalDb & "..BUSDETAIL", "" & _pLocalDb1 & "..Registered")
                If resultVerification = "Approved" Then
                    Dim _nClass As New cDalSendEmail
                    Subject = "Business Account Verification"

                   
                    Select Case _nMachineName
                        Case "GRACEVILLE"
                            Body = "To our Valued Taxpayer, <br><br>" & _
                           "We are happy to inform you that your online enrollment application for Business Account No.: " & no & " has been verified and approved.<br>" & _
                           "You can now use our Web Service Portal for the following transactions:<br>" & _
                               "- Business Renewal <br>" & _
                               "- Appointment <br>" & _
                               "<br>" & _
                               "Remarks : " & remarks

                        Case "MRVLSWEBSVR"
                            Body = "To our Valued Taxpayer, <br><br>" & _
                           "We are happy to inform you that your online enrollment application for Business Account No.: " & no & " has been verified and approved.<br>" & _
                           "You can now use our Web Service Portal for the following transactions:<br>" & _
                               "- Business Renewal <br>" & _
                               "- Appointment <br>" & _
                               "<br>" & _
                               "Remarks : " & remarks & _
                               "<br><br>For Quarterly Renewal with existing curent year payment, you may now view or check your remaining Quarterly assessment or even pay online by clicking payment." & _
                               "<br>"

                        Case Else
                            Body = "To our Valued Taxpayer, <br><br>" & _
                           "We are happy to inform you that your online enrollment application for Business Account No.: " & no & " has been verified and approved. You can now use our Web Service Portal for the following transactions:<br>" & _
                               "- Business Renewal <br>" & _
                               "<br>" & _
                               "Remarks : " & remarks

                    End Select


                ElseIf resultVerification = "Disapproved" Then
                    If _nMachineName = "MRVLSWEBSVR" Then
                        Subject = "Business Account Verification"
                        Body = "To our Valued Taxpayer, <br><br>" & _
                               "We sincerely apologized that your enrollment application for Business Account No.: " & no & " was not authorized/disapproved due to the following reasons:<br>" & _
                                   "- " & remarks & "<br><br>" & _
                                   "Please comply the needed requirements in order to proceed with the enrollment procedure.<br>" & _
                                "<br>" 


                    Else
                        Subject = "Business Account Verification"
                        Body = "To our Valued Taxpayer, <br><br>" & _
                               "We sincerely apologized that your enrollment application for Business Account No.: " & no & " was not authorized/disapproved due to the following reasons:<br>" & _
                                   "- " & remarks & "<br><br>" & _
                                   "Please comply the needed requirements in order to proceed with the enrollment procedure.<br>" & _
                                "<br>"
                    End If


                  

                End If

            Case "Property"
                '     usermail = getEmail(usermail, "" & _pLocalDb & "..RPTDETAIL", "" & _pLocalDb1 & "..Registered")
                If resultVerification = "Approved" Then
                    Subject = "Real Property Account Verification"

                    Body = "To our Valued Taxpayer, <br><br>" & _
                           "We are happy to inform you that your online enrollment application for TDN: " & no & " has been verified and approved. You can now use our Web Service Portal for the following transactions:<br>" & _
                               "- Real Property Payment <br>" & _
                               "<br>"

                ElseIf resultVerification = "Disapproved" Then
                    Subject = "Real Property Account Verification"
                    Body = "To our Valued Taxpayer, <br><br>" & _
                          "We sincerely apologized that your enrollment application for TDN: " & no & " was not authorized/disapproved due to the following reasons:<br>" & _
                              "- " & remarks & "<br><br>" & _
                              "Please comply the needed requirements in order to proceed with the enrollment procedure.<br>" & _
                           "<br>" 

                End If
        End Select


        cDalNewSendEmail.SendEmail(usermail, Subject, Body, Sent)
    End Sub

    Public Function getEmail(ByVal userEmail As String, table As String, oaims As String) As String
        Try
            _pQuery = "SELECT USERID FROM " & oaims & " r INNER JOIN " & table & " b ON REPLACE(r.USERID,'.','') = b.EMAIL WHERE b.EMAIL = '" & userEmail & "'"

            _pSqlCon = cGlobalConnections._pSqlCxn_OAIMS

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                Do Until _pSqlDataReader.Read = False
                    getEmail = _pSqlDataReader("USERID")
                Loop
            End If

            Return getEmail
        Catch ex As Exception

        End Try
    End Function

    Public Sub _pSubSelect(_nTable As String, _nCondition As String)

        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = _nCondition

            _nQuery = _
                             "SELECT " & _
               " * " & _
               "FROM " & _nTable & _
               " "
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCmd.Parameters
                '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
                '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))
            End With
            _mSqlCmd.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadApplicationRecordsSearch(SearchKey, TopCounter) ' ------------- Added by Archie 01212021
        Try
            '_pQuery = "SELECT * FROM SOS_BP_20200703.dbo.BUSDETAIL b INNER JOIN SOS_OAIMS_20200703.dbo.Registered r ON b.EMAIL = REPLACE(r.UserID,'.','') WHERE b.Verified = '0' or b.Verified IS NULL ORDER BY REQDATE"

            Dim _nWhere As String = SearchKey

            _pQuery = "SELECT " & _
                TopCounter & _
                " *, " & _
                " CASE WHEN GENDER = 'M' THEN 'Male' " & _
                " ELSE 'Female'" & _
                " END AS GENDERCOMPLETE, " & _
                " FORMAT(BIRTHDATE, 'MMM dd, yyyy') AS BIRTHDAY" & _
                " FROM " & _pLocalDb & ".dbo.BUSDETAIL b INNER JOIN " & _pLocalDb1 & ".dbo.Registered r " & _
                " ON b.EMAIL2 = r.UserID " & _
                " WHERE " & _
                _nWhere & _
                " b.Verified = '0' or b.Verified IS NULL ORDER BY REQDATE"

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter1 = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable1 = New DataTable
                _mDataAdapter1.Fill(_mDataTable1)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadVerificationHistoryRecordsSearch(SearchKey, TopCounter) ' ------------- Added by Archie 01222021
        Try
            Dim _nWhere As String = SearchKey

            _pQuery = "SELECT " & _
                TopCounter & _
                " * FROM (SELECT  VERIFIEDDATE, EMAIL2 as EMAIL, ACCTNO, OWNER, [STATUS], REMARKS, VERIFIEDBY FROM BUSDETAIL WHERE VERIFIED = '1'" & _
                " UNION" & _
                " SELECT  VERIFIEDDATE, EMAIL, ACCTNO, OWNER, [STATUS], REMARKS,VERIFIEDBY FROM BUSDETAIL_HISTORY ) S" & _
                " WHERE " & _
                _nWhere & _
                " ORDER BY S.VERIFIEDDATE DESC"


            'select * from(SELECT  VERIFIEDDATE, EMAIL2 as EMAIL, ACCTNO, OWNER, [STATUS], REMARKS, VERIFIEDBY FROM BUSDETAIL 
            'WHERE VERIFIED = '1'
            'UNION SELECT  VERIFIEDDATE, EMAIL, ACCTNO, OWNER, [STATUS], REMARKS,VERIFIEDBY FROM BUSDETAIL_HISTORY  
            ') S WHERE S.EMAIL LIKE '%cercado0427@gmailcom%' ORDER BY S.VERIFIEDDATE DESC

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable = New DataTable
                _mDataAdapter.Fill(_mDataTable)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pLoadApplicationRecordsAssessorSearch(SearchKey, TopCounter)
        Try
            Dim _nWhere As String = SearchKey

            _pQuery = "SELECT " & _
                TopCounter & _
                " * FROM (SELECT *, " & _
                " CASE WHEN GENDER = 'M' THEN 'Male' " & _
                " ELSE 'Female'" & _
                " END AS GENDERCOMPLETE" & _
                " FROM " & _pLocalDb & ".dbo.RPTDETAIL b INNER JOIN " & _pLocalDb1 & ".dbo.Registered r ON b.EMAIL2 = r.UserID WHERE b.Verified = '0' or b.Verified IS NULL " & _
                " ) S " & _
                _nWhere & _
                " ORDER BY S.REQDATE "

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter1 = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable1 = New DataTable
                _mDataAdapter1.Fill(_mDataTable1)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pLoadVerificationHistoryRecordsAssessorSearch(SearchKey, TopCounter)
        Try

            Dim _nWhere As String = SearchKey

            _pQuery = "SELECT " & _
                TopCounter & _
                " * FROM (SELECT  VERIFIEDDATE, EMAIL2 as EMAIL, TDN, OWNERNAME, [STATUS], REMARKS, VerifiedBy FROM RPTDETAIL WHERE VERIFIED = '1'" & _
                " UNION" & _
                " SELECT  VERIFIEDDATE, EMAIL, TDN, OWNERNAME, [STATUS], REMARKS, VerifiedBy FROM RPTDETAIL_HISTORY " & _
                " ) S " & _
                _nWhere & _
                " ORDER BY VERIFIEDDATE DESC"

            _pSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _pSqlDataReader = _pSqlCmd.ExecuteReader

            If _pSqlDataReader.HasRows Then
                _mDataAdapter = New SqlDataAdapter(_pQuery, _pSqlCon)
                _mDataTable = New DataTable
                _mDataAdapter.Fill(_mDataTable)
            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region

End Class
