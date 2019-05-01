using System.Collections.Generic;

namespace GoF.Behavioral.Strategy
{
    public class QuickSort :ISortStrategy {

        public void Sort(List<string> list) {
            list.Sort(); // Default is Quicksort
        }
    }
}