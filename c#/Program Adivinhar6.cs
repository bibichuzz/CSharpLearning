using System.Security.Policy;
using System.Text;

class Program6666
{
    public static void Main6666()
    {
        // Gerando um número aleatório
        Random random = new Random();
        int numero_aleatorio = random.Next(1, 101);
        // Console.WriteLine("Número aleatório: " + numero_aleatorio);

        try
        {
            Console.Write("Digite um número de 1 a 100: ");
            int numero_input = Convert.ToInt32(Console.ReadLine());

            while (numero_input != numero_aleatorio)
            {
                if (numero_input < 1 || numero_input > 100)
                {
                    Console.Write($"O número está entre 1 e 100. Tente novamente: ");
                    numero_input = Convert.ToInt32(Console.ReadLine());
                }
                else if (numero_input < numero_aleatorio)
                {
                    Console.Write($"O número é maior do que {numero_input}. Tente novamente: ");
                    numero_input = Convert.ToInt32(Console.ReadLine());
                }
                else if (numero_input > numero_aleatorio)
                {
                    Console.Write($"O número é menor do que {numero_input}. Tente novamente: ");
                    numero_input = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine($"Parabéns! O número era {numero_aleatorio}.");
        }
        catch
        {
            Console.WriteLine("Digite um número válido.");
        }

    }

}