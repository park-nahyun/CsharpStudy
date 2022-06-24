using System;
using System.Data;
using System.Text;
using RoadBook.CsharpBasic.Chapter10.Examples.Model;
using RoadBook.CsharpBasic.Chapter10.Examples.Manager;


// DBManager 클래스를 프로그램에서 호출하는 로직\
/*
 1. 사용자가 프로그램을 실행하면 메시지가 출력된다.(1:조회 2:데이터 추가..)
 2. 사용자가 메시지에 해당하는 번호를 입력한다.
 3. 만약 '종료'를 선택한 경우 프로그램이 종료된다.
 4. 만약 '종료'가 아닌 경우, 선택한 액션이 수행된다.
 5. 선택된 액션이 수행된 후에, 다시 1번으로 돌아간다. 
 */

namespace RoadBook.CsharpBasic.Chapter10.Examples
{
    public class Ex001
    {
        public void Run()
        {

            // DatabaseInfo 정보
            DatabaseInfo dbInfo = new DatabaseInfo();
            dbInfo.Name = "RoadBookDB";
            dbInfo.Ip = "192.168.1.152";
            dbInfo.Port = 1433;
            dbInfo.UserId = "sa";
            dbInfo.UserPassword = "Arisys123$";

            MsSqlManager ms = new MsSqlManager();
            ms.Open(dbInfo);


            /*
             StringBuilder 클래스는 String 클래스와 유사합니다. 
            String 클래스와 다른점은 String 클래스는 불변인데 반해서 StringBuilder 클래스는 가변적이라는 점입니다. 
            즉, String 클래스의 문자열은 한 번 생성되면 메모리 내부에서 변경이 불가능합니다. 
            일반적으로 문자열 결합 등을 이용하는 연산 과정 등은 메모리 내에서 이전과 다른 새로운 문자열이 새롭게 만들어지고 있는 상태입니다. 
            StringBuilder 클래스는 문자열 결합 등의 액션을 수행할 때 새로운 문자열을 만들어내지 않고, 기존의 문자열에 추가될 뿐입니다. 
             */
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.AppendLine("****************************************");
            sbMessage.AppendLine("1. SELECT");
            sbMessage.AppendLine("2. INSERT");
            sbMessage.AppendLine("3. UPDATE");
            sbMessage.AppendLine("4. DELETE");
            sbMessage.AppendLine("0. QUIT");
            sbMessage.AppendLine("****************************************");

            while (true)
            { 
                Console.WriteLine(sbMessage.ToString());
                string input = Console.ReadLine();

                if (input == "0")
                {
                    ms.Close();

                    Console.WriteLine("BYE~!!!");
                    break;
                }
                else
                { 
                    
                }
            }

        }
    }
}
 