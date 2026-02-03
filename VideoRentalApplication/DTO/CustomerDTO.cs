using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte MembershipTypeId { get; set; }
        public MembershiptType MembershipType { get; set; }

    }
}