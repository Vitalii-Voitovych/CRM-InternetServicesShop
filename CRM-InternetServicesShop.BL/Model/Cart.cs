using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_InternetServicesShop.BL.Model
{
    public class Cart : IEnumerable
    {
        public Customer Customer { get; set; }
        public Dictionary<Service, int> Services { get; set; }
        public decimal Price => GetAll().Sum(s => s.Price);

        public Cart(Customer customer)
        {
            Customer = customer;
            Services = new Dictionary<Service, int>();
        }

        public void Add(Service service)
        {
            if (Services.TryGetValue(service, out int count))
            {
                Services[service] = ++count;
            }
            else
            {
                Services.Add(service, 1);
            }
        }

        public void Remove(Service service)
        {
            if (Services.TryGetValue(service, out int count))
            {
                Services[service] = --count;
                if (count == 0)
                {
                    Services.Remove(service);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var service in Services.Keys)
            {
                for (int i = 0; i < Services[service]; i++)
                {
                    yield return service;
                }
            };
        }

        public List<Service> GetAll()
        {
            var result = new List<Service>();
            foreach (Service service in this)
            {
                result.Add(service);
            }
            return result;
        }
    }
}
