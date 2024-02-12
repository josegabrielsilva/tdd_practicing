using FluentAssertions;
using ClassLibrary1;

namespace UnitTests;

public class RequisitosTransferenciaDeSaldo
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Transferencia_QuandoValorTransferenciaForMenorOuIgualAZeroDeveRetornarException(decimal valorTransferencia) 
    {
        //Arrange
        var contaOrigem = new ContaBancaria(1000);
        var contaDestino = new ContaBancaria(1000);
        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        var dataValidaTransferencia = new DateTime(2024, 2, 12, 9, 10, 1);

        //Act
        var resultadoTransferencia = Assert.Throws<ArgumentException>(() => transferencia.Transferir(
            dataValidaTransferencia, valorTransferencia));

        //Assert
        resultadoTransferencia.Message.Should().Contain(TransferenciaEntreContas.ValorTransferenciaDeveSerMaiorQueZero);
    }

    [Fact]
    public void Transferencia_QuandoTransferenciaEstiverForaDiaUtilDeveRetornarException() 
    {
        //Arrange
        var contaOrigem = new ContaBancaria(1000);
        var contaDestino = new ContaBancaria(1000);
        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;
        var dataForaDiaUtil = new DateTime(2024, 2, 10, 9, 10, 1);

        //Act
        var resultadoTransferencia = Assert.Throws<Exception>(() => transferencia.Transferir(dataForaDiaUtil, valorTransferencia));
        //Assert
        resultadoTransferencia.Message.Should().Contain(TransferenciaEntreContas.TransferenciaForaDiaUtil);
    }
    
    [Fact]
    public void Transferencia_QuandoTransferenciaEstiverForaHorarioDeveRetornarException() 
    {
        //Arrange
        var contaOrigem = new ContaBancaria(1000);
        var contaDestino = new ContaBancaria(1000);
        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;
        var dataForaHorario = new DateTime(2024, 2, 12, 6, 10, 1);

        //Act
        var resultadoTransferencia = Assert.Throws<Exception>(() => transferencia.Transferir(dataForaHorario, valorTransferencia));
        
        //Assert
        resultadoTransferencia.Message.Should().Contain(TransferenciaEntreContas.TransferenciaForaHorario);
    }

    [Fact]
    public void Transferencia_QuandoRealizarTransferenciaOValorTransferidoDeveSerDecrementadoDoSaldoAtualDaContaOrigem() 
    {
        //Arrange
        const decimal ValorInicialContaOrigem = 1000;
        var contaOrigem = new ContaBancaria(ValorInicialContaOrigem);

        const decimal valorInicialContaDestino = 2000;
        var contaDestino = new ContaBancaria(valorInicialContaDestino);

        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;

        var dataValidaTransferencia = new DateTime(2024, 2, 12, 9, 10, 1);

        //Act
        transferencia.Transferir(dataValidaTransferencia, valorTransferencia);

        //Assert

        contaOrigem.saldoConta.Should().Be(500);
    }

    [Fact]
    public void Transferencia_QuandoRealizarTransferenciaOValorTransferidoDeveSerAcrescidoNoSaldoAtualContaDestino()
    {
        //Arrange
        const decimal ValorInicialContaOrigem = 1000;
        var contaOrigem = new ContaBancaria(ValorInicialContaOrigem);

        const decimal valorInicialContaDestino = 2000;
        var contaDestino = new ContaBancaria(valorInicialContaDestino);

        var transferencia = new TransferenciaEntreContas(contaOrigem, contaDestino);
        const decimal valorTransferencia = 500;

        var dataValidaTransferencia = new DateTime(2024, 2, 12, 9, 10, 1);

        //Act
        transferencia.Transferir(dataValidaTransferencia, valorTransferencia);

        //Assert
        contaDestino.saldoConta.Should().Be(2500);
    }
}
