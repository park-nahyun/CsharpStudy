﻿using System.Data;
using Npgsql;
using RoadBook.CsharpBasic.Chapter10.Examples.Model;

namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    public class PgSqlManager : IDatabaseManager
    {
        public void Open(DatabaseInfo dbInfo)
        {
            
        }

        public DataTable Select(string sql)
        {
            //TODO
            return new DataTable();
        }

        public int Insert(string sql)
        {
            //TODO
            return 0;
        }

        public int Update(string sql)
        {
            //TODO
            return 0;
        }

        public int Delete(string sql)
        {
            //TODO
            return 0;
        }

        public void Close()
        {
            //TODO
        }
    }
}