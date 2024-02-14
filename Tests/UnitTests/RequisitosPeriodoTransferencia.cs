using ClassLibrary1;
using FluentAssertions;

namespace UnitTests;

public class RequisitosPeriodoTransferencia
{
    [Fact]
    internal void ValidarHoraLimiteTransferencia_SeHorarioTransferenciaMenorQueHorarioInicio_DeveRetornarFalse() 
    {
        //Arrange
        const int horaTransferencia = 4;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeFalse();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_SeHorarioTransferenciaMaiorQueHorarioFim_DeveRetornarFalse() 
    {
        //Arrange
        const int horaTransferencia = 19;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeFalse();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_SeHorarioTransferenciaDentroDoPeriodo_DeveRetornarTrue() 
    {
        //Arrange
        const int horaTransferencia = 14;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_SeHorarioTransferenciaIgualAHorarioInicio_DeveRetornarTrue()
    {
        //Arrange
        const int horaTransferencia = RegrasDoBanco.HoraInicioTransferencia;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }

    [Fact]
    internal void ValidarHoraLimiteTransferencia_SeHorarioTransferenciaIgualAHorarioFim_DeveRetornarTrue()
    {
        //Arrange
        const int horaTransferencia = RegrasDoBanco.HoraFimTransferencia;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }
}