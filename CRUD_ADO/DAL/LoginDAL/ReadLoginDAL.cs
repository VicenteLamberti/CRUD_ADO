using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.LoginDAL
{
    public class ReadLoginDAL: GenericaDAL
    {
       


        public bool VerificarSeExisteUsuarioNoBanco(UserModel userModel)
        {
            var conexao = MetodoQueRetornaAConexao();
            bool existeUsuario;

            string selectQuery = $"SELECT * FROM user WHERE user_name = @userName AND password = @pass";
            using (conexao)
            {
                conexao.Open();
                using(SqliteCommand comando = new SqliteCommand(selectQuery,conexao))
                {
                    comando.Parameters.AddWithValue("@userName", userModel.UserName);
                    comando.Parameters.AddWithValue("@pass", userModel.Password);

                    var reader = comando.ExecuteReader();
                    existeUsuario = reader.HasRows;
                    
                }
            }
            return existeUsuario;
        }

        public UserModel GetUser (string userName)
        {
            var conexao = MetodoQueRetornaAConexao();

            UserModel user = new UserModel();
            string selectQuery = $"SELECT * FROM user WHERE user_name = @userName";
            using (conexao)
            {
                conexao.Open();
                using (SqliteCommand comando = new SqliteCommand(selectQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@userName", userName);

                    var reader = comando.ExecuteReader();
                    if(reader.HasRows)
                    {
                        reader.Read();
                        user.UserName = reader["user_name"].ToString();
                        user.Permissao = reader["permissao"].ToString();
                    }
                    else
                    {
                        //colocar validacao
                    }
                   

                }
            }
            return user;
        }


        public bool GetUserPorEmail(string email)
        {
            var conexao = MetodoQueRetornaAConexao();
            bool existeUsuario;
            UserModel user = new UserModel();
            string selectQuery = $"SELECT * FROM user WHERE email = @email";
            using (conexao)
            {
                conexao.Open();
                using (SqliteCommand comando = new SqliteCommand(selectQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@email", email);

                    var reader = comando.ExecuteReader();
                    existeUsuario = reader.HasRows;


                }
            }
            return existeUsuario;
        }



    }
}


