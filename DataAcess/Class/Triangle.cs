using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Abstract;

namespace DataAcess.Class
{
    public class Triangle : Shape
    {
        public Triangle(double width, double height) : base(width, height)
        {
            this.width = width;
            this.height = height;
        }

        public override double width { get; set ; }
        public override double height { get; set; }

        public override double area()
        {
            return (width * height) / 2;
        }

        public override void display()
        {
            Console.WriteLine("Chieu dai tam giac la {0} va chieu cao tam giac la {1}",width,height);
        }
    }
}
