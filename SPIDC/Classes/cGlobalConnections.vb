
#Region "Imports"

Imports System.Data.SqlClient
'Imports VS2014.CL.CR.cEventLog
Imports System.Reflection.MethodBase
Imports System.IO

#End Region

Public Class cGlobalConnections

#Region "Variable Constant"

    ''Private Const _mStrServerName_SJDM As String = "10.0.0.19\SQL2012ENT"
    ''Private Const _mStrDBName_SJDM As String = "R&D.CR"
    ''Private Const _mStrUserID_SJDM As String = "iisadmin"
    ''Private Const _mStrPass_SJDM As String = "#@VeryStr0ngS@P@ssw0rd#"

    'SPIDC
    Private Shared _mStrCxn_CR_Manila As String =
        "Data Source=WEBSERVER\MSSQL2012" & _
        ";Initial Catalog=R&D.CR" & _
        ";User ID=iisadmin" & _
        ";Password=#@VeryStr0ngS@P@ssw0rd#"

    'NEDA
    Private Shared _mStrCxn_CR_IAIS_SVR As String = _
        "Data Source=IAIS-SVR" & _
        ";Initial Catalog=CR" & _
        ";User ID=iisadmin" & _
        ";Password=#@VeryStr0ngS@P@ssw0rd#"

    'Brazil
    Private Shared _mStrCxn_CR_Brazil As String = _
        "Data Source=PRG-BRAZIL\SQL2012" & _
        ";Initial Catalog=CR" & _
        ";User ID=iisadmin" & _
        ";Password=#@VeryStr0ngS@P@ssw0rd#"

    'Webserver
    Private Const _mStrCxn_CR_Webserver As String = _
        "Data Source=WEBSERVER\MSSQL2012" & _
        ";Initial Catalog=R&D.CR" & _
        ";User ID=iisadmin" & _
        ";Password=#@VeryStr0ngS@P@ssw0rd#"

    'MUNTIWS
    Private Shared _mStrCxn_CR_MUNTIWS As String = _
        "Data Source=192.168.50.10" & _
        ";Initial Catalog=WEB_CR" & _
        ";User ID=iisadmin" & _
        ";Password=#P@ssw0rd#"


    'Modified By Louie 20190621
    Private Shared _mStrCxn_CR_SJDM As String = _
      "Data Source=" & _mStrCR_ServerName & _
      ";Initial Catalog=" & _mStrCR_DBName & _
      ";User ID=" & _mStrCR_ID & _
      ";Password=" & _mStrCR_Pass

    'Private Const _mStrCxn_CR_SJDM As String = _
    '    "Data Source=10.0.0.19\SQL2012ENT" & _
    '    ";Initial Catalog=R&D.CR" & _
    '    ";User ID=iisadmin" & _
    '    ";Password=#@VeryStr0ngS@P@ssw0rd#"

    'EGYPT
    Private Shared _mStrCxn_CR_EGYPT As String = _
        "Data Source=10.0.0.19\SQL2012ENT" & _
        ";Initial Catalog=R&D.CR" & _
        ";User ID=iisadmin" & _
        ";Password=#@VeryStr0ngS@P@ssw0rd#"
    'PARIS
    Private Shared _mStrCxn_CR_PARIS As String = _
        "Data Source=PARIS" & _
        ";Initial Catalog=R&D.CR" & _
        ";User ID=sa" & _
        ";Password=P@ssw0rd"

    'LaTrinidad
    Private Shared _mStrCxn_CR_Latrinidad As String = _
        "Data Source=MAINSERVER" & _
        ";Initial Catalog=R&D.CR" & _
        ";User ID=sa" & _
        ";Password=P@ssw0rd"

    'Templates
    Private Shared _mStrCxn_Templates As String = _
        "Data Source=MANILA\MSSQL2012DEV" & _
        ";Initial Catalog=R&D.Templates" & _
        ";User ID=iisadmin" & _
        ";Password=#@VeryStr0ngS@P@ssw0rd#"
#End Region

#Region "Variable"

    Private Shared _mSqlCxn_Templates As New SqlConnection

    '----------------------------------
    'Web Database.
    Private Shared _mStrCxn_CR As String
    Private Shared _mSqlCxn_CR As New SqlConnection

    'Added 20190620 By louie
    Private Shared _mStrCR_ServerName As String
    Private Shared _mStrCR_ID As String
    Private Shared _mStrCR_Pass As String
    Private Shared _mStrCR_DBName As String

    'Windows Form Database.112	
    Private Shared _mStrCxn_LGU As String
    Private Shared _mSqlCxn_LGU As New SqlConnection

    '----------------------------------
    'Web Application Database.
    Private Shared _mStrCxn_OAIMS As String
    Private Shared _mSqlCxn_OAIMS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_BMMS As String
    Private Shared _mSqlCxn_BMMS As New SqlConnection

    '----------------------------------
    'Web Application Database.
    Private Shared _mStrCxn_BPLTIMS As String
    Private Shared _mSqlCxn_BPLTIMS As New SqlConnection
    Private Shared _mStrCxn_BPLTIMS_F As String
    Private Shared _mSqlCxn_BPLTIMS_F As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_BPLTAS As String
    Private Shared _mSqlCxn_BPLTAS As New SqlConnection
    Private Shared _mStrCxn_BPLTAS_D As String
    Private Shared _mSqlCxn_BPLTAS_D As New SqlConnection
    Private Shared _mStrCxn_BPLTAS_F As String
    Private Shared _mSqlCxn_BPLTAS_F As New SqlConnection
    '----------------------------------
    'Web Application Database.
    Private Shared _mStrCxn_ExIMS As String
    Private Shared _mSqlCxn_ExIMS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_GAAMS As String
    Private Shared _mSqlCxn_GAAMS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_GSMS As String
    Private Shared _mSqlCxn_GSMS As New SqlConnection

    '----------------------------------
    'Web Application Database.
    Private Shared _mStrCxn_HRIMS As String
    Private Shared _mSqlCxn_HRIMS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_PMIPS As String
    Private Shared _mSqlCxn_PMIPS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_MMS As String
    Private Shared _mSqlCxn_MMS As New SqlConnection

    '----------------------------------
    'Web Application Database.
    Private Shared _mStrCxn_TIMS As String
    Private Shared _mSqlCxn_TIMS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_TOIMS As String
    Private Shared _mSqlCxn_TOIMS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_RPTAS As String
    Private Shared _mSqlCxn_RPTAS As New SqlConnection

    '----------------------------------
    'Windows Form Database.
    Private Shared _mStrCxn_RPTAS_T As String
    Private Shared _mSqlCxn_RPTAS_T As New SqlConnection

    '----------------------------------
    'Web Application Database.
    Private Shared _mStrCxn_RPTIMS As String
    Private Shared _mSqlCxn_RPTIMS As New SqlConnection



#End Region

#Region "Property Templates"

    Public Shared ReadOnly Property _pStrCxn_Templates() As String
        Get
            Return _mStrCxn_Templates
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_Templates() As SqlConnection
        Get
            Try
                '----------------------------------

                If _mSqlCxn_Templates.State = ConnectionState.Closed Then
                    _mSqlCxn_Templates.ConnectionString = _pStrCxn_Templates
                    _mSqlCxn_Templates.Open()
                End If

                Return _mSqlCxn_Templates
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property CR"

    Public Shared ReadOnly Property _pStrCxn_CR() As String
        Get
            _mSubGetConnectionString_CR()
            'TODO: Encrypt Connection String 
            Return _mStrCxn_CR
        End Get
    End Property

    Public Shared ReadOnly Property _pStrCxn_LGU() As String
        Get
            Return _mSubGetConnectionString("LGU")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_LGU() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_LGU.State = ConnectionState.Closed Then
                    _mSqlCxn_LGU.ConnectionString = _pStrCxn_LGU
                    _mSqlCxn_LGU.Open()
                End If

                Return _mSqlCxn_LGU
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

    Public Shared ReadOnly Property _pSqlCxn_CR() As SqlConnection
        Get
            Try
                '----------------------------------
                'TODO: Try detecting if connection is broken, closed, fetching..etc..

                If _mSqlCxn_CR.State = ConnectionState.Closed Then
                    _mSqlCxn_CR = New SqlConnection
                    _mSqlCxn_CR.ConnectionString = _pStrCxn_CR
                    _mSqlCxn_CR.Open()
                Else
                    _mSqlCxn_CR.Close()
                    _mSqlCxn_CR = New SqlConnection
                    _mSqlCxn_CR.ConnectionString = _pStrCxn_CR
                    _mSqlCxn_CR.Open()

                End If

                Return _mSqlCxn_CR
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

    ' Added 20190620 By louie
    '========================================================================
    Public Shared ReadOnly Property _pStrCR_ServerName() As String
        Get
            Return _mStrCR_ServerName
        End Get
    End Property

    Public Shared ReadOnly Property _pStrCR_ID() As String
        Get
            Return _mStrCR_ID
        End Get
    End Property

    Public Shared ReadOnly Property _pStrCR_Pass() As String
        Get
            Return _mStrCR_Pass
        End Get
    End Property

    Public Shared ReadOnly Property _pStrCR_DBName() As String
        Get
            Return _mStrCR_DBName
        End Get
    End Property
    '========================================================================

#End Region

#Region "Property OAIMS"

    Public Shared ReadOnly Property _pStrCxn_OAIMS() As String
        Get
            Return _mSubGetConnectionString("OAIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_OAIMS() As SqlConnection
        Get
            Try
                '----------------------------------
                'If _mSqlCxn_OAIMS.State <> ConnectionState.Closed And _mSqlCxn_OAIMS.State.HasFlag(ConnectionState.Open) Then
                '    Return _mSqlCxn_OAIMS
                'Else
                '    _mSqlCxn_OAIMS.ConnectionString = _pStrCxn_OAIMS
                '    _mSqlCxn_OAIMS.Open()
                'End If


                If _mSqlCxn_OAIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_OAIMS.ConnectionString = _pStrCxn_OAIMS
                    _mSqlCxn_OAIMS.Open()
                End If

                Return _mSqlCxn_OAIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property BMMS"

    Public Shared ReadOnly Property _pStrCxn_BMMS() As String
        Get
            Return _mSubGetConnectionString("BMMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_BMMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_BMMS.State = ConnectionState.Closed Then
                    _mSqlCxn_BMMS.ConnectionString = _pStrCxn_BMMS
                    _mSqlCxn_BMMS.Open()
                End If

                Return _mSqlCxn_BMMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region



#Region "Property BPLTIMS"

    Public Shared ReadOnly Property _pStrCxn_BPLTIMS() As String
        Get
            Return _mSubGetConnectionString("BPLTIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_BPLTIMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_BPLTIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_BPLTIMS.ConnectionString = _pStrCxn_BPLTIMS
                    _mSqlCxn_BPLTIMS.Open()
                End If

                Return _mSqlCxn_BPLTIMS
                '----------------------------------
            Catch ex As Exception
                ''_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property BPLTIMS_F"

    Public Shared ReadOnly Property _pStrCxn_BPLTIMS_F() As String
        Get
            Return _mSubGetConnectionString("BPLTIMS_F")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_BPLTIMS_F() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_BPLTIMS_F.State = ConnectionState.Closed Or ConnectionState.Connecting Then
                    _mSqlCxn_BPLTIMS_F.ConnectionString = _pStrCxn_BPLTIMS_F
                    _mSqlCxn_BPLTIMS_F.Open()
                Else

                    _mSqlCxn_BPLTIMS_F.Close()
                    _mSqlCxn_BPLTIMS_F.ConnectionString = _pStrCxn_BPLTIMS_F
                    _mSqlCxn_BPLTIMS_F.Open()

                End If

                Return _mSqlCxn_BPLTIMS_F
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property BPLTAS"

    Public Shared ReadOnly Property _pStrCxn_BPLTAS() As String
        Get
            Return _mSubGetConnectionString("BPLTAS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_BPLTAS() As SqlConnection
        Get
            Try
                '----------------------------------


                If _mSqlCxn_BPLTAS.State = ConnectionState.Closed Then
                    _mSqlCxn_BPLTAS.ConnectionString = _pStrCxn_BPLTAS
                    _mSqlCxn_BPLTAS.Open()
                Else
                    _mSqlCxn_BPLTAS.Close()
                    _mSqlCxn_BPLTAS.ConnectionString = _pStrCxn_BPLTAS
                    _mSqlCxn_BPLTAS.Open()
                End If

                Return _mSqlCxn_BPLTAS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property BPLTAS_D"

    Public Shared ReadOnly Property _pStrCxn_BPLTAS_D() As String
        Get
            Return _mSubGetConnectionString("BPLTAS_D")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_BPLTAS_D() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_BPLTAS_D.State = ConnectionState.Closed Then
                    _mSqlCxn_BPLTAS_D.ConnectionString = _pStrCxn_BPLTAS_D
                    _mSqlCxn_BPLTAS_D.Open()
                End If

                Return _mSqlCxn_BPLTAS_D
                '----------------------------------
            Catch ex As Exception
                ''_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property BPLTAS_F"

    Public Shared ReadOnly Property _pStrCxn_BPLTAS_F() As String
        Get
            Return _mSubGetConnectionString("BPLTAS_F")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_BPLTAS_F() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_BPLTAS_F.State = ConnectionState.Closed Then
                    _mSqlCxn_BPLTAS_F.ConnectionString = _pStrCxn_BPLTAS_F
                    _mSqlCxn_BPLTAS_F.Open()
                End If

                Return _mSqlCxn_BPLTAS_F
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region




#Region "Property ExIMS"

    Public Shared ReadOnly Property _pStrCxn_ExIMS() As String
        Get
            Return _mSubGetConnectionString("ExIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_ExIMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_ExIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_ExIMS.ConnectionString = _pStrCxn_ExIMS
                    _mSqlCxn_ExIMS.Open()
                End If

                Return _mSqlCxn_ExIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property GAAMS"

    Public Shared ReadOnly Property _pStrCxn_GAAMS() As String
        Get
            Return _mSubGetConnectionString("GAAMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_GAAMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_GAAMS.State = ConnectionState.Closed Then
                    _mSqlCxn_GAAMS.ConnectionString = _mStrCxn_GAAMS
                    _mSqlCxn_GAAMS.Open()
                End If

                Return _mSqlCxn_GAAMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property GSMS"

    Public Shared ReadOnly Property _pStrCxn_GSMS() As String
        Get
            Return _mSubGetConnectionString("GSMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_GSMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_GSMS.State = ConnectionState.Closed Then
                    _mSqlCxn_GSMS.ConnectionString = _pStrCxn_GSMS
                    _mSqlCxn_GSMS.Open()
                End If

                Return _mSqlCxn_GSMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property HRIMS"

    Public Shared ReadOnly Property _pStrCxn_HRIMS() As String
        Get
            Return _mSubGetConnectionString("HRIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_HRIMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_HRIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_HRIMS.ConnectionString = _pStrCxn_HRIMS
                    _mSqlCxn_HRIMS.Open()
                End If

                Return _mSqlCxn_HRIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property PMIPS"

    Public Shared ReadOnly Property _pStrCxn_PMIPS() As String
        Get
            Return _mSubGetConnectionString("PMIPS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_PMIPS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_PMIPS.State = ConnectionState.Closed Then
                    _mSqlCxn_PMIPS.ConnectionString = _pStrCxn_PMIPS
                    _mSqlCxn_PMIPS.Open()
                End If

                Return _mSqlCxn_PMIPS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property MMS"

    Public Shared ReadOnly Property _pStrCxn_MMS() As String
        Get
            Return _mSubGetConnectionString("MMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_MMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_MMS.State = ConnectionState.Closed Then
                    _mSqlCxn_MMS.ConnectionString = _pStrCxn_MMS
                    _mSqlCxn_MMS.Open()
                End If

                Return _mSqlCxn_MMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region



#Region "Property TIMS"

    Public Shared ReadOnly Property _pStrCxn_TIMS() As String
        Get
            Return _mSubGetConnectionString("TIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_TIMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_TIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_TIMS.ConnectionString = _pStrCxn_TIMS
                    _mSqlCxn_TIMS.Open()
                End If

                Return _mSqlCxn_TIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property TOIMS"

    Public Shared ReadOnly Property _pStrCxn_TOIMS() As String
        Get
            Return _mSubGetConnectionString("TOIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_TOIMS(Optional err As String = Nothing) As SqlConnection
        Get
            Try
                '----------------------------------

                If _mSqlCxn_TOIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_TOIMS.ConnectionString = _pStrCxn_TOIMS
                    _mSqlCxn_TOIMS.Open()
                End If

                Return _mSqlCxn_TOIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                err = ex.Message
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property RPTAS"

    Public Shared ReadOnly Property _pStrCxn_RPTAS() As String
        Get
            Return _mSubGetConnectionString("RPTAS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_RPTAS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_RPTAS.State = ConnectionState.Closed Then
                    _mSqlCxn_RPTAS.ConnectionString = _pStrCxn_RPTAS
                    _mSqlCxn_RPTAS.Open()
                End If

                Return _mSqlCxn_RPTAS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property RPTAS_T"

    Public Shared ReadOnly Property _pStrCxn_RPTAS_T() As String
        Get
            Return _mSubGetConnectionString("RPTAS_T")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_RPTAS_T() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_RPTAS_T.State = ConnectionState.Closed Then
                    _mSqlCxn_RPTAS_T.ConnectionString = _pStrCxn_RPTAS_T
                    _mSqlCxn_RPTAS_T.Open()
                End If

                Return _mSqlCxn_RPTAS_T
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Property RPTIMS"

    Public Shared ReadOnly Property _pStrCxn_RPTIMS() As String
        Get
            Return _mSubGetConnectionString("RPTIMS")
        End Get
    End Property
    Public Shared ReadOnly Property _pSqlCxn_RPTIMS() As SqlConnection
        Get
            Try
                '----------------------------------
                If _mSqlCxn_RPTIMS.State = ConnectionState.Closed Then
                    _mSqlCxn_RPTIMS.ConnectionString = _pStrCxn_RPTIMS
                    _mSqlCxn_RPTIMS.Open()
                End If

                Return _mSqlCxn_RPTIMS
                '----------------------------------
            Catch ex As Exception
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property

#End Region



#Region "Routine"
    Private Shared Sub _mSubGetConnectionString_CR()
        Try
            '----------------------------------
            'Hard-coded Connection String for "CR" database.
            'Hard-coded Machine Names.
            Dim _nStringConnection As String = Nothing
            Dim _nClass As New cHardwareInformation
            Dim _nMachineName As String = Nothing
            Dim _nMachineIP As String = Nothing

            _nMachineName = _nClass._pMachineName.ToUpper
            _nMachineIP = _nClass._pMachineIP

            'Server Names should be in Upper Casing.
        
            _nStringConnection = cServerConnection._SQLConnectionString(_nMachineName)
            If _nStringConnection = Nothing Then
                _nStringConnection = GetLocalHostConnection()
            End If

            _mStrCxn_CR = _nStringConnection
            '----------------------------------
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
            _mStrCxn_CR = Nothing
        End Try
    End Sub

    Private Shared Function GetLocalHostConnection() As String

        '_mStrCR_ServerName = "HAVANA\MSSQL2019"
        '_mStrCR_ID = "sa"
        '_mStrCR_Pass = "P@ssw0rd"
        '_mStrCR_DBName = "SOS_CR_MUNTINLUPA"



        Dim _mSQLConfig = HttpContext.Current.Server.MapPath("~/SQLCon.env")
        If File.Exists(_mSQLConfig) Then
            Dim lines As String() = File.ReadAllLines(_mSQLConfig)
            For Each line As String In lines
                Dim parts As String() = line.Split("=")
                If parts.Length = 2 Then
                    Dim key As String = parts(0).Trim()
                    Dim value As String = parts(1).Trim()
                    Environment.SetEnvironmentVariable(key, value)
                End If
            Next
            ' Now you can access the environment variables
            'APP NAME
            _mStrCR_ServerName = Environment.GetEnvironmentVariable("CR_ServerName")
            _mStrCR_ID = Environment.GetEnvironmentVariable("CR_ID")
            _mStrCR_Pass = Environment.GetEnvironmentVariable("CR_Pass")
            _mStrCR_DBName = Environment.GetEnvironmentVariable("CR_DBName")

        Else

            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CALOOCAN_20231018"  '"SOS_CR_CAINTA_20230929" 'SOS_CR_CALOOCAN_20231018  '"SOS_CR_CALOOCAN_20230928"

         
        End If

        Return "Data Source=" & _mStrCR_ServerName & _
                     ";Initial Catalog=" & _mStrCR_DBName & _
                     ";User ID=" & _mStrCR_ID & _
                     ";Password=" & _mStrCR_Pass & _
                     ";MultipleActiveResultSets=True"

        'Return cServer.ConStr_CAINTA ' cServer.ConStr_HAVANA
    End Function

    Private Shared Function _mSubGetConnectionString(_nCode As String)
        Try
            '----------------------------------

            Dim _nConnectionString As String = Nothing

            Dim _nClass As New cDalGlobalConnectionsDefault

            _nClass._pCxn = _pSqlCxn_CR
            _nClass._pSetupGlobalConnectionsDatabases = _nCode
            _nClass._pSubRecordSelectSpecific()

            _nConnectionString =
                "Data Source=" & _nClass._pDBDataSource & _
                ";Initial Catalog=" & _nClass._pDBInitialCatalog & _
                ";User ID=" & _nClass._pDBUserID & _
                ";Password=" & _nClass._pDBUserKey & _
                ";MultipleActiveResultSets=True"
            Return _nConnectionString
            '----------------------------------
        Catch ex As Exception
            ''_pSubEventLog(ex, 2)
            Return Nothing
        End Try
    End Function

    Private Sub xxx(_nMachineName As String, _nStringConnection As String)
        Select Case _nMachineName
            Case "HAVANA"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("CALOOCAN") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CALOOCAN")
                ElseIf curr_url.ToUpper.Contains("CSJDM") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CSJDM")
                ElseIf curr_url.ToUpper.Contains("CAINTA") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CAINTA")
                ElseIf curr_url.ToUpper.Contains("CALBAYOG") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CALBAYOG")
                ElseIf curr_url.ToUpper.Contains("LATRINIDAD") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_LATRINIDAD")
                ElseIf curr_url.ToUpper.Contains("BAGO") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_BAGO")
                ElseIf curr_url.ToUpper.Contains("TAYTAY") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_TAYTAY")
                ElseIf curr_url.ToUpper.Contains("ILOILO") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_ILOILO")
                ElseIf curr_url.ToUpper.Contains("CABUGAO") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CABUGAO")
                ElseIf curr_url.ToUpper.Contains("CABUYAO") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CABUYAO")
                ElseIf curr_url.ToUpper.Contains("PASAY") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_PASAY")
                ElseIf curr_url.ToUpper.Contains("CAVITE") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CAVITE")
                ElseIf curr_url.ToUpper.Contains("VICTORIAS") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_VICTORIAS")
                ElseIf curr_url.ToUpper.Contains("BINANGONAN") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_BINANGONAN")

                ElseIf curr_url.ToUpper.Contains("CANDON") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CANDON")


                ElseIf curr_url.ToUpper.Contains("MUNTINLUPA") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_MUNTINLUPA")


                ElseIf curr_url.ToUpper.Contains("LCR") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_LCR")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_HAVANA_CALOOCAN")
                End If

                ' _nStringConnection = _FnGetCRCon("SOS_HAVANA_CAINTA")


            Case "PASAYWEBSERVER"  ' CANDON
                _nStringConnection = _FnGetCRCon("SOS_PASAY")

            Case "PASAYWEBSERVER"  ' PASAY
                _nStringConnection = _FnGetCRCon("SOS_PASAY")

            Case "WAPP01"  ' CAVITE
                _nStringConnection = _FnGetCRCon("SOS_CAVITE")

            Case "WEBAPP"  ' CAVITE
                _nStringConnection = _FnGetCRCon("SOS_CAVITE2")

            Case "WAPP01.lgucavitecity.gov" ' CAVITE
                _nStringConnection = _FnGetCRCon("SOS_CAVITE")

            Case "HELSINKI" ' TALISAY
                _nStringConnection = _FnGetCRCon("SOS_TALISAY")


            Case "SANJUANWEBSVR" ' SANJUAN
                _nStringConnection = _FnGetCRCon("SOS_SANJUAN")

            Case "TARLACWEBSVR" ' TARLAC
                _nStringConnection = _FnGetCRCon("SOS_TARLAC")

            Case "MANDAUEWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_MANDAUE_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_MANDAUE_LIVE")
                End If



            Case "MRVLSWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_MARIVELES_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_MARIVELES_LIVE")
                End If


            Case "MANOLOWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_MANOLO_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_MANOLO_LIVE")
                End If

            Case "TALISAYWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_TALISAY_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_TALISAY")
                End If

            Case "WEBSVRCALOOCAN"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_CALOOCAN_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_CALOOCAN_LIVE")
                End If

            Case "GRACEVILLE"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_CSJDM_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_CSJDM_LIVE")
                End If

            Case "MUNTI-SVR17"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                _nStringConnection = _FnGetCRCon("SOS_MUNTI_DUMMY")

            Case "LENOVOWIN2016"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                _nStringConnection = _FnGetCRCon("SOS_ILOILO")

            Case "TAYTAYWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_TAYTAY_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_TAYTAY")
                End If

            Case "MARAMAGWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_MARAMAG_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_MARAMAG")
                End If

            Case "TKQ_WEBSERVER"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_TAGKAWAYAN_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_TAGKAWAYAN")
                End If

            Case "RODRIGUEZWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_RODRIGUEZ_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_RODRIGUEZ")
                End If

            Case "CAINTAWEBSVR"
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_CAINTA_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_CAINTA")
                End If

            Case "BIZPORTAL" 'SILAY SITY
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_SILAY_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_SILAY")
                End If

            Case "BAGOWEBSERVER" 'BAGO CITY
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_BAGO_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_BAGO")
                End If

            Case "BISLIGWEBSVR" 'BISLIG CITY
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_BISLIG_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_BISLIG")
                End If


            Case "WEBSVR" 'TANAY
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_TANAY_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_TANAY")
                End If


            Case "WEBSERVER2023" 'VICTORIAS
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
                If curr_url.ToUpper.Contains("TEST") = True Then
                    _nStringConnection = _FnGetCRCon("SOS_VICTORIAS_DUMMY")
                Else
                    _nStringConnection = _FnGetCRCon("SOS_VICTORIAS")
                End If

            Case Else
                _nStringConnection = _FnGetCRCon("SOS_HAVANA_CALOOCAN") ' SOS_HAVANA_TALISAY

        End Select

    End Sub

    Private Shared Function _FnGetCRCon(ByVal xServerName As String) As String
        Try
            _FnGetCRCon = Nothing

            Select Case xServerName
                Case "SOS_TOMI"
                    _mStrCR_ServerName = "TOMI\MSSQLSERVER2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CALOOCAN"

                Case "SOS_MARIVELES_LIVE"
                    _mStrCR_ServerName = "MRVLSWEBSVR\MARIVELESWEBSVR"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MARIVELES"

                Case "SOS_MARIVELES_DUMMY"
                    _mStrCR_ServerName = "MRVLSWEBSVR\MARIVELESWEBSVR"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MARIVELES_DUMMY"

                    'Case "SOS_VICTORIAS"
                    '    _mStrCR_ServerName = "STOCKHOLM\MSSQL2014"
                    '    _mStrCR_ID = "sa"
                    '    _mStrCR_Pass = "P@ssw0rd"
                    '    _mStrCR_DBName = "SOS_CR_VICTORIAS"

                Case "SOS_PASAY"
                    _mStrCR_ServerName = "PASAYWEBSERVER\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_PASAY"

                Case "SOS_CAVITE"
                    _mStrCR_ServerName = "WAPP01\MSSQL2019"
                    _mStrCR_ID = "spidcweb"
                    _mStrCR_Pass = "#P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_CAVITE2"
                    _mStrCR_ServerName = "WEBAPP\MSSQLSERVER2019"
                    _mStrCR_ID = "spidcweb"
                    _mStrCR_Pass = "#P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_MANOLO_LIVE"
                    _mStrCR_DBName = "SOS_CR_MANOLO"
                    _mStrCR_ServerName = "MANOLOWEBSVR\GAS"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"

                Case "SOS_MANOLO_DUMMY"
                    _mStrCR_DBName = "SOS_CR_MANOLO_DUMMY"
                    _mStrCR_ServerName = "MANOLOWEBSVR\GAS"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"


                Case "SOS_CALOOCAN_LIVE"
                    _mStrCR_ServerName = "WEBSVRCALOOCAN\MSSQL2014"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CALOOCAN"

                Case "SOS_CALOOCAN_DUMMY"
                    _mStrCR_ServerName = "WEBSVRCALOOCAN\MSSQL2014"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CALOOCAN_WEB_TEST"

                Case "SOS_CSJDM_LIVE"
                    _mStrCR_ServerName = "GRACEVILLE\WEBSVR"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_SJDM"

                Case "SOS_CSJDM_DUMMY"
                    _mStrCR_ServerName = "GRACEVILLE\WEBSVR"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_TARLAC"
                    _mStrCR_ServerName = "TARLACWEBSVR\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TARLAC"

                Case "SOS_SANJUAN"
                    _mStrCR_ServerName = "WIN-N57IJISA71G\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_MANDAUE_LIVE"
                    _mStrCR_ServerName = "MANDAUEWEBSVR\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_LIVE"

                Case "SOS_MANDAUE_DUMMY"
                    _mStrCR_ServerName = "MANDAUEWEBSVR\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_MARILAO_LIVE"
                    _mStrCR_ServerName = "WEBSERVER\WEBSERVER"
                    _mStrCR_ID = "iisadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MARILAO"

                Case "SOS_TALISAY"
                    _mStrCR_ServerName = "HELSINKI"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_TALISAY_DUMMY"
                    _mStrCR_ServerName = "HELSINKI"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_DUMMY"

                Case "SOS_MUNTI_DUMMY"
                    _mStrCR_ServerName = "MUNTI-SVR17"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_ILOILO"
                    _mStrCR_ServerName = "LENOVOWIN2016"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_ILOILO"

                Case "SOS_TAYTAY"
                    _mStrCR_ServerName = "TAYTAYWEBSVR\MSSQL2019"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TAYTAY"

                Case "SOS_TAYTAY_DUMMY"
                    _mStrCR_ServerName = "TAYTAYWEBSVR\MSSQL2014"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "misP@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TAYTAY_TEST"

                Case "SOS_MARAMAG"
                    _mStrCR_ServerName = "MARAMAGWEBSVR\WSP"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MARAMAG"

                Case "SOS_MARAMAG_DUMMY"
                    _mStrCR_ServerName = "MARAMAGWEBSVR\WSP"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_DUMMY"

                Case "SOS_TAGKAWAYAN"
                    _mStrCR_ServerName = "TKQ_WEBSERVER\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_TAGKAWAYAN_DUMMY"
                    _mStrCR_ServerName = "TKQWEBSERVER\WEB"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_DUMMY"

                Case "SOS_RODRIGUEZ"
                    _mStrCR_ServerName = "RODRIGUEZWEBSVR\MSSQLSERVER01"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_RODRIGUEZ_DUMMY"
                    _mStrCR_ServerName = "RODRIGUEZWEBSVR\MSSQLSERVER01"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_DUMMY"

                Case "SOS_CAINTA"
                    _mStrCR_ServerName = "CAINTAWEBSVR\mssql2019"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_SILAY"
                    _mStrCR_ServerName = "BIZPORTAL\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_SILAY"

                Case "SOS_SILAY_DUMMY"
                    _mStrCR_ServerName = "BIZPORTAL"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_SILAY_DUMMY"

                Case "SOS_BAGO"
                    _mStrCR_ServerName = "BAGOWEBSERVER\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_BAGO"

                Case "SOS_BAGO_DUMMY"
                    _mStrCR_ServerName = "CTOWEBSERVER\MSSQLSERVER02"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_BAGO_DUMMY"

                Case "SOS_BISLIG"
                    _mStrCR_ServerName = "BISLIGWEBSVR\MSSQL2019"
                    _mStrCR_ID = "webadmin"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_BISLIG_DUMMY"
                    _mStrCR_ServerName = "BISLIGWEBSVR\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_DUMMY"

                Case "SOS_TANAY"
                    _mStrCR_ServerName = "WEBSVR"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_TANAY_DUMMY"
                    _mStrCR_ServerName = "WSP\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_DUMMY"

                Case "SOS_VICTORIAS"
                    _mStrCR_ServerName = "WEBSERVER2023\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_VICTORIAS"


                    '========================

                Case "SOS_HAVANA"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CALOOCAN_2021"

                Case "SOS_HAVANA_DEMO"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"

                Case "SOS_HAVANA_CALOOCAN"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CALOOCAN_20230504"

                Case "SOS_HAVANA_CSJDM"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_SJDM"

                Case "SOS_HAVANA_MANDAUE"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MANDAUE"

                Case "SOS_HAVANA_ILOILO"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_ILOILO"

                Case "SOS_HAVANA_CABUGAO"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CABUGAO"

                Case "SOS_HAVANA_PASAY"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_PASAY"

                Case "SOS_HAVANA_CABUYAO"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CABUYAO"

                Case "SOS_HAVANA_TARLAC"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TARLAC"

                Case "SOS_HAVANA_BINANGONAN"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_BINANGONAN"

                Case "SOS_HAVANA_MARIVELES"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MARIVELES"

                Case "SOS_HAVANA_TALISAY"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TALISAY"

                Case "SOS_HAVANA_SILAY"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_SILAY"

                Case "SOS_HAVANA_RODRIGUEZ"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_RODRIGUEZ"

                Case "SOS_HAVANA_VICTORIAS"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_VICTORIAS"

                Case "SOS_HAVANA_TAYTAY"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TAYTAY"

                Case "SOS_HAVANA_CAVITE"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_LCR_CAVITE"


                Case "SOS_HAVANA_BAGO"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_BAGO"

                Case "SOS_HAVANA_CAINTA"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CAINTA"

                Case "SOS_HAVANA_CALBAYOG"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CALBAYOG"

                Case "SOS_HAVANA_LATRINIDAD"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_LATRINIDAD"

                Case "SOS_LCR"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_LCR"

                Case "SOS_HAVANA_EBMAGALONA"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_EBMAGALONA"

                Case "SOS_HAVANA_TAGKAWAYAN"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TAGKAWAYAN"

                Case "SOS_HAVANA_TANAY"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_TANAY"

                Case "SOS_HAVANA_LATRINIDAD"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_LATRINIDAD"

                Case "SOS_HAVANA_CANDON"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_CANDON"

                Case "SOS_HAVANA_MUNTINLUPA"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR_MUNTINLUPA"

                Case "WSP"
                    _mStrCR_ServerName = "HAVANA\MSSQL2019"
                    _mStrCR_ID = "sa"
                    _mStrCR_Pass = "P@ssw0rd"
                    _mStrCR_DBName = "SOS_CR"


            End Select



            _FnGetCRCon = "Data Source=" & _mStrCR_ServerName & _
                            ";Initial Catalog=" & _mStrCR_DBName & _
                            ";User ID=" & _mStrCR_ID & _
                            ";Password=" & _mStrCR_Pass & _
                            ";MultipleActiveResultSets=True"



            Return _FnGetCRCon

        Catch ex As Exception
            _FnGetCRCon = Nothing
        End Try

    End Function

#End Region

End Class
