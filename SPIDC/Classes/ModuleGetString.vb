Imports System.Data.SqlClient
Imports System.Data

Module ModuleGetString
    Public Function GetString(Prmtr As String, _
                            _cnt As SqlConnection, _
                        FldUse As Integer, _
                        MsgNFnd As String, _
                        SW As Integer) As String
        Dim _sqlcommand As New SqlCommand
        If _cnt.State = ConnectionState.Closed Then _cnt.Open()

        '_con(Prmtr, _cnt)
        _sqlcommand = New SqlCommand(Prmtr, _cnt)

        Dim _read As SqlDataReader = _sqlcommand.ExecuteReader

        If _read.HasRows = False Then
            If SW = 1 Then
                If Not MsgNFnd = "" Then

                End If
            Else
                GetString = CStr(False)
            End If
        Else
            If SW = 1 Then ' String,Integer
                _read.Read()
                GetString = _read.Item(FldUse).ToString
                If VarType(GetString) = vbNull Then
                    GetString = "0"
                End If
            Else
                GetString = CStr(True)
            End If
        End If
        _read.Close()
        _sqlcommand.Dispose()
    End Function
End Module
