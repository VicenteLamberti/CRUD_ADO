using CRUD_VICENTE.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL.ProdutoDAL
{
    public class InsertProdutoDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
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



    }
}




