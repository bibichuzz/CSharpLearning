public class Program3
{
    public static void Main3()
    {
        PagamentoCartaoCredito cartao = new PagamentoCartaoCredito();
        PagamentoBoleto boleto = new PagamentoBoleto();

        List<IPagamento> listaPagamentos = new List<IPagamento>();
        listaPagamentos.Add(cartao);
        listaPagamentos.Add(boleto);

        foreach (IPagamento pagamento in listaPagamentos){
            pagamento.ProcessarPagamento(500.12);
        }

    }
    interface IPagamento{
        void ProcessarPagamento(double valor);
    }
    class PagamentoCartaoCredito : IPagamento {
        public void ProcessarPagamento(double valor){
            string _valor = valor.ToString("F");
            Console.WriteLine($"Você pagou sua fatura de R${_valor} do cartão de crédito");
        }
    }
    class PagamentoBoleto : IPagamento {
        public void ProcessarPagamento(double valor){
            string _valor = valor.ToString("F");
            Console.WriteLine($"Você pagou um boleto de R${_valor}.");
        }
    }
}