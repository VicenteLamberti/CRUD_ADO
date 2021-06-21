using Microsoft.Data.Sqlite;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_VICENTE.DAL
{
    public class GenericaDAL
    {
        private SqliteConnection MetodoQueRetornaAConexao()
        {
            return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
        }


        


    }
}
