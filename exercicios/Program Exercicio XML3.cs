using System.Text;
using System.Xml.Serialization;

public class Aluno
{
    public string Nome { get; set; }
    public double Nota { get; set; }
}

public class Program333
{
    public static void Main333()
    {
        // Registrar o provedor de codificação para garantir suporte a ISO-8859-1
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Configurar o console para usar ISO-8859-1 para entrada e saída
        Console.OutputEncoding = Encoding.GetEncoding("iso-8859-1");
        Console.InputEncoding = Encoding.GetEncoding("iso-8859-1");

        try
        {
            Console.Write("Digite o nome do aluno: ");
            string aluno_nome = Console.ReadLine();
            while (aluno_nome.Length < 1)
            {
                Console.Write("Nome inválido. Digite o nome do aluno novamente: ");
                aluno_nome = Console.ReadLine();
            }

            Console.Write("Digite a nota do aluno: ");
            double aluno_nota = Convert.ToDouble(Console.ReadLine());
            while (aluno_nota < 0 || aluno_nota > 10)
            {
                Console.Write("Nota inválida. Digite a nota do aluno novamente: ");
                aluno_nota = Convert.ToDouble(Console.ReadLine());
            }

            Aluno aluno = new Aluno
            {
                Nome = aluno_nome,
                Nota = aluno_nota
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Aluno));
            string caminho = @"arquivos\objetoxml.xml";

            using(StreamWriter writer = new StreamWriter(caminho)){
                serializer.Serialize(writer, aluno);
            }
            
            Console.WriteLine("Dados registrados com sucesso!");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao registrar aluno, tente novamente.");
        }

    }

}