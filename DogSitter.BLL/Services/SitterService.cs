﻿using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class SitterService : ISitterService
    {
        private ISitterRepository _repository;
        private IMapper _mapper;

        public SitterService(ISitterRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public SitterModel GetById(int id)
        {
            try
            {
                var sitter = _repository.GetById(id);
                return _mapper.Map<SitterModel>(sitter);
            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
        }
        public List<SitterModel> GetAll()
        {
            var sitters = _repository.GetAll();
            return _mapper.Map<List<SitterModel>>(sitters);
        }

        public void Add(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            _repository.Add(sitter);
        }

        public void Update(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
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
            _repository.EditStateProfileSitterById(id, false);
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

        public void ConfirmProfileSitterById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new ServiceNotFoundExeption($"Sitter {id} was not found");
            }
            if (!entity.IsDeleted)
            {
                _repository.EditStateProfileSitterById(id, true);
            }
        }

        public void BlockProfileSitterById(int id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new ServiceNotFoundExeption($"Sitter {id} was not found");
            }
            _repository.EditStateProfileSitterById(id, false);
        }
    }
}
