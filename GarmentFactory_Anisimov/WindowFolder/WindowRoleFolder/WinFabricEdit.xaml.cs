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
    /// Логика взаимодействия для WinFabricEdit.xaml
    /// </summary>
    public partial class WinFabricEdit : Window
    {
        readonly SqlConnection connection =
            new SqlConnection(@"Data Source=DENIS-PC;
                                Initial Catalog=GarmentFactory;
                                Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        public WinFabricEdit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.Open();
                cmd = new SqlCommand("SELECT ArticleNumber, Name, Color, Drawing, " +
                        "Composition, Width, Length, Price FROM [Fabric] " +
                        $"WHERE IdFabric = {App.Id}", connection);
                reader = cmd.ExecuteReader();
                reader.Read();
                tbArticle.Text = reader[0].ToString();
                tbName.Text = reader[1].ToString();
                tbColor.Text = reader[2].ToString();
                tbDrawing.Text = reader[3].ToString();
                tbComposition.Text = reader[4].ToString();
                tbWidth.Text = reader[5].ToString();
                tbLength.Text = reader[6].ToString();
                tbPrice.Text = reader[7].ToString();
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
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
                    cmd = new SqlCommand("UPDATE [Fabric] " +
                        "SET ArticleNumber = @ArticleNumber, " +
                        "Name = @Name," +
                        "Color = @Color," +
                        "Drawing = @Drawing," +
                        "Composition = @Composition, " +
                        "Width = @Width," +
                        "Length = @Length," +
                        "Price = @Price " +
                        $"WHERE [IdFabric] = {App.Id}", connection);
                    cmd.Parameters.AddWithValue("ArticleNumber", tbArticle.Text);
                    cmd.Parameters.AddWithValue("Name", tbName.Text);
                    cmd.Parameters.AddWithValue("Color", tbColor.Text);
                    cmd.Parameters.AddWithValue("Drawing", tbDrawing.Text);
                    cmd.Parameters.AddWithValue("Composition", tbComposition.Text);
                    cmd.Parameters.AddWithValue("Width", tbWidth.Text);
                    cmd.Parameters.AddWithValue("Length", tbLength.Text);
                    cmd.Parameters.AddWithValue("Price", double.Parse(tbPrice.Text));
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
