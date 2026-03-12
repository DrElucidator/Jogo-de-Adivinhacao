# Jogo de Adivinhação

Este repositório contém um simples jogo de adivinhação desenvolvido em C# como um aplicativo de console. O objetivo do jogo é que o jogador tente descobrir um número aleatório dentro de um intervalo definido, com um número limitado de tentativas.

## Funcionalidades

- **Seleção de dificuldade:** Fácil, Médio e Difícil, cada uma com diferentes limites de tentativas e intervalos de valores.
- **Contagem de tentativas:** Limite de palpites com feedback a cada tentativa.
- **Dica única por partida:** Permite ao jogador solicitar uma dica (par ou ímpar) com custo de pontos.
- **Pontuação:** Calculada com base na proximidade do palpite ao número sorteado.
- **Reinício do jogo:** Pergunta ao final de cada partida se o jogador deseja continuar.

## Como executar

1. Abra o terminal na pasta do projeto `JogoDeAdivinhacao.ConsoleApp`.
2. Compile o projeto com o comando:
   ```bash
   dotnet build
   ```
3. Execute o jogo:
   ```bash
   dotnet run --project JogoDeAdivinhacao.ConsoleApp
   ```

## Estrutura do projeto

- `JogoDeAdivinhacao.ConsoleApp/`: código fonte do jogo.
- `Program.cs`: lógica principal do jogo.
- `JogoDeAdivinhacao.slnx`: solução do Visual Studio/VS Code.

## Requisitos

- [.NET SDK 6.0 ou superior](https://dotnet.microsoft.com/download).

## Como contribuir

1. Faça um fork do repositório.
2. Crie uma branch com sua feature ou correção (`git checkout -b minha-feature`).
3. Commit suas alterações (`git commit -m 'Adiciona nova funcionalidade'`).
4. Push para a branch (`git push origin minha-feature`).
5. Abra um Pull Request.
---

Obrigado por jogar! 😊