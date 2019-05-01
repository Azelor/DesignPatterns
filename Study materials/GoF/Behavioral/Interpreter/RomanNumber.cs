using System.Collections.Generic;
namespace GoF.Behavioral.Interpreter
{
    public class RomanNumber
    {
        private readonly List<Expression> interpreters = new List<Expression> {
            new ThousandExpression(),
            new HundredExpression(),
            new TenExpression(),
            new OneExpression()
        };
        private Context context;
        private readonly string value;
        public RomanNumber(string romanNumber) {
            value = romanNumber;
        }

        public int ToArabic() {
            context = new Context(value);
            foreach (var i in interpreters) i.Interpret(context);
            return context.Output;
        }
    }
}
