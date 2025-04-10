using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Abstract
{
   public abstract class Shape
    {
        public abstract double width { get; set; }
        public abstract double height { get; set; }

        protected Shape(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public  abstract double area();
        public abstract void display();

    }
}
