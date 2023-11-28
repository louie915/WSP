
#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Data
Imports Microsoft.VisualBasic.Devices 'CARL IMPORT
Imports System.IO
Imports System.Drawing


#End Region

Public Class cDalPermit


    Inherits System.Web.UI.Page
    'Usman Added 10-13-23
#Region ""

    Public Function getRowPermit(FieldToGet As String, field As String, table As String, Optional condField As String = "") As String
        Try
            Dim val As String
            Dim cond As String = IIf(condField.Trim <> "", " WHERE " & condField, "")
            Dim getQuer As String = "SELECT DISTINCT " & field.ToUpper & " FROM " & table & cond
            DisplayOutput(getQuer)
            Dim _TempCmd As New SqlCommand(getQuer, cGlobalConnections._pSqlCxn_BPLTAS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            _TempReader.Read()
            val = IIf(_TempReader.HasRows, _TempReader.Item(FieldToGet).ToString, "")
            _TempReader.Close()
            _TempCmd.Dispose()
            getRowPermit = val
        Catch ex As Exception
            getRowPermit = ""
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
#End Region





End Class
