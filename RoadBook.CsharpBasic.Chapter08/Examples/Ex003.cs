using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


// 파일에 내용 출력해보기
namespace RoadBook.CsharpBasic.Chapter08.Examples
{
    internal class Ex003
    {
        private readonly string currentDirectory = Environment.CurrentDirectory;

        public void Run()
        {
            FileInfo fileInfo = new FileInfo(currentDirectory + @"\data\log.txt");

            Console.WriteLine("저장경로 : {0}", fileInfo.DirectoryName);
            Console.WriteLine("파일명 : {0}", fileInfo.Name);

            Console.WriteLine("=== 파일 내용 ===");
            using (StreamReader sr = new StreamReader(fileInfo.FullName))
            { 
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                { 
                    Console.WriteLine(line);
                }
            }
        }
    }
}



/*
저장경로 : D:\Works\CSharpWorks\RoadBook.CsharpBasic.Chapter08\bin\Debug\net6.0\data
파일명 : log.txt
=== 파일 내용 ===
프로그램 실행 시간: 2022-06-21 오후 3:34:04
 */
