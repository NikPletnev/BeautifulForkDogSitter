﻿using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface IAdminRepository
    {
        void AddAdmin(Admin admin);
        void DeleteAdmin(int id);
        Admin GetAdminById(int id);
        List<Admin> GetAllAdmins();
        void UpdateAdmin(Admin admin);
        void UpdateAdmin(int id, bool isDeleted);
    }
}