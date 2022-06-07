using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastelariaDoZe.DAO
{
    public class Comanda
    {
        public int IdComanda { get;  set; }
        public string NumeroComanda { get; private set; }
        public DateTime DataFiado { get; private set; }
        public int StatusPagamento { get; private set; }
        public int StatusComanda { get;  set; }
        public DateTime DataHora { get;  set; }
        public int IdFuncionario { get; private set; }
        public int IdCliente { get;  set; }

        public double ValorCobrado { get; private set; }

        public Comanda(string numeroComanda, int statusComanda, DateTime dataHora)
        {
            NumeroComanda = numeroComanda;
            StatusComanda = statusComanda;
            DataHora = dataHora;
        }

        public Comanda()
        {
        }

        public Comanda(int idComanda, string numeroComanda)
        {
            IdComanda = idComanda;
            NumeroComanda = numeroComanda;
        }

        public Comanda(int idComanda, int statusPagamento, int statusComanda, int idFuncionario, int idCliente, double valorCobrado)
        {
            IdComanda = idComanda;
            StatusPagamento = statusPagamento;
            StatusComanda = statusComanda;
            IdFuncionario = idFuncionario;
            IdCliente = idCliente;
            ValorCobrado = valorCobrado;
        }

        public Comanda(int idComanda, DateTime dataFiado, int statusPagamento, int statusComanda, int idFuncionario, int idCliente)
        {
            IdComanda = idComanda;
            DataFiado = dataFiado;
            StatusPagamento = statusPagamento;
            StatusComanda = statusComanda;
            IdFuncionario = idFuncionario;
            IdCliente = idCliente;
        }

        public override string ToString()
        {
            return this.NumeroComanda;
        }
    }
    public class ComandaProdutos
    {
        public int IdComandaProduto { get; private set; }
        public int IdComanda { get;  set; }
        public int IdProduto { get; private set; }
        public int Quantidade { get; private set; }
        public double ValorUnitario { get; private set; }
        public int IdFuncionario { get; private set; }

        public ComandaProdutos(int idComanda, int idProduto, int quantidade, double valorUnitario, int idFuncionario)
        {
            IdComanda = idComanda;
            IdProduto = idProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            IdFuncionario = idFuncionario;
        }

        public ComandaProdutos(int idComandaProduto, int quantidade, int idFuncionario)
        {
            IdComandaProduto = idComandaProduto;
            Quantidade = quantidade;
            IdFuncionario = idFuncionario;
        }

        public ComandaProdutos(int idComandaProduto)
        {
            IdComandaProduto = idComandaProduto;
        }

        public ComandaProdutos()
        {
        }
    }
    public class ComandaDAO
    {
        private DbProviderFactory factory;
        public DataTable ListaComandas(string provider, string stringConexao, Comanda comanda)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)                    
                    var statusComanda = comando.CreateParameter();
                    statusComanda.ParameterName = "@statusComanda";
                    statusComanda.Value = comanda.StatusComanda;
                    comando.Parameters.Add(statusComanda);

                    conexao.Open();
                    comando.CommandText = @"SELECT id_comanda AS ID, comanda AS Comanda,
                    data_hora AS Data, if(status_comanda=0,'Aberta','Fechada') AS Status FROM tb_comanda WHERE
                    status_comanda = @statusComanda";
                    //Executa o script na conexão e retorna as linhas afetadas.
                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);
                    return linhas;
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }

        public bool AbreNovaComanda(string provider, string stringConexao, Comanda comanda)
        {
            factory = DbProviderFactories.GetFactory(provider);
            bool auxRetorno;
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    var numeroComanda = comando.CreateParameter();
                    numeroComanda.ParameterName = "@numeroComanda";
                    numeroComanda.Value = comanda.NumeroComanda;
                    comando.Parameters.Add(numeroComanda);

                    var dataHora = comando.CreateParameter();
                    dataHora.ParameterName = "@dataHora";
                    dataHora.Value = comanda.DataHora;
                    comando.Parameters.Add(dataHora);

                    var statusComanda = comando.CreateParameter();
                    statusComanda.ParameterName = "@statusComanda";
                    statusComanda.Value = comanda.StatusComanda;
                    comando.Parameters.Add(statusComanda);

                    conexao.Open();
                    // antes de abrir a comanda precisa validar se ela já não esta aberta
                    comando.CommandText = @"SELECT id_comanda FROM tb_comanda WHERE status_comanda = @statusComanda and
                    comanda = @numeroComanda";
                    DataTable qtdaComandas = new DataTable();
                    qtdaComandas.Load(comando.ExecuteReader());
                    if (qtdaComandas.Rows.Count > 0)
                    {
                        auxRetorno = false;
                    }
                    else
                    {
                        comando.CommandText = @"INSERT INTO tb_comanda(comanda, data_hora, status_comanda) VALUES
                (@numeroComanda, @dataHora, @statusComanda)";
                        var linhas = comando.ExecuteNonQuery();
                        auxRetorno = true;
                    }
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
            return auxRetorno;
        }

        public void ExcluiComanda(string provider, string stringConexao, Comanda comanda)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    var idComanda = comando.CreateParameter();
                    idComanda.ParameterName = "@idComanda";
                    idComanda.Value = comanda.IdComanda;
                    comando.Parameters.Add(idComanda);

                    conexao.Open();

                    comando.CommandText = @"DELETE FROM tb_comanda WHERE id_comanda = @idComanda";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }

        public void AddItemComanda(string provider, string stringConexao, ComandaProdutos comandaProdutos)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;

                    var idComanda = comando.CreateParameter();
                    idComanda.ParameterName = "@idComanda";
                    idComanda.Value = comandaProdutos.IdComanda;
                    comando.Parameters.Add(idComanda);

                    var idProduto = comando.CreateParameter();
                    idProduto.ParameterName = "@idProduto";
                    idProduto.Value = comandaProdutos.IdProduto;
                    comando.Parameters.Add(idProduto);

                    var quantidade = comando.CreateParameter();
                    quantidade.ParameterName = "@quantidade";
                    quantidade.Value = comandaProdutos.Quantidade;
                    comando.Parameters.Add(quantidade);

                    var valorUnitario = comando.CreateParameter();
                    valorUnitario.ParameterName = "@valorUnitario";
                    valorUnitario.Value = comandaProdutos.ValorUnitario;
                    comando.Parameters.Add(valorUnitario);

                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = comandaProdutos.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    conexao.Open();
                    comando.CommandText = @"INSERT INTO tb_comanda_produto(comanda_id, produto_id, quantidade, valor_unitario,
funcionario_id) VALUES (@idComanda, @idProduto, @quantidade, @valorUnitario, @idFuncionario)";
                    //Executa o script na conexão e retorna o número de linhas afetadas.
                    var linhas = comando.ExecuteNonQuery();
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }

        public DataTable ListaItensComanda(string provider, string stringConexao, ComandaProdutos comandaProdutos)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                //Atribui a string de conexão
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    //Atribui conexão
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var idComanda = comando.CreateParameter();
                    idComanda.ParameterName = "@idComanda";
                    idComanda.Value = comandaProdutos.IdComanda;
                    comando.Parameters.Add(idComanda);
                    conexao.Open();
                    comando.CommandText = @"SELECT cp.id_comanda_produto AS ID, p.nome AS Nome, cp.quantidade AS
Quantidade, cp.valor_unitario AS Unitário, f.nome AS Funcionário
FROM tb_comanda_produto cp
INNER JOIN tb_produto p ON cp.produto_id = p.id_produto
INNER JOIN tb_funcionario f ON cp.funcionario_id = f.id_funcionario
WHERE cp.comanda_id = @idComanda";
                    //Executa o script na conexão e retorna as linhas afetadas.
                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);
                    return linhas;
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }
        public void EditaItemComanda(string provider,string stringConexao,ComandaProdutos comandaProdutos)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using(var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using(var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    //Adiciona parâmetros

                    var idComandaProduto = comando.CreateParameter();
                    idComandaProduto.ParameterName = "@idComandaProduto";
                    idComandaProduto.Value = comandaProdutos.IdComandaProduto;
                    comando.Parameters.Add(idComandaProduto);

                    var quantidade = comando.CreateParameter();
                    quantidade.ParameterName = "@quantidade";
                    quantidade.Value = comandaProdutos.Quantidade;
                    comando.Parameters.Add(quantidade);

                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = comandaProdutos.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    conexao.Open();

                    comando.CommandText = @"UPDATE tb_comanda_produto
                                            SET quantidade = @quantidade,
                                            funcionario_id = @idFuncionario 
                                            WHERE id_comanda_produto = @idComandaProduto";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }

        public void ExcluiItemComanda(string provider, string stringConexao,ComandaProdutos comandaProdutos)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using(var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using(var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    var idComandaProduto = comando.CreateParameter();
                    idComandaProduto.ParameterName = "@idComandaProduto";
                    idComandaProduto.Value = comandaProdutos.IdComandaProduto;
                    comando.Parameters.Add(idComandaProduto);

                    conexao.Open();

                    comando.CommandText = @"DELETE FROM tb_comanda_produto 
                                            WHERE id_comanda_produto = @idComandaProduto";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }

        public double TotalComanda(string provider, string stringConexao, ComandaProdutos comandaProdutos)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var idComanda = comando.CreateParameter();
                    idComanda.ParameterName = "@idComanda";
                    idComanda.Value = comandaProdutos.IdComanda;
                    comando.Parameters.Add(idComanda);
                    conexao.Open();
                    comando.CommandText = @"SELECT SUM( quantidade * valor_unitario ) AS Total FROM
                    tb_comanda_produto WHERE comanda_id = @idComanda";
                    //Executa o script na conexão e retorna as linhas afetadas.
                    var sdr = comando.ExecuteReader();
                    sdr.Read();
                    return Convert.ToDouble(sdr["Total"]);
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }

        public void RecebeComandaAVista(string provider, string stringConexao, Comanda comanda)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    var idComanda = comando.CreateParameter();
                    idComanda.ParameterName = "@idComanda";
                    idComanda.Value = comanda.IdComanda;
                    comando.Parameters.Add(idComanda);

                    var statusComanda = comando.CreateParameter();
                    statusComanda.ParameterName = "@statusComanda";
                    statusComanda.Value = comanda.StatusComanda;
                    comando.Parameters.Add(statusComanda);

                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = comanda.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    var statusPagamento = comando.CreateParameter();
                    statusPagamento.ParameterName = "@statusPagamento";
                    statusPagamento.Value = comanda.StatusPagamento;
                    comando.Parameters.Add(statusPagamento);

                    var valorCobrado = comando.CreateParameter();
                    valorCobrado.ParameterName = "@valorCobrado";
                    valorCobrado.Value = comanda.ValorCobrado;
                    comando.Parameters.Add(valorCobrado);

                    //verifica se foi informado o ID do cliente e ajusta o sql
                    string auxIdCliente = (comanda.IdCliente > 0) ? "cliente_id = " + comanda.IdCliente + "," : "";
                    conexao.Open();
                    comando.CommandText = @"UPDATE tb_comanda SET status_comanda = @statusComanda, " + auxIdCliente + " funcionario_id = @idFuncionario, status_pagamento = @statusPagamento, valor_cobrado = @valorCobrado WHERE id_comanda = @idComanda";
                     //Executa o script na conexão e retorna o número de linhas afetadas.
                    var linhas = comando.ExecuteNonQuery();
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }

        public bool ValidaInadimplencia(string provider, string stringConexao, Comanda comanda)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var idCliente = comando.CreateParameter();
                    idCliente.ParameterName = "@idCliente";
                    idCliente.Value = comanda.IdCliente;
                    comando.Parameters.Add(idCliente);

                    var dataComanda = comando.CreateParameter();
                    dataComanda.ParameterName = "@dataComanda";
                    dataComanda.Value = comanda.DataHora;
                    comando.Parameters.Add(dataComanda);

                    conexao.Open();
                    comando.CommandText = @"SELECT id_comanda AS ID FROM tb_comanda WHERE status_comanda
                                           = 2 and cliente_id = @idCliente and @dataComanda > data_hora";
                    //Executa o script na conexão e retorna as linhas afetadas.
                    var sdr = comando.ExecuteReader();
                    return sdr.HasRows; //retorna verdadeiro ou falso, caso tenha ou não registros
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }

        public void RegistraComandaFiado(string provider, string stringConexao, Comanda comanda)
        {
            factory = DbProviderFactories.GetFactory(provider);
            using (var conexao = factory.CreateConnection()) //Cria conexão
            {
                conexao.ConnectionString = stringConexao;
                using (var comando = factory.CreateCommand()) //Cria comando
                {
                    comando.Connection = conexao;
                    //Adiciona parâmetros (@campo e valor)
                    var idComanda = comando.CreateParameter();
                    idComanda.ParameterName = "@idComanda";
                    idComanda.Value = comanda.IdComanda;
                    comando.Parameters.Add(idComanda);

                    var statusComanda = comando.CreateParameter();
                    statusComanda.ParameterName = "@statusComanda";
                    statusComanda.Value = comanda.StatusComanda;
                    comando.Parameters.Add(statusComanda);

                    var idCliente = comando.CreateParameter();
                    idCliente.ParameterName = "@idCliente";
                    idCliente.Value = comanda.IdCliente;
                    comando.Parameters.Add(idCliente);

                    var idFuncionario = comando.CreateParameter();
                    idFuncionario.ParameterName = "@idFuncionario";
                    idFuncionario.Value = comanda.IdFuncionario;
                    comando.Parameters.Add(idFuncionario);

                    var statusPagamento = comando.CreateParameter();
                    statusPagamento.ParameterName ="@statusPagamento";
                    statusPagamento.Value = comanda.StatusPagamento;
                    comando.Parameters.Add(statusPagamento);

                    var dataAssinatura = comando.CreateParameter();
                    dataAssinatura.ParameterName = "@dataAssinatura";
                    dataAssinatura.Value = comanda.DataFiado;
                    comando.Parameters.Add(dataAssinatura);

                    conexao.Open();
                    comando.CommandText = @"UPDATE tb_comanda SET status_comanda = @statusComanda, cliente_id =
                                          @idCliente, funcionario_id = @idFuncionario, status_pagamento = @statusPagamento,
                                          data_assinatura_fiado = @dataAssinatura WHERE id_comanda = @idComanda";
                    var linhas = comando.ExecuteNonQuery();
                }
            } //using faz o conexao.Close() automático quando fecha o seu escopo
        }



        public ComandaDAO()
        {

        }
    }
}


