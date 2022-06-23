using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoadBook.CsharpBasic.Chapter10.Examples.Model;
using System.Data.SqlClient;

// MS-SQL 데이터베이스를 관리하는 매니저 만들기

namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    internal class MsSqlManager : IDatabaseManager // IDatabaseManager 인터페이스를 참조한다 = 약속된 메소드 Open ~ Close를 구현해야 한다.
    {
        SqlConnection connection = null;

        public void Open(DatabaseInfo dbInfo)
        {
            string conStr = string.Format("Data Source={0},{1}; Initial Catalog={2};User ID={3};Password={4}",
                dbInfo.Ip, dbInfo.Port, dbInfo.Name, dbInfo.UserId, dbInfo.UserPassword);
            connection = new SqlConnection(conStr);
            connection.Open();
        }

        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                for (int idx = 0; idx < reader.FieldCount; idx++)
                { 
                    dt.Columns.Add(new DataColumn(reader.GetName(idx)));
                }

                while (reader.Read())
                {
                    DataRow row = dt.NewRow();

                    for (int idx = 0; idx < dt.Columns.Count; idx++)
                    { 
                        row[dt.Columns[idx].ColumnName] = dt.Columns[idx].ColumnName;
                    }
                    dt.Rows.Add(row);
                }
            }
        }
        return dt;
    }
}
