

'## Collection of Server Machine name and CR Connection Strings
' ## Create by Louie Jay Aviles 
' Created: 20230809

' Last modified: 20230810
Public Class cServer

    Private Shared _mStrCR_ServerName As String
    Private Shared _mStrCR_ID As String
    Private Shared _mStrCR_Pass As String
    Private Shared _mStrCR_DBName As String

#Region "MACHINE NAME"

    Public Shared ReadOnly Property MachineName_HAVANA As String
        Get
            Return "HAVANA"
        End Get
    End Property

    'BISLIG

    'CAVITE NEW
    Public Shared ReadOnly Property MachineName_HVHOST01 As String ' @ADDED 20231108 LOUIE
        Get
            Return "HVHOST01"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_HVHOST01_lgucavitecity_gov As String ' @ADDED 20231108 LOUIE
        Get
            Return "HVHOST01.lgucavitecity.gov"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_SPIDC_CGSJWeb As String ' @ADDED 20231016 LOUIE
        Get
            Return "SPIDC-CGSJWEB"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_CONSOLACIONWEB As String ' @ADDED 20230928 LOUIE
        Get
            Return "CONSOLACIONWEB"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_CABUYAOSVR5 As String ' @ADDED 20230928 LOUIE
        Get
            Return "CABUYAOSVR5"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_SJWEBSVR As String ' @ADDED 20230925 LOUIE
        Get
            Return "SJWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_CANDONWSP As String ' @ADDED 20230921 LOUIE
        Get
            Return "CANDONWSP"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_CANDONWSP_candoncity_gov As String ' @ADDED 20230921 LOUIE
        Get
            Return "CANDONWSP.candoncity.gov"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_PASAYWEBSVR As String
        Get
            Return "PASAYWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_WAPP01 As String
        Get
            Return "WAPP01"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_WEBAPP As String
        Get
            Return "WEBAPP"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_WAPP01_lgucavitecity_gov As String
        Get
            Return "WAPP01.lgucavitecity.gov"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_SANJUANWEBSVR As String
        Get
            Return "SANJUANWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_TARLACWEBSVR As String
        Get
            Return "TARLACWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_MANDAUEWEBSVR As String
        Get
            Return "MANDAUEWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_MANDAUESVR As String
        Get
            Return "MANDAUESVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_MRVLSWEBSVR As String
        Get
            Return "MRVLSWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_MANOLOWEBSVR As String
        Get
            Return "MANOLOWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_TALISAYWEBSVR As String
        Get
            Return "TALISAYWEBSVR"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_WEBSVRCALOOCAN As String
        Get
            Return "WEBSVRCALOOCAN"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_HELSINKI As String
        Get
            Return "HELSINKI"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_GRACEVILLE As String
        Get
            Return "GRACEVILLE"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_MUNTI_SVR17 As String
        Get
            Return "MUNTI-SVR17"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_LENOVOWIN2016 As String
        Get
            Return "LENOVOWIN2016"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_TAYTAYWEBSVR As String
        Get
            Return "TAYTAYWEBSVR"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_MARAMAGWEBSVR As String
        Get
            Return "MARAMAGWEBSVR"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_TKQ_WEBSERVER As String
        Get
            Return "TKQ_WEBSERVER"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_RODRIGUEZWEBSVR As String
        Get
            Return "RODRIGUEZWEBSVR"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_CAINTAWEBSVR As String
        Get
            Return "CAINTAWEBSVR"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_BIZPORTAL As String
        Get
            Return "BIZPORTAL"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_BAGOWEBSERVER As String
        Get
            Return "BAGOWEBSERVER"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_BISLIGWEBSVR As String
        Get
            Return "BISLIGWEBSVR"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_WEBSVR As String
        Get
            Return "WEBSVR"
        End Get
    End Property
    Public Shared ReadOnly Property MachineName_WEBSERVER2023 As String
        Get
            Return "WEBSERVER2023"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_WEBSERVER As String  'CSJDM 
        Get
            Return "WEBSERVER"
        End Get
    End Property

    Public Shared ReadOnly Property MachineName_WEBSERVER_FullName As String  'CSJDM 
        Get
            Return "WEBSERVER.CSJDM.BPLO"
        End Get
    End Property

#End Region

#Region "CR Connection String  HAVANA"


   

    Public Shared ReadOnly Property ConStr_HAVANA As String
        Get

            '_mStrCR_ServerName = "HAVANA\MSSQL2019"
            '_mStrCR_ID = "sa"
            '_mStrCR_Pass = "P@ssw0rd"
            '_mStrCR_DBName = "SOS_CR_CALOOCAN_20230504"

            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CALOOCAN_20231018" '"SOS_CR_CALOOCAN_20230928"

            Return _FnGetConStr()

        End Get
    End Property


    Public Shared ReadOnly Property ConStr_HAVANA_PASAY As String
        Get

            '_mStrCR_ServerName = "HAVANA\MSSQL2019"
            '_mStrCR_ID = "sa"
            '_mStrCR_Pass = "P@ssw0rd"
            '_mStrCR_DBName = "SOS_CR_CALOOCAN_20230504"

            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_PASAY"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MUNTINLUPA As String '@20231005
        Get

            '_mStrCR_ServerName = "HAVANA\MSSQL2019"
            '_mStrCR_ID = "sa"
            '_mStrCR_Pass = "P@ssw0rd"
            '_mStrCR_DBName = "SOS_CR_CALOOCAN_20230504"

            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MUNTINLUPA"

            Return _FnGetConStr()

        End Get
    End Property


    Public Shared ReadOnly Property ConStr_CAINTA As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CAINTA" '@Modified 20230929
            '_mStrCR_DBName = "SOS_CR_CAINTA"

            Return _FnGetConStr()

        End Get
    End Property


    Public Shared ReadOnly Property ConStr_HAVANA_LCR As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_LCR"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_FAMS As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_FAMS"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_CANDON As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CANDON"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_CALOOCAN As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CALOOCAN_2021"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_CSJDM As String
        Get




            '_mStrCR_ServerName = "HAVANA\MSSQL2019"
            '_mStrCR_ID = "sa"
            '_mStrCR_Pass = "P@ssw0rd"
            '_mStrCR_DBName = "SOS_CR_SJDM"

            Return cServerConnection._GetFromENV_File

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_MANDAUE As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MANDAUE"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_ILOILO As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_ILOILO"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_TARLAC As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_TARLAC"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_BINANGONAN As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_BINANGONAN"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_MARIVELES As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MARIVELES"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_TALISAY As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_TALISAY"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_SILAY As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_SILAY"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_RODRIGUEZ As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_RODRIGUEZ"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_VICTORIAS As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_VICTORIAS"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_TAYTAY As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_TAYTAY"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_CAVITE As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CAVITE"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HAVANA_BAGO As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_BAGO"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property _SvrCAVITE As String
        Get
            _mStrCR_ServerName = "HAVANA\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_BAGO"

            Return _FnGetConStr()

        End Get
    End Property


#End Region

#Region "CR Connection String "

    'CAVITE WS NEW
    Public Shared ReadOnly Property ConStr_HVHOST01 As String '@ ADDED 20231016
        Get

            _mStrCR_ServerName = "HVHOST01\MSSQL2019"
            _mStrCR_ID = "spidcweb"
            _mStrCR_Pass = "cavite@c1tyadmin"
            _mStrCR_DBName = "SOS_CR_CAVITECITY"
            Return _FnGetConStr()


        End Get
    End Property

    Public Shared ReadOnly Property ConStr_SPIDC_CGSJWeb As String '@ ADDED 20231016
        Get
            _mStrCR_ServerName = "161.49.182.138\SJWEBSERVICES"
            _mStrCR_ID = "sjweb"
            _mStrCR_Pass = "g~D7XeW3"
            _mStrCR_DBName = "SOS_CR_SANJUAN"
            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_CONSOLACIONWEB As String '@ ADDED 20230928
        Get
            _mStrCR_ServerName = "CONSOLACIONWEB\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CONSOLACION"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_CABUYAOSVR5 As String '@ ADDED 20230928
        Get
            _mStrCR_ServerName = "CABUYAOSVR5\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CABUYAO"
            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_SJWEBSVR As String '@ ADDED 20230925
        Get
            _mStrCR_ServerName = "SJWEBSVR\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_SANJUAN"
            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_CANDONWSP As String '@ ADDED 20230921
        Get
            _mStrCR_ServerName = "CANDONWSP"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CANDON"
            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_MARIVELESWEBSVR_LIVE As String
        Get
            _mStrCR_ServerName = "MRVLSWEBSVR\MARIVELESWEBSVR"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MARIVELES"
            Return _FnGetConStr()

        End Get
    End Property


    Public Shared ReadOnly Property ConStr_MARIVELESWEBSVR_DUMMY As String
        Get
            _mStrCR_ServerName = "MRVLSWEBSVR\MARIVELESWEBSVR"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MARIVELES_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_PASAYWEBSVR As String
        Get
            _mStrCR_ServerName = "PASAYWEBSVR\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_PASAY"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_WAPP01 As String
        Get
            _mStrCR_ServerName = "WAPP01\MSSQL2019"
            _mStrCR_ID = "spidcweb"
            _mStrCR_Pass = "#P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"
            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_WEBAPP As String
        Get
            _mStrCR_ServerName = "WEBAPP\MSSQLSERVER2019"
            _mStrCR_ID = "spidcweb"
            _mStrCR_Pass = "#P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_WEBAPP_LCR As String
        Get
            _mStrCR_ServerName = "WEBAPP\MSSQLSERVER2019"
            _mStrCR_ID = "spidcweb"
            _mStrCR_Pass = "#P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_LCR"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_WEBAPP_FAMS As String
        Get
            _mStrCR_ServerName = "WEBAPP\MSSQLSERVER2019"
            _mStrCR_ID = "spidcweb"
            _mStrCR_Pass = "#P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_FAMS"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_MANOLOWEBSVR_LIVE As String
        Get
            _mStrCR_DBName = "SOS_CR_MANOLO"
            _mStrCR_ServerName = "MANOLOWEBSVR\GAS"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "#P@ssw0rd#"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MANOLOWEBSVR_DUMMY As String
        Get
            _mStrCR_DBName = "SOS_CR_MANOLO_DUMMY"
            _mStrCR_ServerName = "MANOLOWEBSVR\GAS"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "#P@ssw0rd#"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_WEBSVRCALOOCAN_LIVE As String
        Get
            _mStrCR_ServerName = "WEBSVRCALOOCAN\MSSQL2014"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CALOOCAN"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_WEBSVRCALOOCAN_DUMMY As String
        Get
            _mStrCR_ServerName = "WEBSVRCALOOCAN\MSSQL2014"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_CALOOCAN_WEB_TEST"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_GRACEVILLE As String
        Get
            _mStrCR_ServerName = "GRACEVILLE\WEBSVR"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_SJDM"


            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_GRACEVILLE_LIVE As String
        Get
            _mStrCR_ServerName = "GRACEVILLE\WEBSVR"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_SJDM"


            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_CSJDMWEBSERVER As String
        Get
            _mStrCR_ServerName = "WEBSERVER"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"


            Return _FnGetConStr()

        End Get
    End Property


    Public Shared ReadOnly Property ConStr_GRACEVILLE_DUMMY As String
        Get
            _mStrCR_ServerName = "GRACEVILLE\WEBSVR"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_TARLACWEBSVR As String
        Get
            _mStrCR_ServerName = "TARLACWEBSVR\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_TARLAC"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_SANJUANWEBSVR As String
        Get
            _mStrCR_ServerName = "WIN-N57IJISA71G\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MANDAUEWEBSVR_LIVE As String
        Get
            _mStrCR_ServerName = "MANDAUEWEBSVR\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_LIVE"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MANDAUESVR As String
        Get
            _mStrCR_ServerName = "MANDAUESVR\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_LIVE"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MANDAUEWEBSVR_DUMMY As String
        Get
            _mStrCR_ServerName = "MANDAUEWEBSVR\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"
            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MARILAO_LIVE As String
        Get
            _mStrCR_ServerName = "WEBSERVER\WEBSERVER"
            _mStrCR_ID = "iisadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MARILAO"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_HELSINKI As String
        Get
            _mStrCR_ServerName = "HELSINKI"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property


    Public Shared ReadOnly Property ConStr_HELSINKI_DUMMY As String
        Get
            _mStrCR_ServerName = "HELSINKI"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_MUNTI_SVR17 As String
        Get
            _mStrCR_ServerName = "MUNTI-SVR17"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_LENOVOWIN2016 As String
        Get
            _mStrCR_ServerName = "LENOVOWIN2016"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_ILOILO"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_TAYTAYWEBSVR_DUMMY As String
        Get
            _mStrCR_ServerName = "TAYTAYWEBSVR\MSSQL2014"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "misP@ssw0rd"
            _mStrCR_DBName = "SOS_CR_TAYTAY_TEST"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_TAYTAYWEBSVR As String
        Get
            _mStrCR_ServerName = "TAYTAYWEBSVR\MSSQL2019"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_TAYTAY"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MARAMAGWEBSVR As String
        Get
            _mStrCR_ServerName = "MARAMAGWEBSVR\WSP"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MARAMAG"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_MARAMAGWEBSVR_LIVE As String
        Get
            _mStrCR_ServerName = "MARAMAGWEBSVR\WSP"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_MARAMAG"

            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_MARAMAGWEBSVR_DUMMY As String
        Get
            _mStrCR_ServerName = "MARAMAGWEBSVR\WSP"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_TKQ_WEBSERVER As String
        Get
            _mStrCR_ServerName = "TKQ_WEBSERVER\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_TKQ_WEBSERVER_DUMMY As String
        Get
            _mStrCR_ServerName = "TKQWEBSERVER\WEB"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_RODRIGUEZWEBSVR As String
        Get
            _mStrCR_ServerName = "RODRIGUEZWEBSVR\MSSQLSERVER01"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_RODRIGUEZWEBSVR_DUMMY As String
        Get
            _mStrCR_ServerName = "RODRIGUEZWEBSVR\MSSQLSERVER01"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_DUMMY"
            Return _FnGetConStr()

        End Get
    End Property

    Public Shared ReadOnly Property ConStr_CAINTAWEBSVR As String
        Get
            _mStrCR_ServerName = "CAINTAWEBSVR\mssql2019"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"
            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_BIZPORTAL As String
        Get
            _mStrCR_ServerName = "BIZPORTAL\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_SILAY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_BIZPORTAL_DUMMY As String
        Get
            _mStrCR_ServerName = "BIZPORTAL\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_SILAY_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_BAGOWEBSERVER As String
        Get
            _mStrCR_ServerName = "BAGOWEBSERVER\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_BAGO"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_BAGOWEBSERVER_DUMMY As String
        Get
            _mStrCR_ServerName = "CTOWEBSERVER\MSSQLSERVER02"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_BAGO_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_BISLIGWEBSVR As String
        Get
            _mStrCR_ServerName = "BISLIGWEBSVR\MSSQL2019"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "#P@ssw0rd#"
            _mStrCR_DBName = "SOS_CR_BISLIG"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_BISLIGWEBSVR_DUMMY As String
        Get
            _mStrCR_ServerName = "BISLIGWEBSVR\MSSQL2019"
            _mStrCR_ID = "webadmin"
            _mStrCR_Pass = "#P@ssw0rd#"
            _mStrCR_DBName = "SOS_CR_BISLIG_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_TANAY As String
        Get
            _mStrCR_ServerName = "WEBSVR"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_TANAY_DUMMY As String
        Get
            _mStrCR_ServerName = "WSP\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_DUMMY"

            Return _FnGetConStr()

        End Get
    End Property
    Public Shared ReadOnly Property ConStr_VICTORIAS As String
        Get
            _mStrCR_ServerName = "WEBSERVER2023\MSSQL2019"
            _mStrCR_ID = "sa"
            _mStrCR_Pass = "P@ssw0rd"
            _mStrCR_DBName = "SOS_CR_VICTORIAS"

            Return _FnGetConStr()

        End Get
    End Property

#End Region
    Public Shared Function _FnGetConStr() As String
        Try
            _FnGetConStr = Nothing

            _FnGetConStr = "Data Source=" & _mStrCR_ServerName & _
                            ";Initial Catalog=" & _mStrCR_DBName & _
                            ";User ID=" & _mStrCR_ID & _
                            ";Password=" & _mStrCR_Pass & _
                            ";MultipleActiveResultSets=True"

            Return _FnGetConStr

        Catch ex As Exception
            _FnGetConStr = Nothing
        End Try

    End Function

End Class
