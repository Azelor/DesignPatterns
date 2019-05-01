using System.Collections;

namespace GoF.Behavioral.Iterator {

    public class Aggregate : IAggregate<Item> {

        private readonly ArrayList items = new ArrayList();

        public IIterator<Item> CreateIterator() { return new Iterator(this); }

        public int Count
        {
            get { return items.Count; }
        }

        public Item this[int index]
        {
            get { return items[index] as Item; }
            set { items.Add(value); }
        }
    }
}