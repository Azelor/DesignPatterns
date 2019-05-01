using System.Collections.Generic;
namespace GoF.Creational.Singleton {

    public class ThreadSafeLogBook {
        private static ThreadSafeLogBook _instance;
        private List<string> logs;

        private static readonly object SynchronizationLock = new object();

        public static ThreadSafeLogBook Create(List<string> l) {
            ThreadSafeInstanceCreating();
            _instance.logs = l;
            return _instance;
        }

        public void Write(string log) {
            lock (SynchronizationLock) { logs.Add(log); }
        }
        public string Read(int index) {
            lock (SynchronizationLock) { return IsOutOfRange(index) ? string.Empty : logs[index]; }
        }

        private bool IsOutOfRange(int index) {
            if (index < 0) return false;
            return index < logs.Count;
        }

        private static void ThreadSafeInstanceCreating() {
            if (_instance != null) return;
            lock (SynchronizationLock) {
                if (_instance == null) { _instance = new ThreadSafeLogBook(); }
            }
        }
    }
}