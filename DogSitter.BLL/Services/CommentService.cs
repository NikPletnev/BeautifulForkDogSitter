using AutoMapper;
using DogSitter.BLL.Exeptions;
using DogSitter.BLL.Models;
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

        public List<CommentModel> GetAll() =>
             _mapper.Map<List<CommentModel>>(_repository.GetAll());


        public void DeleteById(int id)
        {
            var comment = _repository.GetById(id);
            if (comment == null)
            {
                throw new EntityNotFoundException($"Comment {id} was not found");
            }

            bool isDelited = true;
            _repository.Update(comment, isDelited);
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
