using System;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Console.WriteLine("--------- Início Exercício 1 ---------");
        Exercicio1();
        Console.WriteLine("--------- Fim Exercício 1 ---------\n");

        Console.WriteLine("--------- Início Exercício 2 ---------");
        Exercicio2();
        Console.WriteLine("--------- Fim Exercício 2 ---------\n");

        Console.WriteLine("--------- Início Exercício 3 ---------");
        Exercicio3();
        Console.WriteLine("--------- Fim Exercício 3 ---------\n");

        Console.WriteLine("--------- Início Exercício 4 ---------");
        Exercicio4();
        Console.WriteLine("--------- Fim Exercício 4 ---------\n");

        Console.WriteLine("--------- Início Exercício 5 ---------");
        Exercicio5();
        Console.WriteLine("--------- Fim Exercício 5 ---------\n");
    }

    #region Exercício 1
    static void Exercicio1()
    {
        int INDICE = 13, SOMA = 0, K = 0;

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine($"O valor de SOMA é: {SOMA}");
    }
    #endregion

    #region Exercício 2
    static void Exercicio2()
    {
        Console.Write("Digite um número: ");
        int numero = int.Parse(Console.ReadLine());
        if (PertenceFibonacci(numero))
        {
            Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"{numero} não pertence à sequência de Fibonacci.");
        }
    }
    static bool PertenceFibonacci(int numero)
    {
        int a = 0, b = 1, c = 0;
        while (c < numero)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c == numero || numero == 0;
    }
    #endregion

    #region Exercício 3
    static void Exercicio3()
    {
        string json = @"
        [
            { ""dia"": 1, ""valor"": 22174.1664 },
            { ""dia"": 2, ""valor"": 24537.6698 },
            { ""dia"": 3, ""valor"": 26139.6134 },
            { ""dia"": 4, ""valor"": 0.0 },
            { ""dia"": 5, ""valor"": 0.0 },
            { ""dia"": 6, ""valor"": 26742.6612 },
            { ""dia"": 7, ""valor"": 0.0 },
            { ""dia"": 8, ""valor"": 42889.2258 },
            { ""dia"": 9, ""valor"": 46251.174 },
            { ""dia"": 10, ""valor"": 11191.4722 },
            { ""dia"": 11, ""valor"": 0.0 },
            { ""dia"": 12, ""valor"": 0.0 },
            { ""dia"": 13, ""valor"": 3847.4823 },
            { ""dia"": 14, ""valor"": 373.7838 },
            { ""dia"": 15, ""valor"": 2659.7563 },
            { ""dia"": 16, ""valor"": 48924.2448 },
            { ""dia"": 17, ""valor"": 18419.2614 },
            { ""dia"": 18, ""valor"": 0.0 },
            { ""dia"": 19, ""valor"": 0.0 },
            { ""dia"": 20, ""valor"": 35240.1826 },
            { ""dia"": 21, ""valor"": 43829.1667 },
            { ""dia"": 22, ""valor"": 18235.6852 },
            { ""dia"": 23, ""valor"": 4355.0662 },
            { ""dia"": 24, ""valor"": 13327.1025 },
            { ""dia"": 25, ""valor"": 0.0 },
            { ""dia"": 26, ""valor"": 0.0 },
            { ""dia"": 27, ""valor"": 25681.8318 },
            { ""dia"": 28, ""valor"": 1718.1221 },
            { ""dia"": 29, ""valor"": 13220.495 },
            { ""dia"": 30, ""valor"": 8414.61 }
        ]";

        var faturamento = JsonSerializer.Deserialize<List<Faturamento>>(json);
        
        var valores = faturamento.Where(x => x.valor > 0).Select(x => x.valor).ToList();

        decimal menor = valores.Min();
        decimal maior = valores.Max();
        decimal media = valores.Average();
        int diasAcimaMedia = faturamento.Count(x => x.valor > media);

        
        Console.WriteLine($"Menor faturamento: {menor}");
        Console.WriteLine($"Maior faturamento: {maior}");
        Console.WriteLine($"Dias acima da média: {diasAcimaMedia}");
    }
    public class Faturamento
    {
        public int dia { get; set; }
        public decimal valor { get; set; }
    }
    #endregion

    #region Exercício 4
    static void Exercicio4()
    {
        decimal sp = 67836.43m, rj = 36678.66m, mg = 29229.88m, es = 27165.48m, outros = 19849.53m;
        decimal total = sp + rj + mg + es + outros;

        Console.WriteLine($"SP: {sp / total * 100:F2}%");
        Console.WriteLine($"RJ: {rj / total * 100:F2}%");
        Console.WriteLine($"MG: {mg / total * 100:F2}%");
        Console.WriteLine($"ES: {es / total * 100:F2}%");
        Console.WriteLine($"Outros: {outros / total * 100:F2}%");
    }
    #endregion

    #region Exercício 5
    static void Exercicio5()
    {
        Console.Write("Digite uma string: ");
        string input = Console.ReadLine();
        string invertida = InverterString(input);

        Console.WriteLine($"String invertida: {invertida}");
    }
    static string InverterString(string input)
    {
        char[] chars = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            chars[i] = input[input.Length - 1 - i];
        }
        return new string(chars);
    }
    #endregion
}