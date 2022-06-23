using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

// 데이터 조회하기

namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex006
    {
        private readonly string connectionStr = string.Format("Data Source ={0},{1};Initial Catalog={2};User ID={3};" +
            "Password={4}", "192.168.1.152", 1433, "testdb", "sa", "Arisys123$");

        public void Run()
        {
            string selectSQL = "SELECT ID, NAME, AGE, JOB FROM TB_USER";

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectSQL, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    /*
                    ExecuteReader() 메소드의 리턴형은 SqlDataReader라는 '객체'
                    SqlDataReader 객체는 질의된 데이터 정보를 가지게 된다.
                     */

                    while (reader.Read())   // SqlDataReader에 담긴 데이터를 한 줄씩 꺼내온다.
                                            // 한줄씩 꺼내오면서 데이터가 있는 경우 true, 없는 경우 false 반환
                    { 
                        Console.WriteLine("회원ID : {0}", reader["ID"]);
                        Console.WriteLine("회원이름 : {0}", reader["NAME"]);
                        Console.WriteLine("회원나이 : {0}", reader["AGE"]);
                        Console.WriteLine("회원직업 : {0}", reader["JOB"]); // ["컬럼명"] or [인덱스]
                        Console.WriteLine("=====");
                    }
                }

                connection.Close();
            }
        }
    }
}
