﻿using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DogSitter.DAL.Repositories
{
    public class SubwayStationRepository : ISubwayStationRepository
    {
        private readonly DogSitterContext _context;
        private bool _isInitialized;
        public SubwayStationRepository(DogSitterContext dbContext)
        {
            _isInitialized = true;
            _context = dbContext;
        }

        public List<SubwayStation> GetAllSubwayStations() =>
            _context.SubwayStations.Where(ss => !ss.IsDeleted).ToList();

        public List<SubwayStation> GetAllSubwayStationsWhereSitterExist()
        {
            var stations = _context.SubwayStations.Where(ss => !ss.IsDeleted)
                        .Where(s => s.Sitters.Any(s => !s.IsDeleted)).ToList();

            foreach (var station in stations)
            {
                station.Sitters = station.Sitters.Where(x => !x.IsDeleted).ToList();
            }

            return stations;
        }

        public SubwayStation GetSubwayStationById(int id) =>
            _context.SubwayStations.FirstOrDefault(s => s.Id == id);

        public void AddSubwayStation(SubwayStation subwayStation)
        {
            _context.SubwayStations.Add(subwayStation);
            _context.SaveChanges();
        }

        public void UpdateSubwayStation(SubwayStation subwayStation)
        {
            var trackingSubwayStation = _context.ChangeTracker.Entries<SubwayStation>()
                .First(a => a.Entity.Id == subwayStation.Id).Entity;

            trackingSubwayStation.Name = subwayStation.Name;
            trackingSubwayStation.Sitters = subwayStation.Sitters;
            _context.SaveChanges();
        }

        public void UpdateSubwayStation(SubwayStation subwayStation, bool IsDeleted)
        {
            subwayStation.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }

        public void RestoreSubwayStation(SubwayStation subwayStation, bool IsDeleted)
        {
            subwayStation.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}