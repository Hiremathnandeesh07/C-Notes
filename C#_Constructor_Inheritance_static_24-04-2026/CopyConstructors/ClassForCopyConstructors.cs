using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyConstructors
{
     class ClassForCopyConstructors
    {
        public string name;
        public int age;

        public ClassForCopyConstructors(string name,int age)
        {
            this.name = name;
            this.age = age;
        }
        public ClassForCopyConstructors(ClassForCopyConstructors c)
        {
            name = c.name;
            age = c.age;
        }
    }

    
}
