using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosis
{
    // A temporary place to save the prognosis
    public class Database
    {
        public Dictionary<string, Dictionary<EmployeeEnum, int>> _prognosis { get; set; }

        public Database()
        {
            _prognosis = new();
        }

        public void Add(string datum, Dictionary<EmployeeEnum, int> employees)
        {
            _prognosis.Add(datum, employees);
        }
    }
}
