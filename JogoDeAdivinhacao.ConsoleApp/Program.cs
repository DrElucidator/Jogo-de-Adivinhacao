using System.Security.Cryptography;
bool jogarNovamente = true;

Console.WriteLine("---------------------------------");
Console.WriteLine("Bem-vindo ao Jogo de Adivinhação!");
Console.WriteLine("---------------------------------");

while (jogarNovamente == true)
{
    int sortNum = RandomNumberGenerator.GetInt32(1, 21);
    Console.WriteLine("Adivinhe o número entre 1 e 20: ");
    string? palpite = Console.ReadLine();

    int NumPalpite = Convert.ToInt32(palpite);

    Console.WriteLine("O número digitado foi: " + palpite);
    Console.WriteLine("O número sorteado foi: " + sortNum);

    if (NumPalpite == sortNum)
    {
        Console.WriteLine("Parabéns! Você acertou!");
        Console.WriteLine();
    }
    else if (NumPalpite < sortNum)
    {
        Console.WriteLine("Tente um número maior!");
    }
    else if (NumPalpite > sortNum)
    {
        Console.WriteLine("Tente mais baixo!");
    }
    Console.ReadLine();
}