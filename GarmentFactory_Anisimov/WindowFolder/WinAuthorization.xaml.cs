﻿using GarmentFactory_Anisimov.ClassFolder;
using GarmentFactory_Anisimov.WindowFolder;
using GarmentFactory_Anisimov.WindowFolder.WindowRoleFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GarmentFactory_Anisimov
{
    /// <summary>
    /// Логика взаимодействия для WinAuthorization.xaml
    /// </summary>
    public partial class WinAuthorization : Window
    {
        readonly SqlConnection connection = 
            new SqlConnection(@"Data Source=DENIS-PC;
                                Initial Catalog=GarmentFactory;
                                Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;

        public WinAuthorization()
        {
            InitializeComponent();

            btnExit.Click += delegate
            {
                ClassMessageBox.MessageBoxQuestionExit();
            };

            btnReg.Click += delegate
            {
                WinRegistration winRegistration = new WinRegistration();
                winRegistration.ShowDialog();
            };
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
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
            else
            {
                try
                {
                    connection.Open();
                    cmd = new SqlCommand("SELECT [RoleId], " +
                        "[Password] FROM [User] " +
                        $"WHERE [Login] = '{tbLogin.Text}'", connection);
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    if (reader[1].ToString() != pbPassword.Password)
                    {
                        ClassMessageBox.MessageBoxError("Не верный " +
                            "логин или пароль");
                        tbLogin.Focus();
                    }
                    else
                    {
                        App.Login = tbLogin.Text;
                        App.Password = reader[1].ToString();
                        App.Role = reader[0].ToString();

                        switch (App.Role)
                        {
                            case "1":
                                WinCustomer winCustomer = new WinCustomer();
                                winCustomer.ShowDialog();
                                break;
                            case "2":
                                WinManager winManager = new WinManager();
                                winManager.ShowDialog();
                                break;
                            case "3":
                                WinStorekeeper winStorekeeper = new WinStorekeeper();
                                winStorekeeper.ShowDialog();
                                break;
                            case "4":
                                WinDirectorate winDirectorate = new WinDirectorate();
                                winDirectorate.ShowDialog();
                                break;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    ClassMessageBox.MessageBoxError(sqlEx.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
