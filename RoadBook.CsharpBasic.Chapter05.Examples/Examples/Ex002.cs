using System;


/*
 프로퍼티 개념
 */

namespace RoadBook.CsharpBasic.Chapter05.Examples
{
    public class Ex002
    {
        public void Run()
        {
            Car002 car = new Car002();
            car.Size = "세단";
            car.Color = "하얀";
            // ------------- 객체의 프로퍼티에 직접 할당ㅅ함

            Console.WriteLine("고객님의 차, {0} {1}이...", car.Color, car.Size);
            car.Engine_on();
            car.Go();
            car.Back();
            car.Left();
            car.Right();
            car.Engine_off();
        }
    }

    class Car002
    {
        #region 형태
        private string size;
        private string color;

        public string Size
        {
            set { size = value; }
            get { return size; }
        }
        public string Color
        {
            set { color = value; }
            get { return color; }
        }
        #endregion
        //-------------------------------- 메소드 형태의 괄호가 생략되는 set과 get을 함께 묶어버림

        #region 행동
        public void Engine_on()
        {
            Console.WriteLine("시동을 켭니다.");
        }

        public void Engine_off()
        {
            Console.WriteLine("시동을 끕니다.");
        }

        public void Go()
        {
            Console.WriteLine("전진합니다.");
        }

        public void Back()
        {
            Console.WriteLine("후진합니다.");
        }

        public void Left()
        {
            Console.WriteLine("좌회정합니다.");
        }

        public void Right()
        {
            Console.WriteLine("우회전합니다.");
        }
        #endregion
    }
}

/*
 객체에서 '형태'를 나타내는 것을 프로퍼티, '행동'을 나타내는 것을 메소드라고 한다.
 */
