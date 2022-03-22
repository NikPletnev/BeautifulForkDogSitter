using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public class SubwayStationRepository : ISubwayStationRepository
    {
        private readonly DogSitterContext _context;
        public SubwayStationRepository(DogSitterContext dbContext)
        {
            _context = dbContext;
        }

        public List<SubwayStation> GetAllSubwayStations() =>
            _context.SubwayStations.Where(ss => !ss.IsDeleted).ToList();

        public List<SubwayStation> GetAllSubwayStationsWhereSitterExist() =>
            _context.SubwayStations.Where(ss => !ss.IsDeleted)
            .Where(s => s.Sitters.Any(s => !s.IsDeleted)).ToList();

        public SubwayStation GetSubwayStationById(int id) =>
            _context.SubwayStations.FirstOrDefault(s => s.Id == id);


        public int AddSubwayStation(SubwayStation subwayStation)
        {
            _context.SubwayStations.Add(subwayStation);
            _context.SaveChanges();

            return subwayStation.Id;
        }

        public void UpdateSubwayStation(SubwayStation exitingSubwayStation, SubwayStation subwayStationToUpdate)
        {
            exitingSubwayStation.Name = subwayStationToUpdate.Name;
            _context.SaveChanges();
        }

        public void UpdateOrDeleteSubwayStation(SubwayStation subwayStation, bool IsDeleted)
        {
            subwayStation.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}
