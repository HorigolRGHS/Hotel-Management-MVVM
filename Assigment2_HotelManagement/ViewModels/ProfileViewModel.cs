using Assigment2_HotelManagement.Models;
using Assigment2_HotelManagement.Utilities;
using Assigment2_HotelManagement.Utils;
using System.Windows;
using System.Windows.Input;

namespace Assigment2_HotelManagement.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private Customer customer;

        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(BirthdayToDateTime));
            }
        }
        public DateTime? BirthdayToDateTime
        {
            get => DateConverter.ToDateTime(Customer.CustomerBirthday);
            set
            {
                Customer.CustomerBirthday = DateConverter.ToDateOnly(value);
                OnPropertyChanged();
            }
        }

        public ICommand UpdateProfileCommand { get; }
        public ICommand LoadProfileCommand { get; }

        public ProfileViewModel()
        {
            Customer = Application.Current.Properties["LoggedInCustomer"] as Customer;
            LoadCustomerProfile();

            UpdateProfileCommand = new RelayCommand(UpdateProfile);


        }

        private void LoadCustomerProfile()
        {
            using (var context = new FuminiHotelManagementContext())
            {

                var customerData = context.Customers.Find(Customer.CustomerId);
                if (customerData != null)
                {
                    Customer.CustomerFullName = customerData.CustomerFullName;
                    Customer.Telephone = customerData.Telephone;
                    Customer.CustomerBirthday = customerData.CustomerBirthday;
                    Customer.CustomerStatus = customerData.CustomerStatus;
                    Customer.EmailAddress = customerData.EmailAddress;
                    OnPropertyChanged(nameof(BirthdayToDateTime));
                }
                else
                {
                    MessageBox.Show("Customer data could not be loaded.");
                }
            }
        }

        private void UpdateProfile(object parameter)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var customerToUpdate = context.Customers.Find(Customer.CustomerId);
                if (customerToUpdate != null)
                {
                    customerToUpdate.CustomerFullName = Customer.CustomerFullName;
                    customerToUpdate.Telephone = Customer.Telephone;
                    customerToUpdate.CustomerBirthday = Customer.CustomerBirthday;
                    customerToUpdate.CustomerStatus = Customer.CustomerStatus;
                    customerToUpdate.EmailAddress = Customer.EmailAddress;

                    context.SaveChanges();
                    MessageBox.Show("Profile updated successfully!");
                }
                else
                {
                    MessageBox.Show("Customer not found.");
                }
            }
        }
    }
}
