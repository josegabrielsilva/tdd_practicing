using ClassLibrary1;
using FluentAssertions;

namespace UnitTests;

public class RequisitosPeriodoTransferencia
{
    [Fact]
    internal void SeHorarioTransferenciaMenorQueHorarioInicioDeveRetornarFalse() 
    {
        //Arrange
        const int horaTransferencia = 4;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeFalse();
    }

    [Fact]
    internal void SeHorarioTransferenciaMaiorQueHorarioFimDeveRetornarFalse() 
    {
        //Arrange
        const int horaTransferencia = 19;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeFalse();
    }

    [Fact]
    internal void SeHorarioTransferenciaDentroDoPeriodoDeveRetornarTrue() 
    {
        //Arrange
        const int horaTransferencia = 14;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }

    [Fact]
    internal void SeHorarioTransferenciaIgualAHorarioInicioDeveRetornarTrue()
    {
        //Arrange
        const int horaTransferencia = RegrasDoBanco.HoraInicioTransferencia;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }

    [Fact]
    internal void SeHorarioTransferenciaIgualAHorarioFimDeveRetornarTrue()
    {
        //Arrange
        const int horaTransferencia = RegrasDoBanco.HoraFimTransferencia;

        //Act
        var horaValida = RegrasDoBanco.ValidarHoraLimiteTransferencia(horaTransferencia);

        //Assert
        horaValida.Should().BeTrue();
    }
}