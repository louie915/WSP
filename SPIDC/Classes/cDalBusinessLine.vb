

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
'Imports VS2014.CL.BPLTIMS.Resources


#End Region

Public Class cDalBusinessLine

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mSqlCon2 As SqlConnection
    Private connetionString As String

    Private _mSqlCommand As SqlCommand
    Private _mSqlCommand2 As SqlCommand
    Private _mSqlCommand3 As SqlCommand
    Private _mSqlCommand4 As SqlCommand  '@ 20170721
    Private _mSqlCommand_GREXCESS As SqlCommand '@ 20170721
    Private _mDataTable As DataTable
    Private _mDataTable2 As DataTable
    Private _mDataTable3 As DataTable
    Private _mDataTable4 As DataTable '@ 20170721
    Private _mDataTable_GREXCESS As DataTable '@ 20170721
    Private _mSqlDataReader As SqlDataReader
    Private _mSqlDataReader2 As SqlDataReader
    Private _mSqlDataReader3 As SqlDataReader
    Private _mSqlDataReader4 As SqlDataReader '@ 20170721
    Private _mSqlDataReader_GREXCESS As SqlDataReader '@ 20170721

#End Region
    Private Shared sql As String
    Private Shared _mQuery As String = Nothing
    Private Shared connection As SqlConnection

    Public Function globalconnection() As String
        Try
            connetionString = cGlobalConnections._pSqlCxn_BPLTIMS.ConnectionString '("Data Source=128.1.14.4\MSSQL2012DEV;Initial Catalog=R&D.BPLTIMS;User ID=chris;")
            'sql = "select * from BldgLedg "
            'subsql = "select * from TaxOrderPayment"
            ''If sql = "" And subsql = "" Then
            'Else
            '    Handleselection1 = sql
            '    Handleselection2 = subsql
            'End If
            connection = New SqlConnection(connetionString)
            connection.Open()
            Dim sqlda As New SqlDataAdapter(Sql, connection)

            sqlda.Fill(_mDataTable)
            'subsqlda.Fill(subtbl)

            connection.Close()

        Catch ex As Exception

        End Try

        Return True
    End Function


#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value

        End Set
    End Property

    Public WriteOnly Property _pSqlConnection2() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon2 = value
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

    Public ReadOnly Property _pSqlCommand2() As SqlCommand
        Get
            Return _mSqlCommand2
        End Get
    End Property

    Public ReadOnly Property _pSqlCommand3() As SqlCommand
        Get
            Return _mSqlCommand3
        End Get
    End Property

    Public ReadOnly Property _pSqlCommand4() As SqlCommand '@ 20170721
        Get
            Return _mSqlCommand4
        End Get
    End Property

    Public ReadOnly Property _pSqlCommand_GREXCESS() As SqlCommand '@ 20170721
        Get
            Return _mSqlCommand_GREXCESS
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

    Public ReadOnly Property _pDataTable2() As DataTable
        Get
            Try
                '----------------------------------

                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable2 = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable2)

                Return _mDataTable2
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pDataTable3() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter3 As New SqlDataAdapter(_mSqlCommand3)
                _mDataTable3 = New DataTable
                _nSqlDataAdapter3.Fill(_mDataTable3)

                Return _mDataTable3
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pDataTable4() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter4 As New SqlDataAdapter(_mSqlCommand4)
                _mDataTable4 = New DataTable
                _nSqlDataAdapter4.Fill(_mDataTable4)

                Return _mDataTable4
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pDataTable_GREXCESS() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter_GREXCESS As New SqlDataAdapter(_mSqlCommand_GREXCESS)
                _mDataTable_GREXCESS = New DataTable
                _nSqlDataAdapter_GREXCESS.Fill(_mDataTable_GREXCESS)

                Return _mDataTable_GREXCESS
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
                '_mSqlDataReader = Nothing
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                ' _mSqlCommand.Dispose()
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pSqlDataReader2() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader2 = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader2
                ' _mSqlCommand2.Dispose()
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pSqlDataReader3() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader3 = _mSqlCommand3.ExecuteReader

                Return _mSqlDataReader3

                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pSqlDataReader4() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader4 = _mSqlCommand4.ExecuteReader

                Return _mSqlDataReader4

                _mSqlCommand4.Dispose()
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader_GREXCESS() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader_GREXCESS = _mSqlCommand_GREXCESS.ExecuteReader

                Return _mSqlDataReader_GREXCESS

                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Variables Field"

    Private _mRowNo As String '   @ Added 20170418

    Private _mOutputRec1 As String '   @ Added 20170418
    Private _mOutputRec2 As String '   @ Added 20170418
    Private _mOutputRec3 As String '   @ Added 20170418
    Private _mOutputRec4 As String '   @ Added 20170418
    Private _mOutputRec5 As String '   @ Added 20170418
    Private _mOutputRec6 As String '   @ Added 20170418
    Private _mOutputRec7 As String '   @ Added 20170418
    Private _mOutputRec8 As String '   @ Added 20170418
    Private _mOutputRec9 As String '   @ Added 20170418
    Private _mOutputRec10 As String '   @ Added 20170418

    Private _mTaxAmt1 As Double '   @ Added 20170814
    Private _mTaxAmt2 As Double '   @ Added 20170814
    Private _mTaxAmt3 As Double '   @ Added 20170814
    Private _mTaxAmt4 As Double '   @ Added 20170814
    Private _mTaxAmt5 As Double '   @ Added 20170814
    Private _mTaxAmt6 As Double '   @ Added 20170814
    Private _mTaxAmt7 As Double '   @ Added 20170814
    Private _mTaxAmt8 As Double '   @ Added 20170814
    Private _mTaxAmt9 As Double '   @ Added 20170814
    Private _mTaxAmt10 As Double '   @ Added 20170814


    Private _mTaxCode As String   '   @ Added 
    Private _mASKHDG_Month As String ' @ Added 20170718
    Private _mASKHDG_Year As String ' @ Added 20170718
    Private _mTaxDesc As String   '   @ Added 20170417
    Private _mTaxDesc2 As String   ' @ Added 20170419
    Private _mBusLineCol As String '   @ Added 20170417
    Private _mTblCode As String   '   @ Added 20170417
    Private _mInputVal As String '   @ Added 20170417

    Private _mGradYear As String '   @ Added 20170531
    Private _mGradMonth As String '   @ Added 20170531
    Private _mGradTaxMin As Double '   @ Added 20170717
    Private _mGradTaxMax As Double '   @ Added 20170717

    Private _mAccount As String
    Private _mBusCode As String
    Private _mnBusCode As String
    Private _mBusDesc As String
    Private _mBusYear As String
    Private _mBusGrossRec As String
    Private _mBusCap As String
    Private _mBusArea As String
    Private _mBusNRC As String
    Private _mBusListSearch As String

    Private _mDate_Estab As Date '@  Added 20170705
    Private _mStatMain As String '@  Added 20170705

    Private _mBusDistCode As String
    Private _mBusBRGYCode As String

    Private _mTaxRate As Double '@ Added 20170412
    Private _mTaxAmt As Double '@ Added 20170412

    Private _mTaxCode2 As String '@ Added 20170509

    Private _mEff_Month As String '@ Added 20170512
    Private _mEff_Year As String '@ Added 20170512

    Private _mBRANGE_QTY As Double '@ Added 20170629 
    Private _mSTATCODE As String '@ Added 20170710
    Private _mBCHOICE1 As Integer '@ Added 20170629
    Private _mBCHOICE2 As Integer '@ Added 20170629
    Private _mBCHOICE3 As Integer '@ Added 20170629
    Private _mBCHOICE4 As Integer '@ Added 20170629
    Private _mBQTY As Double '@ Added 20170629
    Private _mBQTY1 As Double '@ Added 20170629
    Private _mBQTY2 As Double '@ Added 20170629
    Private _mBQTY3 As Double '@ Added 20170629
    Private _mBQTY4 As Double '@ Added 20170629
    Private _mBQTY5 As Double '@ Added 20170629
    Private _mBQTY6 As Double '@ Added 20170629
    Private _mBQTY7 As Double '@ Added 20170629
    Private _mBQTY8 As Double '@ Added 20170629
    Private _mBQTY9 As Double '@ Added 20170629
    Private _mBQTY10 As Double '@ Added 20170629

    Private _mMRANGE_QTY As Double '@ Added 20170629
    Private _mMCHOICE1 As Integer '@ Added 20170629
    Private _mMCHOICE2 As Integer '@ Added 20170629
    Private _mMCHOICE3 As Integer '@ Added 20170629
    Private _mMCHOICE4 As Integer '@ Added 20170629
    Private _mMQTY As Double '@ Added 20170629
    Private _mMQTY1 As Double '@ Added 20170629
    Private _mMQTY2 As Double '@ Added 20170629
    Private _mMQTY3 As Double '@ Added 20170629
    Private _mMQTY4 As Double '@ Added 20170629
    Private _mMQTY5 As Double '@ Added 20170629
    Private _mMQTY6 As Double '@ Added 20170629
    Private _mMQTY7 As Double '@ Added 20170629
    Private _mMQTY8 As Double '@ Added 20170629
    Private _mMQTY9 As Double '@ Added 20170629
    Private _mMQTY10 As Double '@ Added 20170629

    Private _mBT_YEAR As String '@ Added 20170810
    Private _mMF_YEAR As String '@ Added 20170810
    Private _mGF_YEAR As String '@ Added 20170810
    Private _mSF_YEAR As String '@ Added 20170810

    Private _mGRANGE_QTY As Double '@ Added 20170629
    Private _mGCHOICE1 As Integer '@ Added 20170629
    Private _mGCHOICE2 As Integer '@ Added 20170629
    Private _mGCHOICE3 As Integer '@ Added 20170629
    Private _mGCHOICE4 As Integer '@ Added 20170629
    Private _mGQTY As Double '@ Added 20170629
    Private _mGQTY1 As Double '@ Added 20170629
    Private _mGQTY2 As Double '@ Added 20170629
    Private _mGQTY3 As Double '@ Added 20170629
    Private _mGQTY4 As Double '@ Added 20170629
    Private _mGQTY5 As Double '@ Added 20170629
    Private _mGQTY6 As Double '@ Added 20170629
    Private _mGQTY7 As Double '@ Added 20170629
    Private _mGQTY8 As Double '@ Added 20170629
    Private _mGQTY9 As Double '@ Added 20170629
    Private _mGQTY10 As Double '@ Added 20170629

    Private _mFRANGE_QTY As Double '@ Added 20170629
    Private _mFCHOICE1 As Integer '@ Added 20170629
    Private _mFCHOICE2 As Integer '@ Added 20170629
    Private _mFCHOICE3 As Integer '@ Added 20170629
    Private _mFCHOICE4 As Integer '@ Added 20170629
    Private _mFQTY As Double '@ Added 20170629
    Private _mFQTY1 As Double '@ Added 20170629
    Private _mFQTY2 As Double '@ Added 20170629
    Private _mFQTY3 As Double '@ Added 20170629
    Private _mFQTY4 As Double '@ Added 20170629
    Private _mFQTY5 As Double '@ Added 20170629
    Private _mFQTY6 As Double '@ Added 20170629
    Private _mFQTY7 As Double '@ Added 20170629
    Private _mFQTY8 As Double '@ Added 20170629
    Private _mFQTY9 As Double '@ Added 20170629
    Private _mFQTY10 As Double '@ Added 20170629

    Private _mSRANGE_QTY As Double '@ Added 20170629
    Private _mSCHOICE1 As Integer '@ Added 20170629
    Private _mSCHOICE2 As Integer '@ Added 20170629
    Private _mSCHOICE3 As Integer '@ Added 20170629
    Private _mSCHOICE4 As Integer '@ Added 20170629
    Private _mSQTY As Double '@ Added 20170629
    Private _mSQTY1 As Double '@ Added 20170629
    Private _mSQTY2 As Double '@ Added 20170629
    Private _mSQTY3 As Double '@ Added 20170629
    Private _mSQTY4 As Double '@ Added 20170629
    Private _mSQTY5 As Double '@ Added 20170629
    Private _mSQTY6 As Double '@ Added 20170629
    Private _mSQTY7 As Double '@ Added 20170629
    Private _mSQTY8 As Double '@ Added 20170629
    Private _mSQTY9 As Double '@ Added 20170629
    Private _mSQTY10 As Double '@ Added 20170629

    Private _mBCHOICE As String '@ Added 20170630
    Private _mMCHOICE As String '@ Added 20170630
    Private _mGCHOICE As String '@ Added 20170630
    Private _mSCHOICE As String '@ Added 20170630
    Private _mFCHOICE As String '@ Added 20170630

    Private _mBCHOICE_Row As String  '@ Added 20170703
    Private _mMCHOICE_Row As String  '@ Added 20170703
    Private _mGCHOICE_Row As String  '@ Added 20170703
    Private _mSCHOICE_Row As String  '@ Added 20170703
    Private _mFCHOICE_Row As String  '@ Added 20170703

    Private _mCHOICE_Col As String '@ Added 20170703
    'Private _mMCHOICE_Col As String '@ Added 20170703
    'Private _mGCHOICE_Col As String '@ Added 20170703
    'Private _mSCHOICE_Col As String '@ Added 20170703
    'Private _mFCHOICE_Col As String '@ Added 20170703

    Private _mBUSTAX As Double '@ Added 20170704
    Private _mMAYORS As Double '@ Added 20170704
    Private _mGARBAGE As Double '@ Added 20170704
    Private _mSANITARY As Double '@ Added 20170704
    Private _mFIRE As Double '@ Added 20170704
    Private _mGarbage_O As Integer '@ Added 20170704
    Private _mSanitary_O As Integer '@ Added 20170704
    Private _mFIRE_O As Integer '@ Added 20170704
    Private _mNewsw As Integer '@ Added 20170704

    Private _mFeeKind As String '@ Added 20170705

    Private _mBCODE As String '@ Added 20170706
    Private _mMCODE As String '@ Added 20170706
    Private _mGCODE As String '@ Added 20170706
    Private _mSCODE As String '@ Added 20170706
    Private _mFCODE As String '@ Added 20170706

    Private _mB_FinalTax As Double '@ Added 20170714
    Private _mM_FinalTax As Double '@ Added 20170714
    Private _mG_FinalTax As Double '@ Added 20170714
    Private _mS_FinalTax As Double '@ Added 20170714
    Private _mF_FinalTax As Double '@ Added 20170714

    Private _mBT_EFFYR As Integer '@ Added 20170713
    Private _mTaxDueMin As Integer  '@ Added 20170706
    Private _mTaxDueMax As Integer  '@ Added 20170706
    Private _mMTaxCode As Integer  '@ Added 20170706
    Private _mCOMPSW As Integer '@ Added 20170710

    Private _mTempYr As Integer  '@ Added 20170706
    Private _mTempMo As String  '@ Added 20170706
    Private _mTAXBASE As Double  '@ Added 20170707
    Private _mMTAXCODE1 As String  '@ Added 20170707


    Private _mo1 As Double  '@ Added 20170707
    Private _mo2 As Double  '@ Added 20170707
    Private _mo3 As Double  '@ Added 20170707
    Private _mo4 As Double  '@ Added 20170707
    Private _mo5 As Double  '@ Added 20170707
    Private _mo6 As Double  '@ Added 20170707
    Private _mo7 As Double  '@ Added 20170707
    Private _mo8 As Double  '@ Added 20170707
    Private _mo9 As Double  '@ Added 20170707
    Private _mo10 As Double  '@ Added 20170707

    Private _mC1 As Integer  '@ Added 20170707
    Private _mC2 As Integer  '@ Added 20170707
    Private _mC3 As Integer  '@ Added 20170707
    Private _mC4 As Integer  '@ Added 20170707
    Private _mCH1 As Integer  '@ Added 20170720
    Private _mCH2 As Integer  '@ Added 20170720
    Private _mCH3 As Integer  '@ Added 20170720
    Private _mCH4 As Integer  '@ Added 20170720

    Private _mEPO As String
    Private _mEIF As String
    Private _mPLATE As String

    Private _mGRRANGE_RANGEAMT As Double '@ Added 20170412
    Private _mGRRANGE_TAXRATE As Double '@ Added 20170412
    Private _mGRRANGE_TAXAMT As Double '@ Added 20170412
    Private _mGRRANGE_RowNo As Integer '@ Added 20170728

    Private _mFOR_EVERY As Integer '@ Added 20170714
    Private _mINXSOF As Integer '@ Added 20170714
    Private _mExcess_TAXRATE As Double '@ Added 20170714
    Private _mExcess_TAXAMT As Double '@ Added 20170714
    Private _mINFRACOF As Integer '@ Added 20170714
    Private _mEXCESS As Double '@ Added 20170714
    Private _mXSDUE As Double '@ Added 20170714
    Private _mcnt As Double '@ Added 20170714
    Private _mLouie As Boolean '@ Added 20170714
    Private _mADDAMT As Integer '@ Added 20170802

    Private _mELECfee As Double
    Private _mMECHfee As Double
    Private _mBLDGfee As Double
    Private _mSIGNfee As Double
    Private _mEPOfee As Double
    Private _mEIFfee As Double
    Private _mPLATfee As Double

#End Region

#Region "Show Panel"
    ' @ Added 20170420 -------------
    Private _mShowPanel1 As Boolean
    Private _mShowPanel2 As Boolean
    Private _mShowPanel3 As Boolean
    Private _mShowPanel4 As Boolean
    Private _mShowPanel5 As Boolean
    Private _mShowPanel6 As Boolean
    Private _mShowPanel7 As Boolean
    Private _mShowPanel8 As Boolean
    Private _mShowPanel9 As Boolean
    Private _mShowPanel10 As Boolean

#Region "AIF DESCRIPTION"

    Public Property _pEPO() As String
        Get
            Return _mEPO
        End Get
        Set(ByVal value As String)
            _mEPO = value
        End Set
    End Property

    Public Property _pEIF() As String
        Get
            Return _mEIF
        End Get
        Set(ByVal value As String)
            _mEIF = value
        End Set
    End Property

    Public Property _pPLATE() As String
        Get
            Return _mPLATE
        End Get
        Set(ByVal value As String)
            _mPLATE = value
        End Set
    End Property

#End Region

#Region "Option Column"

    Public Property _pCHOICE_Col() As String
        Get
            Return _mCHOICE_Col
        End Get
        Set(ByVal value As String)
            _mCHOICE_Col = value
        End Set
    End Property

    'Public Property _pMCHOICE_Col() As String
    '    Get
    '        Return _mMCHOICE_Col
    '    End Get
    '    Set(ByVal value As String)
    '        _mMCHOICE_Col = value
    '    End Set
    'End Property

    'Public Property _pGCHOICE_Col() As String
    '    Get
    '        Return _mGCHOICE_Col
    '    End Get
    '    Set(ByVal value As String)
    '        _mGCHOICE_Col = value
    '    End Set
    'End Property

    'Public Property _pSCHOICE_Col() As String
    '    Get
    '        Return _mSCHOICE_Col
    '    End Get
    '    Set(ByVal value As String)
    '        _mSCHOICE_Col = value
    '    End Set
    'End Property

    'Public Property _pFCHOICE_Col() As String
    '    Get
    '        Return _mFCHOICE_Col
    '    End Get
    '    Set(ByVal value As String)
    '        _mFCHOICE_Col = value
    '    End Set
    'End Property

#End Region

#Region "SELECTED OPTION ROW"

    Public Property _pBCHOICE_Row() As String
        Get
            Return _mBCHOICE_Row
        End Get
        Set(ByVal value As String)
            _mBCHOICE_Row = value
        End Set
    End Property

    Public Property _pMCHOICE_Row() As String
        Get
            Return _mMCHOICE_Row
        End Get
        Set(ByVal value As String)
            _mMCHOICE_Row = value
        End Set
    End Property

    Public Property _pGCHOICE_Row() As String
        Get
            Return _mGCHOICE_Row
        End Get
        Set(ByVal value As String)
            _mGCHOICE_Row = value
        End Set
    End Property

    Public Property _pSCHOICE_Row() As String
        Get
            Return _mSCHOICE_Row
        End Get
        Set(ByVal value As String)
            _mSCHOICE_Row = value
        End Set
    End Property

    Public Property _pFCHOICE_Row() As String
        Get
            Return _mFCHOICE_Row
        End Get
        Set(ByVal value As String)
            _mFCHOICE_Row = value
        End Set
    End Property

#End Region

#Region "Show Panel Trigger"
    Public Property _pShowPanel1() As Boolean
        Get
            Return _mShowPanel1
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel1 = value
        End Set
    End Property

    Public Property _pShowPanel2() As Boolean
        Get
            Return _mShowPanel2
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel2 = value
        End Set
    End Property

    Public Property _pShowPanel3() As Boolean
        Get
            Return _mShowPanel3
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel3 = value
        End Set
    End Property

    Public Property _pShowPanel4() As Boolean
        Get
            Return _mShowPanel4
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel4 = value
        End Set
    End Property

    Public Property _pShowPanel5() As Boolean
        Get
            Return _mShowPanel5
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel5 = value
        End Set
    End Property

    Public Property _pShowPanel6() As Boolean
        Get
            Return _mShowPanel6
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel6 = value
        End Set
    End Property

    Public Property _pShowPanel7() As Boolean
        Get
            Return _mShowPanel7
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel7 = value
        End Set
    End Property

    Public Property _pShowPanel8() As Boolean
        Get
            Return _mShowPanel8
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel8 = value
        End Set
    End Property

    Public Property _pShowPanel9() As Boolean
        Get
            Return _mShowPanel9
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel9 = value
        End Set
    End Property

    Public Property _pShowPanel10() As Boolean
        Get
            Return _mShowPanel10
        End Get
        Set(ByVal value As Boolean)
            _mShowPanel10 = value
        End Set
    End Property
#End Region

#End Region

#Region "For GREXCESS"
    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    Public Property _pELECfee() As Double
        Get
            Return _mELECfee
        End Get
        Set(ByVal value As Double)
            _mELECfee = value
        End Set
    End Property

    Public Property _pMECHfee() As Double
        Get
            Return _mMECHfee
        End Get
        Set(ByVal value As Double)
            _mMECHfee = value
        End Set
    End Property

    Public Property _pBLDGfee() As Double
        Get
            Return _mBLDGfee
        End Get
        Set(ByVal value As Double)
            _mBLDGfee = value
        End Set
    End Property

    Public Property _pSIGNfee() As Double
        Get
            Return _mSIGNfee
        End Get
        Set(ByVal value As Double)
            _mSIGNfee = value
        End Set
    End Property

    Public Property _pEPOfee() As Double
        Get
            Return _mEPOfee
        End Get
        Set(ByVal value As Double)
            _mEPOfee = value
        End Set
    End Property
    Public Property _pEIFfee() As Double
        Get
            Return _mEIFfee
        End Get
        Set(ByVal value As Double)
            _mEIFfee = value
        End Set
    End Property
    Public Property _pPLATfee() As Double
        Get
            Return _mPLATfee
        End Get
        Set(ByVal value As Double)
            _mPLATfee = value
        End Set
    End Property

    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


    Public Property _pLouie() As Boolean
        Get
            Return _mLouie
        End Get
        Set(ByVal value As Boolean)
            _mLouie = value
        End Set
    End Property

    Public Property _pcnt() As Double
        Get
            Return _mcnt
        End Get
        Set(ByVal value As Double)
            _mcnt = value
        End Set
    End Property

    Public Property _pXSDUE() As Double
        Get
            Return _mXSDUE
        End Get
        Set(ByVal value As Double)
            _mXSDUE = value
        End Set
    End Property

    Public Property _pEXCESS() As Double
        Get
            Return _mEXCESS
        End Get
        Set(ByVal value As Double)
            _mEXCESS = value
        End Set
    End Property

    Public Property _pFOR_EVERY() As Integer
        Get
            Return _mFOR_EVERY
        End Get
        Set(ByVal value As Integer)
            _mFOR_EVERY = value
        End Set
    End Property

    Public Property _pINXSOF() As Integer
        Get
            Return _mINXSOF
        End Get
        Set(ByVal value As Integer)
            _mINXSOF = value
        End Set
    End Property

    Public Property _pExcess_TAXRATE() As Double
        Get
            Return _mExcess_TAXRATE
        End Get
        Set(ByVal value As Double)
            _mExcess_TAXRATE = value
        End Set
    End Property

    Public Property _pExcess_TAXAMT() As Double
        Get
            Return _mExcess_TAXAMT
        End Get
        Set(ByVal value As Double)
            _mExcess_TAXAMT = value
        End Set
    End Property

    Public Property _pINFRACOF() As Integer
        Get
            Return _mINFRACOF
        End Get
        Set(ByVal value As Integer)
            _mINFRACOF = value
        End Set
    End Property
    Public Property _pADDAMT() As Integer
        Get
            Return _mADDAMT
        End Get
        Set(ByVal value As Integer)
            _mADDAMT = value
        End Set
    End Property
#End Region

#Region "For GRRANGE"

    Public Property _pGRRANGE_RANGEAMT() As Double
        Get
            Return _mGRRANGE_RANGEAMT
        End Get
        Set(ByVal value As Double)
            _mGRRANGE_RANGEAMT = value
        End Set
    End Property

    Public Property _pGRRANGE_TAXRATE() As Double
        Get
            Return _mGRRANGE_TAXRATE
        End Get
        Set(ByVal value As Double)
            _mGRRANGE_TAXRATE = value
        End Set
    End Property

    Public Property _pGRRANGE_TAXAMT() As Double
        Get
            Return _mGRRANGE_TAXAMT
        End Get
        Set(ByVal value As Double)
            _mGRRANGE_TAXAMT = value
        End Set
    End Property

    Public Property _pGRRANGE_RowNo() As Integer
        Get
            Return _mGRRANGE_RowNo
        End Get
        Set(ByVal value As Integer)
            _mGRRANGE_RowNo = value
        End Set
    End Property

#End Region

#Region "Main Qty"

    Public Property _po1() As Double
        Get
            Return _mo1
        End Get
        Set(ByVal value As Double)
            _mo1 = value
        End Set
    End Property

    Public Property _po2() As Double
        Get
            Return _mo2
        End Get
        Set(ByVal value As Double)
            _mo2 = value
        End Set
    End Property

    Public Property _po3() As Double
        Get
            Return _mo3
        End Get
        Set(ByVal value As Double)
            _mo3 = value
        End Set
    End Property

    Public Property _po4() As Double
        Get
            Return _mo4
        End Get
        Set(ByVal value As Double)
            _mo4 = value
        End Set
    End Property

    Public Property _po5() As Double
        Get
            Return _mo5
        End Get
        Set(ByVal value As Double)
            _mo5 = value
        End Set
    End Property

    Public Property _po6() As Double
        Get
            Return _mo6
        End Get
        Set(ByVal value As Double)
            _mo6 = value
        End Set
    End Property

    Public Property _po7() As Double
        Get
            Return _mo7
        End Get
        Set(ByVal value As Double)
            _mo7 = value
        End Set
    End Property

    Public Property _po8() As Double
        Get
            Return _mo8
        End Get
        Set(ByVal value As Double)
            _mo8 = value
        End Set
    End Property

    Public Property _po9() As Double
        Get
            Return _mo9
        End Get
        Set(ByVal value As Double)
            _mo9 = value
        End Set
    End Property

    Public Property _po10() As Double
        Get
            Return _mo10
        End Get
        Set(ByVal value As Double)
            _mo10 = value
        End Set
    End Property

#End Region

#Region "Main option"

    Public Property _pC1() As Double
        Get
            Return _mC1
        End Get
        Set(ByVal value As Double)
            _mC1 = value
        End Set
    End Property

    Public Property _pC2() As Double
        Get
            Return _mC2
        End Get
        Set(ByVal value As Double)
            _mC2 = value
        End Set
    End Property

    Public Property _pC3() As Double
        Get
            Return _mC3
        End Get
        Set(ByVal value As Double)
            _mC3 = value
        End Set
    End Property

    Public Property _pC4() As Double
        Get
            Return _mC4
        End Get
        Set(ByVal value As Double)
            _mC4 = value
        End Set
    End Property

    Public Property _pCH1() As Double
        Get
            Return _mCH1
        End Get
        Set(ByVal value As Double)
            _mCH1 = value
        End Set
    End Property

    Public Property _pCH2() As Double
        Get
            Return _mCH2
        End Get
        Set(ByVal value As Double)
            _mCH2 = value
        End Set
    End Property

    Public Property _pCH3() As Double
        Get
            Return _mCH3
        End Get
        Set(ByVal value As Double)
            _mCH3 = value
        End Set
    End Property

    Public Property _pCH4() As Double
        Get
            Return _mCH4
        End Get
        Set(ByVal value As Double)
            _mCH4 = value
        End Set
    End Property


#End Region

#Region ""

    Public Property _pTempYr() As Integer
        Get
            Return _mTempYr
        End Get
        Set(ByVal value As Integer)
            _mTempYr = value
        End Set
    End Property

    Public Property _pTempMo() As String
        Get
            Return _mTempMo
        End Get
        Set(ByVal value As String)
            _mTempMo = value
        End Set
    End Property

    Public Property _pTaxDueMin() As Integer
        Get
            Return _mTaxDueMin
        End Get
        Set(ByVal value As Integer)
            _mTaxDueMin = value
        End Set
    End Property

    Public Property _pTaxDueMax() As Integer
        Get
            Return _mTaxDueMax
        End Get
        Set(ByVal value As Integer)
            _mTaxDueMax = value
        End Set
    End Property

    Public Property _pMTaxCode() As Integer
        Get
            Return _mMTaxCode
        End Get
        Set(ByVal value As Integer)
            _mMTaxCode = value
        End Set
    End Property

    Public Property _pTAXBASE() As Double
        Get
            Return _mTAXBASE
        End Get
        Set(ByVal value As Double)
            _mTAXBASE = value
        End Set
    End Property

    Public Property _pMTAXCODE1() As String
        Get
            Return _mMTAXCODE1
        End Get
        Set(ByVal value As String)
            _mMTAXCODE1 = value
        End Set
    End Property

    Public Property _pCOMPSW() As Double
        Get
            Return _mCOMPSW
        End Get
        Set(ByVal value As Double)
            _mCOMPSW = value
        End Set
    End Property

#End Region

#Region "For Final Tax Output"
    Public Property _pB_FinalTax() As Double
        Get
            Return _mB_FinalTax
        End Get
        Set(ByVal value As Double)
            _mB_FinalTax = value
        End Set
    End Property

    Public Property _pM_FinalTax() As Double
        Get
            Return _mM_FinalTax
        End Get
        Set(ByVal value As Double)
            _mM_FinalTax = value
        End Set
    End Property

    Public Property _pG_FinalTax() As Double
        Get
            Return _mG_FinalTax
        End Get
        Set(ByVal value As Double)
            _mG_FinalTax = value
        End Set
    End Property

    Public Property _pS_FinalTax() As Double
        Get
            Return _mS_FinalTax
        End Get
        Set(ByVal value As Double)
            _mS_FinalTax = value
        End Set
    End Property

    Public Property _pF_FinalTax() As Double
        Get
            Return _mF_FinalTax
        End Get
        Set(ByVal value As Double)
            _mF_FinalTax = value
        End Set
    End Property

#End Region

#Region "TAXCODE"
    Public Property _pBCODE() As String
        Get
            Return _mBCODE
        End Get
        Set(ByVal value As String)
            _mBCODE = value
        End Set
    End Property

    Public Property _pMCODE() As String
        Get
            Return _mMCODE
        End Get
        Set(ByVal value As String)
            _mMCODE = value
        End Set
    End Property

    Public Property _pGCODE() As String
        Get
            Return _mGCODE
        End Get
        Set(ByVal value As String)
            _mGCODE = value
        End Set
    End Property

    Public Property _pSCODE() As String
        Get
            Return _mSCODE
        End Get
        Set(ByVal value As String)
            _mSCODE = value
        End Set
    End Property

    Public Property _pFCODE() As String
        Get
            Return _mFCODE
        End Get
        Set(ByVal value As String)
            _mFCODE = value
        End Set
    End Property

#End Region

    Public Property _pFeeKind() As String
        Get
            Return _mFeeKind
        End Get
        Set(ByVal value As String)
            _mFeeKind = value
        End Set
    End Property

#Region "BUSLINE VARIABLE"

    Public Property _pSTATCODE() As String  '@ Added 20170710
        Get
            Return _mSTATCODE
        End Get
        Set(ByVal value As String)
            _mSTATCODE = value
        End Set
    End Property

    Public Property _pBUSTAX() As Double
        Get
            Return _mBUSTAX
        End Get
        Set(ByVal value As Double)
            _mBUSTAX = value
        End Set
    End Property

    Public Property _pMAYORS() As Double
        Get
            Return _mMAYORS
        End Get
        Set(ByVal value As Double)
            _mMAYORS = value
        End Set
    End Property

    Public Property _pGARBAGE() As Double
        Get
            Return _mGARBAGE
        End Get
        Set(ByVal value As Double)
            _mGARBAGE = value
        End Set
    End Property

    Public Property _pSANITARY() As Double
        Get
            Return _mSANITARY
        End Get
        Set(ByVal value As Double)
            _mSANITARY = value
        End Set
    End Property

    Public Property _pFIRE() As Double
        Get
            Return _mFIRE
        End Get
        Set(ByVal value As Double)
            _mFIRE = value
        End Set
    End Property

    Public Property _pGarbage_O() As Integer
        Get
            Return _mGarbage_O
        End Get
        Set(ByVal value As Integer)
            _mGarbage_O = value
        End Set
    End Property

    Public Property _pSanitary_O() As Integer
        Get
            Return _mSanitary_O
        End Get
        Set(ByVal value As Integer)
            _mSanitary_O = value
        End Set
    End Property

    Public Property _pFire_O() As Integer
        Get
            Return _mFIRE_O
        End Get
        Set(ByVal value As Integer)
            _mFIRE_O = value
        End Set
    End Property

    Public Property _pNewsw() As Boolean
        Get
            Return _mNewsw
        End Get
        Set(ByVal value As Boolean)
            _mNewsw = value
        End Set
    End Property

#End Region

#Region "Temp variable BCODE"

    Public Property _pBRANGE_QTY() As Double
        Get
            Return _mBRANGE_QTY
        End Get
        Set(ByVal value As Double)
            _mBRANGE_QTY = value
        End Set
    End Property

    Public Property _pBCHOICE1() As Integer
        Get
            Return _mBCHOICE1
        End Get
        Set(ByVal value As Integer)
            _mBCHOICE1 = value
        End Set
    End Property

    Public Property _pBCHOICE2() As Integer
        Get
            Return _mBCHOICE2
        End Get
        Set(ByVal value As Integer)
            _mBCHOICE2 = value
        End Set
    End Property

    Public Property _pBCHOICE3() As Integer
        Get
            Return _mBCHOICE3
        End Get
        Set(ByVal value As Integer)
            _mBCHOICE3 = value
        End Set
    End Property

    Public Property _pBCHOICE4() As Integer
        Get
            Return _mBCHOICE4
        End Get
        Set(ByVal value As Integer)
            _mBCHOICE4 = value
        End Set
    End Property

    Public Property _pBQTY() As Double
        Get
            Return _mBQTY
        End Get
        Set(ByVal value As Double)
            _mBQTY = value
        End Set
    End Property

    Public Property _pBQTY1() As Double
        Get
            Return _mBQTY1
        End Get
        Set(ByVal value As Double)
            _mBQTY1 = value
        End Set
    End Property

    Public Property _pBQTY2() As Double
        Get
            Return _mBQTY2
        End Get
        Set(ByVal value As Double)
            _mBQTY2 = value
        End Set
    End Property

    Public Property _pBQTY3() As Double
        Get
            Return _mBQTY3
        End Get
        Set(ByVal value As Double)
            _mBQTY3 = value
        End Set
    End Property

    Public Property _pBQTY4() As Double
        Get
            Return _mBQTY4
        End Get
        Set(ByVal value As Double)
            _mBQTY4 = value
        End Set
    End Property

    Public Property _pBQTY5() As Double
        Get
            Return _mBQTY5
        End Get
        Set(ByVal value As Double)
            _mBQTY5 = value
        End Set
    End Property

    Public Property _pBQTY6() As Double
        Get
            Return _mBQTY6
        End Get
        Set(ByVal value As Double)
            _mBQTY6 = value
        End Set
    End Property

    Public Property _pBQTY7() As Double
        Get
            Return _mBQTY7
        End Get
        Set(ByVal value As Double)
            _mBQTY7 = value
        End Set
    End Property

    Public Property _pBQTY8() As Double
        Get
            Return _mBQTY8
        End Get
        Set(ByVal value As Double)
            _mBQTY8 = value
        End Set
    End Property

    Public Property _pBQTY9() As Double
        Get
            Return _mBQTY9
        End Get
        Set(ByVal value As Double)
            _mBQTY9 = value
        End Set
    End Property

    Public Property _pBQTY10() As Double
        Get
            Return _mBQTY10
        End Get
        Set(ByVal value As Double)
            _mBQTY10 = value
        End Set
    End Property

#End Region

#Region "Temp Variable MCODE"
    Public Property _pMRANGE_QTY() As Double
        Get
            Return _mMRANGE_QTY
        End Get
        Set(ByVal value As Double)
            _mMRANGE_QTY = value
        End Set
    End Property

    Public Property _pMCHOICE1() As Integer
        Get
            Return _mMCHOICE1
        End Get
        Set(ByVal value As Integer)
            _mMCHOICE1 = value
        End Set
    End Property

    Public Property _pMCHOICE2() As Integer
        Get
            Return _mMCHOICE2
        End Get
        Set(ByVal value As Integer)
            _mMCHOICE2 = value
        End Set
    End Property

    Public Property _pMCHOICE3() As Integer
        Get
            Return _mMCHOICE3
        End Get
        Set(ByVal value As Integer)
            _mMCHOICE3 = value
        End Set
    End Property

    Public Property _pMCHOICE4() As Integer
        Get
            Return _mMCHOICE4
        End Get
        Set(ByVal value As Integer)
            _mMCHOICE4 = value
        End Set
    End Property

    Public Property _pMQTY() As Double
        Get
            Return _mMQTY
        End Get
        Set(ByVal value As Double)
            _mMQTY = value
        End Set
    End Property

    Public Property _pMQTY1() As Double
        Get
            Return _mMQTY1
        End Get
        Set(ByVal value As Double)
            _mMQTY1 = value
        End Set
    End Property

    Public Property _pMQTY2() As Double
        Get
            Return _mMQTY2
        End Get
        Set(ByVal value As Double)
            _mMQTY2 = value
        End Set
    End Property

    Public Property _pMQTY3() As Double
        Get
            Return _mMQTY3
        End Get
        Set(ByVal value As Double)
            _mMQTY3 = value
        End Set
    End Property

    Public Property _pMQTY4() As Double
        Get
            Return _mMQTY4
        End Get
        Set(ByVal value As Double)
            _mMQTY4 = value
        End Set
    End Property

    Public Property _pMQTY5() As Double
        Get
            Return _mMQTY5
        End Get
        Set(ByVal value As Double)
            _mMQTY5 = value
        End Set
    End Property

    Public Property _pMQTY6() As Double
        Get
            Return _mMQTY6
        End Get
        Set(ByVal value As Double)
            _mMQTY6 = value
        End Set
    End Property

    Public Property _pMQTY7() As Double
        Get
            Return _mMQTY7
        End Get
        Set(ByVal value As Double)
            _mMQTY7 = value
        End Set
    End Property

    Public Property _pMQTY8() As Double
        Get
            Return _mMQTY8
        End Get
        Set(ByVal value As Double)
            _mMQTY8 = value
        End Set
    End Property

    Public Property _pMQTY9() As Double
        Get
            Return _mMQTY9
        End Get
        Set(ByVal value As Double)
            _mMQTY9 = value
        End Set
    End Property

    Public Property _pMQTY10() As Double
        Get
            Return _mMQTY10
        End Get
        Set(ByVal value As Double)
            _mMQTY10 = value
        End Set
    End Property
#End Region

#Region "PEN_YEAR"
    Public Property _pBT_YEAR() As String
        Get
            Return _mBT_YEAR
        End Get
        Set(ByVal value As String)
            _mBT_YEAR = value
        End Set
    End Property

    Public Property _pMF_YEAR() As String
        Get
            Return _mMF_YEAR
        End Get
        Set(ByVal value As String)
            _mMF_YEAR = value
        End Set
    End Property

    Public Property _pGF_YEAR() As String
        Get
            Return _mGF_YEAR
        End Get
        Set(ByVal value As String)
            _mGF_YEAR = value
        End Set
    End Property

    Public Property _pSF_YEAR() As String
        Get
            Return _mSF_YEAR
        End Get
        Set(ByVal value As String)
            _mSF_YEAR = value
        End Set
    End Property
#End Region


#Region "Temp Variable GCODE"

    Public Property _pGRANGE_QTY() As Double
        Get
            Return _mGRANGE_QTY
        End Get
        Set(ByVal value As Double)
            _mGRANGE_QTY = value
        End Set
    End Property

    Public Property _pGCHOICE1() As Integer
        Get
            Return _mGCHOICE1
        End Get
        Set(ByVal value As Integer)
            _mGCHOICE1 = value
        End Set
    End Property

    Public Property _pGCHOICE2() As Integer
        Get
            Return _mGCHOICE2
        End Get
        Set(ByVal value As Integer)
            _mGCHOICE2 = value
        End Set
    End Property

    Public Property _pGCHOICE3() As Integer
        Get
            Return _mGCHOICE3
        End Get
        Set(ByVal value As Integer)
            _mGCHOICE3 = value
        End Set
    End Property

    Public Property _pGCHOICE4() As Integer
        Get
            Return _mGCHOICE4
        End Get
        Set(ByVal value As Integer)
            _mGCHOICE4 = value
        End Set
    End Property

    Public Property _pGQTY() As Double
        Get
            Return _mGQTY
        End Get
        Set(ByVal value As Double)
            _mGQTY = value
        End Set
    End Property

    Public Property _pGQTY1() As Double
        Get
            Return _mGQTY1
        End Get
        Set(ByVal value As Double)
            _mGQTY1 = value
        End Set
    End Property

    Public Property _pGQTY2() As Double
        Get
            Return _mGQTY2
        End Get
        Set(ByVal value As Double)
            _mGQTY2 = value
        End Set
    End Property

    Public Property _pGQTY3() As Double
        Get
            Return _mGQTY3
        End Get
        Set(ByVal value As Double)
            _mGQTY3 = value
        End Set
    End Property

    Public Property _pGQTY4() As Double
        Get
            Return _mGQTY4
        End Get
        Set(ByVal value As Double)
            _mGQTY4 = value
        End Set
    End Property

    Public Property _pGQTY5() As Double
        Get
            Return _mGQTY5
        End Get
        Set(ByVal value As Double)
            _mGQTY5 = value
        End Set
    End Property

    Public Property _pGQTY6() As Double
        Get
            Return _mGQTY6
        End Get
        Set(ByVal value As Double)
            _mGQTY6 = value
        End Set
    End Property

    Public Property _pGQTY7() As Double
        Get
            Return _mGQTY7
        End Get
        Set(ByVal value As Double)
            _mGQTY7 = value
        End Set
    End Property

    Public Property _pGQTY8() As Double
        Get
            Return _mGQTY8
        End Get
        Set(ByVal value As Double)
            _mGQTY8 = value
        End Set
    End Property

    Public Property _pGQTY9() As Double
        Get
            Return _mGQTY9
        End Get
        Set(ByVal value As Double)
            _mGQTY9 = value
        End Set
    End Property

    Public Property _pGQTY10() As Double
        Get
            Return _mGQTY10
        End Get
        Set(ByVal value As Double)
            _mGQTY10 = value
        End Set
    End Property

#End Region

#Region "temp Variable SCODE"

    Public Property _pSRANGE_QTY() As Double
        Get
            Return _mSRANGE_QTY
        End Get
        Set(ByVal value As Double)
            _mSRANGE_QTY = value
        End Set
    End Property

    Public Property _pSCHOICE1() As Integer
        Get
            Return _mSCHOICE1
        End Get
        Set(ByVal value As Integer)
            _mSCHOICE1 = value
        End Set
    End Property

    Public Property _pSCHOICE2() As Integer
        Get
            Return _mSCHOICE2
        End Get
        Set(ByVal value As Integer)
            _mSCHOICE2 = value
        End Set
    End Property

    Public Property _pSCHOICE3() As Integer
        Get
            Return _mSCHOICE3
        End Get
        Set(ByVal value As Integer)
            _mSCHOICE3 = value
        End Set
    End Property

    Public Property _pSCHOICE4() As Integer
        Get
            Return _mSCHOICE4
        End Get
        Set(ByVal value As Integer)
            _mSCHOICE4 = value
        End Set
    End Property

    Public Property _pSQTY() As Double
        Get
            Return _mSQTY
        End Get
        Set(ByVal value As Double)
            _mSQTY = value
        End Set
    End Property

    Public Property _pSQTY1() As Double
        Get
            Return _mSQTY1
        End Get
        Set(ByVal value As Double)
            _mSQTY1 = value
        End Set
    End Property

    Public Property _pSQTY2() As Double
        Get
            Return _mSQTY2
        End Get
        Set(ByVal value As Double)
            _mSQTY2 = value
        End Set
    End Property

    Public Property _pSQTY3() As Double
        Get
            Return _mSQTY3
        End Get
        Set(ByVal value As Double)
            _mSQTY3 = value
        End Set
    End Property

    Public Property _pSQTY4() As Double
        Get
            Return _mSQTY4
        End Get
        Set(ByVal value As Double)
            _mSQTY4 = value
        End Set
    End Property

    Public Property _pSQTY5() As Double
        Get
            Return _mSQTY5
        End Get
        Set(ByVal value As Double)
            _mSQTY5 = value
        End Set
    End Property

    Public Property _pSQTY6() As Double
        Get
            Return _mSQTY6
        End Get
        Set(ByVal value As Double)
            _mSQTY6 = value
        End Set
    End Property

    Public Property _pSQTY7() As Double
        Get
            Return _mSQTY7
        End Get
        Set(ByVal value As Double)
            _mSQTY7 = value
        End Set
    End Property

    Public Property _pSQTY8() As Double
        Get
            Return _mSQTY8
        End Get
        Set(ByVal value As Double)
            _mSQTY8 = value
        End Set
    End Property

    Public Property _pSQTY9() As Double
        Get
            Return _mSQTY9
        End Get
        Set(ByVal value As Double)
            _mSQTY9 = value
        End Set
    End Property

    Public Property _pSQTY10() As Double
        Get
            Return _mSQTY10
        End Get
        Set(ByVal value As Double)
            _mSQTY10 = value
        End Set
    End Property

#End Region

#Region "Temp Variable FCODE"
    Public Property _pFRANGE_QTY() As Double
        Get
            Return _mFRANGE_QTY
        End Get
        Set(ByVal value As Double)
            _mFRANGE_QTY = value
        End Set
    End Property

    Public Property _pFCHOICE1() As Integer
        Get
            Return _mFCHOICE1
        End Get
        Set(ByVal value As Integer)
            _mFCHOICE1 = value
        End Set
    End Property

    Public Property _pFCHOICE2() As Integer
        Get
            Return _mFCHOICE2
        End Get
        Set(ByVal value As Integer)
            _mFCHOICE2 = value
        End Set
    End Property

    Public Property _pFCHOICE3() As Integer
        Get
            Return _mFCHOICE3
        End Get
        Set(ByVal value As Integer)
            _mFCHOICE3 = value
        End Set
    End Property

    Public Property _pFCHOICE4() As Integer
        Get
            Return _mFCHOICE4
        End Get
        Set(ByVal value As Integer)
            _mFCHOICE4 = value
        End Set
    End Property

    Public Property _pFQTY() As Double
        Get
            Return _mFQTY
        End Get
        Set(ByVal value As Double)
            _mFQTY = value
        End Set
    End Property

    Public Property _pFQTY1() As Double
        Get
            Return _mFQTY1
        End Get
        Set(ByVal value As Double)
            _mFQTY1 = value
        End Set
    End Property

    Public Property _pFQTY2() As Double
        Get
            Return _mFQTY2
        End Get
        Set(ByVal value As Double)
            _mFQTY2 = value
        End Set
    End Property

    Public Property _pFQTY3() As Double
        Get
            Return _mFQTY3
        End Get
        Set(ByVal value As Double)
            _mFQTY3 = value
        End Set
    End Property

    Public Property _pFQTY4() As Double
        Get
            Return _mFQTY4
        End Get
        Set(ByVal value As Double)
            _mFQTY4 = value
        End Set
    End Property

    Public Property _pFQTY5() As Double
        Get
            Return _mFQTY5
        End Get
        Set(ByVal value As Double)
            _mFQTY5 = value
        End Set
    End Property

    Public Property _pFQTY6() As Double
        Get
            Return _mFQTY6
        End Get
        Set(ByVal value As Double)
            _mFQTY6 = value
        End Set
    End Property

    Public Property _pFQTY7() As Double
        Get
            Return _mFQTY7
        End Get
        Set(ByVal value As Double)
            _mFQTY7 = value
        End Set
    End Property

    Public Property _pFQTY8() As Double
        Get
            Return _mFQTY8
        End Get
        Set(ByVal value As Double)
            _mFQTY8 = value
        End Set
    End Property

    Public Property _pFQTY9() As Double
        Get
            Return _mFQTY9
        End Get
        Set(ByVal value As Double)
            _mFQTY9 = value
        End Set
    End Property

    Public Property _pFQTY10() As Double
        Get
            Return _mFQTY10
        End Get
        Set(ByVal value As Double)
            _mFQTY10 = value
        End Set
    End Property
#End Region

#Region "Properties Field"

    Public Property _pRowNo() As String
        Get
            Return _mRowNo
        End Get
        Set(ByVal value As String)
            _mRowNo = value
        End Set
    End Property

    Public Property _pTaxDesc2() As String
        Get
            Return _mTaxDesc2
        End Get
        Set(ByVal value As String)
            _mTaxDesc2 = value
        End Set
    End Property

    Public Property _pTaxDesc() As String
        Get
            Return _mTaxDesc
        End Get
        Set(ByVal value As String)
            _mTaxDesc = value
        End Set
    End Property

    Public Property _pTaxRate() As Double
        Get
            Return _mTaxRate
        End Get
        Set(ByVal value As Double)
            _mTaxRate = value
        End Set
    End Property

    Public Property _pTaxAmt() As Double
        Get
            Return _mTaxAmt
        End Get
        Set(ByVal value As Double)
            _mTaxAmt = value
        End Set
    End Property

    Public Property _pTaxCode() As String
        Get
            Return _mTaxCode
        End Get
        Set(ByVal value As String)
            _mTaxCode = value
        End Set
    End Property

    Public Property _pASKHDG_Month() As String  ' 20170718
        Get
            Return _mASKHDG_Month
        End Get
        Set(ByVal value As String)
            _mASKHDG_Month = value
        End Set
    End Property

    Public Property _pASKHDG_Year() As String ' 20170718
        Get
            Return _mASKHDG_Year
        End Get
        Set(ByVal value As String)
            _mASKHDG_Year = value
        End Set
    End Property

    Public Property _pBusLineCol() As String
        Get
            Return _mBusLineCol
        End Get
        Set(ByVal value As String)
            _mBusLineCol = value
        End Set
    End Property

    Public Property _pTblCode() As String
        Get
            Return _mTblCode
        End Get
        Set(ByVal value As String)
            _mTblCode = value
        End Set
    End Property

    Public Property _pInputVal() As String
        Get
            Return _mInputVal
        End Get
        Set(ByVal value As String)
            _mInputVal = value
        End Set
    End Property

    Public Property _pAccount() As String
        Get
            Return _mAccount
        End Get
        Set(ByVal value As String)
            _mAccount = value
        End Set
    End Property

    Public Property _pnBusCode() As String
        Get
            Return _mnBusCode
        End Get
        Set(ByVal value As String)
            _mnBusCode = value
        End Set
    End Property


    Public Property _pBusCode() As String
        Get
            Return _mBusCode
        End Get
        Set(ByVal value As String)
            _mBusCode = value
        End Set
    End Property

    Public Property _pBusDesc() As String
        Get
            Return _mBusDesc
        End Get
        Set(ByVal value As String)
            _mBusDesc = value
        End Set
    End Property

    Public Property _pBusYear() As String
        Get
            Return _mBusYear
        End Get
        Set(ByVal value As String)
            _mBusYear = value
        End Set
    End Property

    Public Property _pBusGrossRec() As String
        Get
            Return _mBusGrossRec
        End Get
        Set(ByVal value As String)
            _mBusGrossRec = value
        End Set
    End Property

    Public Property _pBusCap() As String
        Get
            Return _mBusCap
        End Get
        Set(ByVal value As String)
            _mBusCap = value
        End Set
    End Property

    Public Property _pBusArea() As String
        Get
            Return _mBusArea
        End Get
        Set(ByVal value As String)
            _mBusArea = value
        End Set
    End Property

    Public Property _pBusNRC() As String
        Get
            Return _mBusNRC
        End Get
        Set(ByVal value As String)
            _mBusNRC = value
        End Set
    End Property

    Public Property _pBusListSearch() As String
        Get
            Return _mBusListSearch
        End Get
        Set(ByVal value As String)
            _mBusListSearch = value
        End Set
    End Property

    Public Property _pBusDistCode() As String
        Get
            Return _mBusDistCode
        End Get
        Set(ByVal value As String)
            _mBusDistCode = value
        End Set
    End Property

    Public Property _pBusBRGYCode() As String
        Get
            Return _mBusBRGYCode
        End Get
        Set(ByVal value As String)
            _mBusBRGYCode = value
        End Set
    End Property

    Public Property _pTaxCode2() As String
        Get
            Return _mTaxCode2
        End Get
        Set(ByVal value As String)
            _mTaxCode2 = value
        End Set
    End Property

    Public Property _pEff_Year() As String
        Get
            Return _mEff_Year
        End Get
        Set(ByVal value As String)
            _mEff_Year = value
        End Set
    End Property

    Public Property _pEff_Month() As String
        Get
            Return _mEff_Month
        End Get
        Set(ByVal value As String)
            _mEff_Month = value
        End Set
    End Property

    Public Property _pGradYear() As String
        Get
            Return _mGradYear
        End Get
        Set(ByVal value As String)
            _mGradYear = value
        End Set
    End Property

    Public Property _pGradMonth() As String
        Get
            Return _mGradMonth
        End Get
        Set(ByVal value As String)
            _mGradMonth = value
        End Set
    End Property

    Public Property _pGradTaxMin() As Double
        Get
            Return _mGradTaxMin
        End Get
        Set(ByVal value As Double)
            _mGradTaxMin = value
        End Set
    End Property

    Public Property _pGradTaxMax() As Double
        Get
            Return _mGradTaxMax
        End Get
        Set(ByVal value As Double)
            _mGradTaxMax = value
        End Set
    End Property

#End Region

    Public Property _pStatMain() As String
        Get
            Return _mStatMain
        End Get
        Set(ByVal value As String)
            _mStatMain = value
        End Set
    End Property

    Public Property _pDate_Estab() As Date
        Get
            Return _mDate_Estab
        End Get
        Set(ByVal value As Date)
            _mDate_Estab = value
        End Set
    End Property

#Region "Output Question"

    Public Property _pTaxAmt1() As Double
        Get
            Return _mTaxAmt1
        End Get
        Set(ByVal value As Double)
            _mTaxAmt1 = value
        End Set
    End Property

    Public Property _pTaxAmt2() As Double
        Get
            Return _mTaxAmt2
        End Get
        Set(ByVal value As Double)
            _mTaxAmt2 = value
        End Set
    End Property

    Public Property _pTaxAmt3() As Double
        Get
            Return _mTaxAmt3
        End Get
        Set(ByVal value As Double)
            _mTaxAmt3 = value
        End Set
    End Property

    Public Property _pTaxAmt4() As Double
        Get
            Return _mTaxAmt4
        End Get
        Set(ByVal value As Double)
            _mTaxAmt4 = value
        End Set
    End Property

    Public Property _pTaxAmt5() As Double
        Get
            Return _mTaxAmt5
        End Get
        Set(ByVal value As Double)
            _mTaxAmt5 = value
        End Set
    End Property

    Public Property _pTaxAmt6() As Double
        Get
            Return _mTaxAmt6
        End Get
        Set(ByVal value As Double)
            _mTaxAmt6 = value
        End Set
    End Property

    Public Property _pTaxAmt7() As Double
        Get
            Return _mTaxAmt7
        End Get
        Set(ByVal value As Double)
            _mTaxAmt7 = value
        End Set
    End Property

    Public Property _pTaxAmt8() As Double
        Get
            Return _mTaxAmt8
        End Get
        Set(ByVal value As Double)
            _mTaxAmt8 = value
        End Set
    End Property

    Public Property _pTaxAmt9() As Double
        Get
            Return _mTaxAmt9
        End Get
        Set(ByVal value As Double)
            _mTaxAmt9 = value
        End Set
    End Property

    Public Property _pTaxAmt10() As Double
        Get
            Return _mTaxAmt10
        End Get
        Set(ByVal value As Double)
            _mTaxAmt10 = value
        End Set
    End Property

    Public Property _pOutputRec1() As String
        Get
            Return _mOutputRec1
        End Get
        Set(ByVal value As String)
            _mOutputRec1 = value
        End Set
    End Property

    Public Property _pOutputRec2() As String
        Get
            Return _mOutputRec2
        End Get
        Set(ByVal value As String)
            _mOutputRec2 = value
        End Set
    End Property

    Public Property _pOutputRec3() As String
        Get
            Return _mOutputRec3
        End Get
        Set(ByVal value As String)
            _mOutputRec3 = value
        End Set
    End Property

    Public Property _pOutputRec4() As String
        Get
            Return _mOutputRec4
        End Get
        Set(ByVal value As String)
            _mOutputRec4 = value
        End Set
    End Property

    Public Property _pOutputRec5() As String
        Get
            Return _mOutputRec5
        End Get
        Set(ByVal value As String)
            _mOutputRec5 = value
        End Set
    End Property

    Public Property _pOutputRec6() As String
        Get
            Return _mOutputRec6
        End Get
        Set(ByVal value As String)
            _mOutputRec6 = value
        End Set
    End Property

    Public Property _pOutputRec7() As String
        Get
            Return _mOutputRec7
        End Get
        Set(ByVal value As String)
            _mOutputRec7 = value
        End Set
    End Property

    Public Property _pOutputRec8() As String
        Get
            Return _mOutputRec8
        End Get
        Set(ByVal value As String)
            _mOutputRec8 = value
        End Set
    End Property

    Public Property _pOutputRec9() As String
        Get
            Return _mOutputRec9
        End Get
        Set(ByVal value As String)
            _mOutputRec9 = value
        End Set
    End Property

    Public Property _pOutputRec10() As String
        Get
            Return _mOutputRec10
        End Get
        Set(ByVal value As String)
            _mOutputRec10 = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"


#End Region

#Region "Routine Command"

    Public Sub _pSubSelectReqList()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery =
            "SELECT REQCODE, REQDESC FROM [BP_ReqList_Setup] "

            ''"SELECT " & _
            ''"REQCODE, REQDESC " & _
            ''"FROM [REQ1] " & _
            '' " "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                ' _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pGetAIF_Desc()  ' Added 20170812
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery =
                "select *, " & _
                    "(select fdesc from labels where fname = isnull(BUSCODE.EPOfname,'')) as EPO, " & _
                    "(select fdesc from labels where fname = isnull(BUSCODE.EIFfname,'')) as EIF, " & _
                    "(select fdesc from labels where fname = isnull(BUSCODE.PLATEfname,'')) as PLATE " & _
                    "from BUSCODE "
            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "where BUS_CODE = @_mBusCode "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mBusCode", _mBusCode)

            End With
            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

    Public Sub _pSubSelectCountBusline()    ' @ Added 20170825 Louie

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery =
                "SELECT * FROM BUSLINE "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = '" & _mAccount & "' and foryear ='" & _mBusYear & "'"
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                '   If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            End With
            _mSqlCommand.Dispose()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectBusFee(ByVal xAcctNo As String, ByVal xYear As String, ByVal xBusCode As String)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery =
                "SELECT" & _
                " isnull(BUSTAX,0) as BUSTAX,isnull(MAYORS,0) as MAYORS,isnull(GARBAGE,0) as GARBAGE,isnull(SANITARY,0) as SANITARY,isnull(FIRE,0) as FIRE " & _
                " FROM BUSLINE " & _
                " WHERE ACCTNO = '" & xAcctNo & "' AND FORYEAR = '" & xYear & "' and BUS_CODE = '" & xBusCode & "'"

            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters
            '    If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            '    If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            'End With
            _mSqlCommand.Dispose()
            '----------------------------------




        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelect()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog
            ' @ Modified 20170913  Louie -- Add ImageCounter 

            '----------------------------------
            _nQuery =
            "SELECT" & _
            " BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, BL.BUSTAX, BL.MAYORS,BL.SANITARY,BL.GARBAGE,BL.FIRE, BL.STATCODE,CASE WHEN ISNULL(BL.ISPRCS,0) = 0 then '' else 'DONE' end ISPRCS" & _
            " FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BUSLINE] AS BL " & _
            " INNER JOIN [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[BUSCODE] AS BC" & _
            " ON BL.BUS_CODE = BC.BUS_CODE COLLATE DATABASE_DEFAULT " & _
            " "
            '   "SELECT" & _
            '" BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, BL.STATCODE" & _
            '" FROM [BusinessLineInfo] AS BL " & _
            '" INNER JOIN [BusinessLine_Setup] AS BC" & _
            '" ON BL.BUS_CODE = BC.BUS_CODE " & _
            '" "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = " WHERE BL.ACCTNO = '" & _mAccount & "' COLLATE DATABASE_DEFAULT AND ISNULL(BL.NEWSW,0) <> 1 "
            Else
                _nWhere = " WHERE BL.ACCTNO = ''"
            End If


            _nOrderBy = " ORDER BY FORYEAR DESC"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                '   If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            End With
            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectForRenewal()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            _nQuery =
            "SELECT" & _
            " BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, BL.BUSTAX, BL.MAYORS,BL.SANITARY,BL.GARBAGE,BL.FIRE, BL.STATCODE,CASE WHEN ISNULL(BL.ISPRCS,0) = 0 then '' else 'DONE' end ISPRCS" & _
            " FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BUSLINE] AS BL " & _
            " INNER JOIN [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[BUSCODE] AS BC" & _
            " ON BL.BUS_CODE = BC.BUS_CODE COLLATE DATABASE_DEFAULT  " & _
            " "

            '"SELECT" & _
            '" BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, BL.STATCODE" & _
            '" FROM [BusinessLineInfo] AS BL " & _
            '" INNER JOIN [BusinessLine_Setup] AS BC" & _
            '" ON BL.BUS_CODE = BC.BUS_CODE " & _
            '" "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE BL.ACCTNO  COLLATE DATABASE_DEFAULT = '" & _mAccount & "' AND ISNULL(BL.NEWSW,0) <> 1 AND isnull(xDeleq,0)  <> 1  AND FORYEAR = (SELECT YEAR(GETDATE()) as YR)"
            Else
                _nWhere = " WHERE BL.ACCTNO = 'xxx'"
            End If

            _nOrderBy = " ORDER BY FORYEAR DESC"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                '   If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            End With
            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectReview()    ' @Added 20170410
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    

            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            _nQuery =
            "SELECT" & _
            " BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, BL.STATCODE" & _
            " FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BUSLINE] AS BL " & _
            " INNER JOIN [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[BUSCODE] AS BC" & _
            " ON BL.BUS_CODE = BC.BUS_CODE COLLATE DATABASE_DEFAULT " & _
            " "
            '"SELECT" & _
            '" BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, BL.STATCODE" & _
            '" FROM [BusinessLineInfo] AS BL " & _
            '" INNER JOIN [BusinessLine_Setup] AS BC" & _
            '" ON BL.BUS_CODE = BC.BUS_CODE " & _
            '" "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE BL.ACCTNO =  '" & _mAccount & "' COLLATE DATABASE_DEFAULT and foryear = '" & _mBusYear & "'"
            Else
                _nWhere = "WHERE BL.ACCTNO = 'xxx'"
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                'If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            End With

            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectBuslineRecord()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery =
            "SELECT isnull(BUSTAX,0) as BUSTAX,isnull(MAYORS,0) as MAYORS,isnull(GARBAGE,0) as GARBAGE,isnull(SANITARY,0) as SANITARY,  isnull(FIRE,0) as FIRE  FROM BUSLINE " & _
            " "


            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = @_mAccount  AND FORYEAR = @_mBusYear and BUS_CODE = @_mBusCode "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub




    Public Sub _pSubPrint()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nClBP2 As New cDalGlobalConnectionsDefault

            _nClBP2._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP2._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBP2._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nWebServerName As String = _nClBP2._pDBDataSource

            '_mAccount = "170320-00001"
            '----------------------------------
            '@ Modified 20170320    Louie
            _nQuery = _
            "SELECT DISTINCT GETDATE() as CURRENTDATE, BI.APP_DATE, BI.ACCTNO,BI.STATCODE, BI.LAST_NAME, BI.FIRST_NAME, BI.MIDDLE_NAME, " & _
            "BI.COMMADDR, BI.CONTTEL, BI.TIN_NO, BI.DTI_NO, BI.DTI_DATE, BI.OWNERTEL, BI.OWNERADDR, BI.COMMNAME, " & _
            "BI.OWNCODE, BI.P_OWNER, BI.P_OWNERADDR, BI.P_ADMIN, BI.P_RENTDATE, BI.P_RENT, BIE.PRES_NAME, " & _
            "BIE.AUTHO_REP, BIE.NO_EMP_F, BIE.NO_EMP_M, BLS.[DESCRIPTION], BLI.AREA, BLI.CAPITAL, BLI.GROSSREC, (SELECT LGU_ADDRESS FROM [" & _nWebServerName & "].[R&D.CR].dbo.LGU_Profile ) as LGU_Address " & _
            "FROM BUSMAST AS BI " & _
            "INNER JOIN BUSMASTEXTN AS BIE " & _
            "ON BI.ACCTNO = BIE.ACCTNO " & _
            "INNER JOIN BUSLINE AS BLI " & _
            "ON BI.ACCTNO = BLI.ACCTNO  " & _
            "INNER JOIN BUSEXTN AS BLE " & _
            "ON BLI.ACCTNO = BLE.ACCTNO " & _
            "INNER JOIN [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.BUSCODE AS BLS " & _
            "ON BLI.BUS_CODE = BLS.BUS_CODE COLLATE DATABASE_DEFAULT "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE BI.ACCTNO = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With
            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubPrintRenewal()  ' @ Added 20171229
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()


            Dim _nClBP2 As New cDalGlobalConnectionsDefault

            _nClBP2._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP2._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBP2._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog
            Dim _nWebServerName As String = _nClBP2._pDBDataSource

            '_mAccount = "170320-00001"
            '----------------------------------
            '@ Modified 20170320    Louie
            _nQuery = _
            "SELECT DISTINCT GETDATE() as APP_DATE, BI.ACCTNO,BI.STATCODE, BI.LAST_NAME, BI.FIRST_NAME, BI.MIDDLE_NAME, " & _
            "BI.COMMADDR, BI.CONTTEL, BI.TIN_NO, BI.DTI_NO, BI.DTI_DATE, BI.OWNERTEL, BI.OWNERADDR, BI.COMMNAME, " & _
            "BI.OWNCODE, BI.P_OWNER, BI.P_OWNERADDR, BI.P_ADMIN, BI.P_RENTDATE, BI.P_RENT, BIE.PRES_NAME, " & _
            "BIE.AUTHO_REP, BIE.NO_EMP_F, BIE.NO_EMP_M, BLS.[DESCRIPTION], BLI.AREA, BLI.CAPITAL, BLI.GROSSREC, (SELECT LGU_ADDRESS FROM [" & _nWebServerName & "].[R&D.CR].dbo.LGU_Profile ) as LGU_Address  " & _
            "FROM BUSMAST AS BI " & _
            "INNER JOIN BUSMASTEXTN AS BIE " & _
            "ON BI.ACCTNO = BIE.ACCTNO " & _
            "INNER JOIN BUSLINE AS BLI " & _
            "ON BI.ACCTNO = BLI.ACCTNO  " & _
            "INNER JOIN BUSEXTN AS BLE " & _
            "ON BLI.ACCTNO = BLE.ACCTNO " & _
            "INNER JOIN [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[BUSCODE] AS BLS " & _
            "ON BLI.BUS_CODE = BLS.BUS_CODE COLLATE DATABASE_DEFAULT "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE BI.ACCTNO = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With
            _mSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectList()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nSort As String = Nothing

            '----------------------------------    
            _nQuery =
            "SELECT BUS_CODE, [DESCRIPTION], BCODE, MCODE, GCODE, SCODE, FCODE FROM [BUSCODE]  "
            ' "SELECT BUS_CODE, [DESCRIPTION], BCODE, MCODE, GCODE, SCODE, FCODE FROM [BusinessLine_Setup]  "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mBusListSearch) Then

                _nWhere = "WHERE [DESCRIPTION] like '%" & _mBusListSearch & "%' AND LEFT([DESCRIPTION],1)<> '*' AND  LEFT([DESCRIPTION],1)<> '.' "
            Else
                _nWhere = "WHERE LEFT([DESCRIPTION],1)<> '*' AND  LEFT([DESCRIPTION],1)<> '.' " '@  Modified 20170628
            End If
            '
            _nSort = " ORDER BY [DESCRIPTION]"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nSort

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusListSearch) Then .AddWithValue("@_mBusListSearch", _mBusListSearch)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectBusLineEntry()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
            "SELECT * FROM [BUSLINE] "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = @_mAccount AND FORYEAR = @_mBusYear AND BUS_CODE = @_mBusCode "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAll__BUSLINE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
            "SELECT * FROM [BUSLINE] "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = @_mAccount AND FORYEAR = @_mBusYear AND BUS_CODE = @_mBusCode "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_BUSLINE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
            "SELECT ACCTNO, FORYEAR, BUS_CODE FROM [BUSLINE] "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = '" & _mAccount & "' AND FORYEAR = '" & _mBusYear & "' AND BUS_CODE = '" & _mBusCode & "' "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_BUSLINE_CHOICE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    
            _nQuery = _
            "Select BCHOICE1,BCHOICE2,BCHOICE3,BCHOICE4," & _
                    "MCHOICE1, MCHOICE2, MCHOICE3, MCHOICE4," & _
                    "GCHOICE1, GCHOICE2, GCHOICE3, GCHOICE4," & _
                    "SCHOICE1, SCHOICE2, SCHOICE3, SCHOICE4," & _
                    "FCHOICE1, FCHOICE2, FCHOICE3, FCHOICE4" & _
            " FROM [BUSLINE] "
            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = @_mAccount AND FORYEAR = @_mBusYear AND BUS_CODE = @_mBusCode "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_BUSLINE_Has()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
            "SELECT ACCTNO, FORYEAR, BUS_CODE FROM [BUSLINE] "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = @_mAccount"
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteFrom_BUSMAST_WEB_Temp()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "DELETE FROM [BUSMAST] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteFrom_BUSMASTEXTN_WEB_Temp()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "DELETE FROM [BUSMASTEXTN_WEB_Temp] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteFrom_BUS_REQUIREMENTS_WEB_TEMP()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "DELETE FROM [BUS_REQUIREMENTS_WEB_Temp] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertInto_BUSMASTEXTN_WEB()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO [BUSMASTEXTN_WEB] " & _
                    "SELECT * FROM [BUSMASTEXTN_WEB_Temp] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertInto_BUS_REQUIREMENTS_WEB()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO [BUS_REQUIREMENTS_WEB] " & _
                    "SELECT * FROM [BUS_REQUIREMENTS_WEB_TEMP] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubSelect_BusCode_TaxCode()    '@ Added 20170706
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery =
                "Select BUS_CODE, [DESCRIPTION], CATEGORY,BCODE, MCODE, GCODE, SCODE, FCODE" & _
                    " from BUSCODE"
            '"Select BUS_CODE, [DESCRIPTION], CATEGORY,BCODE, MCODE, GCODE, SCODE, FCODE" & _
            '       " from BusinessLine_Setup"

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = " WHERE BUS_CODE = @_mBusCode "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                'If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                'If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pChckBusline()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = "SELECT * FROM BUSLINE " & _
            " "
            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = @_mAccount AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSaveSelectedOption_BCHOICE()   ' @ Added 20170703
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = "UPDATE BUSLINE SET " & _mCHOICE_Col & " = '" & _mBCHOICE_Row & "' "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = '" & _mAccount & "' AND [FORYEAR] = '" & _mBusYear & "' AND [BUS_CODE] = '" & _mBusCode & "'"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(IIf(_mBCHOICE_Row = Nothing, "0", _mBCHOICE_Row)) Then .AddWithValue("@_mBCHOICE_Row", IIf(_mBCHOICE_Row = Nothing, "0", _mBCHOICE_Row))
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSaveSelectedOption_MCHOICE()   ' @ Added 20170703
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "UPDATE BUSLINE SET " & _mCHOICE_Col & " = @_mMCHOICE_Row "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = @_mAccount AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(IIf(_mMCHOICE_Row = Nothing, "0", _mMCHOICE_Row)) Then .AddWithValue("@_mMCHOICE_Row", IIf(_mMCHOICE_Row = Nothing, "0", _mMCHOICE_Row))
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSaveSelectedOption_GCHOICE()   ' @ Added 20170703
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "UPDATE BUSLINE SET " & _mCHOICE_Col & " = @_mGCHOICE_Row "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = @_mAccount AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(IIf(_mGCHOICE_Row = Nothing, "0", _mGCHOICE_Row)) Then .AddWithValue("@_mGCHOICE_Row", IIf(_mGCHOICE_Row = Nothing, "0", _mGCHOICE_Row))
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSaveSelectedOption_SCHOICE()   ' @ Added 20170703
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "UPDATE BUSLINE SET " & _mCHOICE_Col & " = @_mSCHOICE_Row "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = @_mAccount AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(IIf(_mSCHOICE_Row = Nothing, "0", _mSCHOICE_Row)) Then .AddWithValue("@_mSCHOICE_Row", IIf(_mSCHOICE_Row = Nothing, "0", _mSCHOICE_Row))
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSaveSelectedOption_FCHOICE()   ' @ Added 20170703
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "UPDATE BUSLINE SET " & _mCHOICE_Col & " = @_mFCHOICE_Row "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = @_mAccount AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(IIf(_mFCHOICE_Row = Nothing, "0", _mFCHOICE_Row)) Then .AddWithValue("@_mFCHOICE_Row", IIf(_mFCHOICE_Row = Nothing, "0", _mFCHOICE_Row))
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateStatus()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "UPDATE BUSLINE SET ISPRCS = 1 Where ACCTNO ='" & _mAccount & "' and   BUS_CODE ='" & _mBusCode & "' and foryear = '" & _mBusYear & "'"


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            End With

            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSaveGatheredInfo()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            Dim _mPres As Integer = Nothing

            '_mPres = Format((Val(Format( _mDate_Estab ), "mm") / 3 + 0.2, "0")
            _mPres = (Month(_mDate_Estab) / 3) + 0.2
            ''xQtr = Val(_mPres)

            _nQuery =
                "UPDATE BUSLINE SET " & _
                "BRANGE_QTY = @_mBRANGE_QTY ,BQTY = @_mBQTY ,BQTY1 = @_mBQTY1 ,BQTY2 = @_mBQTY2 ,BQTY3 = @_mBQTY3 ,BQTY4 = @_mBQTY4 ,BQTY5 = @_mBQTY5 ,BQTY6 = @_mBQTY6 ,BQTY7 = @_mBQTY7 ,BQTY8 = @_mBQTY8 ,BQTY9 = @_mBQTY9 ,BQTY10 = @_mBQTY10 ," & _
                "MRANGE_QTY = @_mMRANGE_QTY ,MQTY = @_mMQTY ,MQTY1 = @_mMQTY1 ,MQTY2 = @_mMQTY2 ,MQTY3 = @_mMQTY3 ,MQTY4 = @_mMQTY4 ,MQTY5 = @_mMQTY5 ,MQTY6 = @_mMQTY6 ,MQTY7 = @_mMQTY7 ,MQTY8 = @_mMQTY8 ,MQTY9 = @_mMQTY9 ,MQTY10 = @_mMQTY10 ," & _
                "GRANGE_QTY = @_mGRANGE_QTY ,GQTY = @_mGQTY ,GQTY1 = @_mGQTY1 ,GQTY2 = @_mGQTY2 ,GQTY3 = @_mGQTY3 ,GQTY4 = @_mGQTY4 ,GQTY5 = @_mGQTY5 ,GQTY6 = @_mGQTY6 ,GQTY7 = @_mGQTY7 ,GQTY8 = @_mGQTY8 ,GQTY9 = @_mGQTY9 ,GQTY10 = @_mGQTY10 ," & _
                "SRANGE_QTY = @_mSRANGE_QTY ,SQTY = @_mSQTY ,SQTY1 = @_mSQTY1 ,SQTY2 = @_mSQTY2 ,SQTY3 = @_mSQTY3 ,SQTY4 = @_mSQTY4 ,SQTY5 = @_mSQTY5 ,SQTY6 = @_mSQTY6 ,SQTY7 = @_mSQTY7 ,SQTY8 = @_mSQTY8 ,SQTY9 = @_mSQTY9 ,SQTY10 = @_mSQTY10 ," & _
                "FRANGE_QTY = @_mFRANGE_QTY ,FQTY = @_mFQTY ,FQTY1 = @_mFQTY1 ,FQTY2 = @_mFQTY2 ,FQTY3 = @_mFQTY3 ,FQTY4 = @_mFQTY4 ,FQTY5 = @_mFQTY5 ,FQTY6 = @_mFQTY6 ,FQTY7 = @_mFQTY7 ,FQTY8 = @_mFQTY8 ,FQTY9 = @_mFQTY9 ,FQTY10 = @_mFQTY10 ," & _
                "MAYORS = @_mMAYORS ,GARBAGE = @_mGARBAGE, SANITARY = @_mSANITARY ,FIRE = @_mFIRE ,Garbage_O = @_mGarbage_O ,Sanitary_O = @_mSanitary_O ,FIRE_O = @_mFIRE_O ,Newsw = @_mNewsw, bqtrind = @_mPres ,gqtrind = @_mPres2 ," & _
                "ELECFEE= @_mELECfee,MECHFEE=@_mMECHfee,BLDGFEE= @_mBLDGFEE,SIGNFEE= @_mSIGNFEE ,EPOFEE=@_mEPOFEE,EIFFEE=@_mEIFFEE,PLATEFEE=@_mPLATfee "
            '"UPDATE BusinessLineInfo SET " & _
            '  "BRANGE_QTY = @_mBRANGE_QTY ,BQTY = @_mBQTY ,BQTY1 = @_mBQTY1 ,BQTY2 = @_mBQTY2 ,BQTY3 = @_mBQTY3 ,BQTY4 = @_mBQTY4 ,BQTY5 = @_mBQTY5 ,BQTY6 = @_mBQTY6 ,BQTY7 = @_mBQTY7 ,BQTY8 = @_mBQTY8 ,BQTY9 = @_mBQTY9 ,BQTY10 = @_mBQTY10 ," & _
            '  "MRANGE_QTY = @_mMRANGE_QTY ,MQTY = @_mMQTY ,MQTY1 = @_mMQTY1 ,MQTY2 = @_mMQTY2 ,MQTY3 = @_mMQTY3 ,MQTY4 = @_mMQTY4 ,MQTY5 = @_mMQTY5 ,MQTY6 = @_mMQTY6 ,MQTY7 = @_mMQTY7 ,MQTY8 = @_mMQTY8 ,MQTY9 = @_mMQTY9 ,MQTY10 = @_mMQTY10 ," & _
            '  "GRANGE_QTY = @_mGRANGE_QTY ,GQTY = @_mGQTY ,GQTY1 = @_mGQTY1 ,GQTY2 = @_mGQTY2 ,GQTY3 = @_mGQTY3 ,GQTY4 = @_mGQTY4 ,GQTY5 = @_mGQTY5 ,GQTY6 = @_mGQTY6 ,GQTY7 = @_mGQTY7 ,GQTY8 = @_mGQTY8 ,GQTY9 = @_mGQTY9 ,GQTY10 = @_mGQTY10 ," & _
            '  "SRANGE_QTY = @_mSRANGE_QTY ,SQTY = @_mSQTY ,SQTY1 = @_mSQTY1 ,SQTY2 = @_mSQTY2 ,SQTY3 = @_mSQTY3 ,SQTY4 = @_mSQTY4 ,SQTY5 = @_mSQTY5 ,SQTY6 = @_mSQTY6 ,SQTY7 = @_mSQTY7 ,SQTY8 = @_mSQTY8 ,SQTY9 = @_mSQTY9 ,SQTY10 = @_mSQTY10 ," & _
            '  "FRANGE_QTY = @_mFRANGE_QTY ,FQTY = @_mFQTY ,FQTY1 = @_mFQTY1 ,FQTY2 = @_mFQTY2 ,FQTY3 = @_mFQTY3 ,FQTY4 = @_mFQTY4 ,FQTY5 = @_mFQTY5 ,FQTY6 = @_mFQTY6 ,FQTY7 = @_mFQTY7 ,FQTY8 = @_mFQTY8 ,FQTY9 = @_mFQTY9 ,FQTY10 = @_mFQTY10 ," & _
            '  "MAYORS = @_mMAYORS ,GARBAGE = @_mGARBAGE, SANITARY = @_mSANITARY ,FIRE = @_mFIRE ,Garbage_O = @_mGarbage_O ,Sanitary_O = @_mSanitary_O ,FIRE_O = @_mFIRE_O ,Newsw = @_mNewsw, bqtrind = @_mPres ,gqtrind = @_mPres2"

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = " WHERE [ACCTNO] = @_mAccount AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)

                If Not String.IsNullOrWhiteSpace(_mBRANGE_QTY) Then .AddWithValue("@_mBRANGE_QTY", _mBRANGE_QTY)
                If Not String.IsNullOrWhiteSpace(_mBQTY) Then .AddWithValue("@_mBQTY", _mBQTY)
                If Not String.IsNullOrWhiteSpace(_mBQTY1) Then .AddWithValue("@_mBQTY1", _mBQTY1)
                If Not String.IsNullOrWhiteSpace(_mBQTY2) Then .AddWithValue("@_mBQTY2", _mBQTY2)
                If Not String.IsNullOrWhiteSpace(_mBQTY3) Then .AddWithValue("@_mBQTY3", _mBQTY3)
                If Not String.IsNullOrWhiteSpace(_mBQTY4) Then .AddWithValue("@_mBQTY4", _mBQTY4)
                If Not String.IsNullOrWhiteSpace(_mBQTY5) Then .AddWithValue("@_mBQTY5", _mBQTY5)
                If Not String.IsNullOrWhiteSpace(_mBQTY6) Then .AddWithValue("@_mBQTY6", _mBQTY6)
                If Not String.IsNullOrWhiteSpace(_mBQTY7) Then .AddWithValue("@_mBQTY7", _mBQTY7)
                If Not String.IsNullOrWhiteSpace(_mBQTY8) Then .AddWithValue("@_mBQTY8", _mBQTY8)
                If Not String.IsNullOrWhiteSpace(_mBQTY9) Then .AddWithValue("@_mBQTY9", _mBQTY9)
                If Not String.IsNullOrWhiteSpace(_mBQTY10) Then .AddWithValue("@_mBQTY10", _mBQTY10)

                If Not String.IsNullOrWhiteSpace(_mMRANGE_QTY) Then .AddWithValue("@_mMRANGE_QTY", _mMRANGE_QTY)
                If Not String.IsNullOrWhiteSpace(_mMQTY) Then .AddWithValue("@_mMQTY", _mMQTY)
                If Not String.IsNullOrWhiteSpace(_mMQTY1) Then .AddWithValue("@_mMQTY1", _mMQTY1)
                If Not String.IsNullOrWhiteSpace(_mMQTY2) Then .AddWithValue("@_mMQTY2", _mMQTY2)
                If Not String.IsNullOrWhiteSpace(_mMQTY3) Then .AddWithValue("@_mMQTY3", _mMQTY3)
                If Not String.IsNullOrWhiteSpace(_mMQTY4) Then .AddWithValue("@_mMQTY4", _mMQTY4)
                If Not String.IsNullOrWhiteSpace(_mMQTY5) Then .AddWithValue("@_mMQTY5", _mMQTY5)
                If Not String.IsNullOrWhiteSpace(_mMQTY6) Then .AddWithValue("@_mMQTY6", _mMQTY6)
                If Not String.IsNullOrWhiteSpace(_mMQTY7) Then .AddWithValue("@_mMQTY7", _mMQTY7)
                If Not String.IsNullOrWhiteSpace(_mMQTY8) Then .AddWithValue("@_mMQTY8", _mMQTY8)
                If Not String.IsNullOrWhiteSpace(_mMQTY9) Then .AddWithValue("@_mMQTY9", _mMQTY9)
                If Not String.IsNullOrWhiteSpace(_mMQTY10) Then .AddWithValue("@_mMQTY10", _mMQTY10)

                If Not String.IsNullOrWhiteSpace(_mGRANGE_QTY) Then .AddWithValue("@_mGRANGE_QTY", _mGRANGE_QTY)
                If Not String.IsNullOrWhiteSpace(_mGQTY) Then .AddWithValue("@_mGQTY", _mGQTY)
                If Not String.IsNullOrWhiteSpace(_mGQTY1) Then .AddWithValue("@_mGQTY1", _mGQTY1)
                If Not String.IsNullOrWhiteSpace(_mGQTY2) Then .AddWithValue("@_mGQTY2", _mGQTY2)
                If Not String.IsNullOrWhiteSpace(_mGQTY3) Then .AddWithValue("@_mGQTY3", _mGQTY3)
                If Not String.IsNullOrWhiteSpace(_mGQTY4) Then .AddWithValue("@_mGQTY4", _mGQTY4)
                If Not String.IsNullOrWhiteSpace(_mGQTY5) Then .AddWithValue("@_mGQTY5", _mGQTY5)
                If Not String.IsNullOrWhiteSpace(_mGQTY6) Then .AddWithValue("@_mGQTY6", _mGQTY6)
                If Not String.IsNullOrWhiteSpace(_mGQTY7) Then .AddWithValue("@_mGQTY7", _mGQTY7)
                If Not String.IsNullOrWhiteSpace(_mGQTY8) Then .AddWithValue("@_mGQTY8", _mGQTY8)
                If Not String.IsNullOrWhiteSpace(_mGQTY9) Then .AddWithValue("@_mGQTY9", _mGQTY9)
                If Not String.IsNullOrWhiteSpace(_mGQTY10) Then .AddWithValue("@_mGQTY10", _mGQTY10)

                If Not String.IsNullOrWhiteSpace(_mSRANGE_QTY) Then .AddWithValue("@_mSRANGE_QTY", _mSRANGE_QTY)
                If Not String.IsNullOrWhiteSpace(_mSQTY) Then .AddWithValue("@_mSQTY", _mSQTY)
                If Not String.IsNullOrWhiteSpace(_mSQTY1) Then .AddWithValue("@_mSQTY1", _mSQTY1)
                If Not String.IsNullOrWhiteSpace(_mSQTY2) Then .AddWithValue("@_mSQTY2", _mSQTY2)
                If Not String.IsNullOrWhiteSpace(_mSQTY3) Then .AddWithValue("@_mSQTY3", _mSQTY3)
                If Not String.IsNullOrWhiteSpace(_mSQTY4) Then .AddWithValue("@_mSQTY4", _mSQTY4)
                If Not String.IsNullOrWhiteSpace(_mSQTY5) Then .AddWithValue("@_mSQTY5", _mSQTY5)
                If Not String.IsNullOrWhiteSpace(_mSQTY6) Then .AddWithValue("@_mSQTY6", _mSQTY6)
                If Not String.IsNullOrWhiteSpace(_mSQTY7) Then .AddWithValue("@_mSQTY7", _mSQTY7)
                If Not String.IsNullOrWhiteSpace(_mSQTY8) Then .AddWithValue("@_mSQTY8", _mSQTY8)
                If Not String.IsNullOrWhiteSpace(_mSQTY9) Then .AddWithValue("@_mSQTY9", _mSQTY9)
                If Not String.IsNullOrWhiteSpace(_mSQTY10) Then .AddWithValue("@_mSQTY10", _mSQTY10)

                If Not String.IsNullOrWhiteSpace(_mFRANGE_QTY) Then .AddWithValue("@_mFRANGE_QTY", _mFRANGE_QTY)
                If Not String.IsNullOrWhiteSpace(_mFQTY) Then .AddWithValue("@_mFQTY", _mFQTY)
                If Not String.IsNullOrWhiteSpace(_mFQTY1) Then .AddWithValue("@_mFQTY1", _mFQTY1)
                If Not String.IsNullOrWhiteSpace(_mFQTY2) Then .AddWithValue("@_mFQTY2", _mFQTY2)
                If Not String.IsNullOrWhiteSpace(_mFQTY3) Then .AddWithValue("@_mFQTY3", _mFQTY3)
                If Not String.IsNullOrWhiteSpace(_mFQTY4) Then .AddWithValue("@_mFQTY4", _mFQTY4)
                If Not String.IsNullOrWhiteSpace(_mFQTY5) Then .AddWithValue("@_mFQTY5", _mFQTY5)
                If Not String.IsNullOrWhiteSpace(_mFQTY6) Then .AddWithValue("@_mFQTY6", _mFQTY6)
                If Not String.IsNullOrWhiteSpace(_mFQTY7) Then .AddWithValue("@_mFQTY7", _mFQTY7)
                If Not String.IsNullOrWhiteSpace(_mFQTY8) Then .AddWithValue("@_mFQTY8", _mFQTY8)
                If Not String.IsNullOrWhiteSpace(_mFQTY9) Then .AddWithValue("@_mFQTY9", _mFQTY9)
                If Not String.IsNullOrWhiteSpace(_mFQTY10) Then .AddWithValue("@_mFQTY10", _mFQTY10)

                If Not String.IsNullOrWhiteSpace(_mBUSTAX) Then .AddWithValue("@_mBUSTAX", _mBUSTAX)
                If Not String.IsNullOrWhiteSpace(_mMAYORS) Then .AddWithValue("@_mMAYORS", _mMAYORS)
                If Not String.IsNullOrWhiteSpace(_mGARBAGE) Then .AddWithValue("@_mGARBAGE", _mGARBAGE)
                If Not String.IsNullOrWhiteSpace(_mSANITARY) Then .AddWithValue("@_mSANITARY", _mSANITARY)
                If Not String.IsNullOrWhiteSpace(_mFIRE) Then .AddWithValue("@_mFIRE", _mFIRE)
                If Not String.IsNullOrWhiteSpace(_mGarbage_O) Then .AddWithValue("@_mGarbage_O", _mGarbage_O)
                If Not String.IsNullOrWhiteSpace(_mSanitary_O) Then .AddWithValue("@_mSanitary_O", _mSanitary_O)
                If Not String.IsNullOrWhiteSpace(_mFIRE_O) Then .AddWithValue("@_mFire_O", _mFIRE_O)
                If Not String.IsNullOrWhiteSpace(_mNewsw) Then .AddWithValue("@_mNewsw", _mNewsw)

                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mPres", _mPres) '@ Added 20170705
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mPres2", _mPres) '@ Added 20170705

                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mELECfee", _mELECfee)
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mMECHfee", _mMECHfee)
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mBLDGfee", _mBLDGfee)
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mSIGNfee", _mSIGNfee)
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mEPOfee", _mEPOfee)
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mEIFfee", _mEIFfee)
                If Not String.IsNullOrWhiteSpace(_mPres) Then .AddWithValue("@_mPLATfee", _mPLATfee)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUdateBusLineInfo() ' @ Added 201704010
        Try
            Dim _nQuery As String = Nothing 'Added 20161129
            Dim _nWhere As String = Nothing 'Added 20161129

            _nQuery =
            "UPDATE BUSLINE SET BUS_CODE = @_mnBusCode "
            '"UPDATE BusinessLineInfo SET BUS_CODE = @_mnBusCode "

            If Not String.IsNullOrWhiteSpace(_mAccount) And Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount  AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mnBusCode) Then .AddWithValue("@_mnBusCode", _mnBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub



    Public Sub _pSubInsertInto_BUSMAST_WEB()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO [BUSMAST_WEB] " & _
                    "SELECT * FROM [BUSMAST_WEB_Temp] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInserInto_BUSEXTN_WEB()
        Try
            Dim _nQuery As String = Nothing 'Added 20161129

            _nQuery =
            "INSERT INTO " & _
              "[BUSEXTN] " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " [ACCTNO]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", [FORYEAR]") & _
              ") " & _
              "VALUES " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " @_mAccount") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", @_mBusYear") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSEXTN_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusNRC) Then .AddWithValue("@_mAccount", _mBusNRC)
            End With

            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubDeleteFrom_BUSEXTN_WEB()
        Try
            Dim _nQuery As String = Nothing 'Added 20161129
            Dim _nWhere As String = Nothing 'Added 20161129

            _nQuery =
            "DELETE FROM [BUSEXTN] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = '" & _mAccount & "' AND [FORYEAR] ='" & _mBusYear & "'"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
            End With

            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubDeleteFrom_BUSLINE_WEB()
        Try
            Dim _nQuery As String = Nothing 'Added 20161129
            Dim _nWhere As String = Nothing 'Added 20161129

            _nQuery =
            "DELETE FROM [BUSLINE] "
            '"DELETE FROM [BusinessLineInfo] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = '" & _mAccount & "' AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = '" & _mBusCode & "'"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
            End With

            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubUpdateInto_BUSLINE_WEB()
        Try
            Dim _nQuery As String = Nothing

            Dim iArea As Double = _mBusArea
            _nQuery =
                " UPDATE BUSLINE SET  [AREA] = '" & iArea & "',CAPITAL =  '" & _mBusCap & "',GROSSREC= '" & _mBusGrossRec & "' ,FORYEAR ='" & _mBusYear & "'" & _
                " WHERE  ACCTNO ='" & _mAccount & "' AND BUS_CODE = '" & _mBusCode & "' AND FORYEAR ='" & _mBusYear & "'"
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSub_DeleteBuslineZeroVal()
        Try
            Dim _nQuery As String = Nothing 'Added 20171113

            _nQuery =
            "DELETE FROM BUSLINE WHERE  ISNULL(AREA,'') = '0' AND ISNULL(CAPITAL,'') = '0.00' AND ISNULL(GROSSREC,'')='0.00'"

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.ExecuteNonQuery()


        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubExe_DeleteBuslineNull()
        Try
            Dim _nQuery As String = Nothing 'Added 20170821

            _nQuery =
            "DELETE FROM BUSLINE WHERE ISNULL(BUS_CODE,'')= '' AND ISNULL(AREA,'') = '' AND ISNULL(CAPITAL,'') = '' AND ISNULL(GROSSREC,'')=''"

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.ExecuteNonQuery()


        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInserInto_BUSLINE_WEB()
        Try
            Dim _nQuery As String = Nothing 'Added 20161129

            _nQuery =
            "INSERT INTO " & _
              "[BUSLINE] " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " [ACCTNO]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", [FORYEAR]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusCode), "", ", [BUS_CODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusDistCode), "", ", [BRGYCODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusBRGYCode), "", ", [LOCACODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusArea), "", ", [AREA]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusCap), "", ", [CAPITAL]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusGrossRec), "", ", [GROSSREC]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusNRC), "", ", [STATCODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mDate_Estab), "", ", [DATE_ESTA]") & _
              ") " & _
              "VALUES " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " @_mAccount") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", @_mBusYear") & _
              IIf(String.IsNullOrWhiteSpace(_mBusCode), "", ", @_mBusCode") & _
              IIf(String.IsNullOrWhiteSpace(_mBusDistCode), "", ", @_mBusDistCode") & _
              IIf(String.IsNullOrWhiteSpace(_mBusBRGYCode), "", ", @_mBusBRGYCode") & _
              IIf(String.IsNullOrWhiteSpace(_mBusArea), "", ", @_mBusArea") & _
              IIf(String.IsNullOrWhiteSpace(_mBusCap), "", ", @_mBusCap") & _
              IIf(String.IsNullOrWhiteSpace(_mBusGrossRec), "", ", @_mBusGrossRec") & _
              IIf(String.IsNullOrWhiteSpace(_mBusNRC), "", ", @_mBusNRC") & _
              IIf(String.IsNullOrWhiteSpace(_mDate_Estab), "", ", @_mDate_Estab") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSLINE_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusDistCode) Then .AddWithValue("@_mBusDistCode", _mBusDistCode)
                If Not String.IsNullOrWhiteSpace(_mBusBRGYCode) Then .AddWithValue("@_mBusBRGYCode", _mBusBRGYCode)
                If Not String.IsNullOrWhiteSpace(_mBusArea) Then .AddWithValue("@_mBusArea", CInt(_mBusArea))
                If Not String.IsNullOrWhiteSpace(_mBusCap) Then .AddWithValue("@_mBusCap", _mBusCap)
                If Not String.IsNullOrWhiteSpace(_mBusGrossRec) Then .AddWithValue("@_mBusGrossRec", _mBusGrossRec)
                If Not String.IsNullOrWhiteSpace(_mBusNRC) Then .AddWithValue("@_mBusNRC", _mBusNRC)
                If Not String.IsNullOrWhiteSpace(_mDate_Estab) Then .AddWithValue("@_mDate_Estab", _mDate_Estab)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try



    End Sub



    Public Sub _pSubSelect_GRADTABL_BCODE()   ' @ Added 20170411
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRADTABL] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRADTABL] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GRADTABL] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode2))) "

                '"Where TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '       "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRADTABL] where EFF_YEAR IN " & _
                '       "(Select EFF_YEAR from [GRADTABL] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '       "and TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode2))) "


            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRRANGE()   ' @ Added 20170504
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------   
            _nQuery = _
                "Select * from [dbo].[GRRANGE] "
            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRRANGE] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GRRANGE] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode2))) "
                '"Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '       "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRRANGE] where EFF_YEAR IN " & _
                '       "(Select EFF_YEAR from [GRRANGE] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '       "and TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode2))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelect_GRADTABL_TaxCode2()   ' @ Added 20170509
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRADTABL] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then

                _nWhere = "WHERE TAXCODE = @_mTaxCode2 AND EFF_YEAR = " & _
                        " @_mEff_Year AND EFF_MONTH = @_mEff_Month "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then .AddWithValue("@_mTaxCode2", _mTaxCode2)
                If Not String.IsNullOrWhiteSpace(_mEff_Month) Then .AddWithValue("@_mEff_Month", _mEff_Month)
                If Not String.IsNullOrWhiteSpace(_mEff_Year) Then .AddWithValue("@_mEff_Year", _mEff_Year)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckGradTable()
        Try
            Dim _nStrSql As String = Nothing

            _nStrSql =
                " DECLARE @OutTAXCODE NVARCHAR(50) ," & _
                " @OutEFF_MONTH NVARCHAR(50) , " & _
                " @OutEFF_YEAR NVARCHAR(50) , " & _
                " @OutDESCRIPTION NVARCHAR(50) ,  " & _
                " @OutTAXRATE NUMERIC(18,2) ,  " & _
                " @OutTAXAMT NUMERIC(18,2) ,  " & _
                " @OutN_TAXRATE NUMERIC(18,2) ,  " & _
                " @OutN_TAXAMT NUMERIC(18,2) ,  " & _
                " @OutCOMPSW INT ,  " & _
                " @OutTAXMIN NUMERIC(18,2) ,  " & _
                " @OutTAXMAX NUMERIC(18,2) ,  " & _
                " @OutISDISCOUNT NVARCHAR(2)  ,  " & _
                " @OutGradFee as NUMERIC(18,2)  " & _
                " " & _
                " EXEC sp_CheckGradTable  " & _
                " @BusCode = '" & _mBusCode & "',  " & _
                " @BusArea = '" & IIf(_mBusArea = Nothing, 0, _mBusArea) & "',  " & _
                " @BusColName =  '" & _mBusLineCol & "',  " & _
                " @BusYear =  '" & _mBusYear & "',  " & _
                " @TAXCODE = @OutTAXCODE output,  " & _
                " @EFF_MONTH  = @OutEFF_MONTH  output,   " & _
                " @EFF_YEAR  = @OutEFF_YEAR output,   " & _
                " @DESCRIPTION  = @OutDESCRIPTION output,   " & _
                " @TAXRATE  = @OutTAXRATE output,   " & _
                " @TAXAMT  = @OutTAXAMT  output,  " & _
                " @N_TAXRATE  = @OutN_TAXRATE output,   " & _
                " @N_TAXAMT  = @OutN_TAXAMT output,   " & _
                " @COMPSW  =  @OutCOMPSW output,  " & _
                " @TAXMIN  =  @OutTAXMIN output,   " & _
                " @TAXMAX  =  @OutTAXMAX output,  " & _
                " @ISDISCOUNT  = @OutISDISCOUNT  output,  " & _
                " @GradFee  = @OutGradFee output  " & _
                " " & _
                " SELECT @OutTAXCODE as TAXCODE , @OutEFF_MONTH as EFF_MONTH , @OutEFF_YEAR as EFF_YEAR, @OutDESCRIPTION as [DESCRIPTION] ,  " & _
                " @OutTAXRATE as TAXRATE, @OutTAXAMT as TAXAMT, @OutN_TAXRATE as N_TAXRATE, @OutN_TAXAMT as N_TAXAMT, @OutCOMPSW as COMPSW,  " & _
                " @OutTAXMIN as TAXMIN, @OutTAXMAX as TAXMAX, @OutISDISCOUNT as ISDISCOUNT , @OutGradFee as GradFee  "


            '"DECLARE @OutGradTaxCode as NVARCHAR(50),@OutGradTaxAmt as NUMERIC(18,2) = 0 ,@OutGradTaxRate as NUMERIC(18,2) = 0 ,@OutGradYear as INT = 0 ," & _
            '        " @OutGradMonth as NVARCHAR(50) = null ,@OutGradTaxMin as NUMERIC(18,2) = 0 ,@OutGradTaxMax as NUMERIC(18,2) = 0 ,@OutGradFee as NUMERIC(18,2) = 0 " & _
            '        " EXEC sp_CheckGradTable " & _
            '        " @BusCode = '" & _mBusCode & "', " & _
            '        " @BusArea = '" & IIf(_mBusArea = Nothing, 0, _mBusArea) & "', " & _
            '        " @BusColName =  '" & _mBusLineCol & "'," & _
            '        " @BusYear =  '" & _mBusYear & "', " & _
            '        " @GradTaxCode = @OutGradTaxCode output ," & _
            '        " @GradTaxAmt = @OutGradTaxAmt output ," & _
            '        " @GradTaxRate = @OutGradTaxRate output ," & _
            '        " @GradYear = @OutGradYear output ," & _
            '        " @GradMonth = @OutGradMonth output ," & _
            '        " @GradTaxMin = @OutGradTaxMin output ," & _
            '        " @GradTaxMax = @OutGradTaxMax output ," & _
            '        " @GradFee = @OutGradFee output " & _
            '        " SELECT @OutGradTaxCode as GradTaxCode ,@OutGradTaxAmt as GradTaxAmt ,@OutGradTaxRate as GradTaxRate ,@OutGradYear as GradYear ," & _
            '        " @OutGradMonth as GradMonth ,@OutGradTaxMin as GradTaxMin ,@OutGradTaxMax as GradTaxMax ,@OutGradFee as GradFee "





            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            Dim paramTAXCODE As New SqlParameter("@TAXCODE", SqlDbType.NVarChar, 50)
            paramTAXCODE.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramTAXCODE)

            Dim paramEFF_MONTH As New SqlParameter("@EFF_MONTH", SqlDbType.NVarChar, 2)
            paramEFF_MONTH.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramEFF_MONTH)

            Dim paramEFF_YEAR As New SqlParameter("@EFF_YEAR", SqlDbType.NVarChar, 4)
            paramEFF_YEAR.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramEFF_YEAR)

            Dim paramDESCRIPTION As New SqlParameter("@DESCRIPTION", SqlDbType.NVarChar, 255)
            paramDESCRIPTION.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramDESCRIPTION)

            Dim paramTAXRATE As New SqlParameter("@TAXRATE", SqlDbType.Float)
            paramTAXRATE.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramTAXRATE)

            Dim paramTAXAMT As New SqlParameter("@TAXAMT", SqlDbType.Float)
            paramTAXAMT.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramTAXAMT)

            Dim paramN_TAXRATE As New SqlParameter("@N_TAXRATE", SqlDbType.Float)
            paramN_TAXRATE.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramN_TAXRATE)

            Dim paramN_TAXAMT As New SqlParameter("@N_TAXAMT", SqlDbType.Float)
            paramN_TAXAMT.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramN_TAXAMT)


            Dim paramCOMPSW As New SqlParameter("@COMPSW", SqlDbType.Int)
            paramCOMPSW.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramCOMPSW)


            Dim paramTAXMIN As New SqlParameter("@TAXMIN", SqlDbType.Float)
            paramTAXMIN.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramTAXMIN)

            Dim paramTAXMAX As New SqlParameter("@TAXMAX", SqlDbType.Float)
            paramTAXMAX.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramTAXMAX)

            Dim paramISDISCOUNT As New SqlParameter("@ISDISCOUNT", SqlDbType.NVarChar, 2)
            paramISDISCOUNT.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramISDISCOUNT)

            Dim paramGradFee As New SqlParameter("@GradFee", SqlDbType.Float)
            paramGradFee.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramGradFee)

            _mSqlCommand.Dispose()


        Catch ex As Exception

        End Try


    End Sub

    Public Sub _pSubSelect_GRADTABL()   ' @ Added 20170420
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            ''------------------------------------------------------------------------------------------------------
            _nQuery = _
                "Select * from [dbo].[GRADTABL] "
            ''------------------------------------------------------------------------------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRADTABL] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GRADTABL] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode2))) "

                '"Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRADTABL] where EFF_YEAR IN " & _
                '        "(Select EFF_YEAR from [GRADTABL] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '        "and TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode2))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKHDG_TaxCode2()   ' @ Added 20170509
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRASKHDG] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then

                _nWhere = "WHERE TAXCODE = @_mTaxCode2 AND EFF_YEAR = " & _
                        " @_mEff_Year AND EFF_MONTH = @_mEff_Month "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then .AddWithValue("@_mTaxCode2", _mTaxCode2)
                If Not String.IsNullOrWhiteSpace(_mEff_Month) Then .AddWithValue("@_mEff_Month", _mEff_Month)
                If Not String.IsNullOrWhiteSpace(_mEff_Year) Then .AddWithValue("@_mEff_Year", _mEff_Year)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKHDG()   ' @ Added 20170420
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRASKHDG] "
            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKHDG] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GRASKHDG] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode))) "

                '"Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKHDG] where EFF_YEAR IN " & _
                '        "(Select EFF_YEAR from [GRASKHDG] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '        "and TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusLineCol) Then .AddWithValue("@_mBusLineCol", _mBusLineCol)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheck_GRASKHDG()
        Try
            Dim _nStrSql As String = Nothing

            _nStrSql =
                "EXEC sp_CheckGRASKHDG" & _
                " @BusCode = '" & _mBusCode & "',  " & _
                " @BusArea = '" & IIf(_mBusArea = Nothing, 0, _mBusArea) & "',  " & _
                " @BusColName =  '" & _mBusLineCol & "',  " & _
                " @BusYear =  '" & _mBusYear & "'  "

            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GROPTION_BCODE()   ' @ Added 20170412
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GROPTION] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GROPTION] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GROPTION] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode))) "
                '"Where TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GROPTION] where EFF_YEAR IN " & _
                '        "(Select EFF_YEAR from [GROPTION] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '        "and TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GROPTION_TaxCode2()   ' @ Added 20170510
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select ROW_NUMBER() OVER(ORDER BY OPTHDG1 ASC) AS Row#,* from [dbo].[GROPTION] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then

                _nWhere = "WHERE TAXCODE = @_mTaxCode2 AND EFF_YEAR = " & _
                        " @_mEff_Year AND EFF_MONTH = @_mEff_Month "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then .AddWithValue("@_mTaxCode2", _mTaxCode2)
                If Not String.IsNullOrWhiteSpace(_mEff_Month) Then .AddWithValue("@_mEff_Month", _mEff_Month)
                If Not String.IsNullOrWhiteSpace(_mEff_Year) Then .AddWithValue("@_mEff_Year", _mEff_Year)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRPQTY_BCODE()   ' @ Added 20170412
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GROPTION] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select " & _mTaxCode & "  FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GROPTION] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GROPTION] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode))) "

                '"Where TAXCODE = (Select " & _mTaxCode & "  FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '       "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GROPTION] where EFF_YEAR IN " & _
                '       "(Select EFF_YEAR from [GROPTION] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '       "and TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mTaxCode) Then .AddWithValue("@_mTaxCode", _mTaxCode)
            End With

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubSelect_GROPTION()   ' @ Added 20170428
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select ROW_NUMBER() OVER(ORDER BY OPTHDG1 ASC) AS RowNo,* from [dbo].[GROPTION] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GROPTION] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GROPTION] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode))) "
                '"Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GROPTION] where EFF_YEAR IN " & _
                '        "(Select EFF_YEAR from [GROPTION] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '        "and TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusLineCol) Then .AddWithValue("@_mBusLineCol", _mBusLineCol)
            End With
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKQTY_BCODE()   ' @ Added 20170412
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRASKQTY] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKQTY] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GRASKQTY] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select BCODE FROM BUSCODE WHERE BUS_CODE = @_mBusCode))) "

                '"Where TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKQTY] where EFF_YEAR IN " & _
                '        "(Select EFF_YEAR from [GRASKQTY] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '        "and TAXCODE = (Select BCODE FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode))) "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKQTY_TaxCode2()   ' @ Added 20170515
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRASKQTY] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then

                _nWhere = "WHERE TAXCODE = @_mTaxCode2 AND EFF_YEAR = " & _
                        " @_mEff_Year AND EFF_MONTH = @_mEff_Month "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then .AddWithValue("@_mTaxCode2", _mTaxCode2)
                If Not String.IsNullOrWhiteSpace(_mEff_Month) Then .AddWithValue("@_mEff_Month", _mEff_Month)
                If Not String.IsNullOrWhiteSpace(_mEff_Year) Then .AddWithValue("@_mEff_Year", _mEff_Year)
            End With
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GROPTION_all(_pDataTable As DataTable) ' @ Added 20170720
        Try
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.
            Dim _nQuery As String = Nothing
            Dim _nOrderBy As String = Nothing

            _nQuery = "Select * from Groption "
            _nOrderBy = "order by TaxCode,Eff_year desc,Eff_month desc"
            _mQuery = _nQuery & _nOrderBy

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GROPTION_all_2(_pDataTable2 As DataTable) ' @ Added 20170808
        Try
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.
            Dim _nQuery As String = Nothing
            Dim _nOrderBy As String = Nothing

            _nQuery = "Select * from Groption "
            _nOrderBy = "order by TaxCode,Eff_year desc,Eff_month desc"
            _mQuery = _nQuery & _nOrderBy

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GROPTION_ForCompute()   ' @ Added 20170720
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GROPTION] "
            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then

                _nWhere = "WHERE TAXCODE = @_mMTaxCode AND EFF_YEAR = " & _
                        " @_mTempYr AND EFF_MONTH = @_mTempMo "
            Else
                _nWhere = Nothing
            End If

            _nOrderBy = "order by OPTHDG1,Eff_year,Eff_month"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
            End With
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKQTY_ForCompute()   ' @ Added 20170719
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRASKQTY] "
            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then

                _nWhere = "WHERE TAXCODE = @_mMTaxCode AND EFF_YEAR = " & _
                        " @_mTempYr AND EFF_MONTH = @_mTempMo "
            Else
                _nWhere = Nothing
            End If

            _nOrderBy = "  order by taxcode,eff_year desc,eff_month desc,Askhdg"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
            End With
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKQTY()   ' @ Added 20170425
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "Select * from [dbo].[GRASKQTY] "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                        "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKQTY] where EFF_YEAR IN " & _
                        "(Select EFF_YEAR from [GRASKQTY] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                        "and TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode))) "

                '"Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
                '       "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKQTY] where EFF_YEAR IN " & _
                '       "(Select EFF_YEAR from [GRASKQTY] where EFF_YEAR <= (SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) " & _
                '       "and TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode))) "
            Else
                _nWhere = Nothing
            End If

            ''----------------------------------
            _mQuery = _nQuery & _nWhere
            ''----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)

            End With
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSubGetGRADTABL_ForCompute() '@ Added 20170720


        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                Dim _inTaxRate As Integer = .GetOrdinal("N_TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("N_TAXAMT")
                Dim _inTaxDesc As Integer = .GetOrdinal("DESCRIPTION")
                Dim _inGradYear As Integer = .GetOrdinal("EFF_YEAR")
                Dim _inGradMonth As Integer = .GetOrdinal("EFF_MONTH")
                Dim _inTAXMIN As Integer = .GetOrdinal("TAXMIN")
                Dim _inTAXMAX As Integer = .GetOrdinal("TAXMAX")
                Dim _inCOMPSW As Integer = .GetOrdinal("COMPSW")


                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            _mTaxDesc = ._pReturnString(_nSqlDataReader(_inTaxDesc))
                            _mBT_EFFYR = ._pReturnString(_nSqlDataReader(_inGradYear))
                            _mGradMonth = ._pReturnString(_nSqlDataReader(_inGradMonth))
                            _mTaxDueMin = ._pReturnString(_nSqlDataReader(_inTAXMIN))
                            _mTaxDueMax = ._pReturnString(_nSqlDataReader(_inTAXMAX))
                            _mCOMPSW = ._pReturnString(_nSqlDataReader(_inCOMPSW))
                        Loop
                    End If

                End With
            End With
            _nSqlDataReader.Close()

        End Using

    End Sub

    Public Sub _mSubGetGRADTABL_ForCompute_2() '@ Added 20170808


        Using _nSqlDataReader As SqlDataReader = _mSqlCommand2.ExecuteReader
            With _nSqlDataReader
                Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                Dim _inTaxRate As Integer = .GetOrdinal("N_TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("N_TAXAMT")
                Dim _inTaxDesc As Integer = .GetOrdinal("DESCRIPTION")
                Dim _inGradYear As Integer = .GetOrdinal("EFF_YEAR")
                Dim _inGradMonth As Integer = .GetOrdinal("EFF_MONTH")
                Dim _inTAXMIN As Integer = .GetOrdinal("TAXMIN")
                Dim _inTAXMAX As Integer = .GetOrdinal("TAXMAX")
                Dim _inCOMPSW As Integer = .GetOrdinal("COMPSW")


                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            _mTaxDesc = ._pReturnString(_nSqlDataReader(_inTaxDesc))
                            _mBT_EFFYR = ._pReturnString(_nSqlDataReader(_inGradYear))
                            _mGradMonth = ._pReturnString(_nSqlDataReader(_inGradMonth))
                            _mTaxDueMin = ._pReturnString(_nSqlDataReader(_inTAXMIN))
                            _mTaxDueMax = ._pReturnString(_nSqlDataReader(_inTAXMAX))
                            _mCOMPSW = ._pReturnString(_nSqlDataReader(_inCOMPSW))
                        Loop
                    End If

                End With
            End With
            _nSqlDataReader.Close()

        End Using

    End Sub

    Public Sub _mSubGetGRADTABL_ForCompute_2(_pDataTable2 As DataTable) '@ Added 20170808


        Using _nSqlDataReader As SqlDataReader = _mSqlCommand2.ExecuteReader
            With _nSqlDataReader
                Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                Dim _inTaxRate As Integer = .GetOrdinal("N_TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("N_TAXAMT")
                Dim _inTaxDesc As Integer = .GetOrdinal("DESCRIPTION")
                Dim _inGradYear As Integer = .GetOrdinal("EFF_YEAR")
                Dim _inGradMonth As Integer = .GetOrdinal("EFF_MONTH")
                Dim _inTAXMIN As Integer = .GetOrdinal("TAXMIN")
                Dim _inTAXMAX As Integer = .GetOrdinal("TAXMAX")
                Dim _inCOMPSW As Integer = .GetOrdinal("COMPSW")


                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            _mTaxDesc = ._pReturnString(_nSqlDataReader(_inTaxDesc))
                            _mBT_EFFYR = ._pReturnString(_nSqlDataReader(_inGradYear))
                            _mGradMonth = ._pReturnString(_nSqlDataReader(_inGradMonth))
                            _mTaxDueMin = ._pReturnString(_nSqlDataReader(_inTAXMIN))
                            _mTaxDueMax = ._pReturnString(_nSqlDataReader(_inTAXMAX))
                            _mCOMPSW = ._pReturnString(_nSqlDataReader(_inCOMPSW))
                        Loop
                    End If

                End With
            End With
            _nSqlDataReader.Close()

        End Using

    End Sub

    Public Sub _mSubGetGROPTION_ForCompute(_pDataTable As DataTable) '@ Added 20170720
        _pSubSelect_GROPTION_ForCompute()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                Dim _inTaxCode2 As Integer = .GetOrdinal("TAXCODE2")
                Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")
                Dim _inOPTHDG1 As Integer = .GetOrdinal("OPTHDG1")
                Dim _inYear As Integer = .GetOrdinal("EFF_YEAR")
                Dim _inMonth As Integer = .GetOrdinal("EFF_MONTH")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                            _mTaxCode2 = ._pReturnString(_nSqlDataReader(_inTaxCode2))
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            _mTaxDesc2 = ._pReturnString(_nSqlDataReader(_inOPTHDG1))
                            _mGradYear = ._pReturnString(_nSqlDataReader(_inYear))
                            _mGradMonth = ._pReturnString(_nSqlDataReader(_inMonth))
                        Loop
                    End If

                End With
            End With
            _nSqlDataReader.Close()
        End Using
    End Sub

    Public Sub _mSubGetGRASKQTY_ForCompute() '@ Added 20170719

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")
                Dim _inASKHDG As Integer = .GetOrdinal("ASKHDG")
                Dim _inYear As Integer = .GetOrdinal("EFF_YEAR")
                Dim _inMonth As Integer = .GetOrdinal("EFF_MONTH")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            _mTaxDesc2 = ._pReturnString(_nSqlDataReader(_inASKHDG))
                            _mGradYear = ._pReturnString(_nSqlDataReader(_inYear))
                            _mGradMonth = ._pReturnString(_nSqlDataReader(_inMonth))
                        Loop
                    End If

                End With
            End With
            _nSqlDataReader.Close()
        End Using
    End Sub

    Public Sub _mSubGetGRADTABLValue() '@ Added 20170412

        '_pSubSelect_GRADTABL_BCODE()
        Dim _nDataTable As New DataTable
        _nDataTable = _pDataTable

        _mTaxCode = _nDataTable.Rows("0").Item("TAXCODE").ToString
        _mTaxRate = _nDataTable.Rows("0").Item("N_TAXRATE").ToString
        _mTaxAmt = _nDataTable.Rows("0").Item("N_TAXAMT").ToString
        _mTaxDesc = _nDataTable.Rows("0").Item("DESCRIPTION").ToString
        _mGradYear = _nDataTable.Rows("0").Item("EFF_YEAR").ToString
        _mGradMonth = _nDataTable.Rows("0").Item("EFF_MONTH").ToString
        _mGradTaxMin = _nDataTable.Rows("0").Item("TAXMIN").ToString
        _mGradTaxMax = _nDataTable.Rows("0").Item("TAXMAX").ToString
        _mCOMPSW = IIf(_nDataTable.Rows("0").Item("COMPSW").ToString = Nothing, 0, _nDataTable.Rows("0").Item("COMPSW"))

        'Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

        '    With _nSqlDataReader
        '        Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
        '        Dim _inTaxRate As Integer = .GetOrdinal("N_TAXRATE")
        '        Dim _inTaxAmt As Integer = .GetOrdinal("N_TAXAMT")
        '        Dim _inTaxDesc As Integer = .GetOrdinal("DESCRIPTION")
        '        Dim _inGradYear As Integer = .GetOrdinal("EFF_YEAR")
        '        Dim _inGradMonth As Integer = .GetOrdinal("EFF_MONTH")
        '        Dim _inTaxMin As Integer = .GetOrdinal("TAXMIN")
        '        Dim _inTaxMax As Integer = .GetOrdinal("TAXMAX")
        '        Dim _inCOMPSW As Integer = .GetOrdinal("COMPSW")

        '        Dim _nClassReturnTypes As New ClassReturnTypes

        '        With _nClassReturnTypes

        '            If _nSqlDataReader.HasRows Then
        '                Do While _nSqlDataReader.Read
        '                    _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
        '                    _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
        '                    _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
        '                    _mTaxDesc = ._pReturnString(_nSqlDataReader(_inTaxDesc))
        '                    _mGradYear = ._pReturnString(_nSqlDataReader(_inGradYear))
        '                    _mGradMonth = ._pReturnString(_nSqlDataReader(_inGradMonth))
        '                    _mGradTaxMin = ._pReturnString(_nSqlDataReader(_inTaxMin))
        '                    _mGradTaxMax = ._pReturnString(_nSqlDataReader(_inTaxMax))
        '                    _mCOMPSW = ._pReturnString(_nSqlDataReader(_inCOMPSW))
        '                Loop
        '            End If

        '        End With
        '    End With
        '    _nSqlDataReader.Close()
        'End Using

    End Sub

    Public Sub _mSubCheck_Busline(_pDataTable As DataTable) ' @ Added 20170707
        _mSqlDataReader = Nothing
        _pSubSelectAll__BUSLINE()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                Dim _inBRANGE_QTY As Integer = .GetOrdinal("BRANGE_QTY")
                Dim _inSTATCODE As Integer = .GetOrdinal("STATCODE")
                Dim _inNewsw As Integer = .GetOrdinal("NEWSW")
                Dim _inBCHOICE1 As Integer = .GetOrdinal("BCHOICE1")
                Dim _inBQTY As Integer = .GetOrdinal("BQTY")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mBRANGE_QTY = ._pReturnString(_nSqlDataReader(_inBRANGE_QTY))
                            _mSTATCODE = ._pReturnString(_nSqlDataReader(_inSTATCODE))
                            _mNewsw = ._pReturnString(_nSqlDataReader(_inNewsw))
                            _mBCHOICE1 = ._pReturnString(_nSqlDataReader(_inBCHOICE1))
                            _mBQTY = ._pReturnString(_nSqlDataReader(_inBQTY))
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()
        End Using

    End Sub

    Public Sub _msubGetGREXCESS_Value(_pDataTable As DataTable) ' @ Added 20170713


        _mSqlDataReader = Nothing
        _mSubSelectGREXCESS()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                Dim _inFOR_EVERY As Integer = .GetOrdinal("FOR_EVERY")
                Dim _inINXSOF As Integer = .GetOrdinal("INXSOF")
                Dim _inTAXRATE As Integer = .GetOrdinal("TAXRATE")
                Dim _inTAXAMT As Integer = .GetOrdinal("TAXAMT")
                Dim _inINFRACOF As Integer = .GetOrdinal("INFRACOF")
                Dim _inADDAMT As Integer = .GetOrdinal("ADDAMT")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mFOR_EVERY = ._pReturnString(_nSqlDataReader(_inFOR_EVERY))
                            _mINXSOF = ._pReturnString(_nSqlDataReader(_inINXSOF))
                            _mExcess_TAXRATE = ._pReturnString(_nSqlDataReader(_inTAXRATE))
                            _mExcess_TAXAMT = ._pReturnString(_nSqlDataReader(_inTAXAMT))
                            _mINFRACOF = ._pReturnString(_nSqlDataReader(_inINFRACOF))
                            _mADDAMT = ._pReturnString(_nSqlDataReader(_inADDAMT))  '@ Added 20170802
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()
        End Using
    End Sub

    Public Sub _msubGetGREXCESS_Value_PerRow(_pDataTable2 As DataTable) '--- @ Added 20170802

        _mSqlDataReader = Nothing
        _mSubSelectGREXCESS_PerRow()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand2.ExecuteReader
            With _nSqlDataReader
                Dim _inFOR_EVERY As Integer = .GetOrdinal("FOR_EVERY")
                Dim _inINXSOF As Integer = .GetOrdinal("INXSOF")
                Dim _inTAXRATE As Integer = .GetOrdinal("TAXRATE")
                Dim _inTAXAMT As Integer = .GetOrdinal("TAXAMT")
                Dim _inINFRACOF As Integer = .GetOrdinal("INFRACOF")
                Dim _inADDAMT As Integer = .GetOrdinal("ADDAMT")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mFOR_EVERY = ._pReturnString(_nSqlDataReader(_inFOR_EVERY))
                            _mINXSOF = ._pReturnString(_nSqlDataReader(_inINXSOF))
                            _mExcess_TAXRATE = ._pReturnString(_nSqlDataReader(_inTAXRATE))
                            _mExcess_TAXAMT = ._pReturnString(_nSqlDataReader(_inTAXAMT))
                            _mINFRACOF = ._pReturnString(_nSqlDataReader(_inINFRACOF))
                            _mADDAMT = ._pReturnString(_nSqlDataReader(_inADDAMT))  ' --- @ Added 20170802
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()
            _pSqlDataReader2.Close()
        End Using
    End Sub


    Public Sub _mSubGetGRANGE_Value_PerRow(_pDataTable2 As DataTable)   ' @ Added 20170728
        Try
            _mSqlDataReader2 = Nothing
            _mSubSelectGRRANGE_PerRow()
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand2.ExecuteReader
                With _nSqlDataReader
                    Dim _inRANGEAMT As Integer = .GetOrdinal("RANGEAMT")
                    Dim _inTAXRATE As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTAXAMT As Integer = .GetOrdinal("TAXAMT")
                    Dim _inRowNo As Integer = .GetOrdinal("RowNo")

                    Dim _nClassReturnTypes As New ClassReturnTypes

                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mGRRANGE_RANGEAMT = ._pReturnString(_nSqlDataReader(_inRANGEAMT))
                                _mGRRANGE_TAXRATE = ._pReturnString(_nSqlDataReader(_inTAXRATE))
                                _mGRRANGE_TAXAMT = ._pReturnString(_nSqlDataReader(_inTAXAMT))
                                _mGRRANGE_RowNo = ._pReturnString(_nSqlDataReader(_inRowNo)) ' --- @ Added 20170728
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
                _pSqlDataReader2.Close()
            End Using
        Catch ex As Exception
        End Try
    End Sub


    Public Sub _mSubGetGRANGE_Value()   ' @ Added 20170711
        Try
            'If ConnectionState.Open = True Then
            '    _mSqlCon.Close()
            'End If
            _pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _mSqlDataReader = Nothing
            ' _mSqlDataReader.Close()
            _mSubSelectGRRANGE_All()


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _inRANGEAMT As Integer = .GetOrdinal("RANGEAMT")
                    Dim _inTAXRATE As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTAXAMT As Integer = .GetOrdinal("TAXAMT")
                    Dim _inRowNo As Integer = .GetOrdinal("RowNo")

                    Dim _nClassReturnTypes As New ClassReturnTypes

                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mGRRANGE_RANGEAMT = ._pReturnString(_nSqlDataReader(_inRANGEAMT))
                                _mGRRANGE_TAXRATE = ._pReturnString(_nSqlDataReader(_inTAXRATE))
                                _mGRRANGE_TAXAMT = ._pReturnString(_nSqlDataReader(_inTAXAMT))
                                _mGRRANGE_RowNo = ._pReturnString(_nSqlDataReader(_inRowNo)) ' --- @ Added 20170728
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _mSubGetAIF_Desc()
        Try

            _pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _mSqlDataReader = Nothing
            _pGetAIF_Desc()

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader

                    Dim _inEPO As Integer = .GetOrdinal("EPO")
                    Dim _inEIF As Integer = .GetOrdinal("EIF")
                    Dim _inPLATE As Integer = .GetOrdinal("PLATE")

                    Dim _nClassReturnTypes As New ClassReturnTypes

                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mEPO = ._pReturnString(_nSqlDataReader(_inEPO))
                                _mEIF = ._pReturnString(_nSqlDataReader(_inEIF))
                                _mPLATE = ._pReturnString(_nSqlDataReader(_inPLATE))
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
        End Try

    End Sub

    Public Sub _mSubGetGRASKQTY()   ' @ Added 20170711


        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
            With _nSqlDataReader
                Dim _inRANGEAMT As Integer = .GetOrdinal("RANGEAMT")
                Dim _inTAXRATE As Integer = .GetOrdinal("TAXRATE")
                Dim _inTAXAMT As Integer = .GetOrdinal("TAXAMT")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mGRRANGE_RANGEAMT = ._pReturnString(_nSqlDataReader(_inRANGEAMT))
                            _mGRRANGE_TAXRATE = ._pReturnString(_nSqlDataReader(_inTAXRATE))
                            _mGRRANGE_TAXAMT = ._pReturnString(_nSqlDataReader(_inTAXAMT))
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()
        End Using
    End Sub

    Public Sub _mSubCheckGRADTABL() ' @ Added 20170707

        _mSubSelectGradtable_TaxCode()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

            With _nSqlDataReader
                Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                Dim _inTaxRate As Integer = .GetOrdinal("N_TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("N_TAXAMT")
                Dim _inTaxDesc As Integer = .GetOrdinal("DESCRIPTION")
                Dim _inGradYear As Integer = .GetOrdinal("EFF_YEAR")
                Dim _inGradMonth As Integer = .GetOrdinal("EFF_MONTH")
                Dim _inTAXMIN As Integer = .GetOrdinal("TAXMIN")
                Dim _inTAXMAX As Integer = .GetOrdinal("TAXMAX")
                Dim _inCOMPSW As Integer = .GetOrdinal("COMPSW")

                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            _mTaxDesc = ._pReturnString(_nSqlDataReader(_inTaxDesc))
                            _mBT_EFFYR = ._pReturnString(_nSqlDataReader(_inGradYear))
                            _mGradMonth = ._pReturnString(_nSqlDataReader(_inGradMonth))
                            _mTaxDueMin = ._pReturnString(_nSqlDataReader(_inTAXMIN))
                            _mTaxDueMax = ._pReturnString(_nSqlDataReader(_inTAXMAX))
                            _mCOMPSW = ._pReturnString(_nSqlDataReader(_inCOMPSW))
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()
        End Using
    End Sub

    Public Sub _mSubSelectGREXCESS()    '@ Added 20170714
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            _nQuery =
                "Select * from GREXCESS"

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = " where TAXCODE = @_mMTaxCode and Eff_Month = @_mTempMo  And Eff_Year = @_mTempYr"
            Else
                _nWhere = Nothing
            End If

            _nOrderBy = " order by taxcode,eff_year desc,eff_month desc,Inxsof desc"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
            End With

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _mSubSelectGREXCESS_PerRow()    '@ Added 20170802
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            'Dim _nOrderBy As String = Nothing
            _nQuery =
                " With GREXCESSx as" & _
                " (" & _
                " Select *, " & _
                " ROW_NUMBER() OVER( order by taxcode,eff_year desc,eff_month desc,Inxsof desc) AS RowNo" & _
                " from GREXCESS " & _
                " where TAXCODE = @_mMTaxCode and Eff_Month = @_mTempMo  And Eff_Year = @_mTempYr" & _
                " ) SELECT * FROM GREXCESSx"

            If Not String.IsNullOrWhiteSpace(_mRowNo) Then

                _nWhere = " where RowNo = @_mRowNo "
            Else
                _nWhere = Nothing
            End If

            '_nOrderBy = " order by taxcode,eff_year desc,eff_month desc,Inxsof desc"
            '----------------------------------
            _mQuery = _nQuery & _nWhere ' & _nOrderBy

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
                If Not String.IsNullOrWhiteSpace(_mRowNo) Then .AddWithValue("@_mRowNo", _mRowNo)
            End With

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSubSelectGRRANGE_PerRow()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            _pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _mSqlCon.Close()
            _mSqlCon.Open()

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            _nQuery = _
                "With RANGEx as" & _
                "(" & _
                "Select *, " & _
                " ROW_NUMBER() OVER(ORDER BY taxcode,eff_year desc,eff_month desc,rangeamt) AS RowNo " & _
                " from GRRANGE" & _
                " where TAXCODE = @_mMTaxCode and Eff_Month = @_mTempMo  And Eff_Year = @_mTempYr" & _
                ") select * from RANGEx"

            If Not String.IsNullOrWhiteSpace(_mRowNo) Then
                _nWhere = " where RowNo = @_mRowNo "
            Else
                _nWhere = Nothing
            End If

            _nOrderBy = " order by taxcode,eff_year desc,eff_month desc,rangeamt"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy

            '----------------------------------
            _mSqlCommand = Nothing
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
                If Not String.IsNullOrWhiteSpace(_mRowNo) Then .AddWithValue("@_mRowNo", _mRowNo)
            End With

            _mSqlCommand.Dispose()
            '_mSqlCon.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSubCheckGRANGE(ByVal _mMtaxCode As String, ByVal _mTempMo As String, ByVal _mTempYr As String)
        Try
            _pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            ' _mSqlCon.Open()

            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            _nQuery = _
             "SELECT * FROM GRRANGE WHERE TAXCODE = @_mMTaxCode and Eff_Year = @_mTempYr and Eff_Month = @_mTempMo "
            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = Nothing
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMtaxCode) Then .AddWithValue("@_mMTaxCode", _mMtaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
            End With
            '_mSqlCon.Close()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try


    End Sub

    Public Sub _mSubSp_CheckGRANGE(ByVal _mMtaxCode As String, ByVal _mTempMo As String, ByVal _mTempYr As String)
        Try
            Dim _nStrSql As String = Nothing

            _nStrSql = "DECLARE @Out_TAXCODE NVARCHAR(4) , @Out_EFF_MONTH NVARCHAR(2) , @Out_EFF_YEAR NVARCHAR(4) , @Out_RANGEAMT float , @Out_TAXRATE float , @Out_TAXAMT float " & _
            "EXEC sp_CheckGRRANGE " & _
            "@_mMTaxCode ='" & _mMtaxCode & "'," & _
            "@_mTempYr = '" & _mTempMo & "'," & _
            "@_mTempMo = '" & _mTempYr & "'," & _
            "@TAXCODE = @Out_TAXCODE out ," & _
            "@EFF_MONTH = @Out_EFF_MONTH out," & _
            "@EFF_YEAR = @Out_EFF_YEAR out," & _
            "@RANGEAMT = @Out_RANGEAMT out," & _
            "@TAXRATE = @Out_TAXRATE out," & _
            "@TAXAMT = @Out_TAXAMT out" & _
            "SELECT @Out_EFF_MONTH as EFF_MONTH , @Out_EFF_YEAR as EFF_YEAR, @Out_RANGEAMT as RANGEAMT, @Out_TAXRATE as TAXRATE, @Out_TAXAMT as TAXAMT "

            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _mSubSelectGRRANGE_All()
        Try
            '_pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            ' _mSqlCon.Open()

            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nOrderBy As String = Nothing

            _nQuery = _
                "Select *, ROW_NUMBER() OVER(ORDER BY taxcode,eff_year desc,eff_month desc,rangeamt) AS RowNo from GRRANGE"

            If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then

                _nWhere = " where TAXCODE = @_mMTaxCode and Eff_Month = @_mTempMo  And Eff_Year = @_mTempYr "
            Else
                _nWhere = Nothing
            End If

            _nOrderBy = " order by taxcode,eff_year desc,eff_month desc,rangeamt"
            '----------------------------------
            _mQuery = _nQuery & _nWhere & _nOrderBy

            '----------------------------------
            _mSqlCommand = Nothing
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
            End With
            '_mSqlCon.Close()
            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSubSelectGradtable_TaxCode()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery =
                "Select * from GRADTABL"

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = " where TAXCODE = @_mMTaxCode and Eff_Month = @_mTempMo  And Eff_Year = @_mTempYr "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mMTaxCode) Then .AddWithValue("@_mMTaxCode", _mMTaxCode)
                If Not String.IsNullOrWhiteSpace(_mTempYr) Then .AddWithValue("@_mTempYr", _mTempYr)
                If Not String.IsNullOrWhiteSpace(_mTempMo) Then .AddWithValue("@_mTempMo", _mTempMo)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSubCheckBusCode_TaxCode()  '@ Added 20170706

        _pSubSelect_BusCode_TaxCode()   '@ Added 20170706

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

            With _nSqlDataReader
                Dim _inBCODE As Integer = .GetOrdinal("BCODE")
                Dim _inMCODE As Integer = .GetOrdinal("MCODE")
                Dim _inGCODE As Integer = .GetOrdinal("GCODE")
                Dim _inSCODE As Integer = .GetOrdinal("SCODE")
                Dim _inFCODE As Integer = .GetOrdinal("FCODE")

                Dim _nClassReturnTypes As New ClassReturnTypes
                With _nClassReturnTypes
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mBCODE = ._pReturnString(_nSqlDataReader(_inBCODE))
                            _mMCODE = ._pReturnString(_nSqlDataReader(_inMCODE))
                            _mGCODE = ._pReturnString(_nSqlDataReader(_inGCODE))
                            _mSCODE = ._pReturnString(_nSqlDataReader(_inSCODE))
                            _mFCODE = ._pReturnString(_nSqlDataReader(_inFCODE))
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()

        End Using
        _pBCODE = _mBCODE
        _pMCODE = _mMCODE
        _pGCODE = _mGCODE
        _pSCODE = _mSCODE
        _pFCODE = _mFCODE

    End Sub

    Public Sub _mSubCheckChoiceValue() '@   Added 20170630


        _pSubSelect_BUSLINE_CHOICE()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

            With _nSqlDataReader
                Dim _inBCHOICE1 As Integer = .GetOrdinal("BCHOICE1")
                Dim _inBCHOICE2 As Integer = .GetOrdinal("BCHOICE2")
                Dim _inBCHOICE3 As Integer = .GetOrdinal("BCHOICE3")
                Dim _inBCHOICE4 As Integer = .GetOrdinal("BCHOICE4")
                Dim _inMCHOICE1 As Integer = .GetOrdinal("MCHOICE1")
                Dim _inMCHOICE2 As Integer = .GetOrdinal("MCHOICE2")
                Dim _inMCHOICE3 As Integer = .GetOrdinal("MCHOICE3")
                Dim _inMCHOICE4 As Integer = .GetOrdinal("MCHOICE4")
                Dim _inGCHOICE1 As Integer = .GetOrdinal("GCHOICE1")
                Dim _inGCHOICE2 As Integer = .GetOrdinal("GCHOICE2")
                Dim _inGCHOICE3 As Integer = .GetOrdinal("GCHOICE3")
                Dim _inGCHOICE4 As Integer = .GetOrdinal("GCHOICE4")
                Dim _inSCHOICE1 As Integer = .GetOrdinal("SCHOICE1")
                Dim _inSCHOICE2 As Integer = .GetOrdinal("SCHOICE2")
                Dim _inSCHOICE3 As Integer = .GetOrdinal("SCHOICE3")
                Dim _inSCHOICE4 As Integer = .GetOrdinal("SCHOICE4")
                Dim _inFCHOICE1 As Integer = .GetOrdinal("FCHOICE1")
                Dim _inFCHOICE2 As Integer = .GetOrdinal("FCHOICE2")
                Dim _inFCHOICE3 As Integer = .GetOrdinal("FCHOICE3")
                Dim _inFCHOICE4 As Integer = .GetOrdinal("FCHOICE4")

                Dim _nClassReturnTypes As New ClassReturnTypes
                With _nClassReturnTypes
                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mBCHOICE1 = ._pReturnString(_nSqlDataReader(_inBCHOICE1))
                            _mBCHOICE2 = ._pReturnString(_nSqlDataReader(_inBCHOICE2))
                            _mBCHOICE3 = ._pReturnString(_nSqlDataReader(_inBCHOICE3))
                            _mBCHOICE4 = ._pReturnString(_nSqlDataReader(_inBCHOICE4))
                            _mMCHOICE1 = ._pReturnString(_nSqlDataReader(_inMCHOICE1))
                            _mMCHOICE2 = ._pReturnString(_nSqlDataReader(_inMCHOICE2))
                            _mMCHOICE3 = ._pReturnString(_nSqlDataReader(_inMCHOICE3))
                            _mMCHOICE4 = ._pReturnString(_nSqlDataReader(_inMCHOICE4))
                            _mGCHOICE1 = ._pReturnString(_nSqlDataReader(_inGCHOICE1))
                            _mGCHOICE2 = ._pReturnString(_nSqlDataReader(_inGCHOICE2))
                            _mGCHOICE3 = ._pReturnString(_nSqlDataReader(_inGCHOICE3))
                            _mGCHOICE4 = ._pReturnString(_nSqlDataReader(_inGCHOICE4))
                            _mSCHOICE1 = ._pReturnString(_nSqlDataReader(_inSCHOICE1))
                            _mSCHOICE2 = ._pReturnString(_nSqlDataReader(_inSCHOICE2))
                            _mSCHOICE3 = ._pReturnString(_nSqlDataReader(_inSCHOICE3))
                            _mSCHOICE4 = ._pReturnString(_nSqlDataReader(_inSCHOICE4))
                            _mFCHOICE1 = ._pReturnString(_nSqlDataReader(_inFCHOICE1))
                            _mFCHOICE2 = ._pReturnString(_nSqlDataReader(_inFCHOICE2))
                            _mFCHOICE3 = ._pReturnString(_nSqlDataReader(_inFCHOICE3))
                            _mFCHOICE4 = ._pReturnString(_nSqlDataReader(_inFCHOICE4))
                        Loop
                    End If
                End With
            End With
            _nSqlDataReader.Close()
        End Using

    End Sub

    Public Sub _mSubSavetoTableComputation()

        ''' SavetoInfo
        Try
            Dim _nQuery As String = Nothing 'Added 20170417

            _nQuery =
            "INSERT INTO " & _
              "[ForBuslineComputation] " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " [ACCTNO]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusCode), "", ", [BUS_CODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", [FORYEAR]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxCode), "", ", [TAXCODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusLineCol), "", ", [BUSLINECOL]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxDesc), "", ", [DESC]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxRate), "", ", [N_TAXRATE]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxAmt), "", ", [N_TAXAMT]") & _
              IIf(String.IsNullOrWhiteSpace(_mTblCode), "", ", [TBL_CODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mInputVal), "", ", [INPUTED_VAL]") & _
              ") " & _
              "VALUES " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " @_mAccount") & _
              IIf(String.IsNullOrWhiteSpace(_mBusCode), "", ", @_mBusCode") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", @_mBusYear") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxCode), "", ", @_mTaxCode") & _
              IIf(String.IsNullOrWhiteSpace(_mBusLineCol), "", ", @_mBusLineCol") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxDesc), "", ", @_mTaxDesc") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxRate), "", ", @_mTaxRate") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxAmt), "", ", @_mTaxAmt") & _
              IIf(String.IsNullOrWhiteSpace(_mTblCode), "", ", @_mTblCode") & _
              IIf(String.IsNullOrWhiteSpace(_mInputVal), "", ", @_mInputVal") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSLINE_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mTaxCode) Then .AddWithValue("@_mTaxCode", _mTaxCode)
                If Not String.IsNullOrWhiteSpace(_mBusLineCol) Then .AddWithValue("@_mBusLineCol", _mBusLineCol)
                If Not String.IsNullOrWhiteSpace(_mTaxDesc) Then .AddWithValue("@_mTaxDesc", _mTaxDesc)
                If Not String.IsNullOrWhiteSpace(_mTaxRate) Then .AddWithValue("@_mTaxRate", _mTaxRate)
                If Not String.IsNullOrWhiteSpace(_mTaxAmt) Then .AddWithValue("@_mTaxAmt", _mTaxAmt)
                If Not String.IsNullOrWhiteSpace(_mTblCode) Then .AddWithValue("@_mTblCode", _mTblCode)
                If Not String.IsNullOrWhiteSpace(_mInputVal) Then .AddWithValue("@_mInputVal", _mInputVal)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _mSubSavetoTableComputation_TaxCode2() 'Added 20170515

        ''' SavetoInfo
        Try
            Dim _nQuery As String = Nothing

            _nQuery =
            "INSERT INTO " & _
              "[ForBuslineComputation] " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " [ACCTNO]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxCode2), "", ", [BUS_CODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", [FORYEAR]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxCode), "", ", [TAXCODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mBusLineCol), "", ", [BUSLINECOL]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxDesc), "", ", [DESC]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxRate), "", ", [N_TAXRATE]") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxAmt), "", ", [N_TAXAMT]") & _
              IIf(String.IsNullOrWhiteSpace(_mTblCode), "", ", [TBL_CODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mInputVal), "", ", [INPUTED_VAL]") & _
              ") " & _
              "VALUES " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " @_mAccount") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxCode2), "", ", @_mTaxCode2") & _
              IIf(String.IsNullOrWhiteSpace(_mBusYear), "", ", @_mBusYear") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxCode), "", ", @_mTaxCode") & _
              IIf(String.IsNullOrWhiteSpace(_mBusLineCol), "", ", @_mBusLineCol") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxDesc), "", ", @_mTaxDesc") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxRate), "", ", @_mTaxRate") & _
              IIf(String.IsNullOrWhiteSpace(_mTaxAmt), "", ", @_mTaxAmt") & _
              IIf(String.IsNullOrWhiteSpace(_mTblCode), "", ", @_mTblCode") & _
              IIf(String.IsNullOrWhiteSpace(_mInputVal), "", ", @_mInputVal") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSLINE_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mTaxCode2) Then .AddWithValue("@_mTaxCode2", _mTaxCode2)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mTaxCode) Then .AddWithValue("@_mTaxCode", _mTaxCode)
                If Not String.IsNullOrWhiteSpace(_mBusLineCol) Then .AddWithValue("@_mBusLineCol", _mBusLineCol)
                If Not String.IsNullOrWhiteSpace(_mTaxDesc) Then .AddWithValue("@_mTaxDesc", _mTaxDesc)
                If Not String.IsNullOrWhiteSpace(_mTaxRate) Then .AddWithValue("@_mTaxRate", _mTaxRate)
                If Not String.IsNullOrWhiteSpace(_mTaxAmt) Then .AddWithValue("@_mTaxAmt", _mTaxAmt)
                If Not String.IsNullOrWhiteSpace(_mTblCode) Then .AddWithValue("@_mTblCode", _mTblCode)
                If Not String.IsNullOrWhiteSpace(_mInputVal) Then .AddWithValue("@_mInputVal", _mInputVal)
            End With

            _mSqlCommand.ExecuteNonQuery()

            _mSqlCommand.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub _mSubGetGRASKHDGValue() '@ Added 20170412

        _pSubSelect_GRASKHDG()

        Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

            With _nSqlDataReader
                Dim _inTaxRate As Integer = .GetOrdinal("N_TAXRATE")
                Dim _inTaxAmt As Integer = .GetOrdinal("N_TAXAMT")


                Dim _nClassReturnTypes As New ClassReturnTypes

                With _nClassReturnTypes

                    If _nSqlDataReader.HasRows Then
                        Do While _nSqlDataReader.Read
                            _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                            _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))

                        Loop
                    End If

                End With
            End With
            _nSqlDataReader.Close()
        End Using

    End Sub

    Public Sub _pSubSelect_GRASKQTY_ROW()   ' @ Modified 20170503
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    
            _nQuery = _
                "WITH asa AS  " & _
                    "( " & _
                    "Select ROW_NUMBER() OVER(ORDER BY TAXCODE ASC) AS Row# " & _
                    ", * from [dbo].[GRASKQTY] " & _
                    "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode) " & _
                    "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKQTY] where EFF_YEAR IN " & _
                    "(Select EFF_YEAR from [GRASKQTY] where EFF_YEAR <= " & _
                    "(SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) and TAXCODE = " & _
                    "(Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode2))) " & _
                    ") " & _
                    "SELECT * " & _
                    "FROM asa  "

            '"WITH asa AS  " & _
            '      "( " & _
            '      "Select ROW_NUMBER() OVER(ORDER BY TAXCODE ASC) AS Row# " & _
            '      ", * from [dbo].[GRASKQTY] " & _
            '      "Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
            '      "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKQTY] where EFF_YEAR IN " & _
            '      "(Select EFF_YEAR from [GRASKQTY] where EFF_YEAR <= " & _
            '      "(SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) and TAXCODE = " & _
            '      "(Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode2))) " & _
            '      ") " & _
            '      "SELECT * " & _
            '      "FROM asa  "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "WHERE Row# = @_mRowNo "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand3 = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand3.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mRowNo) Then .AddWithValue("@_mRowNo", _mRowNo)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKHDG_ROW()   ' @ Added 20170420
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    


            _nQuery = _
                "WITH asa AS  " & _
                    "( " & _
                    "Select ROW_NUMBER() OVER(ORDER BY TAXCODE ASC) AS Row# " & _
                    ", * from [dbo].[GRASKHDG] " & _
                    "Where TAXCODE = (Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = '" & _mBusCode & "') " & _
                    "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKHDG] where EFF_YEAR IN " & _
                    "(Select EFF_YEAR from [GRASKHDG] where EFF_YEAR <= " & _
                    "(SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) and TAXCODE = " & _
                    "(Select " & _mBusLineCol & " FROM BUSCODE WHERE BUS_CODE = @_mBusCode2))) " & _
                    ") " & _
                    "SELECT * " & _
                    "FROM asa  "

            '"WITH asa AS  " & _
            '      "( " & _
            '      "Select ROW_NUMBER() OVER(ORDER BY TAXCODE ASC) AS Row# " & _
            '      ", * from [dbo].[GRASKHDG] " & _
            '      "Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
            '      "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKHDG] where EFF_YEAR IN " & _
            '      "(Select EFF_YEAR from [GRASKHDG] where EFF_YEAR <= " & _
            '      "(SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) and TAXCODE = " & _
            '      "(Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode2))) " & _
            '      ") " & _
            '      "SELECT * " & _
            '      "FROM asa  "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "WHERE Row# = @_mRowNo "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand3 = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand3.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mRowNo) Then .AddWithValue("@_mRowNo", _mRowNo)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_GRASKHDG_ROW_2()   ' @ Added 20180713
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    


            _nQuery = _
                "WITH asa AS  " & _
                    "( " & _
                    "Select ROW_NUMBER() OVER(ORDER BY TAXCODE ASC) AS Row# " & _
                    ", * from [dbo].[GRASKHDG] " & _
                    "Where TAXCODE = '" & _mTaxCode2 & "' " & _
                    "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKHDG] where EFF_YEAR IN " & _
                    "(Select EFF_YEAR from [GRASKHDG] where EFF_YEAR <= " & _
                    "(SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) and TAXCODE = " & _
                    "'" & _mTaxCode2 & "')) " & _
                    ") " & _
                    "SELECT * " & _
                    "FROM asa  "

            '"WITH asa AS  " & _
            '      "( " & _
            '      "Select ROW_NUMBER() OVER(ORDER BY TAXCODE ASC) AS Row# " & _
            '      ", * from [dbo].[GRASKHDG] " & _
            '      "Where TAXCODE = (Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode) " & _
            '      "AND EFF_YEAR = (SELECT MAX(EFF_YEAR) FROM [GRASKHDG] where EFF_YEAR IN " & _
            '      "(Select EFF_YEAR from [GRASKHDG] where EFF_YEAR <= " & _
            '      "(SELECT CONVERT(VARCHAR(4),YEAR(getdate()))) and TAXCODE = " & _
            '      "(Select " & _mBusLineCol & " FROM BusinessLine_Setup WHERE BUS_CODE = @_mBusCode2))) " & _
            '      ") " & _
            '      "SELECT * " & _
            '      "FROM asa  "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mBusCode) Then

                _nWhere = "WHERE Row# = '" & _mRowNo & "' "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand3 = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand3.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode2", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mRowNo) Then .AddWithValue("@_mRowNo", _mRowNo)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region


#Region "GetQuestion"

    Public Sub _mSubGetQuestions_GRASKQTY()
        _pTaxAmt1 = 0
        _pTaxAmt2 = 0
        _pTaxAmt3 = 0
        _pTaxAmt4 = 0
        _pTaxAmt5 = 0
        _pTaxAmt6 = 0
        _pTaxAmt7 = 0
        _pTaxAmt8 = 0
        _pTaxAmt9 = 0
        _pTaxAmt10 = 0

        _pRowNo = "1"
        _pSubSelect_GRASKQTY_ROW()

        If _mFnHasRecord1_GRASKQTY() = True Then
            _mShowPanel1 = True
            _pRowNo = "2"
            _pSubSelect_GRASKQTY_ROW()

            If _mFnHasRecord2_GRASKQTY() = True Then
                _mShowPanel2 = True
                _pRowNo = "3"
                _pSubSelect_GRASKQTY_ROW()

                If _mFnHasRecord3_GRASKQTY() = True Then
                    _mShowPanel3 = True
                    _pRowNo = "4"
                    _pSubSelect_GRASKQTY_ROW()

                    If _mFnHasRecord4_GRASKQTY() = True Then
                        _mShowPanel4 = True
                        _pRowNo = "5"
                        _pSubSelect_GRASKQTY_ROW()

                        If _mFnHasRecord5_GRASKQTY() = True Then
                            _mShowPanel5 = True
                            _pRowNo = "6"
                            _pSubSelect_GRASKQTY_ROW()

                            If _mFnHasRecord6_GRASKQTY() = True Then
                                _mShowPanel6 = True
                                _pRowNo = "7"
                                _pSubSelect_GRASKQTY_ROW()

                                If _mFnHasRecord7_GRASKQTY() = True Then
                                    _mShowPanel7 = True
                                    _pRowNo = "8"
                                    _pSubSelect_GRASKQTY_ROW()

                                    If _mFnHasRecord8_GRASKQTY() = True Then
                                        _mShowPanel8 = True
                                        _pRowNo = "9"
                                        _pSubSelect_GRASKQTY_ROW()

                                        If _mFnHasRecord9_GRASKQTY() = True Then
                                            _mShowPanel9 = True
                                            _pRowNo = "10"
                                            _pSubSelect_GRASKQTY_ROW()

                                            If _mFnHasRecord10_GRASKQTY() = True Then
                                                _mShowPanel10 = True

                                            End If
                                        Else
                                            Exit Sub
                                        End If
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    Exit Sub
                                End If
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If
    End Sub

    Public Sub _mSubGetQuestions_GRASKHDG()   '@  Added 20170420

        _pRowNo = "1"
        _pSubSelect_GRASKHDG_ROW()

        If _mFnHasRecord1() = True Then
            _mShowPanel1 = True
            _pRowNo = "2"
            _pSubSelect_GRASKHDG_ROW()

            If _mFnHasRecord2() = True Then
                _mShowPanel2 = True
                _pRowNo = "3"
                _pSubSelect_GRASKHDG_ROW()

                If _mFnHasRecord3() = True Then
                    _mShowPanel3 = True
                    _pRowNo = "4"
                    _pSubSelect_GRASKHDG_ROW()

                    If _mFnHasRecord4() = True Then
                        _mShowPanel4 = True
                        _pRowNo = "5"
                        _pSubSelect_GRASKHDG_ROW()

                        If _mFnHasRecord5() = True Then
                            _mShowPanel5 = True
                            _pRowNo = "6"
                            _pSubSelect_GRASKHDG_ROW()

                            If _mFnHasRecord6() = True Then
                                _mShowPanel6 = True
                                _pRowNo = "7"
                                _pSubSelect_GRASKHDG_ROW()

                                If _mFnHasRecord7() = True Then
                                    _mShowPanel7 = True
                                    _pRowNo = "8"
                                    _pSubSelect_GRASKHDG_ROW()

                                    If _mFnHasRecord8() = True Then
                                        _mShowPanel8 = True
                                        _pRowNo = "9"
                                        _pSubSelect_GRASKHDG_ROW()

                                        If _mFnHasRecord9() = True Then
                                            _mShowPanel9 = True
                                            _pRowNo = "10"
                                            _pSubSelect_GRASKHDG_ROW()

                                            If _mFnHasRecord10() = True Then
                                                _mShowPanel10 = True

                                            End If
                                        Else
                                            Exit Sub
                                        End If
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    Exit Sub
                                End If
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else


            Exit Sub
        End If
    End Sub

    Public Sub _mSubGetQuestions_GRASKHDG_2()   '@  Added 20180713

        _pRowNo = "1"
        _pSubSelect_GRASKHDG_ROW_2()

        If _mFnHasRecord1() = True Then
            _mShowPanel1 = True
            _pRowNo = "2"
            _pSubSelect_GRASKHDG_ROW_2()

            If _mFnHasRecord2() = True Then
                _mShowPanel2 = True
                _pRowNo = "3"
                _pSubSelect_GRASKHDG_ROW_2()

                If _mFnHasRecord3() = True Then
                    _mShowPanel3 = True
                    _pRowNo = "4"
                    _pSubSelect_GRASKHDG_ROW_2()

                    If _mFnHasRecord4() = True Then
                        _mShowPanel4 = True
                        _pRowNo = "5"
                        _pSubSelect_GRASKHDG_ROW_2()

                        If _mFnHasRecord5() = True Then
                            _mShowPanel5 = True
                            _pRowNo = "6"
                            _pSubSelect_GRASKHDG_ROW_2()

                            If _mFnHasRecord6() = True Then
                                _mShowPanel6 = True
                                _pRowNo = "7"
                                _pSubSelect_GRASKHDG_ROW_2()

                                If _mFnHasRecord7() = True Then
                                    _mShowPanel7 = True
                                    _pRowNo = "8"
                                    _pSubSelect_GRASKHDG_ROW_2()

                                    If _mFnHasRecord8() = True Then
                                        _mShowPanel8 = True
                                        _pRowNo = "9"
                                        _pSubSelect_GRASKHDG_ROW_2()

                                        If _mFnHasRecord9() = True Then
                                            _mShowPanel9 = True
                                            _pRowNo = "10"
                                            _pSubSelect_GRASKHDG_ROW_2()

                                            If _mFnHasRecord10() = True Then
                                                _mShowPanel10 = True

                                            End If
                                        Else
                                            Exit Sub
                                        End If
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    Exit Sub
                                End If
                            Else
                                Exit Sub
                            End If
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else


            Exit Sub
        End If
    End Sub
#Region "GRASK QTY"
    Public Function _mFnHasRecord1_GRASKQTY() As Boolean
        Try
            _mFnHasRecord1_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec1 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec1 = Trim(._pReturnString(_nSqlDataReader(_inOutputRec1)))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt1 = _mTaxAmt
                            _mFnHasRecord1_GRASKQTY = True
                        Else
                            _mFnHasRecord1_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord2_GRASKQTY() As Boolean
        Try
            _mFnHasRecord2_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec2 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec2 = Trim(._pReturnString(_nSqlDataReader(_inOutputRec2)))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt2 = _mTaxAmt
                            _mFnHasRecord2_GRASKQTY = True
                        Else
                            _mFnHasRecord2_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord3_GRASKQTY() As Boolean
        Try
            _mFnHasRecord3_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec3 = Trim(._pReturnString(_nSqlDataReader(_inOutputRec3)))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt3 = _mTaxAmt
                            _mFnHasRecord3_GRASKQTY = True
                        Else
                            _mFnHasRecord3_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord4_GRASKQTY() As Boolean
        Try
            _mFnHasRecord4_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec4 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec4 = ._pReturnString(_nSqlDataReader(_inOutputRec4))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt4 = _mTaxAmt
                            _mFnHasRecord4_GRASKQTY = True
                        Else
                            _mFnHasRecord4_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord5_GRASKQTY() As Boolean
        Try
            _mFnHasRecord5_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec5 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec5 = ._pReturnString(_nSqlDataReader(_inOutputRec5))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt5 = _mTaxAmt
                            _mFnHasRecord5_GRASKQTY = True
                        Else
                            _mFnHasRecord5_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord6_GRASKQTY() As Boolean
        Try
            _mFnHasRecord6_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec6 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec6 = ._pReturnString(_nSqlDataReader(_inOutputRec6))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt6 = _mTaxAmt
                            _mFnHasRecord6_GRASKQTY = True
                        Else
                            _mFnHasRecord6_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord7_GRASKQTY() As Boolean
        Try
            _mFnHasRecord7_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec7 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec7 = ._pReturnString(_nSqlDataReader(_inOutputRec7))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt7 = _mTaxAmt
                            _mFnHasRecord7_GRASKQTY = True
                        Else
                            _mFnHasRecord7_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord8_GRASKQTY() As Boolean
        Try
            _mFnHasRecord8_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec8 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec8 = ._pReturnString(_nSqlDataReader(_inOutputRec8))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt8 = _mTaxAmt
                            _mFnHasRecord8_GRASKQTY = True
                        Else
                            _mFnHasRecord8_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function _mFnHasRecord9_GRASKQTY() As Boolean
        Try
            _mFnHasRecord9_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec9 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec9 = ._pReturnString(_nSqlDataReader(_inOutputRec9))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt9 = _mTaxAmt
                            _mFnHasRecord9_GRASKQTY = True
                        Else
                            _mFnHasRecord9_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function _mFnHasRecord10_GRASKQTY() As Boolean
        Try
            _mFnHasRecord10_GRASKQTY = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec10 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inTaxRate As Integer = .GetOrdinal("TAXRATE")
                    Dim _inTaxAmt As Integer = .GetOrdinal("TAXAMT")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec10 = ._pReturnString(_nSqlDataReader(_inOutputRec10))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mTaxRate = ._pReturnString(_nSqlDataReader(_inTaxRate))
                                _mTaxAmt = ._pReturnString(_nSqlDataReader(_inTaxAmt))
                            Loop
                            _pTaxAmt10 = _mTaxAmt
                            _mFnHasRecord10_GRASKQTY = True
                        Else
                            _mFnHasRecord10_GRASKQTY = False
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
    '--------------
    Public Function _mFnHasRecord1() As Boolean
        Try
            _mFnHasRecord1 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec1 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")

                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec1 = ._pReturnString(_nSqlDataReader(_inOutputRec1))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord1 = True
                        Else
                            _mFnHasRecord1 = False

                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try



    End Function

    Public Function _mFnHasRecord2() As Boolean
        Try
            _mFnHasRecord2 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec2 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes

                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec2 = ._pReturnString(_nSqlDataReader(_inOutputRec2))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord2 = True
                        Else
                            _mFnHasRecord2 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _mFnHasRecord3() As Boolean
        Try

            _mFnHasRecord3 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec3 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord3 = True
                        Else
                            _mFnHasRecord3 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _mFnHasRecord4() As Boolean
        Try
            _mFnHasRecord4 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec4 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord4 = True
                        Else
                            _mFnHasRecord4 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _mFnHasRecord5() As Boolean
        Try
            _mFnHasRecord5 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec5 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord5 = True
                        Else
                            _mFnHasRecord5 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using


        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _mFnHasRecord6() As Boolean
        Try
            _mFnHasRecord6 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec6 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord6 = True
                        Else
                            _mFnHasRecord6 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _mFnHasRecord7() As Boolean
        Try
            _mFnHasRecord7 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec7 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord7 = True
                        Else
                            _mFnHasRecord7 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using


        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function _mFnHasRecord8() As Boolean
        Try
            _mFnHasRecord8 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec8 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord8 = True
                        Else
                            _mFnHasRecord8 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using


        Catch ex As Exception
            Return False
        End Try


    End Function

    Public Function _mFnHasRecord9() As Boolean
        Try
            _mFnHasRecord9 = False

            Dim _nDataTable3 As New DataTable
            _nDataTable3 = _pDataTable3


            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec9 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord9 = True
                        Else
                            _mFnHasRecord9 = False
                        End If

                    End With
                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _mFnHasRecord10() As Boolean
        Try
            _mFnHasRecord10 = False

            Dim _nDataTable As New DataTable
            _nDataTable = _pDataTable3

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand3.ExecuteReader

                With _nSqlDataReader
                    Dim _inOutputRec3 As Integer = .GetOrdinal("ASKHDG")
                    Dim _inTaxCode As Integer = .GetOrdinal("TAXCODE")
                    Dim _inEffMonth As Integer = .GetOrdinal("EFF_MONTH")
                    Dim _inEffYear As Integer = .GetOrdinal("EFF_YEAR")
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _mOutputRec10 = ._pReturnString(_nSqlDataReader(_inOutputRec3))
                                _mTaxCode = ._pReturnString(_nSqlDataReader(_inTaxCode))
                                _mASKHDG_Month = ._pReturnString(_nSqlDataReader(_inEffMonth))
                                _mASKHDG_Year = ._pReturnString(_nSqlDataReader(_inEffYear))
                            Loop
                            _mFnHasRecord10 = True
                        Else
                            _mFnHasRecord10 = False
                        End If

                    End With

                End With
                _nSqlDataReader.Close()
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Sub DisplayComputedLine()

    '    Try
    '        Dim _nClass As New VS2014.CL.BPLTIMS.cDalBusinessLine

    '        With _nClass
    '            ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
    '            ._pAccount = cPageSession_BusinessLine._pxAccountNo
    '            ._pBusCode = cPageSession_BusinessLine._pxBusCode
    '            ._pBusYear = cPageSession_BusinessLine._pxForYear

    '            Dim _nDataTable As New DataTable
    '            _nDataTable = _pDataTable


    '           Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
    '                With _nSqlDataReader
    '                    Dim _inBFEE As Integer = .GetOrdinal("BUSTAX")
    '                    Dim _inMFEE As Integer = .GetOrdinal("MAYORS")
    '                    Dim _inGFEE As Integer = .GetOrdinal("GARBAGE")
    '                    Dim _inSFEE As Integer = .GetOrdinal("SANITARY")
    '                    Dim _inFFEE As Integer = .GetOrdinal("FIRE")


    '                    Dim _nClassReturnTypes As New ClassReturnTypes
    '                    With _nClassReturnTypes

    '                        If _nSqlDataReader.HasRows Then
    '                            Do While _nSqlDataReader.Read
    '                                _oTextBoxBFee.Text = ._pReturnString(_nSqlDataReader(_inBFEE))
    '                                _oTextBoxMFee.Text = ._pReturnString(_nSqlDataReader(_inMFEE))
    '                                _oTextBoxGFee.Text = ._pReturnString(_nSqlDataReader(_inGFEE))
    '                                _oTextBoxSFee.Text = ._pReturnString(_nSqlDataReader(_inSFEE))

    '                            Loop
    '                        End If
    '                    End With
    '                End With
    '                _nSqlDataReader.Close()

    '            End Using

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub _mFnSaveFeeTemp()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "UPDATE BUSLINE SET " & _
                        "BUSTAX = @_mBUSTAX, MAYORS = @_mMAYORS, GARBAGE = @_mGARBAGE, SANITARY = @_mSANITARY, FIRE = @_mFIRE, " & _
                        "GARBAGE_o = @_mGARBAGE, SANITARY_o = @_mSANITARY, FIRE_o = @_mFIRE, " & _
                        "BT_YEAR = @_mBT_YEAR, MF_YEAR = @_mMF_YEAR, GF_YEAR = @_mGF_YEAR ,SF_YEAR = @_mSF_YEAR "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                _nWhere = "WHERE [ACCTNO] = @_mAccount AND [FORYEAR] = @_mBusYear AND [BUS_CODE] = @_mBusCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mBUSTAX) Then .AddWithValue("@_mBUSTAX", _mBUSTAX)
                If Not String.IsNullOrWhiteSpace(_mMAYORS) Then .AddWithValue("@_mMAYORS", _mMAYORS)
                If Not String.IsNullOrWhiteSpace(_mGARBAGE) Then .AddWithValue("@_mGARBAGE", _mGARBAGE)
                If Not String.IsNullOrWhiteSpace(_mSANITARY) Then .AddWithValue("@_mSANITARY", _mSANITARY)
                If Not String.IsNullOrWhiteSpace(_mFIRE) Then .AddWithValue("@_mFIRE", _mFIRE)
                If Not String.IsNullOrWhiteSpace(_mGARBAGE) Then .AddWithValue("@_mGARBAGE2", _mGARBAGE)
                If Not String.IsNullOrWhiteSpace(_mSANITARY) Then .AddWithValue("@_mSANITARY2", _mSANITARY)
                If Not String.IsNullOrWhiteSpace(_mFIRE) Then .AddWithValue("@_mFIRE2", _mFIRE)
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mBusYear) Then .AddWithValue("@_mBusYear", _mBusYear)
                If Not String.IsNullOrWhiteSpace(_mBusCode) Then .AddWithValue("@_mBusCode", _mBusCode)
                If Not String.IsNullOrWhiteSpace(_mBT_YEAR) Then .AddWithValue("@_mBT_YEAR", _mBT_YEAR)
                If Not String.IsNullOrWhiteSpace(_mMF_YEAR) Then .AddWithValue("@_mMF_YEAR", _mMF_YEAR)
                If Not String.IsNullOrWhiteSpace(_mGF_YEAR) Then .AddWithValue("@_mGF_YEAR", _mGF_YEAR)
                If Not String.IsNullOrWhiteSpace(_mSF_YEAR) Then .AddWithValue("@_mSF_YEAR", _mSF_YEAR)
            End With

            _mSqlCommand.ExecuteNonQuery()


            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub _mSubClearBuslineWEB(ByVal _nAcctNo As String) ' @Added 2019522
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "Delete from Busline where AcctNo = '" & _nAcctNo & "'"

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()


        Catch ex As Exception

        End Try


    End Sub

    Public Sub _mSubClearBUSEXTN_WEB(ByVal _nAcctNo As String) ' @Added 2019522
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "Delete from BUSEXTN where AcctNo = '" & _nAcctNo & "'"

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
            _mSqlCommand.Dispose()


        Catch ex As Exception

        End Try


    End Sub

#End Region


End Class

