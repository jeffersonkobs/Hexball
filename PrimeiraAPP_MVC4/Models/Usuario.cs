using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace PrimeiraAPP_MVC4.Models
{
    public class Usuario
    {
        public List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        public Usuario()
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            //MySqlConnection Conexao = ConexaoBancoMySQL.getConexao();
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT * FROM USUARIOS";
            try
            {
                Conexao.Open();//Abre conexão
                MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

                UsuarioModel Usuario = new UsuarioModel();//Estancia objeto do tipo usuário

                

                while (dtreader.Read())//Enquanto existir dados no select
                {
                    Usuario.id = dtreader.GetInt32("id");
                    Usuario.nome = dtreader["nome"].ToString();
                    Usuario.sobrenome = dtreader["sobrenome"].ToString();
                    Usuario.endereco = dtreader["endereco"].ToString();
                    Usuario.email = dtreader["email"].ToString();
                    Usuario.nascimento = Convert.ToDateTime(dtreader["nascimento"].ToString());
                    

                    listaUsuarios.Add(Usuario);//Adiciona na lista um objeto do tipo cliente


                    //dtreader.NextResult();
                }
                Conexao.Close();//Fecha Conexao
            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }
            
        }
        public void CriaUsuario(UsuarioModel usuarioModelo)
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"insert into usuarios(nome, sobrenome, endereco, email, nascimento) 
                                  values('" + usuarioModelo.nome + "','" + usuarioModelo.sobrenome + "','" + usuarioModelo.endereco + "','" + usuarioModelo.email + "', str_to_date('" + usuarioModelo.nascimento + "','dd/MM/yyyy hh:mm:ss'));";
            try
            {
                Conexao.Open();//Abre conexão
                Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }
        }

        public void AlteraUsuario(UsuarioModel usuarioModelo)
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"update usuarios set nome = '" + usuarioModelo.nome + "', sobrenome = '" + usuarioModelo.sobrenome + "', endereco = '" + usuarioModelo.endereco + "', email = '" + usuarioModelo.email + "' where id = " + usuarioModelo.id;

//                                  values('" + usuarioModelo.nome + "','" + usuarioModelo.sobrenome + "','" + usuarioModelo.endereco + "','" + usuarioModelo.email + "', str_to_date('" + usuarioModelo.nascimento + "','dd/MM/yyyy hh:mm:ss'));";
            try
            {
                Conexao.Open();//Abre conexão
                MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }
        }
        public UsuarioModel GetUsuario(int id)
        {
            //UsuarioModel _usuarioModel = null;
            UsuarioModel _usuarioModel = new UsuarioModel();

            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"SELECT * FROM USUARIOS WHERE ID = " + id;

            Conexao.Open();//Abre conexão
            MySqlDataReader dtreader = Query.ExecuteReader();

            while (dtreader.Read())//Enquanto existir dados no select
            {
                _usuarioModel.id = dtreader.GetInt32("id");
                _usuarioModel.nome = dtreader["nome"].ToString();
                _usuarioModel.sobrenome = dtreader["sobrenome"].ToString();
                _usuarioModel.endereco = dtreader["endereco"].ToString();
                _usuarioModel.email = dtreader["email"].ToString();
                _usuarioModel.nascimento = Convert.ToDateTime(dtreader["nascimento"].ToString());
            }

            return _usuarioModel;
        }

        public void DeletarUsuario(UsuarioModel usuarioModelo)
        {
            string CONFIG = ("Persist Security Info=False;server=localhost;database=hexball;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
            MySqlCommand Query = new MySqlCommand();
            Query.Connection = Conexao;
            Query.CommandText = @"delete from usuarios where id = '" + usuarioModelo.id;

            try
            {
                Conexao.Open();//Abre conexão
                MySqlDataReader dtreader = Query.ExecuteReader();//Crie um objeto do tipo reader para ler os dados do banco

            }
            catch
            {
                Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");
            }
        }
    }
}