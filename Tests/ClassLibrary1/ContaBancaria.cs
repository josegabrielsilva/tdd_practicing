
namespace ClassLibrary1;

public class ContaBancaria
{
    public const string DeveSerMaiorQueZero = "Deve ser maior que zero.";
    public const string ValorSaqueExcedeSaldoDisponivel = "Valor de saque excede saldo disponível.";
    public const string ValorSaqueExcedeLimiteDiario = "Valor de saque excede o limite diário.";
    public decimal saldoConta { get; private set; }
    private decimal limiteDiarioSaque = 1000;

    public ContaBancaria(decimal saldoConta)
    {
        this.saldoConta = saldoConta;
    }
    public ContaBancaria(decimal saldoConta, decimal limiteDiarioSaque)
    {
        this.saldoConta = saldoConta;
        this.limiteDiarioSaque = limiteDiarioSaque;
    }
    public decimal Depositar(decimal valorDeposito)
    {
        if (valorDeposito <= 0)
            throw new ArgumentException(DeveSerMaiorQueZero, nameof(valorDeposito));
        saldoConta += valorDeposito;
        return saldoConta;
    }

    public decimal Saque(decimal valorSaque)
    {
        if (valorSaque > saldoConta)
            throw new ArgumentException(ValorSaqueExcedeSaldoDisponivel, nameof(valorSaque));

        if(valorSaque > limiteDiarioSaque)
            throw new ArgumentException(ValorSaqueExcedeLimiteDiario, nameof(valorSaque));

        if (valorSaque <= 0)
            throw new ArgumentException(DeveSerMaiorQueZero, nameof(valorSaque));
        saldoConta -= valorSaque;
        return saldoConta;
    }
}