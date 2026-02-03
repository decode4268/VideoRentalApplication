using AutoMapper;
using VideoRentalApplication.DTO;
using VideoRentalApplication.Model;
using VideoRentalApplication.Models;

namespace VideoRentalApplication.App_Start
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            // Model-- to -- Dto
            Mapper.CreateMap<CustomerDTO, Customer>();
            // DTO -- to -- Model
            Mapper.CreateMap<Customer, CustomerDTO>();

            Mapper.CreateMap<MembershiptType, MemebershipTypeDTO>();
        }

    }
}