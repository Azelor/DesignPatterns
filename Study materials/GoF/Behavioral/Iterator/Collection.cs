
namespace GoF.Behavioral.Iterator
{
    public class Collection
    {
        private readonly IIterator<Item> iterator;
        private readonly IAggregate<Item> aggregate;

        public Collection() {
            aggregate = new Aggregate();
            iterator = new Iterator(aggregate);
        }

        public int Step
        {
            get { return iterator.Step; }
            set { iterator.Step = value; }
        }

        public bool IsDone
        {
            get { return iterator.IsDone; }
        }

        public void Add(Item i) {
            aggregate[aggregate.Count] = i;
        }

        public Item First() {
            return iterator.First();
        }

        public Item CurrentItem() {
            return iterator.CurrentItem;
        }

        public Item Next() {
            return iterator.Next();
        }
    }
}
