﻿using GarmentFactory_Anisimov.ClassFolder;
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
    /// Логика взаимодействия для WinCustomer.xaml
    /// </summary>
    public partial class WinCustomer : Window
    {
        public WinCustomer()
        {
            InitializeComponent();

            btnExit.Click += delegate
            {
                ClassMessageBox.MessageBoxQuestionExit();
            };
        }
    }
}
