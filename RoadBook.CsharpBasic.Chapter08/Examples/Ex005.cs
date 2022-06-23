using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex005
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
                try
                {
                    sw.WriteLine("[{0}] 데이터베이스 연결 시도...", DateTime.Now);
                    connection.Open();
                    sw.WriteLine("[{0}] 데이터베이스 연결 OK...", DateTime.Now);

                    Model.User user = SetUser(); // User 정보 입력 받는 메소드 실행
                    string insertSQL = string.Format("INSERT INTO TB_USER(ID, NAME, AGE, JOB) VALUES ('{0}','{1}','{2}','{3}')",
                        user.userID, user.Name, user.Age, user.Job); // User 모델 Insert


                    using (SqlCommand command = new SqlCommand(insertSQL, connection))
                    {
                        int activeNumber = command.ExecuteNonQuery();
                        sw.WriteLine("영향 받은 데이터 : " + activeNumber);
                    }


                    sw.WriteLine("[{0}] 데이터베이스 연결 끊기 시도...", DateTime.Now);
                    connection.Close();
                    sw.WriteLine("[{0}] 데이터베이스 연결 끊기 OK...", DateTime.Now);
                }
                catch (IOException e)
                {
                    Console.WriteLine("예외 발생");
                }
            }
        }

        private Model.User SetUser()
        { 
            Model.User user = new Model.User(); ;// User 모델 객체 생성

            bool validate = false;  // 플래그 f

            do // 아이디 등등 입력 받아서 User 모델에 넣기
            {
                Console.Write("신규 회원의 아이디를 입력하세요: ");
                user.userID = Console.ReadLine();
                Console.Write("신규 회원의 이름을 입력하세요: ");
                user.Name = Console.ReadLine();
                Console.Write("신규 회원의 나이를 입력하세요: ");
                user.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("신규 회원의 직업을 입력하세요: ");
                user.Job = Console.ReadLine();

                Console.WriteLine("신규 회원 : {0} / {1} / {2} / {3} 이 맞습니까? (y/n)", user.userID, user.Name, user.Age, user.Job);

                validate = Console.ReadLine().ToLower() != "y"; // 맞다고(y) 하면 validate true로 바꾸고 반복문 멈추기
            }while(validate);

            return user; // user return
        }

    }
}
