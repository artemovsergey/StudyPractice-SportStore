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
                    statusUser.Text = user.RoleNavigation.Name;
                    //MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name} {user.Patronymic}. \r\t");
                }
                else
                {
                    statusUser.Text = "Гость";
                    //MessageBox.Show("Гость");
                }

                productlistView.ItemsSource = db.Products.ToList();

                List<string> sortList = new List<string>() { "По возрастанию цены", "По убыванию цены" };
                sortUserComboBox.ItemsSource = sortList.ToList();

                List<string> filtertList = db.Products.Select(u => u.Manufacturer).Distinct().ToList();
                filtertList.Insert(0, "Все производители");
                filterUserComboBox.ItemsSource = filtertList.ToList();

            }

        }


        private void sortUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SportStoreContext db = new SportStoreContext())
            {
                if (sortUserComboBox.SelectedValue == "По убыванию цены")
                {
                    productlistView.ItemsSource = db.Products.OrderByDescending(u => u.Cost).ToList();
                }

                if (sortUserComboBox.SelectedValue == "По возрастанию цены")
                {
                    productlistView.ItemsSource = db.Products.OrderBy(u => u.Cost).ToList();
                }
            }
        }


        private void filterUserComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (SportStoreContext db = new SportStoreContext())
            {
                if (db.Products.Select(u => u.Manufacturer).Distinct().ToList().Contains(filterUserComboBox.SelectedValue) )
                {
                    productlistView.ItemsSource = db.Products.Where(u => u.Manufacturer == filterUserComboBox.SelectedValue).ToList();
                }
                else
                {
                    productlistView.ItemsSource = db.Products.ToList();
                }
            }
        }


        private void exitButtonClick(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            this.Close();
        }



    }
}
