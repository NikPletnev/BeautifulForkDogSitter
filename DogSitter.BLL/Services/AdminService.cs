using AutoMapper;
using DogSitter.BLL.Configs;
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
            var entity = _map.Map<Admin>(adminModel);
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            _rep.UpdateAdmin(entity);

        }

        public void DeleteAdmin(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            _rep.UpdateAdmin(id, true);
        }

        public void RestoreAdmin(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            _rep.UpdateAdmin(id, false);
        }

        public void AddAdmin(AdminModel adminModel)
        {
            _rep.AddAdmin(_map.Map<Admin>(adminModel));
        }

        public AdminModel GetAdminById(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            return _map.Map<AdminModel>(admin);
        }

        public List<AdminModel> GetAllAdmins()
        {
            return _map.Map<List<AdminModel>>(_rep.GetAllAdmins());
        }
    }
}
