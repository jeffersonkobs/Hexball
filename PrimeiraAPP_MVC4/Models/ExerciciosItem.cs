using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PrimeiraAPP_MVC4.Models
{
    public class ExerciciosItem
    {
        public List<ExerciciosItemModels> listaExerciciosItem = new List<ExerciciosItemModels>();

        public ExerciciosItem()
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            //MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT EI.ID, EI.EXERCICIOS_ID, EI.EXERCICIOS_TIPO_ID, ET.NOME AS EXERCICIOS_TIPO_NOME, EI.LADO_LANCADOR, EI.QUADRANTE, EI.SEQUENCIA FROM EXERCICIOS_ITEM EI, EXERCICIOS_TIPO ET WHERE EI.EXERCICIOS_TIPO_ID = ET.ID";
            try
            {
                Conexao.Open();//Abre conexão
                MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

                ExerciciosItemModels ExerciciosItem = new ExerciciosItemModels();//Estancia objeto do tipo usuário

                while (dtreader.Read())//Enquanto existir dados no select
                {
                    ExerciciosItem.id = dtreader.GetInt32("id");
                    ExerciciosItem.exercicios_tipo_id = dtreader.GetInt32("exercicios_tipo_id");
                    ExerciciosItem.exercicios_id = dtreader.GetInt32("exercicios_id");
                    ExerciciosItem.exercicios_tipo_nome = dtreader["exercicios_tipo_nome"].ToString();
                    ExerciciosItem.lado_lancador = dtreader.GetInt32("lado_lancador");
                    ExerciciosItem.quadrante = dtreader.GetInt32("quadrante");
                    ExerciciosItem.sequencia= dtreader.GetInt32("sequencia");

                    listaExerciciosItem.Add(ExerciciosItem);//Adiciona na lista um objeto do tipo cliente


                    //dtreader.NextResult();
                }
                Conexao.Close();//Fecha Conexao
            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }

        }
    }
}