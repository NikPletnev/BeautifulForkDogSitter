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
        private AdminRepository _rep = new AdminRepository();
        private MMapper _map = new MMapper();

        public void UpdateAdmin(int id, AdminModel adminModel)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            _rep.UpdateAdmin(_map.MapAdminModelToAdmin(adminModel));

        }

        public void DeleteAdmin(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            _rep.DeleteAdmin(id);
        }

        public void AddAdmin(AdminModel adminModel)
        {
            _rep.AddAdmin(_map.MapAdminModelToAdmin(adminModel));
        }

        public AdminModel GetAdminById(int id)
        {
            var admin = _rep.GetAdminById(id);
            if (admin == null)
            {
                throw new Exception("Администратор не найден");
            }

            return _map.MapAdminToAdminModel(admin);
        }

        public List<AdminModel> GetAllAdmins()
        {
            return _map.MapAdminToAdminModel(_rep.GetAllAdmins());
        }
    }
}
