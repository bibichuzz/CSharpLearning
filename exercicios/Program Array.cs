public class Program5
{
    public static void Main5()
    {
        string[] diasDaSemana = { "domingo", "segunda", "terça", "quarta", "quinta", "sexta", "sábado",};

        Console.Write("Digite um número de 1 a 7: ");

        try{
            int diaNumero = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"É {diasDaSemana[diaNumero-1]}.");
        }
        catch(FormatException){
            Console.WriteLine("Input inválido!");
        }
        catch(IndexOutOfRangeException){
            Console.WriteLine("Digite um número dentro do intervalo descrito.");
        }
    }
    
}