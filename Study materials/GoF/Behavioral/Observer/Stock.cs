using System;
using System.Collections.Generic;

namespace GoF.Behavioral.Observer
{
    public abstract class Stock {

        protected Stock(string symbol, double price)
        {
            Symbol = symbol;
            this.price = price;
        }

        private double price;
        public readonly List<IInvestor> investors = 
            new List<IInvestor>() {};
        
        public void Attach(IInvestor investor) {
            investors.Add(investor);
        }
        public void Detach(IInvestor investor) {
            investors.Remove(investor);
        }
        public void Notify() {
            foreach (var investor in investors) {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        public double Price
        {
            get { return price; }
            set {
                if (!(Math.Abs(price - value) > 0.0001)) return;
                price = value;
                Notify();
            }
        }

        public string Symbol { get; }
    }
}