namespace Bank.Core;

public class RegrasDoBanco
{
    public const short HoraInicioTransferencia = 8;
    public const short HoraFimTransferencia = 17;

    public static bool ValidarHoraLimiteTransferencia(int hora)
        => hora >= HoraInicioTransferencia && hora <= HoraFimTransferencia;

    public const DayOfWeek PrimeiroDiaUtilTransferencia = DayOfWeek.Monday;
    public const DayOfWeek UltimoDiaUtilTransferencia = DayOfWeek.Friday;

    public static bool ValidarDiaUtilTransferencia(DayOfWeek diaTransferencia)
        => diaTransferencia >= PrimeiroDiaUtilTransferencia && diaTransferencia <= UltimoDiaUtilTransferencia;
}