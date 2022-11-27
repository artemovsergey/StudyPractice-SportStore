using SportStore.Models;
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

namespace SportStore
{
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();


            using(SportStoreContext db = new SportStoreContext())
            {
                if (user != null)
                {
                    MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name} {user.Patronymic}. \r\t");
                }
                else
                {
                    MessageBox.Show("Гость");
                }

                productlistView.ItemsSource = db.Products.ToList();

            }

        }

        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }



    }
}
