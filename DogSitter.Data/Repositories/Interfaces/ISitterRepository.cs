using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ISitterRepository
    {
        int Add(Sitter sitter);
        void EditProfileStateBySitterId(int id, bool verify);
        List<Sitter> GetAll();
        //List<Sitter> GetAllSitterByServiceId(int id);
        List<Sitter> GetAllSittersWithWorkTimeBySubwayStationId(int subwaystationId);
        Sitter GetById(int id);
        void UpdateOrDelete(Sitter sitter, bool isDeleted);
        void Update(Sitter exitingSitter, Sitter sitterToUpdate);
        void ChangeRating(Sitter sitter);
        List<Order> GetAllSitterOrders(Sitter sitter);
        List<Sitter> GetAllSitterWithService();
    }
}