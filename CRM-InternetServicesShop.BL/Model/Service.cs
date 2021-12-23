using System.Collections.Generic;

namespace CRM_InternetServicesShop.BL.Model
{
    public class Service
    {
        public int ServiceId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public override string ToString()
        {
            return $"{Name} : ${Price}";
        }
    }
}
