using CRUD_VICENTE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_VICENTE.DAL
{


    public class ProdutoDAL
    {

        private SqliteConnection MetodoQueRetornaAConexao()
        {
            return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
        }


        public List<ProdutoModel> listarTodos()
        {
            var conexao = MetodoQueRetornaAConexao();

            var listaQueSeraORetorno = new List<ProdutoModel>();


            string selectQuery = $"SELECT * FROM produto";
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


       






        public ProdutoModel listarPorId(int id)
        {
            var conexao = MetodoQueRetornaAConexao();
            ProdutoModel objetoQueSeraRetornado = null;
            string listarPorIdQuery = $"SELECT * FROM produto WHERE id = @id";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(listarPorIdQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        objetoQueSeraRetornado = new ProdutoModel
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            NomeProduto = reader["nome_produto"].ToString(),
                            Preco = Convert.ToDouble(reader["preco"])
                        };
                    }

                }
            }
            return objetoQueSeraRetornado;
        }


        public ProdutoModel DeletarProduto(int id)
        {
            return listarPorId(id);
        }


        public void InserirProduto(ProdutoModel produto)
        {
            var conexao = MetodoQueRetornaAConexao();
            string inserirQuery = $"INSERT INTO produto (nome_produto, preco) VALUES (@nomeProduto, @precoProduto)";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(inserirQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto);
                    comando.Parameters.AddWithValue("@precoProduto", produto.Preco);
                    comando.ExecuteNonQuery();
                }
            }
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


        public void EditarProduto(ProdutoModel prod)
        {
            var conexao = MetodoQueRetornaAConexao();
            string editQuery = $"UPDATE produto SET nome_produto = @nomeProduto, preco = @precoProduto WHERE id = @id";
            using (conexao)
            {
                conexao.Open();
                using(var comando = new SqliteCommand(editQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeProduto", prod.NomeProduto);
                    comando.Parameters.AddWithValue("@precoProduto", prod.Preco);
                    comando.Parameters.AddWithValue("@id", prod.Id);
                    comando.ExecuteNonQuery();

                }

            }

        }







    }
}
