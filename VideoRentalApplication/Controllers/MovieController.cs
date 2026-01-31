using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalApplication.Models;
using System.Data.Entity;
using VideoRentalApplication.ViewModel;

namespace VideoRentalApplication.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
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
            var movieList = _context.Movies
                           .Include(c => c.Genre) // navigation property
                           .ToList();
            return View(movieList);
        }
        public ViewResult MovieForm()
        {
            var movieFormVm = new MovieFormViewModel();
            movieFormVm.Movies = new Movie();
            movieFormVm.Genres = _context.Genres.ToList();
            return View(movieFormVm);
        }
        [HttpPost]
        public ActionResult Save(MovieFormViewModel customerFormViewModel)
        {
            if (!ModelState.IsValid)
            {
                var movieFormVm = new MovieFormViewModel();
                movieFormVm.Movies = new Movie();
                movieFormVm.Genres = _context.Genres.ToList();
                return View("MovieForm",movieFormVm);
            }
            if (customerFormViewModel.Movies.Id == 0)
            {
                _context.Movies.Add(customerFormViewModel.Movies);
            }
            else
            {
                var customerInDb = _context.Movies.FirstOrDefault(c => c.Id == customerFormViewModel.Movies.Id);
                if (customerInDb == null)
                    return HttpNotFound();
                customerInDb.Name = customerFormViewModel.Movies.Name;
                customerInDb.Genreid = customerFormViewModel.Movies.Genreid;
                customerInDb.AddedDate = customerFormViewModel.Movies.AddedDate;
                customerInDb.ReleaseDate = customerFormViewModel.Movies.ReleaseDate;
                customerInDb.NumberInStock = customerFormViewModel.Movies.NumberInStock;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int Id)
        {
            var customerInDb = _context.Movies.FirstOrDefault(c => c.Id == Id);
            if (customerInDb == null)
                return HttpNotFound();
            var movieFormVm = new MovieFormViewModel();
            movieFormVm.Movies = new Movie();
            movieFormVm.Genres = _context.Genres.ToList();
            return View("MovieForm", movieFormVm);
        }

        public ActionResult Delete(int Id)
        {
            var customData = _context.Movies.FirstOrDefault(x => x.Id == Id);
            if (customData != null)
            {
                _context.Movies.Remove(customData);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}