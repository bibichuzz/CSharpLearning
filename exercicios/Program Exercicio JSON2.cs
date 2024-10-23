using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

public class Animal
{
    public string Especie { get; set; }
    public int Idade { get; set; }
    public string Nome { get; set; }
}

public class Program213123
{
    public static void Main123213()
    {
        Animal animal = new Animal
        {
            Especie = "Pássaro",
            Idade = 7,
            Nome = "Piu Piu"
        };

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(animal, options);

        try
        {
            File.WriteAllText(@"arquivos\objetojson.json", jsonString);
            Console.WriteLine("Objeto enviado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro na gravação de arquivo: " + ex);
        }

    }

}