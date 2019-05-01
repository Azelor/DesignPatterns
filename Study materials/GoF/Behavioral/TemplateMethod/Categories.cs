using System.Data;
using System.Data.OleDb;

namespace GoF.Behavioral.TemplateMethod
{
    public class Categories : DataAccessObject {
        
        public override void Select() {
            var sql = "select CategoryName from Categories";
            var dataAdapter = new OleDbDataAdapter(
                sql,connectionString);

            dataSet = new DataSet();
            dataAdapter.Fill(dataSet,"Categories");
        }
        public override void Process() {
            var dataTable = dataSet.Tables["Categories"];
            foreach(DataRow row in dataTable.Rows) {
                results.Add(row["CategoryName"].ToString());
            }
        }
    }
}