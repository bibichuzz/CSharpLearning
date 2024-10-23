class Program9
{
    static void Main9()
    {
        string nomeArquivo = "dados.txt";
        string texto = "Este é um exemplo de escrita em arquivo.";
        try
        {
            using (StreamWriter escritor = new StreamWriter(nomeArquivo))
            {
                escritor.WriteLine(texto);
            }
            Console.WriteLine("Dados gravados no arquivo com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao gravar no arquivo: " + ex.Message);
        }
    }
}