using CRUD_ADO.DAL.CarrinhoDAL;
using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.ProdutoDAL
{
    public class UpdateProdutoDAL : GenericaDAL
    {
        

        public void EditarProduto(ProdutoModel prod)
        {
            var conexao = MetodoQueRetornaAConexao();
            string editQuery = $"UPDATE produto SET nome_produto = @nomeProduto, preco = @precoProduto WHERE id = @id";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(editQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeProduto", prod.NomeProduto.ToUpper());
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
            string[] arridsQuerySemVirgulaNoFinal = idsQuerySemVirgulaNoFinal.Split(',');
            foreach(string ids in arridsQuerySemVirgulaNoFinal)
            {
                string editQuery = $"UPDATE produto SET quantidade = (SELECT quantidade FROM produto WHERE id ={ids})-1 WHERE id = {ids}";
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
}
