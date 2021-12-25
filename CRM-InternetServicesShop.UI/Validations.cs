using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_InternetServicesShop.UI
{
    public static class Validations
    {
        public static string PhoneValidation(this string phone)
        {
            if (phone.Length == 10 && phone.StartsWith("0"))
            {
                return phone;
            }
            else
            {
                MessageBox.Show("Некоректний номер телефону!");
                return null;
            }
        }
        
        public static string EmailValidation(this string email)
        {
            if (email.Contains("@"))
            {
                return email;
            }
            else
            {
                MessageBox.Show("Не коректна пошта!");
                return null;
            }
        }
    }
}
