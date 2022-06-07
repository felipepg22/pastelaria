using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastelariaDoZe.DAO
{
    public class Empresa
    {
        public Empresa(double taxaJuroDiario, double multaAtraso)
        {
            TaxaJuroDiario = taxaJuroDiario;
            MultaAtraso = multaAtraso;
        }

        public Empresa()
        {
        }

        public int IdEmpresa { get; private set; }
        public double TaxaJuroDiario { get;  private set; }
        public double MultaAtraso { get; private set; }

    }
    public class EmpresaDAO
    {
        //Utilização de mais do que um provider com o mesmo script (MySQL, SQLServer, Firebird...)
        private DbProviderFactory factory;

        
        /// <summary>
        /// Edita os parâmetros Multa e Juros
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="empresa">Objeto empresa</param>
        public void EditarDbProvider(string provider,string stringConexao,Empresa empresa)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    var taxaJuroDiario = comando.CreateParameter();
                    taxaJuroDiario.ParameterName = "@taxaJuroDiario";
                    taxaJuroDiario.Value = empresa.TaxaJuroDiario;
                    comando.Parameters.Add(taxaJuroDiario);

                    //Adicona parâmetro (campo e valor)
                    var multaAtraso = comando.CreateParameter();
                    multaAtraso.ParameterName = "@multaAtraso";
                    multaAtraso.Value = empresa.MultaAtraso;
                    comando.Parameters.Add(multaAtraso);

                    conexao.Open();

                    comando.CommandText = @"UPDATE tb_empresa SET taxa_juro_diario = @taxaJuroDiario,multa_atraso = @multaAtraso";

                    var linhas = comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Lista os parâmetros Multa e Juros que se encontram no banco de dados
        /// </summary>
        /// <param name="provider">SGBD Usado</param>
        /// <param name="stringConexao">Local do banco de dados</param>
        /// <param name="empresa">Objeto empresa</param>
        /// <returns></returns>
        public DataTable SelectDbProviderOne(string provider, string stringConexao, Empresa empresa)
        {
            factory = DbProviderFactories.GetFactory(provider);

            using (var conexao = factory.CreateConnection())
            {
                conexao.ConnectionString = stringConexao;

                using (var comando = factory.CreateCommand())
                {
                    comando.Connection = conexao;

                    var taxaJuroDiario = comando.CreateParameter();
                    taxaJuroDiario.ParameterName = "@taxaJuroDiario";
                    taxaJuroDiario.Value = empresa.TaxaJuroDiario;
                    comando.Parameters.Add(taxaJuroDiario);

                    //Adicona parâmetro (campo e valor)
                    var multaAtraso = comando.CreateParameter();
                    multaAtraso.ParameterName = "@multaAtraso";
                    multaAtraso.Value = empresa.MultaAtraso;
                    comando.Parameters.Add(multaAtraso);

                    conexao.Open();

                    comando.CommandText = @"SELECT taxa_juro_diario AS JUROS,multa_atraso AS MULTA FROM tb_empresa";

                    var sdr = comando.ExecuteReader();
                    DataTable linhas = new DataTable();
                    linhas.Load(sdr);


                    return linhas;

                }
            }
        }

        //metodos para editar, excluir, listar, etc
        
    }
}

