namespace GoF.Behavioral.ChainOfResponsibility {
    public class Manager : Approver {

        public Manager(Approver successor, double liability) : base(successor, liability) { }
    }
}