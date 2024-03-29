﻿namespace Bank.Core;

public class TransferenciaEntreContas(ContaBancaria contaOrigem, ContaBancaria contaDestino)
{
    public const string ValorTransferenciaDeveSerMaiorQueZero = "Deve ser maior que zero.";
    public const string TransferenciaForaHorario = "Transferencia fora de horário.";
    public const string TransferenciaForaDiaUtil = "Transferencia fora de dia util.";
    public Guid Id { get; private set; } = Guid.NewGuid();
    private ContaBancaria ContaOrigem = contaOrigem;
    private ContaBancaria ContaDestino = contaDestino;

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

        ContaOrigem.Sacar(valorTransferencia);

        ContaDestino.Depositar(valorTransferencia);
    }
}