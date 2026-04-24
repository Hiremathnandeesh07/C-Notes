using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Person1
    {
        public string name;
        public string gender;
        public int age;

        public Person1(string name,string gender,int age)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
        }
    }
    class Employee : Person1
    {
        public int empId;
        public Employee(string name,string gender,int age,int empId): base(name,gender,age)
        {
            this.empId = empId;
        }

    }
    internal class InheritanceWithGoodExample
    {
        static void Main(string[] args)
        {
            Employee e = new Employee("nandeesh", "male", 32, 3774);
        }
    }
}
