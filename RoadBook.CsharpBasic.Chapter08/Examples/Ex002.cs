using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex002
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;

        public void Run()
        {
            // 파일 덮어쓰기 여부를 true로 선언했기 때문에 프로그램을 여러 번 실행하면, log.txt 파일은 여러 줄로 계속 기록된다.
            using (StreamWriter sw = new StreamWriter(currentDirectory + @"\data\log.txt", true))
            {
                sw.WriteLine("프로그램 실행 시간: {0}", DateTime.Now);
            }

            /*
            using을 StreamWriter 클래스 선언문에 감쌌다.
            using은 네임스페이스 기능 불러오기 기능 외에도
            메모리 자원을 자동으로 할당하고 자동으로 제거하는 기능을 한다

            using으로 묶여진 StreamWriter 클래스는 
            sw.WriteLine 문장을 실행한 후에 자동으로 자원이 해제된다.
        
             
             /*
            using을 사용하지 않고 구현했다면..

            StreamWriter sw = new StreamWriter(currentDirectory + @"\data\log.txt");
            sw.WriteLine("프로그램 실행 시간: {0}", DateTime.Now);
            sw.close();

            이렇게 표현됐을 것.

            using의 사용은 개발자들의 취향 차이
             */
        }


    }
}
