using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Hard
{
    class EmployeePromotion
    {
        private List<Employee> employeeRecord = new List<Employee>();

        private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        public void DisplayMenu()
        {
            bool flag = true;
            Console.WriteLine("Please enter the option");
            do
            {
                Console.WriteLine("1.Add an employee");
                Console.WriteLine("2.Modify an employee detail");
                Console.WriteLine("3.Print all employee's details");
                Console.WriteLine("4.Print an employee detail");
                Console.WriteLine("5.Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": CreateEmployeeRecord();
                        break;
                    case "2": ModifyEmployee(); 
                        break;
                    case "3": SortAndPrintEmployees(); 
                        break;
                    case "4": getById(); 
                        break;
                    case "5": flag = false; 
                        break;
                    default: Console.WriteLine("Invalid Choice");
                        break;

                }
            } while (flag);
        }
        public void CreateEmployeeRecord()
        {
            

            bool flag = true;


            

            do
            {
                Employee employee = new Employee();
                employee.TakeEmployeeDetailsFromUser();
                if (!employees.ContainsKey(employee.Id))
                {
                    employees.Add(employee.Id, employee);
                }
                else
                {
                    Console.WriteLine("Employee with {0} already exist", employee.Id);
                    goto Exit;
                }


            Exit: Console.WriteLine("To continue entering employee details enter 1, to exit enter 0");
                string value = Console.ReadLine();
                if (value == "1")
                { }
                else if (value == "0")
                { flag = false; }

            } while (flag);
        } 
        public void ModifyEmployee()
        {
            Regex rgx_id = new Regex(@"^[0-9]+$");
            Regex rgx_age = new Regex(@"^[1-9][0-9]{1,2}$");
            Regex rgx_name = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");
            Regex rgx_salary = new Regex(@"^[1-9][0-9]*$");

        ReadId: Console.WriteLine("Please enter the employee ID");
            string id = Console.ReadLine();                                                    

            if (isValid(id, rgx_id))
            {

                if (!employees.ContainsKey(Convert.ToInt32(id)))
                {
                    Console.WriteLine("The {0} does not exist", id);
                }
                else
                {
                   EditChoice: Console.WriteLine("what value would you like to change");
                    Console.WriteLine("1.Age");
                    Console.WriteLine("2.Name");
                    Console.WriteLine("3.Salary");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1": ReadAge: Console.WriteLine("Please enter the employee age");
                                   string age = Console.ReadLine();
                                    if (isValid(age, rgx_age))
                                    {
                                        employees[Convert.ToInt32(id)].Age = Convert.ToInt32(age);
                                        Console.WriteLine("The age of the employee with id:{0} was updated to {1}",id,age);
                                    }
                                    else
                                    {
                                    goto ReadAge;
                                    }
                            break;
                        case "2":  ReadName: Console.WriteLine("Please enter the employee name");
                                    string name = Console.ReadLine();
                                    if (isValid(name, rgx_name))
                                    {
                                        employees[Convert.ToInt32(id)].Name = name;
                                        Console.WriteLine("The name of the employee with id:{0} was updated to {1}", id, name);
                                    }
                                    else
                                    {
                                        goto ReadName;
                                    } //edit name
                            break;
                        case "3":   ReadSalary: Console.WriteLine("Please enter the employee salary");
                                    string salary = Console.ReadLine();

                                    if (isValid(salary, rgx_salary))
                                    {
                                        employees[Convert.ToInt32(id)].Salary= Convert.ToDouble(salary);
                                        Console.WriteLine("The salary of the employee with id:{0} was updated to {1}", id, salary);
                                    }
                                    else
                                    {
                                        goto ReadSalary;
                                    }  //edit salary
                            break;
                        default: Console.WriteLine("Invalid choice");
                                 goto EditChoice;
                            

                    }

                }
            }
            else
            {
                goto ReadId;
            }
            
        }

        public void getById()
        {
            Regex rgx_id = new Regex(@"^[0-9]+$");

        ReadId: Console.WriteLine("Please enter the employee ID");
            string id = Console.ReadLine();                                                   

            if (isValid(id, rgx_id))
            {

                if (!employees.ContainsKey(Convert.ToInt32(id)))
                {
                    Console.WriteLine("The {0} does not exist", id);
                }
                else
                {
                    Console.WriteLine(employees[Convert.ToInt32(id)]);

                }
            }
            else
            {
                goto ReadId;
            }
            



        }
        public void SortAndPrintEmployees()
        {
            if (employees.Any())
            {
                foreach (Employee employee in employees.Values)
                {
                    Console.WriteLine(employee);
                    Console.WriteLine("------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("There are no employee records");
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







    }
}
