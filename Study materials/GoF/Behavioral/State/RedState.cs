using System;

namespace GoF.Behavioral.State
{
    public class RedState :State {

        private double serviceFee;

        public RedState(State state) {
            Balance = state.Balance;
            Account = state.Account;
            Initialize();
        }

        private void Initialize() {
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            serviceFee = 15.00;
        }

        public override void Withdraw(double amount) {
            amount = amount - serviceFee;
            if (amount < 0)
            {
                Console.WriteLine("No funds available for withdrawal!");
            }
        }

        public override void PayInterest() {
            // No interest is paid
        }

        protected override void StateChangeCheck() {
            if(Balance > upperLimit) {
                Account.State = new SilverState(this);
            }
        }
    }
}