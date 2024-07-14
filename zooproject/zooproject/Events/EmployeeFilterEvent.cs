using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.User;

namespace zooproject.Events
{
    public class EmployeeFilterEvent
    {
        public delegate void EmployeeFilterEventHandler(int Job, int Rank, int WorkContract, bool isActive, DateTime? date);
        public event EmployeeFilterEventHandler EmployeeEvent;
        public EmployeeFilterEvent() { }

        public void SentFilteredEmployees(int Job, int Rank, int WorkContract, bool isActive, DateTime? date)
        {
            EmployeeEvent(Job, Rank, WorkContract, isActive, date);
        }
    }
}
