using System.Security.Cryptography;

Console.Clear();

Console.WriteLine("--------------------------------------------");
Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
Console.WriteLine("--------------------------------------------");

Console.WriteLine();
Console.WriteLine("Digite ENTER para iniciar...");
Console.ReadLine();

while (true)
{
    Console.Clear();
    int[] numDigitados = new int[100];
    int contadorDePalpites = 0;
    int pontuacao = 1000;
    Console.WriteLine("Escolha o nível de dificuldade: ");
    Console.WriteLine();
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - Médio (5 tentativas)");
    Console.WriteLine("3 - Difícil (3 tentativas)");
    Console.WriteLine();
    Console.WriteLine("Digite a sua escolha: ");
    string? dificuldade = Console.ReadLine();

    int maxNum;
    int maxTry;
    switch (dificuldade)
    {
        case "1":
            maxNum = 20;
            maxTry = 10;
            break;
        case "2":
            maxNum = 50;
            maxTry = 5;
            break;
        case "3":
            maxNum = 100;
            maxTry = 3;
            break;
        default:
            Console.WriteLine("Opção inválida, escolha uma opção válida.");
            continue;
    }

    int sortNum = RandomNumberGenerator.GetInt32(1, maxNum + 1);

    for (int tentativa = 1; tentativa <= maxTry; tentativa++)
    {
        Console.Clear();
        Console.WriteLine($"Tentativa {tentativa} de {maxTry}");
        Console.WriteLine();
        Console.WriteLine($"Digite o número entre 1 e {maxNum}: ");
        string? palpite = Console.ReadLine();

        if (!int.TryParse(palpite, out int NumPalpite))
        {
            Console.WriteLine("Entrada inválida. Digite um número.");
            tentativa--;
            Console.ReadLine();
            continue;
        }

        bool oldNum = false;
        for (int i = 0; i < contadorDePalpites; i++)
        {
            if (numDigitados[i] == NumPalpite)
            {
                oldNum = true;
                break;
            }
        }

        if (oldNum)
        {
            Console.WriteLine("Você já digitou esse número, tente outro.");
            tentativa--;
            Console.ReadLine();
            continue;
        }

        numDigitados[contadorDePalpites++] = NumPalpite;

        Console.WriteLine("O número digitado foi: " + NumPalpite);

        if (NumPalpite == sortNum)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Parabéns! Você acertou!");
            Console.WriteLine();
            Console.WriteLine("O número sorteado foi: " + sortNum);
            break;
        }
        else if (NumPalpite < sortNum)
        {
            Console.WriteLine();
            Console.WriteLine("Tente um número maior!");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Tente um número menor!");
        }

        int DiffNum = Math.Abs(sortNum - NumPalpite);

        if (DiffNum >= 10)
            pontuacao -= 100;
        else if (DiffNum >= 5)
            pontuacao -= 50;
        else
            pontuacao -= 20;

        Console.WriteLine();
        Console.WriteLine("Sua pontuação é: " + pontuacao);
        Console.ReadLine();

        if (tentativa == maxTry)
        {
            Console.WriteLine("Que pena, você perdeu!");
            Console.WriteLine("O número sorteado foi: " + sortNum);
        }
    }

    Console.WriteLine();
    Console.WriteLine("Deseja jogar novamente? [s/n]: ");
    string? opcaoContinuar = Console.ReadLine();
    if (opcaoContinuar?.ToUpper() != "S")
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Obrigado por jogar! Até a próxima!");
        break;
    }
}