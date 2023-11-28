Public Class cGridview

    Public Shared Sub _pGridviewBind(ByVal _nDataTable As DataTable, ByVal _nGridview As GridView)
        Try
            _nGridview.DataSource = _nDataTable
            _nGridview.DataBind()

        Catch ex As Exception

        End Try
    End Sub

    Shared Sub pEmptyGridView(ByVal _nDataTable As DataTable, ByVal _nGridview As GridView, ByVal msg As String)
        Try

            If _nDataTable.Rows.Count = 0 Then
                _nDataTable.Rows.Add(_nDataTable.NewRow())
                _nGridview.DataSource = _nDataTable
                _nGridview.DataBind()
                Dim columnCount As Integer = _nGridview.Rows(0).Cells.Count
                _nGridview.Rows(0).Cells.Clear()
                _nGridview.Rows(0).Cells.Add(New TableCell())
                _nGridview.Rows(0).Cells(0).ColumnSpan = columnCount
                _nGridview.Rows(0).Cells(0).Text = "<font color=Red><center>" & msg & "</center></font>"
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class
