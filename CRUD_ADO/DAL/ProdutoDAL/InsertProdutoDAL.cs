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
            //return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
            return new SqliteConnection("Data Source=C:\\Users\\vicente_leonardo\\Desktop\\Cursos\\Projetos\\CRUD_ADO_GEO\\BANCO_CRUD_ADO.db");

        }









        public void InserirProduto(ProdutoModel produto)
        {
            var conexao = MetodoQueRetornaAConexao();
            string inserirQuery = $"INSERT INTO produto (nome_produto, quantidade ,preco) VALUES (@nomeProduto,@quantidadeProduto, @precoProduto)";
            using (conexao)
            {
                conexao.Open();
                using (var comando = new SqliteCommand(inserirQuery, conexao))
                {
                    comando.Parameters.AddWithValue("@nomeProduto", produto.NomeProduto.ToUpper());
                    comando.Parameters.AddWithValue("@precoProduto", produto.Preco);
                    comando.Parameters.AddWithValue("@quantidadeProduto", produto.Quantidade);
                    comando.ExecuteNonQuery();
                }
            }
        }



    }
}




