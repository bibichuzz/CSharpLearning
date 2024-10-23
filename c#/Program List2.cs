using System;
using System.Collections.Generic;
using System.Text;
class Program2222
{
    public static void Main2222()
    {
        // Registrar o provedor de codificação para garantir suporte a ISO-8859-1
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        // Configurar o console para usar ISO-8859-1 para entrada e saída
        Console.OutputEncoding = Encoding.GetEncoding("iso-8859-1");
        Console.InputEncoding = Encoding.GetEncoding("iso-8859-1");

        List<string> frutas = new List<string>();
        frutas.Add("maçã");
        frutas.Add("banana");
        frutas.Add("melancia");

        Console.WriteLine("Lista atual: " + String.Join(", ", frutas));
        Console.Write("Digite o nome de uma fruta: ");
        string fruta_input = Console.ReadLine().ToLower();

        while(fruta_input.Length < 1 || fruta_input.Any(char.IsDigit)){
            Console.Write("Insira um nome de fruta válido: ");
            fruta_input = Console.ReadLine();
        }

        if(frutas.Contains(fruta_input)){
            frutas.Remove(fruta_input);
        }
        else{
            frutas.Add(fruta_input);
        }
        Console.WriteLine("Nova lista de frutas: " + String.Join(", ", frutas));
    }
}