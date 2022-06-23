using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ArrayList 인덱스 중간 위치에 삽입하기
namespace RoadBook.CsharpBasic.Chapter06.Examples
{
    internal class Ex007
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

            // 중간에 삽입하기 - 5번째 인덱스(6번째 공간)에 100이라는 문자열을 삽입하라
            aList.Insert(5, "100");

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