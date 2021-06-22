using CRUD_VICENTE.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.ProdutoDAL
{
    public class DeleteProdutoDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
        }

        public ProdutoModel DeletarProduto(int id)
        {
            ReadProdutoDAL readDAL = new ReadProdutoDAL();
            return readDAL.listarPorId(id);
        }


        public void DeletarProdutoEfetivamente(ProdutoModel produto)
        {
            var conexao = MetodoQueRetornaAConexao();

            string deleteQuery = $"DELETE FROM produto WHERE id = @id";

            using (conexao)
            {
                conexao.Open();

                using (var comando = new SqliteCommand(deleteQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@id", produto.Id);
                    comando.ExecuteNonQuery();
                }
            }
        }

    }
}
