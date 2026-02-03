using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalApplication.Models;
using System.Data.Entity;

namespace VideoRentalApplication.APIController
{
    public class MovieAPIController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MovieAPIController()
        {
            _context = new ApplicationDbContext();
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET :  /api/GetAllMovies
        [HttpGet]
        public List<Movie> GetAllMovies()
        {
            return _context.Movies.Include(x => x.Genre).ToList();
        }

        // GET : /api/GetMoviesById/1
        [HttpGet]
        public Movie GetMoviesById(int id)
        {
            return _context.Movies.FirstOrDefault(c => c.Id == id);
        }

        // POST : /api/CreateMovie
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid || movie == null)
                return BadRequest();
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);

        }

        // PUT : /api/UpdateMovie

        [HttpPut]
        public void UpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (movie.Id == 0)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);
            //var data = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();
            if (movieInDb != null)
            {
                movieInDb.Name = movie.Name;
                movieInDb.Genreid = movie.Genreid;
                movieInDb.AddedDate = movie.AddedDate;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                _context.SaveChanges();
            }
        }

        // DELETE : api/DeleteMovie/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
