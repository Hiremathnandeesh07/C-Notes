using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{

    interface IDevice
    {
        void On();
    }
    class Fan:IDevice
    {
        public void On()
        {
            Console.WriteLine("fan is ON");
        }
    }

    class Light : IDevice
    {
        public void On()
        {
            Console.WriteLine("light is ON");
        }
    }

    class Switch
    {
        IDevice device;
        public Switch(IDevice device)
        {
            this.device = device;
        }
        public void Press()
        {
            device.On();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Switch s1= new Switch(new Fan());
            s1.Press();
        }
    }
}
