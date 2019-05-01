
namespace GoF.Behavioral.Command {
    public class Display {
        public Display(decimal x, Operator o, decimal y, decimal result) {
            FirstOperand = x;
            Operator = o;
            SecondOperand = y;
            Result = result;
        }

        public decimal FirstOperand { get; }

        public Operator Operator { get; }

        public decimal SecondOperand { get; }

        public decimal Result { get; }

        public override string ToString() {
            return $"{FirstOperand} {Op} {SecondOperand} = {Result}";
        }

        internal string Op {
            get {
                switch (Operator) {
                    case Operator.Add:
                        return "+";
                    case Operator.Subtract:
                        return "-";
                    case Operator.Multiply:
                        return "*";
                    case Operator.Divide:
                        return "/";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
