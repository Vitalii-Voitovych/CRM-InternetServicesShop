using System;

namespace CRM_InternetServicesShop.BL.Model
{
    public class Payment
    {
        public int PaymentId{ get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        public DateTime Date { get; set; }
    }
}
