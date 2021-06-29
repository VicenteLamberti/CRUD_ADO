using CRUD_ADO.DAL.CarrinhoDAL;
using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.ProdutoDAL
{
    public class UpdateProdutoDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            //return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
            return new SqliteConnection("Data Source=C:\\Users\\vicente_leonardo\\Desktop\\Cursos\\Projetos\\CRUD_ADO_GEO\\BANCO_CRUD_ADO.db");

        }

        public void EditarProduto(ProdutoModel prod)
        {
            var conexao = MetodoQueRetornaAConexao();
            string editQuery = $"UPDATE produto SET nome_produto = @nomeProduto, preco = @precoProduto WHERE id = @id";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(editQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeProduto", prod.NomeProduto);
                    comando.Parameters.AddWithValue("@precoProduto", prod.Preco);
                    comando.Parameters.AddWithValue("@id", prod.Id);
                    comando.ExecuteNonQuery();
                }
            }

        }

        public void AtualizarQuantidadeProdutos()
        {
            var conexao = MetodoQueRetornaAConexao();
            ReadProdutoCarrinhoDAL readCarrinhoDAL = new ReadProdutoCarrinhoDAL();
            string idsQuerySemVirgulaNoFinal = readCarrinhoDAL.RetornarIdsDosProdutos();

            string editQuery = $"UPDATE produto SET quantidade = ( (SELECT quantidade FROM produto WHERE id IN (" + idsQuerySemVirgulaNoFinal + ")) -1 ) WHERE id IN (" + idsQuerySemVirgulaNoFinal + ")";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(editQuery, conexao))
                {
                    comando.ExecuteNonQuery();
                }
            }
        }



    }
}
