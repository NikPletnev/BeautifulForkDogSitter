using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ISitterRepository
    {
        void Add(Sitter sitter);
        void EditProfileStateBySitterId(int id, bool verify);
        List<Sitter> GetAll();
        //List<Sitter> GetAllSitterByServiceId(int id);
        List<Sitter> GetAllSittersWithWorkTimeBySubwayStation(SubwayStation subwaystation);
        Sitter GetById(int id);
        void Update(int id, bool isDeleted);
        void Update(Sitter sitter);
        void ChangeRating(Sitter sitter);
        List<Order> GetAllSitterOrders(Sitter sitter);
        List<Sitter> GetAllSitterWithService();
    }
}