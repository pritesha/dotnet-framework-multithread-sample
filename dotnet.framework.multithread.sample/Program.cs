using System;
using System.Collections.Generic;
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
                    Name = "Customer-" + i,
                    // wait time added just to simulate the asynchronous behaviour
                    WaitTime = new Random(i).Next(2000, 5000)
                };
                customers.Add(customer);
            }

            ProcessCustomersAsync(customers).Wait();
        }

        static async Task ProcessCustomersAsync(IReadOnlyCollection<Customer> customers)
        {
            List<Task> tasks = new List<Task>() { };
            foreach(var customer in customers)
            {
                tasks.Add(ProcessCustomerAsync(customer));
            }

            await Task.WhenAll(tasks);
        }

        static async Task ProcessCustomerAsync(Customer customer)
        {
            Console.WriteLine("Processing {0} started  at {1}", customer.Name, DateTime.Now);
            // Delay to task to simulate the processing time.
            await Task.Delay(customer.WaitTime);
            Console.WriteLine("Processing {0} finished at {1}", customer.Name, DateTime.Now);
        }
    }
}

