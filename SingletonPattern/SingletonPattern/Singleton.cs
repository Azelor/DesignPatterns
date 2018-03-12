using System.Collections.Generic;
using System.Threading;

namespace SingletonPattern
{
    public class Singleton
    {
        // Allocate memory to the singleton instance
        private static Singleton instance;
        
        // Constructor
        private Singleton() {}
        
        private readonly List<int> list = new List<int>();
        private object key = new object();
        
        // Method for accessing the singleton
        public static Singleton Instance
        {
            get
            {
                if (instance is null) instance = new Singleton();
                return instance;
            }
        }
        
        public void Add(int s)
        {
            lock (key)
            {
                if (list.Contains(s)) return;
                Thread.Sleep(100);
                list.Add(s);
            }
        }
        
        public int Count()
        {
            return list.Count;
        }

        public List<int> List()
        {
            return list;
        }
    }
}
