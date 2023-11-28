
#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Data
Imports Microsoft.VisualBasic.Devices 'CARL IMPORT
Imports System.IO
Imports System.Drawing


#End Region

Public Class cDalHRIMS

    Inherits System.Web.UI.Page


#Region "Variables JOJIE"
    Private Shared _mHRIMS_RegLink As String
    Public Shared xapplicantEmailID As String
    Public Shared xQues34a As String
    Public Shared xQues34b As String
    Public Shared xQues35a As String
    Public Shared xQues35b As String
    Public Shared xQues36 As String
    Public Shared xQues37 As String
    Public Shared xQues38a As String
    Public Shared xQues38b As String
    Public Shared xQues39 As String
    Public Shared xQues40a As String
    Public Shared xQues40b As String
    Public Shared xQues40c As String

    Private Const _sscPrefix As String = "cSessionLoader."
    Private Const _sscDone As String = _sscPrefix & "_sscDone"
    Public xuser As String
    Public xidno As String
    Public Shared xemp_no As String

#End Region

#Region "Variables Data"
    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Public Shared xapplicantidno As String
    Public Shared xapplicantEmail As String
    Public Shared xapplicantItemno As String
    Public Shared xapplicantName As String
    Public Shared xpostiontitle As String '20200521
#End Region

#Region "Properties Data"

    Public Shared Property _pHRIMS_RegLink() As String
        Get
            Return _mHRIMS_RegLink
        End Get
        Set(value As String)
            _mHRIMS_RegLink = value
        End Set
    End Property

    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlConnection = value
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


#End Region

#Region "Properties Field"



    Shared Property _pDone() As String
        Get
            Return Current.Session(_sscDone)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDone) = value
        End Set
    End Property

    Public Property _puser As String
        Get
            Return xuser
        End Get
        Set(ByVal value As String)
            xuser = value
        End Set
    End Property
    Public Property _pxidno As String
        Get
            Return xidno
        End Get
        Set(ByVal value As String)
            xidno = value
        End Set
    End Property
    Public Property _papplicantidno As String '20200519
        Get
            Return xapplicantidno
        End Get
        Set(ByVal value As String)
            xapplicantidno = value
        End Set
    End Property
    Public Property _papplicantemail As String '20200519
        Get
            Return xapplicantEmail
        End Get
        Set(ByVal value As String)
            xapplicantEmail = value
        End Set
    End Property
    Public Property _papplicantItemno As String '20200519
        Get
            Return xapplicantItemno
        End Get
        Set(ByVal value As String)
            xapplicantItemno = value
        End Set
    End Property
    Public Property _papplicantname As String '20200519
        Get
            Return xapplicantName
        End Get
        Set(ByVal value As String)
            xapplicantName = value
        End Set
    End Property

    Public Property _ppositiontitle As String '20200521
        Get
            Return xpostiontitle
        End Get
        Set(ByVal value As String)
            xpostiontitle = value
        End Set
    End Property

    Public Property _pQuest34a As String
        Get
            Return xQues34a
        End Get
        Set(ByVal value As String)
            xQues34a = value
        End Set
    End Property
    Public Property _pQuest34b As String
        Get
            Return xQues34b
        End Get
        Set(ByVal value As String)
            xQues34b = value
        End Set
    End Property
    Public Property _pQuest35a As String
        Get
            Return xQues35a
        End Get
        Set(ByVal value As String)
            xQues35a = value
        End Set
    End Property
    Public Property _pQuest35b As String
        Get
            Return xQues35b
        End Get
        Set(ByVal value As String)
            xQues35b = value
        End Set
    End Property
    Public Property _pQuest36 As String
        Get
            Return xQues36
        End Get
        Set(ByVal value As String)
            xQues36 = value
        End Set
    End Property
    Public Property _pQuest37 As String
        Get
            Return xQues37
        End Get
        Set(ByVal value As String)
            xQues37 = value
        End Set
    End Property
    Public Property _pQuest38a As String
        Get
            Return xQues38a
        End Get
        Set(ByVal value As String)
            xQues34a = value
        End Set
    End Property
    Public Property _pQuest38b As String
        Get
            Return xQues38b
        End Get
        Set(ByVal value As String)
            xQues38b = value
        End Set
    End Property
    Public Property _pQuest39 As String
        Get
            Return xQues39
        End Get
        Set(ByVal value As String)
            xQues39 = value
        End Set
    End Property
    Public Property _pQuest40a As String
        Get
            Return xQues40a
        End Get
        Set(ByVal value As String)
            xQues40a = value
        End Set
    End Property
    Public Property _pQuest40b As String
        Get
            Return xQues40b
        End Get
        Set(ByVal value As String)
            xQues40b = value
        End Set
    End Property
    Public Property _pQuest40c As String
        Get
            Return xQues40c
        End Get
        Set(ByVal value As String)
            xQues40c = value
        End Set
    End Property
    Public Property _pApplicantEmailIDno As String
        Get
            Return xapplicantEmailID
        End Get
        Set(ByVal value As String)
            xapplicantEmailID = value
        End Set
    End Property

#End Region

#Region "jojie Employee"

    Public Shared _mEmpLastname

    Public Shared _mEmpMidname

    Public Shared _mEmpFirstname

    Public Shared _mEmpNo

    Public Shared _mEmpDepartment

    Public Shared _mStat

    Public Shared _mOBTO

    Public Shared _muserType

    Public Shared Property _puserType() As String

        Get

            Return _muserType

        End Get

        Set(value As String)

            _muserType = value

        End Set

    End Property

    Shared Property _pStat() As Boolean

        Get

            Return _mStat

        End Get

        Set(ByVal value As Boolean)

            _mStat = value

        End Set

    End Property

    Public Shared Property _pEmpLastname() As String

        Get

            Return _mEmpLastname

        End Get

        Set(value As String)

            _mEmpLastname = value

        End Set

    End Property

    Public Shared Property _pOBTO() As String

        Get

            Return _mOBTO

        End Get

        Set(value As String)

            _mOBTO = value

        End Set

    End Property

    Public Shared Property _pEmpfirstname() As String

        Get

            Return _mEmpFirstname

        End Get

        Set(value As String)

            _mEmpFirstname = value

        End Set

    End Property

    Public Shared Property _pEmpmidname() As String

        Get

            Return _mEmpMidname

        End Get

        Set(value As String)

            _mEmpMidname = value

        End Set

    End Property

    Public Shared Property _pEmpNo() As String

        Get

            Return _mEmpNo

        End Get

        Set(value As String)

            _mEmpNo = value

        End Set

    End Property

    Public Shared Property _pEmpDepartment() As String

        Get

            Return _mEmpDepartment

        End Get

        Set(value As String)

            _mEmpDepartment = value

        End Set

    End Property



#End Region
#Region "Routine Command"



#Region "CARL"

#Region "Properties"
    Private Shared _vFrom As String
    Public Shared Property _From() As String
        Get
            Return _vFrom
        End Get
        Set(value As String)
            _vFrom = value
        End Set
    End Property

    Private Shared _vTo As String
    Public Shared Property _To() As String
        Get
            Return _vTo
        End Get
        Set(value As String)
            _vTo = value
        End Set
    End Property

#End Region

#Region "Variables Data"
    Public Shared DetectTrap As Boolean
    Enum action
        toSet
        toGet
    End Enum
#End Region

    Public Sub PopulateRecords(dg As GridView, con As SqlConnection, _fields As String, _table As String, Optional _condition As String = "", Optional _orderBy As String = "")
        Try
            Dim getquery As String = IIf(_fields.Trim <> "", " SELECT " & _fields.Trim, "") & "  " & IIf(_table.Trim <> "", " FROM " & _table.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "") & IIf(_orderBy.Trim <> "", " ORDER BY " & _orderBy.Trim, "")
            DisplayOutput(getquery)

            _mSqlCommand = New SqlCommand(getquery, con)
            Dim _nSqlDataAdapter As New SqlDataAdapter(getquery, con)

            dg.Visible = ifHasRows(_fields, con, _table, _condition)

            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            dg.DataSource = _mDataTable
            dg.DataBind()
        Catch ex As Exception
            DisplayOutput(ex.Message)
        End Try
    End Sub

    Public Sub CUD(action As String, _fields As String, _table As String, Optional _condition As String = "")
        Try
            Dim getquery As String = ""

            Select Case action
                Case "C" ' IF SPECIFIC YUNG FIELD SA INSERT INCLUED IT BESIDE _table parameter ' CARL20190802
                    getquery = "INSERT INTO " & IIf(_table.Trim <> "", _table.Trim, "") & " VALUES(" & IIf(_fields.Trim <> "", _fields.Trim, "") & ")"
                Case "U"
                    getquery = "UPDATE " & IIf(_table.Trim <> "", _table.Trim, "") & " set " & IIf(_fields.Trim <> "", _fields.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
                Case "D"
                    getquery = "DELETE " & IIf(_table.Trim <> "", _table.Trim, "") & " " & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
                Case Else
            End Select
            DisplayOutput(getquery)

            _pSqlConnection = cGlobalConnections._pSqlCxn_HRIMS
            _mSqlCommand = New SqlCommand(getquery, _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            DisplayOutput(ex.Message)
        End Try
    End Sub

    Public Function ifHasRows(field As String, con As SqlConnection, table As String, Optional condField As String = "") As Boolean
        Try
            Dim getquery As String = IIf(field.Trim <> "", " SELECT " & field.Trim, "") & "  " & IIf(table.Trim <> "", " FROM " & table.Trim, "") & IIf(condField.Trim <> "", " WHERE " & condField.Trim, "")
            DisplayOutput(getquery)
            Dim _TempCmd As New SqlCommand(getquery, con)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            ifHasRows = _TempReader.HasRows
            _TempReader.Close()
            _TempCmd.Dispose()
        Catch ex As Exception
            ifHasRows = False
        End Try
    End Function

    Public Function getRow(FieldToGet As String, field As String, table As String, Optional condField As String = "") As String
        Try
            Dim val As String
            Dim cond As String = IIf(condField.Trim <> "", " where " & condField, "")
            Dim getQuer As String = "select " & field.ToUpper & " from " & table & cond
            DisplayOutput(getQuer)
            Dim _TempCmd As New SqlCommand(getQuer, cGlobalConnections._pSqlCxn_HRIMS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            _TempReader.Read()
            val = IIf(_TempReader.HasRows, _TempReader.Item(FieldToGet).ToString, "")
            _TempReader.Close()
            _TempCmd.Dispose()
            getRow = val
        Catch ex As Exception
            getRow = ""
        End Try
    End Function

    Public Function getRow3(FieldToGet As String, field As String, table As String, Optional condField As String = "") As String
        Try
            Dim val As String
            Dim getquery As String = IIf(field.Trim <> "", " SELECT " & field.Trim, "") & "  " & IIf(table.Trim <> "", " FROM " & table.Trim, "") & IIf(condField.Trim <> "", " WHERE " & condField.Trim, "")
            DisplayOutput(getquery)
            Dim _TempCmd As New SqlCommand(getquery, cGlobalConnections._pSqlCxn_HRIMS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            _TempReader.Read()
            val = IIf(_TempReader.HasRows, _TempReader.Item(FieldToGet).ToString, "")
            _TempReader.Close()
            _TempCmd.Dispose()
            getRow3 = val
        Catch ex As Exception
            getRow3 = ""
        End Try
    End Function

    Public Function getRow2(con As SqlConnection, db As String, FieldToGet As String, field As String, table As String, Optional condField As String = "") As String
        Try
            Dim val As String
            Dim cond As String = IIf(condField.Trim <> "", " where " & condField, "")
            Dim getQuer As String = "select " & field.ToUpper & " from [" & db & "].[dbo]." & table & cond
            DisplayOutput(getQuer)
            Dim _TempCmd As New SqlCommand(getQuer, con)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            _TempReader.Read()
            val = IIf(_TempReader.HasRows, _TempReader.Item(FieldToGet).ToString, "")
            _TempReader.Close()
            _TempCmd.Dispose()
            getRow2 = val
        Catch ex As Exception
            getRow2 = ""
        End Try
    End Function

    Public Sub DisplayOutput(text As String)
        Try
            'Dim CARL As Boolean = False ' toggle this to True to toggle copy the text to clipboard
            'If CARL Then
            '    Dim Comp As New Computer
            '    Comp.Clipboard.SetText(text) error
            'End If
            Debug.Print(vbNewLine & "[" & My.Computer.Name & "] " & text)

        Catch ex As Exception
            Debug.Print("ERROR: [" & ex.Message & "] " & vbNewLine & vbNewLine & text)
        End Try
    End Sub

    Public Sub RemoveHistory(Pos, page)
        Try

            'Select Case Pos
            '    Case "<"
            '        DisplayOutput(Request.ServerVariables("HTTP_REFERER"))
            '        page.Response.Redirect(Request.UrlReferrer.ToString())
            '    Case Else
            'End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub NavigatePage(Pos, page)
        Try
            Select Case Pos
                Case "<"
                    Write("window.history.go(-1);", page)
                Case Else
                    page.Response.Redirect(Pos & ".aspx")
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Write(Text, page)
        Try
            page.Response.Write("<script>try{" & Text & "}catch(e){alert(e.message);}</script>")
        Catch ex As Exception
            page.Response.Write("<script>try{alert(" & ex.Message & ");}catch(e){alert(e.message);}")
        End Try
    End Sub

    Public Sub MessageBox(Text, page)
        Try
            page.Response.Write("<script>try{alert(" & Text & ");}catch(e){alert(e.message);}</script>")
        Catch ex As Exception
            page.Response.Write("<script>try{alert('" & ex.Message & "');}catch(e){alert(e.message);}</script>")
        End Try
    End Sub

    Public Function FormatDate(action As action, format As Integer, val As String) As String
        Try

            If val.Trim() = "" And action = cDalHRIMS.action.toSet Then Return "''"
            If val.Trim() = "" And action = cDalHRIMS.action.toGet Then Return ""

            Dim formatType As String = ""
            Dim _date As DateTime = val
            Select Case format
                Case 1
                    formatType = "MM-dd-yyyy"
                Case 2
                    formatType = "dd-MM-yyyy"
                Case 3
                    formatType = "yyyy-dd-MM"
                Case 4
                    formatType = "yyyy-MM-dd"
            End Select
            Select Case action
                Case cDalHRIMS.action.toSet
                    Return "format(cast('" & val & "' as date),'" & formatType & "')"
                Case cDalHRIMS.action.toGet
                    Return _date.ToString(formatType)
            End Select
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function IfUserTypeIs(str1 As String) As Boolean
        Try
            Return CBool(cSessionUser._pUsertype = str1)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function createAcronym(val As String) As String
        Try

            Dim Query As String = "DECLARE @WORD nVARCHAR(MAX)	= '" & val & "', @ACRONYM nVARCHAR(MAX)" _
                                & "SET @WORD = RTRIM(LTRIM(@WORD))" _
                                & "SET @ACRONYM = LEFT(@WORD, 1)" _
                                & " while CHARINDEX(' ', @WORD, 1) > 0" _
                                & "   BEGIN" _
                                & "    SET @WORD = LTRIM(RIGHT(@WORD, LEN(@WORD) - CHARINDEX(' ',@WORD,1))) " _
                                & "    SET @ACRONYM = @ACRONYM +LEFT(@WORD,1)" _
                                & "   END " _
                                & "select @ACRONYM as acronym"

            Dim _mDbCon = cGlobalConnections._pSqlCxn_HRIMS
            Dim _mSqlCmd = New SqlCommand(Query, _mDbCon)

            Return _mSqlCmd.ExecuteScalar.ToString()

        Catch ex As Exception
            Return "ERROR"
        End Try
    End Function


    Public Sub InsertItemInDropdown(obj As DropDownList, StartPos As Integer, FieldToGet As String, _fields As String, _table As String, Optional _condition As String = "")
        Try
            Dim getquery As String = IIf(_fields.Trim <> "", " SELECT " & _fields.Trim, "") & "  " & IIf(_table.Trim <> "", " FROM " & _table.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
            DisplayOutput(getquery)

            Dim _TempCmd As New SqlCommand(getquery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader

            If _TempReader.HasRows Then
                For index = 1 To obj.Items.Count
                    If obj.Items.Count = 1 Then GoTo hop
                    obj.Items.RemoveAt(1)
hop:
                Next

                While _TempReader.Read
                    obj.Items.Insert(StartPos, _TempReader.Item(FieldToGet).ToString)
                End While

            End If
            obj.Visible = _TempReader.HasRows
            _TempReader.Close()
            _TempCmd.Dispose()


        Catch ex As Exception
        End Try
    End Sub

    Public Sub SaveActionLog(_date As DateTime, details As String, _mod As String, type As String, idno As String, stat As String)
        Try
            'If module = "Leave Application" Then
            '    details = hdnaction.Value & "Leave Application" & " from `" & hdn1.Value & "` to `" & hdn2.Value & "` total of " & nodays.Value & " of Day(s)"
            '    type = "Application Leave"
            'Else
            '    details = obto1.Value + " Official Business / Travel Order Application" & " from `" & obto2.Value & "` to `" & obto3.Value
            '    type = "Application Official Business / Travel Order Application "
            'End If
            Dim cDal As New cDalHRIMS
            cDal._pSaveTransactionLog(_date, details, _mod, type, idno, stat)
        Catch ex As Exception

        End Try
    End Sub




#Region "UPLOAD FILE"

    Sub upload_Docs(up As HtmlInputFile, seqID As String, ModuleID As String, _table As String)

        Try
            If up.PostedFile IsNot Nothing And up.PostedFile.ContentLength > 0 Then

                Dim _fieldsIns As String = "@CODE,@IDNO,@MODULEID,@SEQID,@FILEDATA,@FILENAME,@FILETYPE"
                Dim _fieldsUpd As String = "CODE=@CODE,IDNO=@IDNO,MODULEID=@MODULEID,SEQID=@SEQID,FILEDATA=@FILEDATA,FILENAME=@FILENAME,FILETYPE=@FILETYPE"
                Dim CODE As String = createAcronym(ModuleID).ToUpper & "-" & cSessionUser._pIDNo & "-" & seqID

                Dim FileData As HttpPostedFile = up.PostedFile
                Dim FileName As String = up.PostedFile.FileName
                Dim FileType As String = up.PostedFile.ContentType

                Dim fs As System.IO.Stream = FileData.InputStream
                Dim br As New System.IO.BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

                Dim getquery As String
                If ifHasRows("CODE", cGlobalConnections._pSqlCxn_HRIMS, "PDS_ATTACHMENT", "CODE='" & CODE & "'") Then
                    Dim ONYO As String = "WHERE CODE ='" & CODE & "'"
                    getquery = "UPDATE " & IIf(_table.Trim <> "", _table.Trim, "") & " SET " & IIf(_fieldsUpd.Trim <> "", _fieldsUpd.Trim, "") & " " & ONYO
                Else
                    getquery = "INSERT INTO " & IIf(_table.Trim <> "", _table.Trim, "") & " VALUES(" & IIf(_fieldsIns.Trim <> "", _fieldsIns.Trim, "") & ")"
                End If

                DisplayOutput(getquery)

                _pSqlConnection = cGlobalConnections._pSqlCxn_HRIMS
                _mSqlCommand = New SqlCommand(getquery, _mSqlConnection)

                With _mSqlCommand
                    With .Parameters
                        .AddWithValue("@CODE", CODE)
                        .AddWithValue("@IDNO", cSessionUser._pIDNo)
                        .AddWithValue("@MODULEID", ModuleID)
                        .AddWithValue("@SEQID", seqID)
                        .AddWithValue("@FILEDATA", bytes)
                        .AddWithValue("@FILENAME", FileName)
                        .AddWithValue("@FILETYPE", FileType)
                    End With
                    .ExecuteNonQuery()
                End With

            End If
        Catch ex As Exception
            DisplayOutput(ex.Message)
        End Try

    End Sub





#End Region

    'Public Function FormatToDate(format As Integer, val As String) As String
    '    Try
    '        Dim formatType As String = ""
    '        Dim res As String = ""
    '        Select Case format
    '            Case 1
    '                formatType = "MM-dd-yyyy"
    '                res = "format(cast('" & val & "' as date),'" & formatType & "')"
    '            Case 2
    '                res = DateTime.ParseExact(val, "yyyy-MM-dd", Nothing).ToString("MM-dd-yyyy")
    '        End Select
    '        Return res
    '    Catch ex As Exception
    '        Return val
    '    End Try
    'End Function


#End Region




#Region "JOJIE"

    Public Sub _pSubSelectVoluntaryWork()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select SeqNo,IDNO,format(cast(dfrom as date),'MM-dd-yyyy') as dfrom,format(cast(dTo as date),'MM-dd-yyyy') as dto,OrganizationName,OrganizationAddress,NumberofHours,Position,NatureofWork from PDS_VoluntaryWorkorInvolvement where IDNO ='" & cSessionUser._pIDNo & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsert(idno, dfrom, dto, oname, oaddress, nohr, jobp, now, seqno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " insert into PDS_VoluntaryWorkorInvolvement values ('" + idno + "', '" + dfrom + "', '" + dto + "', '" + oname + "', '" + oaddress + "' ,  '" + nohr + "',  '" + jobp + "', '" + now + "','" + seqno + "') "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdate(idno, dfrom, dto, oname, oaddress, nohr, jobp, now)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update PDS_VoluntaryWorkorInvolvement set  dFrom='" + dfrom + "', dTo ='" + dto + "', OrganizationName ='" + oname + "', OrganizationAddress = '" + oaddress + " ' ,  NumberofHours ='" + nohr + "', Position = '" + jobp + "', NatureofWork ='" + now + "' where SeqNo ='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubdelete(idno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "delete PDS_VoluntaryWorkorInvolvement where SeqNo='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Function _id(idno As String) As String
        Try
            Dim _nQuery As String = Nothing
            Dim _nQuery1 As String = Nothing
            Dim s As String, s1 As String
            _nQuery = "select top 1 right(SeqNo,3)   from PDS_VoluntaryWorkorInvolvement   order by SeqNo desc "


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader

            _read = _nSqlCommand.ExecuteReader()
            If _read.HasRows Then
                While _read.Read
                    If Left(_read.Item(0).ToString, 2) = "00" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "10"
                                s = "VWI - 0" + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "VWI - 00" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    ElseIf Left(_read.Item(0).ToString, 1) = "0" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "100"
                                s = "VWI - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "VWI - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    Else
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "1000"
                                s = "VWI - " + "000" + "-" + "001"
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                            Case Else
                                s = "VWI - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "VWI - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    End If
                    'Select Case _read.Item(0).ToString
                    '    Case Left(_read.Item(0).ToString, 2) = "00"
                    '        s1 = Right(_read.Item(0).ToString, 3)
                    '        s1 = s1 + 1
                    '        s = "VWI - 00 " + s1
                    '        idno = s
                    '        _read.Close()
                    '        _nSqlCommand.Dispose()

                    '    Case Left(_read.Item(0).ToString, 1) = "0"
                    '    Case Left(_read.Item(0).ToString, 1) = "009"
                    '    Case Left(_read.Item(0).ToString, 1) = "099"



                    'End Select
                    Return idno

                End While
            Else
                s = "VWI - 001"
                idno = s
                _read.Close()
                _nSqlCommand.Dispose()
                Return idno

                Exit Function
            End If
            _read.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
        Return idno
    End Function
    Public Sub _pSubSelectTraining()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select IDNO,format(cast(dfrom as date),'MM-dd-yyyy') as dfrom,format(cast(dTo as date),'MM-dd-yyyy') as dto,TitleofSeminarConferenceWorkshopShortCourse,NumberofHours,NumberofHours,TypeofLearningDevelopment,ConductedSponsoredBy,SeqNo from PDS_TrainingPrograms where IDNO = '" & cSessionUser._pIDNo & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertTrain(idno, dfrom, dto, seminar, nohr, learning, spo, seqno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " insert into PDS_TrainingPrograms values ('" + idno + "', '" + dfrom + "', '" + dto + "', '" + seminar + "',   '" + nohr + "',  '" + learning + "', '" + spo + "','" + seqno + "') "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateTrain(idno, dfrom, dto, seminar, nohr, learning, spo)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update PDS_TrainingPrograms set  dFrom='" + dfrom + "', dTo ='" + dto + "', TitleofSeminarConferenceWorkshopShortCourse ='" + seminar + "', TypeofLearningDevelopment = '" + learning + " ' ,  NumberofHours ='" + nohr + "', ConductedSponsoredBy ='" + spo + "' where SeqNo ='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Function _idTrain(idno As String) As String
        Try
            Dim _nQuery As String = Nothing
            Dim _nQuery1 As String = Nothing
            Dim s As String, s1 As String

            _nQuery = "select top 1 right(SeqNo,3)   from PDS_TrainingPrograms  where IDNO='" & cSessionUser._pIDNo & "' order by SeqNo desc "



            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader

            _read = _nSqlCommand.ExecuteReader()
            If _read.HasRows Then
                While _read.Read
                    If Left(_read.Item(0).ToString, 2) = "00" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "10"
                                s = "TR - 0" + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "TR - 00" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    ElseIf Left(_read.Item(0).ToString, 1) = "0" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "100"
                                s = "TR - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "TR - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    Else
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "1000"
                                s = "TR - " + "000" + "-" + "001"
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                            Case Else
                                s = "TR - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "TR - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    End If
                    'Select Case _read.Item(0).ToString
                    '    Case Left(_read.Item(0).ToString, 2) = "00"
                    '        s1 = Right(_read.Item(0).ToString, 3)
                    '        s1 = s1 + 1
                    '        s = "VWI - 00 " + s1
                    '        idno = s
                    '        _read.Close()
                    '        _nSqlCommand.Dispose()

                    '    Case Left(_read.Item(0).ToString, 1) = "0"
                    '    Case Left(_read.Item(0).ToString, 1) = "009"
                    '    Case Left(_read.Item(0).ToString, 1) = "099"



                    'End Select
                    Return idno

                End While
            Else
                s = "TR - 001"
                idno = s
                _read.Close()
                _nSqlCommand.Dispose()
                Return idno

                Exit Function
            End If
            _read.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
        Return idno
    End Function

    Public Sub _pSubdeleteTrain(idno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "delete PDS_TrainingPrograms where SeqNo='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectotherinfo()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "Select * from  PDS_OtherInformation where IDNO ='" & cSessionUser._pIDNo & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertotherinfo(idno, skill, reg, orga, seqno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " insert into PDS_OtherInformation values ('" + idno + "', '" + skill + "', '" + reg + "', '" + orga + "', '" + seqno + "') "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateotherinfo(idno, skill, reg, orga)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update PDS_OtherInformation set  SpecialSkillsHobbies='" + skill + "', NonAcademicDistinctionsRecognition ='" + reg + "', MembershipinAssociationOrganization ='" + orga + "' where SeqNo ='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Function _idOtherinfo(idno As String) As String
        Try
            Dim _nQuery As String = Nothing
            Dim _nQuery1 As String = Nothing
            Dim s As String, s1 As String
            _nQuery = "select top 1 right(IDNO,3)   from PDS_OtherInformation   order by IDNO desc "


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader

            _read = _nSqlCommand.ExecuteReader()
            If _read.HasRows Then
                While _read.Read
                    If Left(_read.Item(0).ToString, 2) = "00" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "10"
                                s = "OI - 0" + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "OI - 00" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    ElseIf Left(_read.Item(0).ToString, 1) = "0" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "100"
                                s = "OI - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "OI - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    Else
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "1000"
                                s = "OI - " + "000" + "-" + "001"
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                            Case Else
                                s = "OI - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "OI - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    End If
                    'Select Case _read.Item(0).ToString
                    '    Case Left(_read.Item(0).ToString, 2) = "00"
                    '        s1 = Right(_read.Item(0).ToString, 3)
                    '        s1 = s1 + 1
                    '        s = "VWI - 00 " + s1
                    '        idno = s
                    '        _read.Close()
                    '        _nSqlCommand.Dispose()

                    '    Case Left(_read.Item(0).ToString, 1) = "0"
                    '    Case Left(_read.Item(0).ToString, 1) = "009"
                    '    Case Left(_read.Item(0).ToString, 1) = "099"



                    'End Select
                    Return idno

                End While
            Else
                s = "OI - 001"
                idno = s
                _read.Close()
                _nSqlCommand.Dispose()
                Return idno

                Exit Function
            End If
            _read.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
        Return idno
    End Function

    Public Sub _pSubdeleteotherinfo(idno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "delete PDS_OtherInformation where SeqNO='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRef()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    

            _nQuery = "select (select UserID from SOS_OAIMS_20200605..Registered where IDNO ='" & cSessionUser._pIDNo & "')as Email,SeqNo,IDNO,FirstName,LastName,MiddleName,  isnull(firstname,' ') + ' '  + isnull(middlename,' ')+ ' ' +isnull(lastname,'') as FullName,Fullname as RFullname, Address,TelNo from PDS_References where IDNO = '" & cSessionUser._pIDNo & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    xapplicantEmail = _nSqlDr.Item("Email").ToString
                    xapplicantidno = _nSqlDr.Item("IDNO").ToString
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsertref(idno, fname, mname, lname, address, telno, seqno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " insert into PDS_References values ('" + idno + "', '" + fname + "', '" + lname + "', '" + mname + "','" + address + "','" + telno + " ','" + seqno + " ' , '" + fname + " " + mname + " " + lname + "') "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateotherinfo(idno, fname, mname, lname, address, telno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update PDS_References set  FirstName='" + fname + "', LastName ='" + lname + "', MiddleName ='" + mname + "', Address ='" + address + "', TelNo ='" + telno + "' where SeqNo ='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubref(idno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "delete PDS_References where SeqNo='" + idno + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Function _idRef(idno As String) As String
        Try
            Dim _nQuery As String = Nothing
            Dim _nQuery1 As String = Nothing
            Dim s As String, s1 As String
            _nQuery = "select top 1 right(IDNO,3)   from PDS_References   order by IDNO desc "


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader

            _read = _nSqlCommand.ExecuteReader()
            If _read.HasRows Then
                While _read.Read
                    If Left(_read.Item(0).ToString, 2) = "00" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "10"
                                s = "Ref - 0" + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "Ref - 00" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    ElseIf Left(_read.Item(0).ToString, 1) = "0" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "100"
                                s = "Ref - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "Ref - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    Else
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "1000"
                                s = "Ref - " + "000" + "-" + "001"
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                            Case Else
                                s = "Ref - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "Ref - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    End If

                    Return idno

                End While
            Else
                s = "Ref - 001"
                idno = s
                _read.Close()
                _nSqlCommand.Dispose()
                Return idno

                Exit Function
            End If
            _read.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
        Return idno
    End Function


    Public Sub _pSubSelectTApplicant() ' 20200518
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "SELECT (SELECT USERID FROM SOS_OAIMS_20200605..Registered WHERE IDNo=PDS_APPLICANT.USERID)AS eMAIL,* FROM PDS_Applicant"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub String_pSubSelectUser()  '20200518
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select UserType,IDNo,isnull(LastName,'')+' ' + isnull(firstname,'') +' ' +ISNULL(middlename,'') as Fullname from SOS_OAIMS_20200605..Registered where IDNO='" & cSessionUser._pIDNo & "'"

            '---------------------------------- 
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader

            _read = _nSqlCommand.ExecuteReader()
            _read.Read()
            If _read.HasRows Then
                _pxidno = _read.Item(1).ToString
                _puser = _read.Item(2).ToString
            End If
            '----------------------------------

            _read.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubSelectQuestionFied() ' 20200526 jojie 
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select * from PDS_QuestionField where IDNO ='" & cSessionUser._pIDNo & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    ' xQues34a = _nSqlDr.Item("Detail34a").ToString()
                    xQues34a = _nSqlDr.Item("Detail34a").ToString()
                    xQues34a = _nSqlDr.Item("Detail34a").ToString()
                    xQues34b = _nSqlDr.Item("Detail34b").ToString()
                    xQues35a = _nSqlDr.Item("Detail35a").ToString()
                    xQues35b = _nSqlDr.Item("Detail35b").ToString()
                    xQues36 = _nSqlDr.Item("Detail36").ToString()
                    xQues37 = _nSqlDr.Item("Detail37").ToString()
                    xQues38a = _nSqlDr.Item("Detail38a").ToString()
                    xQues38b = _nSqlDr.Item("Detail38b").ToString()
                    xQues39 = _nSqlDr.Item("Detail39").ToString()
                    xQues40a = _nSqlDr.Item("Detail40a").ToString()
                    xQues40b = _nSqlDr.Item("Detail40b").ToString()
                    xQues40c = _nSqlDr.Item("Detail40c").ToString()
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertQuestion(idno, q34a, q34b, q35a, q35b, q36, q37, q38a, q38b, q39, q40a, q40b, q40c)


        Try
            Dim _nQuery As String = Nothing
            _nQuery = " insert into PDS_QuestionField values ('" + idno + "', '" + q34a + "', '" + q34b + "', '" + q35a + "',   '" + q35b + "',  '" + q36 + "', '" + q37 + "','" + q38a + "','" + q38b + "','" + q39 + "','" + q40a + "','" + q40b + "','" + q40c + "') "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubupdateQuestion(idno, q34a, q34b, q35a, q35b, q36, q37, q38a, q38b, q39, q40a, q40b, q40c)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = " update PDS_QuestionField set Detail34a ='" + q34a + "', Detail34b ='" + q34b + "', Detail35a ='" + q35a + "',   Detail35b ='" + q35b + "', Detail36 = '" + q36 + "',Detail37 = '" + q37 + "',Detail38a ='" + q38a + "',Detail38b ='" + q38b + "',Detail39 ='" + q39 + "',Detail40a ='" + q40a + "',Detail40b ='" + q40b + "',Detail40c ='" + q40c + "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateHREvaluation(idno, invited, QSE, Recr, Exam, evaluator, appidno, appuser, xtime, xdate)

        Try

            Dim _nQuery As String = Nothing

            _nQuery = "update PDS_Applicant set  InvitedforExamination='" + invited + "', QSEvaluation ='" + QSE + "', Status ='" + Recr + "', StatusExam = '" + Exam + " ',EVALUATED_BY ='" + Replace(evaluator, "HR Name :", "") + "', examdate = '" + xdate + "', examtime = '" + xtime + "'where ITEM_NO ='" + appuser + "'and USERID='" + appidno + "'and APPLICANT_ID='" + idno + "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception


        End Try

    End Sub

    Public Sub _pCreateTempDTR()

        Dim str As String = ""

        str = " if not exist SELECT ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE' and ROUTINE_NAME = '[CreateDTRTemp]' " & _
            "Create PROCEDURE [dbo].[CreateDTRTemp](@date as nvarchar(200),@EmpNo as nvarchar(200)) AS" & _
                "End" & _
                " BEGIN" & _
                "DECLARE @sQUERY NVARCHAR(4000)" & _
                "DECLARE @sCOND NVARCHAR(4000)" & _
                "declare @xInt as integer" & _
                "SET @sQUERY='IF EXISTS(SELECT NAME FROM SYSOBJECTS WHERE NAME= " & _
                "    ''tempDTR'' AND TYPE=''U'') DROP TABLE tempDTR '                    " & _
                "PRINT @sQUERY" & _
                "EXEC sp_executesql @sQUERY" & _
                "" & _
                "SET @sQUERY=' select * into tempDTR from ProcessedDTR where tdate like ''%'+@date+'%'' and emp_no='''+ @EmpNo +''''        " & _
                "EXEC sp_executesql @sQUERY " & _
                "" & _
                "PRINT @sQUERY" & _
                "select @xInt =count(*) from tempDTR " & _
                "print @xInt" & _
                "" & _
                "if @xInt =29" & _
                "begin " & _
                "        SET @sQUERY=' insert into tempDTR(dateCtr,emp_no,tdate,deptheadsw,Work_hrs,Work_Min) values(30,'''','''','''','''','''') '        " & _
                "        EXEC sp_executesql @sQUERY " & _
                "        SET @sQUERY=' insert into tempDTR(dateCtr,emp_no,tdate,deptheadsw,Work_hrs,Work_Min) values(31,'''','''','''','''','''') '        " & _
                "        EXEC sp_executesql @sQUERY " & _
                "            End" & _
                "" & _
                "if @xInt =30" & _
                "begin " & _
                "        SET @sQUERY=' insert into tempDTR(dateCtr,emp_no,tdate,deptheadsw,Work_hrs,Work_Min) values(31,'''','''','''','''','''') '        " & _
                "        EXEC sp_executesql @sQUERY " & _
                "                End" & _
                "" & _
                "                End"


        Dim tempcreate As SqlCommand

        tempcreate = New SqlCommand(str, cGlobalConnections._pSqlCxn_HRIMS)

    End Sub


    Public Sub _pSubInsertOBTO(empno, dfrom, dto, depart, arrival, destination, purpose, desc, status, dateapply)

        Try

            Dim _nQuery As String = Nothing

            _nQuery = " insert into  OB_TO_Application values ('" + empno + "', '" + dfrom + "', '" + dto + "', '" + depart + "', '" + arrival + "' ,  '" + destination + "',  '" + purpose + "', '" + desc + "', '" + status + "', '" + dateapply + "','') "

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception


        End Try

    End Sub


    Public Sub _pSubSelectEmployee()

        Try

            '----------------------------------

            Dim _nQuery As String = Nothing

            Dim _nWhere As String = Nothing


            '----------------------------------

            If _mStat = True Then

                If _muserType = "HR" Then

                    _nQuery = "select top 10 emp_no,Last_name, First_name, Mid_name,(select DeptDesc from Department where DeptCode= Department) as Department from Payroll_Data"


                Else

                    _nQuery = "select (select EmailAdd from Personal_Data where emp_no = Payroll_Data.emp_no),emp_no,Last_name, First_name, Mid_name,(select DeptDesc from Department where DeptCode= Department) as Department from Payroll_Data where (select EmailAdd from Personal_Data where emp_no = Payroll_Data.emp_no)='" & cSessionUser._pUserID & "'"


                End If

            Else

                _nQuery = "select emp_no,Last_name, First_name, Mid_name,(select DeptDesc from Department where DeptCode= Department) as Department from Payroll_Data where (select DeptDesc from Department where DeptCode= Department)  ='" & _mEmpDepartment & "'"


            End If

            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                _nSqlDr.Read()

                If _nSqlDr.HasRows Then

                    If _muserType <> "HR" Then

                        _mEmpLastname = _nSqlDr.Item(2).ToString()

                        _mEmpFirstname = _nSqlDr.Item(3).ToString()

                        _mEmpMidname = _nSqlDr.Item(4).ToString()

                        _mEmpNo = _nSqlDr.Item(1).ToString()

                    End If

                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If

            End Using

        Catch ex As Exception


        End Try

    End Sub

    Public Sub _pSubApplicationOBTOApplication()

        Try

            '----------------------------------
            Dim dbactive As String = Nothing
            dbactive = GetString("select  DBInitialCatalog from GlobalConnectionsDefault where SetupGlobalConnectionsDatabases = 'PMIPS'", cGlobalConnections._pSqlCxn_CR, 0, "", 1)

            Dim _nQuery As String = Nothing

            Dim _nWhere As String = Nothing


            '----------------------------------

            '_nQuery = "select Emp_no,        convert(nvarchar(50),cast(DateFrom as smalldatetime),101) as DateFrom,        convert(nvarchar(50),cast(DateTo as smalldatetime),101) as DateTo,        CONVERT(varchar(15),  CAST(timeDeparture AS TIME), 100) as timeDeparture,        CONVERT(varchar(15),  CAST(timearrival AS TIME), 100) as timearrival,        Destination        ,Purpose,        Remarks        ,Status,        DateApply        ,DateUpdated from OB_TO_Application where (select EmailAdd from Personal_Data where Emp_no = '" & xemp_no & "') ='" & cSessionUser._pUserID & "'"
            '_nQuery = "select * from OB_TO_Application where emp_no =(select emp_no from Personal_Data where Emp_no = '" & xemp_no & "')"
            _nQuery = "select * from OB_TO_Application where emp_no =(select emp_no from [TEXAS\MSSQL2014]." & dbactive & ".[dbo].Personal_Data where Emp_no = '" & xemp_no & "')"

            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                _nSqlDr.Read()

                If _nSqlDr.HasRows Then

                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop  

                End If

            End Using

        Catch ex As Exception


        End Try

    End Sub

    Public Sub _pSubApplicationOBTO()

        Try

            '----------------------------------

            Dim _nQuery As String = Nothing

            Dim _nWhere As String = Nothing


            '----------------------------------

            '_nQuery = "select pd.emp_no,isnull(pd.Last_name,'') + ' ,' + isnull(pd.First_name,'') +' ' + isnull(pd.Mid_name,'') +'' as Name,DateApply,obto.Status,obto.datefrom,obto.dateto,obto.timearrival,obto.timedeparture,obto.destination,obto.purpose,obto.remarks from OB_TO_Application obto inner join Payroll_Data pd on obto.emp_no = pd.emp_no"


            _nQuery = "select pd.emp_no,isnull(pd.Last_name,'') + ' ,' + isnull(pd.First_name,'') +' ' + isnull(pd.Mid_name,'') +'' as Name,DateApply,obto.Status,convert(nvarchar(50),cast(obto.DateFrom as smalldatetime),101) as DateFrom,        convert(nvarchar(50),cast(obto.DateTo as smalldatetime),101) as DateTo,        CONVERT(varchar(15),  CAST(timeDeparture AS TIME), 100) as timeDeparture,        CONVERT(varchar(15),  CAST(timearrival AS TIME), 100) as timearrival,CONVERT(varchar(15),  CAST(obto.timearrival AS TIME), 100) as timearrival,CONVERT(varchar(15),  CAST(obto.timeDeparture AS TIME), 100) as timedeparture,obto.destination,obto.purpose,obto.remarks from OB_TO_Application obto inner join Payroll_Data pd on obto.emp_no = pd.emp_no"


            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                _nSqlDr.Read()

                If _nSqlDr.HasRows Then

                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop  

                End If

            End Using

        Catch ex As Exception


        End Try

    End Sub




    Public Sub _pSubCreateOBTO()

        Try

            '----------------------------------

            Dim _nQuery As String = Nothing

            Dim _nWhere As String = Nothing


            '----------------------------------

            _nQuery = "      if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='OB_TO_Application')" & _
                                  "      CREATE TABLE [dbo].[OB_TO_Application](                                                     " & _
                                  "          [Emp_no] [nvarchar](50) NULL,                                                           " & _
                                  "          [DateFrom] [nvarchar](50) NULL,                                                         " & _
                                  "          [DateTo] [nvarchar](50) NULL,                                                           " & _
                                  "          [timeDeparture] [nvarchar](50) NULL,                                                    " & _
                                  "          [timearrival] [nvarchar](50) NULL,                                                      " & _
                                  "          [Destination] [nvarchar](50) NULL,                                                      " & _
                                  "          [Purpose] [nvarchar](50) NULL,                                                          " & _
                                  "          [Remarks] [nvarchar](50) NULL,                                                          " & _
                                  "          [Status] [nvarchar](50) NULL,                                                           " & _
                                  "          [DateApply] [nvarchar](50) NULL                                                         " & _
                                  "      ) ON [PRIMARY]                                                                              "


            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception


        End Try

    End Sub


    Public Sub _pSubupdateOBTO(idno, dfrom, dto, status, dateupdated, Remarks)

        Try

            Dim _nQuery As String = Nothing

            ' _nQuery = "update OB_TO_Application set Status='" & status & "',DateUpdated='" & dateupdated & "' where Emp_no='" & idno & "' and DateFrom ='" & dfrom & "' and DateTo = '" & dto & "' "
            _nQuery = "update OB_TO_Application set Status='" & status & "',DateUpdated='" & dateupdated & "',Remarks='" & Remarks & "' where Emp_no='" & idno & "' and DateFrom =cast('" & dfrom & "' as date) and DateTo = cast('" & dto & "'as date)  and Status='Pending'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception


        End Try

    End Sub

    Public Sub _pSubDelete(idno, dfrom, dto)

        Try

            Dim _nQuery As String = Nothing

            _nQuery = "delete OB_TO_Application where Emp_no='" & idno & "' and DateFrom ='" & dfrom & "' and DateTo = '" & dto & "' "

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception


        End Try

    End Sub



    Public Sub _pSubInsertPMIPSOBTO(Emp_no, ObDate_From, ObDate_To, OB_Desc, Remarks, OBCode, ObTime_From, ObTime_To)

        Try

            Dim _nQuery As String = Nothing

            Dim id As String

            Dim xAutoNo = _idOBTOWebidno(id)

            _nQuery = " insert into Emp_OB (Emp_no,ObDate_From,ObDate_To,OB_Desc,Remarks,OBCode,ObTime_From,ObTime_To,autoID)values ('" & Emp_no & "','" & ObDate_From & "','" & ObDate_To & "','" & OB_Desc & "','" & Remarks & "','" & OBCode & "','" & ObTime_From & "','" & ObTime_To & "','" & xAutoNo & "')"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception


        End Try

    End Sub


    Public Function _idOBTOWebidno(idno As String) As String

        Try

            Dim _nQuery As String = Nothing

            Dim _nQuery1 As String = Nothing

            Dim s As String, s1 As String

            Dim useridno As String

            useridno = GetString("select  emp_no from Personal_Data where  EmailAdd='" & cSessionUser._pUserID & "'", cGlobalConnections._pSqlCxn_HRIMS, 0, "", 1)

            _nQuery = "select right(autoID,4) from Emp_OB where Emp_no='" & useridno & "'  order by autoID desc "



            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            Dim _read As SqlDataReader


            _read = _nSqlCommand.ExecuteReader()

            _read.Read()

            If _read.HasRows Then

                s1 = _read.Item(0).ToString()

                s1 = s1 + 1

                s1 = Strings.Left(s1, 5)

                If s1 <= 9 Then

                    s = "HRIMS-" + useridno + "-000" + s1

                    idno = s

                ElseIf s1 >= 10 And s1 <= 99 Then

                    s = "HRIMS-" + useridno + "-00" + s1

                    idno = s

                ElseIf s1 >= 100 And s1 <= 999 Then

                    s = "HRIMS-" + useridno + "-0" + s1

                    idno = s

                End If


            Else

                s = "HRIMS-" + useridno + "-0001"

                idno = s

                _read.Close()

                _nSqlCommand.Dispose()

                Return idno


                Exit Function

            End If

            _read.Close()

            _nSqlCommand.Dispose()

            '----------------------------------

        Catch ex As Exception


        End Try

        Return idno

    End Function


    Public Sub _pSubupdateApplicationLeave(idno, dfrom, dto, status, dateupdated, remarks) '20200611


        Try

            Dim _nQuery As String = Nothing

            _nQuery = "update Temp_LeaveApplication set Status='" & IIf(status = "Approved", 1, 0) & "',DateUpdated='" & dateupdated & "',Remarks='" & IIf(remarks <> "", "Disapproved " & remarks, "Approved") & "'where Emp_no='" & idno & "' and EmpLFrom =cast('" & dfrom & "' as date) and EmpLto = cast('" & dto & "'as date)"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception



        End Try


    End Sub


    Public Sub _pSubSelectTApplicantOBTO() ' 20200623

        Try

            '----------------------------------
            Dim dbactive As String = Nothing
            dbactive = GetString("select  DBInitialCatalog from GlobalConnectionsDefault where SetupGlobalConnectionsDatabases = 'PMIPS'", cGlobalConnections._pSqlCxn_CR, 0, "", 1)

            Dim _nQuery As String = Nothing

            Dim _nWhere As String = Nothing


            '----------------------------------                

            '_nQuery = "select (select isnull(Last_name,'')+ ' ' + isnull(First_name,',  ')+' '+ left(isnull(Mid_name,''),1) +'.'  from Payroll_Data where emp_no=OB_TO_Application.Emp_no) as Name " & _
            '                        ",DateFrom,DateTo,timeDeparture,timearrival,Destination,purpose,DateApply,Status,isnull(Remarks,'') as Remarks,Emp_no " & _
            '                        "from OB_TO_Application order by DateApply desc"
            _nQuery = " select  isnull(PD.Last_name,'')+ ' ' + isnull(PD.First_name,',  ')+' '+ left(isnull(PD.Mid_name,''),1) +'.' AS NAME," & _
                    " OB.DateFrom,OB.DateTo,OB.timeDeparture,OB.timearrival,OB.Destination,OB.purpose,OB.DateApply,OB.Status,isnull(OB.Remarks,'') as" & _
                    "  Remarks,OB.Emp_no  from [128.1.8.8\mssqlserver2012].SOS_HRIMS.dbo.OB_TO_Application OB  inner join " & _
                    " [TEXAS\MSSQL2014]." & dbactive & ".[dbo].Payroll_Data PD ON PD.emp_no = OB.emp_no"
            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                _nSqlDr.Read()

                If _nSqlDr.HasRows Then

                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If

            End Using

        Catch ex As Exception


        End Try

    End Sub

    Public Sub _pSubupdateApplicationOBTO(idno, dfrom, dto, status, dateupdated, remarks, dateapply) '20200623


        Try

            Dim _nQuery As String = Nothing
            '_nQuery = "update OB_TO_Application set Remarks='" & remarks & "',Status='" & status & "',DateUpdated='" & dateupdated & "' where emp_no='" & idno & "' and DateFrom='" & dfrom & "' and DateTo='" & dto & "' and DateApply='" & dateapply & "'"
            _nQuery = "update OB_TO_Application set Remarks='" & IIf(remarks <> "", "Disapproved " & remarks, "Approved") & "',Status='" & IIf(status = "Approved", 1, 0) & "',DateUpdated='" & dateupdated & "' where emp_no='" & idno & "' and DateFrom='" & dfrom & "' and DateTo='" & dto & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()

        Catch ex As Exception



        End Try

    End Sub
    Public Function _ApplicationidTraining(idno As String) As String
        Try
            Dim _nQuery As String = Nothing
            Dim _nQuery1 As String = Nothing
            Dim s As String, s1 As String
            Dim useridno As String
            useridno = GetString("select  emp_no from Personal_Data where  EmailAdd='" & cSessionUser._pUserID & "'", cGlobalConnections._pSqlCxn_HRIMS, 0, "", 1)
            _nQuery = "select top 1 right(ApplicationIDNO,4) from TrainingApplication where Emp_no ='" & useridno & "'  order by ApplicationIDNO desc "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader
            _read = _nSqlCommand.ExecuteReader()
            _read.Read()
            If _read.HasRows Then
                s1 = _read.Item(0).ToString()
                s1 = s1 + 1
                s1 = Strings.Left(s1, 5)
                If s1 <= 9 Then
                    s = Replace(System.DateTime.Now.ToShortDateString, "/", "") + useridno + "000" + s1
                    idno = s
                ElseIf s1 >= 10 And s1 <= 99 Then
                    s = Replace(System.DateTime.Now.ToShortDateString, "/", "") + useridno + "00" + s1
                    idno = s
                ElseIf s1 >= 100 And s1 <= 999 Then
                    s = Replace(System.DateTime.Now.ToShortDateString, "/", "") + useridno + "0" + s1
                    idno = s
                End If
            Else
                s = Replace(System.DateTime.Now.ToShortDateString, "/", "") + useridno + "0001"
                idno = s
                _read.Close()
                _nSqlCommand.Dispose()
                Return idno
                Exit Function
            End If
            _read.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
        End Try
        Return idno
    End Function

    Public Sub _pSubInsertTrainingApplication(Emp_no, TrainingCourse, TrainingCode, title, DateFrom, DateTo, Venue, ConductedBy, DateApply)
        Try
            Dim xApplicationIDNO As String
            Dim x As String
            xApplicationIDNO = _ApplicationidTraining(x)
            Dim _nQuery As String = Nothing
            _nQuery = "insert into TrainingApplication (ApplicationIDNO,Emp_no, TrainingCourse, TrainingCode, title, DateFrom, DateTo, Venue, ConductedBy, DateApply) values('" & xApplicationIDNO & "','" & Emp_no & "','" & TrainingCourse & "','" & TrainingCode & "','" & title & "','" & DateFrom & "','" & DateTo & "','" & Venue & "','" & ConductedBy & "','" & DateApply & "')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubCreateTApplicationTraining() ' 20200625
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "if not exists (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='TrainingApplication') " & _
                        "CREATE TABLE [dbo].[TrainingApplication]( " & _
                        "	[ApplicationIDNO] [nvarchar](50) NOT NULL, " & _
                        "	[Emp_no] [nvarchar](50) NULL, " & _
                        "	[TrainingCourse] [nvarchar](100) NULL, " & _
                        "	[TrainingCode] [nvarchar](50) NULL, " & _
                        "	[Title] [nvarchar](50) NULL, " & _
                        "	[DateFrom] [smalldatetime] NULL, " & _
                        "	[DateTo] [smalldatetime] NULL, " & _
                        "	[Venue] [nvarchar](50) NULL, " & _
                        "	[ConductedBy] [nvarchar](100) NULL," & _
                        "	[Registration] [numeric](18, 2) NULL, " & _
                        "	[Remark] [nvarchar](100) NULL, " & _
                        "	[Status] [bit] NULL, " & _
                        "	[DateApply] [smalldatetime] NULL, " & _
                        "	[DateUpdated] [smalldatetime] NULL, " & _
                        "	[UpdatedBy] [nvarchar](50) NULL, " & _
                        " CONSTRAINT [PK_TrainingApplication] PRIMARY KEY CLUSTERED " & _
                        "( " & _
                        "	[ApplicationIDNO] ASC " & _
                        ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " & _
                        ") ON [PRIMARY] "

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectTApplicantTraining() ' 20200625
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            '_nQuery = "select (select Last_name + ' ' + First_name +', ' + left(Mid_name,1) + '.' from Payroll_Data ) as Name," & _
            '           "TrainingCourse, Title,DateFrom,DateTo,Venue,ConductedBy,Registration,DateApply,Status from TrainingApplication"
            Dim empno As String
            empno = GetString("select emp_no from Personal_Data where EmailAdd='" & cSessionUser._pUserID & "'", cGlobalConnections._pSqlCxn_PMIPS, 0, "", 1)
            _nQuery = "select (select Last_name + ' ' + First_name +', ' + left(Mid_name,1) + '.' from Payroll_Data where emp_no = TrainingApplication.emp_no) as Name ,TrainingCourse, Title,format(cast(DateFrom as date),'MM-dd-yyyy') as DateFrom,format(cast(DateTo as date),'MM-dd-yyyy') as DateTo,Venue,ConductedBy,isnull(Remark,'') as Remark,format(cast(DateApply as date),'MM-dd-yyyy') as DateApply,Status from TrainingApplication where emp_no = '" & empno & "'order by DateApply "

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectTApplicantTrainingHR() ' 20200625

        Try

            '----------------------------------

            Dim _nQuery As String = Nothing

            Dim _nWhere As String = Nothing


            '----------------------------------                

            '_nQuery = "select (select Last_name + ' ' + First_name +', ' + left(Mid_name,1) + '.' from Payroll_Data ) as Name," & _

            '           "TrainingCourse, Title,DateFrom,DateTo,Venue,ConductedBy,Registration,DateApply,Status from TrainingApplication"

            '_nQuery = "select (select Last_name + ' ' + First_name +', ' + left(Mid_name,1) + '.' from Payroll_Data where emp_no = TrainingApplication.emp_no) as Name ,TrainingCourse, Title,format(cast(DateFrom as date),'MM-dd-yyyy') as DateFrom,format(cast(DateTo as date),'MM-dd-yyyy') as DateTo,Venue,ConductedBy,isnull(Remark,'') as Remark,format(cast(DateApply as date),'MM-dd-yyyy') as DateApply,Status,Remark,Emp_no from TrainingApplication order by DateApply Desc"
            Dim dbactive As String = Nothing
            dbactive = GetString("select  DBInitialCatalog from GlobalConnectionsDefault where SetupGlobalConnectionsDatabases = 'PMIPS'", cGlobalConnections._pSqlCxn_CR, 0, "", 1)

            _nQuery = "select  isnull(PD.Last_name,'')+ ' ' + isnull(PD.First_name,',  ')+' '+ left(isnull(PD.Mid_name,''),1) +'.' AS NAME, " & _
                        "TrainingCourse, Title,format(cast(DateFrom as date),'MM-dd-yyyy') as DateFrom,format(cast(DateTo as date),'MM-dd-yyyy') as DateTo,Venue,ConductedBy,isnull(Remark,'') as Remark,format(cast(DateApply as date),'MM-dd-yyyy') as DateApply,Status,Remark,tr.Emp_no   " & _
                        "from [128.1.8.8\mssqlserver2012].SOS_HRIMS.dbo.TrainingApplication TR  inner join " & _
                        "[TEXAS\MSSQL2014]." & dbactive & ".[dbo].Payroll_Data PD ON PD.emp_no = TR.emp_no"
            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                _nSqlDr.Read()

                If _nSqlDr.HasRows Then

                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If

            End Using

        Catch ex As Exception


        End Try

    End Sub

    Public Sub _pSubupdateApplicationTraining(idno, dfrom, dto, status, dateupdated, remarks, dateapply, updateby) '20200626


        Try

            Dim _nQuery As String = Nothing


            _nQuery = "update TrainingApplication set Status='" & IIf(status = "Approved", 1, 0) & "', Remark='" & IIf(remarks <> "", "Disapproved " & remarks, "Approved") & "',DateUpdated='" & dateupdated & "',UpdatedBy='" & updateby & "' where emp_no='" & idno & "' and DateFrom='" & dfrom & "' and DateTo='" & dto & "' and DateApply='" & dateapply & "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)

            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------

        Catch ex As Exception



        End Try

    End Sub

    Public Sub _pSubupdateok(stat, office, item) '20200623


        Try

            Dim _nQuery As String = Nothing
            _nQuery = "update PDS_Applicant set viewstat='" & stat & "' where USERID ='" & cSessionUser._pIDNo & "' and POSITION_TITLE ='" & office & "' and ITEM_NO='" & item & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()

        Catch ex As Exception



        End Try
    End Sub
    Public Sub _pSubSelectEducCertificate(applicantid, Modules) ' 20200713
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------                
            _nQuery = "  select * from PDS_Attachment where IDNO='" & applicantid & "' and ModuleID='" & Modules & "'"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelectCivil(applicantid, Modules) ' 20200713
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------                
            _nQuery = "  select * from PDS_Attachment where IDNO='" & applicantid & "' and ModuleID='" & Modules & "'"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubSelectWorkExp(applicantid, Modules) ' 20200713
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------                
            _nQuery = "  select * from PDS_Attachment where IDNO='" & applicantid & "' and ModuleID='" & Modules & "'"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelecVoluntaryworkCerti(applicantid, Modules) ' 20200713
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------                
            _nQuery = "  select *e from PDS_Attachment where IDNO='" & applicantid & "' and ModuleID='" & Modules & "'"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelecTrainingCerti(applicantid, Modules) ' 20200713
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------                
            _nQuery = "  select * from PDS_Attachment where IDNO='" & applicantid & "' and ModuleID='" & Modules & "'"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader

                    '  Do While _nSqlDr.Read

                    '_nOwner = _nSqlDr.Item("OWNER").ToString

                    ' Loop

                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "GIMAY"
    Private Shared Leave As New DataTable 'Gimay 20200625
    Private Shared LeaveApplication As New DataTable 'Gimay 20200626

    'Gimay 20200624
    Private Shared _tempRegion As New DataTable
    Private Shared _tempProvince As New DataTable
    Private Shared _tempMunicipal As New DataTable
    Private Shared _tempBarangay As New DataTable

    'Gimay 20200624
    Private Shared _CurRegion As String
    Private Shared _CurProvince As String
    Private Shared _CurMunicipal As String
    Private Shared _CurBarangay As String

    'Gimay 20200624
    Private Shared _RegionDV As New DataView
    Private Shared _ProvinceDV As New DataView
    Private Shared _MunicipalDV As New DataView
    Private Shared _BarangayDV As New DataView


    'Gimay 20200625
    Private Shared _tempPermRegion As New DataTable
    Private Shared _tempPermProvince As New DataTable
    Private Shared _tempPermMunicipal As New DataTable
    Private Shared _tempPermBarangay As New DataTable

    'Gimay 20200625
    Private Shared _CurPermRegion As String
    Private Shared _CurPermProvince As String
    Private Shared _CurPermMunicipal As String
    Private Shared _CurPermBarangay As String

    'Gimay 20200625
    Private Shared _PermRegionDV As New DataView
    Private Shared _PermProvinceDV As New DataView
    Private Shared _PermMunicipalDV As New DataView
    Private Shared _PermBarangayDV As New DataView



    'Gimay 20200518
    Private Shared _mBirthDate As String
    Private Shared _mBirthPlace As String
    Private Shared _mBloodType As String
    Private Shared _mCitizenship As String
    Private Shared _mCivilStatus As String
    Private Shared _mDateApplied As String
    Private Shared _mEmployeeID As String
    Private Shared _mExtName As String
    Private Shared _mFather_FName As String
    Private Shared _mFather_LName As String
    Private Shared _mFather_MName As String
    Private Shared _mFirstName As String
    Private Shared _mGender As String
    Private Shared _mGSIS As String
    Private Shared _mHeight As String
    Private Shared _mIDNO As String
    Private Shared _mLastName As String
    Private Shared _mMiddleName As String
    Private Shared _mMother_FName As String
    Private Shared _mMother_LName As String
    Private Shared _mMother_MName As String
    Private Shared _mPagIbig As String
    Private Shared _mPermanent_Add As String
    Private Shared _mPhilHealth As String
    Private Shared _mPictureFile As String
    Private Shared _mReligion As String
    Private Shared _mResidential_Add As String
    Private Shared _mSpouse_BusinessAdd As String
    Private Shared _mSpouse_BusinessName As String
    Private Shared _mSpouse_FName As String
    Private Shared _mSpouse_LName As String
    Private Shared _mSpouse_MName As String
    Private Shared _mSpouse_Occupation As String
    Private Shared _mSpouse_TelNo As String
    Private Shared _mTin As String
    Private Shared _mWeight As String

    Private Shared _mSSSno As String 'Gimay 20200715

    Private Shared _mProfilePic As Byte() 'Gimay 20200623

    Private Shared _mSuccessful As Boolean
    Private Shared _mErrMsg As String

    'Gimay 20200605
    Private Shared _mDateUpdated As String
    Private Shared _mEmp_No As String
    Private Shared _mEmpLDays As String
    Private Shared _mEmpLFrom As String
    Private Shared _mEmpLTo As String
    Private Shared _mLeaveCode As String
    Private Shared _mLeaveDesc As String
    Private Shared _mRemarks As String
    Private Shared _mStatus As String

    'Gimay 20200626
    Private Shared _mDepartment As String
    Private Shared _mOffice As String
    Private Shared _mDateHired As String



    Private Shared Attachments As New DataTable 'Gimay 20200629
    'Gimay 20200714
    Private Shared _mCareerService As String
    Private Shared _mCS_NO As String
    Private Shared _mDateOfExamination As String
    Private Shared _mFileData As String
    Private Shared _mFileName As String
    Private Shared _mFileType As String
    Private Shared _mLicenseDate As String
    Private Shared _mLicenseNo As String
    Private Shared _mPlaceOfExamination As String
    Private Shared _mRating As String

    'Gimay 20200714
    Private Shared _mAppointmentStatus As String
    Private Shared _mEmployer As String
    Private Shared _mEXP_NO As String
    Private Shared _mForwarded As String
    Private Shared _mFrom As String
    Private Shared _mGovService As String
    Private Shared _mJobPosition As String
    Private Shared _mMonthlySalary As String
    Private Shared _mSalaryGrade As String
    Private Shared _mTo As String


    'Gimay 20200714
    Private Shared _mdFrom As String
    Private Shared _mdTo As String
    Private Shared _mNatureofWork As String
    Private Shared _mNumberofHours As String
    Private Shared _mOrganizationAddress As String
    Private Shared _mOrganizationName As String
    Private Shared _mPosition As String
    Private Shared _mSeqNo As String


    'Gimay 20200714
    Private Shared _mConductedSponsoredBy As String
    Private Shared _mTitleofSeminarConferenceWorkshopShortCourse As String
    Private Shared _mTypeofLearningDevelopment As String

    'Gimay 20200714
    Private Shared _mMembershipinAssociationOrganization As String
    Private Shared _mNonAcademicDistinctionsRecognition As String
    Private Shared _mSpecialSkillsHobbies As String

    'Gimay 20200714
    Private Shared _mDATEFROM As String
    Private Shared _mDATETO As String
    Private Shared _mDEGREECOURSEDETAIL As String
    Private Shared _mEDUCATIONLEVEL As String
    Private Shared _mEL_NO As String
    Private Shared _mHIGHESTGRADELEVELUNITSEARNED As String
    Private Shared _mINSTITUTIONNAME As String
    Private Shared _mSCHOLARSHIPACADEMICHONORSDETAIL As String
    Private Shared _mYEARGRADUATED As String

    'Gimay 20200715
    Private Shared _mAddress As String
    Private Shared _mTelNo As String
    Private Shared _mFullName As String


    Public Shared Property _pAttachments() As DataTable 'Gimay 20200629
        Get
            Return Attachments
        End Get
        Set(value As DataTable)
            Attachments = value
        End Set
    End Property

    Public Shared Property _pRemarks() As String  'Gimay 20200626
        Get
            Return _mRemarks
        End Get
        Set(value As String)
            _mRemarks = value
        End Set
    End Property


    Public Shared Property _pDateUpdated() As String 'Gimay 20200626
        Get
            Return _mDateUpdated
        End Get
        Set(value As String)
            _mDateUpdated = value
        End Set
    End Property


    Public Shared Property _pDateHired() As String 'Gimay 20200626
        Get
            Return _mDateHired
        End Get
        Set(value As String)
            _mDateHired = value
        End Set
    End Property


    Public Shared Property _pDepartment() As String 'Gimay 20200626
        Get
            Return _mDepartment
        End Get
        Set(value As String)
            _mDepartment = value
        End Set
    End Property

    Public Shared Property _pOffice() As String 'Gimay 202006246
        Get
            Return _mOffice
        End Get
        Set(value As String)
            _mOffice = value
        End Set
    End Property

    Public Shared Property _pLeaveDT() As DataTable 'Gimay 20200625
        Get
            Return Leave
        End Get
        Set(value As DataTable)
            Leave = value
        End Set
    End Property

    Public Shared Property _pLeaveApplication() As DataTable 'Gimay 20200626
        Get
            Return LeaveApplication
        End Get
        Set(value As DataTable)
            LeaveApplication = value
        End Set
    End Property

#Region "Residential Location"
    Public Shared Property _pRegionDT() As DataTable 'Gimay 20200624
        Get
            Return _tempRegion
        End Get
        Set(value As DataTable)
            _tempRegion = value
        End Set
    End Property

    Public Shared Property _pProvinceDT() As DataTable 'Gimay 20200624
        Get
            Return _tempProvince
        End Get
        Set(value As DataTable)
            _tempProvince = value
        End Set
    End Property

    Public Shared Property _pMunicipalDT() As DataTable 'Gimay 20200624
        Get
            Return _tempMunicipal
        End Get
        Set(value As DataTable)
            _tempMunicipal = value
        End Set
    End Property

    Public Shared Property _pBarangayDT() As DataTable 'Gimay 20200624
        Get
            Return _tempBarangay
        End Get
        Set(value As DataTable)
            _tempBarangay = value
        End Set
    End Property



    Public Shared Property _pRegionDV() As DataView 'Gimay 20200624
        Get
            Return _RegionDV
        End Get
        Set(value As DataView)
            _RegionDV = value
        End Set
    End Property

    Public Shared Property _pProvinceDV() As DataView 'Gimay 20200624
        Get
            Return _ProvinceDV
        End Get
        Set(value As DataView)
            _ProvinceDV = value
        End Set
    End Property

    Public Shared Property _pMunicipalDV() As DataView 'Gimay 20200624
        Get
            Return _MunicipalDV
        End Get
        Set(value As DataView)
            _MunicipalDV = value
        End Set
    End Property

    Public Shared Property _pBarangayDV() As DataView 'Gimay 20200624
        Get
            Return _BarangayDV
        End Get
        Set(value As DataView)
            _BarangayDV = value
        End Set
    End Property

    Public Shared Property _pCurRegion() As String 'Gimay 20200624 
        Get
            Return _CurRegion
        End Get
        Set(value As String)
            _CurRegion = value
        End Set
    End Property

    Public Shared Property _pCurProvince() As String 'Gimay 20200624
        Get
            Return _CurProvince
        End Get
        Set(value As String)
            _CurProvince = value
        End Set
    End Property

    'Gimay 20200624
    Public Shared Property _pCurMunicipal() As String
        Get
            Return _CurMunicipal
        End Get
        Set(value As String)
            _CurMunicipal = value
        End Set
    End Property

    'Gimay 20200624
    Public Shared Property _pCurBarangay() As String
        Get
            Return _CurBarangay
        End Get
        Set(value As String)
            _CurBarangay = value
        End Set
    End Property


    Public Shared Property _pProfilePic() As Byte() 'Gimay 20200623
        Get
            Return _mProfilePic
        End Get
        Set(value As Byte())
            _mProfilePic = value
        End Set
    End Property
#End Region 'Gimay 20200624

#Region "Permanent Location"
    Public Shared Property _pPermRegionDT() As DataTable 'Gimay 20200624
        Get
            Return _tempPermRegion
        End Get
        Set(value As DataTable)
            _tempPermRegion = value
        End Set
    End Property

    Public Shared Property _pPermProvinceDT() As DataTable 'Gimay 20200624
        Get
            Return _tempPermProvince
        End Get
        Set(value As DataTable)
            _tempPermProvince = value
        End Set
    End Property

    Public Shared Property _pPermMunicipalDT() As DataTable 'Gimay 20200624
        Get
            Return _tempPermMunicipal
        End Get
        Set(value As DataTable)
            _tempPermMunicipal = value
        End Set
    End Property

    Public Shared Property _pPermBarangayDT() As DataTable 'Gimay 20200624
        Get
            Return _tempPermBarangay
        End Get
        Set(value As DataTable)
            _tempPermBarangay = value
        End Set
    End Property



    Public Shared Property _pPermRegionDV() As DataView 'Gimay 20200624
        Get
            Return _PermRegionDV
        End Get
        Set(value As DataView)
            _PermRegionDV = value
        End Set
    End Property

    Public Shared Property _pPermProvinceDV() As DataView 'Gimay 20200624
        Get
            Return _PermProvinceDV
        End Get
        Set(value As DataView)
            _PermProvinceDV = value
        End Set
    End Property

    Public Shared Property _pPermMunicipalDV() As DataView 'Gimay 20200624
        Get
            Return _PermMunicipalDV
        End Get
        Set(value As DataView)
            _PermMunicipalDV = value
        End Set
    End Property

    Public Shared Property _pPermBarangayDV() As DataView 'Gimay 20200624
        Get
            Return _PermBarangayDV
        End Get
        Set(value As DataView)
            _PermBarangayDV = value
        End Set
    End Property

    Public Shared Property _pPermCurRegion() As String 'Gimay 20200624 
        Get
            Return _CurPermRegion
        End Get
        Set(value As String)
            _CurPermRegion = value
        End Set
    End Property

    Public Shared Property _pPermCurProvince() As String 'Gimay 20200624
        Get
            Return _CurPermProvince
        End Get
        Set(value As String)
            _CurPermProvince = value
        End Set
    End Property

    'Gimay 20200624
    Public Shared Property _pPermCurMunicipal() As String
        Get
            Return _CurPermMunicipal
        End Get
        Set(value As String)
            _CurPermMunicipal = value
        End Set
    End Property

    'Gimay 20200624
    Public Shared Property _pPermCurBarangay() As String
        Get
            Return _CurPermBarangay
        End Get
        Set(value As String)
            _CurPermBarangay = value
        End Set
    End Property



#End Region 'Gimay 20200625

    Public Shared Property _pPermProfilePic() As Byte() 'Gimay 20200623
        Get
            Return _mProfilePic
        End Get
        Set(value As Byte())
            _mProfilePic = value
        End Set
    End Property


    Public Shared Property _pBirthDate() As String
        Get
            Return _mBirthDate
        End Get
        Set(value As String)
            _mBirthDate = value
        End Set
    End Property

    Public Shared Property _pBirthPlace() As String
        Get
            Return _mBirthPlace
        End Get
        Set(value As String)
            _mBirthPlace = value
        End Set
    End Property

    Public Shared Property _pBloodType() As String
        Get
            Return _mBloodType
        End Get
        Set(value As String)
            _mBloodType = value
        End Set
    End Property

    Public Shared Property _pCitizenship() As String
        Get
            Return _mCitizenship
        End Get
        Set(value As String)
            _mCitizenship = value
        End Set
    End Property

    Public Shared Property _pCivilStatus() As String
        Get
            Return _mCivilStatus
        End Get
        Set(value As String)
            _mCivilStatus = value
        End Set
    End Property

    Public Shared Property _pDateApplied() As String
        Get
            Return _mDateApplied
        End Get
        Set(value As String)
            _mDateApplied = value
        End Set
    End Property

    Public Shared Property _pEmployeeID() As String
        Get
            Return _mEmployeeID
        End Get
        Set(value As String)
            _mEmployeeID = value
        End Set
    End Property

    Public Shared Property _pExtName() As String
        Get
            Return _mExtName
        End Get
        Set(value As String)
            _mExtName = value
        End Set
    End Property

    Public Shared Property _pFather_FName() As String
        Get
            Return _mFather_FName
        End Get
        Set(value As String)
            _mFather_FName = value
        End Set
    End Property

    Public Shared Property _pFather_LName() As String
        Get
            Return _mFather_LName
        End Get
        Set(value As String)
            _mFather_LName = value
        End Set
    End Property

    Public Shared Property _pFather_MName() As String
        Get
            Return _mFather_MName
        End Get
        Set(value As String)
            _mFather_MName = value
        End Set
    End Property



    Public Shared Property _pGender() As String
        Get
            Return _mGender
        End Get
        Set(value As String)
            _mGender = value
        End Set
    End Property

    Public Shared Property _pGSIS() As String
        Get
            Return _mGSIS
        End Get
        Set(value As String)
            _mGSIS = value
        End Set
    End Property

    Public Shared Property _pHeight() As String
        Get
            Return _mHeight
        End Get
        Set(value As String)
            _mHeight = value
        End Set
    End Property



    Public Shared Property _pLastName() As String
        Get
            Return _mLastName
        End Get
        Set(value As String)
            _mLastName = value
        End Set
    End Property

    Public Shared Property _pMiddleName() As String
        Get
            Return _mMiddleName
        End Get
        Set(value As String)
            _mMiddleName = value
        End Set
    End Property

    Public Shared Property _pMother_FName() As String
        Get
            Return _mMother_FName
        End Get
        Set(value As String)
            _mMother_FName = value
        End Set
    End Property

    Public Shared Property _pMother_LName() As String
        Get
            Return _mMother_LName
        End Get
        Set(value As String)
            _mMother_LName = value
        End Set
    End Property

    Public Shared Property _pMother_MName() As String
        Get
            Return _mMother_MName
        End Get
        Set(value As String)
            _mMother_MName = value
        End Set
    End Property

    Public Shared Property _pPagIbig() As String
        Get
            Return _mPagIbig
        End Get
        Set(value As String)
            _mPagIbig = value
        End Set
    End Property

    Public Shared Property _pPermanent_Add() As String
        Get
            Return _mPermanent_Add
        End Get
        Set(value As String)
            _mPermanent_Add = value
        End Set
    End Property

    Public Shared Property _pPhilHealth() As String
        Get
            Return _mPhilHealth
        End Get
        Set(value As String)
            _mPhilHealth = value
        End Set
    End Property

    Public Shared Property _pPictureFile() As String
        Get
            Return _mPictureFile
        End Get
        Set(value As String)
            _mPictureFile = value
        End Set
    End Property

    Public Shared Property _pReligion() As String
        Get
            Return _mReligion
        End Get
        Set(value As String)
            _mReligion = value
        End Set
    End Property

    Public Shared Property _pResidential_Add() As String
        Get
            Return _mResidential_Add
        End Get
        Set(value As String)
            _mResidential_Add = value
        End Set
    End Property

    Public Shared Property _pSpouse_BusinessAdd() As String
        Get
            Return _mSpouse_BusinessAdd
        End Get
        Set(value As String)
            _mSpouse_BusinessAdd = value
        End Set
    End Property

    Public Shared Property _pSpouse_BusinessName() As String
        Get
            Return _mSpouse_BusinessName
        End Get
        Set(value As String)
            _mSpouse_BusinessName = value
        End Set
    End Property

    Public Shared Property _pSpouse_FName() As String
        Get
            Return _mSpouse_FName
        End Get
        Set(value As String)
            _mSpouse_FName = value
        End Set
    End Property

    Public Shared Property _pSpouse_LName() As String
        Get
            Return _mSpouse_LName
        End Get
        Set(value As String)
            _mSpouse_LName = value
        End Set
    End Property

    Public Shared Property _pSpouse_MName() As String
        Get
            Return _mSpouse_MName
        End Get
        Set(value As String)
            _mSpouse_MName = value
        End Set
    End Property

    Public Shared Property _pSpouse_Occupation() As String
        Get
            Return _mSpouse_Occupation
        End Get
        Set(value As String)
            _mSpouse_Occupation = value
        End Set
    End Property

    Public Shared Property _pSpouse_TelNo() As String
        Get
            Return _mSpouse_TelNo
        End Get
        Set(value As String)
            _mSpouse_TelNo = value
        End Set
    End Property

    Public Shared Property _pSSSno() As String 'Gimay 20200715
        Get
            Return _mSSSno
        End Get
        Set(value As String)
            _mSSSno = value
        End Set
    End Property

    Public Shared Property _pTin() As String
        Get
            Return _mTin
        End Get
        Set(value As String)
            _mTin = value
        End Set
    End Property

    Public Shared Property _pWeight() As String
        Get
            Return _mWeight
        End Get
        Set(value As String)
            _mWeight = value
        End Set
    End Property

    Shared Property _pSuccessful() As Boolean
        Get
            Return _mSuccessful
        End Get
        Set(ByVal value As Boolean)
            _mSuccessful = value
        End Set
    End Property

    Shared Property _pErrMsg() As String
        Get
            Return _mSuccessful
        End Get
        Set(ByVal value As String)
            _mErrMsg = value
        End Set
    End Property

    Public Shared Property _pEmp_No() As String
        Get
            Return _mEmp_No
        End Get
        Set(value As String)
            _mEmp_No = value
        End Set
    End Property

    Public Shared Property _pEmpLDays() As String
        Get
            Return _mEmpLDays
        End Get
        Set(value As String)
            _mEmpLDays = value
        End Set
    End Property

    Public Shared Property _pEmpLFrom() As String
        Get
            Return _mEmpLFrom
        End Get
        Set(value As String)
            _mEmpLFrom = value
        End Set
    End Property

    Public Shared Property _pEmpLTo() As String
        Get
            Return _mEmpLTo
        End Get
        Set(value As String)
            _mEmpLTo = value
        End Set
    End Property

    Public Shared Property _pStatus() As String
        Get
            Return _mStatus
        End Get
        Set(value As String)
            _mStatus = value
        End Set
    End Property

    Public Shared Property _pLeaveCode() As String
        Get
            Return _mLeaveCode
        End Get
        Set(value As String)
            _mLeaveCode = value
        End Set
    End Property

    Public Shared Property _pLeaveDesc() As String
        Get
            Return _mLeaveDesc
        End Get
        Set(value As String)
            _mLeaveDesc = value
        End Set
    End Property


    Public Function ByteToImage(ByVal ImageByte As Byte()) As Bitmap 'Gimay 20200629
        Try
            If IsNothing(ImageByte) = False Then
                Dim stream As New MemoryStream(ImageByte)
                Dim bmp As New Bitmap(stream)
                Return bmp
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        Finally
        End Try
    End Function


    'Public Sub _pChildControl(ByVal _mCommand As String,
    '                         ByVal _mFirstName As String,
    '                         ByVal _mMiddleName As String,
    '                         ByVal _mLastName As String,
    '                         ByVal _mBirthDate As String)

    'Gimay 20200715
    Public Sub _pChildControl(ByVal _mCommand As String,
                           ByVal _mFullName As String,
                           ByVal _mBirthDate As String)
        Try
            'Dim _FullName As String = cSessionUser._pFirstName & cSessionUser._pMiddleName & cSessionUser._pLastName
            Dim _user As String = cSessionUser._pIDNo
            Select Case _mCommand
                Case "Add"
                    '_mSqlCommand = New SqlCommand(" insert into temp_" & _user & " " &
                    '                              " (FirstName,MiddleName,LastName,BirthDate) " &
                    '                              " values (" &
                    '                              " '" & _mFirstName & "', " &
                    '                              " '" & _mMiddleName & "', " &
                    '                              " '" & _mLastName & "', " &
                    '                              " '" & _mBirthDate & "' " &
                    '                              ")", _mSqlConnection)

                    'Gimay 20200715
                    _mSqlCommand = New SqlCommand(" insert into temp_" & _user & " " &
                                                  " (FullName,BirthDate) " &
                                                  " values (" &
                                                  " '" & _mFullName & "', " &
                                                  " '" & _mBirthDate & "' " &
                                                  ")", _mSqlConnection)

                    _mSqlCommand.ExecuteNonQuery()

                Case "Delete"
                    '_mSqlCommand = New SqlCommand(" delete temp_" & _user & " where  " &
                    '                              " FirstName='" & _mFirstName & "' " &
                    '                              " MiddleName='" & _mMiddleName & "' " &
                    '                              " LastName='" & _mLastName & "' " &
                    '                              " BirthDate='" & _mBirthDate & "' " &
                    '                              "", _mSqlConnection)

                    'Gimay 20200715
                    _mSqlCommand = New SqlCommand(" delete temp_" & _user & " where  " &
                                                  " FullName='" & _mFullName & "' " &
                                                  "", _mSqlConnection)

                    _mSqlCommand.ExecuteNonQuery()
            End Select

            _mSqlCommand.Dispose()

        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub

    'Gimay 20200518
    Public Sub DeleteTempChild(ByVal _mCode As String)
        Try
            _mSqlCommand = New SqlCommand("IF EXISTS (SELECT name FROM sys.objects WHERE name = N'temp_" & _mCode & "') drop table temp_" & _mCode & "", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub

    'Gimay 20200524
    Public Sub DeleteTempLocation(ByVal _mCode As String)
        Try
            _mSqlCommand = New SqlCommand("IF EXISTS (SELECT name FROM sys.objects WHERE name = N'tempLoc_" & _mCode & "') drop table temp_" & _mCode & "", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub


    Public Sub DeleteTempAttachment(ByVal _mCode As String)
        Try
            _mSqlCommand = New SqlCommand("IF EXISTS (SELECT name FROM sys.objects WHERE name = N'TempAttachment_" & _mCode & "') drop table TempAttachment_" & _mCode & "", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub

    'Gimay 20200518
    Public Sub CreateTempChild()
        Try
            'Dim _FullName As String = cSessionUser._pFirstName & cSessionUser._pMiddleName & cSessionUser._pLastName
            Dim _user As String = cSessionUser._pIDNo
            DeleteTempChild(_user)

            'Gimay 20200715
            _mSqlCommand = New SqlCommand("create table temp_" & _user & " " &
                                          "( " &
                                          " [FullName] [nvarchar](50) NULL, " &
                                          " [FirstName] [nvarchar](50) NULL, " &
                                          " [MiddleName] [nvarchar](50) NULL, " &
                                          " [LastName] [nvarchar](50) NULL, " &
                                          " [BirthDate] [smalldatetime] NULL," &
                                          ") ", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub


    'Gimay 20200602
    Public Sub CreateTempAttachment()
        Try
            'Dim _FullName As String = cSessionUser._pFirstName & cSessionUser._pMiddleName & cSessionUser._pLastName
            Dim _user As String = cSessionUser._pIDNo
            DeleteTempAttachment(_user)

            _mSqlCommand = New SqlCommand("create table TempAttachment_" & _user & " " &
                                          "( " &
                                          " [IDNO] [nvarchar](50) NULL, " &
                                          " [TYPE] [nvarchar](250) NULL, " &
                                          " [FILE_NAME] [nvarchar](250) NULL, " &
                                          " [FILE_DATA] [varbinary](max) NULL," &
                                          ") ", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub


    'Gimay 20200524
    Public Sub CreateTempLocation()
        Try
            Dim _user As String = cSessionUser._pIDNo
            DeleteTempLocation(_user)

            _mSqlCommand = New SqlCommand("create table tempLoc_" & _user & " " &
                                          "( " &
                                          " [Region] [nvarchar](250) NULL, " &
                                          " [Province] [nvarchar](250) NULL, " &
                                          " [Municipal] [nvarchar](250) NULL, " &
                                          " [Barangay] [nvarchar](250) NULL," &
                                          " [Other] [nvarchar](1000) NULL," &
                                          " [PermRegion] [nvarchar](250) NULL, " &
                                          " [PermProvince] [nvarchar](250) NULL, " &
                                          " [PermMunicipal] [nvarchar](250) NULL, " &
                                          " [PermBarangay] [nvarchar](250) NULL," &
                                          " [PermOther] [nvarchar](1000) NULL," &
                                          ") ", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try
    End Sub

    Public Sub _pDeleteChild(ByVal _tempID As String)
        Try
            _mSqlCommand = New SqlCommand(" delete temp_PDS_SUB where IDNO='" & _tempID & "' ", _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSaveChild(ByVal _tempID As String) 'Gimay 20200519
        Dim _nStrSql As String
        Try
            '_nStrSql = " delete temp_PDS_SUB where IDNO='" & _mIDNO & "' "
            _pDeleteChild(_tempID)
            'Dim _FullName As String = cSessionUser._pFirstName & cSessionUser._pMiddleName & cSessionUser._pLastName
            Dim _user As String = cSessionUser._pIDNo
            '_nStrSql = " insert into temp_PDS_SUB select '" & _tempID & "', FirstName,MiddleName,LastName,BirthDate from temp_" & _user & ""

            'Gimay 20200715
            _nStrSql = " insert into temp_PDS_SUB select '" & _tempID & "', FirstName,MiddleName,LastName,BirthDate,FullName from temp_" & _user & ""

            '_nStrSql = " EXEC [sp_temp_PDS_sub_IUD] @Action = 'INSERT' " &
            '                     IIf(_mBirthDate = "", "", ",@BirthDate= N'" & _mBirthDate & "' ") &
            '                     IIf(_mFirstName = "", "", ",@FirstName= N'" & _mFirstName & "' ") &
            '                     IIf(_mIDNO = "", "", ",@IDNO= N'" & _mIDNO & "' ") &
            '                     IIf(_mLastName = "", "", ",@LastName= N'" & _mLastName & "' ") &
            '                     IIf(_mMiddleName = "", "", ",@MiddleName= N'" & _mMiddleName & "' ") &
            '                     ",@Successful = @Successful output  " &
            '                     ",@ErrMsg = @ErrMsg output  "

            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlConnection)

            ''set paramater Success
            '_mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            ''set paramater Error
            '_mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            '_mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            '_mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            '_mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value

            _mSuccessful = True
        Catch ex As Exception
            _mSuccessful = False
        End Try
    End Sub

    Public Sub _pSaveLeave()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_Temp_LeaveApplication_IUD] @Action = 'INSERT' " &
                                IIf(_mEmp_No = "", "", ",@Emp_No= N'" & _mEmp_No & "' ") &
                                IIf(_mEmpLDays = "", "", ",@EmpLDays= N'" & _mEmpLDays & "' ") &
                                IIf(_mEmpLFrom = "", "", ",@EmpLFrom= N'" & _mEmpLFrom & "' ") &
                                IIf(_mEmpLTo = "", "", ",@EmpLTo= N'" & _mEmpLTo & "' ") &
                                IIf(_mIDNO = "", "", ",@IDNO= N'" & _mIDNO & "' ") &
                                IIf(_mLeaveCode = "", "", ",@LeaveCode= N'" & _mLeaveCode & "' ") &
                                IIf(_mLeaveDesc = "", "", ",@LeaveDesc= N'" & _mLeaveDesc & "' ") &
                                IIf(_mStatus = "", "", ",@Status= N'" & _mStatus & "' ") &
                                IIf(_mDateApplied = "", "", ",@DateApplied= N'" & _mDateApplied & "' ") &
                                ",@Successful = @Successful output  " &
                                ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlConnection)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub

    Public Function _pCheckLeave(ByVal _mCond As String) As Boolean 'Gimay 20200710
        Dim _nStrSql As String = ""
        Try

            _mCond = Replace(_mCond, "'", "''")
            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_Temp_LeaveApplication_IUD] @Action = 'SELECT' " &
                       ",@SelectCond='" & _mCond & "' " &
                       ",@Successful = @Successful output  " &
                       ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlConnection)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    Return True
                Else
                    Return False
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub _pCheckPDS(ByRef HasRec As Boolean, ByVal Switch As String, Optional ByVal skipcheck As Boolean = False)
        Try
            'If _oButtonSubmitPersonalInformation.Text = "Edit" Or _oButtonSubmitPersonalInformation.Text = "Update" Then Return True : Exit Function

            If skipcheck = True Then HasRec = True : Exit Sub
            Try
                'Dim UserFullName As String = cSessionUser._pFirstName & cSessionUser._pMiddleName & cSessionUser._pLastName
                Dim _nQuery As String = ""

                Select Case Switch
                    Case "personalinfo"
                        '_nQuery = "select [IDNO],[PictureFile],convert(varchar,[DateApplied],101) as [DateApplied],FirstName],[MiddleName],[LastName],[ExtName],convert(varchar,[birthdate],101) as [birthdate],BirthPlace],[Gender],[CivilStatus],[Citizenship],[BloodType],[Religion],[Height],[Weight],[Tin],[PagIbig],[PhilHealth],[GSIS],[EmployeeID],[Residential_Add],[Permanent_Add] from temp_PDS where isnull(FirstName,'') + isnull(MiddleName,'') + isnull(LastName,'') = '" & UserFullName & "'"
                        _nQuery = "select [IDNO],[PictureFile],convert(varchar,[DateApplied],101) as [DateApplied],[FirstName],[MiddleName],[LastName],[ExtName],convert(varchar,[birthdate],101) as [birthdate],[BirthPlace],[Gender],[CivilStatus],[Citizenship],[BloodType],[Religion], format([Height],'0.00') as [Height] ,cast([Weight] as int) as [Weight],[Tin],[PagIbig],[PhilHealth],[GSIS],[EmployeeID],[Residential_Add],[Permanent_Add],SSSNo from temp_PDS where IDNO = '" & cSessionUser._pIDNo & "'"
                    Case "familybackground"
                        _nQuery = "select Father_FName,Father_MName,Father_LName,Mother_FName,Mother_MName,Mother_LName,Spouse_FName,Spouse_MName,Spouse_LName,Spouse_Occupation,Spouse_BusinessName,Spouse_BusinessAdd,Spouse_TelNo,CivilStatus from temp_PDS where IDNO='" & cSessionUser._pIDNo & "' "
                End Select

                _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

                Using _tempReader As SqlDataReader = _mSqlCommand.ExecuteReader
                    _tempReader.Read()

                    If _tempReader.HasRows Then
                        Select Case Switch
                            Case "personalinfo"

                                If IsDBNull(_tempReader.Item("BirthDate").ToString) Then
                                    _mBirthDate = ""
                                Else
                                    _mBirthDate = UCase(_tempReader.Item("BirthDate").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("BirthPlace").ToString) Then
                                    _mBirthPlace = ""
                                Else
                                    _mBirthPlace = UCase(_tempReader.Item("BirthPlace").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("BloodType").ToString) Then
                                    _mBloodType = ""
                                Else
                                    _mBloodType = UCase(_tempReader.Item("BloodType").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Citizenship").ToString) Then
                                    _mCitizenship = ""
                                Else
                                    _mCitizenship = UCase(_tempReader.Item("Citizenship").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("CivilStatus").ToString) Then
                                    _mCivilStatus = ""
                                Else
                                    _mCivilStatus = UCase(_tempReader.Item("CivilStatus").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("DateApplied").ToString) Then
                                    _mDateApplied = ""
                                Else
                                    _mDateApplied = UCase(_tempReader.Item("DateApplied").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("EmployeeID").ToString) Then
                                    _mEmployeeID = ""
                                Else
                                    _mEmployeeID = UCase(_tempReader.Item("EmployeeID").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("ExtName").ToString) Then
                                    _mExtName = ""
                                Else
                                    _mExtName = UCase(_tempReader.Item("ExtName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("FirstName").ToString) Then
                                    _mFirstName = ""
                                Else
                                    _mFirstName = UCase(_tempReader.Item("FirstName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Gender").ToString) Then
                                    _mGender = ""
                                Else
                                    _mGender = UCase(_tempReader.Item("Gender").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("GSIS").ToString) Then
                                    _mGSIS = ""
                                Else
                                    _mGSIS = UCase(_tempReader.Item("GSIS").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Height").ToString) Then
                                    _mHeight = ""
                                Else
                                    _mHeight = UCase(_tempReader.Item("Height").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("IDNO").ToString) Then
                                    _mIDNO = ""
                                Else
                                    _mIDNO = UCase(_tempReader.Item("IDNO").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("LastName").ToString) Then
                                    _mLastName = ""
                                Else
                                    _mLastName = UCase(_tempReader.Item("LastName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("MiddleName").ToString) Then
                                    _mMiddleName = ""
                                Else
                                    _mMiddleName = UCase(_tempReader.Item("MiddleName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("PagIbig").ToString) Then
                                    _mPagIbig = ""
                                Else
                                    _mPagIbig = UCase(_tempReader.Item("PagIbig").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Permanent_Add").ToString) Then
                                    _mPermanent_Add = ""
                                Else
                                    _mPermanent_Add = UCase(_tempReader.Item("Permanent_Add").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("PhilHealth").ToString) Then
                                    _mPhilHealth = ""
                                Else
                                    _mPhilHealth = UCase(_tempReader.Item("PhilHealth").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("PictureFile").ToString) Then
                                    _mPictureFile = ""
                                Else
                                    _mPictureFile = UCase(_tempReader.Item("PictureFile").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Religion").ToString) Then
                                    _mReligion = ""
                                Else
                                    _mReligion = UCase(_tempReader.Item("Religion").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Residential_Add").ToString) Then
                                    _mResidential_Add = ""
                                Else
                                    _mResidential_Add = UCase(_tempReader.Item("Residential_Add").ToString)
                                End If

                                'Gimay 20200715
                                If IsDBNull(_tempReader.Item("SSSno").ToString) Then
                                    _mSSSno = ""
                                Else
                                    _mSSSno = UCase(_tempReader.Item("SSSno").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Tin").ToString) Then
                                    _mTin = ""
                                Else
                                    _mTin = UCase(_tempReader.Item("Tin").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Weight").ToString) Then
                                    _mWeight = ""
                                Else
                                    _mWeight = UCase(_tempReader.Item("Weight").ToString)
                                End If

                                'While _tempReader.Read
                                '_pBirthPlace = _tempReader.Item("BirthPlace").ToString
                                '_pBloodType = _tempReader.Item("BloodType").ToString
                                '_pCitizenship = _tempReader.Item("Citizenship").ToString
                                '_pCivilStatus = _tempReader.Item("CivilStatus").ToString
                                '_pDateApplied = _tempReader.Item("DateApplied").ToString
                                '_pEmployeeID = _tempReader.Item("EmployeeID").ToString
                                '_pExtName = _tempReader.Item("ExtName").ToString
                                '_pGender = _tempReader.Item("Gender").ToString
                                '_pGSIS = _tempReader.Item("GSIS").ToString
                                '_pHeight = _tempReader.Item("Height").ToString
                                '_pIDNO = _tempReader.Item("IDNO").ToString
                                '_pPagIbig = _tempReader.Item("PAGIBIG").ToString
                                '_pPhilHealth = _tempReader.Item("PhilHealth").ToString
                                '_pReligion = _tempReader.Item("Religion").ToString
                                '_pTin = _tempReader.Item("TIN").ToString
                                '_pWeight = _tempReader.Item("Weight").ToString
                                '_pBirthDate = _tempReader.Item("BirthDate").ToString
                                '_pResidential_Add = _tempReader.Item("Residential_Add").ToString
                                '_pPermanent_Add = _tempReader.Item("Permanent_Add").ToString
                            Case "familybackground"
                                If IsDBNull(_tempReader.Item("Father_FName").ToString) Then
                                    _mFather_FName = ""
                                Else
                                    _mFather_FName = UCase(_tempReader.Item("Father_FName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Father_LName").ToString) Then
                                    _mFather_LName = ""
                                Else
                                    _mFather_LName = UCase(_tempReader.Item("Father_LName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Father_MName").ToString) Then
                                    _mFather_MName = ""
                                Else
                                    _mFather_MName = UCase(_tempReader.Item("Father_MName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Mother_FName").ToString) Then
                                    _mMother_FName = ""
                                Else
                                    _mMother_FName = UCase(_tempReader.Item("Mother_FName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Mother_LName").ToString) Then
                                    _mMother_LName = ""
                                Else
                                    _mMother_LName = UCase(_tempReader.Item("Mother_LName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Mother_MName").ToString) Then
                                    _mMother_MName = ""
                                Else
                                    _mMother_MName = UCase(_tempReader.Item("Mother_MName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_BusinessAdd").ToString) Then
                                    _mSpouse_BusinessAdd = ""
                                Else
                                    _mSpouse_BusinessAdd = UCase(_tempReader.Item("Spouse_BusinessAdd").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_BusinessName").ToString) Then
                                    _mSpouse_BusinessName = ""
                                Else
                                    _mSpouse_BusinessName = UCase(_tempReader.Item("Spouse_BusinessName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_FName").ToString) Then
                                    _mSpouse_FName = ""
                                Else
                                    _mSpouse_FName = UCase(_tempReader.Item("Spouse_FName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_LName").ToString) Then
                                    _mSpouse_LName = ""
                                Else
                                    _mSpouse_LName = UCase(_tempReader.Item("Spouse_LName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_MName").ToString) Then
                                    _mSpouse_MName = ""
                                Else
                                    _mSpouse_MName = UCase(_tempReader.Item("Spouse_MName").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_Occupation").ToString) Then
                                    _mSpouse_Occupation = ""
                                Else
                                    _mSpouse_Occupation = UCase(_tempReader.Item("Spouse_Occupation").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("Spouse_TelNo").ToString) Then
                                    _mSpouse_TelNo = ""
                                Else
                                    _mSpouse_TelNo = UCase(_tempReader.Item("Spouse_TelNo").ToString)
                                End If

                                If IsDBNull(_tempReader.Item("CivilStatus").ToString) Then
                                    _mCivilStatus = ""
                                Else
                                    _mCivilStatus = UCase(_tempReader.Item("CivilStatus").ToString)
                                End If
                        End Select

                        HasRec = True
                    Else
                        HasRec = False
                    End If
                End Using
                _mSqlCommand.Dispose()
            Catch ex As Exception
            End Try
        Catch ex As Exception
        Finally
            _mSqlCommand.Dispose()
        End Try
    End Sub


    Public Sub _pSubSavePersonalInformation(ByVal _mCommand As String, ByVal _mIDNo As String, ByVal _mSwitch As String) 'Gimay 20200518
        Dim _nStrSql As String = ""
        Try

            Select Case LCase(_mSwitch)
                Case "personal"
                    _nStrSql = " EXEC [sp_temp_PDS_IUD] @Action = '" & _mCommand & "' " &
                               IIf(_mCommand = "INSERT", "", ",@SelectCond=' where IDNO=''" & _mIDNo & "'''") &
                              IIf(_mBirthDate = "", ",@BirthDate=''", ",@BirthDate= N'" & _mBirthDate & "' ") &
                              IIf(_mBirthPlace = "", ",@BirthPlace=''", ",@BirthPlace= N'" & _mBirthPlace & "' ") &
                              IIf(_mBloodType = "", ",@BloodType=''", ",@BloodType= N'" & _mBloodType & "' ") &
                              IIf(_mCitizenship = "", ",@Citizenship=''", ",@Citizenship= N'" & _mCitizenship & "' ") &
                              IIf(_mCivilStatus = "", ",@CivilStatus=''", ",@CivilStatus= N'" & _mCivilStatus & "' ") &
                              IIf(_mDateApplied = "", ",@DateApplied=''", ",@DateApplied= N'" & _mDateApplied & "' ") &
                              IIf(_mEmployeeID = "", ",@EmployeeID=''", ",@EmployeeID= N'" & _mEmployeeID & "' ") &
                              IIf(_mExtName = "", ",@ExtName= ''", ",@ExtName= N'" & _mExtName & "' ") &
                              IIf(_mFirstName = "", ",@FirstName=''", ",@FirstName= N'" & _mFirstName & "' ") &
                              IIf(_mGender = "", ",@Gender=''", ",@Gender= N'" & _mGender & "' ") &
                              IIf(_mGSIS = "", ",@GSIS=''", ",@GSIS= N'" & _mGSIS & "' ") &
                              IIf(_mHeight = "", ",@Height=''", ",@Height= N'" & _mHeight & "' ") &
                              IIf(_mIDNo = "", ",@IDNO=''", ",@IDNO= N'" & _mIDNo & "' ") &
                              IIf(_mLastName = "", ",@LastName=''", ",@LastName= N'" & _mLastName & "' ") &
                              IIf(_mMiddleName = "", ",@MiddleName=''", ",@MiddleName= N'" & _mMiddleName & "' ") &
                              IIf(_mPagIbig = "", "", ",@PagIbig= N'" & _mPagIbig & "' ") &
                              IIf(_mPermanent_Add = "", ",@Permanent_Add=''", ",@Permanent_Add= N'" & _mPermanent_Add & "' ") &
                              IIf(_mPhilHealth = "", ",@PhilHealth=''", ",@PhilHealth= N'" & _mPhilHealth & "' ") &
                              IIf(_mReligion = "", ",@Religion=''", ",@Religion= N'" & _mReligion & "' ") &
                              IIf(_mResidential_Add = "", ",@Residential_Add=''", ",@Residential_Add= N'" & _mResidential_Add & "' ") &
                              IIf(_mTin = "", ",@Tin=''", ",@Tin= N'" & _mTin & "' ") &
                              IIf(_mWeight = "", ",@Weight=''", ",@Weight= N'" & _mWeight & "' ") &
                              IIf(_mSpouse_BusinessAdd = "", ",@Spouse_BusinessAdd=''", ",@Spouse_BusinessAdd= N'" & _mSpouse_BusinessAdd & "' ") &
                              IIf(_mSpouse_BusinessName = "", ",@Spouse_BusinessName=''", ",@Spouse_BusinessName= N'" & _mSpouse_BusinessName & "' ") &
                              IIf(_mSpouse_FName = "", ",@Spouse_FName=''", ",@Spouse_FName= N'" & _mSpouse_FName & "' ") &
                              IIf(_mSpouse_LName = "", ",@Spouse_LName=''", ",@Spouse_LName= N'" & _mSpouse_LName & "' ") &
                              IIf(_mSpouse_MName = "", ",@Spouse_MName=''", ",@Spouse_MName= N'" & _mSpouse_MName & "' ") &
                              IIf(_mSpouse_Occupation = "", ",@Spouse_Occupation=''", ",@Spouse_Occupation= N'" & _mSpouse_Occupation & "' ") &
                              IIf(_mSpouse_TelNo = "", ",@Spouse_TelNo=''", ",@Spouse_TelNo= N'" & _mSpouse_TelNo & "' ") &
                               ",@Successful = @Successful output  " &
                               ",@ErrMsg = @ErrMsg output  "
                Case "family"
                    _nStrSql = " EXEC [sp_temp_PDS_IUD] @Action = '" & _mCommand & "' " &
                               IIf(_mCommand = "INSERT", "", ",@SelectCond=' where IDNO=''" & _mIDNo & "'''") &
                              IIf(_mFather_FName = "", ",@Father_FName=''", ",@Father_FName= N'" & _mFather_FName & "' ") &
                              IIf(_mFather_LName = "", ",@Father_LName=''", ",@Father_LName= N'" & _mFather_LName & "' ") &
                              IIf(_mFather_MName = "", ",@Father_MName=''", ",@Father_MName= N'" & _mFather_MName & "' ") &
                              IIf(_mMother_FName = "", ",@Mother_FName=''", ",@Mother_FName= N'" & _mMother_FName & "' ") &
                              IIf(_mMother_LName = "", ",@Mother_LName=''", ",@Mother_LName= N'" & _mMother_LName & "' ") &
                              IIf(_mMother_MName = "", ",@Mother_MName=''", ",@Mother_MName= N'" & _mMother_MName & "' ") &
                              IIf(_mSpouse_BusinessAdd = "", ",@Spouse_BusinessAdd=''", ",@Spouse_BusinessAdd= N'" & _mSpouse_BusinessAdd & "' ") &
                              IIf(_mSpouse_BusinessName = "", ",@Spouse_BusinessName=''", ",@Spouse_BusinessName= N'" & _mSpouse_BusinessName & "' ") &
                              IIf(_mSpouse_FName = "", ",@Spouse_FName=''", ",@Spouse_FName= N'" & _mSpouse_FName & "' ") &
                              IIf(_mSpouse_LName = "", ",@Spouse_LName=''", ",@Spouse_LName= N'" & _mSpouse_LName & "' ") &
                              IIf(_mSpouse_MName = "", ",@Spouse_MName=''", ",@Spouse_MName= N'" & _mSpouse_MName & "' ") &
                              IIf(_mSpouse_Occupation = "", ",@Spouse_Occupation=''", ",@Spouse_Occupation= N'" & _mSpouse_Occupation & "' ") &
                              IIf(_mSpouse_TelNo = "", ",@Spouse_TelNo=''", ",@Spouse_TelNo= N'" & _mSpouse_TelNo & "' ") &
                               ",@Successful = @Successful output  " &
                               ",@ErrMsg = @ErrMsg output  "
            End Select


            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlConnection)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "SET AND GET CIVILSERVICE PDS"
    Public Shared Property _pCareerService() As String
        Get
            Return _mCareerService
        End Get
        Set(value As String)
            _mCareerService = value
        End Set
    End Property

    Public Shared Property _pCS_NO() As String
        Get
            Return _mCS_NO
        End Get
        Set(value As String)
            _mCS_NO = value
        End Set
    End Property

    Public Shared Property _pDateOfExamination() As String
        Get
            Return _mDateOfExamination
        End Get
        Set(value As String)
            _mDateOfExamination = value
        End Set
    End Property

    Public Shared Property _pFileData() As String
        Get
            Return _mFileData
        End Get
        Set(value As String)
            _mFileData = value
        End Set
    End Property

    Public Shared Property _pFileName() As String
        Get
            Return _mFileName
        End Get
        Set(value As String)
            _mFileName = value
        End Set
    End Property

    Public Shared Property _pFileType() As String
        Get
            Return _mFileType
        End Get
        Set(value As String)
            _mFileType = value
        End Set
    End Property


    Public Shared Property _pLicenseDate() As String
        Get
            Return _mLicenseDate
        End Get
        Set(value As String)
            _mLicenseDate = value
        End Set
    End Property

    Public Shared Property _pLicenseNo() As String
        Get
            Return _mLicenseNo
        End Get
        Set(value As String)
            _mLicenseNo = value
        End Set
    End Property

    Public Shared Property _pPlaceOfExamination() As String
        Get
            Return _mPlaceOfExamination
        End Get
        Set(value As String)
            _mPlaceOfExamination = value
        End Set
    End Property

    Public Shared Property _pRating() As String
        Get
            Return _mRating
        End Get
        Set(value As String)
            _mRating = value
        End Set
    End Property

#End Region 'GIMAY 20200714
#Region "SET AND GET WORK EXPERIENCE PDS" 'Gimay 20200714
    Public Shared Property _pAppointmentStatus() As String
        Get
            Return _mAppointmentStatus
        End Get
        Set(value As String)
            _mAppointmentStatus = value
        End Set
    End Property

    Public Shared Property _pEmployer() As String
        Get
            Return _mEmployer
        End Get
        Set(value As String)
            _mEmployer = value
        End Set
    End Property

    Public Shared Property _pEXP_NO() As String
        Get
            Return _mEXP_NO
        End Get
        Set(value As String)
            _mEXP_NO = value
        End Set
    End Property

    Public Shared Property _pForwarded() As String
        Get
            Return _mForwarded
        End Get
        Set(value As String)
            _mForwarded = value
        End Set
    End Property

    Public Shared Property _pFrom() As String
        Get
            Return _mFrom
        End Get
        Set(value As String)
            _mFrom = value
        End Set
    End Property

    Public Shared Property _pGovService() As String
        Get
            Return _mGovService
        End Get
        Set(value As String)
            _mGovService = value
        End Set
    End Property


    Public Shared Property _pJobPosition() As String
        Get
            Return _mJobPosition
        End Get
        Set(value As String)
            _mJobPosition = value
        End Set
    End Property

    Public Shared Property _pMonthlySalary() As String
        Get
            Return _mMonthlySalary
        End Get
        Set(value As String)
            _mMonthlySalary = value
        End Set
    End Property

    Public Shared Property _pSalaryGrade() As String
        Get
            Return _mSalaryGrade
        End Get
        Set(value As String)
            _mSalaryGrade = value
        End Set
    End Property

    Public Shared Property _pTo() As String
        Get
            Return _mTo
        End Get
        Set(value As String)
            _mTo = value
        End Set
    End Property
#End Region 'Gimay 20200714
#Region "SET AND GET VOLUNTARY"
    Public Shared Property _pdFrom() As String
        Get
            Return _mdFrom
        End Get
        Set(value As String)
            _mdFrom = value
        End Set
    End Property

    Public Shared Property _pdTo() As String
        Get
            Return _mdTo
        End Get
        Set(value As String)
            _mdTo = value
        End Set
    End Property

    Public Shared Property _pNatureofWork() As String
        Get
            Return _mNatureofWork
        End Get
        Set(value As String)
            _mNatureofWork = value
        End Set
    End Property

    Public Shared Property _pNumberofHours() As String
        Get
            Return _mNumberofHours
        End Get
        Set(value As String)
            _mNumberofHours = value
        End Set
    End Property

    Public Shared Property _pOrganizationAddress() As String
        Get
            Return _mOrganizationAddress
        End Get
        Set(value As String)
            _mOrganizationAddress = value
        End Set
    End Property

    Public Shared Property _pOrganizationName() As String
        Get
            Return _mOrganizationName
        End Get
        Set(value As String)
            _mOrganizationName = value
        End Set
    End Property

    Public Shared Property _pPosition() As String
        Get
            Return _mPosition
        End Get
        Set(value As String)
            _mPosition = value
        End Set
    End Property

    Public Shared Property _pSeqNo() As String
        Get
            Return _mSeqNo
        End Get
        Set(value As String)
            _mSeqNo = value
        End Set
    End Property
#End Region 'Gimay 20200714
#Region "SET AND GET TRAINING"
    Public Shared Property _pConductedSponsoredBy() As String
        Get
            Return _mConductedSponsoredBy
        End Get
        Set(value As String)
            _mConductedSponsoredBy = value
        End Set
    End Property

    Public Shared Property _pTitleofSeminarConferenceWorkshopShortCourse() As String
        Get
            Return _mTitleofSeminarConferenceWorkshopShortCourse
        End Get
        Set(value As String)
            _mTitleofSeminarConferenceWorkshopShortCourse = value
        End Set
    End Property

    Public Shared Property _pTypeofLearningDevelopment() As String
        Get
            Return _mTypeofLearningDevelopment
        End Get
        Set(value As String)
            _mTypeofLearningDevelopment = value
        End Set
    End Property
#End Region 'Gimay 20200714
#Region "SET AND GET OTHER INFORMATION"

    Public Shared Property _pMembershipinAssociationOrganization() As String
        Get
            Return _mMembershipinAssociationOrganization
        End Get
        Set(value As String)
            _mMembershipinAssociationOrganization = value
        End Set
    End Property

    Public Shared Property _pNonAcademicDistinctionsRecognition() As String
        Get
            Return _mNonAcademicDistinctionsRecognition
        End Get
        Set(value As String)
            _mNonAcademicDistinctionsRecognition = value
        End Set
    End Property

    Public Shared Property _pSpecialSkillsHobbies() As String
        Get
            Return _mSpecialSkillsHobbies
        End Get
        Set(value As String)
            _mSpecialSkillsHobbies = value
        End Set
    End Property

#End Region 'Gimay 20200714
#Region "SET AND GET  EDUCATION"
    Public Shared Property _pDATEFROM() As String
        Get
            Return _mDATEFROM
        End Get
        Set(value As String)
            _mDATEFROM = value
        End Set
    End Property

    Public Shared Property _pDATETO() As String
        Get
            Return _mDATETO
        End Get
        Set(value As String)
            _mDATETO = value
        End Set
    End Property

    Public Shared Property _pDEGREECOURSEDETAIL() As String
        Get
            Return _mDEGREECOURSEDETAIL
        End Get
        Set(value As String)
            _mDEGREECOURSEDETAIL = value
        End Set
    End Property

    Public Shared Property _pEDUCATIONLEVEL() As String
        Get
            Return _mEDUCATIONLEVEL
        End Get
        Set(value As String)
            _mEDUCATIONLEVEL = value
        End Set
    End Property

    Public Shared Property _pEL_NO() As String
        Get
            Return _mEL_NO
        End Get
        Set(value As String)
            _mEL_NO = value
        End Set
    End Property

    Public Shared Property _pHIGHESTGRADELEVELUNITSEARNED() As String
        Get
            Return _mHIGHESTGRADELEVELUNITSEARNED
        End Get
        Set(value As String)
            _mHIGHESTGRADELEVELUNITSEARNED = value
        End Set
    End Property

    Public Shared Property _pIDNo() As String
        Get
            Return _mIDNO
        End Get
        Set(value As String)
            _mIDNO = value
        End Set
    End Property

    Public Shared Property _pINSTITUTIONNAME() As String
        Get
            Return _mINSTITUTIONNAME
        End Get
        Set(value As String)
            _mINSTITUTIONNAME = value
        End Set
    End Property

    Public Shared Property _pSCHOLARSHIPACADEMICHONORSDETAIL() As String
        Get
            Return _mSCHOLARSHIPACADEMICHONORSDETAIL
        End Get
        Set(value As String)
            _mSCHOLARSHIPACADEMICHONORSDETAIL = value
        End Set
    End Property

    Public Shared Property _pYEARGRADUATED() As String
        Get
            Return _mYEARGRADUATED
        End Get
        Set(value As String)
            _mYEARGRADUATED = value
        End Set
    End Property
#End Region 'Gimay 20200714
#Region "SET  AND GET REFERENCE" 'Gimay 202007
    Public Shared Property _pAddress() As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
        End Set
    End Property

    Public Shared Property _pFullName() As String
        Get
            Return _mFullName
        End Get
        Set(value As String)
            _mFullName = value
        End Set
    End Property

    Public Shared Property _pFirstName() As String
        Get
            Return _mFirstName
        End Get
        Set(value As String)
            _mFirstName = value
        End Set
    End Property


    Public Shared Property _pTelNo() As String
        Get
            Return _mTelNo
        End Get
        Set(value As String)
            _mTelNo = value
        End Set
    End Property
#End Region 'Gimay 20200715
    '#Region "SET AND GET CHILDREN"
    '    Public Shared Property _pBirthDate() As String
    '        Get
    '            Return _mBirthDate
    '        End Get
    '        Set(value As String)
    '            _mBirthDate = value
    '        End Set
    '    End Property

    '    Public Shared Property _pFirstName() As String
    '        Get
    '            Return _mFirstName
    '        End Get
    '        Set(value As String)
    '            _mFirstName = value
    '        End Set
    '    End Property

    '    Public Shared Property _pFullName() As String
    '        Get
    '            Return _mFullName
    '        End Get
    '        Set(value As String)
    '            _mFullName = value
    '        End Set
    '    End Property

    '    Public Shared Property _pIDNO() As String
    '        Get
    '            Return _mIDNO
    '        End Get
    '        Set(value As String)
    '            _mIDNO = value
    '        End Set
    '    End Property

    '    Public Shared Property _pLastName() As String
    '        Get
    '            Return _mLastName
    '        End Get
    '        Set(value As String)
    '            _mLastName = value
    '        End Set
    '    End Property

    '    Public Shared Property _pMiddleName() As String
    '        Get
    '            Return _mMiddleName
    '        End Get
    '        Set(value As String)
    '            _mMiddleName = value
    '        End Set
    '    End Property
    '#End Region

#Region "GIMAY PICKUP FROM LOCAL"
    Public Sub GetCivilService(ByVal EmpNo As String)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select " &
                      " Exam as CareerService,  " &
                      " ERating As Rating,   " &
                      " EDate as DateOfExamination,  " &
                      " EPLace as PlaceOfExamination,  " &
                      " LicNumber as LicenseNo,  " &
                      " LicDate as LicenseDate,  " &
                      " format(ROW_NUMBER() over (partition by Emp_No order by EDate),'0000') as CS_NO " &
                      " From OI_Eligibility" &
                      "  Where Emp_No ='" & EmpNo & "'"



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                'If _nSqlDr.HasRows Then
                ' Getting Record using reader
                Do While _nSqlDr.Read
                    If IsDBNull(_nSqlDr.Item("CareerService").ToString) Then
                        _mCareerService = ""
                    Else
                        _mCareerService = UCase(_nSqlDr.Item("CareerService").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DateOfExamination").ToString) Then
                        _mDateOfExamination = ""
                    Else
                        _mDateOfExamination = UCase(_nSqlDr.Item("DateOfExamination").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("CS_NO").ToString) Then
                        _mCS_NO = ""
                    Else
                        _mCS_NO = UCase(_nSqlDr.Item("CS_NO").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LicenseDate").ToString) Then
                        _mLicenseDate = ""
                    Else
                        _mLicenseDate = UCase(_nSqlDr.Item("LicenseDate").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LicenseNo").ToString) Then
                        _mLicenseNo = ""
                    Else
                        _mLicenseNo = UCase(_nSqlDr.Item("LicenseNo").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("PlaceOfExamination").ToString) Then
                        _mPlaceOfExamination = ""
                    Else
                        _mPlaceOfExamination = UCase(_nSqlDr.Item("PlaceOfExamination").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Rating").ToString) Then
                        _mRating = ""
                    Else
                        _mRating = UCase(_nSqlDr.Item("Rating").ToString)
                    End If

                    _pSaveCivilService()
                Loop
                'Else
                '    cDalHRIMS._mCareerService = ""
                '    cDalHRIMS._mRating = ""
                '    cDalHRIMS._mDateOfExamination = ""
                '    cDalHRIMS._mPlaceOfExamination = ""
                '    cDalHRIMS._mLicenseNo = ""
                '    cDalHRIMS._mLicenseDate = ""
                'End If
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714


    Public Sub GetWorExperience(ByVal EmpNo As String)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select " &
                      " WRKFRM as [From], " &
                      " WRKTO AS [To], " &
                      " WRKPOS as JobPosition, " &
                      " WRKDEPARTMENT as Employer, " &
                      " WRKSAL as MonthlySalary, " &
                      " SG as SalaryGrade, " &
                      " WRKSTATUS AS AppointmentStatus, " &
                      " GovService, " &
                      " format(ROW_NUMBER() over (partition by Emp_No order by WRKFRM),'0000') as EXP_NO " &
                      " from OI_WRKExperience " &
                      "  Where Emp_No ='" & EmpNo & "'"



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                'If _nSqlDr.HasRows Then
                ' Getting Record using reader
                Do While _nSqlDr.Read
                    If IsDBNull(_nSqlDr.Item("AppointmentStatus").ToString) Then
                        _mAppointmentStatus = ""
                    Else
                        _mAppointmentStatus = UCase(_nSqlDr.Item("AppointmentStatus").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Employer").ToString) Then
                        _mEmployer = ""
                    Else
                        _mEmployer = UCase(_nSqlDr.Item("Employer").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("EXP_NO").ToString) Then
                        _mEXP_NO = ""
                    Else
                        _mEXP_NO = UCase(_nSqlDr.Item("EXP_NO").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("From").ToString) Then
                        _mFrom = ""
                    Else
                        _mFrom = UCase(_nSqlDr.Item("From").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("GovService").ToString) Then
                        _mGovService = ""
                    Else
                        _mGovService = UCase(_nSqlDr.Item("GovService").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("JobPosition").ToString) Then
                        _mJobPosition = ""
                    Else
                        _mJobPosition = UCase(_nSqlDr.Item("JobPosition").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("MonthlySalary").ToString) Then
                        _mMonthlySalary = ""
                    Else
                        _mMonthlySalary = UCase(_nSqlDr.Item("MonthlySalary").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("SalaryGrade").ToString) Then
                        _mSalaryGrade = ""
                    Else
                        _mSalaryGrade = UCase(_nSqlDr.Item("SalaryGrade").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("To").ToString) Then
                        _mTo = ""
                    Else
                        _mTo = UCase(_nSqlDr.Item("To").ToString)
                    End If

                    _pSaveWorExperience()
                Loop
                'End If
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub GetVoluntary(ByVal EmpNo As String) 'Gimay 20200714
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " SELECT " &
                      " Volfrom as dFrom, " &
                      " Volto as dTo, " &
                      " Volorg as OrganizationName, " &
                      " VolPos as Position, " &
                      " Volhrs as NumberofHours " &
                      " FROM OI_Volunteer" &
                      "  Where Emp_No ='" & EmpNo & "'"



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                Do While _nSqlDr.Read
                    If IsDBNull(_nSqlDr.Item("dFrom").ToString) Then
                        _mdFrom = ""
                    Else
                        _mdFrom = UCase(_nSqlDr.Item("dFrom").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("dTo").ToString) Then
                        _mdTo = ""
                    Else
                        _mdTo = UCase(_nSqlDr.Item("dTo").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("NumberofHours").ToString) Then
                        _mNumberofHours = ""
                    Else
                        _mNumberofHours = UCase(_nSqlDr.Item("NumberofHours").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("OrganizationName").ToString) Then
                        _mOrganizationName = ""
                    Else
                        _mOrganizationName = UCase(_nSqlDr.Item("OrganizationName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("Position").ToString) Then
                        _mPosition = ""
                    Else
                        _mPosition = UCase(_nSqlDr.Item("Position").ToString)
                    End If

                    _pSaveVoluntary()
                Loop
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub GetTraining(ByVal EmpNo As String) 'Gimay 20200714
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select " &
                      " TPeriod as dFrom, " &
                      " TPeriodTo as dTo, " &
                      " TDesc as TitleofSeminarConferenceWorkshopShortCourse, " &
                      " THours as NumberofHours, " &
                      " TConducted as ConductedSponsoredBy, " &
                      " 'TR - ' + format(ROW_NUMBER() over (partition by Emp_no order by TPeriod),'000') as EXP_NO " &
                      " from OI_Training " &
                      "  Where Emp_No ='" & EmpNo & "'"



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                Do While _nSqlDr.Read
                    If IsDBNull(_nSqlDr.Item("ConductedSponsoredBy").ToString) Then
                        _mConductedSponsoredBy = ""
                    Else
                        _mConductedSponsoredBy = UCase(_nSqlDr.Item("ConductedSponsoredBy").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("dFrom").ToString) Then
                        _mdFrom = ""
                    Else
                        _mdFrom = UCase(_nSqlDr.Item("dFrom").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("dTo").ToString) Then
                        _mdTo = ""
                    Else
                        _mdTo = UCase(_nSqlDr.Item("dTo").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("NumberofHours").ToString) Then
                        _mNumberofHours = ""
                    Else
                        _mNumberofHours = UCase(_nSqlDr.Item("NumberofHours").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TitleofSeminarConferenceWorkshopShortCourse").ToString) Then
                        _mTitleofSeminarConferenceWorkshopShortCourse = ""
                    Else
                        _mTitleofSeminarConferenceWorkshopShortCourse = UCase(_nSqlDr.Item("TitleofSeminarConferenceWorkshopShortCourse").ToString)
                    End If

                    _pSaveTraining()
                Loop
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714


    Public Sub GetOtherInformation(ByVal EmpNo As String) 'Gimay 20200714
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select " &
                      " Skils_Desc As SpecialSkillsHobbies,  " &
                      " NONACRecog as NonAcademicDistinctionsRecognition, " &
                      " OrgMembr as MembershipinAssociationOrganization, " &
                      " 'OI - ' + format(ROW_NUMBER() over (partition by Emp_no order by Skils_Desc),'000') as SeqNo " &
                      " From oi_skills" &
                      " Where Emp_No ='" & EmpNo & "'"



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                Do While _nSqlDr.Read

                    If IsDBNull(_nSqlDr.Item("MembershipinAssociationOrganization").ToString) Then
                        _mMembershipinAssociationOrganization = ""
                    Else
                        _mMembershipinAssociationOrganization = UCase(_nSqlDr.Item("MembershipinAssociationOrganization").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("NonAcademicDistinctionsRecognition").ToString) Then
                        _mNonAcademicDistinctionsRecognition = ""
                    Else
                        _mNonAcademicDistinctionsRecognition = UCase(_nSqlDr.Item("NonAcademicDistinctionsRecognition").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("SeqNo").ToString) Then
                        _mSeqNo = ""
                    Else
                        _mSeqNo = UCase(_nSqlDr.Item("SeqNo").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("SpecialSkillsHobbies").ToString) Then
                        _mSpecialSkillsHobbies = ""
                    Else
                        _mSpecialSkillsHobbies = UCase(_nSqlDr.Item("SpecialSkillsHobbies").ToString)
                    End If

                    _pSaveOtherInformation()
                Loop
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub GetEducationalInformation(ByVal EmpNo As String) 'Gimay 202007146
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select EDUCATIONLEVEL, ESchool as INSTITUTIONNAME, " &
                      "  Year(cast(substring(Inclusive_date ,1,4) as date)) as DATEFROM, " &
                      "  Year(cast(RIGHT(Inclusive_date ,4) as date)) as DATETO, " &
                      "  Honors,Deg_Earned, " &
                      "  Ecourse as DEGREECOURSEDETAIL, " &
                      "  YearGrad AS YEARGRADUATED,  " &
                      " Emp_No, " &
                      " format(ROW_NUMBER() over (partition by emp_no order by YearGrad),'0000') as EL_NO " &
                      "              from " &
                      "  (SELECT 'Elementary' as EDUCATIONLEVEL ,Emp_No, ESchool, Inclusive_date, Honors, Deg_Earned, Ecourse, YearGrad FROM OI_EducPrimary   " &
                      "   union " &
                      "  select 'Secondary' as EDUCATIONLEVEL, Emp_No, ESchool, Inclusive_date, Honors, Deg_Earned, Ecourse, YearGrad from OI_EducSecondary " &
                      "  union " &
                      "  select 'College' as EDUCATIONLEVEL, Emp_No, ESchool, Inclusive_date,  Honors,Deg_Earned, ECourse,  YearGrad from OI_EducThertiary " &
                      "  union " &
                      "  select 'Others' as EDUCATIONLEVEL, Emp_No, ESchool, Inclusive_date,  Honors,Deg_Earned, ECourse,  YearGrad from oi_masters" &
                      "  union " &
                      "  Select 'Others' as EDUCATIONLEVEL, Emp_No, ESchool, Inclusive_date,  Honors,Deg_Earned, ECourse,  YearGrad from oi_doctorate " &
                      " ) as xtable  " &
                      " " &
                      " Where Emp_No ='" & EmpNo & "' order by  Year(cast(substring(Inclusive_date ,1,4) as date)) "



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                Do While _nSqlDr.Read

                    If IsDBNull(_nSqlDr.Item("DATEFROM").ToString) Then
                        _mDATEFROM = ""
                    Else
                        _mDATEFROM = UCase(_nSqlDr.Item("DATEFROM").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DATETO").ToString) Then
                        _mDATETO = ""
                    Else
                        _mDATETO = UCase(_nSqlDr.Item("DATETO").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("DEGREECOURSEDETAIL").ToString) Then
                        _mDEGREECOURSEDETAIL = ""
                    Else
                        _mDEGREECOURSEDETAIL = UCase(_nSqlDr.Item("DEGREECOURSEDETAIL").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("EDUCATIONLEVEL").ToString) Then
                        _mEDUCATIONLEVEL = ""
                    Else
                        _mEDUCATIONLEVEL = UCase(_nSqlDr.Item("EDUCATIONLEVEL").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("EL_NO").ToString) Then
                        _mEL_NO = ""
                    Else
                        _mEL_NO = UCase(_nSqlDr.Item("EL_NO").ToString)
                    End If

                    'If IsDBNull(_nSqlDr.Item("HIGHESTGRADELEVELUNITSEARNED").ToString) Then
                    '    _mHIGHESTGRADELEVELUNITSEARNED = ""
                    'Else
                    '    _mHIGHESTGRADELEVELUNITSEARNED = UCase(_nSqlDr.Item("HIGHESTGRADELEVELUNITSEARNED").ToString)
                    'End If

                    'If IsDBNull(_nSqlDr.Item("IDNo").ToString) Then
                    '    _mIDNO = ""
                    'Else
                    '    _mIDNO = UCase(_nSqlDr.Item("IDNo").ToString)
                    'End If

                    If IsDBNull(_nSqlDr.Item("INSTITUTIONNAME").ToString) Then
                        _mINSTITUTIONNAME = ""
                    Else
                        _mINSTITUTIONNAME = UCase(_nSqlDr.Item("INSTITUTIONNAME").ToString)
                    End If

                    'If IsDBNull(_nSqlDr.Item("SCHOLARSHIPACADEMICHONORSDETAIL").ToString) Then
                    '    _mSCHOLARSHIPACADEMICHONORSDETAIL = ""
                    'Else
                    '    _mSCHOLARSHIPACADEMICHONORSDETAIL = UCase(_nSqlDr.Item("SCHOLARSHIPACADEMICHONORSDETAIL").ToString)
                    'End If

                    If IsDBNull(_nSqlDr.Item("YEARGRADUATED").ToString) Then
                        _mYEARGRADUATED = ""
                    Else
                        _mYEARGRADUATED = UCase(_nSqlDr.Item("YEARGRADUATED").ToString)
                    End If


                    _pSaveEducational()
                Loop
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub GetReferenece(ByVal EmpNo As String) 'Gimay 20200715
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select RName as FullName, " &
                      " First_Name as FirstName, " &
                      " Middle_Name as MiddleName, " &
                      " Last_Name as LastName, " &
                      " RTelNo as [TelNo],  " &
                      " RAddress as [Address],  " &
                      " 'Ref - ' + format(ROW_NUMBER() over (partition by emp_no order by RName),'000') as SeqNo  " &
                      " from OI_Reference  " &
                      " " &
                      " Where Emp_No ='" & EmpNo & "' "



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                Do While _nSqlDr.Read

                    If IsDBNull(_nSqlDr.Item("Address").ToString) Then
                        _mAddress = ""
                    Else
                        _mAddress = UCase(_nSqlDr.Item("Address").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("FullName").ToString) Then
                        _mFullName = ""
                    Else
                        _mFullName = UCase(_nSqlDr.Item("FullName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("FirstName").ToString) Then
                        _mFirstName = ""
                    Else
                        _mFirstName = UCase(_nSqlDr.Item("FirstName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LastName").ToString) Then
                        _mLastName = ""
                    Else
                        _mLastName = UCase(_nSqlDr.Item("LastName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("MiddleName").ToString) Then
                        _mMiddleName = ""
                    Else
                        _mMiddleName = UCase(_nSqlDr.Item("MiddleName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("SeqNo").ToString) Then
                        _mSeqNo = ""
                    Else
                        _mSeqNo = UCase(_nSqlDr.Item("SeqNo").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("TelNo").ToString) Then
                        _mTelNo = ""
                    Else
                        _mTelNo = UCase(_nSqlDr.Item("TelNo").ToString)
                    End If

                    _pSaveReference()
                Loop
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714
    Public Sub GetChildren(ByVal EmpNo As String) 'Gimay 20200715
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " select  " &
                      " First_Name as FirstName, " &
                      " Middle_Name as MiddleName," &
                      " Last_Name as LastName," &
                      " Children as Fullname, " &
                      " CBDay as BirthDate " &
                      " from OI_Children  " &
                      " " &
                      " Where Emp_No ='" & EmpNo & "' "



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_PMIPS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_PMIPS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                Do While _nSqlDr.Read

                    If IsDBNull(_nSqlDr.Item("BirthDate").ToString) Then
                        _mBirthDate = ""
                    Else
                        _mBirthDate = UCase(_nSqlDr.Item("BirthDate").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("FirstName").ToString) Then
                        _mFirstName = ""
                    Else
                        _mFirstName = UCase(_nSqlDr.Item("FirstName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("FullName").ToString) Then
                        _mFullName = ""
                    Else
                        _mFullName = UCase(_nSqlDr.Item("FullName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("LastName").ToString) Then
                        _mLastName = ""
                    Else
                        _mLastName = UCase(_nSqlDr.Item("LastName").ToString)
                    End If

                    If IsDBNull(_nSqlDr.Item("MiddleName").ToString) Then
                        _mMiddleName = ""
                    Else
                        _mMiddleName = UCase(_nSqlDr.Item("MiddleName").ToString)
                    End If


                    _pSaveChildren()
                Loop
            End Using

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714



    Public Sub _pSaveCivilService()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_CivilService_IUD] @Action = 'INSERT' " &
                                ",@CareerService= N'" & _mCareerService & "' " &
                                ",@CS_NO= N'" & _mCS_NO & "' " &
                                ",@DateOfExamination= N'" & _mDateOfExamination & "' " &
                                ",@IDNo= N'" & _mIDNO & "' " &
                                ",@LicenseDate= N'" & _mLicenseDate & "' " &
                                ",@LicenseNo= N'" & _mLicenseNo & "' " &
                                ",@PlaceOfExamination= N'" & _mPlaceOfExamination & "' " &
                                ",@Rating= N'" & _mRating & "' " &
                                ",@Successful = @Successful output  " &
                                ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveWorExperience()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_WorkExperience_IUD] @Action = 'INSERT' " &
                             ",@AppointmentStatus= N'" & _mAppointmentStatus & "' " &
                              ",@Employer= N'" & _mEmployer & "' " &
                              ",@EXP_NO= N'" & _mEXP_NO & "' " &
                              ",@Forwarded= N'" & _mForwarded & "' " &
                              ",@From= N'" & _mFrom & "' " &
                              ",@GovService= N'" & _mGovService & "' " &
                              ",@IDNo= N'" & _mIDNO & "' " &
                              ",@JobPosition= N'" & _mJobPosition & "' " &
                              ",@MonthlySalary= N'" & _mMonthlySalary & "' " &
                              ",@SalaryGrade= N'" & _mSalaryGrade & "' " &
                               ",@To= N'" & _mTo & "' " &
                                ",@Successful = @Successful output  " &
                                ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveVoluntary()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_VoluntaryWorkorInvolvement_IUD] @Action = 'INSERT' " &
                               ",@dFrom= N'" & _mdFrom & "' " &
                                ",@dTo= N'" & _mdTo & "' " &
                                ",@IDNO= N'" & _mIDNO & "' " &
                                ",@NatureofWork= N'" & _mNatureofWork & "' " &
                                ",@NumberofHours= N'" & _mNumberofHours & "' " &
                                ",@OrganizationAddress= N'" & _mOrganizationAddress & "' " &
                                ",@OrganizationName= N'" & _mOrganizationName & "' " &
                                ",@Position= N'" & _mPosition & "' " &
                                ",@SeqNo= N'" & _mSeqNo & "' " &
                                ",@Successful = @Successful output  " &
                                ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveTraining()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_TrainingPrograms_IUD] @Action = 'INSERT' " &
                              ",@ConductedSponsoredBy= N'" & _mConductedSponsoredBy & "' " &
                                ",@dFrom= N'" & _mdFrom & "' " &
                                ",@dTo= N'" & _mdTo & "' " &
                                ",@IDNO= N'" & _mIDNO & "' " &
                                ",@NumberofHours= N'" & _mNumberofHours & "' " &
                                ",@SeqNo= N'" & _mSeqNo & "' " &
                                ",@TitleofSeminarConferenceWorkshopShortCourse= N'" & _mTitleofSeminarConferenceWorkshopShortCourse & "' " &
                                ",@TypeofLearningDevelopment= N'" & _mTypeofLearningDevelopment & "' " &
                                ",@Successful = @Successful output  " &
                                ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveOtherInformation()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_OtherInformation_IUD] @Action = 'INSERT' " &
                               ",@IDNO= N'" & _mIDNO & "' " &
                                ",@MembershipinAssociationOrganization= N'" & _mMembershipinAssociationOrganization & "' " &
                                ",@NonAcademicDistinctionsRecognition= N'" & _mNonAcademicDistinctionsRecognition & "' " &
                                ",@SeqNo= N'" & _mSeqNo & "' " &
                                ",@SpecialSkillsHobbies= N'" & _mSpecialSkillsHobbies & "' " &
                                ",@Successful = @Successful output  " &
                                ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveEducational()
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_Education_IUD] @Action = 'INSERT' " &
                             ",@IDNO= N'" & _mIDNO & "' " &
                             ",@DATEFROM= N'" & _mDATEFROM & "' " & _
                              ",@DATETO= N'" & _mDATETO & "' " & _
                              ",@DEGREECOURSEDETAIL= N'" & _mDEGREECOURSEDETAIL & "' " & _
                              ",@EDUCATIONLEVEL= N'" & _mEDUCATIONLEVEL & "' " & _
                              ",@EL_NO= N'" & _mEL_NO & "' " & _
                              ",@HIGHESTGRADELEVELUNITSEARNED= N'" & _mHIGHESTGRADELEVELUNITSEARNED & "' " & _
                              ",@INSTITUTIONNAME= N'" & _mINSTITUTIONNAME & "' " & _
                              ",@SCHOLARSHIPACADEMICHONORSDETAIL= N'" & _mSCHOLARSHIPACADEMICHONORSDETAIL & "' " & _
                              ",@YEARGRADUATED= N'" & _mYEARGRADUATED & "' " & _
                              ",@Successful = @Successful output  " &
                              ",@ErrMsg = @ErrMsg output  "



            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveReference() 'Gimay 20200715
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_PDS_References_IUD] @Action = 'INSERT' " &
                             ",@IDNO= N'" & _mIDNO & "' " &
                              IIf(_mAddress = "", "", ",@Address= N'" & _mAddress & "' ") & _
                              IIf(_mFirstName = "", "", ",@FirstName= N'" & _mFirstName & "' ") & _
                              IIf(_mFullName = "", "", ",@FullName= N'" & _mFullName & "' ") & _
                              IIf(_mLastName = "", "", ",@LastName= N'" & _mLastName & "' ") & _
                              IIf(_mMiddleName = "", "", ",@MiddleName= N'" & _mMiddleName & "' ") & _
                              IIf(_mSeqNo = "", "", ",@SeqNo= N'" & _mSeqNo & "' ") & _
                              IIf(_mTelNo = "", "", ",@TelNo= N'" & _mTelNo & "' ") & _
                              ",@Successful = @Successful output  " &
                              ",@ErrMsg = @ErrMsg output  "



            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

    Public Sub _pSaveChildren() 'Gimay 20200715
        Dim _nStrSql As String = ""
        Try

            'Gimay 20200626 added date applied
            _nStrSql = " EXEC [sp_temp_PDS_sub_IUD] @Action = 'INSERT' " &
                             ",@IDNO= N'" & _mIDNO & "' " &
                             IIf(_mBirthDate = "", "", ",@BirthDate= N'" & _mBirthDate & "' ") & _
                             IIf(_mFirstName = "", "", ",@FirstName= N'" & _mFirstName & "' ") & _
                             IIf(_mFullName = "", "", ",@FullName= N'" & _mFullName & "' ") & _
                             IIf(_mLastName = "", "", ",@LastName= N'" & _mLastName & "' ") & _
                             IIf(_mMiddleName = "", "", ",@MiddleName= N'" & _mMiddleName & "' ") & _
                              ",@Successful = @Successful output  " &
                              ",@ErrMsg = @ErrMsg output  "



            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub 'Gimay 20200714

#End Region
    Public Sub _pSubSelectVacantPosition()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select i.ItemNo,p.PosDesc,(Select DeptDesc from Department where DeptCode = i.DeptCode) " & _
                      "as DeptDesc,p.SGRate,s.sgamount from itemcode i inner join PosTable p on i.PosCode = p.PosCode " & _
                      "inner join SalGradeTable s on p.SGRate = s.SGCode where isnull(Vaccant_Sw,0) = 0"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_nOwner = _nSqlDr.Item("OWNER").ToString
                        _mFirstName = _nSqlDr.Item("OWNER").ToString
                        _mLastName = _nSqlDr.Item("OWNER").ToString
                        _mBirthDate = Convert.ToDateTime(_nSqlDr.Item("BDay").ToString)
                        _mGender = _nSqlDr.Item("Sex").ToString

                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectEmpEmailAll()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "SELECT PAYROLL_DATA.emp_no,First_name,Mid_name,Last_name,EmailAdd, Department.DeptDesc as 'Department' FROM PAYROLL_DATA  " &
                      "INNER JOIN Personal_Data ON PAYROLL_DATA.emp_no = Personal_Data.emp_no                                    " &
                      "left OUTER join Department ON  Department.deptcode = PAYROLL_DATA.Department                              " &
                      "where ISNULL(REC_STATUS,0) = 1 And isnull(emp_gone,0) = 0 And isnull(emp_not_exist,0) = 0                 " &
                      "And Personal_Data.EmailAdd IS NOT NULL                                                                    " &
                      "And Personal_Data.EmailAdd <>  ''                                                                         " &
                      "And Personal_Data.EmailAdd <> 'N/A'                                                                       "



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    ' Getting Record using reader
                    Do While _nSqlDr.Read
                        cDalHRIMS._mFirstName = _nSqlDr.Item("First_Name").ToString
                        cDalHRIMS._mMiddleName = _nSqlDr.Item("Mid_Name").ToString
                        cDalHRIMS._mLastName = _nSqlDr.Item("Last_Name").ToString
                        cDalHRIMS._mResidential_Add = _nSqlDr.Item("Address").ToString
                        cDalHRIMS._mPermanent_Add = _nSqlDr.Item("PermanentAdd").ToString
                        cDalHRIMS._mCivilStatus = _nSqlDr.Item("CStatus").ToString
                        'cDalHRIMS._mCitizenship = _nSqlDr.Item("Citizen").ToString
                        cDalHRIMS._mCitizenship = _nSqlDr.Item("Citizenship").ToString
                        cDalHRIMS._mGender = IIf(_nSqlDr.Item("Sex").ToString = "Male", "M", "F")
                        cDalHRIMS._mWeight = _nSqlDr.Item("Weight").ToString
                        cDalHRIMS._mHeight = _nSqlDr.Item("Height").ToString
                        cDalHRIMS._mBirthDate = _nSqlDr.Item("BDay").ToString
                        cDalHRIMS._mBirthPlace = _nSqlDr.Item("BPlace").ToString
                        cDalHRIMS._mReligion = _nSqlDr.Item("RDescription").ToString
                        'cDalHRIMS._mReligion = _nSqlDr.Item("Religion").ToString
                        cDalHRIMS._mBloodType = _nSqlDr.Item("BloodType").ToString
                        cDalHRIMS._mDateApplied = _nSqlDr.Item("Date_Hired").ToString
                        cDalHRIMS._mEmployeeID = _nSqlDr.Item("emp_no").ToString

                        'cDalHRIMS._mExtName = _nSqlDr.Item("DateApplied").ToString
                        'cDalHRIMS._mGSIS = _nSqlDr.Item("DateApplied").ToString
                        'cDalHRIMS._mIDNO = _nSqlDr.Item("DateApplied").ToString
                        'cDalHRIMS._mPagIbig = _nSqlDr.Item("DateApplied").ToString
                        'cDalHRIMS._mPhilHealth = _nSqlDr.Item("DateApplied").ToString
                        'cDalHRIMS._mPictureFile = _nSqlDr.Item("DateApplied").ToString
                        'cDalHRIMS._mTin = _nSqlDr.Item("DateApplied").ToString

                        'Spouse---------
                        cDalHRIMS._mSpouse_FName = _nSqlDr.Item("Spouse").ToString
                        cDalHRIMS._mSpouse_MName = _nSqlDr.Item("Spouse_MidN").ToString
                        cDalHRIMS._mSpouse_LName = _nSqlDr.Item("Spouse_LastN").ToString
                        cDalHRIMS._mSpouse_Occupation = _nSqlDr.Item("SpsOccu").ToString
                        cDalHRIMS._mSpouse_BusinessAdd = _nSqlDr.Item("SpsBusAdd").ToString
                        cDalHRIMS._mSpouse_BusinessName = _nSqlDr.Item("SpsBusName").ToString
                        cDalHRIMS._mSpouse_TelNo = _nSqlDr.Item("SpsTelno").ToString
                        'Father---------
                        cDalHRIMS._mFather_FName = _nSqlDr.Item("Father").ToString
                        cDalHRIMS._mFather_MName = _nSqlDr.Item("Father_MidN").ToString
                        cDalHRIMS._mFather_LName = _nSqlDr.Item("Father_LastN").ToString
                        'Mother---------
                        cDalHRIMS._mMother_FName = _nSqlDr.Item("Mother").ToString
                        cDalHRIMS._mMother_MName = _nSqlDr.Item("Mother_MidN").ToString
                        cDalHRIMS._mMother_LName = _nSqlDr.Item("Mother_LastN").ToString
                    Loop

                Else

                    'no record found
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectEmpEmail(ByVal EmailAddr As String, ByRef RecFound As Boolean)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            ' _nQuery = "SELECT * from Personal_Data INNER JOIN Sysctrl ON Personal_Data.emp_no = Sysctrl.emp_no Where Personal_Data.EmailAdd='" & EmailAddr & "'"
            '_nQuery = "SELECT sc.[Description] as Citizenship,Personal_Data.*,* FROM PAYROLL_DATA " &
            '          " INNER JOIN Personal_Data ON PAYROLL_DATA.emp_no = Personal_Data.emp_no " &
            '          " LEFT OUTER JOIN Religion ON Religion.RCode = Personal_Data.Religion " &
            '          " LEFT OUTER JOIN SetupCitizenship sc on sc.Code = Personal_Data.Citizen " &
            '          " where ISNULL(REC_STATUS,0) = 1 And isnull(emp_gone,0) = 0 And isnull(emp_not_exist,0) = 0 And Personal_Data.EmailAdd='" & EmailAddr & "'"

            'Gimay 20200715 added picturefile
            _nQuery = "SELECT sc.[Description] as Citizenship,Personal_Data.*,* FROM PAYROLL_DATA " &
                      " INNER JOIN Personal_Data ON PAYROLL_DATA.emp_no = Personal_Data.emp_no " &
                      " LEFT OUTER JOIN Religion ON Religion.RCode = Personal_Data.Religion " &
                      " LEFT OUTER JOIN SetupCitizenship sc on sc.Code = Personal_Data.Citizen " &
                      "  LEFT OUTER JOIN payroll_picture PP ON PP.Emp_No = Personal_Data.emp_no " &
                      " where ISNULL(REC_STATUS,0) = 1 And isnull(emp_gone,0) = 0 And isnull(emp_not_exist,0) = 0 And Personal_Data.EmailAdd='" & EmailAddr & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    ' Getting Record using reader
                    Do While _nSqlDr.Read
                        cDalHRIMS._mFirstName = _nSqlDr.Item("First_Name").ToString
                        cDalHRIMS._mMiddleName = _nSqlDr.Item("Mid_Name").ToString
                        cDalHRIMS._mLastName = _nSqlDr.Item("Last_Name").ToString
                        cDalHRIMS._mResidential_Add = _nSqlDr.Item("Address").ToString
                        cDalHRIMS._mPermanent_Add = _nSqlDr.Item("PermanentAdd").ToString
                        cDalHRIMS._mCivilStatus = _nSqlDr.Item("CStatus").ToString
                        'cDalHRIMS._mCitizenship = _nSqlDr.Item("Citizen").ToString
                        cDalHRIMS._mCitizenship = _nSqlDr.Item("Citizenship").ToString
                        cDalHRIMS._mGender = IIf(_nSqlDr.Item("Sex").ToString = "Male", "M", "F")
                        cDalHRIMS._mWeight = _nSqlDr.Item("Weight").ToString
                        cDalHRIMS._mHeight = _nSqlDr.Item("Height").ToString
                        cDalHRIMS._mBirthDate = _nSqlDr.Item("BDay").ToString
                        cDalHRIMS._mBirthPlace = _nSqlDr.Item("BPlace").ToString
                        cDalHRIMS._mReligion = _nSqlDr.Item("RDescription").ToString
                        'cDalHRIMS._mReligion = _nSqlDr.Item("Religion").ToString
                        cDalHRIMS._mBloodType = _nSqlDr.Item("BloodType").ToString
                        cDalHRIMS._mDateApplied = _nSqlDr.Item("Date_Hired").ToString
                        cDalHRIMS._mEmployeeID = _nSqlDr.Item("emp_no").ToString

                        cDalHRIMS._mGSIS = _nSqlDr.Item("Gsis_No").ToString 'Gimay 20200715
                        cDalHRIMS._mPagIbig = _nSqlDr.Item("Pagibig_No").ToString 'Gimay 20200715
                        cDalHRIMS._mPhilHealth = _nSqlDr.Item("Medicare_No").ToString 'Gimay 20200715
                        cDalHRIMS._mSSSno = _nSqlDr.Item("SSSno").ToString 'Gimay 20200715
                        cDalHRIMS._mPictureFile = _nSqlDr.Item("Picfile").ToString 'Gimay 20200715
                        'cDalHRIMS._mTin = _nSqlDr.Item("DateApplied").ToString

                        'Spouse---------
                        cDalHRIMS._mSpouse_FName = _nSqlDr.Item("Spouse").ToString
                        cDalHRIMS._mSpouse_MName = _nSqlDr.Item("Spouse_MidN").ToString
                        cDalHRIMS._mSpouse_LName = _nSqlDr.Item("Spouse_LastN").ToString
                        cDalHRIMS._mSpouse_Occupation = _nSqlDr.Item("SpsOccu").ToString
                        cDalHRIMS._mSpouse_BusinessAdd = _nSqlDr.Item("SpsBusAdd").ToString
                        cDalHRIMS._mSpouse_BusinessName = _nSqlDr.Item("SpsBusName").ToString
                        cDalHRIMS._mSpouse_TelNo = _nSqlDr.Item("SpsTelno").ToString
                        'Father---------
                        cDalHRIMS._mFather_FName = _nSqlDr.Item("Father").ToString
                        cDalHRIMS._mFather_MName = _nSqlDr.Item("Father_MidN").ToString
                        cDalHRIMS._mFather_LName = _nSqlDr.Item("Father_LastN").ToString
                        'Mother---------
                        cDalHRIMS._mMother_FName = _nSqlDr.Item("Mother").ToString
                        cDalHRIMS._mMother_MName = _nSqlDr.Item("Mother_MidN").ToString
                        cDalHRIMS._mMother_LName = _nSqlDr.Item("Mother_LastN").ToString
                    Loop
                    RecFound = True
                Else
                    RecFound = False
                    'no record found
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub




#End Region

#Region "Routines"


#End Region




#Region "TRANSACTION LOG" 'Gimay 20200623

    Public Function GetServerDate() As Date 'Gimay 20200424
        Dim _cmd As SqlCommand = Nothing
        Dim _rdr As SqlDataReader = Nothing
        Try


            _cmd = New SqlCommand("SELECT GETDATE() AS ServerDate", cGlobalConnections._pSqlCxn_HRIMS)
            _rdr = _cmd.ExecuteReader
            _rdr.Read()

            If _rdr.HasRows Then
                Return _rdr.Item("ServerDate").ToString
            End If
            ' con.Dispose()
        Catch ex As Exception

        Finally
            _cmd.Dispose()
            _rdr.Close()
        End Try
    End Function
    Public Sub _pSaveTransactionLog(ByVal _mDate As String, ByVal _mDetails As String, ByVal _mModule As String, ByVal _mType As String, ByVal _mUserID As String, Optional stat As String = "")
        Dim _nStrSql As String = ""
        Try

            _nStrSql = " EXEC [sp_TransactionLog_IUD] @Action = 'INSERT' " &
                                IIf(_mDate = "", "", ",@Date= N'" & _mDate & "' ") &
                                IIf(_mDetails = "", "", ",@Details= N'" & _mDetails & "' ") &
                                IIf(_mModule = "", "", ",@Module= N'" & _mModule & "' ") &
                                IIf(_mType = "", "", ",@Type= N'" & _mType & "' ") &
                                IIf(_mUserID = "", "", ",@UserID= N'" & _mUserID & "' ") &
                                IIf(stat = "", "", ",@Status= N'" & stat & "' ") &
                               ",@Successful = @Successful output  " &
                               ",@ErrMsg = @ErrMsg output  "


            _mSqlCommand = New SqlCommand(_nStrSql, cGlobalConnections._pSqlCxn_HRIMS)

            'set paramater Success
            _mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output

            'set paramater Error
            _mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        '_mCode = _nSqlDr.Item(0).ToString
                    Loop
                End If
            End Using


            _mSuccessful = _mSqlCommand.Parameters("@Successful").Value
            _mErrMsg = _mSqlCommand.Parameters("@ErrMsg").Value
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
