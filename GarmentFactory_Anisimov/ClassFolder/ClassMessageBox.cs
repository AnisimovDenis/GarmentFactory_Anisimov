using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GarmentFactory_Anisimov.ClassFolder
{
    static class ClassMessageBox
    {
        public static void MessageBoxInfo(string info)
        {
            MessageBox.Show(info, "Уведмоление",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void MessageBoxError(string info)
        {
            MessageBox.Show(info, "Уведмоление",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void MessageBoxQuestionExit()
        {
            MessageBoxResult message = MessageBox.Show("Вы точно хотите выйти?", "Уведмоление",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (message)
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
            }
        }
    }
}
