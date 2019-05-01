using System.Collections.Generic;

namespace GoF.Structural.Bridge
{
    class CustomersData : DataObject
    {
        public List<string> Customers { get; } = new List<string>();
        public int Current { get; set; }
        
        public CustomersData() // TODO: sisendiks saab anda IEnumerable, mitte List (mingi loenduv abstraktne kollektsioon)
        {
            // TODO: Muuta nii, et saab anda Listi inimestest konstruktorisse (for-loopib l2bi)
            Customers.Add("Jim Jones");
            Customers.Add("Samual Jackson");
            Customers.Add("Allen Good");
            Customers.Add("Ann Stills");
            Customers.Add("Lisa Giolani");
        }

        public override void NextRecord()
        {
            if (Current <= Customers.Count - 1)
            {
                Current++;
            }
        }

        public override void PriorRecord()
        {
            if (Current > 0)
            {
                Current--;
            }
        }

        public override void AddRecord(string customer)
        {
            Customers.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            Customers.Remove(customer);
        }

        public override string ShowRecord()
        {
            return Customers[Current];
        }

        public override List<string> ShowAllRecords()
        {
            return Customers;
        }
    }
}