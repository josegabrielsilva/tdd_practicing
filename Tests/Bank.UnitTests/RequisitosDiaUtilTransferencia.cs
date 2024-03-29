﻿using Bank.Core;
using FluentAssertions;

namespace UnitTests;

public class RequisitosDiaUtilTransferencia
{
    [Theory]
    [InlineData(DayOfWeek.Sunday)]
    [InlineData(DayOfWeek.Saturday)]
    public void ValidarDiaUtilTransferencia_DiaTransferenciaFinalDeSemana_DeveRetornarFalse(DayOfWeek day) 
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
    public void ValidarDiaUtilTransferencia_DiaTransferenciaDeSegundaASexta_DeveRetornarTrue(DayOfWeek day) 
    {
        //Act
        var resultadoValidacao = RegrasDoBanco.ValidarDiaUtilTransferencia(day);

        //Assert
        resultadoValidacao.Should().BeTrue();
    }
}