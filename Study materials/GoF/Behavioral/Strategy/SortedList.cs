using System;
using System.Collections.Generic;

namespace GoF.Behavioral.Strategy
{
    public class SortedList
    {
        public List<string> List { get; } = new List<string>();

        public ISortStrategy SortStrategy { get; set; }

        public void Add(string name) {
            List.Add(name);
        }

        public void Sort() {
            SortStrategy.Sort(List);
            foreach(var name in List) {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}