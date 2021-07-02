using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.LoginDAL
{
    public class UpdateLoginDAL : GenericaDAL
    {
        public void AlterarUsuario(UserModel userModel)
        {
            var conexao = MetodoQueRetornaAConexao();
            string editQuery = $"UPDATE produto SET user_name = @user, password = @pass, email= @e-mail WHERE user_name = @user";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(editQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@user", userModel.UserName);
                    comando.Parameters.AddWithValue("@pass", userModel.Password);
                    comando.Parameters.AddWithValue("@e-mail", userModel.Email);
                    comando.ExecuteNonQuery();
                }
            }

        }
    }
}
