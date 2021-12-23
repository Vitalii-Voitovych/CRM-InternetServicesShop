using System.Collections.Generic;

namespace CRM_InternetServicesShop.BL.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            if (Phone != null)
            {
                return $"{FullName} Phone: {Phone}";
            }
            else
            {
                return $"{FullName} Phone: {Email}";
            }
        }
    }
}
