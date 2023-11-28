Public Class cCourier

    '' Get LGU Profile
    Public Shared Function _GetCourier_KeriDelivery(ByRef _nURL As String) As Boolean
        _GetCourier_KeriDelivery = False
        Try

            Dim _nLGU As String = cSessionLGUProfile._pLGU_Name()

            Select Case True

                Case _nLGU.ToUpper.Contains("PASAY")
                    _nURL = "https://kericity-portal.keridelivery.com/?department=pasay_bplo"
                    Return True

                Case _nLGU.ToUpper.Contains("MUNTINLUPA")
                    _nURL = "https://kericity-portal.keridelivery.com/?department=muntinlupa_bplo" ' &redirect_url=https://best.muntinlupacity.gov.ph
                    Return True

            End Select

        Catch ex As Exception
            _nURL = Nothing
            Return True

        End Try
    End Function

    Public Shared Function _Init_Courier(_olink_Keri As HyperLink) As Boolean

        _Init_Courier = False
        Dim URLKeri As String = Nothing
        _Init_Courier = _GetCourier_KeriDelivery(URLKeri)
        _olink_Keri.NavigateUrl = URLKeri

    End Function

    '' Is Courier Enabled



End Class
