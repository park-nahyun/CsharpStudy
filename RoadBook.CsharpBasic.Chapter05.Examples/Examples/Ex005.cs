using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 더하기 공통 기능


// 하나의 메소드는 하나의 기능을 담당하게 구현한다.
namespace RoadBook.CsharpBasic.Chapter05.Examples
{
    internal class Ex005
    {
        public void Run()
        {
            Sum(1, 1);
            Sum(2, 2);
            Sum(3, 3);
        }

        private void Sum(int number01, int number02)
        {
            Console.WriteLine("{0} + {1} = {2}", number01, number02, number01 + number02);
        }
    }
}
