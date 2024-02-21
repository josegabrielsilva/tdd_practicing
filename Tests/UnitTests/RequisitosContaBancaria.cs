using FluentAssertions;
using Bank.Core;

namespace UnitTests
{
    public class RequisitosContaBancaria
    {
        [Fact]
        public void Deposito_QuandoSolicitado_DeveRetornarSaldoInicialAcrescidoDoValorDepositado()
        {
            //Arrange
            const decimal valorDeposito = 10;
            const decimal saldoInicialDaContaBancaria = 100;
            var conta = new ContaBancaria(saldoInicialDaContaBancaria);

            //Act
            var valorAposDeposito = conta.Depositar(valorDeposito);

            //Assert
            const decimal saldoContaBancariaAposDeposito = 110;
            valorAposDeposito.Should().Be(saldoContaBancariaAposDeposito);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deposito_QuandoValorDepositoForMenorOuIgualAZero_DeveRetornarException(int valorDeposito)
        {
            //Arrange
            const decimal saldoInicialDaContaBancaria = 10;
            var conta = new ContaBancaria(saldoInicialDaContaBancaria);

            //Act
            var result = Assert.Throws<ArgumentException>(() => conta.Depositar(valorDeposito));

            //Assert
            result.Message.Should().Contain(ContaBancaria.DeveSerMaiorQueZero);
        }

        [Fact]
        public void Saque_QuandoValorDeSaqueForMaiorQueSaldoDisponivel_DeveRetornarException()
        {
            //Arrange
            const decimal valorDeSaque = 1000;
            const decimal valorInicialContaBancaria = 100;
            var conta = new ContaBancaria(valorInicialContaBancaria);

            //Act
            var resultadoSaque = Assert.Throws<ArgumentException>(() => conta.Saque(valorDeSaque));

            //Assert
            resultadoSaque.Message.Should().Contain(ContaBancaria.ValorSaqueExcedeSaldoDisponivel);
        }

        [Fact]
        public void Saque_QuandoValorDeSaqueExcederLimiteDiario_DeveRetornarException()
        {
            //Arrange
            const decimal valorInicialContaBancaria = 10000;
            const decimal limiteDiarioContaBancaria = 5000;
            const decimal valorDeSaque = 5500;
            var conta = new ContaBancaria(valorInicialContaBancaria, limiteDiarioContaBancaria);

            //Act
            var resultadoSaque = Assert.Throws<ArgumentException>(() => conta.Saque(valorDeSaque));

            //Assert
            resultadoSaque.Message.Should().Contain(ContaBancaria.ValorSaqueExcedeLimiteDiario);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Saque_QuandoValorDeSaqueForMenorOuIgualAZero_DeveRetornarException(decimal valorDeSaque)
        {
            //Arrange
            const decimal valorInicialContaBancaria = 10000;
            var conta = new ContaBancaria(valorInicialContaBancaria);

            //Act
            var resultadoSaque = Assert.Throws<ArgumentException>(() => conta.Saque(valorDeSaque));

            //Assert
            resultadoSaque.Message.Should().Contain(ContaBancaria.DeveSerMaiorQueZero);
        }

        [Fact]
        public void Saque_QuandoRealizarSaque_DeveRetornarSaldoInicialContaMenosValorSacado()
        {
            //Arrange
            const decimal saldoInicialContaBancaria = 10000;
            const decimal valorDeSaque = 500;
            var conta = new ContaBancaria(saldoInicialContaBancaria);

            //Act
            var resultadoSaque = conta.Saque(valorDeSaque);

            //Assert
            const decimal saldoContaBancariaAposSaque = 9500;
            resultadoSaque.Should().Be(saldoContaBancariaAposSaque);
        }
    }
}