namespace GoF.Behavioral.ChainOfResponsibility {

    public class President : Approver {

        public President(Approver successor, double liability) : base(successor, liability) { }

    }
}