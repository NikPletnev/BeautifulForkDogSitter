using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private DogSitterContext _context;

        public ContactTypeRepository(DogSitterContext context)
        {
            _context = context;
        }

        public List<ContactType> GetAllContactTypes() =>
                _context.ContactTypes.Where(c => !c.IsDeleted).ToList();

        public ContactType GetContactTypeById(int id) =>
                _context.ContactTypes.FirstOrDefault(c => c.Id == id);

        public void AddContactType(ContactType contactType)
        {
            _context.ContactTypes.Add(contactType);
            _context.SaveChanges();
        }

        public void UpdateContactType(int id, bool isDeleted)
        {
            var entity = GetContactTypeById(id);
            entity.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

        public void UpdateContactType(ContactType contactType)
        {
            var entity = GetContactTypeById(contactType.Id);
            entity.Name = contactType.Name;
            _context.SaveChanges();
        }
    }
}
