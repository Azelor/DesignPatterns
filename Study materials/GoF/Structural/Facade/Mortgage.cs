namespace GoF.Structural.Facade
{
    class Mortgage
    {
        private readonly Bank bank = new Bank();
        private readonly Loan loan = new Loan();
        private readonly Credit credit = new Credit();

        public bool IsEligible(Customer customer, int amount)
        {
            bool eligible = true;
            
            if (!bank.HasSufficientSavings(customer, amount))
            {
                eligible = false;
            }
            else if (!loan.HasNoBadLoans(customer))
            {
                eligible = false;
            }
            else if (!credit.HasGoodCredit(customer))
            {
                eligible = false;
            }

            return eligible;
        }
    }
}