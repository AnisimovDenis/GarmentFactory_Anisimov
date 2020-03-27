using GarmentFactory_Anisimov.ClassFolder;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GarmentFactory_Anisimov.WindowFolder.WindowRoleFolder
{
    /// <summary>
    /// Логика взаимодействия для WinFabric.xaml
    /// </summary>
    public partial class WinFabric : Window
    {
        readonly SqlConnection connection =
            new SqlConnection(@"Data Source=DENIS-PC;
                                Initial Catalog=GarmentFactory;
                                Integrated Security=True");
        SqlCommand cmd;
        ClassDataGrid classDataGrid;
        public WinFabric()
        {
            InitializeComponent();

            classDataGrid = new ClassDataGrid(dgFabric);
            classDataGrid.LoaderData("SELECT * FROM dbo.[Fabric]");

            btnExit.Click += delegate
            {
                ClassMessageBox.MessageBoxQuestionExit();
            };

            btnRefresh.Click += delegate
            {
                classDataGrid.LoaderData("SELECT * FROM dbo.[Fabric]");
            };
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbColumn.Text == "Наименование")
            {
                classDataGrid.LoaderData($"SELECT * FROM dbo.[Fabric] " +
                $"WHERE Name LIKE '{tbSearch.Text}%'");
            }
            else
            {
                classDataGrid.LoaderData($"SELECT * FROM dbo.[Fabric] " +
                $"WHERE ArticleNumber LIKE '{tbSearch.Text}%'");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WinFabricAdd winFabricAdd = new WinFabricAdd();
            winFabricAdd.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            App.Id = classDataGrid.Selecter();
            if (App.Id != null)
            {
                WinFabricEdit winFabricEdit = new WinFabricEdit();
                winFabricEdit.ShowDialog();
            }
            else
            {
                ClassMessageBox.MessageBoxInfo("Выберите данные для редактирования");   
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            App.Id = classDataGrid.Selecter();
            if (App.Id != null)
            {
                MessageBoxResult message = 
                        MessageBox.Show("Вы уверены, что хотите удалить?", "Уведмоление",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                switch (message)
                {
                    case MessageBoxResult.Yes:
                        try
                        {
                            connection.Open();
                            cmd = new SqlCommand("DELETE FROM [Fabric] " +
                                $"WHERE [IdFabric] = '{App.Id}'", connection);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            ClassMessageBox.MessageBoxError(ex.Message);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    break;
                }
            }
            else
            {
                ClassMessageBox.MessageBoxInfo("Выберите данные для удаления");
            }
        }
    }
}
