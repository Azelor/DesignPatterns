namespace GoF.Behavioral.Iterator {
    public class Iterator : IIterator<Item> {

        private readonly IAggregate<Item> aggregate;
        private int current;

        public Iterator(IAggregate<Item> c) { aggregate = c; }

        public Item First() {
            current = 0;
            return CurrentItem;
        }

        public Item Next() {
            current += Step;
            return CurrentItem;
        }

        public int Step { get; set; }

        public Item CurrentItem
        {
            get { return !IsDone ? aggregate[current] : null; }
        }

        public bool IsDone
        {
            get { return current >= aggregate.Count; }
        }
    }
}
