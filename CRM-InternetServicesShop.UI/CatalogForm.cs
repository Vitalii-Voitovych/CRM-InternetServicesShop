using CRM_InternetServicesShop.BL.Controller;
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
    public partial class CatalogForm<T> : Form
        where T: class
    {
        private readonly EntityController<T> controller;
        public CatalogForm(ShopDbContext dbContext)
        {
            InitializeComponent();
            controller = new EntityController<T>(dbContext);
            dataGridView.DataSource = controller.GetData();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            switch (typeof(T).Name)
            {
                case "Customer":
                    var customerForm = new CustomerForm();
                    if (customerForm.ShowDialog() == DialogResult.OK)
                    {
                        controller.AddRecord(customerForm.Customer as T);
                        dataGridView.Update();
                    }
                    break;
                case "Service":
                    var serviceForm = new ServiceForm();
                    if (serviceForm.ShowDialog() == DialogResult.OK)
                    {
                        controller.AddRecord(serviceForm.Service as T);
                        dataGridView.Update();
                    }
                    break;
                default:
                    break;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            switch (typeof(T).Name)
            {
                case "Customer":
                    var customer = controller.Find(id);
                    controller.RemoveRecord(customer);
                    dataGridView.Update();
                    break;
                case "Service":
                    var service = controller.Find(id);
                    controller.RemoveRecord(service);
                    dataGridView.Update();
                    break;
                default:
                    break;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;
            switch (typeof(T).Name)
            {
                case "Customer":
                    var customer = controller.Find(id);
                    var customerForm = new CustomerForm(customer as Customer);
                    if (customerForm.ShowDialog() == DialogResult.OK)
                    {
                        controller.Update();
                        dataGridView.Update();
                    }
                    break;
                case "Service":
                    var service = controller.Find(id);
                    var serviceForm = new ServiceForm(service as Service);
                    if (serviceForm.ShowDialog() == DialogResult.OK)
                    {
                        controller.Update();
                        dataGridView.Update();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
