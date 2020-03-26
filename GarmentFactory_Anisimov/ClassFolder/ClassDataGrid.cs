using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GarmentFactory_Anisimov.ClassFolder
{
    public class ClassDataGrid
    {
        readonly SqlConnection connection =
            new SqlConnection(@"Data Source=DENIS-PC;
                                Initial Catalog=GarmentFactory;
                                Integrated Security=True");
        SqlDataAdapter adapter;
        DataTable dataTable;
        DataGrid dataGrid;

        public ClassDataGrid(DataGrid dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        public void LoaderData(string sqlCommand)
        {
            try
            {
                adapter = new SqlDataAdapter(sqlCommand, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                ClassMessageBox.MessageBoxError(ex.Message);
            }
        }
    }
}
