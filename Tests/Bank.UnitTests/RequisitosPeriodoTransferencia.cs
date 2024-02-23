using Bank.Core;
using FluentAssertions;

namespace UnitTests;

public class RequisitosPeriodoTransferencia
{
    [Fact]
    internal void ValidarHoraLimiteTransferencia_HoraTransferenciaMenorQueHoraInicial_DeveRetornarFalse() 
    {
        //Arrange
        const int horaTransferencia = 4;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeFalse();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_HoraTransferenciaMaiorQueHoraFim_DeveRetornarFalse() 
    {
        //Arrange
        const int horaTransferencia = 19;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeFalse();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_HoraTransferenciaDentroDoIntervalo_DeveRetornarTrue() 
    {
        //Arrange
        const int horaTransferencia = 14;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_HoraTransferenciaIgualHoraInicial_DeveRetornarTrue()
    {
        //Arrange
        const int horaTransferencia = RegrasDoBanco.HoraInicioTransferencia;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_HoraTransferenciaIgualHoraFim_DeveRetornarTrue()
    {
        //Arrange
        const int horaTransferencia = RegrasDoBanco.HoraFimTransferencia;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }
}