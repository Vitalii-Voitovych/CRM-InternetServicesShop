using CRM_InternetServicesShop.BL.Model;
using CRM_InternetServicesShop.UI.EntityForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_InternetServicesShop.UI
{
    public partial class MainForm : Form
    {
        private Customer customer; 
        private ShopDbContext dbContext;
        private Cart cart;
        public MainForm()
        {
            InitializeComponent();
            dbContext = new ShopDbContext();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogForm<Customer>(dbContext);
            form.Show();
        }

        private void ServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogForm<Service>(dbContext);
            form.Show();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogForm<Order>(dbContext);
            form.Show();
        }

        private void PaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CatalogForm<Payment>(dbContext);
            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm();
            while (true)
            {
                if (customerForm.ShowDialog() == DialogResult.OK)
                {
                    customer = dbContext.Customers.FirstOrDefault(
                        c => c.FullName.Equals(customerForm.Customer.FullName));
                    if (customer != null)
                    {
                        label2.Text = $"Вітаємо, {customer.FullName}";
                        break;
                    }
                }
            }
            cart = new Cart(customer);
            Task.Run(() =>
            {
                listBoxServices.Invoke((Action)delegate
                {
                    listBoxServices.Items.AddRange(dbContext.Services.ToArray());
                });
            });
        }

        private void ListBoxServices_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxServices.SelectedItem is Service service)
            {
                cart.Add(service);
                listBoxCart.Items.Add(service);
                UpdatePrice();
            }
        }

        private void ListBoxCart_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxCart.SelectedItem is Service service)
            {
                cart.Remove(service);
                listBoxCart.Items.Remove(service);
                UpdatePrice();
            }
        }

        private void UpdatePrice()
        {
            label3.Text = $"До оплати : ${cart.Price}";
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            var order = new Order()
            {
                CustomerId = customer.CustomerId,
                Date = DateTime.Now
            };


        }

    }
}
