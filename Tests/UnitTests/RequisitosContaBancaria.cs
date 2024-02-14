using FluentAssertions;
using ClassLibrary1;

namespace UnitTests
{
    public class RequisitosContaBancaria
    {
        [Fact]
        public void Deposito_QuandoRealizarDeposito_DeveRetornarOValorInicialAcrescidoDoValorDepositado()
        {
            //Arrange
            decimal valorDeposito = 10;
            const decimal valorInicialDaContaBancaria = 100;
            var conta = new ContaBancaria(valorInicialDaContaBancaria);

            //Act
            var valorAposDeposito = conta.Depositar(valorDeposito);

            //Assert
            valorAposDeposito.Should().Be(valorInicialDaContaBancaria + valorDeposito);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Deposito_QuandoValorDepositoForMenorOuIgualAZero_DeveRetornarException(int valorDeposito)
        {
            //Arrange
            var conta = new ContaBancaria(10);

            //Act
            var result = Assert.Throws<ArgumentException>(() => conta.Depositar(valorDeposito));

            //Assert
            result.Message.Should().Contain(ContaBancaria.DeveSerMaiorQueZero);
        }

        [Fact]
        public void Saque_QuandoValorDeSaqueForMaiorQueSaldoDisponivel_DeveRetornarException()
        {
            //Arrange
            const decimal valorInicialContaBancaria = 100;
            const decimal valorDeSaque = 1000;
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
        public void Saque_QuandoRealizarSaque_DeveRetornarValorInicialContaMenosValorSolicitadoNoSaque()
        {
            //Arrange
            const decimal valorInicialContaBancaria = 10000;
            const decimal valorDeSaque = 500;
            var conta = new ContaBancaria(valorInicialContaBancaria);

            //Act
            var resultadoSaque = conta.Saque(valorDeSaque);

            //Assert
            resultadoSaque.Should().Be(9500);
        }
    }
}