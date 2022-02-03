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
    public class CommentService
    {
        private readonly CommentRepository _repository;

        public CommentService()
        {
            _repository = new CommentRepository();
        }

        public CommentModel GetById(int id)
        {
            try
            {
                var comment = _repository.GetById(id);
                return CustomMapper.GetInstance().Map<CommentModel>(comment);
            }
            catch (Exception)
            {

                throw new Exception("Комментарий не найден");
            }
        }

        public List<CommentModel> GetAll()
        {
            var comment = _repository.GetAll();
            return CustomMapper.GetInstance().Map<List<CommentModel>>(comment);
        }

        public void Add(CommentModel commentModel)
        {
            var comment = CustomMapper.GetInstance().Map<Comment>(commentModel);
            _repository.Add(comment);
        }

        public void Update(CommentModel commentModel)
        {
            var comment = CustomMapper.GetInstance().Map<Comment>(commentModel);
            try
            {
                var entity = _repository.GetById(commentModel.Id);

            }
            catch (Exception)
            {

                throw new Exception("Комментарий не найден");
            }
            _repository.Update(comment);
        }

        public void DeleteById(int id)
        {
            try
            {
                var entity = _repository.GetById(id);

            }
            catch (Exception)
            {

                throw new Exception("Комментарий не найден");
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

                throw new Exception("Комментарий не найден");
            }
            bool Delete = false;
            _repository.Update(id, Delete);
        }
    }
}
