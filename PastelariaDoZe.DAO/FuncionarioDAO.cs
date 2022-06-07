using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PastelariaDoZe.DAO
{
    public class Funcionario
    {

        /// <summary>
        /// Cria uma instância da classe Funcionario
        /// </summary>
        /// <param name="nome">Nome do Funcionário</param>
        /// <param name="senha">Senha para acesso do Funcionário</param>
        /// <param name="grupo">Se o funcionário é administrador ou atendente: 0 = Admin e 1 = Atendente</param>
        /// <param name="matricula">Matrícula do Funcionário</param>
        /// <param name="cpf">CPF do Funcionário</param>
        /// <param name="telefone">Número de Telefone do Funcionário</param>
        public Funcionario(string nome, string senha, int grupo, string matricula, string cpf, string telefone)
        {
            Nome = nome;
            Senha = senha;
            Grupo = grupo;
            Matricula = matricula;
            Cpf = cpf;
            Telefone = telefone;
        }

        public Funcionario(string senha, string cpf)
        {
            Senha = senha;
            Cpf = cpf;
        }

        public Funcionario(string nome)
        {
            Nome = nome;
        }

        public Funcionario()
        {
        }

        public Funcionario(string nome, int grupo, string matricula, string cpf, string telefone)
        {
            Nome = nome;
            Grupo = grupo;
            Matricula = matricula;
            Cpf = cpf;
            Telefone = telefone;
        }

        public int IdFuncionario { get;  set; }

        [Required(ErrorMessage ="Nome do funcionário é obrigatório.")]
        [StringLength(100,ErrorMessage ="Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get;  private set; }

        
        public string Senha { get;  private set; }
        public int Grupo { get; private set; }

        [Required(ErrorMessage = "Matrícula do funcionário é obrigatório.")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "Matrícula deve ter 10 caracteres")]
        public string Matricula { get; private set; }

        [Required(ErrorMessage = "CPF do funcionário é obrigatório.")]
        [StringLength(11,MinimumLength =11, ErrorMessage = "CPF deve ter 11 dígitos.")]
        public string Cpf { get; private set; }

        [Required(ErrorMessage = "Telefone do funcionário é obrigatório.")]
        [StringLength(11,MinimumLength =11, ErrorMessage = "Telefone deve ter 11 dígitos.")]
        public string Telefone { get; private set; }

    }
    public class FuncionarioDAO
    {
        //Utilização de mais do que um provider com o mesmo script (MySQL, SQLServer, Firebird...)
        private DbProviderFactory factory;
        /// <summary>
        /// Insere um Funcionário no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja adicionar</param>
        public void InserirDbProvider(string provider, string stringConexao, Funcionario funcionario)
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
                    nome.Value = funcionario.Nome;
                    comando.Parameters.Add(nome);

                    //Adicona parâmetro (campo e valor)
                    var senha = comando.CreateParameter();
                    senha.ParameterName = "@senha";
                    senha.Value = funcionario.Senha;
                    comando.Parameters.Add(senha);

                    var grupo = comando.CreateParameter();
                    grupo.ParameterName = "@grupo";
                    grupo.Value = funcionario.Grupo;
                    comando.Parameters.Add(grupo);

                    var matricula = comando.CreateParameter();
                    matricula.ParameterName = "@matricula";
                    matricula.Value = funcionario.Matricula;
                    comando.Parameters.Add(matricula);

                    var cpf = comando.CreateParameter();
                    cpf.ParameterName = "@cpf";
                    cpf.Value = funcionario.Cpf;
                    comando.Parameters.Add(cpf);

                    var telefone = comando.CreateParameter();
                    telefone.ParameterName = "@telefone";
                    telefone.Value = funcionario.Telefone;
                    comando.Parameters.Add(telefone);



                    //Abre conexão
                    conexao.Open();

                    //Script para inserir com os parametros dicionados
                    comando.CommandText = @"INSERT INTO tb_funcionario(nome,senha,grupo,matricula,cpf,telefone) VALUES (@nome,@senha,@grupo,@matricula,@cpf,@telefone)";

                    //Executa o script na conexão e retorna o número de linhas afetadas.
                    var linhas = comando.ExecuteNonQuery();
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }
        /// <summary>
        /// Lista todos os Funcionários do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja listar</param>
        public DataTable SelectDbProviderAll(string provider, string stringConexao,Funcionario funcionario)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    conexao.Open();

                    comando.CommandText = @"SELECT id_funcionario as ID,nome as NOME,cpf as CPF,telefone AS telefone, matricula AS matricula,if(grupo =1,'Admin','Balcão') as GRUPO FROM tb_funcionario";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);


                    return linhas;
                }
            }
        }
        /// <summary>
        /// Lista um Funcionário do banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja listar</param>
        public DataTable SelectDbProviderOne(string provider, string stringConexao, Funcionario funcionario)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = funcionario.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    conexao.Open();

                    comando.CommandText = @"SELECT id_funcionario as ID,nome as NOME,cpf as CPF,telefone AS telefone, matricula AS matricula,if(grupo =1,'Admin','Balcão') as GRUPO FROM tb_funcionario WHERE id_funcionario = @idFuncionario";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);

                    return linhas;
                }
            }
        }

        /// <summary>
        /// Edita um Funcionário no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja editar</param>
        public void EditarDbProvider(string provider, string stringConexao, Funcionario funcionario)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;
                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = funcionario.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    var nome = comando.CreateParameter();
                    nome.ParameterName = "@nome";
                    nome.Value = funcionario.Nome;
                    comando.Parameters.Add(nome);
                

                    var grupo = comando.CreateParameter();
                    grupo.ParameterName = "@grupo";
                    grupo.Value = funcionario.Grupo;
                    comando.Parameters.Add(grupo);
                   

                    var matricula = comando.CreateParameter();
                    matricula.ParameterName = "@matricula";
                    matricula.Value = funcionario.Matricula;
                    comando.Parameters.Add(matricula);

                    var cpf = comando.CreateParameter();
                    cpf.ParameterName = "@cpf";
                    cpf.Value = funcionario.Cpf;
                    comando.Parameters.Add(cpf);

                    var telefone = comando.CreateParameter();
                    telefone.ParameterName = "@telefone";
                    telefone.Value = funcionario.Telefone;
                    comando.Parameters.Add(telefone);

                    conexao.Open();

                    comando.CommandText = @"UPDATE tb_funcionario SET nome = @nome,cpf = @cpf,matricula = @matricula,telefone = @telefone,grupo = @grupo WHERE id_funcionario = @idFuncionario";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Exclui um Funcionário no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja excluir</param>
        public void ExcluirDbProvider(string provider, string stringConexao,Funcionario funcionario)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using(var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;
                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = funcionario.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    conexao.Open();

                    comando.CommandText = @"DELETE FROM tb_funcionario WHERE id_funcionario = @idFuncionario";

                   var linhas = comando.ExecuteNonQuery();
                }
            }

        }
        /// <summary>
        /// Valida o login do Funcionario comparando CPF e senha
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja validar</param>
        public DataTable ValidaLogin(string provider, string stringConexao, Funcionario funcionario)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    var cpf = comando.CreateParameter();
                    cpf.ParameterName = "@cpf";
                    cpf.Value = funcionario.Cpf;
                    comando.Parameters.Add(cpf);

                    var senha = comando.CreateParameter();
                    senha.ParameterName = "@senha";
                    senha.Value = funcionario.Senha;
                    comando.Parameters.Add(senha);

                    conexao.Open();
                    comando.CommandText = @"SELECT id_funcionario AS ID, nome AS Nome, cpf AS CPF,
                    telefone AS Telefone, matricula AS Matricula, if(grupo = 1,'Admin','Balcão') AS
                    Grupo FROM tb_funcionario WHERE cpf = @cpf and senha = @senha";

                    //Executa o script na conexão e retorna as linhas afetadas.
                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);
                    return linhas;
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }
        /// <summary>
        /// Lista um Funcionário no banco de dados procurando pelo nome
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="funcionario">Objeto Funcionario que se deseja pesquisar</param>
        public DataTable SelectDbProviderNome(string provider, string stringConexao, Funcionario funcionario)
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
                    nome.Value = "%" + funcionario.Nome + "%";
                    comando.Parameters.Add(nome);
                    conexao.Open();
                    comando.CommandText = @"SELECT id_funcionario as ID,nome as NOME,cpf as CPF,telefone AS telefone, matricula AS matricula,if(grupo =1,'Admin','Balcão') as GRUPO FROM tb_funcionario WHERE nome like @nome";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);

                    return linhas;
                }
            }
        }


        public FuncionarioDAO()
        {

        }
    }
}
