using System.Data;
using System.Data.OleDb;

namespace GoF.Behavioral.TemplateMethod
{
    public class Products :DataAccessObject {

        public override void Select() {
            var sql = "select ProductName from Products";
            var dataAdapter = new OleDbDataAdapter(
                sql,connectionString);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet,"Products");
        }
        public override void Process() {
            var dataTable = dataSet.Tables["Products"];
            foreach(DataRow row in dataTable.Rows) {
                results.Add(row["ProductName"].ToString());
            }
        }
    }
}