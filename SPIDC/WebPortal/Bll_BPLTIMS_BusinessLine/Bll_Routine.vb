Partial Public Class BPLTIMSNewBusinessApplication

    Public Sub _PassValuetoClassLoader()
        cLoader_BPLTIMS._pAREA = _otextArea.Value
        cLoader_BPLTIMS._pCAPITAL = _otextCapital.Value
        cLoader_BPLTIMS._pGROSSREC = "0.00"

        ''== For BusExtn
        cLoader_BPLTIMS._pSTATCODE = "N"

    End Sub


End Class
