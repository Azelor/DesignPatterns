namespace GoF.Behavioral.Command {

    public class Command : ICommand {

        private readonly Processor processor;

        public Command(Processor c, Operator o, decimal operand) {
            processor = c;
            Operator = o;
            Operand = operand;
        }

        public Operator Operator { get; }

        public decimal Operand { get;}

        public Display Execute() { return processor.Calculate(Operator, Operand); }

        public Display UnExecute() { return processor.Calculate(Undo(Operator), Operand); }

        private static Operator Undo(Operator o) {
            switch (o) {
                case Operator.Add: return Operator.Subtract;
                case Operator.Subtract: return Operator.Add;
                case Operator.Multiply: return Operator.Divide;
                case Operator.Divide: return Operator.Multiply;
                default:
                    return Operator.Undefined;
            }
        }
    }
}