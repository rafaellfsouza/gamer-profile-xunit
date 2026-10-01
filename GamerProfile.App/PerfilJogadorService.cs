namespace GamerProfile.App;

/// <summary>
/// Serviço responsável pelas regras de negócio do cadastro de jogadores.
/// </summary>
public class PerfilJogadorService
{
    /// <summary>
    /// Bônus fixo de XP aplicado ao total calculado das fases.
    /// </summary>
    private const int BonusFixoXp = 100;

    /// <summary>
    /// Nível mínimo exigido para o jogador participar de partidas ranqueadas.
    /// </summary>
    private const int NivelMinimoRanked = 15;

    /// <summary>
    /// Gera a tag do usuário concatenando o nickname e o código com o caractere '#'.
    /// Exemplo: ("Aragorn", "1042") retorna "Aragorn#1042".
    /// </summary>
    /// <param name="nickname">Apelido do jogador.</param>
    /// <param name="codigo">Código numérico do jogador.</param>
    /// <returns>Tag no formato "nickname#codigo".</returns>
    public string GerarTagUsuario(string nickname, string codigo)
    {
        return $"{nickname}#{codigo}";
    }

    /// <summary>
    /// Calcula o XP total somando o XP de duas fases e aplicando um bônus fixo de 100 pontos.
    /// Exemplo: (200, 300) retorna 600.
    /// </summary>
    /// <param name="xpFase1">XP obtido na fase 1.</param>
    /// <param name="xpFase2">XP obtido na fase 2.</param>
    /// <returns>Soma dos XPs mais o bônus fixo.</returns>
    public int CalcularXPTotal(int xpFase1, int xpFase2)
    {
        return xpFase1 + xpFase2 + BonusFixoXp;
    }

    /// <summary>
    /// Verifica se o jogador é elegível para partidas ranqueadas.
    /// Retorna true se o nível for maior ou igual a 15; caso contrário, false.
    /// </summary>
    /// <param name="nivelJogador">Nível atual do jogador.</param>
    /// <returns>True se elegível para ranked; false caso contrário.</returns>
    public bool EEligivelParaRanked(int nivelJogador)
    {
        return nivelJogador >= NivelMinimoRanked;
    }
}
