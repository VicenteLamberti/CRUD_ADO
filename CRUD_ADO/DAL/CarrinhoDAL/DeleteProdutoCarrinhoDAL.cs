using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.CarrinhoDAL
{
    public class DeleteProdutoCarrinhoDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            //return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
            return new SqliteConnection("Data Source=C:\\Users\\vicente_leonardo\\Desktop\\Cursos\\Projetos\\CRUD_ADO_GEO\\BANCO_CRUD_ADO.db");

        }


        public void RemoverProdutoCarrinho(int idProduto)
        {
            var conexao = MetodoQueRetornaAConexao();

            string deleteQuery = $"DELETE FROM carrinho_produto WHERE id_produto = @id and id_usuario = 'vicente'";

            using (conexao)
            {
                conexao.Open();

                using (var comando = new SqliteCommand(deleteQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@id", idProduto);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void RemoverTodosProdutosCarrinho()
        {
            var conexao = MetodoQueRetornaAConexao();
            ReadProdutoCarrinhoDAL readProdutoCarrinhoDAL = new ReadProdutoCarrinhoDAL();
            string idsQuerySemVirgulaNoFinal = readProdutoCarrinhoDAL.RetornarIdsDosProdutos();
            //string deleteQuery = $"DELETE FROM carrinho_produto WHERE id_produto IN (" + idsQuerySemVirgulaNoFinal + ")  AND id_usuario = 'vicente'";
            string deleteQuery = $"DELETE FROM carrinho_produto WHERE id_usuario = 'vicente' ";

            using (conexao)
            {
                conexao.Open();

                using (var comando = new SqliteCommand(deleteQuery, conexao))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
