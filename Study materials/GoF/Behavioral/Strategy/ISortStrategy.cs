using System.Collections.Generic;

namespace GoF.Behavioral.Strategy
{
    public interface ISortStrategy {
        void Sort(List<string> list);
    }
}