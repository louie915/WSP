


#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalImageSetup

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


#End Region

#Region "Properties Data"
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

#Region "Variable Field"


    Private _mUserID As String


#End Region

#Region "Property Field"


    Public Property _pUserID As String
        Get
            Return _mUserID
        End Get
        Set(value As String)
            _mUserID = value
        End Set
    End Property

#End Region

#Region "Routine Command"

    Public Sub _pSubSelectCarousel()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                "select [FileID],[FileName]," & _
                " (SELECT case " & _
                " when cast(FileSize as Int) < 1048576 then concat(format(cast(FileSize as Int) / 1024.0, 'N3'), ' KB')" & _
                " when cast(FileSize as Int) < 1073741824 then concat(format(cast(FileSize as Int) / 1048576.0, 'N3'), ' MB')   " & _
                " end)strSize" & _
                " ,('data:'+ [FileType] +';base64,'+ [File64])[File64]  from [Carousel] cross apply (select [FileData] as '*' for xml path('')) T (File64) order by FileName" & _
                ""

            '"select [FileID],[FileName],[FileType],[FileData],[FileSize],('data:'+ [FileType] +';base64,'+ [File64])[File64]  from [Carousel] cross apply (select [FileData] as '*' for xml path('')) T (File64) order by FileName"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelectDLForms()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                "select [FileID],[FileName]," & _
                " (SELECT case " & _
                " when cast(FileSize as Int) < 1048576 then concat(format(cast(FileSize as Int) / 1024.0, 'N3'), ' KB')" & _
                " when cast(FileSize as Int) < 1073741824 then concat(format(cast(FileSize as Int) / 1048576.0, 'N3'), ' MB')   " & _
                " end)strSize" & _
                " ,('data:'+ [FileType] +';base64,'+ [File64])[File64]  from [DLForms] cross apply (select [FileData] as '*' for xml path('')) T (File64) order by FileName" & _
                ""
             _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubGetTotFileSize(ByRef strSize As String, ByRef intSize As Integer, ByRef Err As String, ByVal TblName As String)
        Try
            '----------------------------------      
            Dim _nQuery As String
            _nQuery = _
                " WITH D(intSize) as (SELECT SUM(cast([FileSize] as int) )  FROM [" & TblName.ToUpper & "])" & _
                " SELECT isnull( (select case " & _
                " when D.intSize < 1048576 then concat(format(D.intSize / 1024.0, 'N3'), ' KB')" & _
                " when D.intSize < 1073741824 then concat(format(D.intSize / 1048576.0, 'N3'), ' MB')" & _
                " end as strSize),0)strSize, isnull(intSize,0)intSize from D"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    strSize = _mSqlDataReader("strSize")
                    intSize = _mSqlDataReader("intSize")
                Loop
            Else
                strSize = 0
                intSize = 0
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            Err = ex.Message
            strSize = 0
            intSize = 0
        End Try

    End Sub

    Function get_Img(ByVal TransactionNo As String) As String
        Dim strImg As String = Nothing
        Try
            '----------------------------------      
            Dim _nQuery As String
            _nQuery = _
                 " select " & _
                 " ('data:'+ [FileType] +';base64,'+ [File64])[File64]  from [TABLE_NAME] " & _
                 " cross apply (select [FileData] as '*' for xml path('')) T (File64)  " & _
                 " where TransactionNo = '' "
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon) 
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    strImg = _mSqlDataReader("File64")
                Loop
            Else
                strImg = "#"
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            strImg = "#"
        End Try

        Return strImg
    End Function

    Public Sub _pSubCreateTable(ByVal tblName As String)
        Try
            Dim _nQuery As String = Nothing
            If tblName.ToUpper = "CAROUSEL" Then
                _nQuery = "CREATE TABLE [dbo].[Carousel]([FileName] [nvarchar](max) NULL,	[FileType] [nvarchar](max) NULL,	[FileData] [varbinary](max) NULL,	[FileSize] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "DLFORMS" Then
                _nQuery = "CREATE TABLE [dbo].[DLForms]([FileName] [nvarchar](max) NULL,	[FileType] [nvarchar](max) NULL,	[FileData] [varbinary](max) NULL,	[FileSize] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "LINKATTACHMENT" Then
                _nQuery = "CREATE TABLE [dbo].[LINKATTACHMENT]([FileName] [nvarchar](max) NULL,	[FileType] [nvarchar](max) NULL,	[FileData] [varbinary](max) NULL,	[FileSize] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "POLICY" Then
                _nQuery = "CREATE TABLE [dbo].[POLICY]([Title] [nvarchar](max) NULL,	[Content] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "ANNOUNCEMENT" Then
                _nQuery = "CREATE TABLE [dbo].[ANNOUNCEMENT]([Title] [nvarchar](max) NULL,	[Content] [nvarchar](max) NULL,	[DATE] [nvarchar](max) NULL,[STATUS] [bit])"
            ElseIf tblName.ToUpper = "MASKING" Then
                _nQuery = "CREATE TABLE [dbo].[MASKING]([Module] [nvarchar](max) NULL,	[MASKING] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "RPTPROFILE" Then
                _mSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
                _nQuery = " CREATE TABLE [dbo].[RPTPROFILE]( " &
                          " [Region] [nvarchar](max) NULL," &
                          " [Prov] [nvarchar](max) NULL," &
                          " [ProvName] [nvarchar](max) NULL," &
                          " [City] [nvarchar](max) NULL," &
                          " [District] [nvarchar](max) NULL," &
                          " [DistrictName] [nvarchar](max) NULL," &
                          " [LguLevel] [nvarchar](max) NULL," &
                          " [LguName] [nvarchar](max) NULL," &
                          " [Prefix] [nvarchar](max) NULL" &
                          " )"
            End If
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSaveTerms(ByVal Title As String, ByVal Content As String, ByVal EXISTS As Boolean, ByRef ERR As String)
        Try
            Dim _nQuery As String = Nothing
            If EXISTS = True Then
                _nQuery = "UPDATE POLICY SET TITLE='" & Title & "',CONTENT='" & Content & "'"
            Else
                _nQuery = "INSERT INTO POLICY VALUES('" & Title & "','" & Content & "')"
            End If
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            ERR = ex.Message
        End Try
    End Sub

    Public Sub _pSubGetTerms(ByRef Title As String, ByRef Content As String, ByRef ERR As String)
        Try
            '----------------------------------      
            Dim _nQuery As String = "Select * from Policy"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    Title = _mSqlDataReader("Title")
                    Content = _mSqlDataReader("Content")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            ERR = Nothing
            '----------------------------------
        Catch ex As Exception
            Err = ex.Message
        End Try
    End Sub

    Public Function hasTerms() As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------      
            Dim _nQuery As String = "SELECT * FROM POLICY"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            '   _mSqlCon.Open()
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Exists = True
            Else
                Exists = False
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            Exists = False
        End Try
        Return Exists
    End Function

    Public Sub _pSubSaveANN(ByVal _Title As String, ByVal _Content As String, ByVal _DATE As String, ByVal _STATUS As Boolean, ByVal EXISTS As Boolean, ByRef ERR As String)
        Try
            Dim _nQuery As String = Nothing
            If EXISTS = True Then
                _nQuery = "UPDATE ANNOUNCEMENT SET TITLE='" & _Title & "',CONTENT='" & _Content & "',[DATE]='" & _DATE & "',[STATUS]='" & _STATUS & "'"
            Else
                _nQuery = "INSERT INTO ANNOUNCEMENT VALUES('" & _Title & "','" & _Content & "','" & _DATE & "','" & _STATUS & "')"
            End If
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            ERR = ex.Message
        End Try
    End Sub
    Public Sub _pSubGetANN(ByRef _Title As String, ByRef _Content As String, ByRef _DATE As String, ByRef _STATUS As Boolean, ByRef ERR As String)
        Try
            '----------------------------------      
            Dim _nQuery As String = "Select * from ANNOUNCEMENT"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    _Title = _mSqlDataReader("Title")
                    _Content = _mSqlDataReader("Content")
                    _DATE = _mSqlDataReader("DATE")
                    _STATUS = _mSqlDataReader("STATUS")

                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            ERR = Nothing
            '----------------------------------
        Catch ex As Exception
            ERR = ex.Message
        End Try
    End Sub
    Public Function hasANN() As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------      
            Dim _nQuery As String = "SELECT * FROM ANNOUNCEMENT"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            '   _mSqlCon.Open()
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Exists = True
            Else
                Exists = False
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            Exists = False
        End Try
        Return Exists
    End Function


    Public Sub _pSubAlterTableAutoNum(ByVal tblName As String, ByVal ParamName As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE dbo." & tblName & "   ADD " & ParamName & " INT IDENTITY       CONSTRAINT PK_" & tblName & " PRIMARY KEY CLUSTERED"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Function _pSubCheckIfTableExist(ByVal tblName As String) As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------     
           
            Dim _nQuery As String

            If tblName = "RPTPROFILE" Then
                _nQuery = "If exists (select * from " & cGlobalConnections._pSqlCxn_RPTIMS.Database & ".sys.tables where name = '" & tblName.ToUpper & "')    select '1' as [Exists]	else (select '0' as [Exists])"
            Else
                _nQuery = "If exists (select * from " & cGlobalConnections._pSqlCxn_CR.Database & ".sys.tables where name = '" & tblName.ToUpper & "')    select '1' as [Exists]	else (select '0' as [Exists])"
            End If


            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            If _mSqlCon.State = ConnectionState.Closed Then
                _mSqlCon.Open()
            End If
            '   _mSqlCon.Open()
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    Exists = _mSqlDataReader("Exists")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            Exists = False
        End Try


        Return Exists
    End Function

    Public Sub _pSubDisplayTNC(ByRef TITLE As String, ByRef CONTENT As String)
        Try
            Dim _nQuery As String = "SELECT * FROM POLICY"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Dim ctr As Integer = 0
                Do Until _mSqlDataReader.Read = False
                    CONTENT = _mSqlDataReader("CONTENT")
                    TITLE = _mSqlDataReader("TITLE")
                Loop
            Else
                CONTENT = Nothing
                TITLE = Nothing
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
            CONTENT = Nothing
            TITLE = Nothing
        End Try
    End Sub

    Public Sub _pSubDisplayANN(ByRef _TITLE As String, ByRef _CONTENT As String, ByRef _DATE As String, ByRef _STATUS As Boolean)
        Try
            Dim _nQuery As String = "SELECT * FROM ANNOUNCEMENT"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    _CONTENT = _mSqlDataReader("CONTENT")
                    _TITLE = _mSqlDataReader("TITLE")
                    _DATE = _mSqlDataReader("DATE")
                    _STATUS = _mSqlDataReader("STATUS")
                Loop
            Else
                _CONTENT = Nothing
                _TITLE = Nothing
                _DATE = Nothing
                _STATUS = False
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
            _CONTENT = Nothing
            _TITLE = Nothing
            _DATE = Nothing
            _STATUS = False
        End Try


    End Sub

    Public Function _pSubDisplayLogo() As String
        Dim file64 As String
        Try
            Dim _nQuery As String = " select ('data:'+ [LGU_LOGO_Ext] +';base64,'+ [File64])[File64]  from LGU_Profile cross apply (select [LGU_LOGO] as '*' for xml path('')) T (File64)"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Dim ctr As Integer = 0
                Do Until _mSqlDataReader.Read = False
                    file64 = _mSqlDataReader("File64")
                Loop
            Else
                file64 = Nothing
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
        End Try
        Return file64
    End Function

    Public Function _pSubDisplayLINKATTACHMENT(ByVal Link As String) As String
        Dim file64 As String
        Try
            Dim _nQuery As String = " select ('data:'+ [FileType] +';base64,'+ [File64])[File64]  from LGU_Profile cross apply (select [FileData] as '*' for xml path('')) T (File64)" &
                                    " where FileName='" & Link & "'"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Dim ctr As Integer = 0
                Do Until _mSqlDataReader.Read = False
                    file64 = _mSqlDataReader("File64")
                Loop
            Else
                file64 = Nothing
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
        End Try
        Return file64
    End Function

    Public Function _pSubDisplayCarousel() As String
        Dim HTMLstring As String = Nothing
        Try
            '----------------------------------      
            Dim _nQuery As String = "select [FileID],[FileName],[FileType],[FileData],[FileSize],('data:'+ [FileType] +';base64,'+ [File64])[File64]  from [Carousel] cross apply (select [FileData] as '*' for xml path('')) T (File64) order by FileName"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Dim ctr As Integer = 0
                Do Until _mSqlDataReader.Read = False
                    If ctr = 0 Then
                        HTMLstring += "<div class='carousel-item active'> <img src='" & _mSqlDataReader("File64") & "' style='max-height: 90vh; max-width: 100%' /></div>"
                    Else
                        HTMLstring += "<div class='carousel-item'> <img src='" & _mSqlDataReader("File64") & "' style='max-height: 80vh; max-width: 100%'/></div>"
                    End If

                    ctr += 1
                Loop
            Else
                HTMLstring = Nothing
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception
            HTMLstring = Nothing
        End Try


        Return HTMLstring
    End Function

    Public Sub _pSubRemoveCarousel(ByVal FileID As String, ByVal FileName As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "DELETE from CAROUSEL where FileId='" & FileID & "' and FileName = '" & FileName & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRemoveAllCarousel()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "DELETE from CAROUSEL "
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRemoveDLForms(ByVal FileID As String, ByVal FileName As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "DELETE from DLForms where FileId='" & FileID & "' and FileName = '" & FileName & "'"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRemoveAllDLForms()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "DELETE from DLForms "
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

#End Region






End Class
