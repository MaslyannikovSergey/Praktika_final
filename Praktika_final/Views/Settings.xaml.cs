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

namespace Praktika_final.Views
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary lightTheme = new ResourceDictionary();
            lightTheme.Source = new Uri("Views/LightTheme.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(lightTheme);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ResourceDictionary darkTheme = new ResourceDictionary();
            darkTheme.Source = new Uri("Views/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceDictionary darkTheme = new ResourceDictionary();
            darkTheme.Source = new Uri("Views/DarkTheme.xaml", UriKind.RelativeOrAbsolute);

            ResourceDictionary lightTheme = new ResourceDictionary();
            lightTheme.Source = new Uri("Views/LightTheme.xaml", UriKind.RelativeOrAbsolute);
            if (Application.Current.Resources.MergedDictionaries.Contains(darkTheme))
            {
                // Словарь ресурсов DarkTheme.xaml установлен
                pepka.IsChecked = false; // Установить состояние CheckBox в unchecked
            }
            else if (Application.Current.Resources.MergedDictionaries.Contains(lightTheme))
            {
                // Словарь ресурсов LightTheme.xaml установлен
                pepka.IsChecked = true; // Установить состояние CheckBox в checked
            }
        }
    }
}
