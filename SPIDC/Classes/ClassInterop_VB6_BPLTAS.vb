

#Region "Imports"

Imports VS2014.CL.BPLTIMS.Resources
Imports System.Data.SqlClient
Imports VS2014.CL.CR.cEventLog
Imports System.Reflection.MethodBase
Imports cGlobalConnections
Imports cBllGridView
Imports cRegisterScript
'Imports BPLTAS_ONLINE
'Imports BPLTAS_BILLING_ONLINE
'Imports BPLTAS_ONLINE


#End Region

Public Class ClassInterop_VB6_BPLTAS


    Public Sub _pSubBillAccount(ByRef _xResult As Boolean, ByRef xLiteral As Literal)

        Try
            '----------------------------------
            'This Routine uses ClassPageSession_pBilling
            Dim xDLLDate As String = Nothing
            '----------------------------------
            'Parse Connection String.
            Dim _nCsBPLTASLIVE As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_BPLTAS) 'added by renz

            Dim _nCsRegistration As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_OAIMS)

            Dim _nCsBPLTAS As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_BPLTAS)

            Dim _nCsBPLTASDOC As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_BPLTAS_D)



            '----------------------------------
            'Processing here.
            ''Dim _nClass As New ClssBilling
            ''_nClass = New ClssBilling

            ''_nClass.BPLTAS_SERVER = _nCsBPLTAS.DataSource
            ''_nClass.BPLTAS_xDataBase = _nCsBPLTAS.InitialCatalog
            ''_nClass.BPLTAS_xUID = _nCsBPLTAS.UserID
            ''_nClass.BPLTAS_xPW = _nCsBPLTAS.Password

            ''_nClass.BPLTASDOC_xDataBase = _nCsBPLTASDOC.InitialCatalog

            ''_nClass.BPLTAS_Online_Server = _nCsRegistration.DataSource
            ''_nClass.BPLTAS_Online_xDataBase = _nCsRegistration.InitialCatalog
            ''_nClass.BPLTAS_Online_xUID = _nCsRegistration.UserID
            ''_nClass.BPLTAS_Online_xPW = _nCsRegistration.Password

            ''_nClass.UserEmailAddress = ClassPageSession_pBilling._pUserId
            ''_nClass.LocGovUnit = ClassPageSession_pBilling._pLocGovUnit
            ''_nClass.BPLTAS_xAcctNo = ClassPageSession_pBilling._pBusinessAccountNumber
            ''_nClass.BPLTAS_xQtrToPay = ClassPageSession_pBilling._pQuarterToPay
            ''_nClass.BPLTAS_xCombo2 = ClassPageSession_pBilling._pTransactionType

            '''Processing
            ''_nClass.pSubProcessBilling()

            ''ClassPageSession_pBilling._pTotalTaxDue = _nClass.pTotalTaxDue
            ''ClassPageSession_pBilling._pTotalPenalty = _nClass.pTotalPenalty
            ''ClassPageSession_pBilling._pTotalExcessCredit = _nClass.pTotalExcessCredit
            ''ClassPageSession_pBilling._pTotalTaxCredit = _nClass.pTotalTaxCredit
            ''ClassPageSession_pBilling._pTotalAmountDue = _nClass.pTotalDue

            ''ClassPageSession_pBilling._pResultGrossReceiptIsNeeded = _nClass.pGrossReceiptIsNeeded
            ''ClassPageSession_pBilling._pResultTransactionDidNotProceed = _nClass.pTransactionDidNotProceed
            ''ClassPageSession_pBilling._pResultAccountCleared = _nClass.pAccountCleared
            ''ClassPageSession_pBilling._pResultTransactionPaid = _nClass.pTransactionPaid

            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
               
                Dim _nClssBPLTAS As New BPLTAS_BILLING_ONLINE.clssBilling
                Dim x As String = Nothing


                _nClssBPLTAS.CR_xSERVER = cGlobalConnections._pStrCR_ServerName
                _nClssBPLTAS.CR_xUID = cGlobalConnections._pStrCR_ID
                _nClssBPLTAS.CR_xPW = cGlobalConnections._pStrCR_Pass
                _nClssBPLTAS.CR_xDataBase = cGlobalConnections._pStrCR_DBName

                'Dim _nCl As New cDalGlobalConnectionsDefault
                '_nCl._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nCl._pSetupGlobalConnectionsDatabases = "OAIMS"
                '_nCl._pSubRecordSelectSpecific()


                '--------------------------------------------
                'Get Dll Date Complied 
                Dim _nDateCompiled As String = Nothing
                _nDateCompiled = "" '_nClssBPLTAS.pDateCompiled
                '   ._pDateCompiled = _nDateCompiled
                '--------------------------------------------

                '_nClssBPLTAS.BPLTAS_Online_Server = _nCl._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_Online_xUID = _nCl._pDBUserID
                '_nClssBPLTAS.BPLTAS_Online_xPW = _nCl._pDBUserKey
                '_nClssBPLTAS.BPLTAS_Online_xDataBase = _nCl._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_OAIMS.Database.ToString ''"R&D.OAIMS"

                '''TOIMS
                ''Dim _nClTOIMS As New cDalGlobalConnectionsDefault
                ''_nClTOIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                ''_nClTOIMS._pSetupGlobalConnectionsDatabases = "TOIMS"
                ''_nClTOIMS._pSubRecordSelectSpecific()
                ''_nClssBPLTAS.BPLTASTOIMS_xDataBase = _nClTOIMS._pDBInitialCatalog '"R&D.TOIMS"

                ''BPLTIMS
                'Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                '_nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                '_nClBPLTIMS._pSubRecordSelectSpecific()

                '_nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"


                'DOC TRACK
                'Dim _nClDOC As New cDalGlobalConnectionsDefault
                '_nClDOC._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClDOC._pSetupGlobalConnectionsDatabases = "BPLTAS_D"
                '_nClDOC._pSubRecordSelectSpecific()
                '_nClssBPLTAS.BPLTASDOC_xDataBase = _nClDOC._pDBInitialCatalog


                ''BPLTAS LIVE
                'Dim _nClBP As New cDalGlobalConnectionsDefault
                '_nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                '_nClBP._pSubRecordSelectSpecific()

                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"


                ' "128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xAcctNo = ClassPageSession_pBilling._pBusinessAccountNumber
                '_nClssBPLTAS.BPLTASFILE_xDataBase = "BPLTASFILE"
                _nClssBPLTAS.BPLTAS_xQtrToPay = ClassPageSession_pBilling._pQuarterToPay
                _nClssBPLTAS.BPLTAS_xCombo2 = ClassPageSession_pBilling._pTransactionType

                _nClssBPLTAS.pSubProcessBilling()
                _xResult = True
            End With

            '----------------------------------
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            _xResult = False
        End Try


    End Sub

    Public Sub _pSubGenerateTOP(ByRef _xResult As Boolean)


        Try
            '----------------------------------
            'This Routine uses ClassPageSession_pBilling
            Dim xDLLDate As String = Nothing
            '----------------------------------
            'Parse Connection String.
            Dim _nCsBPLTASLIVE As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_BPLTAS) 'added by renz
            '_pSubEventLog("Connection String: BPLTAS LIVE" & cGlobalConnections._pStrCxn_BPLTAS)
            Dim _nCsRegistration As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_OAIMS)
            '_pSubEventLog("Connection String: OAIMS" & cGlobalConnections._pStrCxn_OAIMS)
            Dim _nCsBPLTAS As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_BPLTAS)
            '_pSubEventLog("Connection String: BPLTAS" & cGlobalConnections._pStrCxn_BPLTAS)
            Dim _nCsBPLTASDOC As New SqlConnectionStringBuilder(cGlobalConnections._pStrCxn_BPLTAS_D)
            '_pSubEventLog("Connection String: BPLTAS DOC" & cGlobalConnections._pStrCxn_BPLTAS_D)


            '----------------------------------
            'Processing here.
            ''Dim _nClass As New ClssBilling
            ''_nClass = New ClssBilling

            ''_nClass.BPLTAS_SERVER = _nCsBPLTAS.DataSource
            ''_nClass.BPLTAS_xDataBase = _nCsBPLTAS.InitialCatalog
            ''_nClass.BPLTAS_xUID = _nCsBPLTAS.UserID
            ''_nClass.BPLTAS_xPW = _nCsBPLTAS.Password

            ''_nClass.BPLTASDOC_xDataBase = _nCsBPLTASDOC.InitialCatalog

            ''_nClass.BPLTAS_Online_Server = _nCsRegistration.DataSource
            ''_nClass.BPLTAS_Online_xDataBase = _nCsRegistration.InitialCatalog
            ''_nClass.BPLTAS_Online_xUID = _nCsRegistration.UserID
            ''_nClass.BPLTAS_Online_xPW = _nCsRegistration.Password

            ''_nClass.UserEmailAddress = ClassPageSession_pBilling._pUserId
            ''_nClass.LocGovUnit = ClassPageSession_pBilling._pLocGovUnit
            ''_nClass.BPLTAS_xAcctNo = ClassPageSession_pBilling._pBusinessAccountNumber
            ''_nClass.BPLTAS_xQtrToPay = ClassPageSession_pBilling._pQuarterToPay
            ''_nClass.BPLTAS_xCombo2 = ClassPageSession_pBilling._pTransactionType

            '''Processing
            ''_nClass.pSubProcessBilling()

            ''ClassPageSession_pBilling._pTotalTaxDue = _nClass.pTotalTaxDue
            ''ClassPageSession_pBilling._pTotalPenalty = _nClass.pTotalPenalty
            ''ClassPageSession_pBilling._pTotalExcessCredit = _nClass.pTotalExcessCredit
            ''ClassPageSession_pBilling._pTotalTaxCredit = _nClass.pTotalTaxCredit
            ''ClassPageSession_pBilling._pTotalAmountDue = _nClass.pTotalDue

            ''ClassPageSession_pBilling._pResultGrossReceiptIsNeeded = _nClass.pGrossReceiptIsNeeded
            ''ClassPageSession_pBilling._pResultTransactionDidNotProceed = _nClass.pTransactionDidNotProceed
            ''ClassPageSession_pBilling._pResultAccountCleared = _nClass.pAccountCleared
            ''ClassPageSession_pBilling._pResultTransactionPaid = _nClass.pTransactionPaid

            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


                Dim _nClssBPLTAS As New BPLTAS_BILLING_ONLINE.clssBilling
                Dim x As String = Nothing
                Debug.Print("BPLTAS_BILLING_ONLINE.clssBilling")

                _nClssBPLTAS.CR_xSERVER = cGlobalConnections._pStrCR_ServerName
                Debug.Print("_nClssBPLTAS.CR_xSERVER  " & cGlobalConnections._pStrCR_ServerName)
                _nClssBPLTAS.CR_xUID = cGlobalConnections._pStrCR_ID
                Debug.Print(" _nClssBPLTAS.CR_xUID " & cGlobalConnections._pStrCR_ID)
                _nClssBPLTAS.CR_xPW = cGlobalConnections._pStrCR_Pass
                Debug.Print("_nClssBPLTAS.CR_xPW " & cGlobalConnections._pStrCR_Pass)
                _nClssBPLTAS.CR_xDataBase = cGlobalConnections._pStrCR_DBName
                Debug.Print("_nClssBPLTAS.CR_xDataBase" & cGlobalConnections._pStrCR_DBName)

                'Dim _nCl As New cDalGlobalConnectionsDefault
                '_nCl._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nCl._pSetupGlobalConnectionsDatabases = "OAIMS"
                '_nCl._pSubRecordSelectSpecific()


                '--------------------------------------------
                'Get Dll Date Complied 
                Dim _nDateCompiled As String = Nothing
                _nDateCompiled = "" '_nClssBPLTAS.pDateCompiled
                '_pDateCompiled = _nDateCompiled
                '--------------------------------------------

                '_nClssBPLTAS.BPLTAS_Online_Server = _nCl._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_Online_xUID = _nCl._pDBUserID
                '_nClssBPLTAS.BPLTAS_Online_xPW = _nCl._pDBUserKey
                '_nClssBPLTAS.BPLTAS_Online_xDataBase = _nCl._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_OAIMS.Database.ToString ''"R&D.OAIMS"

                '''TOIMS
                ''Dim _nClTOIMS As New cDalGlobalConnectionsDefault
                ''_nClTOIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                ''_nClTOIMS._pSetupGlobalConnectionsDatabases = "TOIMS"
                ''_nClTOIMS._pSubRecordSelectSpecific()
                ''_nClssBPLTAS.BPLTASTOIMS_xDataBase = _nClTOIMS._pDBInitialCatalog '"R&D.TOIMS"

                ''BPLTIMS
                'Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                '_nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                '_nClBPLTIMS._pSubRecordSelectSpecific()

                '_nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"


                'DOC TRACK
                'Dim _nClDOC As New cDalGlobalConnectionsDefault
                '_nClDOC._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClDOC._pSetupGlobalConnectionsDatabases = "BPLTAS_D"
                '_nClDOC._pSubRecordSelectSpecific()
                '_nClssBPLTAS.BPLTASDOC_xDataBase = _nClDOC._pDBInitialCatalog


                ''BPLTAS LIVE
                'Dim _nClBP As New cDalGlobalConnectionsDefault
                '_nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                '_nClBP._pSubRecordSelectSpecific()

                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"


                ' "128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xAcctNo = ClassPageSession_pBilling._pBusinessAccountNumber
                Debug.Print(" _nClssBPLTAS.BPLTAS_xAcctNo " & ClassPageSession_pBilling._pBusinessAccountNumber)
                '_nClssBPLTAS.BPLTASFILE_xDataBase = "BPLTASFILE"
                _nClssBPLTAS.BPLTAS_xQtrToPay = ClassPageSession_pBilling._pQuarterToPay
                Debug.Print("_nClssBPLTAS.BPLTAS_xQtrToPay " & ClassPageSession_pBilling._pQuarterToPay)
                _nClssBPLTAS.BPLTAS_xCombo2 = ClassPageSession_pBilling._pTransactionType
                Debug.Print(" _nClssBPLTAS.BPLTAS_xCombo2 " & ClassPageSession_pBilling._pTransactionType)

                _nClssBPLTAS.pSubProcessBilling()
                Debug.Print(" _nClssBPLTAS.pSubProcessBilling()")
                _xResult = True
                Debug.Print(" _xResult = True")
            End With

            '----------------------------------
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            _xResult = False
        End Try


    End Sub

End Class
