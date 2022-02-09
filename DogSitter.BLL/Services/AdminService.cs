using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class AdminService : IAdminService
    {
        private AdminRepository _rep;
        private IMapper _mapper;

        public AdminService(IMapper mapper)
        {
            _rep = new AdminRepository();
            _mapper = mapper;
        }

        public void UpdateAdmin(int id, AdminModel adminModel)
        {
            var entity = _mapper.Map<Admin>(adminModel);
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
            _rep.AddAdmin(_mapper.Map<Admin>(adminModel));
        }

        public AdminModel GetAdminById(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            return _mapper.Map<AdminModel>(admin);
        }

        public List<AdminModel> GetAllAdmins()
        {
            return _mapper.Map<List<AdminModel>>(_rep.GetAllAdmins());
        }
    }
}
