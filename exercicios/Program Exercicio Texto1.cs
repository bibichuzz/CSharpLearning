public class Program12
{
    public static void Main12()
    {
        string arquivo = "arquivo.txt";
        string texto = "Olá, esse texto está escrito aqui de uma maneira muito legal! Ebaaaa";

        try{
            using (StreamWriter writer = new StreamWriter(arquivo)){
                writer.WriteLine(texto);
            }
        }
        catch(Exception ex){
            Console.WriteLine("Houve um erro na gravação de dados.");
        }

        try{
                texto = File.ReadAllText(arquivo);
                string[] palavras = texto.Split(" ");
                int numero_palavras = palavras.Count();
                foreach (string palavra in palavras){
                    Console.WriteLine(palavra);
                }
                Console.WriteLine($"O texto possui {numero_palavras} palavra(s).");
        }
        catch (Exception ex){
            Console.WriteLine("Houve um erro na leitura de dados.");
        }    
    }

}