using System.Collections.Generic;
using System.Data;

namespace GoF.Behavioral.TemplateMethod
{
    public abstract class DataAccessObject {
        public List<string> results = new List<string>();

        protected string connectionString;
        protected DataSet dataSet;
        public virtual void Connect() {
            connectionString =
                "provider=Microsoft.JET.OLEDB.4.0; " +
                "data source=..\\..\\..\\db1.mdb";
        }
        public abstract void Select();
        public abstract void Process();
        public virtual void Disconnect() {
            connectionString = "";
        }
        public void Run() {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }
}