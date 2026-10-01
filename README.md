# GamerProfile — Cadastro de Jogadores com Testes Unitários (xUnit)

> **Disciplina:** Garantia da Qualidade de Software — Gestão e Qualidade de Software
> **Professor:** Daniel Henrique Matos de Paiva
> **Aluno:** Rafael Luiz Ferreira de Souza — **RA:** 32511503

## 🎯 Propósito do Sistema

O **GamerProfile** é uma solução .NET 10 via linha de comando para gerenciar um serviço de cadastro de jogadores. O projeto foi desenvolvido como atividade de Garantia da Qualidade de Software para demonstrar a aplicação de **Test-Driven Quality**: o código de produção (`GamerProfile.App`) é coberto por **testes unitários automatizados** (`GamerProfile.Tests`) escritos com o framework **xUnit**.

O serviço `PerfilJogadorService` implementa três métodos, um para cada tipo de retorno exigido:

| Método | Retorno | Regra de Negócio |
|---|---|---|
| `GerarTagUsuario(string nickname, string codigo)` | `string` | Concatena nickname e código com `#` (ex.: `"Aragorn"` + `"1042"` → `"Aragorn#1042"`) |
| `CalcularXPTotal(int xpFase1, int xpFase2)` | `int` | Soma o XP das duas fases e aplica bônus fixo de **100** pontos (ex.: `200` + `300` → `600`) |
| `EEligivelParaRanked(int nivelJogador)` | `bool` | Retorna `true` se o nível for **≥ 15**; caso contrário, `false` |

## 🧪 Os três tipos de testes unitários realizados

Os testes estão na classe `PerfilJogadorServiceTests` e utilizam o atributo `[Fact]`:

1. **Teste de `string`** — valida se `GerarTagUsuario` gera a formatação correta, utilizando `Assert.Equal("Aragorn#1042", resultado)`.
2. **Teste de `int`** — valida se `CalcularXPTotal` realiza a soma das fases e aplica o bônus de 100 corretamente, utilizando `Assert.Equal(valorEsperado, resultado)`.
3. **Teste de `bool`** — valida a regra de elegibilidade para partidas ranqueadas, utilizando `Assert.True(...)` para níveis a partir de 15 e `Assert.False(...)` para níveis abaixo de 15.

## 📁 Estrutura da Solução

```
gamer-profile-xunit/
├── GamerProfile.sln                  # Solução (agrupa os dois projetos)
├── GamerProfile.App/                 # Código de produção (console app)
│   ├── GamerProfile.App.csproj
│   ├── PerfilJogadorService.cs       # Serviço com os 3 métodos (string, int, bool)
│   └── Program.cs                    # Demonstração de uso via linha de comando
├── GamerProfile.Tests/               # Testes unitários (xUnit)
│   ├── GamerProfile.Tests.csproj
│   └── PerfilJogadorServiceTests.cs  # 4 testes [Fact] cobrindo os 3 métodos
├── README.md
├── LICENSE                           # Licença MIT
└── .gitignore
```

## 🚀 Como executar

### Pré-requisitos

- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) ou superior instalado.

### Executar os testes unitários

Na raiz do repositório, execute:

```bash
dotnet test
```

Resultado esperado: **4 testes aprovados** (`Passed! - Failed: 0, Passed: 4`).

### Executar a aplicação de console (demonstração)

```bash
dotnet run --project GamerProfile.App
```

Saída esperada:

```
=== GamerProfile — Cadastro de Jogadores ===

Tag do usuário......: Aragorn#1042
XP total (200 + 300): 600
Nível 20 é elegível para ranked? Sim
Nível 10 é elegível para ranked? Não
```

## 🔧 Comandos utilizados para criar a solução (.NET CLI)

```bash
# 1. Cria a Solução
dotnet new sln -n GamerProfile

# 2. Cria o projeto da aplicação (Código de Produção)
dotnet new console -n GamerProfile.App -f net10.0

# 3. Cria o projeto de Testes Unitários com xUnit
dotnet new xunit -n GamerProfile.Tests -f net10.0

# 4. Adiciona ambos os projetos à Solução
dotnet sln add GamerProfile.App/GamerProfile.App.csproj
dotnet sln add GamerProfile.Tests/GamerProfile.Tests.csproj

# 5. Adiciona a referência do projeto de Produção no projeto de Testes
dotnet add GamerProfile.Tests/GamerProfile.Tests.csproj reference GamerProfile.App/GamerProfile.App.csproj
```

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
