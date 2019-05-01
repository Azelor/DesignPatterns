using System.Collections.Generic;

namespace GoF.Structural.Bridge
{
    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract string ShowRecord();
        public abstract List<string> ShowAllRecords();
    }
}