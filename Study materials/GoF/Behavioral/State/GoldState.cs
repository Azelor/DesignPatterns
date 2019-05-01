namespace GoF.Behavioral.State
{
    public class GoldState :State {

        public GoldState(State state)
            : this(state.Balance,state.Account) {
        }

        public GoldState(double balance,Account account) {
            Balance = balance;
            Account = account;
            Initialize();
        }

        private void Initialize() {
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }

        public override void PayInterest() {
            Balance += interest * Balance;
            StateChangeCheck();
        }

        protected override void StateChangeCheck() {
            if(Balance < 0.0) {
                Account.State = new RedState(this);
            } else if(Balance < lowerLimit) {
                Account.State = new SilverState(this);
            }
        }
    }
}