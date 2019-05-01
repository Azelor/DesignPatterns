using System.Collections.Generic;

namespace GoF.Behavioral.Command {

    public class Calculator {

        private readonly Processor processor = new Processor();
        private readonly List<ICommand> commands = new List<ICommand>();
        private int counter;
        public Display Display { get; private set; }

        public void Redo(int levels) {
            for (var i = 0; i < levels; i++) {
                if (counter >= commands.Count - 1) continue;
                var command = commands[counter++];
                Display = command.Execute();
            }
        }

        public void Undo(int levels) {
            for (var i = 0; i < levels; i++) {
                if (counter <= 0) continue;
                var command = commands[--counter];
                Display = command.UnExecute();
            }
        }

        public void Calculate(Operator o, decimal operand) {
            ICommand command = new Command(processor, o, operand);
            Display = command.Execute();
            commands.Add(command);
            counter++;
        }
    }
}