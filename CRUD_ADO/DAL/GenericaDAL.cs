using Microsoft.Data.Sqlite;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.DAL
{
    public class GenericaDAL
    {
        public SqliteConnection MetodoQueRetornaAConexao()
        {
            //return new SqliteConnection("Data Source=E:\\DEV\\PROJETOS\\CRUD_ADO\\BANCO_CRUD_ADO.db");
            return new SqliteConnection("Data Source=C:\\Users\\vicente_leonardo\\Desktop\\Cursos\\Projetos\\CRUD_ADO_GEO\\BANCO_CRUD_ADO.db");

        }


      


    }
}
