

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Web.HttpContext

#End Region

Public Class cDalAppointment

#Region "Variables Data"

    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mSqlDataReader As SqlDataReader
    Public Shared _mCertType As String
    Public Shared _mDataTable As DataTable
    'Public Shared _mDepartment As String
    Public Shared _mDepartmentAbbrev As String
    ' Public Shared _mTransType As String
    ' Public Shared _mPurpose As String
    Public Shared TaxpayerName As String
    Public Shared TaxpayerContact As String
    Public Shared REMARKS As String

    Public Shared ScheduledBy As String
    Public Shared AppDateFrom As Date
    Public Shared AppDateTo As Date
    Public Shared TransDateFrom As Date
    Public Shared TransDateTo As Date
    Public Shared Department As String
    Public Shared SortByCode As String
    Public Shared OrderCode As String
    Public Shared SortByDesc As String
    Public Shared OrderDesc As String


    Private _mDataSet As DataSet
    Private Shared _mDbCon As New SqlConnection
    Public Shared _mSqlCon As SqlConnection

    Private Const _sscPrefix As String = "cDalAppointment."
    Private Const _sscDepartment As String = _sscPrefix & "_sscDepartment"
    Private Const _sscTransType As String = _sscPrefix & "_sscTransType"
    Private Const _sscPurpose As String = _sscPrefix & "_sscPurpose"

      

#End Region

#Region "Properties Data"
    Shared Property _mPurpose() As String
        Get
            Return Current.Session(_sscPurpose)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPurpose) = value
        End Set
    End Property
    Shared Property _mTransType() As String
        Get
            Return Current.Session(_sscTransType)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTransType) = value
        End Set
    End Property
    Shared Property _mDepartment() As String
        Get
            Return Current.Session(_sscDepartment)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDepartment) = value
        End Set
    End Property

    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pDataSet() As DataSet
        Get
            Try
                '----------------------------------

                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataSet = New DataSet
                _nSqlDataAdapter.Fill(_mDataSet)
                Return _mDataSet
                '----------------------------------

            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Variables Field"
    Private _mEventID As String
    Private _mEventTime As String



    Private Const _sscFile001 As String = _sscPrefix & "_sscFile001"
    Private Const _sscFile002 As String = _sscPrefix & "_sscFile002"
    Private Const _sscFile003 As String = _sscPrefix & "_sscFile003"
    Private Const _sscFile004 As String = _sscPrefix & "_sscFile004"
    Private Const _sscFile005 As String = _sscPrefix & "_sscFile005"
    Private Const _sscModuleID As String = _sscPrefix & "_sscModuleID"


#End Region

#Region "Properties Field"

    Shared Property _pModuleID() As String
        Get
            Return Current.Session(_sscModuleID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscModuleID) = value
        End Set
    End Property
    Shared Property _pFile001() As String
        Get
            Return Current.Session(_sscFile001)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile001) = value
        End Set
    End Property

    Shared Property _pFile002() As String
        Get
            Return Current.Session(_sscFile002)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile002) = value
        End Set
    End Property

    Shared Property _pFile003() As String
        Get
            Return Current.Session(_sscFile003)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile003) = value
        End Set
    End Property

    Shared Property _pFile004() As String
        Get
            Return Current.Session(_sscFile004)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile004) = value
        End Set
    End Property

    Shared Property _pFile005() As String
        Get
            Return Current.Session(_sscFile005)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFile005) = value
        End Set
    End Property
    Public Property _pEventID As String
        Get
            Return _mEventID
        End Get
        Set(value As String)
            _mEventID = value
        End Set
    End Property

    Public Property _pEventTime As String
        Get
            Return _mEventTime
        End Get
        Set(value As String)
            _mEventTime = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"

#End Region

#Region "Routine Command"

    Public Sub _pSubInsertAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO Attachment VALUES(@Email,@RefNo,@ModuleID,@AcctID,@SeqID,@FileData,@FileName,@FileType,@ReqDesc,@Office)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Email", Email)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
                .AddWithValue("@ReqDesc", ReqDesc)
                .AddWithValue("@Office", Office)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAAppointment(dateFrom, dateTo, dateTime, Department, Beg_AM_Slot, AM_Slot, Beg_PM_Slot, PM_Slot, DayCondition)
        Try
            Dim _nQuery As String = Nothing
            Dim where As String = Nothing
            _nQuery = "" & _
                " DECLARE" & _
                " @FirstDateOfYear DATETIME," & _
                " @LastDateOfYear DATETIME " & _
                " SELECT @FirstDateOfYear = dateadd(d,-1,'" & dateFrom & "')                                                                                                     " & _
                " SELECT @LastDateOfYear = dateadd(d,1,'" & dateTo & "')                                                                                                      " & _
                " ;WITH cte AS (                                                                                                                                 " & _
                " SELECT 1 AS DayID,                                                                                                                             " & _
                " @FirstDateOfYear AS FromDate,                                                                                                                  " & _
                " DATENAME(dw, @FirstDateOfYear) AS Dayname                                                                                                      " & _
                " UNION ALL                                                                                                                                      " & _
                " SELECT cte.DayID + 1 AS DayID,                                                                                                                 " & _
                " DATEADD(d, 1 ,cte.FromDate),                                                                                                                   " & _
                " DATENAME(dw, DATEADD(d, 1 ,cte.FromDate)) AS Dayname                                                                                           " & _
                " FROM cte                                                                                                                                       " & _
                " WHERE DATEADD(d,1,cte.FromDate) < @LastDateOfYear                                                                                              " & _
                " )                                                                                                                                              " & _
                " Insert into AppointmentSlot                                                                                                                    " & _
                " SELECT  FromDate as AppDate,'" & Beg_AM_Slot & "' as Beg_AM_Slot,'" & AM_Slot & "' as AM_Slot,'" & Beg_PM_Slot & "' as Beg_PM_Slot,'" & PM_Slot & "' as PM_Slot, '#5070DA' as Color,'" & Department & "' as Office           " & _
                " FROM CTE  " & _
                " WHERE FromDate not IN (select AppDate from AppointmentSlot where Office = '" & Department & "')"
            Select Case DayCondition
                Case "on"
                    'do nothing
                Case Else
                    where = " and DayName not IN ('Saturday','Sunday')"
            End Select

            Dim _nSqlCommand As New SqlCommand(_nQuery & where, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubUpdateAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Attachment SET FileData = @FileData, FileName = @FileName, FileType = @FileType " & _
                      " where Email=@Email and ModuleID=@ModuleID and AcctID=@AcctID and SeqID=@SeqID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Email", Email)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAttachRefNo(ByVal Email As String, ByVal RefNo As String, ByVal ModuleID As String, ByVal AcctID As String, ByVal AppDate As String, ByVal Slot As String, Optional ByRef _err As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Attachment SET RefNo = '" & RefNo & "' " & _
                ",ModuleID='" & ModuleID & "' " & _
                " where Email='" & Email & "' and AcctID='" & AcctID & "' and " & _
                " [RefNo]='" & RefNo & "' and  [ModuleID]='" & ModuleID & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)


            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
            '_err = ";_pSubUpdateAttachRefNo:OK"
        Catch ex As Exception
            _err = ";_pSubUpdateAttachRefNo:" & ex.Message
        End Try
    End Sub

    Public Sub _pSubUpdateAppointmentCode(ByVal Email As String, ByVal Code As String, Optional ByRef _err As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Appointment SET CodeUsed = 1 " & _
                " where Email='" & Email & "' and Code='" & Code & "' "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
            ' _err = ";_pSubUpdateAppointmentCode:OK"
        Catch ex As Exception
            _err = ";_pSubUpdateAppointmentCode:" & ex.Message
        End Try
    End Sub


    Public Sub _pSubGetDepartment()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT * from [Department]"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetDepartmentAppointmentType()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department]  order by UserType asc"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetOfficeWithAppointment()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " select distinct Office from Appointment order by office asc"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetTypeWithAppointment(ByVal Office As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery =
            " select Distinct AR.Type from AppointmentRequirements AR" &
            " Inner Join Appointment A on A.TransType=AR.Type" &
            " where AR.Department='" & Office & "' and A.[STATUS] = 'Pending Approval'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub
    Public Function _pSubGetTOP1Department() As String
        Dim result As String = Nothing
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT TOP 1 UserType from [Department] order by UserType asc"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("UserType").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Sub _pSubGetEnrolledAccounts(ByVal Department As String, ByRef Enrolled_Accounts As Integer)
        Try
            Dim _nQuery As String = Nothing
            Select Case Department
                Case "BPLO"
                    _nQuery = " SELECT COUNT(*) AS CTR from [BUSDETAIL] where EMAIL2='" & cSessionUser._pUserID & "' AND VERIFIED = 1  "

                Case "CAO"
                    _nQuery = " SELECT COUNT(*) AS CTR  from [RPTDETAIL] where EMAIL2='" & cSessionUser._pUserID & "' AND VERIFIED = 1 "

            End Select

            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Enrolled_Accounts = _nSqlDr("CTR").ToString()
                    Loop
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetSpecificDate(ByVal _Date As Date, ByVal office As String, ByRef AM_Slot As Integer, ByRef PM_Slot As Integer, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " Select * from AppointmentSlot where [AppDate] = '" & Format(_Date, "yyyy-MM-dd") & "' and Office='" & office & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                    Do While _nSqlDr.Read
                        AM_Slot = _nSqlDr("AM_Slot")
                        PM_Slot = _nSqlDr("PM_Slot")
                    Loop
                Else
                    AM_Slot = 0
                    PM_Slot = 0
                    Exists = False
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetCodeParameters(ByVal Code As String, ByRef isValid As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Appointment] where Code='" & Code & "' and email='" & cSessionUser._pUserID & "' and CodeUsed=0"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        cDalAppointment._mDepartment = _nSqlDr("Office").ToString()
                        cDalAppointment._mTransType = _nSqlDr("TransType").ToString()
                        cDalAppointment._mPurpose = _nSqlDr("Purpose").ToString()
                        isValid = True
                    Loop
                Else
                    isValid = False
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetDepartmentAppointment()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department] where Usertype in (select OFfice from [AppointmentSlot]  where AppDate >= getdate())"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetRequirements(Department)
        Try
            Dim _nQuery As String = Nothing

            _nQuery = " Select [Type]," &
                " (Header + (replace(concat('<ul>',concat('<li>',replace(Body,';','</li><li>')),'</ul>'),'<li></ul>','</ul>')) + isnull(Footer,''))Content" &
                " FROM [AppointmentRequirements] " &
                " where Department = '" & Department & "' and Availability = 1 "

            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetRequirementsNewBPonly()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = "select [Type],(Header + Body + isnull(Footer,'')) as Content from [AppointmentRequirements] where Department = 'BPLO' and Type like '%New Business%'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetRequirementsTEST()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT Type, Department FROM [AppointmentRequirements]"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetAppType(Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT distinct(TransType) from [Appointment] where [Office] = '" & Office & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetDepartmentDesc(ByVal Department As String, ByRef Description As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department] where Abbrev = '" & Department & "' or UserType='" & Department & "' "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Description = _nSqlDr("Department").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubcheckIfRegulatory(ByVal office As String, ByRef Regulatory As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT Regulatory from [Department] where Abbrev = '" & office & "' or UserType='" & office & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Regulatory = _nSqlDr("Regulatory")
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectImage(ByVal Email As String, ByVal ModuleID As String, ByVal AcctID As String, ByVal SeqID As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] "
            _nWhere = " where Email =  '" & cSessionUser._pUserID & "' and ModuleID='" & ModuleID & "' and AcctID='" & AcctID & "' and SeqID= '" & SeqID & "'"

            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False

                End If
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectSpecificAppDate(ByVal AppDate As String, ByVal Slot As String, ByVal Office As String)
        Try
            Dim _nQuery As String = Nothing
            '  _mQuery = " select Email,upper(registered.FirstName + ' ' + Registered.LastName) as Name,[TransDate],[AppDate],Slot, AppID, AcctID, TransType,Purpose, [Status],ServedBy,Remarks from Appointment INNER JOIN registered ON appointment.email = registered.[UserID] where Appointment.office='" & cSessionUser._pOffice & "' and Appointment.AppDate='" & cSessionLoader._pSelectedEventDate & "' and Appointment.Slot = '" & cSessionLoader._pSelectedEventTime & "' order by Appointment.appid asc"
            _mQuery = "  select A.Email,A.AcctID,A.Slot,a.AppID,A.Office,A.ServedBy,A.Status,A.TransType,A.Purpose,A.Remarks,A.AcctID,  	 " &
                " AppDate,   (format(A.TransDate,'MMMM dd, yyyy hh:mm') + ' ' + A.Slot)TransDate,    " &
                " case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',  " &
                " D.Department from Appointment A    Inner Join Department D on D.Usertype = A.Office    " &
                " where A.office='" & cSessionUser._pOffice & "' and A.AppDate='" & cSessionLoader._pSelectedEventDate & "' and A.Slot = '" & cSessionLoader._pSelectedEventTime & "' order by A.appid asc"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAllRequest(ByVal Office As String)
        Try
            Dim _nQuery As String = Nothing
            _mQuery = "Select * from Appointment where Office='" & Office & "' and Approved=0 and Status='Request Pending' order by transDate asc"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGenCode(ByRef GenCode As String)
        Try
            Dim _nQuery As String = Nothing
            Dim CTR As String
            Dim MonthNo As String
            _mQuery = "  select  top 1 Month(getdate()) AS MonthNo, (SELECT COUNT(Month(transdate))   FROM [Appointment] WHERE Month(transdate) = 12) as CTR FROM [Appointment]"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        MonthNo = _nSqlDr("MonthNo").ToString()
                        CTR = _nSqlDr("CTR").ToString().PadLeft(3, "0"c)
                    Loop
                Else

                End If
            End Using
            If CTR = 0 Then CTR = "001"
            If MonthNo < 10 Then MonthNo = "0" & MonthNo
            GenCode = "BPLOCSJDM" & CTR & "-" & MonthNo
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    ' Public Sub _pSubGenerateCode(code)
    '     Try
    '         Dim _nQuery As String = Nothing
    '         _nQuery = _
    '            "SELECT * from [Appointment] where Email='" & Email & "' order by [Date] desc"
    '         _mQuery = _nQuery
    '         _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
    '
    '     Catch ex As Exception
    '
    '     End Try
    '
    ' End Sub



    Public Sub _pSubAppointmentRequest(Status, Type, Email, Code, Remarks)
        Try
            Dim _nQuery As String = Nothing
            Select Case Status
                Case "Download"
                Case "Approve"
                    _nQuery = "update [Appointment] set  Status = 'Approved', Approved = 1, CodeUsed=0, Code='" & Code & "', Remarks='" & Remarks & "' where Email='" & Email & "' and TransType = '" & Type & "' "
                Case "Deny"
                    _nQuery = "update [Appointment] set  Status = 'Denied', Approved = 0, CodeUsed=0, Remarks='" & Remarks & "' where Email='" & Email & "' and TransType = '" & Type & "' "

            End Select
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectSpecificAttachment(ByVal Email As String, ByVal ReqDesc As String, ByVal AcctID As String, ByVal SeqID As String, ByRef FileData As Byte(), ByRef FileType As String, ByRef FileName As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] "
            _nWhere = " where Email =  '" & Email & "' and ReqDesc='" & ReqDesc & "' and AcctID='" & AcctID & "' and SeqID='" & SeqID & "' "
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        FileData = DirectCast(_nSqlDr("FileData"), Byte())
                        FileType = _nSqlDr("FileType").ToString()
                        FileName = _nSqlDr("FileName").ToString()
                    Loop
                End If
            End Using




            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAttachments(Office)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] where office='" & Office & "' and ModuleID = '" & cSessionLoader._pSelectedEventID & "'"
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectIdNo(EventDate, EventTime)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " SELECT * from [Appointment] where APPDATE =  '" & EventDate & "' and Slot='" & EventTime & "' "
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectCertAppointment(ByVal Office As String)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing

            _nQuery = "select [Email],registered.FirstName + ' ' + Registered.LastName as Name,convert(varchar, cast([TransDate] as datetime), 1) as [TransDate],convert(varchar, cast([AppDate] as datetime), 1) as [AppDate] ,Slot, AppID, AcctID, Owner, TransType,'' as [Action], [Status] from Appointment INNER JOIN registered ON appointment.email = registered.[UserID] where Appointment.office='" & Office & "' order by Appointment.[TransDate] desc"

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)







            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubValidateAppointment(ByVal EventDate As String, _
                                        ByVal EventTime As String, _
                                        ByVal Office As String, _
                                        ByRef valid As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            If EventTime = "AM" Then EventTime = "AM_Slot"
            If EventTime = "PM" Then EventTime = "PM_Slot"
            _nQuery = "SELECT AppDate, Beg_AM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>12 then 0   else  AM_Slot end as 'AM_Slot' , Beg_PM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>=17 then 0   else  PM_Slot end as 'PM_Slot', Color, Office FROM AppointmentSlot WHERE        (Office = '" & Office & "') AND (DATEADD(d, 1, AppDate) >= (SELECT        GETDATE() AS Expr1)) " & _
                " and Appdate = '" & EventDate & "' and " & EventTime & " >= 1"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        valid = True
                    Else
                        valid = False
                    End If
                End With

                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubAutoID(EventDate, EventTime)
        Try
            '----------------------------------       
            _pSubSelectIdNo(EventDate, EventTime)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iTime As Integer = .GetOrdinal("Slot")
                    Dim _iDate As Integer = .GetOrdinal("AppDate")
                    Dim _ictr As Integer = 1

                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _ictr = _ictr + 1
                            Loop
                            _mEventID = EventDate.Replace("-", "") & "-" & _ictr.ToString().PadLeft(5, "0"c)
                        Else
                            _mEventID = EventDate.Replace("-", "") & "-" & "00001"
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAppointment(Email, TransType, AppDate, AppTime, AppId, Owner, AcctID, Status, Remarks, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType], [AppDate], [Slot], [Remarks],[AppID],[Owner],[AcctID],[Status],[Office],[TransDate]) VALUES('" & Email & "','" & TransType & "','" & AppDate & "','" & AppTime & "','" & Remarks & "','" & AppId & "','" & Owner & "','" & AcctID & "','" & Status & "','" & Office & "',(SELECT GETDATE()))"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAppointmentOTHERS(ByVal Email As String, ByVal TransType As String, ByVal AppDate As String, ByVal AppTime As String, ByVal AppId As String, ByVal Owner As String, ByVal AcctID As String, ByVal Status As String, ByVal Remarks As String, ByVal Office As String, ByVal Purpose As String, ByVal Hash As String, Optional ByRef _err As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType], [AppDate], [Slot], [Remarks],[AppID],[Owner],[AcctID],[Status],[Office],[TransDate],[Purpose],[Hash]) VALUES('" & Email & "','" & TransType & "','" & AppDate & "','" & AppTime & "','" & Remarks & "','" & AppId & "','" & Owner & "','" & AcctID & "','" & Status & "','" & Office & "',(SELECT GETDATE()),'" & Purpose & "','" & Hash & "')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '_err = ";_pSubInsertAppointmentOTHERS:OK"
            '----------------------------------
        Catch ex As Exception
            _err = ";_pSubInsertAppointmentOTHERS:" & ex.Message
        End Try
    End Sub

    Public Sub _pSubInsertAppointmentRequest(ByVal Email As String, ByVal TransType As String, ByVal Office As String, ByVal Purpose As String, Optional ByRef _err As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType],[Office],[Purpose],[TransDate],[Approved],[Status]) VALUES('" & Email & "','" & TransType & "','" & Office & "','" & Purpose & "', (SELECT GETDATE()) ,0,'Request Pending')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
            _err = ";_pSubInsertAppointmentRequest:" & ex.Message
        End Try
    End Sub

    Public Sub _pSubIfAlreadyRequested(ByVal Email As String, ByVal TransType As String, ByVal Office As String, ByVal Purpose As String, ByRef isOK As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = "Select * from [Appointment] where " & _
                "Email='" & Email & "' and " & _
                "TransType='" & TransType & "' and " & _
                "Office='" & Office & "' and " & _
                "Purpose='" & Purpose & "'"
            '  "CodeUsed is null"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    If _nSqlDataReader.HasRows Then
                        isOK = False
                    Else
                        isOK = True
                    End If
                End With

                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubUpdateSpecificSlot(ByVal AppDate As Date, ByVal Office As String, ByVal AM_SLOT As Integer, ByVal PM_SLOT As Integer)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update AppointmentSlot set AM_Slot=" & AM_SLOT & ",PM_SLOT=" & PM_SLOT & " where office='" & Office & "' and AppDate='" & AppDate & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubUpdateAppointmentSlot(ByVal AppDate As String, ByVal AppTime As String, ByVal Office As String, Optional ByRef _err As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            If Trim(AppTime).ToUpper = "AM" Then
                _nQuery = "update [AppointmentSlot] set " _
                                   & " AM_Slot = (AM_Slot - 1) " _
                                   & " where AppDate='" & AppDate & "' and office='" & Office & "'"
            ElseIf Trim(AppTime).ToUpper = "PM" Then
                _nQuery = "update [AppointmentSlot] set " _
                                   & " PM_Slot = (PM_Slot - 1) " _
                                   & " where AppDate='" & AppDate & "' and office='" & Office & "'"
            Else
                _err = "Invalid AppTime"
                Exit Sub
            End If

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
            _err = ex.Message
        End Try
    End Sub

    Public Sub _pSubUpdateAppStatus(Status, AppID, ServedBy, Remarks)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update [Appointment] set  Status = '" & Status & "', ServedBy = '" & ServedBy & "', Remarks = '" & Remarks & "' where AppID='" & AppID & "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSetFlag(Email, msg, errID)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update [Registered] set  Barangay = 'Flagged:" & errID & ":" & msg & "' where UserID='" & Email & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectAppointmentReport(Office, AppType, AppStatus, AppFrom, AppTo, SortName) 'Gimay 20201027
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing

            If SortName = Nothing Then
                SortName = "Name"
            ElseIf SortName = "Appointment Type" Then
                SortName = "TransType"
            ElseIf SortName = "Appointment Date" Then
                SortName = "AppDateSlot"
            End If

            If AppType <> "All" Then

                If AppStatus = "All" Then
                    _nQuery = "Select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name', TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot , AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And AppDate   between '" & Trim(AppFrom) & "'   And '" & AppTo & "') xtb  order by xtb." & SortName

                ElseIf AppStatus = "Served" Then
                    _nQuery = " Select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType, (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "'And  [Status]='Served' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb order by xtb." & SortName

                ElseIf AppStatus = "Pending" Then
                    _nQuery = " Select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                 " And Transtype='" & AppType & "' And  [Status]='Pending' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb order by xtb." & SortName

                ElseIf AppStatus = "NoShow" Then
                    _nQuery = " Select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And  [Status]='NoShow' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb order xtb." & SortName

                End If

            Else
                If AppStatus = "All" Then
                    _nQuery = "select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType, (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    "  And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order by xtb." & SortName

                ElseIf AppStatus = "Served" Then
                    _nQuery = "select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot , AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And  [Status]='Served' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order xtb." & SortName

                ElseIf AppStatus = "Pending" Then
                    _nQuery = "select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                 " And Transtype='" & AppType & "' And  [Status]='Pending' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order xtb." & SortName

                ElseIf AppStatus = "NoShow" Then
                    _nQuery = "select * from (select case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner  else Owner  end 'Name',   TransType,  (cast(Format(AppDate,'MM/dd/yyyy') as nvarchar)  + ' ' + cast(Slot as nvarchar) ) as AppDateSlot, AppDate, Slot, AcctID, Status, (select top 1  Department from Department where Abbrev = a.Office) as Office, Remarks, AppID, Owner, TransDate, Purpose, ServedBy  from Appointment a where a.Office = '" & Office & "'" &
                    " And Transtype='" & AppType & "' And  [Status]='NoShow' And AppDate between '" & Trim(AppFrom) & "' And '" & AppTo & "') xtb  order xtb." & SortName

                End If
            End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)







            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Get_AppointmentTypes(ByVal Department As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing
            _nQuery = "Select *,replace(concat('<ul>',concat('<li>',replace([Body],';','</li><li>')),'</ul>'),'<li></ul>','</ul>')display from [AppointmentRequirements] where [Department] ='" & Department & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Get_AppointmentRequests(Optional ByVal Office As String = Nothing, Optional ByVal Type As String = Nothing, Optional ByVal Sort As String = Nothing, Optional ByVal Order As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing
         
            _nQuery = "Select DATENAME(MONTH,AppDate)  + ' ' + RIGHT('0' + DATENAME(DAY, AppDate), 2) + ', ' + DATENAME(YEAR, AppDate) AppDate2,* from Appointment where [STATUS] = 'Pending Approval'"

                If Office = "ALL" Then
                    _nWhere = ""
                Else
                    _nWhere += " and Office='" & Office & "'"
                End If

                If Type = "ALL" Then
                Else
                _nWhere += " and TransType='" & Type & "'"
                End If

            _nQuery += _nWhere & " order by " & Sort & " " & Order


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Get_AppointmentRequestsHistory()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing

            _nQuery = "Select  DATENAME(MONTH,AppDate)  + ' ' + RIGHT('0' + DATENAME(DAY, AppDate), 2) + ', ' + DATENAME(YEAR, AppDate) AppDate2, *  from Appointment where isnull(RequestStatus,'0') <> '0' and Office='" & cSessionUser._pOffice & "' order by RequestProcessDate desc"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Get_Departments()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = "select DepartmentCode,Department,Usertype,isnull(Regulatory,'false')Regulatory from Department"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Remove_AppointmentTypes(ByVal Department As String, ByVal Type As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Delete From [AppointmentRequirements] where Department = '" & Department & "' and Type='" & Type & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Remove_Department(ByVal DepartmentCode As String, ByVal UserType As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Delete From Department where DepartmentCode = '" & DepartmentCode & "' and UserType='" & UserType & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Function _getNotificationCtr_Regulatory(ByVal Office As String, Optional ByRef ctr2 As Integer = 0) As Integer
        Dim ctr As String = 0
        Try
            Dim _nQuery As String =
    " Select" &
    " ( select count(*)ctrAL " &
    " from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Appointment " &
    " where office='" & Office & "' and status='Pending' and appdate = getdate())ctrAL," &
    " ( select count(*)ctrAL " &
    "  from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Appointment " &
    "  where office='" & Office & "' and status='Pending Approval' )ctrAR"

            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        ctr = _nSqlDr("ctrAL").ToString
                        ctr2 = _nSqlDr("ctrAR").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception
        End Try
        Return ctr
    End Function
    Public Function Get_SchedulerHistory(Optional ByVal SearchBy As String = Nothing, Optional ByVal SearchTxt As String = Nothing) As DataTable
        Try
            Dim _Query As String = Nothing
            Dim _where As String = Nothing

            _Query =
             "  select A.Email,A.AppID,A.TransType,A.Purpose,A.Remarks,A.AcctID," &
             "  (format(A.AppDate,'MMMM dd, yyyy') + ' ' + A.Slot)NewAppDate, " &
             "  (format(A.TransDate,'MMMM dd, yyyy hh:mm') + ' ' + A.Slot)NewTransDate, " &
             "  case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner" &
             "  else (SELECT SUBSTRING(A.Owner,0,CHARINDEX(';',A.Owner,0)))  end 'NewName'," &
             "  case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Email" &
             "  else (SELECT SUBSTRING(A.Owner,CHARINDEX(';',A.Owner)+1,LEN(A.Owner)) )  end 'NewContact'," &
             "  D.Department from Appointment A    Inner Join Department D on D.Usertype = A.Office  " &
             "  WHERE A.AppDate >='" & AppDateFrom & "' and A.AppDate <= '" & AppDateTo & "' and A.TransDate >='" & TransDateFrom & "' and A.TransDate <= '" & TransDateTo & "' "

            If String.IsNullOrEmpty(SearchBy) Or String.IsNullOrEmpty(Trim(SearchTxt)) Then
                If ScheduledBy = "ALL2" Then
                    _where += " and A.Email in (select userid from registered where office='APPT')"
                ElseIf ScheduledBy <> "ALL" Then
                    _where += " and A.Email='" & ScheduledBy & "'"
                End If
                If Department <> "ALL" Then
                    _where += " and A.Office='" & Department & "'"
                End If
            Else
                _where = " and " & SearchBy & " like '%" & Trim(SearchTxt) & "%' "
            End If

            _Query += _where & " order by " & SortByCode & " " & OrderCode
            _mSqlCommand = New SqlCommand(_Query, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            Return _mDataTable
        Catch ex As Exception

        End Try
    End Function

    Public Function Gen_DeptCode() As String
        Dim DeptCode As String = Nothing
        Try
            Dim _mQuery As String =
              "Select concat(FORMAT (getdate(), 'yyyy-' ), (SELECT REPLACE(STR((select count(*) from Department where LEFT(DepartmentCode, 3) =year(getdate()) ),3),' ','0')) )  as NewDeptCode"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        DeptCode = _nSqlDr("NewDeptCode").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception
        End Try
        Return DeptCode
    End Function

    Public Sub Insert_Department(ByVal DepartmentCode As String, ByVal DepartmentDesc As String, ByVal UserType As String, ByVal Regulatory As Boolean)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "insert into DEPARTMENT(DepartmentCode,Department,Usertype,Regulatory)" &
                " VALUES(@DepartmentCode,@Department,@Usertype,@Regulatory);"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@DepartmentCode", DepartmentCode)
                .AddWithValue("@Department", DepartmentDesc.ToUpper)
                .AddWithValue("@Usertype", UserType.ToUpper)
                .AddWithValue("@Regulatory", Regulatory)
            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Function isExists(ByVal DeptCode As String, ByVal DepartmentDesc As String, ByVal UserType As String) As Boolean
        Dim Exists As Boolean = False
        Try
            Dim _mQuery As String =
              "Select * from Department where  DepartmentCode = '" & DeptCode & "' OR  Department='" & DepartmentDesc & "' "
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False
                End If
            End Using
        Catch ex As Exception
        End Try
        Return Exists
    End Function

    Public Function Get_AppointmentSlip(ByVal AppID As String) As DataTable
        Try
            Dim _Query As String =
                " select A.Email,A.AppID,A.TransType,A.Purpose,A.Remarks,A.AcctID," &
                " (format(A.AppDate,'MMMM dd, yyyy') + ' ' + A.Slot)APPDATE, " &
                " (format(A.TransDate,'MMMM dd, yyyy hh:mm') + ' ' + A.Slot)TRANSDATE," &
                " case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Owner" &
                " else (SELECT SUBSTRING(A.Owner,0,CHARINDEX(';',A.Owner,0)))  end 'NAME'," &
                " case when isnull((select userid from registered where office='APPT' and userid=A.Email),'0')='0' then Email" &
                " else (SELECT SUBSTRING(A.Owner,CHARINDEX(';',A.Owner)+1,LEN(A.Owner)) )  end 'CONTACT'," &
                " D.Department from Appointment A    Inner Join Department D on D.Usertype = A.Office " &
                "WHERE A.AppID ='" & AppID & "'"
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            Return _mDataTable
        Catch ex As Exception
        End Try
    End Function


    Public Function Get_DataSet(ByVal cmbName As String) As DataSet
        Try
            Select Case cmbName
                Case "cmbScheduledBy"
                    _mQuery = " select distinct (A.email)Code,(concat(R.LastName,', ',R.FirstName))Description from appointment A " &
                              " inner join registered R on A.email = R.userid" &
                              " where A.email in (select userid from Registered where office='APPT') " &
                              " order by concat(R.LastName,', ',R.FirstName) asc"
                Case "cmbDepartment"
                    _mQuery = " select distinct (A.Office)Code,(D.Department)Description from appointment A" &
                              " Inner Join Department D on D.Usertype = A.Office order by office asc"
            End Select

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            Dim _mDataSet = New DataSet()
            _nSqlDataAdapter.Fill(_mDataSet)
            Return _mDataSet
        Catch ex As Exception

        End Try
    End Function

    Public Sub Get_DateRange(ByRef AppDateFrom As Date, ByRef AppDateTo As Date, ByRef TransDateFrom As Date, ByRef TransDateTo As Date)
        Try
            Dim _mQuery As String =
                " Select " &
                "	DATEADD(day, -1, min(Appdate))AppDateFrom ," &
                "	DATEADD(day, 1, max(Appdate))AppDateTo ," &
                "	DATEADD(day, -1, min(TransDate))TransDateFrom ," &
                "	DATEADD(day, 1, max(TransDate))TransDateTo" &
                " from Appointment "
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        AppDateFrom = _nSqlDr("AppDateFrom")
                        AppDateTo = _nSqlDr("AppDateTo")
                        TransDateFrom = CDate(Format(_nSqlDr("TransDateFrom"), "MM-dd-yyyy"))
                        TransDateTo = CDate(Format(_nSqlDr("TransDateTo"), "MM-dd-yyyy"))
                    Loop
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Public Function Get_UploadedSupDoc(ByVal AppID As String, ByRef FileData As Byte(), ByRef FileName As String, ByRef FileType As String, Optional ByRef ProcessedBy As String = Nothing, Optional ByRef ProcessRemarks As String = Nothing, Optional ByRef Status As String = Nothing, Optional ByRef err As String = Nothing)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                    " select" &
                    " Att.FileData,Att.FileName,Att.FileType,App.RequestProcessBy,App.RequestRemarks,App.RequestStatus" &
                    " from Attachment Att " &
                    " inner join Appointment App on Att.Refno=App.AppID" &
                    " where Att.RefNo='" & AppID & "'"


            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim iFileData As Integer = .GetOrdinal("FileData")
                    Dim iFileName As Integer = .GetOrdinal("FileName")
                    Dim iFileType As Integer = .GetOrdinal("FileType")
                    Dim iProcessedBy As Integer = .GetOrdinal("RequestProcessBy")
                    Dim iStatus As Integer = .GetOrdinal("RequestStatus")
                    Dim iProcessRemarks As Integer = .GetOrdinal("RequestRemarks")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                FileData = ._pReturnByteArray(_nSqlDataReader(iFileData))
                                FileName = ._pReturnString(_nSqlDataReader(iFileName))
                                FileType = ._pReturnString(_nSqlDataReader(iFileType))
                                ProcessedBy = ._pReturnString(_nSqlDataReader(iProcessedBy))
                                Status = ._pReturnString(_nSqlDataReader(iStatus))
                                ProcessRemarks = ._pReturnString(_nSqlDataReader(iProcessRemarks))
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception
            err = ex.Message
        End Try
    End Function

    Public Function get_RemainingSlot(ByVal AppID As String, Optional ByRef err As String = Nothing) As Integer
        Dim result As Integer = 0
        Try
            Dim _mQuery As String =
                "SELECT " &
                "	A2.AppId," &
                "    A1.AppDate," &
                "	A2.Slot," &
                "    A1.Office,	" &
                "    CASE " &
                "        WHEN A2.Slot = 'AM' THEN A1.AM_Slot" &
                "        WHEN A2.Slot = 'PM' THEN A1.PM_Slot" &
                "    END AS RemainingSlots" &
                "    FROM" &
                "    Appointmentslot A1" &
                "    INNER Join" &
                "    Appointment A2 ON A1.Office = A2.Office AND A1.AppDate = A2.AppDate" &
                "    WHERE" &
                "    A2.AppID = '" & AppID & "';"

            _mSqlCommand = New SqlCommand(_mQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("RemainingSlots")
                    Loop
                End If
            End Using

            Return result
        Catch ex As Exception
            err = ex.Message
        End Try
    End Function

    Public Sub Update_Table()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                " IF NOT EXISTS ( " &
                " SELECT * FROM sys.columns" &
                " WHERE Name IN ('RequestProcessDate','RequestRemarks','RequestProcessBy','RequestStatus')" &
                " AND OBJECT_ID = OBJECT_ID('APPOINTMENT')" &
                " )" &
                " BEGIN" &
                " EXEC('" &
                " ALTER TABLE APPOINTMENT" &
                " ADD RequestProcessDate DATETIME," &
                " RequestRemarks NVARCHAR(MAX)," &
                " RequestProcessBy NVARCHAR(MAX)," &
                " RequestStatus NVARCHAR(MAX)" &
                " ');" &
                " End"
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Update_AppointmentRequest(ByVal AppID As String, ByVal RequestRemarks As String, ByVal RequestStatus As String, ByVal Status As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                " Update Appointment Set RequestProcessDate=getdate(),RequestRemarks='" & RequestRemarks & "',RequestProcessBy='" & cSessionUser._pUserID & "',RequestStatus='" & RequestStatus & "',Status='" & Status & "' where AppID='" & AppID & "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

#End Region

End Class
