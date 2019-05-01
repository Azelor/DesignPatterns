using System.Collections.Generic;

namespace GoF.Behavioral.Observer
{
    public class Investor : IInvestor {

        public Investor(string name) { this.name = name; }
        
        private readonly string name;
        public List<string> notifications = new List<string>();

        public void Update(Stock stock) {
            notifications.Add("Notified " + name + " of " + stock.Symbol + "'s change to " + stock.Price.ToString("C"));
        }
    }
}