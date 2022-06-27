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

            // DB속성--------------------------------
            DatabaseInfo dbInfo = new DatabaseInfo();
            dbInfo.Name = "RoadBookDB";
            dbInfo.Ip = "192.168.1.152";
            dbInfo.Port = 1433;
            dbInfo.UserId = "sa";
            dbInfo.UserPassword = "Arisys123$";

            // -------------------------------------DB속성


            // 내가 쓰는 DB 선언하기
            MsSqlManager ms = new MsSqlManager();
            ms.Open(dbInfo); // DB 열기
           
            /*
             StringBuilder 클래스는 String 클래스와 유사합니다. 
            String 클래스와 다른점은 String 클래스는 불변인데 반해서 StringBuilder 클래스는 가변적이라는 점입니다. 
            즉, String 클래스의 문자열은 한 번 생성되면 메모리 내부에서 변경이 불가능합니다. 
            일반적으로 문자열 결합 등을 이용하는 연산 과정 등은 메모리 내에서 이전과 다른 새로운 문자열이 새롭게 만들어지고 있는 상태입니다. 
            StringBuilder 클래스는 문자열 결합 등의 액션을 수행할 때 새로운 문자열을 만들어내지 않고, 기존의 문자열에 추가될 뿐입니다. 
             */

            //-- String Builder에 메세지 정보 입력---------------------------
            StringBuilder sbMessage = new StringBuilder();
            sbMessage.AppendLine("****************************************");
            sbMessage.AppendLine("1. SELECT");
            sbMessage.AppendLine("2. INSERT");
            sbMessage.AppendLine("3. UPDATE");
            sbMessage.AppendLine("4. DELETE");
            sbMessage.AppendLine("0. QUIT");
            sbMessage.AppendLine("****************************************");
            //------------------------------ String Builder에 메세지 정보 입력


            //-- 0 (quit) 입력까지 반복되는 반복문
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
                else // 종료하지 않은 경우
                {
                    
                    // 필요한 문자열 변수 선언(CRUD에 필요한 변수들)

                    string index = string.Empty;
                    string title = string.Empty;
                    string summary = string.Empty;
                    string createUserNm = string.Empty;
                    string tags = string.Empty;
                    string createDate = string.Empty;

                    StringBuilder sbSQL = new StringBuilder();

                    switch (input)
                    {
                        case "1":   // SELECT
                            DataTable dt = ms.Select("SELECT IDX, TITLE, SUMMARY, CREATE_DT, CREATE_USER_NM, TAGS, LIKE_CNT, CATEGORY_IDX FROM TB_CONTENTS"); // select 호출

                            if (dt.Rows.Count > 0) // 리턴 받은 DataTable Row의 개수가 0보다 큰 경우 --> 조회된 데이터가 있는 것으로 간주
                            {
                                string[] columns = new string[dt.Columns.Count];

                                for (int idx = 0; idx < dt.Columns.Count; idx++) // 데이터를 한줄 씩 출력
                                {
                                    columns[idx] = dt.Columns[idx].ToString();

                                    Console.Write(dt.Columns[idx] + "\t");
                                }

                                Console.WriteLine();

                                for (int idx = 0; idx < dt.Rows.Count; idx++)
                                {
                                    for (int idx_j = 0; idx_j < dt.Columns.Count; idx_j++)
                                    {
                                        Console.Write(dt.Rows[idx][columns[idx_j]] + "\t");
                                    }

                                    Console.WriteLine();
                                }
                            }

                            else // 리턴 받은 row 개수가 0개 이하인 경우
                            {
                                Console.WriteLine("No Data!!");
                            }

                            break;

                        case "2": // INSERT
                            Console.WriteLine("TITLE : ");
                            title = Console.ReadLine();
                            Console.WriteLine("SUMMARY : ");
                            summary  = Console.ReadLine();
                            Console.Write("CREATE_USER_NM : ");
                            createUserNm = Console.ReadLine();
                            Console.Write("TAGS : ");
                            tags = Console.ReadLine();

                            createDate = DateTime.Now.ToString("yyyy-mm-dd");

                            sbSQL.Append(" INSERT TB_CONTENTS ( TITLE, SUMMARY, CREATE_DT, CREATE_USER_NM, TAGS, CATEGORY_IDX) ");
                            sbSQL.Append(string.Format(" VALUES( '{0}', '{1}', '{2}'. '{3}', '{4}', '{5}' ))",
                                title, summary, createDate, createUserNm, tags, 2));

                            ms.Insert(sbSQL.ToString());

                            break;

                        case "3":   // UPDATE
                            ms.Open(dbInfo);

                            Console.Write("Changed IDX : ");
                            index = Console.ReadLine();
                            Console.Write("TITLE : ");
                            title = Console.ReadLine();
                            Console.Write("SUMMARY : ");
                            summary = Console.ReadLine();

                            sbSQL.Append(" UPDATE TB_CONTENTS SET ");
                            sbSQL.Append(
                                string.Format(" TITLE = '{0}', SUMMARY = '{1}' ",
                                    title, summary
                                )
                            );
                            sbSQL.Append(
                                string.Format(" WHERE IDX = {0}",
                                    index
                                )
                            );

                            ms.Update(sbSQL.ToString());

                            break;

                        case "4":   // DELETE
                            ms.Open(dbInfo);

                            Console.Write("DELETED IDX : ");
                            index = Console.ReadLine();

                            sbSQL.Append(" DELETE FROM TB_CONTENTS ");
                            sbSQL.Append(
                                string.Format(" WHERE IDX = {0}",
                                    index
                                )
                            );

                            ms.Update(sbSQL.ToString());

                            break;
                        default:
                            Console.WriteLine("Invalid");

                            break;
                    }
                }
            }
        }
    }
}

