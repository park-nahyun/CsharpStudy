using System;
using System.IO;
using System.Data.SqlClient;
// 데이터베이스에 접근하기
// 필요한 정보 : ip, port, 어떤DB?, 계정 정보
// 연결 객체를 사용하기 위해서는 SqlConnection 사용해야 함.
namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex004
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;
        private readonly string connectionStr = string.Format("Data Source={0},{1};Initial Catalog={2};User ID={3};" +
            "Password={4}", "192.168.1.152", 1433, "testdb", "sa", "Arisys123$");

        public void Run()
        {
            CheckedDirectory();
            TryConnectToDatabase();
        }

        private void CheckedDirectory() // 데이터 접속 기록을 파일로 남기기 위한 디렉토리 경로 설정 및 존재 여부를 판단.
        { 
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory + @"\data");
            
            if (!directoryInfo.Exists) { directoryInfo.Create(); }
        }

        private void TryConnectToDatabase() // SqlConnection 객체를 이용한 데이터베이스 접근시도에 대한 기록을 StreamWriter 클래스를 이용하여 파일로 남김
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            string fileName = string.Format(@"\data\db{0}.log", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));

            using (StreamWriter sw = new StreamWriter(currentDirectory + fileName, true))
            {
                sw.WriteLine("[{0}] 데이터베이스 연결 시도...", DateTime.Now);
                connection.Open();
                sw.WriteLine("[{0}] 데이터베이스 연결 OK...", DateTime.Now);

                sw.WriteLine("[{0}] 데이터베이스 연결 끊기 시도...", DateTime.Now);
                connection.Close();
                sw.WriteLine("[{0}] 데이터베이스 연결 끊기 OK...", DateTime.Now);
            }
        }

    }
}
