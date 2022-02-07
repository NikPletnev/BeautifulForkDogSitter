﻿using System.ComponentModel.DataAnnotations;

namespace DogSitter.DAL.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public virtual ContactType ContactType { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Sitter Sitter { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Contact contact &&
                   Id == contact.Id &&
                   Value == contact.Value &&
                   IsDeleted == contact.IsDeleted;
        }

        public override string ToString()
        {
            return $"{Id} {Value}";
        }

        

    }
}
