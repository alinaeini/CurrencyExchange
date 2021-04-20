using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyExchange.Application.Utilities.Design_Patterns.Structural_Design_Patterns.Adapter
{
    public class AdapterDesignPattern
    {
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public decimal Salary { get; set; }

            public Employee(int id, string name, string designation, decimal salary)
            {
                ID = id;
                Name = name;
                Designation = designation;
                Salary = salary;
            }
        }
        //Step2: Creating Adaptee

        public class ThirdPartyBillingSystemAdaptee
        {
            //ThirdPartyBillingSystem accepts employees information as a List to process each employee salary
            public void ProcessSalary(List<Employee> listEmployee)
            {
                foreach (Employee employee in listEmployee)
                {
                    Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.Name + " Account");
                }
            }
        }
        //Step3: Creating Target interface

        //Create an interface with the name ITarget and then copy and paste the following code in it.This class defines the abstract ProcessCompanySalary method
        //which is going to be implemented by the Adapter.Again the client is going to use this method to process the salary.
        public interface ITarget
        {
            void ProcessCompanySalary(string[,] employeesArray);
        }

        //Step4: Creating Adapter

        //Create a class file with the name EmployeeAdapter.cs and then copy and paste the following code in it.
        //This class implements the ITarget interface and provides the implementation for the ProcessCompanySalary method.
        //This class also has a reference to the ThirdPartyBillingSystem object. The ProcessCompanySalary method receives the employee
        //information as a string array and then converts the string array to a list of employees and then calls the ProcessSalary method
        //on the ThirdPartyBillingSystem object bypassing the list of employees as an argument.

        public class EmployeeAdapter : ITarget
        {
            ThirdPartyBillingSystemAdaptee _thirdPartyBillingSystemAdaptee = new ThirdPartyBillingSystemAdaptee();

            public void ProcessCompanySalary(string[,] employeesArray)
            {
                string Id = null;
                string Name = null;
                string Designation = null;
                string Salary = null;
                List<Employee> listEmployee = new List<Employee>();
                for (int i = 0; i < employeesArray.GetLength(0); i++)
                {
                    for (int j = 0; j < employeesArray.GetLength(1); j++)
                    {
                        if (j == 0)
                        {
                            Id = employeesArray[i, j];
                        }
                        else if (j == 1)
                        {
                            Name = employeesArray[i, j];
                        }
                        else if (j == 1)
                        {
                            Designation = employeesArray[i, j];
                        }
                        else
                        {
                            Salary = employeesArray[i, j];
                        }
                    }

                    listEmployee.Add(new Employee(Convert.ToInt32(Id), Name, Designation, Convert.ToDecimal(Salary)));
                }

                Console.WriteLine("Adapter converted Array of Employee to List of Employee");
                Console.WriteLine("Then delegate to the ThirdPartyBillingSystem for processing the employee salary\n");
                _thirdPartyBillingSystemAdaptee.ProcessSalary(listEmployee);
            }
        }

        // Step5: Client
        class Program
        {
            static void Main(string[] args)
            {
                string[,] employeesArray = new string[5, 4]
                {
                    {"101","John","SE","10000"},
                    {"102","Smith","SE","20000"},
                    {"103","Dev","SSE","30000"},
                    {"104","Pam","SE","40000"},
                    {"105","Sara","SSE","50000"}
                };

                ITarget target = new EmployeeAdapter();
                Console.WriteLine("HR system passes employee string array to Adapter\n");
                target.ProcessCompanySalary(employeesArray);
                Console.Read();
            }
        }
    }
}
