
using System.Threading;
using System.Threading.Tasks;
class Program213
{
    public static async Task Main213()
    {
        // Gerando a lista de 10 números aleatórios
        List<int> numeros_aleatorios = new List<int>();
        Random num_aleatorio = new Random();
        for (int i = 0; i < 10; i++)
        {
            numeros_aleatorios.Add(num_aleatorio.Next(1, 100));
        }

        // Criando as tasks para a divisão entre número par e ímpar
        Task<List<int>> numeros_pares = Task.Run(() => NumerosPares(numeros_aleatorios));
        Task<List<int>> numeros_impares = Task.Run(()=> NumerosImpares(numeros_aleatorios));
        // Indicando o tipo de retorno da task para poder utilizar a lista criada para a próxima etapa
        // Task.Run() permite enviar parâmetros à task

        await Task.WhenAll(numeros_pares, numeros_impares);
        // Juntando os resultados e ordenando-os
        List<int> lista_completa = numeros_pares.Result.Concat(numeros_impares.Result).OrderBy(n => n).ToList();
        string lista_completa_join = String.Join(", ", lista_completa.ToArray());
        Console.WriteLine($"Lista completa: {lista_completa_join}");
    }
    static List<int> NumerosPares(List<int> num_list)
    {
        var par = from num in num_list
                  where num % 2 == 0
                  orderby num ascending
                  select num;
        string par_join = String.Join(", ", par.ToArray());
        Thread.Sleep(1500);
        Console.WriteLine($"Números pares: {par_join}");
        return par.ToList();
    }

    static List<int> NumerosImpares(List<int> num_list)
    {
        var impar = from num in num_list
                    where num % 2 != 0
                    orderby num ascending
                    select num;
        string impar_join = String.Join(", ", impar.ToArray());
        Thread.Sleep(3000);
        Console.WriteLine($"Números ímpares: {impar_join}");
        return impar.ToList();
    }

}