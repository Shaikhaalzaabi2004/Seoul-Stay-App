using Microsoft.EntityFrameworkCore;
using SeoulStay.Models;
using SeoulStay.Properties;
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

namespace SeoulStay
{
    /// <summary>
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        Ih04Context db = new Ih04Context();
        List<Item> items = new List<Item>();
        User customerPassed;
        User employeePassed;
        User userSignedIn;
        public Management(int customer, int employee)
        {
            InitializeComponent();

            customerPassed = db.Users.FirstOrDefault(x => x.Id == customer);

            employeePassed = db.Users.FirstOrDefault(x => x.Id == employee);

            StyleApplier.Apply(parent);

            populateTravelerDg();
            populateOwnerDg();



            if (employee != 0)
            {
                // add employee restriction

                addBtn.IsEnabled = false;
                userSignedIn = db.Users.FirstOrDefault(x => x.Id == employee);
            }
            else
            {
                userSignedIn = db.Users.FirstOrDefault(x => x.Id == customer);
            }
        }
        private void Management_Activated(object sender, EventArgs e)
        {
            populateTravelerDg();
            populateOwnerDg();
            myTabControl_SelectionChanged(null, null);
        }

        public void populateTravelerDg()
        {
            items = new List<Item>(db.Items.Include(x=> x.Area).Include(x=> x.ItemType).Include(x=> x.ItemAttractions).ThenInclude(x=> x.Attraction).ToList());
            travelerDg.ItemsSource = items.ToList();
        }

        public void populateOwnerDg()
        {
            items = new List<Item>(db.Items.Include(x => x.Area).Include(x => x.ItemType).Include(x => x.ItemAttractions).ThenInclude(x => x.Attraction).ToList());
            ownerDg.ItemsSource = items.Where(x => x.UserId == customerPassed.Id).ToList();
        }
        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.userId = 0;
            Settings.Default.employeeId = 0;
            Settings.Default.Save();

            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void myTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(myTabControl.SelectedIndex == 0)
            {
                int itemsFound = travelerDg.Items.Count;
                itemsFoundLabel.Content = $"{itemsFound} items found";
            }
            else
            {
                int itemsFound = ownerDg.Items.Count;
                itemsFoundLabel.Content = $"{itemsFound} items found";
            }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = search.Text.ToLower();

            var searchResult = items.Where(x => x.Title.ToLower().StartsWith(searchText) || x.Area.Name.ToLower().StartsWith(searchText) || x.ItemAttractions.Any(a => a.Attraction.Name.ToLower().StartsWith(searchText) && a.Distance <= 1)).ToList();

            travelerDg.ItemsSource = searchResult;
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            addEdit addWin = new addEdit(userSignedIn);
            addWin.Show();
            this.Close();
        }

        private void editLink_Click(object sender, RoutedEventArgs e)
        {
            if(employeePassed != null)
            {
                MessageBox.Show("Employees May Not Edit Listings");
            }
            else
            {
                Item selected = ownerDg.SelectedItem as Item;
                addEdit editWin = new addEdit(userSignedIn, selected);
                editWin.Show();
                this.Close();
            }
        }
    }
}
