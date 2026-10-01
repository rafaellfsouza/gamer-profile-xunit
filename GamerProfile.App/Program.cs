using GamerProfile.App;

// Aplicação de console que demonstra o uso do PerfilJogadorService.
var service = new PerfilJogadorService();

Console.WriteLine("=== GamerProfile — Cadastro de Jogadores ===");
Console.WriteLine();

// Exemplo 1: geração da tag do usuário (retorno string)
string tag = service.GerarTagUsuario("Aragorn", "1042");
Console.WriteLine($"Tag do usuário......: {tag}");

// Exemplo 2: cálculo do XP total com bônus (retorno int)
int xpTotal = service.CalcularXPTotal(200, 300);
Console.WriteLine($"XP total (200 + 300): {xpTotal}");

// Exemplo 3: verificação de elegibilidade para ranked (retorno bool)
bool elegivelNivel20 = service.EEligivelParaRanked(20);
bool elegivelNivel10 = service.EEligivelParaRanked(10);
Console.WriteLine($"Nível 20 é elegível para ranked? {(elegivelNivel20 ? "Sim" : "Não")}");
Console.WriteLine($"Nível 10 é elegível para ranked? {(elegivelNivel10 ? "Sim" : "Não")}");
