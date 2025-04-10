using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Class
{
    public class EmployeeClass
    {
        public string Name { get; set; }
        public double salary { get; set; }

        public EmployeeClass(string name, double salary)
        {
            Name = name;
            this.salary = salary;
        }
        public virtual void display()
        {
            Console.WriteLine($"Ten nhan vien: {Name}");
            Console.WriteLine($"Luongn: {salary} VND");
        }


    }
}
