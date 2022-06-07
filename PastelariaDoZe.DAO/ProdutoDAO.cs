using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PastelariaDoZe.DAO
{
    public class Produto
    {
        /// <summary>
        /// Cria uma instância da classe Produto
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <param name="descricao">Descrição do Produto</param>
        /// <param name="valorUnitario">Preço do Produto</param>
        public Produto(string nome, string descricao, double valorUnitario,byte[] foto)
        {
            Nome = nome;
            Descricao = descricao;
            ValorUnitario = valorUnitario;
            Foto = foto;
        }

        public Produto()
        {
        }

        public Produto(string nome)
        {
            Nome = nome;
        }

        public int IdProduto { get;  set; }

        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        [StringLength(100,ErrorMessage ="Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "Descrição do produto é obrigatório.")]
        [StringLength(200, ErrorMessage = "Descrição deve ter no máximo 200 caracteres.")]
        public string Descricao { get; private set; }        
        public double ValorUnitario { get; private set; }

        public byte[] Foto { get; private set; }
    }
    public class ProdutoDAO
    {
        //Utilização de mais do que um provider com o mesmo script (MySQL, SQLServer, Firebird...)
        private DbProviderFactory factory;
        /// <summary>
        /// Insere um Produto no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="produto">Objeto produto que se deseja adicionar</param>
        public void InserirDbProvider(string provider, string stringConexao, Produto produto)
        {
            /* 
             * Exemplos de provider:
             *      MySql.Data.MySqlClient
             *      System.Data.SqlClient
            */
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                //Atribui a string de conexão
                //exemplo de string: Server=localhost;port=3306;Database=pastelaria_db;Uid=root;Pwd=abcBolinhas;
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    //Atribui conexão
                    comando.Connection = conexao;

                    //Adicona parâmetro (@campo e valor)
                    var nome = comando.CreateParameter();
                    nome.ParameterName = "@nome";
                    nome.Value = produto.Nome;
                    comando.Parameters.Add(nome);

                    //Adicona parâmetro (campo e valor)
                    var descricao = comando.CreateParameter();
                    descricao.ParameterName = "@descricao";
                    descricao.Value = produto.Descricao;
                    comando.Parameters.Add(descricao);

                    var valorUnitario = comando.CreateParameter();
                    valorUnitario.ParameterName = "@valorUnitario";
                    valorUnitario.Value = produto.ValorUnitario;
                    comando.Parameters.Add(valorUnitario);

                    var foto = comando.CreateParameter();
                    foto.ParameterName = "@foto";
                    foto.Value = produto.Foto;
                    comando.Parameters.Add(foto);



                    //Abre conexão
                    conexao.Open();

                    //Script para inserir com os parametros dicionados
                    comando.CommandText = @"INSERT INTO tb_produto(nome,descricao,valor_unitario,foto) VALUES (@nome,@descricao,@valorUnitario,@foto)";

                    //Executa o script na conexão e retorna o número de linhas afetadas.
                    var linhas = comando.ExecuteNonQuery();
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }
        /// <summary>
        /// Lista todos os Produtos do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="produto">Objeto produto que se deseja listar</param>
        public DataTable SelectDbProviderAll(string provider, string stringConexao, Produto produto)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    conexao.Open();

                    comando.CommandText = @"SELECT id_produto AS ID,nome AS NOME, descricao AS DESCRICAO, foto AS FOTO, valor_unitario AS PRECO FROM tb_produto";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);


                    return linhas;
                }
            }
        }
        /// <summary>
        /// Lista um Produto do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="produto">Objeto produto que se deseja listar</param>
        public DataTable SelectDbProviderOne(string provider, string stringConexao, Produto produto)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    var idProduto = comando.CreateParameter();
                    idProduto.ParameterName = "@idProduto";
                    idProduto.Value = produto.IdProduto;
                    comando.Parameters.Add(idProduto);

                    conexao.Open();

                    comando.CommandText = @"SELECT id_produto as ID,nome as NOME,descricao as DESCRICAO,foto AS FOTO,valor_unitario AS PRECO FROM tb_produto WHERE id_produto = @idProduto";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);

                    return linhas;
                }
            }
        }
        /// <summary>
        /// Edita um Produto no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="produto">Objeto produto que se deseja editar</param>
        public void EditarDbProvider(string provider, string stringConexao, Produto produto)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;
                    var idProduto = comando.CreateParameter();
                    idProduto.ParameterName = "@idProduto";
                    idProduto.Value = produto.IdProduto;
                    comando.Parameters.Add(idProduto);

                    var nome = comando.CreateParameter();
                    nome.ParameterName = "@nome";
                    nome.Value = produto.Nome;
                    comando.Parameters.Add(nome);


                    var descricao = comando.CreateParameter();
                    descricao.ParameterName = "@descricao";
                    descricao.Value = produto.Descricao;
                    comando.Parameters.Add(descricao);

                    var foto = comando.CreateParameter();
                    foto.ParameterName = "@foto";
                    foto.Value = produto.Foto;
                    comando.Parameters.Add(foto);

                    var valorUnitario = comando.CreateParameter();
                    valorUnitario.ParameterName = "@valorUnitario";
                    valorUnitario.Value = produto.ValorUnitario;
                    comando.Parameters.Add(valorUnitario);                   

                    conexao.Open();

                    comando.CommandText = @"UPDATE tb_produto SET nome = @nome,descricao = @descricao,foto = @foto,valor_unitario = @valorUnitario WHERE id_produto = @idProduto";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Exclui um Produto no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="produto">Objeto produto que se deseja excluir</param>
        public void ExcluirDbProvider(string provider, string stringConexao, Produto produto)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;
                    var idProduto = comando.CreateParameter();
                    idProduto.ParameterName = "@idProduto";
                    idProduto.Value = produto.IdProduto;
                    comando.Parameters.Add(idProduto);

                    conexao.Open();

                    comando.CommandText = @"DELETE FROM tb_produto WHERE id_produto = @idProduto";

                    var linhas = comando.ExecuteNonQuery();
                }
            }

        }
        /// <summary>
        /// Lista um Produto no banco de dados procurando pelo nome
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="produto">Objeto produto que se deseja pesquisar</param>
        public DataTable SelectDbProviderNome(string provider, string stringConexao, Produto produto)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;
                using(var comando = factory.CreateCommand())
                {
                    //Atribui conexão
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var nome = comando.CreateParameter();
                    nome.ParameterName = "@nome";
                    nome.Value = "%" + produto.Nome + "%";
                    comando.Parameters.Add(nome);
                    conexao.Open();
                    comando.CommandText = @"SELECT id_produto AS ID, nome AS Nome, valor_unitario
                    AS Valor, descricao AS Descrição, foto AS Imagem FROM tb_produto WHERE nome like @nome";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);

                    return linhas;
                }
            }
        }
        //metodos para editar, excluir, listar, etc
        public ProdutoDAO()
        {

        }
    }
}
