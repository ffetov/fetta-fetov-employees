using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace fetta_fetov_employees
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\users\dell\source\repos\fetta-fetov-employees\fetta-fetov-employees\data.txt";
            string line;
            List<EmployeeModel> ListofEmployees = new List<EmployeeModel>();
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] record = line.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (record[3].ToUpper() == "NULL")
                    {
                        record[3] = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    DateTime end = DateTime.Parse(record[3], CultureInfo.InvariantCulture);
                    DateTime start = DateTime.Parse(record[2], CultureInfo.InvariantCulture);
                    double totalDays = (end - start).TotalDays;
                    EmployeeModel employee = new EmployeeModel(record[0], record[1], start, end, totalDays);
                    ListofEmployees.Add(employee);
                }
                double max = ListofEmployees[0].TotalDaysWorked;
                uint empIdWithMaxWorkingDays = 0;
                int index = 0;
                for (int i = 1; i < ListofEmployees.Count; i++)
                {
                    if (ListofEmployees[i].TotalDaysWorked > max)
                    {
                        max = ListofEmployees[i].TotalDaysWorked;
                        empIdWithMaxWorkingDays = ListofEmployees[i].EmployeeId;
                        index = i;
                    }
                    else
                    {
                        empIdWithMaxWorkingDays = ListofEmployees[0].EmployeeId;
                    }
                }
                Console.WriteLine(empIdWithMaxWorkingDays);
                ListofEmployees.Remove(ListofEmployees[index]);
                max = ListofEmployees[0].TotalDaysWorked;
                empIdWithMaxWorkingDays = 0;
                for (int i = 1; i < ListofEmployees.Count; i++)
                {
                    if (ListofEmployees[i].TotalDaysWorked > max)
                    {
                        max = ListofEmployees[i].TotalDaysWorked;
                        empIdWithMaxWorkingDays = ListofEmployees[i].EmployeeId;
                        index = i;
                    }
                    else
                    {
                        empIdWithMaxWorkingDays = ListofEmployees[0].EmployeeId;
                    }
                    Console.WriteLine(empIdWithMaxWorkingDays);
                    ListofEmployees.Remove(ListofEmployees[index]);
                }
            }
        }
    }
}
