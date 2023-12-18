using Praktika_final.Properties;
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

namespace Praktika_final.Views
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose1_Click(object sender, RoutedEventArgs e)
        {
            LoginView lw = new LoginView();
            lw.Show();
            this.Close();
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=FR3Y; Database=Ratanushka82; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[User] VALUES(@Username, @Password, @Name, @LastName, @Email, 'user')";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Username", txtLogin.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtLogin.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                LoginView lp = new LoginView();
                lp.Show();
                this.Close();
            }
            catch
            {

            }
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings f1 = new Settings();
            f1.Show();
        }
    }
}
