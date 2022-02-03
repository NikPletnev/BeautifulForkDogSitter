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

        public SitterModel GetById(int id)
        {
            try
            {
                var sitter = _repository.GetById(id);
                return CustomMapper.GetInstance().Map<SitterModel>(sitter);
            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
        }

        public List<SitterModel> GetAll()
        {
            var sitters = _repository.GetAll();
            return CustomMapper.GetInstance().Map<List<SitterModel>>(sitters);
        }

        public void Add(SitterModel sitterModel)
        {
            var sitter = CustomMapper.GetInstance().Map<Sitter>(sitterModel);
            _repository.Add(sitter);
        }

        public void Update(SitterModel sitterModel)
        {
            var sitter = CustomMapper.GetInstance().Map<Sitter>(sitterModel);
            try
            {
                var entity = _repository.GetById(sitterModel.Id);

            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
            _repository.Update(sitter);
        }

        public void DeleteById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);

            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
            bool delete = true;
            _repository.Update(id, delete);
        }

        public void Restore(int id)
        {
            try
            {
                var entity = _repository.GetById(id);

            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
            bool Delete = false;
            _repository.Update(id, Delete);
        }
    }
}
