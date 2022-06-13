Public Class BusinessEnum

    Public Enum enumFichRemesaPago
        'CSB34 = 0
        'Confirming = 1
        'CSB341 = 2
        'CSB68 = 3
        CSB3414 = 4
    End Enum

    Public Enum TipoMandato
        CORE
        B2B
    End Enum

    Public Enum MandatoTipoPago
        Recurrente
        Unico
    End Enum

    Public Enum TipoFicheroBancario
        Core        '//Adeudo Directo Básico        (CSB 19.14)
        B2B         '//Adeudo Directo B2B           (CSB 19.44) 
        CSB34_14    '//Servicio de Transferencias   (CSB 34.14)
    End Enum


    Public Enum MandatoEstado
        PdteFirma = 0
        Aceptado = 1
    End Enum

End Class
