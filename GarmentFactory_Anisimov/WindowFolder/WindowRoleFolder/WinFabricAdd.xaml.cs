using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GarmentFactory_Anisimov.WindowFolder.WindowRoleFolder
{
    /// <summary>
    /// Логика взаимодействия для WinFabricAdd.xaml
    /// </summary>
    public partial class WinFabricAdd : Window
    {
        readonly SqlConnection connection =
            new SqlConnection(@"Data Source=DENIS-PC;
                                Initial Catalog=GarmentFactory;
                                Integrated Security=True");
        SqlCommand cmd;

        public WinFabricAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            cmd = new SqlCommand("INSERT INTO [User]" +
                "VALUES (@Login, @Password, @RoleId)", connection);
            cmd.Parameters.AddWithValue("Login", tbLogin.Text);
            cmd.Parameters.AddWithValue("Password", pbPassword.Password);
            cmd.Parameters.AddWithValue("RoleId", 1);
            cmd.ExecuteNonQuery();
        }
    }
}
