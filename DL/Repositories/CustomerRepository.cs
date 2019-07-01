using DL.Infrastructure;
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        public void AddCustomer(Customer objCustomer)
        {
            this.DataContext.Add(objCustomer);
            this.DataContext.SaveChanges();
        }

        public IEnumerable<Customer> GetByOperatorId(int operatorId)
        {
            //Check how to pass nested query 
            //var customers = this.DataContext.Customer.Where(o => o.CustomerId == 1234);
            var customers = this.DataContext.Customer;
            return customers;
        }

    }
    public interface ICustomerRepository : IRepository<Customer>
    {
        void AddCustomer(Customer objCustomer);
        IEnumerable<Customer> GetByOperatorId(int operatorId);
    }
}
