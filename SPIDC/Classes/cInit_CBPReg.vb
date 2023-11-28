Imports System
Imports System.Text
Imports RestSharp
Imports System.Net
Imports System.IO

Public Class cInit_CBPReg

    Public Shared Sub _InitCBP_AutorizeRep(ByRef strBody As String, ByRef strTrigger As String)
        Try
            Select Case True
                Case cLoader_CBPAuthRep._pIsRegCBP
                    strTrigger = "sessionStorage.setItem('RegMode','CBP');"
                Case cLoader_CBPAuthRep._pIsRegOAIMS
                    strTrigger = "sessionStorage.setItem('RegMode','OAIMS');"
            End Select

            Dim _nAddress As String = cLoader_CBPAuthRep._phouse_no + " " + cLoader_CBPAuthRep._pbldg_name + " " + cLoader_CBPAuthRep._pbldg_no + " " + cLoader_CBPAuthRep._psubdivision + " " + cLoader_CBPAuthRep._pstreet_name + " " + cLoader_CBPAuthRep._pbarangay + " " + cLoader_CBPAuthRep._pmunicipality + " " + cLoader_CBPAuthRep._ptown + " " + cLoader_CBPAuthRep._pprovince
            Dim _nBirthday As String = Nothing
            If cLoader_CBPAuthRep._pbirthday <> Nothing Then
                _nBirthday = CDate(cLoader_CBPAuthRep._pbirthday).ToString("MM/dd/yyyy")
            End If

            strBody += "sessionStorage.setItem('AR_first_name','" & cLoader_CBPAuthRep._pfirst_name & "');"
            strBody += "sessionStorage.setItem('AR_middle_name','" & cLoader_CBPAuthRep._pmiddle_name & "');"
            strBody += "sessionStorage.setItem('AR_last_name','" & cLoader_CBPAuthRep._plast_name & "');"
            strBody += "sessionStorage.setItem('AR_suffix','" & cLoader_CBPAuthRep._psuffix & "');"
            strBody += "sessionStorage.setItem('AR_sex','" & IIf(cLoader_CBPAuthRep._psex.ToUpper = "MALE", "M", "F") & "');"
            strBody += "sessionStorage.setItem('AR_mobile_no','" & cLoader_CBPAuthRep._pmobile_no & "');"
            strBody += "sessionStorage.setItem('AR_email_address','" & cLoader_CBPAuthRep._pemail_address & "');"
            strBody += "sessionStorage.setItem('AR_nationality','" & cLoader_CBPAuthRep._pnationality & "');"
            strBody += "sessionStorage.setItem('AR_address','" & _nAddress & "');"
            strBody += "sessionStorage.setItem('AR_tin_number','" & cLoader_CBPAuthRep._ptin_number & "');"
            strBody += "sessionStorage.setItem('AR_telephone_number','" & cLoader_CBPAuthRep._ptelephone_number & "');"
            strBody += "sessionStorage.setItem('AR_landline','" & cLoader_CBPAuthRep._plandline & "');"
            strBody += "sessionStorage.setItem('AR_alternate_email_address','" & cLoader_CBPAuthRep._palternate_email_address & "');"
            strBody += "sessionStorage.setItem('AR_birthday','" & _nBirthday & "');"
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub _InitCBP_BussinessInfo(ByRef strBody As String, ByRef strTrigger As String)

        Dim _nAddress As String = cLoader_CBPBusinessInfo._phouse_no + " " + cLoader_CBPBusinessInfo._pbldg_name + " " + cLoader_CBPBusinessInfo._pbldg_no + " " + cLoader_CBPBusinessInfo._psubdivision + " " + cLoader_CBPBusinessInfo._pstreet_name + " " + cLoader_CBPBusinessInfo._pbarangay + " " + cLoader_CBPBusinessInfo._pmunicipality + " " + cLoader_CBPBusinessInfo._ptown + " " + cLoader_CBPBusinessInfo._pprovince
        strTrigger = "sessionStorage.setItem('RegMode','OAIMS');"
        strBody += "sessionStorage.setItem('verified_company_name','" & cLoader_CBPBusinessInfo._pverified_company_name & "');"
        strBody += "sessionStorage.setItem('company_registration_no','" & cLoader_CBPBusinessInfo._pcompany_registration_no & "');"
        strBody += "sessionStorage.setItem('tradename','" & cLoader_CBPBusinessInfo._ptradename & "');"
        strBody += "sessionStorage.setItem('statement','" & cLoader_CBPBusinessInfo._pstatement & "');"
        strBody += "sessionStorage.setItem('ptype_of_business','" & cLoader_CBPBusinessInfo._ptype_of_business & "');"
        strBody += "sessionStorage.setItem('company_type','" & cLoader_CBPBusinessInfo._pcompany_type & "');"
        strBody += "sessionStorage.setItem('company_sub_type','" & cLoader_CBPBusinessInfo._pcompany_sub_type & "');"
        strBody += "sessionStorage.setItem('company_classification','" & cLoader_CBPBusinessInfo._pcompany_classification & "');"
        strBody += "sessionStorage.setItem('economic_zone','" & cLoader_CBPBusinessInfo._peconomic_zone & "');"
        strBody += "sessionStorage.setItem('economic_zone_location','" & cLoader_CBPBusinessInfo._peconomic_zone_location & "');"
        strBody += "sessionStorage.setItem('enterprise_type','" & cLoader_CBPBusinessInfo._penterprise_type & "');"
        strBody += "sessionStorage.setItem('tin_number','" & cLoader_CBPBusinessInfo._ptin_number & "');"
        strBody += "sessionStorage.setItem('zip_code','" & cLoader_CBPBusinessInfo._pzip_code & "');"
        strBody += "sessionStorage.setItem('region_code','" & cLoader_CBPBusinessInfo._pregion_code & "');"
        strBody += "sessionStorage.setItem('province_code','" & cLoader_CBPBusinessInfo._pprovince_code & "');"
        strBody += "sessionStorage.setItem('city_code','" & cLoader_CBPBusinessInfo._pcity_code & "');"
        strBody += "sessionStorage.setItem('region','" & cLoader_CBPBusinessInfo._pregion & "');"
        strBody += "sessionStorage.setItem('province','" & cLoader_CBPBusinessInfo._pprovince & "');"
        strBody += "sessionStorage.setItem('town','" & cLoader_CBPBusinessInfo._ptown & "');"
        strBody += "sessionStorage.setItem('municipality','" & cLoader_CBPBusinessInfo._pmunicipality & "');"
        strBody += "sessionStorage.setItem('barangay','" & cLoader_CBPBusinessInfo._pbarangay & "');"
        strBody += "sessionStorage.setItem('subdivision','" & cLoader_CBPBusinessInfo._psubdivision & "');"
        strBody += "sessionStorage.setItem('street_name','" & cLoader_CBPBusinessInfo._pstreet_name & "');"
        strBody += "sessionStorage.setItem('bldg_no','" & cLoader_CBPBusinessInfo._pbldg_no & "');"
        strBody += "sessionStorage.setItem('bldg_name','" & cLoader_CBPBusinessInfo._pbldg_name & "');"
        strBody += "sessionStorage.setItem('house_no','" & cLoader_CBPBusinessInfo._phouse_no & "');"
        strBody += "sessionStorage.setItem('landline','" & cLoader_CBPBusinessInfo._plandline & "');"
        strBody += "sessionStorage.setItem('local','" & cLoader_CBPBusinessInfo._plocal & "');"
        strBody += "sessionStorage.setItem('mobile_no','" & cLoader_CBPBusinessInfo._pmobile_no & "');"
        strBody += "sessionStorage.setItem('email_address','" & cLoader_CBPBusinessInfo._pemail_address & "');"
        strBody += "sessionStorage.setItem('territorial_region','" & cLoader_CBPBusinessInfo._pterritorial_region & "');"
        strBody += "sessionStorage.setItem('territorial_city','" & cLoader_CBPBusinessInfo._pterritorial_city & "');"
        strBody += "sessionStorage.setItem('territorial_barangay','" & cLoader_CBPBusinessInfo._pterritorial_barangay & "');"
        strBody += "sessionStorage.setItem('dominant_name','" & cLoader_CBPBusinessInfo._pdominant_name & "');"
        strBody += "sessionStorage.setItem('date_of_birth','" & cLoader_CBPBusinessInfo._pdate_of_birth & "');"
        strBody += "sessionStorage.setItem('business_name_number','" & cLoader_CBPBusinessInfo._pbusiness_name_number & "');"
        strBody += "sessionStorage.setItem('authorized_capital_stock','" & cLoader_CBPBusinessInfo._pauthorized_capital_stock & "');"
        strBody += "sessionStorage.setItem('with_par_value_per_share','" & cLoader_CBPBusinessInfo._pwith_par_value_per_share & "');"
        strBody += "sessionStorage.setItem('without_par_value_per_share','" & cLoader_CBPBusinessInfo._pwithout_par_value_per_share & "');"
        strBody += "sessionStorage.setItem('with_and_without_par_value_per_share','" & cLoader_CBPBusinessInfo._pwith_and_without_par_value_per_share & "');"
        strBody += "sessionStorage.setItem('landline','" & cLoader_CBPBusinessInfo._psubscribed_capital_stock & "');"
        strBody += "sessionStorage.setItem('subscribed_capital_stock','" & cLoader_CBPBusinessInfo._ppaid_up_capital_stock & "');"
        strBody += "sessionStorage.setItem('total_contribution','" & cLoader_CBPBusinessInfo._ptotal_contribution & "');"
        strBody += "sessionStorage.setItem('industry_classification_division','" & cLoader_CBPBusinessInfo._pindustry_classification_division & "');"
        strBody += "sessionStorage.setItem('industry_classification_group','" & cLoader_CBPBusinessInfo._pindustry_classification_group & "');"
        strBody += "sessionStorage.setItem('primary_purpose','" & cLoader_CBPBusinessInfo._pprimary_purpose & "');"
        strBody += "sessionStorage.setItem('secondary_purpose','" & cLoader_CBPBusinessInfo._psecondary_purpose & "');"
        strBody += "sessionStorage.setItem('business_activities','" & cLoader_CBPBusinessInfo._pbusiness_activities & "');"
        strBody += "sessionStorage.setItem('business_address','" & _nAddress & "');"
    End Sub
    Public Shared Function _FnGetBearerToken() As String '@ Added 020211108
        Try
            'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim client = New RestClient("https://api.dev.business.gov.ph/v1/api/security/request-token")
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            request.AddHeader("Content-Type", "application/json")
            Dim body = "{" & _
                        " ""application_id"": ""caloocan@gov.ph""," & _
                        " ""application_secret"": ""d5b6fdb0-1390-4f3c-8431-309a4063abf8"", " & _
                        " ""client_name"": ""City Government of Caloocan"" " & _
                       " }"
            request.AddParameter("application/json", body, ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            Console.WriteLine(response.Content)

            Dim SplitStr() As String
            SplitStr = response.Content.Split(":")
            Dim access_token As String
            access_token = SplitStr(3).Replace("}", "").Replace("""", "")
            Return access_token

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            Return Nothing
        End Try

    End Function
    Public Shared Sub UpdateCBPAppStatus(_nStatusPage As String, _nAppType As String, _nAppDate As Date, Optional _nPaymentMode As String = Nothing, Optional date_issued As Date = Nothing, Optional permit_number As String = Nothing, Optional date_expires As Date = Nothing, Optional reference_no As String = Nothing) ' @ 202011108

        Try

            '=============================================================================================
            '|| STATUS CODE ----                       ||       DESCRIPTION ----                        || 
            '|| SUBMITTED-BUSINESS-PERMIT-APPLICATION  ||      Business Permit Application Submitted    || 
            '|| VERIFIED-BUSINESS-PERMIT               ||      Business Permit Application Verified     || 
            '|| ISSUED-BUSINESS-PERMIT                 ||      Business Permit Issued                   || 
            '|| APPLICATION-DISAPPROVED                ||      Business Permit Application Disapproved  || 
            '|| BUSINESS-PERMIT-REVOKED                ||      Business Permit Revoked                  || 
            '=============================================================================================
            'cLoader_CBPAuthRep._pBearerToken = _FnGetBearerToken()

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim client = New RestClient("https://api.dev.business.gov.ph/v1/api/ebpls/business/v2/update-status/" & _nStatusPage)
            client.Timeout = -1
            Dim request = New RestRequest(Method.PUT)
            request.AddHeader("Authorization", "Bearer " & _FnGetBearerToken())
            request.AddHeader("Content-Type", "application/json")
            Dim body = "{" & _
                        "  ""business_name"":""COME IN!"" " & _
                        " ,""date_of_application"":""" & _nAppDate.ToString("yyyy-MM-dd hh:mm tt") & """ " & _
                        " ,""type_of_application"":""" & _nAppType & """ " & _
                        " ,""business_identification_number"":""" & cSessionLoader._pAccountNo & """ " & _
                        " ,""date_of_action"":""" & Date.Now.ToString("yyyy-MM-dd hh:mm tt") & """ " & _
                        " ,""cbp_number"":""" & cLoader_CBPAuthRep._pcbp_transaction_no & """ " & _
                        " ,""payment_mode"":""" & _nPaymentMode & """ " & _
                        " ,""date_issued"":""" & date_issued.ToString("yyyy-MM-dd hh:mm tt") & """ " & _
                        " ,""remarks"":"""" " & _
                        " ,""permit_number"":""" & permit_number & """ " & _
                        " ,""date_expires"":""" & date_expires.ToString("yyyy-MM-dd hh:mm tt") & """ " & _
                        " ,""reference_no"":""" & reference_no & """ " & _
                        " }"
            request.AddParameter("application/json", body, ParameterType.RequestBody)
            Dim response As IRestResponse = client.Execute(request)
            Console.WriteLine(response.Content)

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try

    End Sub

    Public Shared Function _PostECert(cbp_transaction_no As String, _nFileLoc As String) As Boolean

        Try
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim file As FileInfo = New FileInfo(_nFileLoc)
            Dim filename As String = file.Name
            Dim contentType As String = MimeMapping.GetMimeMapping(_nFileLoc)
            Dim client As New RestClient("https://api.dev.business.gov.ph/v1/api/ebpls/business/v2/upload/" & cbp_transaction_no)
            Dim request1 = New RestRequest(Method.POST)
            request1.AddFile("file", file.FullName, contentType)
            request1.AddHeader("Content-Type", "multipart/form-data")
            request1.AddHeader("Authorization", "Bearer " & _FnGetBearerToken())
            request1.AddHeader("accept", "*/*")
            Dim response As IRestResponse = client.Execute(request1)
            Console.WriteLine(response.Content)
            Dim result As String = response.Content
            If result.Contains("{""success"":true}") Then
                Return True
            Else
                Return False
            End If
            'ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            'Dim client = New RestClient("https://api.dev.business.gov.ph/v1/api/ebpls/business/v2/upload/CBPCC3C5E3F16E706ADC")
            'Dim boundary As String = "---------------------------" & DateTime.Now.Ticks.ToString("x")
            'client.Timeout = -1
            'Dim request1 = New RestRequest(Method.POST)
            'request1.AddHeader("Authorization", "Bearer " & _FnGetBearerToken())
            'request1.AddHeader("Content-Type", "multipart/form-data; boundary=" & boundary)
            'request1.AddFile("file", _nFileLoc)
            'Dim response As IRestResponse = client.Execute(request1)
            'Console.WriteLine(response.Content)

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            Return False
        End Try

    End Function
    Public Shared Sub _TagAsECertPosted()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSMAST SET IsECertPosted = 1" & _
                            "  WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND cbp_transaction_no = ''" & cLoader_CBPBusinessInfo._pcbp_transaction_no & "'' "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _InsertAppStatLog(_nStatusCode As String)
        Try
            Dim _nStatusDesc As String = Nothing
            Select Case _nStatusCode

                Case "SUBMITTED-BUSINESS-PERMIT-APPLICATION"
                    _nStatusDesc = "Business Permit Application Submitted"
                Case "VERIFIED-BUSINESS-PERMIT"
                    _nStatusDesc = "Business Permit Application Verified"
                Case "ISSUED-BUSINESS-PERMIT"
                    _nStatusDesc = "Business Permit Issued"
                Case "APPLICATION-DISAPPROVED"
                    _nStatusDesc = "Business Permit Application Disapproved"
                Case "BUSINESS-PERMIT-REVOKED"
                    _nStatusDesc = "Business Permit Revoked"
                Case "BUSINESS-PERMIT-PAID"
                    _nStatusDesc = "Business Permit Paid"
                Case "BUSINESS-PERMIT-FOR-PAYMENT"
                    _nStatusDesc = "Business Permit For Payment"

            End Select

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO cbp_application_status " & _
                            "   (business_account_number, cbp_transaction_number, email_address, for_year, status_date, status_code, status_desc) " & _
                            "   VALUES (''" & cSessionLoader._pAccountNo & "'', ''" & cLoader_CBPAuthRep._pcbp_transaction_no & "'', ''" & cLoader_BPLTIMS._pEMAILADDR & "'', YEAR(GETDATE()), format(GETDATE(),''yyyy-MM-dd hh:mm tt'') , ''" & _nStatusCode & "'', ''" & _nStatusDesc & "'')"
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub
    Public Shared Sub _DisplayCBPAppStat(cbp_transaction_number As String, business_account_number As String, email_address As String, ByRef strBuilder As String, ByRef _nSuccess As Boolean, ByRef _nErrMsg As String, ByRef _nRowCont As Integer)
        Try
            Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
            Dim PageName As String = System.IO.Path.GetFileName(PagePath)

            Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM vw_CBP_Application_Status "
                ._pCondition = " where cbp_transaction_number = ''" & cbp_transaction_number & "'' " & _
                                " and email_address = ''" & email_address & "'' "
                '" and business_account_number = ''" & business_account_number & "'' " & _
                ._pSortBy = " ORDER BY status_date desc"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable
                Dim sb = New System.Text.StringBuilder()

                sb.Append("<html>")
                sb.Append("<style> table, th, td {   border:1px solid black; } </style>")
                sb.Append("<body>")

                sb.Append("<Center>")
                sb.Append("<div>")
                sb.Append("<br>")
                sb.Append("<h4> BUSINESS PERMIT APPLICATION STATUS </h4>")
                _nRowCont = _nDataTable.Rows.Count
                If _nDataTable.Rows.Count > 0 Then

                    sb.Append("<div>")
                    sb.Append("<b> <label> Business name/Trade name </label> </b> <br>")
                    sb.Append("<label>" & _nDataTable.Rows(0).Item("verified_company_name").ToString() & "</label>")
                    sb.Append("</div>")

                    sb.Append("<div>")
                    sb.Append("<b> <label>CBP Transaction No</label> </b> <br>")
                    sb.Append("<label>" & _nDataTable.Rows(0).Item("cbp_transaction_number").ToString() & "</label>")
                    sb.Append("</div>")

                    sb.Append("<div>")
                    sb.Append("<b> <label>Business Account No.</label> </b> <br>")
                    sb.Append("<label>" & _nDataTable.Rows(0).Item("business_account_number").ToString() & "</label>")
                    sb.Append("</div>")

                    sb.Append("<div>")
                    sb.Append("<b> <label>Email Address</label> </b> <br>")
                    sb.Append("<label>" & _nDataTable.Rows(0).Item("email_address").ToString() & "</label>")
                    sb.Append("</div>")

                    sb.Append("<br>")
                    sb.Append("<div style='width:80%'>")
                    sb.Append("<table style='width:80%'>")

                    sb.Append("<tr>")
                    sb.Append("<th>Date</th>")
                    sb.Append("<th>Status</th>")
                    sb.Append("</tr>")

                    Dim _nRow As Integer = 0
                    For Each row As DataRow In _nDataTable.Rows

                        sb.Append("<tr>")
                        sb.Append("<td>" & _nDataTable.Rows(_nRow).Item("status_date").ToString() & "</td>")
                        sb.Append("<td>" & _nDataTable.Rows(_nRow).Item("status_desc").ToString() & "</td>")
                        sb.Append("</tr>")

                        'sb.Append("<div style='width:80%'>")

                        'sb.Append("<b> <label>Status Date</label><br> </b>")
                        'sb.Append("<label>" & _nDataTable.Rows(_nRow).Item("status_date").ToString() & "</label><br>")

                        'sb.Append("<b> <label>Status</label><br> </b>")
                        'sb.Append("<label>" & _nDataTable.Rows(_nRow).Item("status_desc").ToString() & "</label><br>")

                        'sb.Append("</div>")

                        _nRow = _nRow + 1
                    Next

                    sb.Append("</table>")
                    sb.Append("<br>")
                    sb.Append("<br>")

                Else
                    If _nSuccess = False Then
                        sb.Append("<div>")
                        sb.Append("<label>" & _nErrMsg & "</label>")
                        sb.Append("</div>")
                    End If
                    If _nDataTable.HasErrors Then
                        sb.Append("<div>")
                        sb.Append("<label>" & _nDataTable.GetErrors().ToString & "</label>")
                        sb.Append("</div>")
                    End If

                End If


                sb.Append("<div>")
                sb.Append(" <a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Go to Web Service Portal</a> <br>")
                sb.Append("</div>")
                sb.Append("</div>")
                sb.Append("</Center>")
                sb.Append("</body>")
                sb.Append("</html>")

                strBuilder = sb.ToString
            End With


        Catch ex As Exception
            _nSuccess = False
            _nErrMsg = ex.Message
            cEventLog._pSubLogError(ex)
        End Try
    End Sub
    Public Shared Function _Fn_CheckIfExist_CBP_AuthRep(CBPGUID As String) As Boolean

        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select * from [vw_CBP_AuthorizeRepInfo]"
                ._pCondition = " where [guid] = ''" & CBPGUID & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    cLoader_CBPAuthRep._pcbp_transaction_no = _nDataTable.Rows(0).Item("cbp_transaction_no").ToString()
                    cLoader_CBPAuthRep._pemail_address = _nDataTable.Rows(0).Item("email_address").ToString()
                    cLoader_CBPAuthRep._pfirst_name = _nDataTable.Rows(0).Item("first_name").ToString()
                    cLoader_CBPAuthRep._pmiddle_name = _nDataTable.Rows(0).Item("middle_name").ToString()
                    cLoader_CBPAuthRep._plast_name = _nDataTable.Rows(0).Item("last_name").ToString()
                    cLoader_CBPAuthRep._psuffix = _nDataTable.Rows(0).Item("suffix").ToString()
                    cLoader_CBPAuthRep._psex = _nDataTable.Rows(0).Item("sex").ToString()
                    cLoader_CBPAuthRep._pbirthday = _nDataTable.Rows(0).Item("birthday").ToString()
                    cLoader_CBPAuthRep._pnationality = _nDataTable.Rows(0).Item("nationality").ToString()
                    cLoader_CBPAuthRep._ptin_number = _nDataTable.Rows(0).Item("tin_number").ToString()
                    cLoader_CBPAuthRep._pposition = _nDataTable.Rows(0).Item("position").ToString()
                    cLoader_CBPAuthRep._prole = _nDataTable.Rows(0).Item("role").ToString()
                    cLoader_CBPAuthRep._pzip_code = _nDataTable.Rows(0).Item("zip_code").ToString()
                    cLoader_CBPAuthRep._pregion = _nDataTable.Rows(0).Item("region").ToString()
                    cLoader_CBPAuthRep._pprovince = _nDataTable.Rows(0).Item("province").ToString()
                    cLoader_CBPAuthRep._ptown = _nDataTable.Rows(0).Item("town").ToString()
                    cLoader_CBPAuthRep._pmunicipality = _nDataTable.Rows(0).Item("municipality").ToString()
                    cLoader_CBPAuthRep._pbarangay = _nDataTable.Rows(0).Item("barangay").ToString()
                    cLoader_CBPAuthRep._psubdivision = _nDataTable.Rows(0).Item("subdivision").ToString()
                    cLoader_CBPAuthRep._pstreet_name = _nDataTable.Rows(0).Item("street_name").ToString()
                    cLoader_CBPAuthRep._pbldg_no = _nDataTable.Rows(0).Item("bldg_no").ToString()
                    cLoader_CBPAuthRep._pbldg_name = _nDataTable.Rows(0).Item("bldg_name").ToString()
                    cLoader_CBPAuthRep._phouse_no = _nDataTable.Rows(0).Item("house_no").ToString()
                    cLoader_CBPAuthRep._palternate_email_address = _nDataTable.Rows(0).Item("alternate_email_address").ToString()
                    cLoader_CBPAuthRep._pmobile_no = _nDataTable.Rows(0).Item("mobile_no").ToString()
                    cLoader_CBPAuthRep._plandline = _nDataTable.Rows(0).Item("landline").ToString()
                    cLoader_CBPAuthRep._plocal = _nDataTable.Rows(0).Item("local").ToString()
                    cLoader_CBPAuthRep._pcountry = _nDataTable.Rows(0).Item("country").ToString()
                    cLoader_CBPAuthRep._paddress = _nDataTable.Rows(0).Item("address").ToString()
                    cLoader_CBPAuthRep._pcountry_code = _nDataTable.Rows(0).Item("country_code").ToString()
                    cLoader_CBPAuthRep._ptelephone_number = _nDataTable.Rows(0).Item("telephone_number").ToString()
                    cLoader_CBPAuthRep._pguid = _nDataTable.Rows(0).Item("guid").ToString()
                    cLoader_CBPAuthRep._pIsFromCBP = True
                    Return True
                Else
                    cLoader_CBPAuthRep._pIsFromCBP = False
                    Return False
                End If

            End With


        Catch ex As Exception
            Return False
            cEventLog._pSubLogError(ex)
        End Try

    End Function
    Public Shared Sub _Get_CBP_BusinessInfo()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select * from [vw_CBP_BusinessInfo]"
                ._pCondition = " where [cbp_transaction_no] = ''" & cLoader_CBPAuthRep._pcbp_transaction_no & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then

                    cLoader_CBPBusinessInfo._pcbp_transaction_no = _nDataTable.Rows(0).Item("cbp_transaction_no").ToString()
                    cLoader_CBPBusinessInfo._pverified_company_name = _nDataTable.Rows(0).Item("verified_company_name").ToString()
                    cLoader_CBPBusinessInfo._pcompany_registration_no = _nDataTable.Rows(0).Item("company_registration_no").ToString()
                    cLoader_CBPBusinessInfo._ptradename = _nDataTable.Rows(0).Item("tradename").ToString()
                    cLoader_CBPBusinessInfo._pstatement = _nDataTable.Rows(0).Item("statement").ToString()
                    cLoader_CBPBusinessInfo._ptype_of_business = _nDataTable.Rows(0).Item("type_of_business").ToString()
                    cLoader_CBPBusinessInfo._pcompany_type = _nDataTable.Rows(0).Item("company_type").ToString()
                    cLoader_CBPBusinessInfo._pcompany_sub_type = _nDataTable.Rows(0).Item("company_sub_type").ToString()
                    cLoader_CBPBusinessInfo._pcompany_classification = _nDataTable.Rows(0).Item("company_classification").ToString()
                    cLoader_CBPBusinessInfo._peconomic_zone = _nDataTable.Rows(0).Item("economic_zone").ToString()
                    cLoader_CBPBusinessInfo._peconomic_zone_location = _nDataTable.Rows(0).Item("economic_zone_location").ToString()
                    cLoader_CBPBusinessInfo._penterprise_type = _nDataTable.Rows(0).Item("enterprise_type").ToString()
                    cLoader_CBPBusinessInfo._ptin_number = _nDataTable.Rows(0).Item("tin_number").ToString()
                    cLoader_CBPBusinessInfo._pzip_code = _nDataTable.Rows(0).Item("zip_code").ToString()
                    cLoader_CBPBusinessInfo._pregion_code = _nDataTable.Rows(0).Item("region_code").ToString()
                    cLoader_CBPBusinessInfo._pprovince_code = _nDataTable.Rows(0).Item("province_code").ToString()
                    cLoader_CBPBusinessInfo._pcity_code = _nDataTable.Rows(0).Item("city_code").ToString()
                    cLoader_CBPBusinessInfo._pregion = _nDataTable.Rows(0).Item("region").ToString()
                    cLoader_CBPBusinessInfo._pprovince = _nDataTable.Rows(0).Item("province").ToString()
                    cLoader_CBPBusinessInfo._ptown = _nDataTable.Rows(0).Item("town").ToString()
                    cLoader_CBPBusinessInfo._pmunicipality = _nDataTable.Rows(0).Item("municipality").ToString()
                    cLoader_CBPBusinessInfo._pbarangay = _nDataTable.Rows(0).Item("barangay").ToString()
                    cLoader_CBPBusinessInfo._psubdivision = _nDataTable.Rows(0).Item("subdivision").ToString()
                    cLoader_CBPBusinessInfo._pstreet_name = _nDataTable.Rows(0).Item("street_name").ToString()
                    cLoader_CBPBusinessInfo._pbldg_no = _nDataTable.Rows(0).Item("bldg_no").ToString()
                    cLoader_CBPBusinessInfo._pbldg_name = _nDataTable.Rows(0).Item("bldg_name").ToString()
                    cLoader_CBPBusinessInfo._phouse_no = _nDataTable.Rows(0).Item("house_no").ToString()
                    cLoader_CBPBusinessInfo._plandline = _nDataTable.Rows(0).Item("landline").ToString()
                    cLoader_CBPBusinessInfo._plocal = _nDataTable.Rows(0).Item("local").ToString()
                    cLoader_CBPBusinessInfo._pmobile_no = _nDataTable.Rows(0).Item("mobile_no").ToString()
                    cLoader_CBPBusinessInfo._pemail_address = _nDataTable.Rows(0).Item("email_address").ToString()
                    cLoader_CBPBusinessInfo._pterritorial_region = _nDataTable.Rows(0).Item("territorial_region").ToString()
                    cLoader_CBPBusinessInfo._pterritorial_city = _nDataTable.Rows(0).Item("territorial_city").ToString()
                    cLoader_CBPBusinessInfo._pterritorial_barangay = _nDataTable.Rows(0).Item("territorial_barangay").ToString()
                    cLoader_CBPBusinessInfo._pdominant_name = _nDataTable.Rows(0).Item("dominant_name").ToString()
                    cLoader_CBPBusinessInfo._pdate_of_birth = _nDataTable.Rows(0).Item("date_of_birth").ToString()
                    cLoader_CBPBusinessInfo._pbusiness_name_number = _nDataTable.Rows(0).Item("business_name_number").ToString()
                    cLoader_CBPBusinessInfo._pauthorized_capital_stock = _nDataTable.Rows(0).Item("authorized_capital_stock").ToString()
                    cLoader_CBPBusinessInfo._pwith_par_value_per_share = _nDataTable.Rows(0).Item("with_par_value_per_share").ToString()
                    cLoader_CBPBusinessInfo._pwithout_par_value_per_share = _nDataTable.Rows(0).Item("without_par_value_per_share").ToString()
                    cLoader_CBPBusinessInfo._pwith_and_without_par_value_per_share = _nDataTable.Rows(0).Item("with_and_without_par_value_per_share").ToString()
                    cLoader_CBPBusinessInfo._psubscribed_capital_stock = _nDataTable.Rows(0).Item("subscribed_capital_stock").ToString()
                    cLoader_CBPBusinessInfo._ppaid_up_capital_stock = _nDataTable.Rows(0).Item("paid_up_capital_stock").ToString()
                    cLoader_CBPBusinessInfo._ptotal_contribution = _nDataTable.Rows(0).Item("total_contribution").ToString()
                    cLoader_CBPBusinessInfo._pindustry_classification_division = _nDataTable.Rows(0).Item("industry_classification_division").ToString()
                    cLoader_CBPBusinessInfo._pindustry_classification_group = _nDataTable.Rows(0).Item("company_registration_no").ToString()
                    cLoader_CBPBusinessInfo._pprimary_purpose = _nDataTable.Rows(0).Item("primary_purpose").ToString()
                    cLoader_CBPBusinessInfo._psecondary_purpose = _nDataTable.Rows(0).Item("secondary_purpose").ToString()
                    cLoader_CBPBusinessInfo._pbusiness_activities = _nDataTable.Rows(0).Item("business_activities").ToString()

                End If

            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub
    Public Shared Function _Fn_CheckIfExist_OAIMS_Registered() As Boolean

        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
                ._pAction = "SELECT"
                ._pSelect = "Select * from [registered] "
                ._pCondition = " where UserID  = ''" & cLoader_CBPAuthRep._pemail_address & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With


        Catch ex As Exception
            Return False
            cEventLog._pSubLogError(ex)
        End Try

    End Function
    Public Shared Sub _SetBusMastCBPTransNo() ' @ 202011110
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = " UPDATE BUSMAST Set " & _
                            " cbp_transaction_no = ''" & cLoader_CBPBusinessInfo._pcbp_transaction_no & "''"
                ._pCondition = " WHERE AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try

    End Sub
    Public Shared Function _Fn_CheckIfCBPApplicant() As Boolean

        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select cbp_transaction_no from BUSMAST"
                ._pCondition = " where ACCTNO = ''" & cSessionLoader._pAccountNo & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    Return False
                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    cLoader_CBPAuthRep._pcbp_transaction_no = _nDataTable.Rows(0).Item("cbp_transaction_no").ToString()
                    If cLoader_CBPAuthRep._pcbp_transaction_no <> Nothing And cLoader_CBPAuthRep._pcbp_transaction_no <> "" Then
                        Return True
                    Else
                        Return False
                    End If
                End If

            End With


        Catch ex As Exception
            Return False
            cEventLog._pSubLogError(ex)
        End Try

    End Function
    Public Shared Function _Fn_GetBUSMASTAppDate() As String

        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select APP_DATE from BUSMAST"
                ._pCondition = " where ACCTNO = ''" & cSessionLoader._pAccountNo & "'' "
                ._pExec(_nSuccess, _nErrMsg)


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("APP_DATE").ToString()
                End If

            End With


        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function _Fn_IsCBP_Integrated() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select cbp_transaction_no from BUSMAST"
                ._pCondition = " WHERE ISNULL(cbp_transaction_no,'''') <> ''''"
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    Return False
                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If


            End With
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub _BindECert(_nGridview As GridView)
        Try
            _nGridview.DataSource = Nothing

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nSvrBPLTAS As String
            Dim _nDBBPLTAS As String

            _nSvrBPLTAS = _nClBP._pDBDataSource
            _nDBBPLTAS = _nClBP._pDBInitialCatalog

            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS_F"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nSvrBPLTAS_F As String
            Dim _nDBBPLTAS_F As String

            _nSvrBPLTAS_F = _nClBP._pDBDataSource
            _nDBBPLTAS_F = _nClBP._pDBInitialCatalog

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT BP.ACCTNO,BM.cbp_transaction_no,BM.COMMNAME,BM.APP_DATE,BP.PERMITNO,BP.DATERELEASED, BM.EMAILADDR, xBase64 ARXFile " & _
                            "FROM [" & _nSvrBPLTAS & "].[" & _nDBBPLTAS & "].dbo.[BusinessPermit]  BP " & _
                            "INNER Join " & _
                            "BUSMAST BM " & _
                            "ON BP.ACCTNO = BM.ACCTNO  " & _
                            "AND BP.FORYEAR = Year(getdate()) " & _
                            "AND BP.Released = 1 " & _
                            "INNER Join " & _
                            "[" & _nSvrBPLTAS_F & "].[" & _nDBBPLTAS_F & "].dbo.[BPfile] BF " & _
                            "cross apply (select BF.ARXfile ''*'' for xml path('''')) T (xBase64) " & _
                            "ON BF.ACCTNO = BM.ACCTNO  " & _
                            "AND BF.FORYEAR = Year(getdate()) " & _
                            "WHERE ISNULL(BM.IsECertPosted,0) = 0" & _
                            "ORDER BY BF.xFileNo Desc "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then

                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _nGridview.DataSource = _nDataTable
                    _nGridview.DataBind()
                    '  _oButtonPost.Enabled = True
                Else
                    cGridview.pEmptyGridView(_nDataTable, _nGridview, "-- NO RECORD AVAILABLE --")
                    ' _oButtonPost.Enabled = False
                End If

            End With

        Catch ex As Exception
            'snackbar("red", " Error occured,  " & ex.Message)
        End Try
    End Sub

    Public Shared Function _Fn_PaymentMode() As String
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
                ._pAction = "SELECT"
                ._pSelect = "Select * from OnlinePaymentRefno"
                ._pCondition = " where ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND StatusID = ''SUCCESS'' "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    Return False
                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then

                    Return "online payment"
                Else
                    Return "over the counter"

                End If

            End With

        Catch ex As Exception

        End Try
    End Function

    '@Added 20211217
    Public Shared Sub _SetSession(ByVal _nUserId As String, ByVal _nGUID As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO CBP_Session" & _
                            "(UserId, guid)" & _
                            "VALUES (''" & _nUserId & "'',''" & _nGUID & "'')"
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub
    '@Added 20211217
    Public Shared Sub _ClearSession(ByVal _nUserID As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM CBP_Session"
                ._pCondition = " WHERE UserID = ''" & _nUserID & "''"
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub
    '@Added 20211217
    Public Shared Function _FnGetSession(ByVal _nUserId As String) As String
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT GUID FROM CBP_Session "
                ._pCondition = " WHERE UserID = ''" & _nUserId & "''"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("GUID").ToString()
                Else
                    Return Nothing
                End If
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            Return Nothing
        End Try
    End Function

End Class
