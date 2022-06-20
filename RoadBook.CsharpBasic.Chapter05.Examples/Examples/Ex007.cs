using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
    두 숫자 연산이 아니라 여러 개 수를 연산한다고 한다면..
    메소드를 계속해서 호출하는 방식이 있을 것.
    
    dynamic result = Sum(1,2);
 */
namespace RoadBook.CsharpBasic.Chapter05.Examples
{
    internal class Ex007
    {
        public void Run()
        {
            dynamic result = Sum(1, 2, 3, 4, 5);
            Console.WriteLine("1 ~ 5까지의 합은 {0}", result);
        }

        private int Sum(params int[] number)    // param 매개변수는 1차원 배열 형태
        {// 예측이 불가능한 매개변수의 개수를 동적으로 늘렸다 줄일 수 있도록 한다!!!
            int result = 0;

            for (int idx = 0; idx < number.Length; idx++)
            { 
                result += number[idx];
            }

            return result;
        }
    }
}

/*
number 매개변수는 [1, 2, 3, 4, 5] 값을 한 번에 담게 되고
반복문을 통해서 result 값을 계속 갱신하게 됨.
 */
