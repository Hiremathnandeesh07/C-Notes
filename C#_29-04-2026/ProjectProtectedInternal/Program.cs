using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectProtectedInternal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
            bc.InternalMethod();
            bc.ProtectedInternalMethod();
        }
    }
}
