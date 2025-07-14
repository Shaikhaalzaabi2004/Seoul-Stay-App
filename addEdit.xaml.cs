using Microsoft.EntityFrameworkCore;
using SeoulStay.Models;
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
    /// Interaction logic for addEdit.xaml
    /// </summary>
    public partial class addEdit : Window
    {
        Item itemToEdit;
        Item itemAdded;
        Ih04Context db = new Ih04Context();
        User user;



        public addEdit(User userSignedIn, Item itemPassed = null)
        {
            InitializeComponent();
            StyleApplier.Apply(parent);
            user = userSignedIn;
            typeCb.Items.Add("Apartment");
            typeCb.Items.Add("House");
            typeCb.Items.Add("Secondary unit");
            typeCb.Items.Add("Unique space");
            typeCb.Items.Add("Boutique hotel");

            if(itemPassed != null)
            {
                itemToEdit = itemPassed;

                typeCb.SelectedItem = itemPassed.ItemType.Name;
                title.Text = itemPassed.Title;
                capacity.Text = itemPassed.Capacity.ToString();
                beds.Text = itemPassed.NumberOfBeds.ToString();
                bedrooms.Text = itemPassed.NumberOfBedrooms.ToString();
                bathrooms.Text = itemPassed.NumberOfBathrooms.ToString();
                aproxAddress.Text = itemPassed.ApproximateAddress.ToString();
                exactAddress.Text = itemPassed.ExactAddress.ToString();
                desc.Text = itemPassed.Description.ToString();
                hostRules.Text = itemPassed.HostRules.ToString();
                min.Text = itemPassed.MinimumNights.ToString();
                max.Text = itemPassed.MaximumNights.ToString();
            }

        }

 
        
     
        public void saveItemInformation()
        {
            if(itemToEdit!= null)
            {
                // save editted info
                if (checkItemInformation())
                {

                        var itemFromDb = db.Items.Include(x => x.ItemType).FirstOrDefault(x => x.Id == itemToEdit.Id);
                        itemFromDb.ItemType.Name = typeCb.SelectedItem.ToString();
                        itemFromDb.Title = title.Text;
                        itemFromDb.Capacity = int.Parse(capacity.Text);
                        itemFromDb.NumberOfBeds = int.Parse(beds.Text);
                        itemFromDb.NumberOfBedrooms = int.Parse(bedrooms.Text);
                        itemFromDb.NumberOfBathrooms = int.Parse(bathrooms.Text);
                        itemFromDb.ApproximateAddress = aproxAddress.Text;
                        itemFromDb.ExactAddress = exactAddress.Text;
                        itemFromDb.Description = desc.Text;
                        itemFromDb.HostRules = hostRules.Text;
                        itemFromDb.MinimumNights = int.Parse(min.Text);
                        itemFromDb.MaximumNights = int.Parse(max.Text);

                        db.SaveChanges();
                        MessageBox.Show("Item Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Please Input All Fields");
                }
            }
            else 
            {
                // create new item
                if (checkItemInformation())
                {
                        Item newItem = new Item()
                        {
                            Guid = new Guid(),
                            UserId = user.Id,
                            ItemTypeId = db.ItemTypes.FirstOrDefault(x => x.Name == typeCb.SelectedItem.ToString()).Id,
                            AreaId = 1,
                            Title = title.Text,
                            Capacity = int.Parse(capacity.Text),
                            NumberOfBeds = int.Parse(beds.Text),
                            NumberOfBedrooms = int.Parse(bedrooms.Text),
                            NumberOfBathrooms = int.Parse(bathrooms.Text),
                            ExactAddress = exactAddress.Text,
                            ApproximateAddress = aproxAddress.Text,
                            Description = desc.Text,
                            HostRules = hostRules.Text,
                            MinimumNights = int.Parse(min.Text),
                            MaximumNights = int.Parse(max.Text)
                        };

                        db.Items.Add(newItem);
                        db.SaveChanges();
                        MessageBox.Show("Item Added Successfully");
                        itemAdded = newItem;
                    }
                    else
                    {
                        MessageBox.Show("Please Input All Fields");
                    }
                }
            }

        public bool checkItemInformation()
        {
            if(typeCb.SelectedItem == null ||
                string.IsNullOrEmpty(title.Text) ||
                string.IsNullOrEmpty(capacity.Text) ||
                string.IsNullOrEmpty(beds.Text) ||
                string.IsNullOrEmpty(bedrooms.Text) ||
                string.IsNullOrEmpty(bathrooms.Text) ||
                string.IsNullOrEmpty(aproxAddress.Text) ||
                string.IsNullOrEmpty(exactAddress.Text) ||
                string.IsNullOrEmpty(desc.Text) ||
                string.IsNullOrEmpty(hostRules.Text) ||
                string.IsNullOrEmpty(min.Text) ||
                string.IsNullOrEmpty(max.Text))
            {
                MessageBox.Show("Listing Details Missing Information");
                return false;
            } else if (int.Parse(capacity.Text)< 0 || int.Parse(beds.Text) < 0 || int.Parse(bathrooms.Text) < 0 || int.Parse(bedrooms.Text) < 0)
            {
                MessageBox.Show("Invalid Field Inputs");
                return false;
            } else if(int.Parse(min.Text)<0 || int.Parse(max.Text)<0 || int.Parse(min.Text) > int.Parse(max.Text))
            {
                MessageBox.Show("Invalid Reservation Time");
                return false;
            }

            return true;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            saveItemInformation();
            Management management = new Management((int)user.Id, 0);
            management.Show();
            this.Close();
        }
    }
}
