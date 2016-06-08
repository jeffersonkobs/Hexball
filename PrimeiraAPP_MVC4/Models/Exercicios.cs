using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PrimeiraAPP_MVC4.Models
{
    public class Exercicios
    {
        public List<ExerciciosModels> listaExercicios = new List<ExerciciosModels>();

        public Exercicios()
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            //MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT E.ID, E.CATEGORIA, E.DIFICULDADE, E.DESCRICAO, E.REPETICOES, E.TREINAMENTOS_ID, T.NOME as TREINAMENTOS_NOME FROM EXERCICIOS E, TREINAMENTOS T WHERE E.TREINAMENTOS_ID = T.ID";
            try
            {
                Conexao.Open();//Abre conexão
                MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

                ExerciciosModels Exercicios = new ExerciciosModels();//Estancia objeto do tipo usuário



                while (dtreader.Read())//Enquanto existir dados no select
                {
                    Exercicios.id = dtreader.GetInt32("id");
                    Exercicios.categoria = dtreader.GetInt32("categoria");
                    Exercicios.dificuldade = dtreader.GetInt32("dificuldade");
                    Exercicios.descricao = dtreader["descricao"].ToString();
                    Exercicios.repeticoes = dtreader.GetInt32("repeticoes");
                    Exercicios.treinamentos_id = dtreader.GetInt32("treinamentos_id");
                    Exercicios.treinamentos_nome = dtreader["treinamentos_nome"].ToString();

                    listaExercicios.Add(Exercicios);//Adiciona na lista um objeto do tipo cliente


                    //dtreader.NextResult();
                }
                Conexao.Close();//Fecha Conexao
            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }
        
        }
        public ExerciciosModels GetExercicios(int id)
        {
            //UsuarioModel _usuarioModel = null;
            ExerciciosModels _exerciciosModels = new ExerciciosModels();

            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT E.ID, E.CATEGORIA, E.DIFICULDADE, E.DESCRICAO, E.REPETICOES, E.TREINAMENTOS_ID, T.NOME as TREINAMENTOS_NOME FROM EXERCICIOS E, TREINAMENTOS T WHERE E.ID = " + id;

            Conexao.Open();//Abre conexão
            MySqlDataReader dtreader = Query.ExecuteReader();

            while (dtreader.Read())//Enquanto existir dados no select
            {
                _exerciciosModels.id = dtreader.GetInt32("id");
                _exerciciosModels.categoria = dtreader.GetInt32("categoria");
                _exerciciosModels.dificuldade = dtreader.GetInt32("dificuldade");
                _exerciciosModels.descricao = dtreader["descricao"].ToString();
                _exerciciosModels.repeticoes = dtreader.GetInt32("repeticoes");
                _exerciciosModels.treinamentos_id = dtreader.GetInt32("treinamentos_id");
                _exerciciosModels.treinamentos_nome = dtreader["treinamentos_nome"].ToString();
            }

            return _exerciciosModels;
        }
    }
}