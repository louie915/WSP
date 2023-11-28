


#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalBP

#Region "Variables Data"
    Public _SqlConnection As SqlConnection
    Private _SqlCommand As SqlCommand
    Private _SqlDataAdapter As SqlDataAdapter
    Private _SqlDataReader As SqlDataReader
    Public _DataTable As DataTable
#End Region




#Region "Routine Command"

    Public Sub _pSubSelect_BPR()
        Try
            Dim _Query As String = _
                " select	bm.ACCTNO,	(CONCAT(CONCAT(bm.Last_Name +' ',bm.first_Name+' ') , bm.Middle_Name) )[OWNER],	(BM.COMMNAME)[BUSNAME],(BM.COMMADDR)[BUSADDRESS], " & _
                " (Select SUBSTRING( (SELECT ' ' + BC.DESCRIPTION + ' ||'   FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.BUSLINE BL" & _
                "  INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.BUSCODE BC ON BL.BUS_CODE=BC.BUS_CODE" & _
                "  WHERE ACCTNO=bm.ACCTNO AND FORYEAR=(" & _
                "  SELECT TOP 1 FORYEAR FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.BUSLINE WHERE ACCTNO=bm.ACCTNO ORDER BY FORYEAR DESC" & _
                "  ) FOR XML PATH('') ), 2 , 9999))  As CATEGORY" & _
                "  from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.[busmast] bm " & _
                "  INNER JOIN BUSDETAIL BD ON BM.ACCTNO=BD.ACCTNO " & _
                "  where BD.EMAIL2='" & cSessionUser._pUserID & "' and bm.acctno not in" & _
                "  (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.[BILLINGTEMP] WHERE FORYEAR = YEAR(GETDATE()))" & _
                " "
            _SqlCommand = New SqlCommand(_Query, _SqlConnection)
            Dim _SqlDataAdapter As New SqlDataAdapter(_Query, _SqlConnection)
            _DataTable = New DataTable
            _SqlDataAdapter.Fill(_DataTable)
            _SqlConnection.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelect_BPP()
        Try
            Dim _Query As String = _
                " select distinct sos.ACCTNO,sos.OWNER,sos.BUSNAME,sos.BUSADDRESS,sos.CATEGORY from BUSDETAIL sos  " & _
                " inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.[BILLINGTEMP] bpl  on bpl.acctno=sos.acctno" & _
                "   WHERE sos.EMAIL2='" & cSessionUser._pUserID & "' and bpl.foryear = year(getdate()) and isnull(bpl.isposted,0) = 0"

            _SqlCommand = New SqlCommand(_Query, _SqlConnection)
            Dim _SqlDataAdapter As New SqlDataAdapter(_Query, _SqlConnection)
            _DataTable = New DataTable
            _SqlDataAdapter.Fill(_DataTable)
            _SqlConnection.Close()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelect_BPI()
        Try
            Dim _Query As String = _
                " select distinct sos.ACCTNO,sos.OWNER,sos.BUSNAME,sos.BUSADDRESS,sos.CATEGORY from BUSDETAIL sos  " & _
                " inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].DBO.[BUSINESSPERMIT] BP  on BP.acctno=sos.acctno" & _
                "   WHERE sos.EMAIL2='" & cSessionUser._pUserID & "' and BP.foryear = year(getdate())"

            _SqlCommand = New SqlCommand(_Query, _SqlConnection)
            Dim _SqlDataAdapter As New SqlDataAdapter(_Query, _SqlConnection)
            _DataTable = New DataTable
            _SqlDataAdapter.Fill(_DataTable)
            _SqlConnection.Close()
        Catch ex As Exception
        End Try
    End Sub

    'Public Sub _pSubGetTotFileSize(ByRef strSize As String, ByRef intSize As Integer, ByRef Err As String)
    '    Try
    '        '----------------------------------      
    '        Dim _nQuery As String
    '        _nQuery = _
    '            " WITH D(intSize) as (SELECT SUM(cast([FileSize] as int) )  FROM [Carousel])" & _
    '            " SELECT case " & _
    '            " when D.intSize < 1048576 then concat(format(D.intSize / 1024.0, 'N3'), ' KB')" & _
    '            " when D.intSize < 1073741824 then concat(format(D.intSize / 1048576.0, 'N3'), ' MB')   " & _
    '            " end as strSize, intSize from D"
    '        Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        _mSqlDataReader = _nSqlCommand.ExecuteReader
    '        If _mSqlDataReader.HasRows Then
    '            Do Until _mSqlDataReader.Read = False
    '                strSize = _mSqlDataReader("strSize")
    '                intSize = _mSqlDataReader("intSize")
    '            Loop
    '        Else
    '            strSize = 0
    '            intSize = 0
    '        End If
    '        _mSqlDataReader.Close()
    '        _nSqlCommand.Dispose()
    '        '----------------------------------
    '    Catch ex As Exception
    '        Err = ex.Message
    '        strSize = 0
    '        intSize = 0
    '    End Try

    'End Sub

    'Public Sub _pSubCreateTable(ByVal tblName As String)
    '    Try
    '        Dim _nQuery As String = Nothing
    '        If tblName.ToUpper = "CAROUSEL" Then
    '            _nQuery = "CREATE TABLE [dbo].[Carousel]([FileName] [nvarchar](max) NULL,	[FileType] [nvarchar](max) NULL,	[FileData] [varbinary](max) NULL,	[FileSize] [nvarchar](max) NULL)"
    '        End If
    '        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
    '        _mDataTable = New DataTable
    '        _nSqlDataAdapter.Fill(_mDataTable)
    '        With _mSqlCommand.Parameters
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Sub _pSubAlterTableAutoNum(ByVal tblName As String, ByVal ParamName As String)
    '    Try
    '        Dim _nQuery As String = Nothing
    '        _nQuery = "ALTER TABLE dbo." & tblName & "   ADD " & ParamName & " INT IDENTITY       CONSTRAINT PK_" & tblName & " PRIMARY KEY CLUSTERED"
    '        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
    '        _mDataTable = New DataTable
    '        _nSqlDataAdapter.Fill(_mDataTable)
    '        With _mSqlCommand.Parameters
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Function _pSubCheckIfTableExist(ByVal tblName As String) As Boolean
    '    Dim Exists As Boolean = False
    '    Try
    '        '----------------------------------      
    '        Dim _nQuery As String = "If exists (select * from " & cGlobalConnections._pSqlCxn_CR.Database & ".sys.tables where name = '" & tblName.ToUpper & "')    select '1' as [Exists]	else (select '0' as [Exists])"
    '        Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        _mSqlCon.Open()
    '        _mSqlDataReader = _nSqlCommand.ExecuteReader
    '        If _mSqlDataReader.HasRows Then
    '            Do Until _mSqlDataReader.Read = False
    '                Exists = _mSqlDataReader("Exists")
    '            Loop
    '        End If
    '        _mSqlDataReader.Close()
    '        _nSqlCommand.Dispose()
    '        '----------------------------------
    '    Catch ex As Exception
    '        Exists = False
    '    End Try


    '    Return Exists
    'End Function




    'Public Function _pSubDisplayCarousel() As String
    '    Dim HTMLstring As String = Nothing
    '    Try
    '        '----------------------------------      
    '        Dim _nQuery As String = "select [FileID],[FileName],[FileType],[FileData],[FileSize],('data:'+ [FileType] +';base64,'+ [File64])[File64]  from [Carousel] cross apply (select [FileData] as '*' for xml path('')) T (File64) order by FileName"
    '        Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        _mSqlDataReader = _nSqlCommand.ExecuteReader
    '        If _mSqlDataReader.HasRows Then
    '            Dim ctr As Integer = 0
    '            Do Until _mSqlDataReader.Read = False
    '                If ctr = 0 Then
    '                    HTMLstring += "<div class='carousel-item active'> <img src='" & _mSqlDataReader("File64") & "' class='d-block w-100' style='border-radius: 5px;'/>'</div>"
    '                Else
    '                    HTMLstring += "<div class='carousel-item'> <img src='" & _mSqlDataReader("File64") & "' class='d-block w-100' style='border-radius: 5px;'/>'</div>"
    '                End If

    '                ctr += 1
    '            Loop
    '        Else
    '            HTMLstring = Nothing
    '        End If
    '        _mSqlDataReader.Close()
    '        _nSqlCommand.Dispose()

    '        '----------------------------------
    '    Catch ex As Exception
    '        HTMLstring = Nothing
    '    End Try


    '    Return HTMLstring
    'End Function

    'Public Sub _pSubRemoveCarousel(ByVal FileID As String, ByVal FileName As String)
    '    Try
    '        Dim _nQuery As String = Nothing
    '        _nQuery = "DELETE from CAROUSEL where FileId='" & FileID & "' and FileName = '" & FileName & "'"
    '        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
    '        _mDataTable = New DataTable
    '        _nSqlDataAdapter.Fill(_mDataTable)
    '        With _mSqlCommand.Parameters
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Public Sub _pSubRemoveAllCarousel()
    '    Try
    '        Dim _nQuery As String = Nothing
    '        _nQuery = "DELETE from CAROUSEL "
    '        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
    '        _mDataTable = New DataTable
    '        _nSqlDataAdapter.Fill(_mDataTable)
    '        With _mSqlCommand.Parameters
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub



#End Region





End Class
