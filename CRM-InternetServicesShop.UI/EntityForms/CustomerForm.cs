using CRM_InternetServicesShop.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_InternetServicesShop.UI.EntityForms
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; private set; }
        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer customer) : this()
        {
            Customer = customer;
            textBoxFullName.Text = Customer.FullName;
            textBoxPhone.Text = Customer.Phone;
            textBoxEmail.Text = Customer.Email;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new Customer();
            Customer.FullName = textBoxFullName.Text;
            Customer.Phone = textBoxPhone.Text.PhoneValidation();
            Customer.Email = textBoxEmail.Text.EmailValidation();
            Close();
        }
    }
}
