using DogSitter.BLL.Configs;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Services
{
    public class AdminService
    {
        private AdminRepository _rep;
        
        public AdminService()
        {
            _rep = new AdminRepository();  
        }

        public void UpdateAdmin(int id, AdminModel adminModel)
        {
            var entity = AdminMapper.GetInstance().Map<Admin>(adminModel);
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
            _rep.AddAdmin(AdminMapper.GetInstance().Map<Admin>(adminModel));
        }

        public AdminModel GetAdminById(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            return AdminMapper.GetInstance().Map<AdminModel>(admin);
        }

        public List<AdminModel> GetAllAdmins()
        {
            return AdminMapper.GetInstance().Map<List<AdminModel>>(_rep.GetAllAdmins());
        }
    }
}
