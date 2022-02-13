using AutoMapper;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class SitterService : ISitterService
    {
        private SitterRepository _repository;
        private IMapper _mapper;

        public SitterService(IMapper mapper)
        {
            _repository = new SitterRepository();
            _mapper = mapper;
        }

        public SitterModel GetSitterById(int id)
        {
            try
            {
                var sitter = _repository.GetSitterById(id);
                return _mapper.Map<SitterModel>(sitter);
            }
            catch (Exception)
            {

                throw new Exception("Ситтер не найден");
            }
        }
        public List<SitterModel> GetAllSitters()
        {
            var sitters = _repository.GetAllSitters();
            return _mapper.Map<List<SitterModel>>(sitters);
        }

        public void AddSitter(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
            _repository.AddSitter(sitter);
        }

        public void UpdateSitter(SitterModel sitterModel)
        {
            var sitter = _mapper.Map<Sitter>(sitterModel);
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

        public void RestoreSitter(int id)
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
