using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LooseCoupling
{
  
        public interface IEngine
        {
            void StartEngine();
        }

        public class DieselEngine : IEngine
        {
            public void StartEngine()
            {
                Console.WriteLine("Starting Diesel Engine...");
            }
        }

        public class PetrolEngine : IEngine
        {
            public void StartEngine()
            {
                Console.WriteLine("Starting Petrol Engine...");
            }
        }
        public class ElectricEngine : IEngine
        {
            public void StartEngine()
            {
                Console.WriteLine("Starting Electric Engine...");
            }
        }

        public class Car
        {
            private IEngine _engine;
            public Car(IEngine engine)
            {
                _engine = engine;
            }


        
        public void StartCar()
            {
                _engine.StartEngine();
                Console.WriteLine("Car started...");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Loose coupling Demo
                DieselEngine engine1 = new DieselEngine();
                Car myCar = new Car(engine1);  // we are passing Diesel Engine object to car class 
                myCar.StartCar();
                //Passing petrol engine object to car class
                PetrolEngine engine2 = new PetrolEngine();
                Car myCar2 = new Car(engine2);
                myCar2.StartCar();


                Console.ReadKey();
            }
        }
    
}
