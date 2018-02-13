using System.Collections.Generic;
using System.Threading;

namespace Singelton
{
    public class NewSingleton
    {
        private static NewSingleton instance = new NewSingleton();
        private NewSingleton(){}
        private object key = new object();
        private readonly List<string> list = new List<string>();
        public static NewSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void Add(string s)
        {
            lock (key)
            {
                if (list.Contains(s)) return;
                Thread.Sleep(1000);
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