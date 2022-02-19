using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Repositories;

namespace DogSitter.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly ISitterRepository _sitterRepository;
        private readonly IMapper _mapper;


        public CommentService(ICommentRepository repository, IMapper mapper, ISitterRepository sitterRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _sitterRepository = sitterRepository;
        }

        public CommentModel GetById(int id)
        {
            var comment = _repository.GetById(id);

            if (comment == null)
            {
                throw new EntityNotFoundException($"Comment {id} was not found");
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
                throw new EntityNotFoundException($"Comment {commentModel.Id} was not found");
            }

            _repository.Update(comment);
        }

        public void DeleteById(CommentModel commentModel)
        {
            var comment = _repository.GetById(commentModel.Id);
            if (comment == null)
            {
                throw new EntityNotFoundException($"Comment {commentModel.Id} was not found");
            }

            bool isDelited = true;
            _repository.Update(comment, isDelited);
        }

        public void Restore(int id)
        {
            var comment = _repository.GetById(id);
            if (comment == null)
            {
                throw new EntityNotFoundException($"Comment {id} was not found");
            }

            bool Delete = false;
            _repository.Update(comment, Delete);
        }

        public List<CommentModel> GetAllCommentsBySitterId(int id)
        {
            var sitter = _sitterRepository.GetById(id);
            if (sitter == null)
            {
                throw new EntityNotFoundException($"Sitter {id} was not found");
            }

            return _mapper.Map<List<CommentModel>>(_repository.GetAllComentsBySitterId(id));
        }
    }
}
