using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Program.Beginning(" Bem-vindo ao Jogo de Adivinhação!");
        while (true)
        {
            Console.Clear();

            string? dificuldade = MenuDificuldade();
            int[] config = ConfigPartida(dificuldade);

            int maxNum = config[0];
            int maxTry = config[1];

            if (maxNum == 0 || maxTry == 0) continue;

            int sortNum = RandomNumberGenerator.GetInt32(1, maxNum + 1);

            RunPartida(maxNum, maxTry, sortNum);

            if (!ContinuarJogo())
                break;
        }
    }
    static void Beginning(string boasvindas)
    {
        Console.Clear();
        Console.WriteLine("Digite como prefere ser chamado: ");
        string? ID = Console.ReadLine();
        if (ID == null || ID == "")
        {
            Console.WriteLine(boasvindas);
        }
        else
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(ID + "," + boasvindas);
            Console.WriteLine("--------------------------------------------");
        }
        Console.WriteLine();
        Console.WriteLine("Digite ENTER para iniciar...");
        Console.ReadLine();
    }
    static string? MenuDificuldade()
    {
        Console.WriteLine("Escolha o nível de dificuldade: ");
        Console.WriteLine();
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine();
        Console.WriteLine("Digite a sua escolha: ");
        string? dificuldade = Console.ReadLine();
        return dificuldade;
    }
    static int[] ConfigPartida(string? dificuldade)
    {
        int[] config = new int[2];
        switch (dificuldade)
        {
            case "1":
                config[0] = 20;
                config[1] = 10;
                break;
            case "2":
                config[0] = 50;
                config[1] = 5;
                break;
            case "3":
                config[0] = 100;
                config[1] = 3;
                break;
            default:
                Console.WriteLine("Opção inválida, escolha uma opção válida.");
                break;
        }
        return config;
    }
    static void RunPartida(int maxNum, int maxTry, int sortNum)
    {
        int[] numDigitados = new int[100]; int contadorDePalpites = 0; int pontuacao = 1000;
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
            for (int x = 0; x < contadorDePalpites; x++)
            {
                if (numDigitados[x] == NumPalpite)
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
    }

    static bool ContinuarJogo()
    {
        Console.WriteLine();
        Console.WriteLine("Deseja jogar novamente? [s/n]: ");
        string? opcaoContinuar = Console.ReadLine();
        if (opcaoContinuar?.ToUpper() != "S")
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Obrigado por jogar! Até a próxima!");
            return false;
        }
        return true;
    }
}