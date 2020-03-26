using GarmentFactory_Anisimov.ClassFolder;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace GarmentFactory_Anisimov.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для WinRegistration.xaml
    /// </summary>
    public partial class WinRegistration : Window
    {
        readonly SqlConnection connection =
            new SqlConnection(@"Data Source=DENIS-PC;
                                Initial Catalog=GarmentFactory;
                                Integrated Security=True");
        SqlCommand cmd;

        public WinRegistration()
        {
            InitializeComponent();

            btnBack.Click += delegate
            {
                WinAuthorization winAuthorization = new WinAuthorization();
                winAuthorization.Show();
                this.Close();
            };

            btnExit.Click += delegate
            {
                ClassMessageBox.MessageBoxQuestionExit();
            };
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text))
            {
                ClassMessageBox.MessageBoxInfo("Введите логин");
                tbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(pbPassword.Password))
            {
                ClassMessageBox.MessageBoxInfo("Введите пароль");
                pbPassword.Focus();
            }
            else if (string.IsNullOrEmpty(pbPasswordSecond.Password))
            {
                ClassMessageBox.MessageBoxInfo("Введите пароль");
                pbPassword.Focus();
            }
            else if (pbPassword.Password != pbPasswordSecond.Password)
            {
                ClassMessageBox.MessageBoxInfo("Введенные пароли не совпадают");
                pbPassword.Focus();
            }
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand("INSERT INTO [User]" +
                        "VALUES (@Login, @Password, @RoleId)", connection);
                    cmd.Parameters.AddWithValue("Login", tbLogin.Text);
                    cmd.Parameters.AddWithValue("Password", pbPassword.Password);
                    cmd.Parameters.AddWithValue("RoleId", 1);
                    cmd.ExecuteNonQuery();
                    ClassMessageBox.MessageBoxInfo("Вы успешно зарегистрировались");
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
