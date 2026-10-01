using GamerProfile.App;

namespace GamerProfile.Tests;

/// <summary>
/// Testes unitários do PerfilJogadorService cobrindo os três tipos de retorno:
/// string, int e bool.
/// </summary>
public class PerfilJogadorServiceTests
{
    private readonly PerfilJogadorService _service = new();

    // Teste 1 (string): valida se GerarTagUsuario gera a formatação correta "nickname#codigo".
    [Fact]
    public void GerarTagUsuario_DeveRetornarNicknameECodigoSeparadosPorCerquilha()
    {
        // Arrange
        string nickname = "Aragorn";
        string codigo = "1042";

        // Act
        string resultado = _service.GerarTagUsuario(nickname, codigo);

        // Assert
        Assert.Equal("Aragorn#1042", resultado);
    }

    // Teste 2 (int): valida se CalcularXPTotal soma as fases e aplica o bônus fixo de 100.
    [Fact]
    public void CalcularXPTotal_DeveSomarAsFasesEAplicarBonusDe100()
    {
        // Arrange
        int xpFase1 = 200;
        int xpFase2 = 300;
        int valorEsperado = 600; // 200 + 300 + 100 (bônus fixo)

        // Act
        int resultado = _service.CalcularXPTotal(xpFase1, xpFase2);

        // Assert
        Assert.Equal(valorEsperado, resultado);
    }

    // Teste 3 (bool): valida a regra de elegibilidade para partidas ranqueadas.
    [Fact]
    public void EEligivelParaRanked_DeveRetornarTrueParaNivel15OuSuperior()
    {
        // Act
        bool resultadoNivel15 = _service.EEligivelParaRanked(15);
        bool resultadoNivel20 = _service.EEligivelParaRanked(20);

        // Assert
        Assert.True(resultadoNivel15);
        Assert.True(resultadoNivel20);
    }

    [Fact]
    public void EEligivelParaRanked_DeveRetornarFalseParaNivelInferiorA15()
    {
        // Act
        bool resultado = _service.EEligivelParaRanked(14);

        // Assert
        Assert.False(resultado);
    }
}
