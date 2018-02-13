using System.Collections.Generic;
using System.Threading;

namespace Singelton
{
    public class NewSingleton
    {
        private static NewSingleton instance;
        private NewSingleton(){}
        private object key = new object();
        private readonly List<string> list = new List<string>();
        public static NewSingleton Instance
        {
            get
            {
                if (instance is null) instance = new NewSingleton();
                return instance;
            }
        }

        public void Add(string s)
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

        public List<string> List()
        {
            return list;
        }
    }
}