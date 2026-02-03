using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalApplication.Model;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.ViewModel
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershiptType> MembershiptTypes { get; set; }
    }
}