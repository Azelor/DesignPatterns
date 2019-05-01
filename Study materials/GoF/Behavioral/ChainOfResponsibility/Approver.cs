using GoF.Aids;

namespace GoF.Behavioral.ChainOfResponsibility {

    public abstract class Approver {

        protected Approver(Approver successor, double liability) {
            Successor = successor;
            Liability = liability;
        }

        public Approver Successor { get; }

        public double Liability { get; }

        public virtual void ProcessRequest(Purchase purchase, ILogBook logBook) {
            if (CanApprove(purchase.Amount))
                logBook.WriteLine(ApprovalMsg(purchase.Number, purchase.Purpose));
            else
                Successor?.ProcessRequest(purchase, logBook);
        }

        internal string ApprovalMsg(int number, string purpose) {
            return $"{GetType().Name} approved request# {number} {purpose}";
        }

        internal bool CanApprove(double amount) { return amount <= Liability; }
    }
}