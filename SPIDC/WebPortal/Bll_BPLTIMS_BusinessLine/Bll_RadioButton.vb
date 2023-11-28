Partial Public Class BPLTIMSNewBusinessApplication

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim _nValue As String = Nothing
        _nValue = RadioButtonList1.SelectedValue
        GetDataBusline(_nValue)


    End Sub

End Class
