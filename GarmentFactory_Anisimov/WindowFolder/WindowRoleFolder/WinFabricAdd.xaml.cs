using GarmentFactory_Anisimov.ClassFolder;
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
            if (string.IsNullOrEmpty(tbArticle.Text))
            {
                ClassMessageBox.MessageBoxError("Введите артикул");
                tbArticle.Focus();
            }
            else if (string.IsNullOrEmpty(tbColor.Text))
            {
                ClassMessageBox.MessageBoxError("Введите цвет");
                tbColor.Focus();
            }
            else if (string.IsNullOrEmpty(tbComposition.Text))
            {
                ClassMessageBox.MessageBoxError("Введите композицию");
                tbComposition.Focus();
            }
            else if (string.IsNullOrEmpty(tbDrawing.Text))
            {
                ClassMessageBox.MessageBoxError("Введите узор");
                tbDrawing.Focus();
            }
            else if (string.IsNullOrEmpty(tbLength.Text))
            {
                ClassMessageBox.MessageBoxError("Введите длину");
                tbLength.Focus();
            }
            else if (string.IsNullOrEmpty(tbName.Text))
            {
                ClassMessageBox.MessageBoxError("Введите наименование");
                tbName.Focus();
            }
            else if (string.IsNullOrEmpty(tbPrice.Text))
            {
                ClassMessageBox.MessageBoxError("Введите цену");
                tbPrice.Focus();
            }
            else if (string.IsNullOrEmpty(tbWidth.Text))
            {
                ClassMessageBox.MessageBoxError("Введите ширину");
                tbWidth.Focus();
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand("INSERT INTO [Fabric] " +
                        "(ArticleNumber, Name, Color, Drawing, " +
                        "Composition, Width, Length, Price)" +
                        "VALUES (@ArticleNumber, @Name," +
                        " @Color, @Drawing, @Composition, " +
                        "@Width, @Length, @Price)", connection);
                    cmd.Parameters.AddWithValue("ArticleNumber", tbArticle.Text);
                    cmd.Parameters.AddWithValue("Name", tbName.Text);
                    cmd.Parameters.AddWithValue("Color", tbColor.Text);
                    cmd.Parameters.AddWithValue("Drawing", tbDrawing.Text);
                    cmd.Parameters.AddWithValue("Composition", tbComposition.Text);
                    cmd.Parameters.AddWithValue("Width", tbWidth.Text);
                    cmd.Parameters.AddWithValue("Length", tbLength.Text);
                    cmd.Parameters.AddWithValue("Price", tbPrice.Text);
                    cmd.ExecuteNonQuery();
                    ClassMessageBox.MessageBoxInfo("Вы успешно добавили товар");
                }
                catch (Exception ex)
                {
                    ClassMessageBox.MessageBoxError(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
