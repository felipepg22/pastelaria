using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PastelariaDoZe
{
    public static class Program
    {
       
         // utilizado para monitorar se o usuário esta ou não logado
        // também para tornar acessível seus dados
        public static bool logado = false;
        public static int idLogado = 0;
        public static string nomeLogado = "";
        public static int grupoLogado = 1000;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MenuPrincipal());
        }

        
    }
}
