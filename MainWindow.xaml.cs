using SeoulStay.Models;
using SeoulStay.Properties;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeoulStay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ih04Context db = new Ih04Context();
        List<User> users = new List<User>();
        int savedCustomerId;
        int savedEmployeeId;
        public MainWindow()
        {
            InitializeComponent();
            StyleApplier.Apply(parent);

            savedEmployeeId = Settings.Default.employeeId;
            savedCustomerId = Settings.Default.userId;

            if(savedCustomerId != 0)
            {
                if (savedEmployeeId != 0)
                {
                    Management managementEmployee = new Management(savedCustomerId, savedEmployeeId);
                    managementEmployee.Show();
                    this.Close();
                }
                Management managementUser = new Management(savedCustomerId, 0);
                managementUser.Show();
                this.Close();
            }
            
        }

        private void showPass_Click(object sender, RoutedEventArgs e)
        {
            if(passInp.Visibility == Visibility.Visible)
            {
                var passValue = passInp.Password;
                passInp.Visibility = Visibility.Collapsed;
                visiblePass.Visibility = Visibility.Visible;
                visiblePass.Text = passValue;
            }
            else
            {
                var passValue = visiblePass.Text;
                passInp.Visibility = Visibility.Visible;
                visiblePass.Visibility = Visibility.Collapsed;
                passInp.Password = passValue;
            }
        }
        private bool checkFields()
        {
            if(string.IsNullOrEmpty(userInp.Text) || string.IsNullOrEmpty(passInp.Password.ToString()))
            {
                return false;
            } 
            return true;
        }
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!checkFields())
            {
                MessageBox.Show("Please Input All Required Fields");
            } else if (string.IsNullOrEmpty(employeeInp.Text))
            {
                // attempt to login as user
                User validUser = db.Users.FirstOrDefault(x=> x.Username == userInp.Text && x.Password == passInp.Password.ToString());

                if(validUser == null)
                {
                    MessageBox.Show("Invalid Credentials");
                }
                else
                {
                    if ((bool)keepMeSignedInCb.IsChecked)
                    {
                        Settings.Default.userId = (int) validUser.Id;
                        Settings.Default.Save();

                        Management management = new Management((int)validUser.Id, 0);
                        management.Show();
                        this.Close();
                    }
                    else
                    {
                        Management management = new Management((int)validUser.Id, 0);
                        management.Show();
                        this.Close();
                        // login as user
                    }
                }
            }
            else
            {
                User validEmployee = db.Users.FirstOrDefault(x => x.Username == employeeInp.Text && x.Password == passInp.Password.ToString());
                User employeeUser = db.Users.FirstOrDefault(x => x.Username == userInp.Text);
                // attempt to login as employee

                if (validEmployee == null)
                {
                    MessageBox.Show("Invalid Credentials");
                }
                else
                {
                    if ((bool)keepMeSignedInCb.IsChecked)
                    {
                        Settings.Default.userId = (int)employeeUser.Id;
                        Settings.Default.employeeId = (int)validEmployee.Id;
                        Settings.Default.Save();

                        Management managementEmployee = new Management((int)employeeUser.Id, (int)validEmployee.Id);
                        managementEmployee.Show();
                        this.Close();
                    }
                    else
                    {
                        // login as employee
                        Management managementEmployee = new Management((int)employeeUser.Id, (int) validEmployee.Id);
                        managementEmployee.Show();
                        this.Close();
                    }
                }
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createAccLink_Click(object sender, RoutedEventArgs e)
        {
            createAccount createWin = new createAccount();
            createWin.Show();
            this.Close();
        }
    }
}

