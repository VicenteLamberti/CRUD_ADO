using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.CarrinhoDAL
{
    public class DeleteProdutoCarrinhoDAL:GenericaDAL
    {
       


        public void RemoverProdutoCarrinho(int idProduto)
        {
            var conexao = MetodoQueRetornaAConexao();

            string deleteQuery = $"DELETE FROM carrinho_produto WHERE id = (SELECT id FROM carrinho_produto WHERE id_produto = @idProd and id_usuario = 'vicente' LIMIT 1 )";

            using (conexao)
            {
                conexao.Open();

                using (var comando = new SqliteCommand(deleteQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@idProd", idProduto);
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
