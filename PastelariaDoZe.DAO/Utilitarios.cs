using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PastelariaDoZe.Biblioteca
{
    /// <summary>
    /// Classe que comporta todos os métodos que se utilizam na aplicação
    /// </summary>
    public static class Utilitarios
    {
        /// <summary>
        /// Método para validar a senha de login da aplicação
        /// </summary>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna true se a senha corresponder ao usuário e false se não corresponder</returns>
        public static bool validaSenhaLogin(string senha)
        {
            if (senha == "admin")
            {
                return true;
            }

            return false;
        }      

        /// <summary>
        /// Altera a cor do background quando o campo ganha foco
        /// </summary>
        /// <param name="sender">Campo que ganhou o foco</param>
        /// <param name="e">Evento que foi capturado</param>
        public static void CampoEventoEnter(object sender,System.EventArgs e)
        {
            if(sender is TextBoxBase txt)
            {
                txt.BackColor = Color.Beige;
                return;
            }

            if(sender is ButtonBase btn)
            {
                btn.BackColor = Color.LightGreen;
            }


        }

        /// <summary>
        /// Muda a cor do background quando o campo perde o foco
        /// </summary>
        /// <param name="sender">Campo que ganhou o foco</param>
        /// <param name="e">Evento que foi gerado</param>
        public static void CampoEventoLeave(object sender,System.EventArgs e)
        {
            if(sender is TextBoxBase txt)
            {
                txt.BackColor = Color.White;
                return;
            }
            if(sender is ButtonBase btn)
            {
                btn.BackColor = Color.Red;
            }
                
        }

        /// <summary>
        /// Fazer o form entender a tecla ENTER como TAB e o ESC para fechá-lo
        /// </summary>
        /// <param name="sender">Objeto que gerou o evento</param>
        /// <param name="e">Evento que foi capturado</param>
        public static void FormEventoKeyDown(object sender,KeyEventArgs e)
        {
            Control x = (Control)sender;//Obtém o form que gerou o evento
            Form form = x.FindForm();

            if (e.KeyCode == Keys.Escape)
            {
                form.Close();
                return;

            }

            if (e.KeyCode == Keys.Enter)
            {
               form.SelectNextControl(form.ActiveControl, !e.Shift, true, true, true);
            }
        }

        /// <summary>
        /// Fazer o campo aceitar apenas valores´numéricos
        /// </summary>
        /// <param name="sender">Objeto que gerou o evento</param>
        /// <param name="e">Evento que foi capturado</param>
        public static void NumericoKeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;

            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;

            }
        }

        /// <summary>
        /// Verifica se o campo senha está igual ao campo confirma senha
        /// </summary>
        /// <param name="senha">Senha digitada no campo senha</param>
        /// <param name="reSenha">Senha digitada no campo confirma senha</param>
        /// <returns></returns>
        public static bool ConfirmaSenha(string senha,string reSenha)
        {
            if(senha == reSenha)
            {
                return true;
            }

            throw new ArgumentException("Senhas não conferem!");
        }

        /// <summary>
        /// Criptografa a senha para ir para o banco de dados
        /// </summary>
        /// <param name="senha">Senha a ser criptografada</param>
        /// <returns>Retorna a senha criptografada</returns>
        public static string CriptografaSenha(string senha)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(senha));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }      
    

        /// <summary>
        /// Classe que valida se as informações dos campos atendem aos requisitos
        /// </summary>
        /// <param name="obj">Objeto que deseja validar</param>
        public static void ValidaClasse(object obj)
        {
            ValidationContext context = new ValidationContext(obj, serviceProvider: null, items: null);
            System.Collections.Generic.List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                throw new ValidationException(sbrErrors.ToString());
            }
        }

        /// <summary>
        /// Registra os eventos em um log
        /// </summary>
        /// <param name="tipo">INFO, ERRO, SQL</param>
        /// <param name="log">Texto que vai pro log</param>
        /// <param name="id">Id fo funcionário que gerou o evento</param>
        public static void SalvaLog(string tipo, string log,int id=0)
        {
            id = Program.idLogado;
            //abre o arquivo para edição
            TextWriter arquivo = File.AppendText(ConfigurationManager.AppSettings.Get("LocalLog"));
            //escreve uma nova linha no arquivo, seguindo o padrão de formatação definido
            //dataHora|||tipo|||usuário que gerou a ação|||ação
            arquivo.WriteLine(DateTime.Now + "|||" + tipo + "|||" + id + "|||" + log);
            arquivo.Close();
        }
    }
}
