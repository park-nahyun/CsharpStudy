using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ArrayList 인덱스 중간 위치 값 삭제하기
namespace RoadBook.CsharpBasic.Chapter06.Examples
{
    internal class Ex008
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

            // 5번째 인덱스에 있는 Array를 제거하라 --> 그리고 삭제된 인덱스로부터, Next 인덱스를 끌어와라
            aList.RemoveAt(5);


            for (int k = 0; k < aList.Count; k++)
            {
                Console.WriteLine("Value: {0} / Type: {1}", aList[k], aList[k].GetType());
            }
        }
    }
}


/*
Remove(argument) 함수는 값을 전달 받아서 제일 먼저 찾은 인덱스에서 그 값을 제거
RemoveAt(number) 매개변수로 전달된 number(인덱스)를 찾아서 해당 값을 제거
RemoveAt(number) 매개변수로 전달된 number(인덱스)를 찾아서 해당 값을 제거
 */