using Bank.Core;
using FluentAssertions;

namespace UnitTests;

public class RequisitosTransferenciaDeSaldo
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Transferencia_QuandoValorTransferenciaForMenorOuIgualAZero_DeveRetornarException(decimal valorTransferencia) 
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
    public void Transferencia_QuandoTransferenciaEstiverForaDiaUtil_DeveRetornarException() 
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
    public void Transferencia_QuandoTransferenciaEstiverForaHorario_DeveRetornarException() 
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
    public void Transferencia_QuandoRealizarTransferenciaOValorTransferido_DeveSerDecrementadoDoSaldoAtualDaContaOrigem() 
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
    }

    [Fact]
    public void Transferencia_QuandoRealizarTransferenciaOValorTransferido_DeveSerAcrescidoNoSaldoAtualContaDestino()
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
        const decimal saldoContaDestinoAposTransferencia = 2500;
        contaDestino.SaldoConta.Should().Be(saldoContaDestinoAposTransferencia);
    }
}
