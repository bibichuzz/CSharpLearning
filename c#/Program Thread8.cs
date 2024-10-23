using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;

class Program8888
{
    public static void Main8888()
    {
        Thread thread1 = new Thread(Thread1);
        thread1.Start();
        Thread.Sleep(1000);
        Thread thread2 = new Thread(Thread2);
        thread2.Start();

        while (thread1.IsAlive || thread2.IsAlive)
        {
            Console.WriteLine("Executando threads...");
            Thread.Sleep(1000);
        }
        Console.WriteLine("Execução concluída!");
    }
    static void Thread1()
    {
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine("Essa mensagem é da primeira thread");
            Thread.Sleep(2000); // Simula uma operação de longa duração
        }
        Console.WriteLine("Thread 1 concluída!");
    }
    static void Thread2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Essa mensagem é da segunda thread");
            Thread.Sleep(2000); // Simula uma operação de longa duração
        }
        Console.WriteLine("Thread 2 concluída!");
    }

}