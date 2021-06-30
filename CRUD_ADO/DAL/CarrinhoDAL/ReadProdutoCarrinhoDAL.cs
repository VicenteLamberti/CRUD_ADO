using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.CarrinhoDAL
{
    public class ReadProdutoCarrinhoDAL:GenericaDAL
    {
        



        public List<ProdutoCarrinhoModel> ObterIdsProdutos()
        {
            var conexao = MetodoQueRetornaAConexao();

            var listaQueSeraORetorno = new List<ProdutoCarrinhoModel>();


            string selectQuery = $"SELECT * FROM carrinho_produto WHERE id_usuario = 'vicente' ";
            using (conexao)
            {
                conexao.Open();

                using (SqliteCommand comando = new SqliteCommand(selectQuery, conexao))
                {
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ProdutoCarrinhoModel ItemDaListaProduto = new ProdutoCarrinhoModel
                        {
                            IdProduto = Convert.ToInt32(reader["id_produto"])
                        };
                        listaQueSeraORetorno.Add(ItemDaListaProduto);
                    }

                }
            }

            return listaQueSeraORetorno;
        }


        public List<ProdutoModel> GerarListaProdutosCarrinho()
        {
            var conexao = MetodoQueRetornaAConexao();

            string idsQuerySemVirgulaNoFinal = RetornarIdsDosProdutos();




            List<ProdutoModel> listaQueSeraORetorno = new List<ProdutoModel>();


            string selectQuery = $"SELECT * FROM produto p INNER JOIN carrinho_produto c ON p.id == c.id_produto WHERE id_usuario = 'vicente' ";
            using (conexao)
            {
                conexao.Open();

                using (SqliteCommand comando = new SqliteCommand(selectQuery, conexao))
                {

                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ProdutoModel ItemDaListaProduto = new ProdutoModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            NomeProduto = reader["nome_produto"].ToString(),
                            Preco = Convert.ToDouble(reader["preco"])
                        };
                        listaQueSeraORetorno.Add(ItemDaListaProduto);
                    }

                }
            }

            return listaQueSeraORetorno;
        }


        public string RetornarIdsDosProdutos()
        {
            List<string> idsProdutos = new List<string>();

            string idsQueryComVirgulaNoFinal = "";

            var produtos = ObterIdsProdutos();

            foreach (var produto in produtos)
            {
                idsProdutos.Add(produto.IdProduto.ToString());
            }


            foreach (var id in idsProdutos)
            {
                idsQueryComVirgulaNoFinal += id;
                idsQueryComVirgulaNoFinal += ",";
            }

            string idsQuerySemVirgulaNoFinal = "";
            if (String.IsNullOrEmpty(idsQueryComVirgulaNoFinal))
            {
                idsQuerySemVirgulaNoFinal = "0";
            }
            else
            {
                idsQuerySemVirgulaNoFinal = idsQueryComVirgulaNoFinal.Substring(0, idsQueryComVirgulaNoFinal.Length - 1);
            }

            return idsQuerySemVirgulaNoFinal;
        }

    }
}
