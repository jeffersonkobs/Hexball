using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PrimeiraAPP_MVC4.Models
{
    public class Treinamentos
    {
        public List<TreinamentosModels> listaTreinamentos = new List<TreinamentosModels>();

        public Treinamentos()
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            //MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT T.ID, T.ATLETAS_ID, A.NOME as ATLETAS_NOME, T.DATA_HORA, T.NOME FROM TREINAMENTOS T, ATLETAS A WHERE T.ATLETAS_ID = A.ID";
            try
            {
                Conexao.Open();//Abre conexão
                MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

                TreinamentosModels Treinamentos = new TreinamentosModels();//Estancia objeto do tipo usuário



                while (dtreader.Read())//Enquanto existir dados no select
                {
                    Treinamentos.id = dtreader.GetInt32("id");
                    Treinamentos.nome = dtreader["nome"].ToString();
                    Treinamentos.atletas_id = dtreader.GetInt32("atletas_id");
                    Treinamentos.atletas_nome = dtreader["atletas_nome"].ToString();
                    Treinamentos.data_hora = Convert.ToDateTime(dtreader["data_hora"].ToString());

                    listaTreinamentos.Add(Treinamentos);//Adiciona na lista um objeto do tipo cliente


                    //dtreader.NextResult();
                }
                Conexao.Close();//Fecha Conexao
            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }

        }
        public TreinamentosModels GetTreinamentos(int id)
        {
            //UsuarioModel _usuarioModel = null;
            TreinamentosModels _treinamentosModels = new TreinamentosModels();

            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT T.ID, T.ATLETAS_ID, A.NOME as ATLETAS_NOME, T.DATA_HORA, T.NOME FROM TREINAMENTOS T, ATLETAS A WHERE T.ATLETAS_ID = A.ID AND T.ID = " + id;

            Conexao.Open();//Abre conexão
            MySqlDataReader dtreader = Query.ExecuteReader();

            while (dtreader.Read())//Enquanto existir dados no select teste
            {
                _treinamentosModels.id = dtreader.GetInt32("id");
                _treinamentosModels.nome = dtreader["nome"].ToString();
                _treinamentosModels.atletas_id = dtreader.GetInt32("atletas_id");
                _treinamentosModels.atletas_nome = dtreader["atletas_nome"].ToString();
                _treinamentosModels.data_hora = Convert.ToDateTime(dtreader["data_hora"].ToString());
            }

            return _treinamentosModels;
        }
    }
}