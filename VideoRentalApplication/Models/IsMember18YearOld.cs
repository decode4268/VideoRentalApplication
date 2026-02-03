using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRentalApplication.Model;

namespace VideoRentalApplication.Models
{
    public class IsMember18YearOld : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of Birth is required");
            int age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            //                  2026      -  1999   = 20

            return age >= 18 ? ValidationResult.Success :
                    new ValidationResult("Customer should be at least years old to go for membership type");

        }
    }
}