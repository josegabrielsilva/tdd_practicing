
namespace Bank.Core;

public class ContaBancaria
{
    public const string DeveSerMaiorQueZero = "Deve ser maior que zero.";
    public const string ValorSaqueExcedeSaldoDisponivel = "Valor de saque excede saldo disponível.";
    public const string ValorSaqueExcedeLimiteDiario = "Valor de saque excede o limite diário.";
    public decimal SaldoConta { get; private set; }
    private readonly decimal limiteDiarioSaque = 1000;

    public ContaBancaria(decimal saldoConta)
    {
        this.SaldoConta = saldoConta;
    }

    public ContaBancaria(decimal saldoConta, decimal limiteDiarioSaque)
    {
        this.SaldoConta = saldoConta;
        this.limiteDiarioSaque = limiteDiarioSaque;
    }

    public decimal Depositar(decimal valorDeposito)
    {
        if (valorDeposito <= 0)
            throw new ArgumentException(DeveSerMaiorQueZero, nameof(valorDeposito));

        SaldoConta += valorDeposito;

        return SaldoConta;
    }

    public decimal Sacar(decimal valorSaque)
    {
        if (valorSaque > SaldoConta)
            throw new ArgumentException(ValorSaqueExcedeSaldoDisponivel, nameof(valorSaque));

        if(valorSaque > limiteDiarioSaque)
            throw new ArgumentException(ValorSaqueExcedeLimiteDiario, nameof(valorSaque));

        if (valorSaque <= 0)
            throw new ArgumentException(DeveSerMaiorQueZero, nameof(valorSaque));

        SaldoConta -= valorSaque;

        return SaldoConta;
    }
}