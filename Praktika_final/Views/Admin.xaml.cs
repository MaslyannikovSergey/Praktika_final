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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
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
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            database.Visibility = Visibility.Visible;
            stackusers.Visibility = Visibility.Hidden;
            stackproduct.Visibility = Visibility.Hidden;
            pervih1.Visibility = Visibility.Hidden;
            pervih2.Visibility = Visibility.Visible;
            using (SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [User]", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                database.ItemsSource = dataTable.DefaultView;
            }

        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
            Settings f1 = new Settings();
            f1.Show();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            database.Visibility = Visibility.Visible;
            stackusers.Visibility = Visibility.Hidden;
            stackproduct.Visibility = Visibility.Hidden;
            pervih2.Visibility = Visibility.Visible;
            pervih1.Visibility = Visibility.Hidden;
            using (SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [User]", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                database.ItemsSource = dataTable.DefaultView;
            }
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            database.Visibility = Visibility.Visible;
            stackusers.Visibility = Visibility.Hidden;
            stackproduct.Visibility = Visibility.Hidden;
            pervih2.Visibility = Visibility.Hidden;
            pervih1.Visibility = Visibility.Visible;
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

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            database.Visibility = Visibility.Hidden;
            stackusers.Visibility = Visibility.Visible;
            stackproduct.Visibility = Visibility.Visible;
            pervih2.Visibility = Visibility.Hidden;
            pervih1.Visibility = Visibility.Hidden;
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            var Log = new LoginView();
            this.Close();
            Log.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (database.SelectedItem != null && database.SelectedItem is DataRowView)
            {
                DataRowView row = (DataRowView)database.SelectedItem;
                int userId = Convert.ToInt32(row["Id"]);
                Delete_User(userId);
            }
        }

        private void Delete_User(int Id)
        {
            SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true");
            string cmd = "DELETE FROM [User] WHERE Id = @Id";
            SqlCommand deleteCommand = new SqlCommand(cmd, connection);
            deleteCommand.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Delete_Product(int Id)
        {
            SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true");
            string cmd = "DELETE FROM [Товары] WHERE IDТовара = @Id";
            SqlCommand deleteCommand = new SqlCommand(cmd, connection);
            deleteCommand.Parameters.AddWithValue("@Id", Id);

            try
            {
                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true");
            connection.Open();
            string cmd = "SELECT * FROM [User]";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("User");
            dataAdp.Fill(dt);
            database.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void btnDelete1_Click(object sender, RoutedEventArgs e)
        {
            if (database.SelectedItem != null && database.SelectedItem is DataRowView)
            {
                DataRowView row = (DataRowView)database.SelectedItem;
                int prodId = Convert.ToInt32(row["IDТовара"]);
                Delete_Product(prodId);
            }
        }

        private void btnRefresh1_Click(object sender, RoutedEventArgs e)
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

        private void AddAdminUsers_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtLastName.Text))
            {
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=FR3Y; Database=Ratanushka82; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[User] VALUES(@Username, @Password, @Name, @LastName, @Email, @Primery)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Username", txtLogin.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Primery", cmbb.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtLogin.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
                cmbb.Text = "";
                var f2 = new AddZapis();
                f2.Show();
            }
            catch
            {

            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTovarName.Text) || string.IsNullOrEmpty(txtProducer.Text) || string.IsNullOrEmpty(txtPrice.Text))
            {
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Server=FR3Y; Database=Ratanushka82; Integrated Security=True");
                con.Open();
                string add_data = "INSERT INTO [dbo].[Товары] VALUES(@Наименование, @Производитель, @Стоимость)";
                SqlCommand cmd = new SqlCommand(add_data, con);

                cmd.Parameters.AddWithValue("@Наименование", txtTovarName.Text);
                cmd.Parameters.AddWithValue("@Производитель", txtProducer.Text);
                cmd.Parameters.AddWithValue("@Стоимость", txtPrice.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                txtTovarName.Text = "";
                txtProducer.Text = "";
                txtPrice.Text = "";
                var f2 = new AddZapis();
                f2.Show();
            }
            catch
            {

            }
        }

        private void btnReSort_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Server=FR3Y; Database= Ratanushka82; Integrated Security=true");
            connection.Open();
            string cmd = "SELECT * FROM [User] order by Username";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("User");
            dataAdp.Fill(dt);
            database.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void btnReSort1_Click(object sender, RoutedEventArgs e)
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
