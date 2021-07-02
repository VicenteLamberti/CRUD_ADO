using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.LoginDAL
{
    public class InsertLoginDAL : GenericaDAL
    {
        public void CriarNovoUsuario(UserModel userModel)
        {
            var conexao = MetodoQueRetornaAConexao();

            string inserirQuery = $"INSERT INTO user (user_name,password,email) VALUES (@user, @password,@email)";
            using (conexao)
            {
                conexao.Open();
                using(var comando = new SqliteCommand(inserirQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@user", userModel.UserName);
                    comando.Parameters.AddWithValue("@password", userModel.Password);
                    comando.Parameters.AddWithValue("@email", userModel.Email);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
