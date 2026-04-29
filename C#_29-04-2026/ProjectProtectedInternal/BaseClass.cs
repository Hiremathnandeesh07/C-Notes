using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProtectedInternal
{
    public class BaseClass
    {

        internal void InternalMethod()
        {
            Console.WriteLine("internal method");
        }

        protected internal void ProtectedInternalMethod()
        {
            Console.WriteLine("protected internal method");
        }
    }
}
