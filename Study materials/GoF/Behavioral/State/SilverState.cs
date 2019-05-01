namespace GoF.Behavioral.State
{
    public class SilverState :State {

        public SilverState(State state) :
            this(state.Balance,state.Account) {
        }

        public SilverState(double balance, Account account) {
            Balance = balance;
            Account = account;
            Initialize();
        }

        private void Initialize() {
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }

        protected override void StateChangeCheck() {
            if(Balance < lowerLimit) {
                Account.State = new RedState(this);
            } else if(Balance > upperLimit) {
                Account.State = new GoldState(this);
            }
        }
    }
}