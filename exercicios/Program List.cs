public class Program8
{
    public static void Main8()
    {
        List<int> inteiros = new List<int>{2,8,28,35};
        Console.WriteLine("Lista atual: " + string.Join(", ", inteiros));
        Console.Write("Digite um número: ");
        int numero = Convert.ToInt32(Console.ReadLine());
        if (inteiros.Contains(numero)){
            inteiros.Remove(numero);
        }
        else {
            inteiros.Add(numero);
        }
        Console.WriteLine("Lista atualizada: " + string.Join(", ", inteiros));
    }
    
}