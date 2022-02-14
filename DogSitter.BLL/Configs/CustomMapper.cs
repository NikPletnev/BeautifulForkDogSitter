using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;


namespace DogSitter.BLL.Configs
{
    public class CustomMapper : Profile
    {
        public CustomMapper()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Sitter, SitterModel>().ReverseMap();
            CreateMap<Serviсe, ServiceModel>().ReverseMap();
            CreateMap<WorkTime, WorkTimeModel>().ReverseMap();
            CreateMap<Admin, AdminModel>().ReverseMap();
            CreateMap<Contact, ContactModel>().ReverseMap();
            CreateMap<Dog, DogModel>().ReverseMap();
            CreateMap<Passport, PassportModel>().ReverseMap();
            CreateMap<WorkTime, WorkTimeModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }

    }
}