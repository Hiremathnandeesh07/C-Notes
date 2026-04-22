using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Question 5
namespace C__Starter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter num1");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num2");
            int num2 = Convert.ToInt32(Console.ReadLine());

            num1 = num1 ^ num2;
            num2 = num1 ^ num2;
            num1 = num1 ^ num2;

            Console.WriteLine("num1 is " + num1);
            Console.WriteLine("num2 is " + num2);


        }
    }
}


//question 6
double radius;
Console.Write("Enter radius: ");
radius = double.Parse(Console.ReadLine());
double area = 3.14 * radius * radius;
double perimeter = 2 * 3.14 * radius;
Console.WriteLine("Area = " + area);
Console.WriteLine("Perimeter = " + perimeter + "\n\n");

//Question 7

double x, y, z;

Console.Write("Enter side x: ");

x = double.Parse(Console.ReadLine());

Console.Write("Enter side y: ");

y = double.Parse(Console.ReadLine());

Console.Write("Enter side z: ");

z = double.Parse(Console.ReadLine());

double s = (x + y + z) / 2;

double triangle_Area = Math.Sqrt(s * (s - x) * (s - y) * (s - z));

double triangle_Perimeter = x + y + z;

Console.WriteLine("Area = " + area);

Console.WriteLine("Perimeter = " + perimeter + "\n\n");


//Question 8 simple intrest

double p, r, t;

Console.Write("Enter principal: ");

p = double.Parse(Console.ReadLine());

Console.Write("Enter rate: ");

r = double.Parse(Console.ReadLine());

Console.Write("Enter time: ");

t = double.Parse(Console.ReadLine());

double si = (p * r * t) / 100;

Console.WriteLine("Simple Interest = " + si + "\n\n");


//Question 9
/*  Student total, average by 
taking 3 subjects marks*/

int m1, m2, m3;

Console.Write("Enter marks1: ");

m1 = int.Parse(Console.ReadLine());

Console.Write("Enter marks2: ");

m2 = int.Parse(Console.ReadLine());

Console.Write("Enter marks3: ");

m3 = int.Parse(Console.ReadLine());

int total = m1 + m2 + m3;

double avg = total / 3.0;

Console.WriteLine("Total = " + total);

Console.WriteLine("Average = " + avg + "\n\n");


//Question 10 
/*
 * Employ payslip by taking 
basic sal, employ id, name, 
Calculate TA 10% on basic,
Calculate DA 12% on basic,
Calculate HRA 15% on basic,
Calculate PF 10% on basic,
Calculate IT 5% on basic,
Finally Gross & Net
Gross = Basic+TA+DA+HRA
Net = Gross – (pf+it
 * 
*/
int empId;

string name;

double basic;

Console.Write("Enter Employee ID: ");

empId = int.Parse(Console.ReadLine());

Console.Write("Enter Name: ");

name = Console.ReadLine();

Console.Write("Enter Basic Salary: ");

basic = double.Parse(Console.ReadLine());

double ta = basic * 0.10;

double da = basic * 0.12;

double hra = basic * 0.15;

double pf = basic * 0.10;

double it = basic * 0.05;

double gross = basic + ta + da + hra;

double net = gross - (pf + it);

Console.WriteLine("Employee ID: " + empId);

Console.WriteLine("Name: " + name);

Console.WriteLine("TA: " + ta);

Console.WriteLine("DA: " + da);

Console.WriteLine("HRA: " + hra);

Console.WriteLine("PF: " + pf);

Console.WriteLine("IT: " + it);

Console.WriteLine("Gross Salary: " + gross);

Console.WriteLine("Net Salary: " + net + "\n\n");







