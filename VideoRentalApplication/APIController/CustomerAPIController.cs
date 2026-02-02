using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using VideoRentalApplication.Models;
using Microsoft.Ajax.Utilities;

namespace VideoRentalApplication.APIController
{
    public class CustomerAPIController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomerAPIController()
        {
            _context = new ApplicationDbContext();
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET :   /api/Customers
        [HttpGet]
        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Include(x => x.MembershipType).ToList();
        }

        // GET : /api/Customers/1
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        // POST : /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid || customer == null)
                return BadRequest();
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);

        }

        // PUT : /api/Customer/1

        [HttpPut]
        public void UpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if(customer.Id == 0)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.FirstOrDefault(x => x.Id == customer.Id);
            //var data = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            if (customerInDb != null)
            {
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customer.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                _context.SaveChanges();
            }
        }

        // DELETE : api/Customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }

    }
}
