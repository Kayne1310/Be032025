using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Class
{
    public class Worker : EmployeeClass
    {
        public string address { get; set; }
        public Worker(string name, double salary, string address) : base(name, salary)
        {
            this.address = address;
        }
        public override void display()
        {
            base.display();
            Console.WriteLine("address", address);
        }


    }
}
