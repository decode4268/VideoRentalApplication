using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using VideoRentalApplication.Models;
using VideoRentalApplication.ViewModel;

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
                           .Include(c => c.MembershipType) // navigation property
                           .ToList();

            return View(customerList);
        }
        public ViewResult CustomerForm()
        {
            var custFormVm = new CustomerFormViewModel();
            custFormVm.Customer = new Customer();
            custFormVm.MembershiptTypes = _context.MembershiptTypes.ToList();
            return View(custFormVm);
        }
        [HttpPost]
        public ActionResult Save(CustomerFormViewModel customerFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var custFormVm = new CustomerFormViewModel();
                custFormVm.Customer = new Customer();
                custFormVm.MembershiptTypes = _context.MembershiptTypes.ToList();
                return View("CustomerForm", custFormVm);
            }
            if (customerFormViewModel.Customer.Id == 0)
            {
                _context.Customers.Add(customerFormViewModel.Customer);
            }
            else
            {
                var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == customerFormViewModel.Customer.Id);
                if (customerInDb == null)
                    return HttpNotFound();
                customerInDb.Name = customerFormViewModel.Customer.Name;
                customerInDb.MembershipTypeId = customerFormViewModel.Customer.MembershipTypeId;
                customerInDb.DateOfBirth = customerFormViewModel.Customer.DateOfBirth;
                customerInDb.IsSubscribeToNewsLetter = customerFormViewModel.Customer.IsSubscribeToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int Id)
        {
            var customerInDb = _context.Customers.FirstOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                return HttpNotFound();
            var customformVM = new CustomerFormViewModel();
            customformVM.Customer = customerInDb;
            customformVM.MembershiptTypes = _context.MembershiptTypes.ToList();
            return View("CustomerForm", customformVM);
        }

        public ActionResult Delete(int Id)
        {
            var customData = _context.Customers.FirstOrDefault(x => x.Id == Id);
            if (customData != null)
            {
                _context.Customers.Remove(customData);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}