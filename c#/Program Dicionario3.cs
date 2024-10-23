using System.Text;

class Program3333
{
    public static void Main3333()
    {
        // Registrar o provedor de codificação para garantir suporte a ISO-8859-1
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Configurar o console para usar ISO-8859-1 para entrada e saída
        Console.OutputEncoding = Encoding.GetEncoding("iso-8859-1");
        Console.InputEncoding = Encoding.GetEncoding("iso-8859-1");

        Dictionary<string, string> estados = new Dictionary<string, string>{
            {"São Paulo","São Paulo"},
            {"Rio de Janeiro", "Rio de Janeiro"},
            {"Acre", "Rio Branco"},
            {"Alagoas", "Maceió"},
            {"Amapá", "Macapá"},
            {"Amazonas", "Manaus"},
            {"Bahia", "Salvador"},
            {"Ceará", "Fortaleza"},
            {"Espírito Santo", "Vitória"},
            {"Goiás", "Goiânia"},
            {"Maranhão", "São Luís"},
            {"Mato Grosso", "Cuiabá"},
            {"Mato Grosso do Sul", "Campo Grande"},
            {"Minhas Gerais", "Belo Horizonte"},
            {"Pará", "Belém"},
            {"Paraíba", "João Pessoa"},
            {"Paraná", "Curitiba"},
            {"Pernambuco", "Recife"},
            {"Piauí", "Teresina"},
            {"Rio Grande do Norte", "Natal"},
            {"Rio Grande do Sul", "Porto Alegre"},
            {"Rondônio", "Porto Velho"},
            {"Roraima", "Boa Vista"},
            {"Santa Catarina", "Florianópolis"},
            {"Sergipe", "Aracaju"},
            {"Tocantins", "Palmas"}
        };

        Console.Write("Digite o nome do estado: ");
        string estado_input = FirstLetterToUpper(Console.ReadLine());

        while(estado_input.Length < 4 || estado_input.Any(char.IsDigit)){
            Console.Write("Insira um nome de estado válido: ");
            estado_input = FirstLetterToUpper(Console.ReadLine());
        }

        if(estados.ContainsKey(estado_input)){
            Console.WriteLine($"A capital do estado de {estado_input} é {estados[estado_input]}.");
        }
        else{
            Console.WriteLine("Esse estado não foi encontrado.");
        }

    }

    // Colocar o estado em letra maiúscula
    static string FirstLetterToUpper(string estado){
        if (estado.Split(" ").Length == 1){
            return char.ToUpper(estado[0]) + estado.Substring(1).ToLower();
        }
        else {
            List<string> estado_resultado = new List<string>();
            
            foreach(string palavra in estado.Split(" ")){
                if(palavra.Length < 3){
                    string palavraLower = palavra.ToLower();
                    estado_resultado.Add(palavraLower);
                } else{
                    string palavraUpper = char.ToUpper(palavra[0]) + palavra.Substring(1).ToLower();
                    estado_resultado.Add(palavraUpper);
                }
            }
            return String.Join(" ", estado_resultado.ToArray());
        }
    }
}