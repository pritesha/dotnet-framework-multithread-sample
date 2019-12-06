using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet.framework.multithread.sample
{
    class Program
    {
        static void Main()
        {
            var customers = new List<Customer>() { };
            for(int i = 0; i <= 9; i++)
            {
                var customer = new Customer
                {
                    Id = i,
                    Name = "Customer-" + i,
                };
                customers.Add(customer);
            }

            customers
                .AsParallel()
                .WithDegreeOfParallelism(5)
                .ForAll(customer =>
                {
                    ProcessCustomer(customer);
                });
        }

        static void ProcessCustomer(Customer customer)
        {
            Console.WriteLine("Processed {0} at {1}", customer.Name, DateTime.Now);
        }
    }
}

