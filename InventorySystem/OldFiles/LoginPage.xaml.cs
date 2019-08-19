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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        
        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(MainWindow.mainPage);
            /*
            var conn = new MainWindow.DBConnect();

            List<string>[] admins = conn.GetAdmin();

            foreach (var admin in admins)
            {
                if (uid.Text == admin[1])
                {
                    if (pass.Password == admin[2])
                    {
                        this.NavigationService.Navigate(MainWindow.loginPage);
                    }
                }
            }
            */
        }
        
    }
}
