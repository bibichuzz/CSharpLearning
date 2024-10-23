using System.Threading;
using System.Threading.Tasks;
class Program12312
{
    public static async Task Main123123()
    {
        Console.Write("Você deseja baixar esse arquivo? [S/Y] Sim [N] Não ");
        string resposta = Console.ReadLine();

        if(resposta.ToLower() == "s" || resposta.ToLower() == "y"){
            Thread download = new Thread(DownloadAsync);
            download.Start();

            while (download.IsAlive){
                Console.WriteLine("Aguardando download...");
                await Task.Delay(500);
            }
            
            Console.WriteLine("Todas as tarefas concluidas!");
        }
        else{
            Console.WriteLine("Download não iniciado");
        }
        
    }
    static void DownloadAsync()
    {
        Thread.Sleep(5000);
        Console.WriteLine("Download de arquivo concluído!");
    }
}