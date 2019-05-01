using GoF.Behavioral.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Behavioral {

    [TestClass] public class CommandTests {

        private Calculator calculator;

        [TestInitialize] public void Initialize() {
            calculator = new Calculator();
            calculator.Calculate(Operator.Add, 100);
            calculator.Calculate(Operator.Subtract, 50);
            calculator.Calculate(Operator.Multiply, 10);
            calculator.Calculate(Operator.Divide, 2);
        }

        [TestMethod] public void ResultTest() { Assert.AreEqual(250, calculator.Display.Result); }

        [TestMethod] public void UndoTest() {
            calculator.Undo(4);
            Assert.AreEqual(0, calculator.Display.Result);
        }
        [TestMethod] public void RedoAfterUndoTest() {
            calculator.Undo(4);
            calculator.Redo(3);
            Assert.AreEqual(500, calculator.Display.Result);
        }
        [TestMethod] public void RedoWithoutUndoTest() {
            calculator.Redo(3);
            Assert.AreEqual(250, calculator.Display.Result);
        }
    }
}