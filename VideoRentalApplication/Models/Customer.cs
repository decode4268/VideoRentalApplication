using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsSubscribeToNewsLetter { get; set; }  
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [IsMember18YearOld]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name="MemberShip Type")]
        public byte MembershipTypeId{ get; set; } 
        public MembershiptType MembershipType { get; set; }
    }
}