namespace GoF.Behavioral.Command {
    public class Processor {
        private decimal result;
        public Display Calculate(Operator o, decimal operand) {
            var r = result;
            switch (o) {
                case Operator.Add:
                    result += operand;
                    break;
                case Operator.Subtract:
                    result -= operand;
                    break;
                case Operator.Multiply:
                    result *= operand;
                    break;
                case Operator.Divide:
                    result /= operand;
                    break;
            }
            return new Display(r, o, operand, result);
        }
    }
}