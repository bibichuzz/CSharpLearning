class Program11111
{
    public static void Main11111()
    {
        // Gerando a array de 10 números aleatórios
        int[] numeros_aleatorios = new int[10];
        Random num_aleatorio = new Random();
        for (int i = 0; i < 10; i++)
        {
            numeros_aleatorios[i] = num_aleatorio.Next(1, 101);
        }

        // Colocando em ordem numérica e obtendo o número maior e menor
        Array.Sort(numeros_aleatorios);
        int maior = numeros_aleatorios[numeros_aleatorios.Length - 1];
        int menor = numeros_aleatorios[0];

        Console.WriteLine("Números escolhidos: " + String.Join(", ", numeros_aleatorios));
        Console.WriteLine("Maior: " + maior);
        Console.WriteLine("Menor: " + menor);
    }
}