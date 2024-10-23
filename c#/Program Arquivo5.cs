using System.Security.Policy;
using System.Text;

class Program5555
{
    public static void Main5555()
    {
        // Registrar o provedor de codificação para garantir suporte a ISO-8859-1
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Configurar o console para usar ISO-8859-1 para entrada e saída
        Console.OutputEncoding = Encoding.GetEncoding("iso-8859-1");
        Console.InputEncoding = Encoding.GetEncoding("iso-8859-1");


        Console.Write("Digite um nome: ");
        string nome_input = FirstLetterToUpper(Console.ReadLine());
        while (nome_input.Length < 3 || nome_input.Any(char.IsDigit))
        {
            Console.Write("Insira um nome válido: ");
            nome_input = FirstLetterToUpper(Console.ReadLine());
        }

        try
        {
            string arquivo = @"arquivos\nomes.txt";
            string[] nomes = File.ReadAllLines(arquivo);
            if(nomes.Contains(nome_input)){
                Console.WriteLine($"O nome {nome_input} está na lista.");
            } else {
                Console.WriteLine($"O nome {nome_input} NÃO está na lista. Deseja adicioná-lo? [S/Y]   [N]");
                string add_nome = Console.ReadLine().ToLower();
                if(add_nome == "s" || add_nome == "y"){
                    File.AppendAllText(arquivo,$"\n{nome_input}");
                    Console.WriteLine("Nome adicionado com sucesso!");
                } else {
                    Console.WriteLine("OK! Finalizando programa...");
                }
            }
        }
        catch
        {
            Console.WriteLine("Erro ao ler arquivo, tente novamente.");
        }
    }
    static string FirstLetterToUpper(string nome)
    {
        List<string> nome_resultado = new List<string>();

        foreach (string palavra in nome.Split(" "))
        {
            string palavra_nome = char.ToUpper(palavra[0]) + palavra.Substring(1).ToLower();
            nome_resultado.Add(palavra_nome);
        }
        return String.Join(" ", nome_resultado.ToArray());
    }

}