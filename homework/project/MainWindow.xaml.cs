using System.Windows;

namespace project
{
    public partial class MainWindow : Window
    {
        public MainWindow() { InitializeComponent(); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();

            login.Show();
        }
    }
}
