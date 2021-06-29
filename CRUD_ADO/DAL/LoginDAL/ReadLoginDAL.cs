using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.LoginDAL
{
    public class ReadLoginDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            //return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
            return new SqliteConnection("Data Source=C:\\Users\\vicente_leonardo\\Desktop\\Cursos\\Projetos\\CRUD_ADO_GEO\\BANCO_CRUD_ADO.db");

        }


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

    }
}




