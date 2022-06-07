using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastelariaDoZe.DAO
{
    public class Recebimento
    {
        public int IdRecebimento { get; private set; }
        public DateTime DataHora { get; private set; }
        public double TotalComandas { get; private set; }
        public double ValorTotal { get; private set; }
        public bool Tipo { get; private set; }
        public double ValorDesconto { get; private set; }


    }
    public class RecebimentoDAO
    {
        public RecebimentoDAO()
        {

        }
    }
}
