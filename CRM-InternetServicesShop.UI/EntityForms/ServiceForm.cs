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
    public partial class ServiceForm : Form
    {
        public Service Service { get; private set; }
        public ServiceForm()
        {
            InitializeComponent();
        }

        public ServiceForm(Service service) : this()
        {
            Service = service;
            textBoxName.Text = Service.Name;
            numericUpDownPrice.Value = Service.Price;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Service = Service ?? new Service();
            Service.Name = textBoxName.Text;
            Service.Price = numericUpDownPrice.Value;
            Close();
        }
    }
}
