using ClassLibrary1;
using FluentAssertions;

namespace UnitTests;

public class RequisitosDiaUtilTransferencia
{
    [Theory]
    [InlineData(DayOfWeek.Sunday)]
    [InlineData(DayOfWeek.Saturday)]
    public void SeDiaTransferenciaForFinalDeSemanaDeveRetornarFalse(DayOfWeek day) 
    {
        //Act
        var resultadoValidacao = RegrasDoBanco.ValidarDiaUtilTransferencia(day);

        //Assert
        resultadoValidacao.Should().BeFalse();
    }

    [Theory]
    [InlineData(DayOfWeek.Monday)]
    [InlineData(DayOfWeek.Tuesday)]
    [InlineData(DayOfWeek.Wednesday)]
    [InlineData(DayOfWeek.Thursday)]
    [InlineData(DayOfWeek.Friday)]
    public void SeDiaTransferenciaForDeSegundaASextaDeveRetornarTrue(DayOfWeek day) 
    {
        //Act
        var resultadoValidacao = RegrasDoBanco.ValidarDiaUtilTransferencia(day);

        //Assert
        resultadoValidacao.Should().BeTrue();
    }
}