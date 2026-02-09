using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using VideoRentalApplication.Models;
using Microsoft.Ajax.Utilities;
using VideoRentalApplication.Model;
using AutoMapper;
using VideoRentalApplication.DTO;

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
        //[HttpGet]
        //public List<Customer> GetAllCustomers()
        //{
        //    return _context.Customers.Include(x => x.MembershipType).ToList();
        //}

        [HttpGet]
        [Route("api/CustomerAPI/AllCustomer")]
        public IHttpActionResult AllCustomer()
        {
            var customerDTO = _context.Customers.Include(x => x.MembershipType).ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDTO);
        }

        // GET : /api/Customers/1
        [HttpGet]
        [Route("api/CustomerAPI/{id}")]
        public Customer GetCustomerById(int? id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        // POST : /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid || customerDto == null)
                return BadRequest();
            var customerData = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customerData);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);

        }

        // PUT : /api/Customer/1

        [HttpPut]
        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if(customerDTO.Id == 0)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.FirstOrDefault(x => x.Id == customerDTO.Id);
            //var data = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            if (customerInDb != null)
            {
                Mapper.Map(customerDTO, customerInDb);
                //customerInDb.Name = customer.Name;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customer.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
                //customerInDb.DateOfBirth = customer.DateOfBirth;
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
