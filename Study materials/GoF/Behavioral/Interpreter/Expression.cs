namespace GoF.Behavioral.Interpreter {
    public abstract class Expression
    {
        public void Interpret(Context c)
        {
            if (c.Input.Length == 0) return;
            if (c.Input.StartsWith(Nine()))
            {
                c.Output += (9 * Multiplier());
                c.Input = c.Input.Substring(2);
            }
            else if (c.Input.StartsWith(Four()))
            {
                c.Output += (4 * Multiplier());
                c.Input = c.Input.Substring(2);
            }
            else if (c.Input.StartsWith(Five()))
            {
                c.Output += (5 * Multiplier());
                c.Input = c.Input.Substring(1);
            }
            while (c.Input.StartsWith(One()))
            {
                c.Output += (1 * Multiplier());
                c.Input = c.Input.Substring(1);
            }
        }
        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }
}