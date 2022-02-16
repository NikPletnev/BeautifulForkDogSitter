using AutoMapper;
using DogSitter.BLL.Configs;
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
            if(adminModel.FirstName == String.Empty ||
                adminModel.LastName == String.Empty ||
                adminModel.Password == String.Empty ||
                adminModel.Contacts.Count == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the admin {id}");
            }

            var entity = _map.Map<Admin>(adminModel);
            var admin = _rep.GetAdminById(id);

            if (admin == null)
            {
                throw new EntityNotFoundException($"Admin {id} was not found");
            }

            _rep.UpdateAdmin(entity);
        }

        public void DeleteAdmin(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new EntityNotFoundException($"Admin {id} was not found");
            }

            _rep.UpdateAdmin(id, true);
        }

        public void RestoreAdmin(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new EntityNotFoundException($"Admin {id} was not found");
            }

            _rep.UpdateAdmin(id, false);
        }

        public void AddAdmin(AdminModel adminModel)
        {
            if (adminModel.FirstName == String.Empty ||
                adminModel.LastName == String.Empty ||
                adminModel.Password == String.Empty ||
                adminModel.Contacts.Count == 0)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new admin");
            }

            _rep.AddAdmin(_map.Map<Admin>(adminModel));
        }

        public AdminModel GetAdminById(int id)
        {
            var admin = _rep.GetAdminById(id);

            if (admin == null)
            {
                throw new EntityNotFoundException($"Admin {id} was not found");
            }

            return _map.Map<AdminModel>(admin);
        }

        public List<AdminModel> GetAllAdmins()
        {
            return _map.Map<List<AdminModel>>(_rep.GetAllAdmins());
        }

        public List<AdminModel> GetAllAdminsWithContacts()
        {
            return _map.Map<List<AdminModel>>(_rep.GetAllAdminWithContacts());
        }

        public AdminModel GetAdminWithContacts(int id)
        {
            var admin = _rep.GetAdminByIdWithContacts(id);

            if (admin == null)
            {
                throw new EntityNotFoundException($"Admin {id} was not found");
            }

            return _map.Map<AdminModel>(admin);
        }
    }
}
