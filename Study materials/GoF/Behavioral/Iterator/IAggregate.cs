namespace GoF.Behavioral.Iterator {

    public interface IAggregate<T> {

        IIterator<T> CreateIterator();

        int Count { get; }

        T this[int index] { get; set; }

    }
}