using System.Security.Policy;
using System.Text;

class Program4444
{
    public static void Main4444()
    {
        HashSet<int> numeros_pares = new HashSet<int>{2,46,22,90,78};
        HashSet<int> numeros_impares = new HashSet<int>{13,67,59,81,49};

        HashSet<int> uniao = new HashSet<int>(numeros_pares);
        uniao.UnionWith(numeros_impares);

        HashSet<int> interseccao = new HashSet<int>(numeros_pares);
        interseccao.IntersectWith(numeros_impares);

        HashSet<int> diferenca = new HashSet<int>(numeros_pares);
        diferenca.ExceptWith(numeros_impares);

        Console.WriteLine("Números pares: " + String.Join(", ", numeros_pares));
        Console.WriteLine("Números ímpares: " + String.Join(", ", numeros_impares));
        Console.WriteLine("União: " + String.Join(", ", uniao));
        Console.WriteLine("Intersecção: " + String.Join(", ", interseccao));
        Console.WriteLine("Diferença: " + String.Join(", ", diferenca));
    }
}