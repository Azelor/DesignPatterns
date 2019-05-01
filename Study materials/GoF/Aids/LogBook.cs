
namespace GoF.Aids {
    public class LogBook : ILogBook {
        private string log;
        public void WriteLine(string s) { log = s; }

        public string ReadLine() { return log; }

    }
}
