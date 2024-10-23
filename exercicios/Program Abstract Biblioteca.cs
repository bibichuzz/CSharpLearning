public class Program4
{
    public static void Main4()
    {
        Revista revista = new Revista();
        Livro livro = new Livro();

        livro.Autor = "Victoria Aveyard";
        livro.Titulo = "A Rainha Vermelha";
        livro.Disponivel = true;

        revista.Edicao = 23;
        revista.Titulo = "Capricho";
        revista.Disponivel = false;

        List<ItemBibllioteca> arquivos = new List<ItemBibllioteca>();
        arquivos.Add(revista);
        arquivos.Add(livro);

        foreach(ItemBibllioteca item in arquivos){
            item.ExibirDetalhes();
        }
    }
    abstract class ItemBibllioteca{
        public string? Titulo {get;set;}
        public bool Disponivel {get;set;}

        public abstract void ExibirDetalhes();
    }
    class Livro : ItemBibllioteca{
        public string? Autor {get;set;}
        public override void ExibirDetalhes()
        {
            if(Disponivel == true){
                Console.WriteLine($"O título {Titulo}, do(a) autor(a) {Autor}, está disponível.");
            } else
            {
                Console.WriteLine($"O título {Titulo}, do autor {Autor}, não está disponível.");
            }
    }
    }
    class Revista : ItemBibllioteca{
        public int Edicao{get;set;}
        public override void ExibirDetalhes()
        {
            if(Disponivel == true){
                Console.WriteLine($"A revista {Titulo}, edição {Edicao}, está disponível.");
            } else
            {
                Console.WriteLine($"A revista {Titulo}, edição {Edicao}, não está disponível.");
            }
    }
}
}