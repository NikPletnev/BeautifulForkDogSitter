using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;


namespace DogSitter.BLL.Configs
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Sitter, SitterModel>().ReverseMap();
            CreateMap<Comment, CommentModel>().ReverseMap();
            CreateMap<Serviсe, ServiceModel>().ReverseMap();
            CreateMap<Timesheet, TimesheetModel>().ReverseMap();
            CreateMap<Admin, AdminModel>().ReverseMap();
            CreateMap<Contact, ContactModel>().ReverseMap();
            CreateMap<Dog, DogModel>().ReverseMap();
            CreateMap<Passport, PassportModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
            CreateMap<SubwayStation, SubwayStationModel>().ReverseMap();
            CreateMap<Address, AddressModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }

    }
}