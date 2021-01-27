using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hard
{
    class Employee 
    {
        int id, age;
        string name;
        double salary;

        public int Id { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }

        public Employee()
        {
        }

        public Employee(int id, int age, string name, double salary)
        {
            this.id = id;
            this.age = age;
            this.name = name;
            this.salary = salary;
        }

        public void TakeEmployeeDetailsFromUser()
        {
            Regex rgx_name = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");
            Regex rgx_id = new Regex(@"^[0-9]+$");
            Regex rgx_age = new Regex(@"^[1-9][0-9]{1,2}$");
            Regex rgx_salary = new Regex(@"^[1-9][0-9]*$");
        
        ReadId: Console.WriteLine("Please enter the employee ID");
            string id = Console.ReadLine();
            if (isValid(id, rgx_id))
            {
                this.Id = Convert.ToInt32(id);
            }
            else
            {
                goto ReadId;
            }
        
        ReadName: Console.WriteLine("Please enter the employee name");
            string name = Console.ReadLine();
            if (isValid(name, rgx_name))
            {
                this.Name = name;
            }
            else
            {
                goto ReadName;
            }

        ReadAge: Console.WriteLine("Please enter the employee age");
            string age = Console.ReadLine();
            if (isValid(age, rgx_age))
            {
                this.Age = Convert.ToInt32(age);
            }
            else
            {
                goto ReadAge;
            }
        ReadSalary: Console.WriteLine("Please enter the employee salary");
            string salary = Console.ReadLine();

            if (isValid(salary, rgx_salary))
            {
                this.Salary = Convert.ToDouble(salary);
            }
            else
            {
                goto ReadSalary;
            }

        }
        private bool isValid(string vlaue, Regex regex)
        {
            if (string.IsNullOrEmpty(vlaue) || !regex.IsMatch(vlaue))                        
            {
                Console.WriteLine("Invalid value please enter a valid value");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return "Employee ID : " + id + "\nName : " + name + "\nAge : " + age + "\nSalary : " + salary;
        }


    }
}
