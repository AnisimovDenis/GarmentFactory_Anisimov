using GarmentFactory_Anisimov.ClassFolder;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WinFabric.xaml
    /// </summary>
    public partial class WinFabric : Window
    {
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
    }
}
