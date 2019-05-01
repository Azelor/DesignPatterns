
namespace GoF.Behavioral.Iterator {

    public interface IIterator<out T> {

        T First();

        T Next();

        bool IsDone { get; }

        T CurrentItem { get; }
        int Step { get; set; }

    }
}