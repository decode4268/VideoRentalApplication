using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
             _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            //var customerList = _context.Customers.ToList();
            //var customerList = _context.Customers.Include(c => c.MembershiptTypeId).ToList();
            var customerList = _context.Customers
                           .Include(c => c.MembershiptType) // navigation property
                           .ToList();

            return View(customerList);
        }
        public ViewResult New()
        {
            var customer = new Customer();
            return View();
        }
    }
}