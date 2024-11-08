using Assigment2_HotelManagement.AdminView;
using Assigment2_HotelManagement.CustomerView;
using Assigment2_HotelManagement.Models;
using Assigment2_HotelManagement.Utilities;

using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Assigment2_HotelManagement.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IConfigurationRoot configuration;

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory) // Ensures it starts in the application's directory
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Set optional to false to ensure it's required
            configuration = builder.Build();  //Build the configuration

            LoginCommand = new RelayCommand(Login);
        }


        private void Login(object parameter)
        {

            string adminEmail = configuration.GetSection("Admin:Email").Value;
            string adminPassword = configuration.GetSection("Admin:Password").Value;


            Customer customer = CheckCustomerCredentials(Email, Password);

            if (customer != null)
            {
                Application.Current.Properties["LoggedInCustomer"] = customer;
                MessageBox.Show("Welcome Customer");
                var windowCustomer = new WindowCustomer();
                windowCustomer.Show();
                Application.Current.Windows[0]?.Close();
            }
            else if (Email.Equals(adminEmail) && Password.Equals(adminPassword))
            {
                MessageBox.Show("Welcome admin");
                var windowAdmin = new WindowAdmin();
                windowAdmin.Show();
                Application.Current.Windows[0]?.Close();
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private Customer CheckCustomerCredentials(string email, string password)
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.EmailAddress == email && c.Password == password);

                return customer;
            }
        }
    }
}
