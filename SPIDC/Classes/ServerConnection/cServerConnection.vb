
'## Connection string routine
' ## Create by Louie Jay Aviles 
' Created: 20230809

' Last modified: 20230810

Imports System.IO
Public Class cServerConnection

    Private Shared _mStrCR_ServerName As String
    Private Shared _mStrCR_ID As String
    Private Shared _mStrCR_Pass As String
    Private Shared _mStrCR_DBName As String

    Public Shared Function _GetFromENV_File() As String
        _GetFromENV_File = ""
        Try

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

                Return "Data Source=" & _mStrCR_ServerName & _
                   ";Initial Catalog=" & _mStrCR_DBName & _
                   ";User ID=" & _mStrCR_ID & _
                   ";Password=" & _mStrCR_Pass & _
                   ";MultipleActiveResultSets=True"
            Else
                Return ""

            End If

        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Shared Function _SQLConnectionString(_nMachineName As String) As String

        _SQLConnectionString = Nothing
        Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri
        Select Case _nMachineName
            Case cServer.MachineName_HAVANA

                Return _HavanaCR()

            Case cServer.MachineName_HVHOST01 ' CAVITE NEW  @ADDED 20231109 LOUIE
                Return cServer.ConStr_HVHOST01

            Case cServer.MachineName_SPIDC_CGSJWeb ' SAN JUAN @ADDED 20230928 LOUIE
                Dim SQLCon As String = _GetFromENV_File()
                If SQLCon <> "" Then
                    Return SQLCon
                Else

                    Return cServer.ConStr_SPIDC_CGSJWeb
                End If


            Case cServer.MachineName_CONSOLACIONWEB ' CONSOLACION @ADDED 20230928 LOUIE
                Return cServer.ConStr_CONSOLACIONWEB

            Case cServer.MachineName_CABUYAOSVR5 ' CABUYAO @ADDED 20230928 LOUIE
                Return cServer.ConStr_CABUYAOSVR5

                'Case cServer.MachineName_SJWEBSVR ' SANJUAN @ADDED 20230921 LOUIE
                '    Return cServer.ConStr_SJWEBSVR
            Case cServer.MachineName_CANDONWSP, cServer.MachineName_CANDONWSP_candoncity_gov ' CANDON @ADDED 20230921 LOUIE
                Return cServer.ConStr_CANDONWSP


            Case cServer.MachineName_TARLACWEBSVR ' TARLAC
                Return cServer.ConStr_TARLACWEBSVR

                ' return _FnGetCRCon("SOS_HAVANA_CAINTA")

            Case cServer.MachineName_PASAYWEBSVR  ' PASAY
                Return cServer.ConStr_PASAYWEBSVR

            Case cServer.MachineName_WAPP01 ' CAVITE
                Return cServer.ConStr_WAPP01

            Case cServer.MachineName_WEBAPP  ' CAVITE

                Select Case True
                    Case curr_url.ToUpper.Contains(cSystem.LCR) : Return cServer.ConStr_WEBAPP_LCR
                    Case curr_url.ToUpper.Contains(cSystem.FAMS) : Return cServer.ConStr_WEBAPP_FAMS
                    Case Else : Return cServer.ConStr_WEBAPP
                End Select

            Case cServer.MachineName_WAPP01_lgucavitecity_gov ' CAVITE
                Return cServer.ConStr_WAPP01

            Case cServer.MachineName_HELSINKI ' TALISAY
                Return cServer.ConStr_HELSINKI


                'Case cServer.MachineName_SANJUANWEBSVR ' SANJUAN
                '    Return cServer.ConStr_SANJUANWEBSVR

            Case cServer.MachineName_TARLACWEBSVR ' TARLAC
                Return cServer.ConStr_TARLACWEBSVR

            Case cServer.MachineName_MANDAUEWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_MANDAUEWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_MANDAUEWEBSVR_LIVE
                End If

            Case cServer.MachineName_MANDAUESVR 'MANDAUEWEBSV II

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_MANDAUEWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_MANDAUESVR
                End If

            Case cServer.MachineName_MRVLSWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_MARIVELESWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_MARIVELESWEBSVR_LIVE
                End If

            Case cServer.MachineName_MANOLOWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_MANOLOWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_MANOLOWEBSVR_LIVE
                End If

            Case cServer.MachineName_TALISAYWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_HELSINKI_DUMMY
                Else
                    Return cServer.ConStr_HELSINKI
                End If

            Case cServer.MachineName_WEBSVRCALOOCAN

                    If curr_url.ToUpper.Contains("TEST") = True Then
                        Return cServer.ConStr_WEBSVRCALOOCAN_DUMMY
                    Else
                        Return cServer.ConStr_WEBSVRCALOOCAN_LIVE
                End If


            Case cServer.MachineName_GRACEVILLE 'CSJDM

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_GRACEVILLE_DUMMY
                Else
                    Return cServer.ConStr_GRACEVILLE_LIVE
                End If

            Case cServer.MachineName_WEBSERVER, cServer.MachineName_WEBSERVER_FullName 'CSJDM

                Return cServer.ConStr_CSJDMWEBSERVER

            Case cServer.MachineName_MUNTI_SVR17

                Return cServer.ConStr_MUNTI_SVR17

            Case cServer.MachineName_LENOVOWIN2016

                Return cServer.ConStr_LENOVOWIN2016

            Case cServer.MachineName_TAYTAYWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_TAYTAYWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_TAYTAYWEBSVR
                End If

            Case cServer.MachineName_MARAMAGWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_MARAMAGWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_MARAMAGWEBSVR_LIVE
                End If

            Case cServer.MachineName_TKQ_WEBSERVER

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_TKQ_WEBSERVER_DUMMY
                Else
                    Return cServer.ConStr_TKQ_WEBSERVER
                End If

            Case cServer.MachineName_RODRIGUEZWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_RODRIGUEZWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_RODRIGUEZWEBSVR
                End If

            Case cServer.MachineName_CAINTAWEBSVR

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_CAINTAWEBSVR
                Else
                    Return cServer.ConStr_CAINTAWEBSVR
                End If

            Case cServer.MachineName_BIZPORTAL 'SILAY SITY

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_BIZPORTAL_DUMMY
                Else
                    Return cServer.ConStr_BIZPORTAL
                End If

            Case cServer.MachineName_BAGOWEBSERVER 'BAGO CITY

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_BAGOWEBSERVER_DUMMY
                Else
                    Return cServer.ConStr_BAGOWEBSERVER
                End If

            Case cServer.MachineName_BISLIGWEBSVR 'BISLIG CITY

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_BISLIGWEBSVR_DUMMY
                Else
                    Return cServer.ConStr_BISLIGWEBSVR
                End If


            Case cServer.MachineName_WEBSVR 'TANAY

                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_TANAY_DUMMY
                Else
                    Return cServer.ConStr_TANAY
                End If


            Case cServer.MachineName_WEBSERVER2023 'VICTORIAS
                If curr_url.ToUpper.Contains("TEST") = True Then
                    Return cServer.ConStr_VICTORIAS
                Else
                    Return cServer.ConStr_VICTORIAS
                End If

        End Select
    End Function

    Private Shared Function _HavanaCR() As String
        _HavanaCR = Nothing

        Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri


        If curr_url.ToUpper.Contains(cSystem.LCR) = True Then Return cServer.ConStr_HAVANA_LCR
        If curr_url.ToUpper.Contains(cSystem.FAMS) = True Then Return cServer.ConStr_HAVANA_FAMS

        If curr_url.ToUpper.Contains("CALOOCAN") = True Then Return cServer.ConStr_HAVANA
        If curr_url.ToUpper.Contains("PASAY") = True Then Return cServer.ConStr_HAVANA_PASAY
        If curr_url.ToUpper.Contains("CANDON") = True Then Return cServer.ConStr_HAVANA_CANDON
        If curr_url.ToUpper.Contains("CSJDM") = True Then Return cServer.ConStr_HAVANA_CSJDM
        If curr_url.ToUpper.Contains("MANDAUE") = True Then Return cServer.ConStr_HAVANA_MANDAUE
        If curr_url.ToUpper.Contains("ILOILO") = True Then Return cServer.ConStr_HAVANA_ILOILO
        If curr_url.ToUpper.Contains("TARLAC") = True Then Return cServer.ConStr_HAVANA_TARLAC
        If curr_url.ToUpper.Contains("BINANGONAN") = True Then Return cServer.ConStr_HAVANA_BINANGONAN
        If curr_url.ToUpper.Contains("MARIVELES") = True Then Return cServer.ConStr_HAVANA_MARIVELES
        If curr_url.ToUpper.Contains("TALISAY") = True Then Return cServer.ConStr_HAVANA_TALISAY
        If curr_url.ToUpper.Contains("SILAY") = True Then Return cServer.ConStr_HAVANA_SILAY
        If curr_url.ToUpper.Contains("RODRIGUEZ") = True Then Return cServer.ConStr_HAVANA_RODRIGUEZ
        If curr_url.ToUpper.Contains("VICTORIAS") = True Then Return cServer.ConStr_HAVANA_VICTORIAS
        If curr_url.ToUpper.Contains("TAYTAY") = True Then Return cServer.ConStr_HAVANA_TAYTAY
        If curr_url.ToUpper.Contains("CAVITE") = True Then Return cServer.ConStr_HAVANA_CAVITE
        If curr_url.ToUpper.Contains("BAGO") = True Then Return cServer.ConStr_HAVANA_BAGO
        If curr_url.ToUpper.Contains("ENGINEERING") = True Then Return cServer.ConStr_HAVANA
        If curr_url.ToUpper.Contains("CAINTA") = True Then Return cServer.ConStr_CAINTA
        If curr_url.ToUpper.Contains("OBO") = True Then Return cServer.ConStr_HAVANA
        If curr_url.ToUpper.Contains("MUNTINLUPA") = True Then Return cServer.ConStr_MUNTINLUPA

    End Function

End Class
