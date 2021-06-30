using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.ProdutoDAL
{
    public class DeleteProdutoDAL : GenericaDAL
    {
       


        public void DeletarProdutoEfetivamente(int id)
        {
            var conexao = MetodoQueRetornaAConexao();

            string deleteQuery = $"DELETE FROM produto WHERE id = @id";

            using (conexao)
            {
                conexao.Open();

                using (var comando = new SqliteCommand(deleteQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
        }

    }
}
