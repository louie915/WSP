Public Class cDBScript


    Public Shared Property IsExist As Boolean



    Public Shared Function DBObject(ByVal xObjectName As String) As String

        Select Case xObjectName
            ' SOS_OAIMS ==============
            Case "Department"
                Return DepartmentCode()
            Case "eOR"
                Return eOR()
            Case "eOR_Extn"
                Return eOR_Extn()
            Case "EOR_Setup"
                Return eOR_Setup()

                ' SOS_BP =================
            Case "SP_GETACCT" 'SP
                Return SP_GETACCT()
        End Select

    End Function

    Private Shared Function SP_GETACCT() As String
        Dim xAction As String

        If IsExist = False Then
            xAction = "CREATE"
        Else
            xAction = "ALTER"
        End If

        Return "  " &
                            "			" + xAction + " PROCEDURE  [dbo].[SP_GETACCT] 																																																			" & _
"				@ACCTNO NVARCHAR(50),@ORNO NVARCHAR(50),@BP_SERVERDB nvarchar(100),@BP_LOCALDB nvarchar(100),@EMAIL AS NVARCHAR(150),@EMAIL22 AS NVARCHAR(150),																									" & _
"				@STATUS INT OUTPUT, @STATUSDESC NVARCHAR(500) OUTPUT																																															" & _
"																																																																" & _
"				 AS																																																												" & _
"				 BEGIN																																																											" & _
"																																																																" & _
"																																																																" & _
"				 	/**																																																											" & _
"					DECLARE @STATUS INT																																																							" & _
"					exec [sp_GETACCT] '1-00002','0328653','TEXAS\MSSQL2014','BPLTAS_CSJDM_20200310','x@gmail.com',@STATUS OUTPUT																																" & _
"					PRINT @STATUS																																																								" & _
"					**/																																																											" & _
"																																																																" & _
"					DECLARE @Query nvarchar(4000)																																																				" & _
"					DECLARE @SQL nvarchar(4000) 																																																				" & _
"					DECLARE @SACCTNO nvarchar(4000)																																																				" & _
"					DECLARE @SORNO nvarchar(4000)																																																				" & _
"					DECLARE @SORNO1 nvarchar(4000)																																																				" & _
"					DECLARE @SACCTNO2 nvarchar(4000)																																																			" & _
"					DECLARE @EMAIL2 nvarchar(4000)																																																				" & _
"					DECLARE @XCURSOR CURSOR 																																																					" & _
"																																																																" & _
"						SET @QUERY = 'select top 1 ACCTNO,ORNO from ['+@BP_SERVERDB+'].['+@BP_LOCALDB+'].dbo.payfile																																			" & _
"									 where acctno = '''+@ACCTNO+''' AND ORNO = '''+@ORNO+'''																																									" & _
"									 union																																																						" & _
"									 select top 1 ACCTNO,ORNO from ['+@BP_SERVERDB+'].['+@BP_LOCALDB+'].dbo.payfilehistory																																		" & _
"									 where acctno = '''+@ACCTNO+''' AND ORNO = '''+@ORNO+'''																																									" & _
"									'																																																							" & _
"						PRINT @QUERY																																																							" & _
"						SET @SQL = 'set @XCURSOR = cursor static for '+ @Query +';open @XCURSOR '																																								" & _
"						EXEC sp_executesql @SQL,N'@XCURSOR cursor OUTPUT',@XCURSOR OUTPUT																																										" & _
"																																																																" & _
"						FETCH NEXT FROM @XCURSOR 																																																				" & _
"						INTO @SACCTNO,@SORNO;																																																					" & _
"																																																																" & _
"																																																																" & _
"						IF @@FETCH_STATUS <> 0																																																					" & _
"						BEGIN																																																									" & _
"							SET @STATUS = 0 /** NOT IN BUSMAST **/																																																" & _
"																																																																" & _
"								DECLARE @XCURSOR3 CURSOR 																																																		" & _
"																																																																" & _
"								SET @QUERY = 'SELECT ISNULL(ORNO1,'''') as ORNO1  from ['+@BP_SERVERDB+'].['+@BP_LOCALDB+'].dbo.BUSLINE 																														" & _
"											  WHERE ACCTNO = '''+@ACCTNO+''' AND ORNO1 = '''+@ORNO+''' 																																							" & _
"											 '																																																					" & _
"								PRINT @QUERY																																																					" & _
"								SET @SQL = 'set @XCURSOR3 = cursor static for '+ @Query +';open @XCURSOR3 '																																						" & _
"								EXEC sp_executesql @SQL,N'@XCURSOR3 cursor OUTPUT',@XCURSOR3 OUTPUT																																								" & _
"																																																																" & _
"																																																																" & _
"									FETCH NEXT FROM @XCURSOR3 																																																	" & _
"									INTO @SORNO1;																																																				" & _
"																																																																" & _
"									IF @@FETCH_STATUS = 0																																																		" & _
"									BEGIN																																																						" & _
"										PRINT @SORNO1																																																			" & _
"										GOTO NXTNA																																																				" & _
"									END																																																							" & _
"									else																																																						" & _
"										set @STATUSDESC = 'Record not found.'																																													" & _
"																																																																" & _
"																																																																" & _
"								FETCH NEXT FROM @XCURSOR3 INTO @SORNO1;																																															" & _
"																																																																" & _
"								CLOSE @XCURSOR3																																																					" & _
"								DEALLOCATE @XCURSOR3																																																			" & _
"																																																																" & _
"																																																																" & _
"						END																																																										" & _
"																																																																" & _
"																																																																" & _
"						IF @@FETCH_STATUS = 0																																																					" & _
"						BEGIN																																																									" & _
"							/** SET @STATUS = 1 IN PAYFILE **/																																																	" & _
"				NXTNA:																																																											" & _
"																																																																" & _
"								DECLARE @XCURSOR2 CURSOR 																																																		" & _
"																																																																" & _
"								SET @QUERY = 'select top 1 ACCTNO,EMAIL from BUSDETAIL																																											" & _
"											 where acctno = '''+ @ACCTNO +''' '																																													" & _
"								PRINT @QUERY																																																					" & _
"								SET @SQL = 'set @XCURSOR2 = cursor static for '+ @Query +';open @XCURSOR2 '																																						" & _
"								EXEC sp_executesql @SQL,N'@XCURSOR2 cursor OUTPUT',@XCURSOR2 OUTPUT																																								" & _
"																																																																" & _
"								FETCH NEXT FROM @XCURSOR2																																																		" & _
"								INTO @SACCTNO2,@EMAIL2;																																																			" & _
"																																																																" & _
"								IF @@FETCH_STATUS = 0																																																			" & _
"									BEGIN																																																						" & _
"										SET @STATUS = 1 /** ALREADY EXIST **//																																													" & _
"										set @STATUSDESC = 'account already enrolled.'																																											" & _
"									END																																																							" & _
"																																																																" & _
"								IF @@FETCH_STATUS <> 0																																																			" & _
"								BEGIN																																																							" & _
"									SET @STATUS = 2 /** ENROLL **/																																																" & _
"									/**																																																							" & _
"									INSERT INTO ACCTDETAIL(ACCTNO,EMAIL)																																														" & _
"									VALUES(@ACCTNO,@EMAIL)																																																		" & _
"									**/																																																							" & _
"																																																																" & _
"									SET @Query = '																																																				" & _
"									INSERT INTO BUSDETAIL(EMAIL,ACCTNO,OWNER,BUSNAME,BUSADDRESS,CATEGORY,CATEGORY1,VERIFIED, ORNO, REQDATE,EMAIL2)																												" & _
"									SELECT  '''+ @EMAIL +''',ACCTNO,BUSOWNER,BUSNAME,BUSADDRESS,CATEGORY,CATEGORY1, 0 AS VERIFIED, '''+@ORNO+''' AS ORNO, GETDATE() AS REQDATE,'''+ @EMAIL22 +''' FROM ['+@BP_SERVERDB+'].['+@BP_LOCALDB+'].dbo.VW_BUSDETAIL 	" & _
"									WHERE ACCTNO = '''+@ACCTNO+''' '																																															" & _
"									PRINT @Query																																																				" & _
"																																																																" & _
"									BEGIN TRY																																																					" & _
"										begin																																																					" & _
"											EXEC sp_executesql @Query																																															" & _
"											set @STATUSDESC = 'Enrolled'																																														" & _
"										end																																																						" & _
"									END TRY																																																						" & _
"									BEGIN CATCH																																																					" & _
"										set @STATUSDESC = ERROR_MESSAGE()																																														" & _
"										SET @STATUS = -1																																																		" & _
"									END CATCH																																																					" & _
"																																																																" & _
"									print @STATUSDESC																																																			" & _
"																																																																" & _
"								END																																																								" & _
"																																																																" & _
"								FETCH NEXT FROM @XCURSOR2 INTO @SACCTNO2,@EMAIL2;																																												" & _
"																																																																" & _
"								CLOSE @XCURSOR2																																																					" & _
"								DEALLOCATE @XCURSOR2																																																			" & _
"																																																																" & _
"						END																																																										" & _
"																																																																" & _
"																																																																" & _
"																																																																" & _
"						FETCH NEXT FROM @XCURSOR INTO @SACCTNO,@SORNO;																																															" & _
"																																																																" & _
"						CLOSE @XCURSOR																																																							" & _
"						DEALLOCATE @XCURSOR																																																						" & _
"																																																																" & _
"						SELECT @STATUS, @STATUSDESC 																																																			" & _
"					 END																																																										" & _
"			"
    End Function


#Region "OAIMS"
    Private Shared Function DepartmentCode() As String
        Return " " &
                " CREATE TABLE [dbo].[Department]( " &
                " 	[DepartmentCode] [nvarchar](50) NOT NULL, " &
                " 	[Department] [nvarchar](50) NOT NULL, " &
                " 	[Abbrev] [nchar](50) NULL, " &
                " 	[UserType] [nvarchar](50) NULL, " &
                " 	[Regulatory] [bit] NULL " &
                "  ON [PRIMARY] "

    End Function

    Private Shared Function eOR() As String
        Return " " &
                " CREATE TABLE [dbo].[eOR]( " &
                " 	[PayorName] [nvarchar](max) NOT NULL, " &
                " 	[Barangay] [nvarchar](max) NOT NULL, " &
                " 	[TaxType] [nvarchar](max) NOT NULL, " &
                " 	[TDNBIN] [nvarchar](max) NOT NULL, " &
                " 	[PIN] [nvarchar](max) NULL, " &
                " 	[PeriodCovered] [nvarchar](max) NOT NULL, " &
                " 	[AssessNo] [nvarchar](max) NULL, " &
                " 	[eORno] [nvarchar](max) NOT NULL, " &
                " 	[DateTime] [nvarchar](max) NOT NULL, " &
                " 	[OnlineID] [nvarchar](max) NOT NULL, " &
                " 	[Gateway_Selected] [nvarchar](max) NOT NULL, " &
                " 	[Gateway_RefNo] [nvarchar](max) NOT NULL, " &
                " 	[Gateway_ConfDate] [nvarchar](max) NOT NULL, " &
                " 	[Bill_Amount] [money] NULL, " &
                " 	[Gateway_Fee] [money] NULL, " &
                " 	[SPIDC_Fee] [money] NULL, " &
                " 	[GrandTotal] [money] NULL, " &
                " 	[QR_File] [varbinary](max) NULL, " &
                " 	[QR_String] [nvarchar](max) NULL, " &
                " 	[PrevORno] [nvarchar](max) NULL, " &
                " 	[PrevAmountPaid] [nvarchar](max) NULL, " &
                " 	[Sent] [bit] NULL, " &
                " 	[Sent_Date] [datetime] NULL " &
                " ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "

    End Function

    Private Shared Function eOR_Extn() As String

        Return " " &
            " CREATE TABLE [dbo].[eOR_Extn]( " & _
            " 	[eORNO] [nvarchar](max) NULL, " & _
            " 	[ORno] [nvarchar](max) NULL, " & _
            " 	[TDNBIN] [nvarchar](max) NULL, " & _
            " 	[AccountCode] [nvarchar](max) NULL, " & _
            " 	[NatureOfCollection] [nvarchar](max) NULL, " & _
            " 	[Amount] [money] NULL " & _
            " ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "

    End Function

    Private Shared Function eOR_Setup() As String

        Return " " &
            " CREATE TABLE [dbo].[eOR_Setup]( " & _
            " 	[Watermark_File] [varbinary](max) NULL, " & _
            " 	[eSignature_File] [varbinary](max) NULL,  " & _
            " 	[Officer_Name] [nvarchar](max) NULL, " & _
            " 	[Officer_Position] [nvarchar](max) NULL, " & _
            " 	[Header1] [nvarchar](max) NULL, " & _
            " 	[Header2] [nvarchar](max) NULL " & _
            " ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] "

    End Function



#End Region


#Region "VIEWS"

#End Region

#Region "STRORED PROCURE"

#End Region




#Region "SOS_BP STORED PROCEDURES"

#End Region



End Class
