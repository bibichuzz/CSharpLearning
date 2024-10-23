using System.Threading;
using System.Threading.Tasks;
class Program9999
{
    public static async Task Main9999()
    {
        Console.Write("Você deseja baixar esse arquivo? [S/Y] Sim [N] Não ");
        string resposta = Console.ReadLine();

        if (resposta.ToLower() == "s" || resposta.ToLower() == "y")
        {
            Task download = Task.Run(DownloadAsync);
            
            while (!download.IsCompleted)
            {
                Console.WriteLine("Aguardando download...");
                await Task.Delay(1000);
            }

            await Task.WhenAll(download);
            Console.WriteLine("Download finalizado!");
        }
        else
        {
            Console.WriteLine("Download não iniciado");
        }

    }
    static void DownloadAsync()
    {
        Thread.Sleep(5000);
        Console.WriteLine("Download de arquivo concluído!");
    }
}