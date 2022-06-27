using System.Data;
using System.Data.SqlClient;
using RoadBook.CsharpBasic.Chapter10.Examples.Model;

namespace RoadBook.CsharpBasic.Chapter10.Examples.Manager
{
    public class MsSqlManager : IDatabaseManager
    {
        SqlConnection connection = null;

        // DB 접속 정보를 매핑 시킨 후, SqlConnection 객체를 오픈한다.
        public void Open(DatabaseInfo dbInfo)
        {
            string conStr = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};Password={4}",
                                    dbInfo.Ip,
                                    dbInfo.Port,
                                    dbInfo.Name,
                                    dbInfo.UserId,
                                    dbInfo.UserPassword);

            connection = new SqlConnection(conStr);
            connection.Open();
        }


        // sql 문자열을 매개변수로 받아, SqlCommend, SqlDataReatder 객체 생성 및 조회를 하여
        // DataTable 객체에 조회된 데이터를 집어넣은 후 리턴 해주는 역할
        public DataTable Select(string sql)
        {

            // 여러가지 변수 값 혹은 리스트들을 형식에 맞춰 규격화하여 보관할 수 있는 기능을 제공
            DataTable dt = new DataTable();

            using (SqlCommand command = new SqlCommand(sql, connection)) // SqlCommand 객체를 'sql 쿼리문'과 'SqlConnection 객체(DB에 접근하여 오픈되어 있는 객체)'를 넘겨서 만들어 준다.
            {
                using (SqlDataReader reader = command.ExecuteReader()) // SQL 쿼리문 결과를 ExecuteReader() 메소드를 이용하여 SqlDataReader 객체에 담아낸다.
                {
                    for (int idx = 0; idx < reader.FieldCount; idx++) // SqlDataReader에 담긴 필드 개수만큼 반복문을 돌려서 
                    {
                        dt.Columns.Add(new DataColumn(reader.GetName(idx))); // DataTable 객체에 새로운 DataColumn을 추가한다.
                    }

                    while (reader.Read())
                    {
                        DataRow row = dt.NewRow();

                        for (int idx = 0; idx < dt.Columns.Count; idx++)
                        {
                            row[dt.Columns[idx]] = reader[dt.Columns[idx].ColumnName];
                        }

                        /* 
                         만약 SQL Query가,
                        SELECT 컬럼1, 컬럼2.. 컬럼3 FROM TB_1 일 경우, 10번의 반복문을 거쳐,
                        10개의 DataColumn이 DataTable에 추가될 것이다.
                         */
                        dt.Rows.Add(row);
                    }
                }
            }

            return dt;
        }

        public int Insert(string sql)
        {
            int activeNumber = 0;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }

        public int Update(string sql)
        {
            int activeNumber = 0;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }

        public int Delete(string sql)
        {
            int activeNumber = 0;

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                activeNumber = command.ExecuteNonQuery();
            }

            return activeNumber;
        }

        public void Close()
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}



