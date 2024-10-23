using System.Data.SQLite;
class Program
{
    public static void Main()
    {
        BancoDados banco_clientes = new BancoDados("Loja");
        //banco_clientes.CriarTabela("Clientes", "Nome", "TEXT", "Idade", "NUMERICAL");

        banco_clientes.InserirDados("Clientes", "Nome", "Diego", "Idade", "21");
        //banco_clientes.InserirDados("Clientes", "Nome", "Pâmela", "Idade", "19");
        //banco_clientes.InserirDados("Clientes", "Nome", "Lorena", "Idade", "36");

        banco_clientes.ExibirDados("Clientes");
    }


    public class BancoDados
    {
        public string Banco { get; set; }
        public string Conexao_string { get; set; }
        public BancoDados(string banco)
        {
            Banco = banco;
            Conexao_string = @$"DataSource=arquivos\{Banco.ToLower()}.sqlite; Version=3;";
        }

        public void CriarTabela(string nome_tabela, params string[] colunas_tabela)
        {
            try
            {
                // Montando a string para criação da tabela
                List<string> query_criar_colunas = new List<string>();

                for (int i = 0; i < colunas_tabela.Length; i += 2)
                {
                    string tipo_coluna = colunas_tabela[i + 1];
                    if (tipo_coluna == "TEXT" || tipo_coluna == "NUMERICAL" || tipo_coluna == "REAL" || tipo_coluna == "BLOB" || tipo_coluna == "INTEGER")
                    {
                        string nome_coluna = colunas_tabela[i];
                        string criar_coluna = $"'{nome_coluna}'{tipo_coluna}";
                        query_criar_colunas.Add(criar_coluna);
                    }
                    else
                    {
                        throw new FormatException("Tipo de dado inválido.");
                    }
                }

                string criar_colunas = String.Join(",", query_criar_colunas.ToArray());

                string criar_tabela = @$"CREATE TABLE '{nome_tabela}'('ID'INTEGER,{criar_colunas},PRIMARY KEY('ID'AUTOINCREMENT));";

                ConexaoBanco(criar_tabela);
                Console.WriteLine("Tabela criada com sucesso!");
            }
            catch (IndexOutOfRangeException ex)
            {
                // Se faltar definição de nome ou tipo da coluna:
                Console.WriteLine("Desculpa, não foi possível criar o banco de dados. Tem certeza de que inseriu todos os dados corretamente?");
            }
            catch (FormatException ex)
            {
                // Se o dado definido para a coluna não for válido em SQLite:
                Console.WriteLine("Erro na formatação de seus dados: " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no processamento de dados: " + ex);
            }
        }

        public void InserirDados(string nome_tabela, params string[] valores_tabela)
        {
            try
            {
                // Montando a string para inserção de dados na tabela
                List<string> colunas_insert = new List<string>();
                List<string> valores_insert = new List<string>();

                List<string>[] colunas_tipos = GetColunas(nome_tabela);
                List<string> nome_colunas_tabela = colunas_tipos[0];
                List<string> tipo_colunas_tabela = colunas_tipos[1];
                int index = 0;

                for (int i = 0; i < valores_tabela.Length; i += 2)
                {
                    string nome_coluna = valores_tabela[i];
                    string valor_coluna = valores_tabela[i + 1];

                    string nome_coluna_tabela = nome_colunas_tabela[index];
                    string tipo_coluna_tabela = tipo_colunas_tabela[index];

                    // Verificação se nome da coluna está correto e se tipo de dado inserido é compatível
                    if (nome_coluna == nome_coluna_tabela)
                    {
                        if (valor_coluna.Any(char.IsLetter) && tipo_coluna_tabela != "TEXT")
                        {
                            throw new FormatException("Inserção de dados inválidos: tipo de dado não suportado OU coluna não existente.");
                        }
                        else
                        {
                            string valor_coluna_query = $"'{valor_coluna}'";
                            colunas_insert.Add(nome_coluna);
                            valores_insert.Add(valor_coluna_query);
                        }
                    }
                    else
                    {
                        throw new FormatException("Inserção de dados inválidos: tipo de dado não suportado OU coluna não existente.");
                    }

                    index++;
                }
                string colunas_string = String.Join(",", colunas_insert.ToArray());
                string valores_string = String.Join(",", valores_insert.ToArray());

                string inserir_dados = @$"INSERT INTO {nome_tabela}({colunas_string}) VALUES({valores_string});";
                ConexaoBanco(inserir_dados);
                Console.WriteLine("Dados enviados com sucesso!");
                //Console.WriteLine(inserir_dados);
            }
            catch (FormatException ex)
            {
                // Formato não suportado e/ou coluna não existe:
                Console.WriteLine("Erro no envio de dados: " + ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Se faltar alguma especificação de coluna ou valor:
                Console.WriteLine("Desculpa, não foi possível inserir os dados. Tem certeza de que inseriu todos os dados corretamente?");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Se a tabela não for identificada:
                Console.WriteLine("Desculpe, não foi possível inserir os dados na tabela especificada. Tem certeza que este é o nome correto?");
            }
        }

        public void ExibirDados(string nome_tabela)
        {
            try
            {
                string selecionar_dados = $"SELECT * FROM {nome_tabela}";
                List<string>[] colunas_tipos = GetColunas(nome_tabela);
                List<string> nome_colunas_tabela = colunas_tipos[0];
                List<string> item_full = new List<string>();
                List<string> info_tabela = new List<string>();
                int index = 0;

                // Montando string para exibição de dados consultados da tabela
                Console.WriteLine("Exibindo todos os dados:");
                using (SQLiteConnection conexao = new SQLiteConnection(Conexao_string))
                {
                    SQLiteCommand query = new SQLiteCommand(selecionar_dados, conexao);
                    conexao.Open();

                    SQLiteDataReader leitor = query.ExecuteReader();
                    while (leitor.Read())
                    {
                        foreach (string coluna in nome_colunas_tabela)
                        {
                            // Especificando coluna "preço" para o caso de cadastro de produtos
                            if (nome_colunas_tabela[index] == "Preço")
                            {
                                string preco = String.Format("{0:.00}", leitor[nome_colunas_tabela[index]]);
                                string item_tabela = $"{nome_colunas_tabela[index]}: R${preco};";
                                item_full.Add(item_tabela);
                            }
                            else
                            {
                                string item_tabela = $"{nome_colunas_tabela[index]}: {leitor[nome_colunas_tabela[index]]};";
                                item_full.Add(item_tabela);
                            }

                            if (index == nome_colunas_tabela.Count - 1)
                            {
                                index = 0;
                            }
                            else
                            {
                                index++;
                            }
                        }

                        string item_full_string = String.Join(" ", item_full.ToArray());
                        info_tabela.Add(item_full_string);
                        item_full.Clear();
                    }
                    leitor.Close();
                    foreach (string item in info_tabela)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Se a tabela não for identificada:
                Console.WriteLine("Desculpe, não foi possível exibir os dados da tabela especificada. Tem certeza que este é o nome correto?");
            }
        }

        public void ConexaoBanco(string comando)
        {
            // Conexão com banco de dados e execução das strings em queries
            using (SQLiteConnection conexao = new SQLiteConnection(Conexao_string))
            {
                SQLiteCommand query = new SQLiteCommand(comando, conexao);
                conexao.Open();
                query.ExecuteNonQuery();
            }
        }

        public List<string>[] GetColunas(string nome_tabela)
        {
            // Obtendo nome e tipo das colunas para verificação de dados
            string comando = "PRAGMA table_info('" + nome_tabela + "');";

            List<string> colunas = new List<string>();
            List<string> tipo_colunas = new List<string>();

            using (SQLiteConnection conexao = new SQLiteConnection(Conexao_string))
            {
                SQLiteCommand query = new SQLiteCommand(comando, conexao);
                conexao.Open();

                SQLiteDataReader leitor = query.ExecuteReader();
                while (leitor.Read())
                {
                    colunas.Add(leitor.GetString(1));
                    tipo_colunas.Add(leitor.GetString(2));
                }
                leitor.Close();
            }

            //Console.WriteLine(String.Join(", ", colunas.ToArray()));
            //Console.WriteLine(String.Join(", ", tipo_colunas.ToArray()));

            // Removendo ID
            colunas.RemoveAt(0);
            tipo_colunas.RemoveAt(0);

            List<string>[] colunas_tipos = [colunas, tipo_colunas];

            return colunas_tipos;
        }
    }
}