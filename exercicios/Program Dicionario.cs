public class Program6
{
    public static void Main6()
    {
        Dictionary<string,double> notaNomeAluno = new Dictionary<string, double>();

        notaNomeAluno.Add("Luisa", 6.7);
        notaNomeAluno.Add("Mario",8);
        notaNomeAluno.Add("Maria",4.5);

        Console.Write("Digite o nome do aluno: ");
        string? nomeAluno = Console.ReadLine();

        if(notaNomeAluno.ContainsKey(nomeAluno)){
            Console.WriteLine($"A nota de {nomeAluno} é {notaNomeAluno[nomeAluno]}");
        }
        else{
            Console.Write($"Digite a nota do aluno {nomeAluno}: ");
            double notaAluno = Convert.ToDouble(Console.ReadLine());
            notaNomeAluno.Add(nomeAluno,notaAluno);
            Console.WriteLine($"A nota de {nomeAluno} é {notaNomeAluno[nomeAluno]}");
        }
    }
    
}