using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadBook.CsharpBasic.Chapter05.Examples
{
    public class Ex001
    {
        public void Run()
        {
            Car001 car = new Car001();
            car.setSize("세단");
            car.setColor("하얀");

            Console.WriteLine("고객님의 차, {0} {1}이...", car.getColor(), car.getSize());

            car.Engine_on();
            car.Go();
            car.Back();
            car.Left();
            car.Right();
            car.Engine_off();
        }
    }

    class Car001
    {
        #region 형태
        private string size;
        private string color;

        public void setSize(string size)
        {
            this.size = size;
        }
        public string getSize()
        {
            return size;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public string getColor()
        {
            return color;
        }
        #endregion

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
 private = 다른 클래스에서 호출 못함..

캡슐화 - 데이터의 형태와 데이터의 형태를 다루는 행위를 하나의 세트로 묶어 내는 것..
여기서는 size, color라는 변수 형태 + 행위 (setSize, getColor 등)
캡슐화를 하면 중요한 데이터를 보호할 수 있다.

데이터 자체를 다루는 private / 방법에 대해 서술하는 public한..

setter 메소드에 있는 this = 객체 형태에 주어진 변수
 
 */
