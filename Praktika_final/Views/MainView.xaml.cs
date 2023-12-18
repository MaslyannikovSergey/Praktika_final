using Praktika_final.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hellouser.Visibility = Visibility.Visible;
            database.Visibility = Visibility.Hidden;
            btnRefresh.Visibility = Visibility.Hidden;
            btnReSort.Visibility = Visibility.Hidden;
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            hellouser.Visibility = Visibility.Hidden;
            database.Visibility = Visibility.Visible;
            btnRefresh.Visibility = Visibility.Visible;
            btnReSort.Visibility = Visibility.Visible;
            using (SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Товары]", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                database.ItemsSource = dataTable.DefaultView;
            }
        }

        private void goback_Click(object sender, RoutedEventArgs e)
        {
            var logv = new LoginView();
            logv.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true");
            connection.Open();
            string cmd = "SELECT * FROM [Товары]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Товары");
            dataAdp.Fill(dt);
            database.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings f1 = new Settings();
            f1.Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnReSort_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true");
            connection.Open();
            string cmd = "SELECT * FROM [Товары] order by Стоимость";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("Товары");
            dataAdp.Fill(dt);
            database.ItemsSource = dt.DefaultView;
            connection.Close();
        }
    }
}
