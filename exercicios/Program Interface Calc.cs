public class Program1
{
    public static void Main1()
    {
        CalculadoraSimples calculadora = new CalculadoraSimples();
        calculadora.Somar(1.5,2.6);
        calculadora.Subtrair(2.7,1);
        calculadora.Multiplicar(2,5.2);
        calculadora.Dividir(6,2);
    }
    interface ICalculadora{
        void Somar(double numero1, double numero2);
        void Subtrair(double numero1, double numero2);
        void Multiplicar(double numero1, double numero2);
        void Dividir(double numero1, double numero2);
    }

    class CalculadoraSimples : ICalculadora {
        public void Somar(double numero1, double numero2){
            Console.WriteLine($"Soma: {numero1 + numero2}");
        }
        public void Subtrair(double numero1, double numero2){
            Console.WriteLine($"Subtração: {numero1 - numero2}");
        }
        public void Multiplicar(double numero1, double numero2){
            Console.WriteLine($"Multiplicação: {numero1 * numero2}");
        }
        public void Dividir(double numero1, double numero2){
            Console.WriteLine($"Divisão: {numero1 / numero2}");
        }
    }
}