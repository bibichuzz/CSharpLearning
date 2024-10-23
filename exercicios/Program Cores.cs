public class Program7
{
    public static void Main7()
    {
        HashSet<string> coresPrimarias = new HashSet<string> {"vermelho", "amarelo", "azul"};
        HashSet<string> coresSecundarias = new HashSet<string> {"laranja", "verde", "roxo"};

        HashSet<string> uniao = new HashSet<string>(coresPrimarias);
        uniao.UnionWith(coresSecundarias);
        Console.WriteLine("Todas as cores: "+string.Join(", ", uniao));

        coresSecundarias.Remove("verde");
        Console.WriteLine("Cores secundárias sem o verde: "+string.Join(", ", coresSecundarias));
    }
}