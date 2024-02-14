using ClassLibrary1;
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
        var resultadoTransferencia = Assert.Throws<ArgumentException>
            (() => transferencia.Transferir(DayOfWeek.Tuesday, 10, valorTransferencia));

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
        var resultadoTransferencia = Assert.Throws<Exception>
            (() => transferencia.Transferir(DayOfWeek.Saturday, 10, valorTransferencia));

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
        var resultadoTransferencia = Assert.Throws<Exception>
            (() => transferencia.Transferir(DayOfWeek.Tuesday, 4, valorTransferencia));
        
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
        transferencia.Transferir(DayOfWeek.Tuesday, 14, valorTransferencia);

        //Assert
        contaOrigem.saldoConta.Should().Be(500);
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
        transferencia.Transferir(DayOfWeek.Tuesday, 14, valorTransferencia);

        //Assert
        contaDestino.saldoConta.Should().Be(2500);
    }
}
