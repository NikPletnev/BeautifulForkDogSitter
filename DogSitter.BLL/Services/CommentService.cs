using AutoMapper;
using DogSitter.BLL.Configs;
using DogSitter.BLL.Exeptions;
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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;


        public CommentService(ICommentRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public CommentModel GetById(int id)
        {
            var comment = _repository.GetById(id);

            if (comment == null)
            {
                throw new ServiceNotFoundExeption($"Comment {id} was not found");
            }
            return _mapper.Map<CommentModel>(_repository.GetById(id));
        }

        public List<CommentModel> GetAll() =>
             _mapper.Map<List<CommentModel>>(_repository.GetAll());


        public void Add(CommentModel commentModel)
        {
            if (commentModel.Text == String.Empty ||
               commentModel.Date == DateTime.MinValue)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to create new comment");
            }
            _repository.Add(_mapper.Map<Comment>(commentModel));
        }

        public void Update(CommentModel commentModel)
        {
            if (commentModel.Text == String.Empty)
            {
                throw new ServiceNotEnoughDataExeption($"There is not enough data to edit the comment {commentModel.Id}");
            }
            var entity = _mapper.Map<Comment>(commentModel);
            var comment = _repository.GetById(commentModel.Id);
            if (comment == null)
            {
                throw new ServiceNotFoundExeption($"Comment {commentModel.Id} was not found");
            }

            _repository.Update(comment);
        }

        public void DeleteById(int id)
        {
            var comment = _repository.GetById(id);
            if (comment == null)
            {
                throw new ServiceNotFoundExeption($"Comment {id} was not found");
            }

            bool isDelited = true;
            _repository.Update(id, isDelited);
        }

        public void Restore(int id)
        {
            var comment = _repository.GetById(id);
            if (comment == null)
            {
                throw new ServiceNotFoundExeption($"Comment {id} was not found");
            }

            bool Delete = false;
            _repository.Update(id, Delete);
        }
    }
}
