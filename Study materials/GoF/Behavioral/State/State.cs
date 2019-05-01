namespace GoF.Behavioral.State {
    public abstract class State {

        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;
        public Account Account { get; set; }
        public double Balance { get; set; }

        public virtual void Deposit(double amount) {
            Balance += amount;
            StateChangeCheck();
        }

        public virtual void Withdraw(double amount) {
            Balance -= amount;
            StateChangeCheck();
        }

        public virtual void PayInterest() {
            Balance += interest * Balance;
            StateChangeCheck();
        }

        protected abstract void StateChangeCheck();
    }
}