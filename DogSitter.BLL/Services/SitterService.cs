using DogSitter.BLL.Config;
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
    public class SitterService
    {
        private SitterRepository _repository;
        
        public SitterService()
        {
            _repository = new SitterRepository();
        }

        public SitterModel GetSitterById(int id)
        {
            try
            {
                var sitter = _repository.GetSitterById(id);
                return CustomMapper.GetInstance().Map<SitterModel>(sitter);
            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
        }
        public List<SitterModel> GetAllSitters()
        {
            var sitters = _repository.GetAllSitters();
            return CustomMapper.GetInstance().Map<List<SitterModel>>(sitters);
        }

        public void AddSitter(SitterModel sitterModel)
        {
            var sitter = CustomMapper.GetInstance().Map<Sitter>(sitterModel);
            _repository.AddSitter(sitter);
        }

        public void UpdateSitter(SitterModel sitterModel)
        {
            var sitter = CustomMapper.GetInstance().Map<Sitter>(sitterModel);
            try
            {
                var entity = _repository.GetSitterById(sitterModel.Id);

            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
            _repository.UpdateSitter(sitter);
        }

        public void DeleteSitterById(int id)
        {
            try
            {
                var entity = _repository.GetSitterById(id);

            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
            bool delete = true;
            _repository.UpdateSitter(id, delete);
        }

        public void RestoreSittr(int id)
        {
            try
            {
                var entity = _repository.GetSitterById(id);

            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
            bool Delete = false;
            _repository.UpdateSitter(id, Delete);
        }
    }
}
