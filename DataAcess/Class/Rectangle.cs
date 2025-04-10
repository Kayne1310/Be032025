using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess.Abstract;

namespace DataAcess.Class
{
    public class Rectangle : Shape
    {

        public override double width { get; set ; }
        public override double height { get; set; }
        public Rectangle(double width, double height) : base(width, height)
        {
            this.width = width;
            this.height = height;
        }

        public override double area()
        {
            return width*height;
        }

        public override void display()
        {
            Console.WriteLine("Chieu dai rectangle la {0} va chieu rong rectangle la{1}",height,width);
        }
    }
}
