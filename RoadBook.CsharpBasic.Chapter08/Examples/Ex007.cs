using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;


// 데이터 수정

namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex007
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

                Model.User user = SetUser();
                string updateSQL = string.Format("UPDATE TB_USER SET NAME='{0}', Age='{1}', Job='{2}' WHERE ID='{3}' "
                    , user.Name, user.Age, user.Job, user.userID);

                using (SqlCommand command = new SqlCommand()) // 아무런 데이터를 넘겨주지 않고, 빈 껍데기의 객체를 생성한 후에,
                {
                    command.Connection = connection;         // 속성을 설정해주는 방식으로 변경
                    command.CommandText = updateSQL;
                    int activeNumber = command.ExecuteNonQuery();

                    // INSERT/UPDATE/DELETE/SELECT문을 여러가지 다중으로 사용하는 경우에는
                    // 빈 껍데기의 객체로 시작해서 속성을 변경해주는 방식으로 코드를 작성하는 것이 간결한 코드가 된다. 

                    sw.WriteLine("영향 받은 데이터 : " + activeNumber);
                }

                
                sw.WriteLine("[{0}] 데이터베이스 연결 끊기 시도...", DateTime.Now);
                connection.Close();
                sw.WriteLine("[{0}] 데이터베이스 연결 끊기 OK...", DateTime.Now);
            }
        }

        private Model.User SetUser()
        {
            Model.User user = new Model.User(); ;// User 모델 객체 생성

            bool validate = false;  // 플래그 f

            do // 아이디 등등 입력 받아서 User 모델에 넣기
            {
                Console.Write("정보 수정 할 회원의 아이디를 입력하세요: ");
                user.userID = Console.ReadLine();
                Console.Write("회원의 이름을 입력하세요: ");
                user.Name = Console.ReadLine();
                Console.Write("회원의 나이를 입력하세요: ");
                user.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("회원의 직업을 입력하세요: ");
                user.Job = Console.ReadLine();

                Console.WriteLine("수정 된 회원 : {0} / {1} / {2} / {3} 이 맞습니까? (y/n)", user.userID, user.Name, user.Age, user.Job);

                validate = Console.ReadLine().ToLower() != "y"; // 맞다고(y) 하면 validate true로 바꾸고 반복문 멈추기
            } while (validate);

            return user; // user return
        }

    }
}
