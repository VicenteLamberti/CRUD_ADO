using CRUD_ADO.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.ProdutoDAL
{
    public class ReadProdutoDAL : GenericaDAL
    {

       







        public List<ProdutoModel> ListarTodos()
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
                            Quantidade = Convert.ToInt32(reader["quantidade"]),
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
                            Quantidade = Convert.ToInt32(reader["quantidade"]),
                            Preco = Convert.ToDouble(reader["preco"])
                        };
                    }

                }
            }
            return objetoQueSeraRetornado;
        }


    }
}
