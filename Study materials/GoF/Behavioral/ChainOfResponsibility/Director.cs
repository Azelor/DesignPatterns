namespace GoF.Behavioral.ChainOfResponsibility {
    public class Director : Approver {
        public Director(Approver successor, double liability) : base(successor, liability) { }
    }
}