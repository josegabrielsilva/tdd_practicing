namespace ClassLibrary1;

public class TransferenciaEntreContas(ContaBancaria contaOrigem, ContaBancaria contaDestino)
{
    public const string ValorTransferenciaDeveSerMaiorQueZero = "Deve ser maior que zero.";
    public const string TransferenciaForaHorario = "Transferencia fora de horário.";
    public const string TransferenciaForaDiaUtil = "Transferencia fora de dia util.";
    public Guid Id { get; private set; } = Guid.NewGuid();
    private ContaBancaria contaOrigem = contaOrigem;
    private ContaBancaria contaDestino = contaDestino;

    public void Transferir(
        DayOfWeek diaSemanaTransferencia,
        int horaTransferencia,
        decimal valorTransferencia)
    {
        if (valorTransferencia <= 0)
            throw new ArgumentException(ValorTransferenciaDeveSerMaiorQueZero, nameof(valorTransferencia));

        if(!RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia))
            throw new Exception(TransferenciaForaHorario);

        if (!RegrasDoBanco.ValidarDiaUtilTransferencia(diaSemanaTransferencia))
            throw new Exception(TransferenciaForaDiaUtil);

        contaOrigem.Saque(valorTransferencia);
        contaDestino.Depositar(valorTransferencia);
    }
}