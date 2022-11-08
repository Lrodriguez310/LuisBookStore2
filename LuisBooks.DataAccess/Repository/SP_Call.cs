using Dapper;
using LuisBooks.DataAccess.Repository.IRepository;
using LuisBookStore.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace LuisBooks.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        // Access the Database
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = ""; // this is needed to call the stored procedures

        //Constructor to open Sql Database

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            // throw new NotImplementedException();

            _db.Dispose();
        }

        public void Execute(string procedurename, DynamicParameters param = null)
        {
            //throw new NotImplementedException();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString)){
                sqlCon.Open();
                sqlCon.Execute(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null)
        {
            //throw new NotImplementedException();
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T OneRecord<T>(string procedurename, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }

        public T Single<T>(string procedurename, DynamicParameters param = null)
        {
            throw new NotImplementedException();
        }
    }
}
