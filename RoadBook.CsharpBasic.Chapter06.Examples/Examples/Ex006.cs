using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 자료 구조 : 자료를 효율적으로 이용할 수 있도록 컴퓨터에 저장하는 방법
// 배열, 스택, 큐 등이 있다.
// System.Collections 네임스페이스 이용
// ArrayList


namespace RoadBook.CsharpBasic.Chapter06.Examples
{
    internal class Ex006
    {
        public void Run()
        {
            ArrayList aList = new ArrayList();

            for (int i = 0; i < 10; i++)
            {
                aList.Add(i);
            }

            for (int j = 10; j < 15; j++)
            { 
                aList.Add(j.ToString());
            }

            for (int k = 0; k < aList.Count; k++)
            {
                Console.WriteLine("Value: {0} / Type: {1}", aList[k], aList[k].GetType());
            }
        }
    }
}


/*
 배열의 크기가 가변적 --> 배열과는 달리 배열의 크기를 먼저 주지 않았다.
자료형이 고정되어있지 않다.

Value: 0 / Type: System.Int32
Value: 1 / Type: System.Int32
Value: 2 / Type: System.Int32
Value: 3 / Type: System.Int32
Value: 4 / Type: System.Int32
Value: 5 / Type: System.Int32
Value: 6 / Type: System.Int32
Value: 7 / Type: System.Int32
Value: 8 / Type: System.Int32
Value: 9 / Type: System.Int32
Value: 10 / Type: System.String
Value: 11 / Type: System.String
Value: 12 / Type: System.String
Value: 13 / Type: System.String
Value: 14 / Type: System.String

 */