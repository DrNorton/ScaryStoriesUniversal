﻿using System.Threading.Tasks;
using ScaryStoriesUniversal.Database.Entities;
using SQLite;

namespace ScaryStoriesUniversal.Database.DataAccess
{
    public class DbConnection : IDbConnection
    {
        string dbPath;
        SQLiteAsyncConnection conn;        

        public DbConnection(string path)
        {
            conn = new SQLiteAsyncConnection(path);
        }

        public async Task InitializeDatabase()
        {
          await  conn.CreateTableAsync<Category>();
           await conn.CreateTableAsync<Source>();
           await conn.CreateTableAsync<Story>();
           await conn.CreateTableAsync<History>();
        }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            return conn;
        }
    }
}
