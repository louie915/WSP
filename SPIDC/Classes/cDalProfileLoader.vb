Imports System.Data.SqlClient

Public Class cDalProfileLoader

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mQuery As String = Nothing
    Private _mSqlDataReader As SqlDataReader
    Private _mDataTable As DataTable
#End Region

#Region "Variables Field"
    Private _mFirstName As String
    Private _mMiddleName As String
    Private _mLastName As String
    Private _mExt As String
    Private _mEmail As String
    Private _mAddress As String
    Private _mBirthDay As Date
    Private _mBirthPlace As String
    Private _mCitizenship As String
    Private _mGender As String
    Private _mCivilStatus As String
    Private _mProfession As String
    Private _mTIN As String
    Private _mContactNumber1 As String
    Private _mContactNumber2 As String
    Private _mContactNumber3 As String
    Private _mHeight As String
    Private _mWeight As String
    Private _mResident As String
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
    Private Shared Isupload As Boolean = False
    'Private Shared _mCounter As Boolean

    Private Shared _mAlternateEmail As String 'Gimay 20201120
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

    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_pSqlCmd)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Properties Field"

    Public Property _pAlternateEmail As String 'Gimay 20201120
        Get
            Return _mAlternateEmail
        End Get
        Set(value As String)
            _mAlternateEmail = value
        End Set
    End Property

    Public Property _pFirstName As String
        Get
            Return _mFirstName
        End Get
        Set(value As String)
            _mFirstName = value
        End Set
    End Property

    Public Property _pMiddleName As String
        Get
            Return _mMiddleName
        End Get
        Set(value As String)
            _mMiddleName = value
        End Set
    End Property

    Public Property _pLastName As String
        Get
            Return _mLastName
        End Get
        Set(value As String)
            _mLastName = value
        End Set
    End Property

    Public Property _pExt As String
        Get
            Return _mExt
        End Get
        Set(value As String)
            _mExt = value
        End Set
    End Property

    Public Property _pEmail As String
        Get
            Return _mEmail
        End Get
        Set(value As String)
            _mEmail = value
        End Set
    End Property

    Public Property _pAddress As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
        End Set
    End Property

    Public Property _pBirthDay As Date
        Get
            Return _mBirthDay
        End Get
        Set(value As Date)
            _mBirthDay = value
        End Set
    End Property

    Public Property _pBirthPlace As String
        Get
            Return _mBirthPlace
        End Get
        Set(value As String)
            _mBirthPlace = value
        End Set
    End Property

    Public Property _pCitizenship As String
        Get
            Return _mCitizenship
        End Get
        Set(value As String)
            _mCitizenship = value
        End Set
    End Property

    Public Property _pGender As String
        Get
            Return _mGender
        End Get
        Set(value As String)
            _mGender = value
        End Set
    End Property

    Public Property _pCivilStatus As String
        Get
            Return _mCivilStatus
        End Get
        Set(value As String)
            _mCivilStatus = value
        End Set
    End Property

    Public Property _pProfession As String
        Get
            Return _mProfession
        End Get
        Set(value As String)
            _mProfession = value
        End Set
    End Property

    Public Property _pTin As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
        End Set
    End Property

    Public Property _pContactNumber1 As String
        Get
            Return _mContactNumber1
        End Get
        Set(value As String)
            _mContactNumber1 = value
        End Set
    End Property

    Public Property _pContactNumber2 As String
        Get
            Return _mContactNumber2
        End Get
        Set(value As String)
            _mContactNumber2 = value
        End Set
    End Property

    Public Property _pContactNumber3 As String
        Get
            Return _mContactNumber3
        End Get
        Set(value As String)
            _mContactNumber3 = value
        End Set
    End Property

    Public Property _pHeight As String
        Get
            Return _mHeight
        End Get
        Set(value As String)
            _mHeight = value
        End Set
    End Property

    Public Property _pWeight As String
        Get
            Return _mWeight
        End Get
        Set(value As String)
            _mWeight = value
        End Set
    End Property

    Public Property _pResident As String
        Get
            Return _mResident
        End Get
        Set(value As String)
            _mResident = value
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

    Public Shared Property pIsupload As Boolean
        Get
            Return Isupload
        End Get
        Set(value As Boolean)
            Isupload = value
        End Set
    End Property


#End Region

#Region "Routine"
    Public Sub loadProfile()
        Try
            Dim _nQuery As String

            'Gimay 20201120 added alternate email field
            _nQuery = "SELECT LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace,Address, Profession, TIN, CivilStatus, Citizenship, Gender, Contact_Tel, Contact_Cp, Contact_Cp_Alt, Height, Weight, Resident, isnull(AlternateEmail,'') as AlternateEmail" &
                " FROM Registered" &
                " WHERE UserID = '" & _pEmail & "'"


            '_nQuery = "SELECT LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace, Address, Profession, TIN, CivilStatus, Citizenship, Gender, Contact_Tel, Contact_Cp, Contact_Cp_Alt, Height, Weight, Resident" & _
            '    " FROM Registered" & _
            '    " WHERE UserID = '" & _pEmail & "'"

            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader()

            Do Until _mSqlDataReader.Read = False
                _pFirstName = _mSqlDataReader.Item(1).ToString()
                _pMiddleName = _mSqlDataReader.Item(2).ToString()
                _pLastName = _mSqlDataReader.Item(0).ToString()
                _pExt = _mSqlDataReader.Item(3).ToString()
                _pAddress = _mSqlDataReader.Item(6).ToString()
                _pBirthDay = _mSqlDataReader.Item(4).ToString()
                _pBirthPlace = _mSqlDataReader.Item(5).ToString()
                _pCitizenship = _mSqlDataReader.Item(10).ToString()
                _pProfession = _mSqlDataReader.Item(7).ToString()
                _pTin = _mSqlDataReader.Item(8).ToString()
                _pGender = _mSqlDataReader.Item(11).ToString()
                _pCivilStatus = _mSqlDataReader.Item(9).ToString()
                _pContactNumber1 = _mSqlDataReader.Item(12).ToString()
                _pContactNumber2 = _mSqlDataReader.Item(13).ToString()
                _pContactNumber3 = _mSqlDataReader.Item(14).ToString()
                _pHeight = _mSqlDataReader.Item(15).ToString()
                _pWeight = _mSqlDataReader.Item(16).ToString()
                _pResident = _mSqlDataReader.Item(17).ToString()
                _pAlternateEmail = _mSqlDataReader.Item(18).ToString() 'Gimay 20201120
            Loop

            _mSqlCmd.Dispose()
            _mSqlDataReader.Close()
        Catch ex As Exception

        End Try
    End Sub

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

    Public Sub ClearFile()

        _mGIdName = Nothing
        _mGIdType = Nothing
        _mGIdData = Nothing
        _mSPAName = Nothing
        _mSPAType = Nothing
        _mSPAData = Nothing
        _mBRSecName = Nothing
        _mBRSecType = Nothing
        _mBRSecData = Nothing

    End Sub

    Public Sub UpdateFiles()
        Dim _mSqlReader As SqlDataReader
        Dim temp As String
        Dim Counter As Boolean
        Dim _nQuery As String = ""
        Try
            _nQuery = "SELECT SEQID, MODULEID FROM ATTACHMENT where EMAIL = '" & _mEmail & "' and MODULEID = 'Change/Update Contact Informations'"
            _mSqlCmd = New SqlCommand(_nQuery, _pSqlCon)
            _mSqlReader = _mSqlCmd.ExecuteReader
            _nQuery = ""
            Dim _ModuleID As String = Nothing, _Requirement As String = Nothing, _AcctID As String = Nothing
            Dim _FileName As String = Nothing, _FileType As String = Nothing, _FileData As Byte() = Nothing
            Dim _ParamData As String = Nothing, _Seqid As String = Nothing
            If _mSqlReader.HasRows Then
                While _mSqlReader.Read()
                    Select Case _mSqlReader.Item("SEQID")
                        Case "001"
                            _ModuleID = "Change/Update Contact Informations"
                            _Requirement = "Requirement 1"
                            _AcctID = "Government ID"
                            _FileName = _mGIdName
                            _FileType = _mGIdType
                            _FileData = _mGIdData
                            _ParamData = "@GIdData"
                            _mCheckGId = True
                        Case "002"
                            _ModuleID = "Change/Update Contact Informations"
                            _Requirement = "Requirement 2"
                            _AcctID = "Special Power of Attorney"
                            _FileName = _mSPAName
                            _FileType = _mSPAType
                            _FileData = _mSPAData
                            _ParamData = "@SPAData"
                            _mCheckSPA = True
                        Case "003"
                            _ModuleID = "Change/Update Contact Informations"
                            _Requirement = "Requirement 3"
                            _AcctID = "Board Resolution/Secretary Certificate"
                            _FileName = _mBRSecName
                            _FileType = _mBRSecType
                            _FileData = _mBRSecData
                            _ParamData = "@BRSecData"
                            _mCheckBRSec = True
                    End Select
                    If IsDBNull(_mSqlReader.Item("SEQID")) Then
                        temp = 1
                        Select Case _mSqlReader.Item("SEQID")
                            Case "001" : _mCheckGId = True : Case "002" : _mCheckSPA = True : Case "003" : _mCheckBRSec = True
                        End Select
                        _nQuery += "Insert into Attachment(EMAIL,REFNO,MODULEID,ACCTID,SEQID,FileData,FileName,FileType,ReqDesc,OFFICE) " & _
                            "VALUES ('" & _mEmail & "','0','" & _ModuleID & "','" & _AcctID & "', '" & _mSqlReader.Item("SEQID") & ", " & _ParamData & _
                            _FileName & "','" & _FileType & "', '" & _Requirement & "','BPLO'); "
                    Else
                        _nQuery += "update Attachment set FileData = " & _ParamData & ", FileName = '" & _FileName & "', FileType = '" & _FileType & "' where EMAIL = '" & _mEmail & _
                                "' and SeqID = '" & _mSqlReader.Item("SEQID") & "'  and MODULEID = '" & _ModuleID & "' ;"
                    End If
                End While
            End If
            _FileName = Nothing
            _FileType = Nothing
            _FileData = Nothing
            For a As Integer = 0 To 2
                Select Case False
                    Case _mCheckGId
                        _ModuleID = "Change/Update Contact Informations"
                        _Requirement = "Requirement 1"
                        _AcctID = "Government ID"
                        _FileName = _mGIdName
                        _FileType = _mGIdType
                        _FileData = _mGIdData
                        _ParamData = "@GIdData"
                        _mCheckGId = True
                        _Seqid = "001"
                    Case _mCheckSPA
                        _ModuleID = "Change/Update Contact Informations"
                        _Requirement = "Requirement 2"
                        _AcctID = "Special Power of Attorney"
                        _FileName = _mSPAName
                        _FileType = _mSPAType
                        _FileData = _mSPAData
                        _ParamData = "@SPAData"
                        _mCheckSPA = True
                        _Seqid = "002"
                    Case _mCheckBRSec
                        _ModuleID = "Change/Update Contact Informations"
                        _Requirement = "Requirement 3"
                        _AcctID = "Board Resolution/Secretary Certificate"
                        _FileName = _mBRSecName
                        _FileType = _mBRSecType
                        _FileData = _mBRSecData
                        _ParamData = "@BRSecData"
                        _mCheckBRSec = True
                        _Seqid = "003"
                End Select
                If Not _FileData Is Nothing Then
                    _nQuery += "Insert into Attachment(EMAIL,REFNO,MODULEID,ACCTID,SEQID,FileData,FileName,FileType,ReqDesc,OFFICE) " & _
                            "VALUES ('" & _mEmail & "','0','" & _ModuleID & "','" & _AcctID & "', '" & _Seqid & "', " & _ParamData & " ,'" & _FileName & "','" & _FileType & "', '" & _Requirement & "','BPLO'); "
                End If

                _FileName = Nothing
                _FileType = Nothing
                _FileData = Nothing
            Next

            _mSqlCmd = New SqlCommand(_nQuery, _pSqlCon)

            With _mSqlCmd.Parameters
                If Not _mGIdData Is Nothing Then
                    .AddWithValue("@GIdData", _mGIdData)
                End If
                If Not _mSPAData Is Nothing Then
                    .AddWithValue("@SPAData", _mSPAData)
                End If
                If Not _mBRSecData Is Nothing Then
                    .AddWithValue("@BRSecData", _mBRSecData)
                End If
            End With

            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()

            Uploadfilesreset()


        Catch ex As Exception

        End Try
    End Sub

    Public Sub Uploadfilesreset()
        _mCheckGId = Nothing
        _mCheckSPA = Nothing
        _mCheckBRSec = Nothing

        _mGIdName = Nothing
        _mGIdType = Nothing
        _mGIdData = Nothing

        _mSPAName = Nothing
        _mSPAType = Nothing
        _mSPAData = Nothing

        _mBRSecName = Nothing
        _mBRSecType = Nothing
        _mBRSecData = Nothing
    End Sub

    Public Sub saveProfile()
        Try
            Dim _nQuery As String

            '_nQuery = "UPDATE Registered" & _
            '    " SET LastName = '" & _pLastName & "', Firstname = '" & _pFirstName & "', MiddleName = '" & _pMiddleName & "', ExtnName = '" & _pExt & "', BirthDate = convert(datetime, '" & _pBirthDay & "', 101), BirthPlace = '" & _pBirthPlace & "'," & _
            '    " Address = '" & _pAddress & "', Profession = '" & _pProfession & "', TIN = '" & _pTin & "', CivilStatus = '" & _pCivilStatus & "', Citizenship = '" & _pCitizenship & "', Gender = '" & _pGender & "', Contact_Tel = '" & _pContactNumber1 & "'," & _
            '    " Contact_Cp = '" & _pContactNumber2 & "', Contact_Cp_Alt = '" & _pContactNumber3 & "', Height = '" & _pHeight & "', Weight = '" & _pWeight & "', Resident = '" & _pResident & "'" & _
            '    ",userlevel=1 WHERE UserID = '" & _pEmail & "' ; "

            'Gimay 2020201120 added alternate email field
            _nQuery = "UPDATE Registered" &
                " SET LastName = '" & _pLastName & "', Firstname = '" & _pFirstName & "', MiddleName = '" & _pMiddleName & "', ExtnName = '" & _pExt & "', BirthDate = convert(datetime, '" & _pBirthDay & "', 101), BirthPlace = '" & _pBirthPlace & "'," &
                " Address = '" & _pAddress & "', Profession = '" & _pProfession & "', TIN = '" & _pTin & "', CivilStatus = '" & _pCivilStatus & "', Citizenship = '" & _pCitizenship & "', Gender = '" & _pGender & "', Contact_Tel = '" & _pContactNumber1 & "'," &
                " Contact_Cp = '" & _pContactNumber2 & "', Contact_Cp_Alt = '" & _pContactNumber3 & "', Height = '" & _pHeight & "', Weight = '" & _pWeight & "', Resident = '" & _pResident & "', AlternateEmail='" & _pAlternateEmail & "' " &
                ",userlevel=1 WHERE UserID = '" & _pEmail & "' ; "


            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)

            _mSqlCmd.ExecuteNonQuery()

            _mSqlCmd.Dispose()

            'UpdateFiles()

        Catch ex As Exception

        End Try
    End Sub

    Public Function getSecurityQuestion() As String
        Try
            Dim res As String = Nothing
            Dim _nQuery As String = Nothing

            _nQuery = "SELECT * FROM Registered" & _
                " WHERE USERID = '" & _pEmail & "'"

            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader

            Do Until _mSqlDataReader.Read = False
                res = _mSqlDataReader("SecurityQ")
            Loop

            _mSqlDataReader.Close()
            _mSqlCmd.Dispose()

            Select Case res
                Case "1"
                    res = "What's your pet's name?"

                Case "2"
                    res = "What primary school did you attend?"

                Case "3"
                    res = "In what town or city was your first full time job?"

                Case "4"
                    res = "In what town or city did you meet your spouse/partner?"

                Case "5"
                    res = "What are the last five digits of your driver's licence number?"

                Case "6"
                    res = "What was the house number and street name you lived in as a child?"

                Case "7"
                    res = "What were the last four digits of your childhood telephone number?"

            End Select

            Return res
        Catch ex As Exception

        End Try
    End Function

    Public Function getSecurityAnswer() As String
        Try
            Dim res As String = Nothing
            Dim _nQuery As String = Nothing

            _nQuery = "SELECT * FROM Registered" & _
                " WHERE USERID = '" & _pEmail & "'"

            _pQuery = _nQuery

            _mSqlCmd = New SqlCommand(_pQuery, _pSqlCon)
            _mSqlDataReader = _mSqlCmd.ExecuteReader

            Do Until _mSqlDataReader.Read = False
                res = _mSqlDataReader("SecurityA")
            Loop

            _mSqlDataReader.Close()
            _mSqlCmd.Dispose()

            Return res
        Catch ex As Exception

        End Try
    End Function




    'archie 20201126
    Public Sub _pSubSelectImage(ByVal Email As String, ByVal ModuleID As String, ByVal AcctID As String, ByVal SeqID As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Attachment] "
            _nWhere = " where Email =  '" & cSessionUser._pUserID & "' and ModuleID='" & ModuleID & "' and AcctID='" & AcctID & "' and SeqID= '" & SeqID & "'"

            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
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

    'archie 20201126
    Public Sub _pSubInsertAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO Attachment VALUES(@Email,@RefNo,@ModuleID,@AcctID,@SeqID,@FileData,@FileName,@FileType,@ReqDesc,@Office)"
            Dim _mSqlCmd As New SqlCommand(_nQuery, _mSqlCon)

            With _mSqlCmd.Parameters
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
            _mSqlCmd.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    'archie 20201126
    Public Sub _pSubUpdateAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update Attachment SET FileData = @FileData, FileName = @FileName, FileType = @FileType " &
                      " where Email=@Email and ModuleID=@ModuleID and AcctID=@AcctID and SeqID=@SeqID"
            Dim _mSqlCmd As New SqlCommand(_nQuery, _mSqlCon)

            With _mSqlCmd.Parameters
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
            _mSqlCmd.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    ''MCE 20201203
    Public Sub _pSubSelectAttachment()


        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT '1'r,tab2.Email, tab2.[Government ID] as 'Name1'  ,tab2.[Special Power of Attorney] as 'Name2'  ,tab2.[Board Resolution/Secretary Certificate]  as 'Name3'  " &
", tab22.[Government ID] as 'Data1'  ,tab22.[Special Power of Attorney] as 'Data2'  ,tab22.[Board Resolution/Secretary Certificate] as 'Data3'					  " &
"FROM (SELECT Email, FileName , AcctID FROM attachment )Tab1  PIVOT  																							  " &
"(MAX(FileName) FOR ACCTID IN ([Government ID],[Special Power of Attorney],[Board Resolution/Secretary Certificate])		 										  " &
")AS Tab2  inner join   (SELECT Email, filedata , AcctID FROM attachment )Tab12  																			  " &
"PIVOT (MAX(filedata) FOR ACCTID IN ([Government ID],[Special Power of Attorney],[Board Resolution/Secretary Certificate]) 										  " &
") AS Tab22  on Tab2.EMAIL = Tab22.EMAIL Where tab2.EMAIL  in (Select EMAIL from Attachment Where ModuleID = 'Change/Update Contact Informations')		  "



            _mSqlCmd = New SqlCommand(_nQuery, _mSqlCon)
            With _mSqlCmd.Parameters
            End With

        Catch ex As Exception

        End Try
    End Sub




    Public Sub _pSubSelectSpecificAttachment(ByVal Email As String, ByVal FileName As String, ByVal Val As String, ByRef FileType As String, ByRef FileData As Byte())
        Dim _nQuery As String = Nothing
        If Val = "001" Then

            _nQuery = "SELECT  top 1 tab2.Email, tab2.[Government ID] as 'FileName',tab22.[Government ID] as 'FileData' ,FileType FROM   " &
    "(SELECT Email, FileName , AcctID,FileType FROM attachment )Tab1  												 " &
    "PIVOT (MAX(FileName) FOR ACCTID IN ([Government ID]))AS Tab2													 " &
    "inner join   (SELECT Email, filedata , AcctID FROM attachment)Tab12  											 " &
    "PIVOT (MAX(filedata) FOR ACCTID IN ([Government ID])) 															 " &
    "AS Tab22 on Tab2.EMAIL = Tab22.EMAIL where tab2.EMAIL ='" & Email & "'                                "

        ElseIf Val = "002" Then

            _nQuery = "SELECT top 1 tab2.Email, tab2.[Special Power of Attorney] as 'FileName',tab22.[Special Power of Attorney] as 'FileData' ,FileType FROM " &
"(SELECT Email, FileName , AcctID,FileType FROM attachment )Tab1  						" &
"PIVOT (MAX(FileName) FOR ACCTID IN ([Special Power of Attorney]))AS Tab2				" &
"inner join   (SELECT Email, filedata , AcctID FROM attachment)Tab12  					" &
"PIVOT (MAX(filedata) FOR ACCTID IN ([Special Power of Attorney])) 						" &
"AS Tab22 on Tab2.EMAIL = Tab22.EMAIL where tab2.EMAIL = '" & Email & "' 		"

        ElseIf Val = "003" Then
            _nQuery = "SELECT top 1 tab2.Email, tab2.[Board Resolution/Secretary Certificate] as 'FileName',tab22.[Board Resolution/Secretary Certificate] as 'FileData' ,FileType FROM  " &
"(SELECT Email, FileName , AcctID,FileType FROM attachment )Tab1  						   " &
"PIVOT (MAX(FileName) FOR ACCTID IN ([Board Resolution/Secretary Certificate]))AS Tab2	   " &
"inner join   (SELECT Email, filedata , AcctID FROM attachment)Tab12  					   " &
"PIVOT (MAX(filedata) FOR ACCTID IN ([Board Resolution/Secretary Certificate])) 		   " &
"AS Tab22 on Tab2.EMAIL = Tab22.EMAIL where tab2.EMAIL= '" & Email & "'     	   "
        End If

        _mSqlCmd = New SqlCommand(_nQuery, _mSqlCon)
        _mSqlDataReader = _mSqlCmd.ExecuteReader

        With _mSqlCmd.Parameters

            Do While _mSqlDataReader.Read
                FileData = _mSqlDataReader("FileData")
                FileType = _mSqlDataReader("FileType")
            Loop

        End With

        _mSqlDataReader.Dispose()
        _mSqlCmd.Dispose()
    End Sub

    Public Sub _pSubDeleteSpecificAttachment(ByVal Email As String, ByVal FileName As String, ByVal Val As String)
        Dim _nQuery As String = Nothing
        _nQuery = "Delete from Attachment Where EMAIL='" & Email & "' And [FileName]='" & FileName & "' And SEQID='" & Val & "'"
        _mSqlCmd = New SqlCommand(_nQuery, _mSqlCon)
        _mSqlCmd.ExecuteNonQuery()
        _mSqlCmd.Dispose()
    End Sub
#End Region

End Class