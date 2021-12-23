using System;
using System.Collections.Generic;

namespace CRM_InternetServicesShop.BL.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public override string ToString()
        {
            return Date.ToString("HH:mm dd.MM.yyyy");
        }
    }
}
