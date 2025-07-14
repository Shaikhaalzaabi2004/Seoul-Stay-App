using SeoulStay.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for createAccount.xaml
    /// </summary>
    public partial class createAccount : Window
    {
        bool termsViewed = false;
        Ih04Context db = new Ih04Context();
        public createAccount()
        {
            InitializeComponent();
            StyleApplier.Apply(parent);
        }

        private void termsLink_Click(object sender, RoutedEventArgs e)
        {
            var termsDirectory = Directory.GetCurrentDirectory() + "/Terms.txt";
            Process.Start("Notepad.exe", termsDirectory);
            termsCb.IsEnabled = true;
        }

        public bool checkFields()
        {
            if(string.IsNullOrEmpty(usernameInp.Text)||
                string.IsNullOrEmpty(fullName.Text)||
                string.IsNullOrEmpty(pass1.Password.ToString())||
                string.IsNullOrEmpty(pass2.Password.ToString())||
                string.IsNullOrEmpty(numOfFamily.Text)||
                birthday.SelectedDate == null
                )
            {
                return false;

                if(maleRadio.IsChecked == false && femalwRadio.IsChecked == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            var duplicateUser = db.Users.FirstOrDefault(x => x.Username == usernameInp.Text);

            if (!checkFields())
            {
                MessageBox.Show("Please Input All Fields");

            } else if(pass1.Password.ToString() != pass2.Password.ToString())
            {
                MessageBox.Show("Passwords Do Not Match");
            } else if(pass1.Password.ToString().Length < 5)
            {
                MessageBox.Show("Passwords Must Be At Least 5 Characters Long");
            } else if(termsCb.IsChecked != true)
            {
                MessageBox.Show("Please Agree To Terms");
            }else if( duplicateUser != null ){
                MessageBox.Show("User Already Exists");
            }
            else
            {
                var newUser = new User()
                {
                    Guid = Guid.NewGuid(),
                    UserTypeId = 2,
                    Username = usernameInp.Text,
                    Password = pass1.Password.ToString(),
                    FullName = fullName.Text,
                    Gender = (bool)femalwRadio.IsChecked,
                    BirthDate = DateOnly.Parse(birthday.SelectedDate.ToString().Split(" ")[0]),
                    FamilyCount = int.Parse(numOfFamily.Text)
                };

                db.Users.Add(newUser);
                db.SaveChanges();
                MessageBox.Show("Registered Successfully");

                Management newUserManagement = new Management((int) newUser.Id, 0);
                newUserManagement.Show();
                this.Close();
                //
            }
        }

        private void returnBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();    
            login.Show();
            this.Close();
        }

    }
}
