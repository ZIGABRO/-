using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace project
{
    public partial class Registration : Window
    {
        private static string file_name = "logins.txt"; 

        public Registration() { InitializeComponent(); }
        static Registration() { if (!File.Exists(file_name)) File.Create(file_name); }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string login = NewLogin.Text, address = Email.Text, password = Password.Text, confirm_password = ConfirmPassword.Text;

            if (Regex.Matches(login, @"(\w+)").Count != 1)
            {
                MessageBox.Show("Incorrect login!");
                return;
            }

            if (!(address != null && new EmailAddressAttribute().IsValid(address)))
            {
                MessageBox.Show("Incorrect email!");
                return;
            }

            if (Regex.Matches(password, @"(\s+)").Count != 0)
            {
                MessageBox.Show("Incorrect password!");
                return;
            }

            if (password != confirm_password)
            {
                MessageBox.Show("Password are different!");
                return;
            }

            SaveAccount(login, password);
            Close();
        }

        private void AlreadyHave_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();

            login.Show();

            Close();
        }

        private void SaveAccount(string login, string password)
        {
            using (StreamWriter sw = new StreamWriter(file_name, true))
                sw.WriteLine(login + " : " + password);
        }
    }
}
