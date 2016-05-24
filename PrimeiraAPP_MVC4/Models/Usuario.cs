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
            string CONFIG = ("Persist Security Info=False;server=localhost;database=projetoteste;uid=root;pwd=''");
            MySqlConnection Conexao = new MySqlConnection(CONFIG);
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
                    Usuario.nome = dtreader["nome"].ToString();
                    Usuario.sobrenome = dtreader["sobrenome"].ToString();
                    Usuario.endereco = dtreader["endereco"].ToString();
                    Usuario.email = dtreader["email"].ToString();
                    //Usuario.nascimento = Convert.ToDateTime(dtreader["nascimento"].ToString());

                    listaUsuarios.Add(Usuario);//Adiciona na lista um objeto do tipo cliente
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
            listaUsuarios.Add(usuarioModelo);
        }

        public void AtualizaUsuario(UsuarioModel usuarioModelo)
        {
            foreach (UsuarioModel usuario in listaUsuarios)
            {
                if (usuario.email == usuarioModelo.email)
                {
                    listaUsuarios.Remove(usuario);
                    listaUsuarios.Add(usuarioModelo);
                    break;
                }
            }
        }
        public UsuarioModel GetUsuario(string Email)
        {
            UsuarioModel _usuarioModel = null;

            foreach (UsuarioModel _usuario in listaUsuarios)
                if (_usuario.email == Email)
                    _usuarioModel = _usuario;

            return _usuarioModel;
        }

        public void DeletarUsuario(String Email)
        {
            foreach (UsuarioModel _usuario in listaUsuarios)
            {
                if (_usuario.email == Email)
                {
                    listaUsuarios.Remove(_usuario);

                    break;
                }
            }
        }
    }
}