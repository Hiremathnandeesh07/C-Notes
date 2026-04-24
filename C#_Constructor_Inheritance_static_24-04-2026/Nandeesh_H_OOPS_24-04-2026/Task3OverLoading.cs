using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nandeesh_H_OOPS_24_04_2026
{
    /*
     * create 3 add methods which takes int double string others
     */
    internal class Task3OverLoading
    {
        public int Add(int a,int b,int c)
        {
            return a + b + c;
        }
        public double Add(double a,double b,double c)
        {
            return a + b + c;
        }
        public string Add(string a,string b,string c)
        {
            return a + b + c;
        }
        
    }
}
