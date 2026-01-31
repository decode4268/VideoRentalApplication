using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movies { get; set; }

        public List<Genre> Genres { get; set; }
    }
}