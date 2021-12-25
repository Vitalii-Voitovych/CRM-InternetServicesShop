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

namespace CRM_InternetServicesShop.UI
{
    public partial class MainForm : Form
    {
        private ShopDbContext dbContext;
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
    }
}
