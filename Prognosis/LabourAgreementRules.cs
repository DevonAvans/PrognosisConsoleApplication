using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosis
{
    public class LabourAgreementRules
    {
        // Stock clerks
        public int _MinutesToUnloadColi { get; set; }
        public int _MinutesPerColi { get; set; }
        public int _MinutesTotalPerColi { get; set; }
        public int _AmountMetersShelfArrangementEachMinute { get; set; }

        // Cashiers
        public int _AmountCustomersPerHourCashier { get; set; }

        // Deli
        public int _AmountCustomersPerHourDeli { get; set; }

        public LabourAgreementRules()
        {
            // Stock clerks
            _MinutesToUnloadColi = 5;
            _MinutesPerColi = 30;
            _MinutesTotalPerColi = _MinutesToUnloadColi + _MinutesPerColi;
            _AmountMetersShelfArrangementEachMinute = 1;

            // Cashier
            _AmountCustomersPerHourCashier = 30;

            // Deli
            _AmountCustomersPerHourDeli = 100;
        }
    }
}
