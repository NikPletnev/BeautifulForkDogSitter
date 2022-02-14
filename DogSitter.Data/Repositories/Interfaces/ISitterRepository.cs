﻿using DogSitter.DAL.Entity;

namespace DogSitter.DAL.Repositories
{
    public interface ISitterRepository
    {
        void Add(Sitter sitter);
        List<Sitter> GetAll();
        Sitter GetById(int id);
        void Update(int id, bool isDeleted);
        void Update(Sitter sitter);
    }
}