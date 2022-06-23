using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// 디렉토리 생성

/*
 정보를 알기 위한, DirectoryInfo 클래스와 FileInfo 클래스
 파일 입출력을 위한, StreamWriter 클래스와 StreamReader 클래스
 둘 다 System.IO 네임스페이스

-- 디렉토리를 다루기 위해 필요한 최소 정보
- 현재 디렉토리가 존재하는가?
- 디렉토리가 존재하지 않는다면, 디렉토리를 만든다
- 디렉토리의 전체경로를 출력한다.
 
 */
namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex001
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;    // 현재 구축해놓은 프로젝트 환경의 경로를 가지고 온다.
        // 예를 들어 나는 D:\Works\CsharpWorks 에 프로젝트 환경 구성이 되어있으므로
        // 이 변수에는 D:\Works\CsharpWorks\bin\Debug 환경을 가지고 오는 것

        //-- 실행 결과 : D:\Works\CSharpWorks\RoadBook.CsharpBasic.Chapter08\bin\Debug 안에 /data 디렉토리 생김

        public void Run()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory + @"\data");
            // @는 디렉토리 위치를 의미한다. 즉 currentDirectory 에서 \data 찾아가라는 뜻

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
                Console.WriteLine("디렉토리가 생성되었습니다.");
            }
            // 해당 디렉토리 경로가 없으면 Create() 디렉토리 경로 생성하고 그 경로 정보를 출력하라고 하는 것

            Console.WriteLine("생성 경로 : {0}", directoryInfo.FullName);

        }
    }
}
