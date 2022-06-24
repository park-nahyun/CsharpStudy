`using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


// 데이터 삭제 

namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex008
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;
        private readonly string connectionStr = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};" +
            "Password={4}", "192.168.1.152", 1433, "testdb", "sa", "Arisys123$");

        public void Run()
        {
            CheckedDirectory();
            TryConnectToDatabase();
        }

        private void CheckedDirectory()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory + @"\data");

            if (!directoryInfo.Exists) { directoryInfo.Create(); }
        }

        private void TryConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            string fileName = string.Format(@"\data\db{0}.log", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));

            using (StreamWriter sw = new StreamWriter(currentDirectory + fileName, true))
            {
                sw.WriteLine("[{0}] 데이터베이스 연결 시도...", DateTime.Now);
                connection.Open();
                sw.WriteLine("[{0}] 데이터베이스 연결 OK...", DateTime.Now);

                Console.Write("삭제 할 유저의 아이디를 입력하세요: ");
                string userID = Console.ReadLine();
                string deleteSQL = string.Format(" DELETE FROM TB_USER WHERE ID = '{0}' ", userID);

                using (SqlCommand command = new SqlCommand()) // 아무런 데이터를 넘겨주지 않고, 빈 껍데기의 객체를 생성한 후에,
                {
                    command.Connection = connection;         // 속성을 설정해주는 방식으로 변경
                    command.CommandText = deleteSQL;
                    int activeNumber = command.ExecuteNonQuery();


                    sw.WriteLine("영향 받은 데이터 : " + activeNumber);
                }


                sw.WriteLine("[{0}] 데이터베이스 연결 끊기 시도...", DateTime.Now);
                connection.Close();
                sw.WriteLine("[{0}] 데이터베이스 연결 끊기 OK...", DateTime.Now);
            }
        }
    }
}
