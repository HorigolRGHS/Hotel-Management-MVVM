using Assigment2_HotelManagement.Models;
using Assigment2_HotelManagement.Utilities;
using Assigment2_HotelManagement.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Assigment2_HotelManagement.ViewModels
{
    public class CustomerManagementViewModel : BaseViewModel
    {
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer != value)
                {
                    selectedCustomer = value;
                    EditedCustomer = selectedCustomer != null ? CloneCustomer(selectedCustomer) : null;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(EditedCustomerBirthday));
                }
            }
        }

        private Customer editedCustomer;
        public Customer EditedCustomer
        {
            get { return editedCustomer; }
            set
            {
                if (editedCustomer != value)
                {
                    editedCustomer = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(EditedCustomerBirthday));

                }
            }
        }



        public ObservableCollection<Customer> Customers { get; set; }

        public ICommand AddCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }
        public ICommand ClearCustomerCommand { get; set; }

        public CustomerManagementViewModel()
        {
            LoadCustomers();
            SelectedCustomer = new Customer();
            EditedCustomer = new Customer();

            AddCustomerCommand = new RelayCommand(AddCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
            ClearCustomerCommand = new RelayCommand(ClearCustomer);
        }

        private void LoadCustomers()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var customersList = context.Customers.ToList();
                Customers = new ObservableCollection<Customer>(customersList);
            }
        }

        public void AddCustomer(object param)
        {
            if (EditedCustomer != null)
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    EditedCustomer.CustomerId = 0;
                    context.Customers.Add(EditedCustomer);
                    context.SaveChanges();

                    Customers.Add(EditedCustomer);
                }

                ClearCustomer(null);
            }
        }

        public void UpdateCustomer(object param)
        {
            if (SelectedCustomer != null && EditedCustomer != null)
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var customerToUpdate = context.Customers.Find(SelectedCustomer.CustomerId);
                    if (customerToUpdate != null)
                    {
                        customerToUpdate.CustomerFullName = EditedCustomer.CustomerFullName;
                        customerToUpdate.Telephone = EditedCustomer.Telephone;
                        customerToUpdate.EmailAddress = EditedCustomer.EmailAddress;
                        customerToUpdate.CustomerBirthday = EditedCustomer.CustomerBirthday;
                        customerToUpdate.CustomerStatus = EditedCustomer.CustomerStatus;
                        customerToUpdate.Password = EditedCustomer.Password;

                        context.SaveChanges();

                        var index = Customers.IndexOf(SelectedCustomer);
                        Customers[index] = customerToUpdate;
                    }
                }
            }
        }

        public void DeleteCustomer(object param)
        {
            if (SelectedCustomer != null)
            {
                using (var context = new FuminiHotelManagementContext())
                {
                    var customerToDelete = context.Customers.Find(SelectedCustomer.CustomerId);
                    if (customerToDelete != null)
                    {
                        context.Customers.Remove(customerToDelete);
                        context.SaveChanges();

                        Customers.Remove(SelectedCustomer);
                        ClearCustomer(null);
                    }
                }
            }
        }

        public void ClearCustomer(object param)
        {
            SelectedCustomer = null;
            EditedCustomer = new Customer();
            OnPropertyChanged(nameof(SelectedCustomer));
            OnPropertyChanged(nameof(EditedCustomer));
        }

        private Customer CloneCustomer(Customer customer)
        {
            return new Customer
            {
                CustomerId = customer.CustomerId,
                CustomerFullName = customer.CustomerFullName,
                Telephone = customer.Telephone,
                EmailAddress = customer.EmailAddress,
                CustomerBirthday = customer.CustomerBirthday,
                CustomerStatus = customer.CustomerStatus,
                Password = customer.Password
            };
        }

        public DateTime? EditedCustomerBirthday
        {
            get => DateConverter.ToDateTime(EditedCustomer?.CustomerBirthday);
            set
            {
                if (EditedCustomer != null)
                {
                    EditedCustomer.CustomerBirthday = DateConverter.ToDateOnly(value);
                    OnPropertyChanged();
                }
            }
        }
    }


}
