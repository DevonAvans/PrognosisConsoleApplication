using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prognosis
{
    public class Prognosis
    {
        private readonly LabourAgreementRules _rulesSet;
        private Database _database;

        // Strings Start of the program
        private readonly string _welcomeText = "Hallo Bumbo manager!";
        private readonly string _demoText = "Dit is een console applicatie demo van de prognose,\n" +
            "dit zal uiteindelijk een UI hebben om het makkelijker te maken";

        // Strings start
        private readonly string _loopStartText = "\nWil je een prognose [m]aken of prognose [b]ekijken?\n[m]aken, [b]ekijken of [s]toppen";

        // Strings make prognosis
        private readonly string _makePrognosisStartText = "\nBij het maken van een prognose worden de aantal medewerkers berekent op de aantal klanten en coli.";
        private readonly string _makePrognosisDateText = "Voor welke datum is de prognose? Format: dd-mm-yyyy | Voorbeeld: 01-01-1980:";
        private readonly string _makePrognosisCustomerText = "Aantal klanten: ";
        private readonly string _makePrognosisColiText = "Aantal coli: ";

        // Strings read prognosis
        private readonly string _showPrognosisResultText = "\nDe gegevens van de prognose:";

        // Variables for prognosis
        private readonly int EmployeeDivided = 8;

        public Prognosis()
        {
            _rulesSet = new();
            _database = new();
        }

        public void Start()
        {

            Console.WriteLine(_welcomeText);
            Console.WriteLine(_demoText);
            Loop();
        }

        private void Loop()
        {
            Console.WriteLine(_loopStartText);
            char input = Console.ReadLine().ToLower()[0];
            if (ValidInput(input))
            {
                if (input == 'm') CreatePrognosis();
                if (input == 'b') ReadPrognosis();
                if (input == 's') return;
            }
            else
            {
                Loop();
            }
            Console.ReadKey();
        }

        private bool ValidInput(char input) => (input == 'm' || input == 'b' || input == 's');

        private void CreatePrognosis()
        {
            try
            {
                Console.WriteLine(_makePrognosisDateText);
                string datum = Console.ReadLine();

                Console.WriteLine(_makePrognosisStartText);
                Console.Write(_makePrognosisCustomerText);
                int amountOfCustomers = int.Parse(Console.ReadLine());

                Console.Write(_makePrognosisColiText);
                int amountOfColi = int.Parse(Console.ReadLine());
                if (amountOfCustomers < 0 || amountOfColi < 0) throw new System.FormatException();
                CalculatePrognosis(datum, amountOfCustomers, amountOfColi);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nAn error has occurred!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try again please\n");
                CreatePrognosis();
            }
        }

        private void ReadPrognosis()
        {
            // TODO: 
        }

        private void CalculatePrognosis(string datum, int amountOfCustomers, int amountOfColi)
        {
            Dictionary<EmployeeEnum, int> employees = new()
            {
                { EmployeeEnum.Cashier, GetAmountOfCashiers(amountOfCustomers) },
                { EmployeeEnum.Deli, GetAmountOfDelis(amountOfCustomers) },
                { EmployeeEnum.Clerk, GetAmountOfClerks(amountOfCustomers) }
            };
            Show(datum, employees);
            SaveToDatabase(datum, employees);
        }
        private void Show(string datum, Dictionary<EmployeeEnum, int> employees)
        {
            Console.WriteLine(_showPrognosisResultText);
            Console.WriteLine(datum);
            foreach (var (key, value) in employees)
            {
                Console.WriteLine($"{key}s: {value}");
            }
        }

        private void SaveToDatabase(string datum, Dictionary<EmployeeEnum, int> employees)
        {
            _database.Add(datum, employees);
            Console.WriteLine("Prognose is opgeslage in de database!");
            Loop();
        }

        private int GetAmountOfCashiers(int amountOfCustomers)
        {
            int totalOfCashierHours = amountOfCustomers / _rulesSet._AmountCustomersPerHourCashier;
            return totalOfCashierHours / EmployeeDivided;
        }

        private int GetAmountOfDelis(int amountOfCustomers)
        {
            int totalOfDeli = amountOfCustomers / _rulesSet._AmountCustomersPerHourDeli;
            return totalOfDeli / EmployeeDivided;
        }

        private int GetAmountOfClerks(int amountOfCustomers)
        {
            int totalOfClerks = amountOfCustomers / _rulesSet._MinutesTotalPerColi;
            return totalOfClerks / EmployeeDivided;
        }
    }
}
