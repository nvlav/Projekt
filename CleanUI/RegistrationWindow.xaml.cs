using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace CleanUI
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        string connectionString = @"Data Source=localhost; Initial Catalog=lpDB; Integrated Security=True;";

        public RegistrationWindow()
        {
            InitializeComponent();
            
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Password == "")
                MessageBox.Show("Please fill mandatory fields");
            else if (txtPassword.Password != txtConfirmPassword.Password)
                MessageBox.Show("Password do not match");
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("Your account was successfully created");
                    Clear();
                }
            }
        }
        void Clear()
        {
            txtUsername.Text = txtPassword.Password = txtEmail.Text = txtConfirmPassword.Password = "";
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void eye_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void eye2_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
