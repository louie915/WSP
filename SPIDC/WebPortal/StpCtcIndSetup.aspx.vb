Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient

Public Class StpCtcIndSetup
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim _nclass As New cDalStpCtcInd
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nclass._pSubSelectDetails()

        If Not IsPostBack Then

            _oTextBox_Address_Left.Text = _nclass._pAddress_Left
            _oTextBox_Address_Top.Text = _nclass._pAddress_Top
            _oTextBox_BasicAmount_Left.Text = _nclass._pBasicAmount_Left
            _oTextBox_BasicAmount_Top.Text = _nclass._pBasicAmount_Top
            _oTextBox_BirthPlace_Left.Text = _nclass._pBirthPlace_Left
            _oTextBox_BirthPlace_Top.Text = _nclass._pBirthPlace_Top
            _oTextBox_BusIncome_Left.Text = _nclass._pBusIncome_Left
            _oTextBox_BusIncome_Top.Text = _nclass._pBusIncome_Top
            _oTextBox_BusIncomeComputation_Left.Text = _nclass._pBusIncomeComputation_Left
            _oTextBox_BusIncomeComputation_Top.Text = _nclass._pBusIncomeComputation_Top
            _oTextBox_Citizenship_Left.Text = _nclass._pCitizenship_Left
            _oTextBox_Citizenship_Top.Text = _nclass._pCitizenship_Top
            _oTextBox_CivilStatus_Left.Text = _nclass._pCivilStatus_Left
            _oTextBox_CivilStatus_Top.Text = _nclass._pCivilStatus_Top
            _oTextBox_DateIssued_Left.Text = _nclass._pDateIssued_Left
            _oTextBox_DateIssued_Top.Text = _nclass._pDateIssued_Top
            _oTextBox_FirstName_Left.Text = _nclass._pFirstName_Left
            _oTextBox_FirstName_Top.Text = _nclass._pFirstName_Top
            _oTextBox_Gender_Left.Text = _nclass._pGender_Left
            _oTextBox_Gender_Top.Text = _nclass._pGender_Top
            _oTextBox_LastName_Left.Text = _nclass._pLastName_Left
            _oTextBox_LastName_Top.Text = _nclass._pLastName_Top
            _oTextBox_LguProfile_Left.Text = _nclass._pLguProfile_Left
            _oTextBox_LguProfile_Top.Text = _nclass._pLguProfile_Top
            _oTextBox_MiddleName_Left.Text = _nclass._pMiddleName_Left
            _oTextBox_MiddleName_Top.Text = _nclass._pMiddleName_Top
            _oTextBox_Occupation_Left.Text = _nclass._pOccupation_Left
            _oTextBox_Occupation_Top.Text = _nclass._pOccupation_Top
            _oTextBox_OrNumber_Left.Text = _nclass._pOrNumber_Left
            _oTextBox_OrNumber_Top.Text = _nclass._pOrNumber_Top
            _oTextBox_Penalty_Left.Text = _nclass._pPenalty_Left
            _oTextBox_Penalty_Top.Text = _nclass._pPenalty_Top
            _oTextBox_ProfIncome_Left.Text = _nclass._pProfIncome_Left
            _oTextBox_ProfIncome_Top.Text = _nclass._pProfIncome_Top
            _oTextBox_ProfIncomeComputation_Left.Text = _nclass._pProfIncomeComputation_Left
            _oTextBox_ProfIncomeComputation_Top.Text = _nclass._pProfIncomeComputation_Top
            _oTextBox_RPTIncome_Left.Text = _nclass._pRPTIncome_Left
            _oTextBox_RPTIncome_Top.Text = _nclass._pRPTIncome_Top
            _oTextBox_RPTIncomeComputation_Top.Text = _nclass._pRPTIncomeComputation_Top
            _oTextBox_RPTIncomeComputation_Left.Text = _nclass._pRPTIncomeComputationLeft
            _oTextBox_SRS_Left.Text = _nclass._pSRS_Left
            _oTextBox_SRS_Top.Text = _nclass._pSRS_Top
            _oTextBox_TaxAmount_Left.Text = _nclass._pTaxAmount_Left
            _oTextBox_TaxAmount_Top.Text = _nclass._pTaxAmount_Top
            _oTextBox_TIN_Left.Text = _nclass._pTIN_Left
            _oTextBox_TIN_Top.Text = _nclass._pTIN_Top
            _oTextBox_TotalAmount_Left.Text = _nclass._pTotalAmount_Left
            _oTextBox_TotalAmount_Top.Text = _nclass._pTotalAmount_Top
            _oTextBox_Year_Left.Text = _nclass._pYear_Left
            _oTextBox_Year_Top.Text = _nclass._pYear_Top

        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim _nclass As New cDalStpCtcInd
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nclass._pSubSelectDetails()

        If Not _nclass._pAddress_Left <> "" Then

            _nclass._pAddress_Left = _oTextBox_Address_Left.Text
            _nclass._pAddress_Top = _oTextBox_Address_Top.Text
            _nclass._pBasicAmount_Left = _oTextBox_BasicAmount_Left.Text
            _nclass._pBasicAmount_Top = _oTextBox_BasicAmount_Top.Text
            _nclass._pBirthPlace_Left = _oTextBox_BirthPlace_Left.Text
            _nclass._pBirthPlace_Top = _oTextBox_BirthPlace_Top.Text
            _nclass._pBusIncome_Left = _oTextBox_BusIncome_Left.Text
            _nclass._pBusIncome_Top = _oTextBox_BusIncome_Top.Text
            _nclass._pBusIncomeComputation_Left = _oTextBox_BusIncomeComputation_Left.Text
            _nclass._pBusIncomeComputation_Top = _oTextBox_BusIncomeComputation_Top.Text
            _nclass._pCitizenship_Left = _oTextBox_Citizenship_Left.Text
            _nclass._pCitizenship_Top = _oTextBox_Citizenship_Top.Text
            _nclass._pCivilStatus_Left = _oTextBox_CivilStatus_Left.Text
            _nclass._pCivilStatus_Top = _oTextBox_CivilStatus_Top.Text
            _nclass._pDateIssued_Left = _oTextBox_DateIssued_Left.Text
            _nclass._pDateIssued_Top = _oTextBox_DateIssued_Top.Text
            _nclass._pFirstName_Left = _oTextBox_FirstName_Left.Text
            _nclass._pFirstName_Top = _oTextBox_FirstName_Top.Text
            _nclass._pGender_Left = _oTextBox_Gender_Left.Text
            _nclass._pGender_Top = _oTextBox_Gender_Top.Text
            _nclass._pLastName_Left = _oTextBox_LastName_Left.Text
            _nclass._pLastName_Top = _oTextBox_LastName_Top.Text
            _nclass._pLguProfile_Left = _oTextBox_LguProfile_Left.Text
            _nclass._pLguProfile_Top = _oTextBox_LguProfile_Top.Text
            _nclass._pMiddleName_Left = _oTextBox_MiddleName_Left.Text
            _nclass._pMiddleName_Top = _oTextBox_MiddleName_Top.Text
            _nclass._pOccupation_Left = _oTextBox_Occupation_Left.Text
            _nclass._pOccupation_Top = _oTextBox_Occupation_Top.Text
            _nclass._pOrNumber_Left = _oTextBox_OrNumber_Left.Text
            _nclass._pOrNumber_Top = _oTextBox_OrNumber_Top.Text
            _nclass._pPenalty_Left = _oTextBox_Penalty_Left.Text
            _nclass._pPenalty_Top = _oTextBox_Penalty_Top.Text
            _nclass._pProfIncome_Left = _oTextBox_ProfIncome_Left.Text
            _nclass._pProfIncome_Top = _oTextBox_ProfIncome_Top.Text
            _nclass._pProfIncomeComputation_Left = _oTextBox_ProfIncomeComputation_Left.Text
            _nclass._pProfIncomeComputation_Top = _oTextBox_ProfIncomeComputation_Top.Text
            _nclass._pRPTIncome_Left = _oTextBox_RPTIncome_Left.Text
            _nclass._pRPTIncome_Top = _oTextBox_RPTIncome_Top.Text
            _nclass._pRPTIncomeComputation_Top = _oTextBox_RPTIncomeComputation_Top.Text
            _nclass._pRPTIncomeComputationLeft = _oTextBox_RPTIncomeComputation_Left.Text
            _nclass._pSRS_Left = _oTextBox_SRS_Left.Text
            _nclass._pSRS_Top = _oTextBox_SRS_Top.Text
            _nclass._pTaxAmount_Left = _oTextBox_TaxAmount_Left.Text
            _nclass._pTaxAmount_Top = _oTextBox_TaxAmount_Top.Text
            _nclass._pTIN_Left = _oTextBox_TIN_Left.Text
            _nclass._pTIN_Top = _oTextBox_TIN_Top.Text
            _nclass._pTotalAmount_Left = _oTextBox_TotalAmount_Left.Text
            _nclass._pTotalAmount_Top = _oTextBox_TotalAmount_Top.Text
            _nclass._pYear_Left = _oTextBox_Year_Left.Text
            _nclass._pYear_Top = _oTextBox_Year_Top.Text

            _nclass._pSubInsert()

        Else
            _nclass._pAddress_Left = _oTextBox_Address_Left.Text
            _nclass._pAddress_Top = _oTextBox_Address_Top.Text
            _nclass._pBasicAmount_Left = _oTextBox_BasicAmount_Left.Text
            _nclass._pBasicAmount_Top = _oTextBox_BasicAmount_Top.Text
            _nclass._pBirthPlace_Left = _oTextBox_BirthPlace_Left.Text
            _nclass._pBirthPlace_Top = _oTextBox_BirthPlace_Top.Text
            _nclass._pBusIncome_Left = _oTextBox_BusIncome_Left.Text
            _nclass._pBusIncome_Top = _oTextBox_BusIncome_Top.Text
            _nclass._pBusIncomeComputation_Left = _oTextBox_BusIncomeComputation_Left.Text
            _nclass._pBusIncomeComputation_Top = _oTextBox_BusIncomeComputation_Top.Text
            _nclass._pCitizenship_Left = _oTextBox_Citizenship_Left.Text
            _nclass._pCitizenship_Top = _oTextBox_Citizenship_Top.Text
            _nclass._pCivilStatus_Left = _oTextBox_CivilStatus_Left.Text
            _nclass._pCivilStatus_Top = _oTextBox_CivilStatus_Top.Text
            _nclass._pDateIssued_Left = _oTextBox_DateIssued_Left.Text
            _nclass._pDateIssued_Top = _oTextBox_DateIssued_Top.Text
            _nclass._pFirstName_Left = _oTextBox_FirstName_Left.Text
            _nclass._pFirstName_Top = _oTextBox_FirstName_Top.Text
            _nclass._pGender_Left = _oTextBox_Gender_Left.Text
            _nclass._pGender_Top = _oTextBox_Gender_Top.Text
            _nclass._pLastName_Left = _oTextBox_LastName_Left.Text
            _nclass._pLastName_Top = _oTextBox_LastName_Top.Text
            _nclass._pLguProfile_Left = _oTextBox_LguProfile_Left.Text
            _nclass._pLguProfile_Top = _oTextBox_LguProfile_Top.Text
            _nclass._pMiddleName_Left = _oTextBox_MiddleName_Left.Text
            _nclass._pMiddleName_Top = _oTextBox_MiddleName_Top.Text
            _nclass._pOccupation_Left = _oTextBox_Occupation_Left.Text
            _nclass._pOccupation_Top = _oTextBox_Occupation_Top.Text
            _nclass._pOrNumber_Left = _oTextBox_OrNumber_Left.Text
            _nclass._pOrNumber_Top = _oTextBox_OrNumber_Top.Text
            _nclass._pPenalty_Left = _oTextBox_Penalty_Left.Text
            _nclass._pPenalty_Top = _oTextBox_Penalty_Top.Text
            _nclass._pProfIncome_Left = _oTextBox_ProfIncome_Left.Text
            _nclass._pProfIncome_Top = _oTextBox_ProfIncome_Top.Text
            _nclass._pProfIncomeComputation_Left = _oTextBox_ProfIncomeComputation_Left.Text
            _nclass._pProfIncomeComputation_Top = _oTextBox_ProfIncomeComputation_Top.Text
            _nclass._pRPTIncome_Left = _oTextBox_RPTIncome_Left.Text
            _nclass._pRPTIncome_Top = _oTextBox_RPTIncome_Top.Text
            _nclass._pRPTIncomeComputation_Top = _oTextBox_RPTIncomeComputation_Top.Text
            _nclass._pRPTIncomeComputationLeft = _oTextBox_RPTIncomeComputation_Left.Text
            _nclass._pSRS_Left = _oTextBox_SRS_Left.Text
            _nclass._pSRS_Top = _oTextBox_SRS_Top.Text
            _nclass._pTaxAmount_Left = _oTextBox_TaxAmount_Left.Text
            _nclass._pTaxAmount_Top = _oTextBox_TaxAmount_Top.Text
            _nclass._pTIN_Left = _oTextBox_TIN_Left.Text
            _nclass._pTIN_Top = _oTextBox_TIN_Top.Text
            _nclass._pTotalAmount_Left = _oTextBox_TotalAmount_Left.Text
            _nclass._pTotalAmount_Top = _oTextBox_TotalAmount_Top.Text
            _nclass._pYear_Left = _oTextBox_Year_Left.Text
            _nclass._pYear_Top = _oTextBox_Year_Top.Text

            _nclass._pSubUpdateStp()
        End If
        CreateSTPCTCIndividual()
    End Sub
    Private Sub CreateSTPCTCIndividual()
        ''==========================================================================================================================================
        Dim rdlcStr As String = ""
        Dim TxtSRSBold As Boolean = False
        Dim TxtSRSTop As String = _oTextBox_SRS_Top.Text & "pt"
        Dim TxtSRSLeft As String = _oTextBox_SRS_Left.Text & "pt"
        Dim TxtOrNumberBold As Boolean = False
        Dim TxtOrNumberTop As String = _oTextBox_OrNumber_Top.Text & "pt"
        Dim TxtOrNumberLeft As String = _oTextBox_OrNumber_Left.Text & "pt"
        Dim TxtYearBold As Boolean = False
        Dim TxtYearTop As String = _oTextBox_Year_Top.Text & "pt"
        Dim TxtYearLeft As String = _oTextBox_Year_Left.Text & "pt"
        Dim TxtLguProfileBold As Boolean = False
        Dim TxtLguProfileTop As String = _oTextBox_LguProfile_Top.Text & "pt"
        Dim TxtLguProfileLeft As String = _oTextBox_LguProfile_Left.Text & "pt"
        Dim TxtDateIssuedBold As Boolean = False
        Dim TxtDateIssuedTop As String = _oTextBox_DateIssued_Top.Text & "pt"
        Dim TxtDateIssuedLeft As String = _oTextBox_DateIssued_Left.Text & "pt"
        Dim TxtTINBold As Boolean = False
        Dim TxtTINTop As String = _oTextBox_TIN_Top.Text & "pt"
        Dim TxtTINLeft As String = _oTextBox_TIN_Left.Text & "pt"
        Dim TxtLastNameBold As Boolean = False
        Dim TxtLastNameTop As String = _oTextBox_LastName_Top.Text & "pt"
        Dim TxtLastNameLeft As String = _oTextBox_LastName_Left.Text & "pt"
        Dim TxtFirstNameBold As Boolean = False
        Dim TxtFirstNameTop As String = _oTextBox_FirstName_Top.Text & "pt"
        Dim TxtFirstNameLeft As String = _oTextBox_FirstName_Left.Text & "pt"
        Dim TxtMiddleNameBold As Boolean = False
        Dim TxtMiddleNameTop As String = _oTextBox_MiddleName_Top.Text & "pt"
        Dim TxtMiddleNameLeft As String = _oTextBox_MiddleName_Left.Text & "pt"
        Dim TxtAddressBold As Boolean = False
        Dim TxtAddressTop As String = _oTextBox_Address_Top.Text & "pt"
        Dim TxtAddressLeft As String = _oTextBox_Address_Left.Text & "pt"
        Dim TxtGenderBold As Boolean = False
        Dim TxtGenderTop As String = _oTextBox_Gender_Top.Text & "pt"
        Dim TxtGenderLeft As String = _oTextBox_Gender_Left.Text & "pt"
        Dim TxtCitizenshipBold As Boolean = False
        Dim TxtCitizenshipTop As String = _oTextBox_Citizenship_Top.Text & "pt"
        Dim TxtCitizenshipLeft As String = _oTextBox_Citizenship_Left.Text & "pt"
        Dim TxtBirthPlaceBold As Boolean = False
        Dim TxtBirthPlaceTop As String = _oTextBox_BirthPlace_Top.Text & "pt"
        Dim TxtBirthPlaceLeft As String = _oTextBox_BirthPlace_Left.Text & "pt"
        Dim TxtOccupationBold As Boolean = False
        Dim TxtOccupationTop As String = _oTextBox_Occupation_Top.Text & "pt"
        Dim TxtOccupationLeft As String = _oTextBox_Occupation_Left.Text & "pt"
        Dim TxtBasicAmountBold As Boolean = False
        Dim TxtBasicAmountTop As String = _oTextBox_BasicAmount_Top.Text & "pt"
        Dim TxtBasicAmountLeft As String = _oTextBox_BasicAmount_Left.Text & "pt"
        Dim TxtTaxAmountBold As Boolean = False
        Dim TxtTaxAmountTop As String = _oTextBox_TaxAmount_Top.Text & "pt"
        Dim TxtTaxAmountLeft As String = _oTextBox_TaxAmount_Left.Text & "pt"
        Dim TxtPenaltyBold As Boolean = False
        Dim TxtPenaltyTop As String = _oTextBox_Penalty_Top.Text & "pt"
        Dim TxtPenaltyLeft As String = _oTextBox_Penalty_Left.Text & "pt"
        Dim TxtTotalAmountBold As Boolean = False
        Dim TxtTotalAmountTop As String = _oTextBox_TotalAmount_Top.Text & "pt"
        Dim TxtTotalAmountLeft As String = _oTextBox_TotalAmount_Left.Text & "pt"
        Dim TxtCivilStatusBold As Boolean = False
        Dim TxtCivilStatusTop As String = _oTextBox_CivilStatus_Top.Text & "pt"
        Dim TxtCivilStatusLeft As String = _oTextBox_CivilStatus_Left.Text & "pt"
        Dim TxtRPTIncomeBold As Boolean = False
        Dim TxtRPTIncomeTop As String = _oTextBox_RPTIncome_Top.Text & "pt"
        Dim TxtRPTIncomeLeft As String = _oTextBox_RPTIncome_Left.Text & "pt"
        Dim TxtProfIncomeBold As Boolean = False
        Dim TxtProfIncomeTop As String = _oTextBox_ProfIncome_Top.Text & "pt"
        Dim TxtProfIncomeLeft As String = _oTextBox_ProfIncome_Left.Text & "pt"
        Dim TxtBusIncomeBold As Boolean = False
        Dim TxtBusIncomeTop As String = _oTextBox_BusIncome_Top.Text & "pt"
        Dim TxtBusIncomeLeft As String = _oTextBox_BusIncome_Left.Text & "pt"
        Dim TxtRPTIncomeComputationBold As Boolean = False
        Dim TxtRPTIncomeComputationTop As String = _oTextBox_RPTIncomeComputation_Top.Text & "pt"
        Dim TxtRPTIncomeComputationLeft As String = _oTextBox_RPTIncomeComputation_Left.Text & "pt"
        Dim TxtProfIncomeComputationBold As Boolean = False
        Dim TxtProfIncomeComputationTop As String = _oTextBox_ProfIncomeComputation_Top.Text & "pt"
        Dim TxtProfIncomeComputationLeft As String = _oTextBox_ProfIncomeComputation_Left.Text & "pt"
        Dim TxtBusIncomeComputationBold As Boolean = False
        Dim TxtBusIncomeComputationTop As String = _oTextBox_BusIncomeComputation_Top.Text & "pt"
        Dim TxtBusIncomeComputationLeft As String = _oTextBox_BusIncomeComputation_Left.Text & "pt"

        rdlcStr = "<?xml version=""1.0"" encoding=""utf-8""?> <Report xmlns=""http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition"" xmlns:rd=""http://schemas.microsoft.com/SQLServer/reporting/reportdesigner""> <AutoRefresh>0</AutoRefresh> <DataSources> <DataSource Name=""ID_oXsd_PrintOR""> <ConnectionProperties> <DataProvider>System.Data.DataSet</DataProvider> <ConnectString>/* Local Connection */</ConnectString> </ConnectionProperties> <rd:DataSourceID>43b75e70-cff1-4ef2-aab5-a5cf30edf8dd</rd:DataSourceID> </DataSource> <DataSource Name=""ID_oXsd_PrintOR1""> <ConnectionProperties> <DataProvider>System.Data.DataSet</DataProvider> <ConnectString>/* Local Connection */</ConnectString> </ConnectionProperties> <rd:DataSourceID>5a6a998c-f839-402d-9f57-77c10074e39a</rd:DataSourceID> </DataSource> </DataSources> <DataSets> <DataSet Name=""DataSet1""> <Query> <DataSourceName>ID_oXsd_PrintOR1</DataSourceName> <CommandText>/* Local Query */</CommandText> </Query> <Fields> <Field Name=""Or_number""> <DataField>Or_number</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""SRS""> <DataField>SRS</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""Year""> <DataField>Year</DataField> <rd:TypeName>System.Int32</rd:TypeName> </Field> <Field Name=""LGUProfile""> <DataField>LGUProfile</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""DateIssued""> <DataField>DateIssued</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""LastName""> <DataField>LastName</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""FirstName""> <DataField>FirstName</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""MiddleName""> <DataField>MiddleName</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""Gender""> <DataField>Gender</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""TIN""> <DataField>TIN</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""Address""> <DataField>Address</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""Citizenship""> <DataField>Citizenship</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""BirthPlace""> <DataField>BirthPlace</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""CivilStatus""> <DataField>CivilStatus</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""BirthDate""> <DataField>BirthDate</DataField> <rd:TypeName>System.DateTime</rd:TypeName> </Field> <Field Name=""Occupation""> <DataField>Occupation</DataField> <rd:TypeName>System.String</rd:TypeName> </Field> <Field Name=""BasicAmount""> <DataField>BasicAmount</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""BusIncome""> <DataField>BusIncome</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""ProfIncome""> <DataField>ProfIncome</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""RPTIncome""> <DataField>RPTIncome</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""BusIncomeComputation""> <DataField>BusIncomeComputation</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""ProfIncomeComputation""> <DataField>ProfIncomeComputation</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""RPTIncomeComputation""> <DataField>RPTIncomeComputation</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""TaxAmount""> <DataField>TaxAmount</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""Penalty""> <DataField>Penalty</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""TotAmount""> <DataField>TotAmount</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> <Field Name=""DelFee""> <DataField>DelFee</DataField> <rd:TypeName>System.Decimal</rd:TypeName> </Field> </Fields> <rd:DataSetInfo> <rd:DataSetName>_oXsd_PrintOR> </rd:DataSetName> <rd:SchemaPath>D:\Shared\IMC\IMC\OnlineServices\_oXsd_PrintOR.xsd> </rd:SchemaPath> <rd:TableName>PrintORIndividual> </rd:TableName> <rd:TableAdapterFillMethod /> <rd:TableAdapterGetDataMethod /> <rd:TableAdapterName /> </rd:DataSetInfo> </DataSet> </DataSets> <ReportSections> <ReportSection> <Body> <ReportItems> <Textbox Name=""TxtSRS""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!SRS.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtSRSBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtSRSTop & "</Top> <Left>" & TxtSRSLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtOrNumber""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!Or_number.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtOrNumberBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtOrNumberTop & "</Top> <Left>" & TxtOrNumberLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>1</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtYear""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!Year.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtYearBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtYearTop & "</Top> <Left>" & TxtYearLeft & "</Left> <Height>0.25in</Height> <Width>0.8125in</Width> <ZIndex>2</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtLguProfile""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!LGUProfile.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtLguProfileBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtLguProfileTop & "</Top> <Left>" & TxtLguProfileLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>3</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtDateIssued""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!DateIssued.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtDateIssuedBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtDateIssuedTop & "</Top> <Left>" & TxtDateIssuedLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>4</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtTIN""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!TIN.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtTINBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtTINTop & "</Top> <Left>" & TxtTINLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>5</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtLastName""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!LastName.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtLastNameBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtLastNameTop & "</Top> <Left>" & TxtLastNameLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>6</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtFirstName""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!FirstName.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtFirstNameBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtFirstNameTop & "</Top> <Left>" & TxtFirstNameLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>7</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtMiddleName""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!MiddleName.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtMiddleNameBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtMiddleNameTop & "</Top> <Left>" & TxtMiddleNameLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>8</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtAddress""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!Address.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtAddressBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtAddressTop & "</Top> <Left>" & TxtAddressLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>9</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtGender""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!Gender.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtGenderBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtGenderTop & "</Top> <Left>" & TxtGenderLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>10</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtCitizenship""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!Citizenship.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtCitizenshipBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtCitizenshipTop & "</Top> <Left>" & TxtCitizenshipLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>11</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtBirthPlace""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!BirthPlace.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtBirthPlaceBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtBirthPlaceTop & "</Top> <Left>" & TxtBirthPlaceLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>12</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtOccupation""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!Occupation.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtOccupationBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtOccupationTop & "</Top> <Left>" & TxtOccupationLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>13</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtBasicAmount""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!BasicAmount.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtBasicAmountBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtBasicAmountTop & "</Top> <Left>" & TxtBasicAmountLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>14</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtTaxAmount""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!TaxAmount.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtTaxAmountBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtTaxAmountTop & "</Top> <Left>" & TxtTaxAmountLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>15</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtPenalty""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!Penalty.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtPenaltyBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtPenaltyTop & "</Top> <Left>" & TxtPenaltyLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>16</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtTotalAmount""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!TotAmount.Value, ""DataSet1"") + Sum(Fields!DelFee.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtTotalAmountBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>0.00;(0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtTotalAmountTop & "</Top> <Left>" & TxtTotalAmountLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>17</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtCivilStatus""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=First(Fields!CivilStatus.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtCivilStatusBold = True, "Bold", "Normal").ToString & "</FontWeight> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtCivilStatusTop & "</Top> <Left>" & TxtCivilStatusLeft & "</Left> <Height>0.25in</Height> <Width>3.1875in</Width> <ZIndex>18</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtRPTIncome""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!RPTIncome.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtRPTIncomeBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtRPTIncomeTop & "</Top> <Left>" & TxtRPTIncomeLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>19</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtProfIncome""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!ProfIncome.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtProfIncomeBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtProfIncomeTop & "</Top> <Left>" & TxtProfIncomeLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>20</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtBusIncome""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!BusIncome.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtBusIncomeBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtBusIncomeTop & "</Top> <Left>" & TxtBusIncomeLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>21</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtRPTIncomeComputation""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!RPTIncomeComputation.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtRPTIncomeComputationBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtRPTIncomeComputationTop & "</Top> <Left>" & TxtRPTIncomeComputationLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>22</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtProfIncomeComputation""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!ProfIncomeComputation.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtProfIncomeComputationBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtProfIncomeComputationTop & "</Top> <Left>" & TxtProfIncomeComputationLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>23</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> <Textbox Name=""TxtBusIncomeComputation""> <CanGrow>true</CanGrow> <KeepTogether>true</KeepTogether> <Paragraphs> <Paragraph> <TextRuns> <TextRun> <Value>=Sum(Fields!BusIncomeComputation.Value, ""DataSet1"")</Value> <Style> <FontWeight>" & IIf(TxtBusIncomeComputationBold = True, "Bold", "Normal").ToString & "</FontWeight> <Format>#,0.00;(#,0.00)</Format> </Style> </TextRun> </TextRuns> <Style/> </Paragraph> </Paragraphs> <Top>" & TxtBusIncomeComputationTop & "</Top> <Left>" & TxtBusIncomeComputationLeft & "</Left> <Height>0.25in</Height> <Width>1.0625in</Width> <ZIndex>24</ZIndex> <Style> <Border> <Style>None</Style> </Border> <PaddingLeft>2pt</PaddingLeft> <PaddingRight>2pt</PaddingRight> <PaddingTop>2pt</PaddingTop> <PaddingBottom>2pt</PaddingBottom> </Style> </Textbox> </ReportItems> <Height>3.60521in</Height> <Style/> </Body> <Width>7.13542in</Width> <Page> <LeftMargin>1in</LeftMargin> <RightMargin>1in</RightMargin> <TopMargin>1in</TopMargin> <BottomMargin>1in</BottomMargin> <Style/> </Page> </ReportSection> </ReportSections> <rd:ReportUnitType>Inch</rd:ReportUnitType> <rd:ReportID>d569f6db-739f-4c56-aa6a-aa1ecdbbd0ae</rd:ReportID> </Report>"


        Dim RdlcPath As String = AppDomain.CurrentDomain.BaseDirectory & "\webportal\_oRdlc_pPrintORIndividual.rdlc"
        If System.IO.File.Exists(RdlcPath) Then System.IO.File.Delete(RdlcPath)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(RdlcPath, True)
        file.WriteLine((rdlcStr.Replace("> <", ">" & vbNewLine & "<")).Replace(">  <", ">" & vbNewLine & "<"))
        file.Close()


        ''==========================================================================================================================================
    End Sub




End Class