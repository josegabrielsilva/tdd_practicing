using Bank.Core;
using FluentAssertions;

namespace UnitTests;

public class RequisitosTransferenciaDeSaldo
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Transferir_ValorTransferenciaMenorOuIgualAZero_DeveRetornarException(decimal valorTransferencia) 
    {
        //Arrange
        var contaOrigem = new ContaBancaria(1000);
        var contaDestino = new ContaBancaria(1000);
        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);

        //Act
        const DayOfWeek diaTransferencia = DayOfWeek.Tuesday;
        const int horaTransferencia = 10;
        var resultadoTransferencia = Assert.Throws<ArgumentException>
            (() => transferencia.Transferir(diaTransferencia, horaTransferencia, valorTransferencia));

        //Assert
        resultadoTransferencia.Message.Should().Contain(TransferenciaEntreContas.ValorTransferenciaDeveSerMaiorQueZero);
    }

    [Fact]
    public void Transferir_TransferenciaForaDiaUtil_DeveRetornarException() 
    {
        //Arrange
        var contaOrigem = new ContaBancaria(1000);
        var contaDestino = new ContaBancaria(1000);
        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;

        //Act
        const DayOfWeek diaTransferencia = DayOfWeek.Saturday;
        const int horaTransferencia = 10;
        var resultadoTransferencia = Assert.Throws<Exception>
            (() => transferencia.Transferir(diaTransferencia, horaTransferencia, valorTransferencia));

        //Assert
        resultadoTransferencia.Message.Should().Contain(TransferenciaEntreContas.TransferenciaForaDiaUtil);
    }
    
    [Fact]
    public void Transferir_EstiverForaHorario_DeveRetornarException() 
    {
        //Arrange
        var contaOrigem = new ContaBancaria(1000);
        var contaDestino = new ContaBancaria(1000);
        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;

        //Act
        const DayOfWeek diaTransferencia = DayOfWeek.Tuesday;
        const int horaTransferencia = 4;
        var resultadoTransferencia = Assert.Throws<Exception>
            (() => transferencia.Transferir(diaTransferencia, horaTransferencia, valorTransferencia));
        
        //Assert
        resultadoTransferencia.Message.Should().Contain(TransferenciaEntreContas.TransferenciaForaHorario);
    }

    [Fact]
    public void Transferir_DiaEHorarioPermitido_DeveDecrementarSaldoContaOrigemEIncrementarSaldoContaDestino() 
    {
        //Arrange
        const decimal ValorInicialContaOrigem = 1000;
        var contaOrigem = new ContaBancaria(ValorInicialContaOrigem);

        const decimal valorInicialContaDestino = 2000;
        var contaDestino = new ContaBancaria(valorInicialContaDestino);

        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;

        //Act
        const DayOfWeek diaTransferencia = DayOfWeek.Tuesday;
        const int horaTransferencia = 14;
        transferencia.Transferir(diaTransferencia, horaTransferencia, valorTransferencia);

        //Assert
        const decimal saldoContaOrigemAposTransferencia = 500;
        contaOrigem.SaldoConta.Should().Be(saldoContaOrigemAposTransferencia);

        const decimal saldoContaDestinoAposTransferencia = 2500;
        contaDestino.SaldoConta.Should().Be(saldoContaDestinoAposTransferencia);
    }
}
