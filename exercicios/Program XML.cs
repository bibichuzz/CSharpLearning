using System;
using System.IO;
using System.Xml.Serialization;
public class Pessoa1
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cidade { get; set; }
}
class Program11
{
    static void Main11()
    {
        Pessoa1 pessoa = new Pessoa1
        {
            Nome = "João Silva",
            Idade = 30,
            Cidade = "São Paulo"
        };
        XmlSerializer serializer = new XmlSerializer(typeof(Pessoa1));
        //Criando objeto em formato XML em branco, para ser preenchido
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, pessoa);
            //Gravando objeto/propriedades no objeto em branco
            string xmlString = writer.ToString();
            //Converte o objeto pronto em string
            Console.WriteLine(xmlString);
        }
    }
}
