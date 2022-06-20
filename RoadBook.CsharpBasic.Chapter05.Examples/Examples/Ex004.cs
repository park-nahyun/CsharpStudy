using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 빵 클래스를 활용한 여러가지 객체 만들기

namespace RoadBook.CsharpBasic.Chapter05.Examples
{
    internal class Ex004
    {
        public void Run()
        {
            Bread custard_cream_bread = new Bread();
            custard_cream_bread.Shape = "별모양";
            custard_cream_bread.Source = "슈크림";

            Console.WriteLine("{0} {1}빵", custard_cream_bread.Shape, custard_cream_bread.Source);

            Bread pizza_bread = new Bread();
            pizza_bread.Shape = "네모난";
            pizza_bread.Source = "피자";
            Console.WriteLine("{0} {1}빵", pizza_bread.Shape, pizza_bread.Source);
        }
    }

    class Bread
    {
        public string Shape { get; set; }
        public string Source { get; set; }
    }
}
