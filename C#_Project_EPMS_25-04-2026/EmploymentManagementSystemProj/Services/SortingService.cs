using EmploymentManagementSystemProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmploymentManagementSystemProj.Services
{
    internal  class SortingService : EmployeeService
    {


        public SortingService(EmployeeService employeeService)
        {
            //  now legal
            this.employees = employeeService.GetEmployeesInternal();
        }



        // implimenting sorting using builtin
        public void BuiltInSorting()
        {
            employees.Sort((e1, e2) => e1.EmpSalary.CompareTo(e2.EmpSalary));
        }


        // implimenting bubble sorting
        public void BubbleSorting()
        {
            int length = employees.Count;
            for(int i = 0; i < length - 1; i++)
            {
                for(int j = 0; j < length - 1 - i; j++)
                {
                    if (employees[j].EmpSalary > employees[j+1].EmpSalary)
                    {

                        Employee temp = employees[j];
                        employees[j] = employees[j + 1];
                        employees[j + 1] = temp;

                    }
                }
            }
        }


        // implimenting quick sort algorithm


        public void QuickSorting()
        {
            if (employees == null || employees.Count <= 1)
                return;

            QuickSort(0, employees.Count - 1);
        }


        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(low, high);

                QuickSort(low, pivotIndex - 1);
                QuickSort(pivotIndex + 1, high);
            }
        }

        private int Partition(int low, int high)
        {
            double pivot = employees[high].EmpSalary;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (employees[j].EmpSalary <= pivot)
                {
                    i++;
                    Swap(i, j);
                }
            }

            Swap(i + 1, high);
            return i + 1;
        }



        private void Swap(int i, int j)
        {
            Employee temp = employees[i];
            employees[i] = employees[j];
            employees[j] = temp;
        }




        // implementing selection sorting
        // implementing selection sorting
        public void SelectionSorting()
        {
            int n = employees.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (employees[j].EmpSalary < employees[minIndex].EmpSalary)
                    {
                        minIndex = j;
                    }
                }

                // swap only if needed
                if (minIndex != i)
                {
                    Employee temp = employees[i];
                    employees[i] = employees[minIndex];
                    employees[minIndex] = temp;
                }
            }
        }

        public double NthHighestDistinct(int n, out bool isValid)
        {
            if (n <= 0)
            {
                isValid = false;
                return -1;
            }

            var salaries = new SortedSet<double>(employees.Select(e => e.EmpSalary));

            if (n > salaries.Count)
            {
                isValid = false;
                return -1;
            }

            int count = 0;
            foreach (var salary in salaries.Reverse()) // iterate from highest
            {
                count++;
                if (count == n)
                {
                    isValid = true;
                    return salary;
                }
            }

            isValid = false;
            return -1;
        }




    }
}
