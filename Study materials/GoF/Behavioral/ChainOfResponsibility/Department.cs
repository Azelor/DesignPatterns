using GoF.Aids;

namespace GoF.Behavioral.ChainOfResponsibility {

    public class Department {

        private readonly Manager manager;

        public Department(Manager m) { manager = m; }

        public void Approve(Purchase p, ILogBook logBook) {
            manager.ProcessRequest(p, logBook);
        }

    }
}