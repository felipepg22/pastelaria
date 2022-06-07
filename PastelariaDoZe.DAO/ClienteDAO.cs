
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace PastelariaDoZe.DAO
{
    public class Cliente
    {      


        public int IdCliente { get;  set; }

        [Required(ErrorMessage = "Nome do Cliente é obrigatório.")]
        [StringLength(100,ErrorMessage ="Nome deve ter no máximo 100 caracteres")]
        public string Nome { get;  private set; }

        [Required(ErrorMessage = "Número do telefone é obrigatório.")]
        [StringLength(11,MinimumLength =11,ErrorMessage ="Telefone deve ter 11 digitos")]

        public string Telefone { get; private set; }

        [Required(ErrorMessage = "CPF do Cliente é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 dígitos.")]
        public string Cpf { get; private set; }
        public int ConsomeFiado { get; private set; }
        public int DiaFiado { get; private set; }

        public string Senha { get; private set; }

        /// <summary>
        /// Cria uma instância da classe Cliente
        /// </summary>
        /// <param name="nome">Nome do Cliente</param>
        /// <param name="telefone">Número de telefone do Cliente</param>
        /// <param name="cpf">Número do CPF do Cliente</param>
        /// <param name="consomeFiado">Se o Cliente está liberado para pagar em fiado: 0 = não e 1 = sim</param>
        /// <param name="diaFiado">Dia do pagamento do fiado</param>
        /// <param name="senha">Senha do Cliente</param>
        public Cliente(string nome, string telefone, string cpf, int consomeFiado, int diaFiado, string senha)
        {
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            ConsomeFiado = consomeFiado;
            DiaFiado = diaFiado;
            Senha = senha;
        }

        public Cliente(string nome, string telefone, string cpf, int consomeFiado, int diaFiado)
        {
            Nome = nome;
            Telefone = telefone;
            Cpf = cpf;
            ConsomeFiado = consomeFiado;
            DiaFiado = diaFiado;
        }

        public Cliente(string nome)
        {
            Nome = nome;
        }

        public Cliente(int idCliente=0, string cpf=null)
        {
            IdCliente = idCliente;
            Cpf = cpf;
        }

        public Cliente(string cpf, string senha) 
        {
            Cpf = cpf;
            Senha = senha;
        }

        public Cliente()
        {
        }
    }
    public class ClienteDAO
    {
        //Utilização de mais do que um provider com o mesmo script (MySQL, SQLServer, Firebird...)
        private DbProviderFactory factory;
     
        /// <summary>
        /// Insere um Cliente no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local que se localiza o banco</param>
        /// <param name="cliente">Objeto cliente que se deseja adicionar</param>
        public void InserirDbProvider(string provider, string stringConexao, Cliente cliente)
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
                        nome.Value = cliente.Nome;
                        comando.Parameters.Add(nome);

                        //Adicona parâmetro (campo e valor)
                        var senha = comando.CreateParameter();
                        senha.ParameterName = "@senha";
                        senha.Value = cliente.Senha;
                        comando.Parameters.Add(senha);



                        var compraFiado = comando.CreateParameter();
                        compraFiado.ParameterName = "@compraFiado";
                        compraFiado.Value = cliente.ConsomeFiado;
                        comando.Parameters.Add(compraFiado);

                        var cpf = comando.CreateParameter();
                        cpf.ParameterName = "@cpf";
                        cpf.Value = cliente.Cpf;
                        comando.Parameters.Add(cpf);

                        var telefone = comando.CreateParameter();
                        telefone.ParameterName = "@telefone";
                        telefone.Value = cliente.Telefone;
                        comando.Parameters.Add(telefone);

                        var diaFiado = comando.CreateParameter();
                        diaFiado.ParameterName = "@diaFiado";
                        diaFiado.Value = cliente.DiaFiado;
                        comando.Parameters.Add(diaFiado);

                        //Abre conexão
                        conexao.Open();

                        //Script para inserir com os parametros dicionados
                        comando.CommandText = @"INSERT INTO tb_cliente(nome,senha,compra_fiado,dia_fiado,cpf,telefone) VALUES (@nome,@senha,@compraFiado,@diaFiado,@cpf,@telefone)";

                        //Executa o script na conexão e retorna o número de linhas afetadas.
                        var linhas = comando.ExecuteNonQuery();
                        
                }
                    


                   
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        /// <summary>
        /// Lista todos os Clientes do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local que se localiza o banco</param>
        /// <param name="cliente">Objeto cliente que se deseja listar</param>
        /// <returns></returns>
        public DataTable SelectDbProviderAll(string provider, string stringConexao, Cliente cliente)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    conexao.Open();

                    comando.CommandText = @"SELECT id_cliente as ID, nome as NOME,cpf AS CPF,telefone AS TELEFONE,if(compra_fiado=0,'Não','Sim') as FIADO,dia_fiado AS 'Dia de Pagamento' FROM tb_cliente";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);


                    return linhas;
                }
            }
        }
        /// <summary>
        /// Lista um Cliente do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local que se localiza o banco</param>
        /// <param name="cliente">Objeto cliente que se deseja listar</param>
        /// <returns></returns>
        public DataTable SelectDbProviderOne(string provider, string stringConexao, Cliente cliente,bool buscaCPF=false)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    var idCliente = comando.CreateParameter();
                    idCliente.ParameterName = "@idCliente";
                    idCliente.Value = cliente.IdCliente;
                    comando.Parameters.Add(idCliente);

                    var cpf = comando.CreateParameter();
                    cpf.ParameterName = "@cpf";
                    cpf.Value = cliente.Cpf;
                    comando.Parameters.Add(cpf);

                    conexao.Open();

                    if (!buscaCPF)
                    {
                        comando.CommandText = @"SELECT id_cliente as ID,nome as NOME,cpf as CPF,telefone AS telefone,if(compra_fiado = 0,'Não','Sim') AS FIADO, dia_fiado AS 'Data de Pagamento' FROM tb_cliente WHERE id_cliente = @idCliente";

                    }
                    else 
                    {
                        comando.CommandText = @"SELECT id_cliente as ID,nome as NOME,cpf as CPF,telefone AS telefone,if(compra_fiado = 0,'Não','Sim') AS FIADO, dia_fiado AS 'Data de Pagamento' FROM tb_cliente WHERE cpf = @cpf";

                    }
                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);

                    return linhas;
                }
            }
        }
        /// <summary>
        /// Edita um Cliente do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local que se localiza o banco</param>
        /// <param name="cliente">Objeto cliente que se deseja editar</param>
        public void EditarDbProvider(string provider, string stringConexao, Cliente cliente)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;
                    var idCliente = comando.CreateParameter();
                    idCliente.ParameterName = "@idCliente";
                    idCliente.Value = cliente.IdCliente;
                    comando.Parameters.Add(idCliente);

                    var nome = comando.CreateParameter();
                    nome.ParameterName = "@nome";
                    nome.Value = cliente.Nome;
                    comando.Parameters.Add(nome);

                    var cpf = comando.CreateParameter();
                    cpf.ParameterName = "@cpf";
                    cpf.Value = cliente.Cpf;
                    comando.Parameters.Add(cpf);


                    var telefone = comando.CreateParameter();
                    telefone.ParameterName = "@telefone";
                    telefone.Value = cliente.Telefone;
                    comando.Parameters.Add(telefone);


                    var compraFiado = comando.CreateParameter();
                    compraFiado.ParameterName = "@compraFiado";
                    compraFiado.Value = cliente.ConsomeFiado;
                    comando.Parameters.Add(compraFiado);

                    var diaFiado = comando.CreateParameter();
                    diaFiado.ParameterName = "@diaFiado";
                    diaFiado.Value = cliente.DiaFiado;
                    comando.Parameters.Add(diaFiado);    

                    


                    conexao.Open();

                    comando.CommandText = @"UPDATE tb_cliente SET nome = @nome,cpf = @cpf,telefone = @telefone,compra_fiado = @compraFiado,dia_fiado = @diaFiado WHERE id_cliente = @idCliente";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Exclui um Cliente do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local que se localiza o banco</param>
        /// <param name="cliente">Objeto cliente que se deseja excluir</param>
        public void ExcluirDbProvider(string provider, string stringConexao, Cliente cliente)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;
                    var idCliente = comando.CreateParameter();
                    idCliente.ParameterName = "@idCliente";
                    idCliente.Value = cliente.IdCliente;
                    comando.Parameters.Add(idCliente);

                    conexao.Open();

                    comando.CommandText = @"DELETE FROM tb_cliente WHERE id_cliente = @idCliente";

                    var linhas = comando.ExecuteNonQuery();
                }
            }

        }
        /// <summary>
        /// Lista um Cliente do banco de dados buscando pelo nome
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local que se localiza o banco</param>
        /// <param name="cliente">Objeto cliente que se deseja pesquisar</param>
        /// <returns></returns>
        public DataTable SelectDbProviderNome(string provider, string stringConexao, Cliente cliente)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand())
                {
                    //Atribui conexão
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var nome = comando.CreateParameter();
                    nome.ParameterName = "@nome";
                    nome.Value = "%" + cliente.Nome + "%";
                    comando.Parameters.Add(nome);
                    conexao.Open();
                    comando.CommandText = @"SELECT id_cliente as ID,nome as NOME,cpf as CPF,telefone as TELEFONE,if(compra_fiado=0,'Não','Sim') as FIADO,dia_fiado as 'Dia de Pagamento' FROM tb_cliente WHERE nome like @nome";
                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);

                    return linhas;
                }
            }
        }

        public bool ValidaSenhaCliente(string provider, string stringConexao, Cliente cliente)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var cpf = comando.CreateParameter();
                    cpf.ParameterName = "@cpf";
                    cpf.Value = cliente.Cpf;
                    comando.Parameters.Add(cpf);

                    var senha = comando.CreateParameter();
                    senha.ParameterName = "@senha";
                    senha.Value = cliente.Senha;
                    comando.Parameters.Add(senha);

                    conexao.Open();
                    comando.CommandText = @"SELECT id_cliente AS ID FROM tb_cliente WHERE cpf = @cpf and senha = @senha";
                    //Executa o script na conexão e retorna as linhas afetadas.
                    var sdr = comando.ExecuteReader();
                    return sdr.HasRows; //retorna verdadeiro ou falso, caso tenha ou não registros
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }




        public ClienteDAO()
            {

            }


    }

        //metodos para editar, excluir, listar, etc

        
    }



