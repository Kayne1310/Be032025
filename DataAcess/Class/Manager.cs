using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Class
{
    public class Manager : EmployeeClass
    {
        public int age {  get; set; }
        public Manager(string name, double salary,int age) : base(name, salary)
        {
           this.age=age;

        }
        public override void display()
        {
            base.display();
            Console.WriteLine("tuoi la ",age);
        }


    }
}
