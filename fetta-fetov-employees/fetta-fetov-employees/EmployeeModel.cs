using System;
using System.Collections.Generic;
using System.Text;

namespace fetta_fetov_employees
{
    public class EmployeeModel
    {
        public uint EmployeeId { get; set; }
        public uint ProjectId { get; set; }
        public DateTime StartDate = new DateTime();
        public DateTime EndDate = new DateTime();
        public double TotalDaysWorked;
        public EmployeeModel(string empId, string projId, DateTime start, DateTime end, double totalDays)
        {
            this.EmployeeId = uint.Parse(empId);
            this.ProjectId = uint.Parse(projId);
            this.StartDate = start;
            this.EndDate = end;
            this.TotalDaysWorked = totalDays;
        }
    }
}
