Public Class cEmptyGridview

    Shared Sub pEmpyGridViewWithHeader(ByVal grd As GridView, ByVal dt As DataTable, ByVal msg As String)
        Try

            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow())
                grd.DataSource = dt
                grd.DataBind()
                Dim columnCount As Integer = grd.Rows(0).Cells.Count
                grd.Rows(0).Cells.Clear()
                grd.Rows(0).Cells.Add(New TableCell())
                grd.Rows(0).Cells(0).ColumnSpan = columnCount
                grd.Rows(0).Cells(0).Text = "<font color=Red><center>" & msg & "</center></font>"
            End If

        Catch ex As Exception
        End Try
    End Sub

End Class
