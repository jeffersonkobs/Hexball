using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PrimeiraAPP_MVC4.Models
{
    public class ConexaoBancoMySQL
    {
        private static MySqlConnection objConexao = null;

        // string mysql acessa o banco do servidor de hospedagem
        //private String stringconnection1 = “server=seusite.com.br;User Id = seuid; password=suasenha;database=seubanconoservidordehospedagem”;

        //string mysql rodando na maquina do desenvolvedor.
        private String stringconnection2 = "server=localhost;User Id=admin; password='';database=hexball";

        #region metodos que tentam abrir conexao com projeto rodando local ou hospedado
        public void tentarAbrirConexaoLocal()
        {
            objConexao = new MySqlConnection();
            objConexao.ConnectionString = stringconnection2;
            objConexao.Open();            
        }

        #endregion

        public ConexaoBancoMySQL()
        {

            try
            {
                tentarAbrirConexaoLocal();
            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");

                // Você pode substituir esta notificação por qualquer outra coisa que faça o mesmo que o metodo console.whiteline
            }

        }

        public static MySqlConnection getConexao()
        {
            new ConexaoBancoMySQL();
            return objConexao;
        }
        public static void fecharConexao()
        {
            objConexao.Close();
        }
    }
}
