using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;

class Program7777
{
    public static void Main7777()
    {
        // Gerando a array de 10 números aleatórios
        List<int> numeros_aleatorios = new List<int>();
        Random num_aleatorio = new Random();
        for (int i = 0; i < 10; i++)
        {
            numeros_aleatorios.Add(num_aleatorio.Next(1, 101));
        }
        Console.WriteLine("Números: "+ String.Join(", ",numeros_aleatorios.ToArray()));
        
        var numeros_pares = from n in numeros_aleatorios
        where n % 2 == 0
        select n;
        int soma = numeros_pares.Sum();
        Console.WriteLine("A soma dos números pares é "+ soma);
    }

}