public class Program2
{
    public static void Main2()
    {
        Triangulo triangulo = new Triangulo();
        Circulo circulo = new Circulo();
        triangulo.Altura = 2;
        triangulo.Base = 3;
        circulo.Raio = 3;

        triangulo.CalcularArea();
        circulo.CalcularArea();
    }
    abstract class FormaGeometrica
    {
        public abstract void CalcularArea();
    }
    class Triangulo : FormaGeometrica{
        public int Base {get; set;}
        public int Altura {get; set;}

        public override void CalcularArea()
        {
            Console.WriteLine($"Área do triângulo: {Base*Altura/2}cm²");
        }
    }
    class Circulo : FormaGeometrica{
        public int Raio {get; set;}
        public const double Pi = 3.14;
        public override void CalcularArea()
        {
            Console.WriteLine($"Área do círculo: {Raio*Raio*Pi}cm²");
        }
    }
}