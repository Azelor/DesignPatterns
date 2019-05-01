namespace GoF.Structural.Facade
{
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            return true;
        }
    }
}