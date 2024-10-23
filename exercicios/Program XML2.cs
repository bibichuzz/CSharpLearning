using System;
using System.IO;
using System.Xml.Serialization;
public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Cidade { get; set; }
}
class Program111
{
    static void Main111()
    {
        string xmlString = @"<?xml version=""1.0"" encoding=""utf16""?><Pessoa><Nome>Maria Souza</Nome><Idade>25</Idade><Cidade>Rio de Janeiro</Cidade></Pessoa>";
        XmlSerializer serializer = new XmlSerializer(typeof(Pessoa));
        using (StringReader reader = new StringReader(xmlString))
        {
            Pessoa pessoa = (Pessoa)serializer.Deserialize(reader);
            Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}, Cidade: {pessoa.Cidade}");
 }
    }
}