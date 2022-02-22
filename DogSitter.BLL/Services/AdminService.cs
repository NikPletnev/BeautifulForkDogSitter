using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _rep;
        private readonly IMapper _map;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _rep = adminRepository;
            _map = mapper;
        }

        public void UpdateAdmin(int id, AdminModel adminModel)
        {
            if (adminModel.FirstName == String.Empty ||
                adminModel.LastName == String.Empty ||
                adminModel.Password == String.Empty ||
                adminModel.Contacts.Count == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the admin {id}");
            }

            var admin = _map.Map<Admin>(adminModel);
            var entity = _rep.GetAdminById(id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Admin {id} was not found");
            }

            _rep.UpdateAdmin(entity, admin);
        }

        public List<AdminModel> GetAllAdminsWithContacts()
        {
            return _map.Map<List<AdminModel>>(_rep.GetAllAdminWithContacts());
        }
    }
}
