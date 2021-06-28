using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.CarrinhoDAL
{
    public class InsertProdutoCarrinhoDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            //return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
            return new SqliteConnection("Data Source=C:\\Users\\vicente_leonardo\\Desktop\\Cursos\\Projetos\\CRUD_ADO_GEO\\BANCO_CRUD_ADO.db");

        }


       public void InsertProdutoCarrinho(int id, string usuario)
        {
            var conexao = MetodoQueRetornaAConexao();
            string inserirProdutoCarrinhoQuery = $"INSERT INTO carrinho_produto (id_produto, id_usuario) VALUES (@id, @usuario)";
            using(conexao)
            {
                conexao.Open();
                using(var comando = new SqliteCommand(inserirProdutoCarrinhoQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    comando.ExecuteNonQuery();

                }
            }
        }
    }
}
