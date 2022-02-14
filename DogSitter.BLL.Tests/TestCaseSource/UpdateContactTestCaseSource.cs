﻿using DogSitter.BLL.Models;
using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class UpdateContactTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 1;

            Contact contact = new Contact() { Id = 1, Value = "89871234567", ContactType = ContactType.phone, IsDeleted = false };
            
            ContactModel contactModel = new ContactModel() { Id = 1, Value = "89871234567", ContactType = ContactType.phone, IsDeleted = false };

            yield return new object[] { id, contact, contactModel };

            int id2 = 4;
            
            Contact contact2 = new Contact() { Id = 4, Value = "@qwerty", ContactType = ContactType.mail, IsDeleted = false };
            
            ContactModel contactModel2 = new ContactModel() { Id = 4, Value = "@qwerty", ContactType = ContactType.mail, IsDeleted = false };

            yield return new object[] { id2, contact2, contactModel2 };

            int id3 = 99;

            Contact contact3 = new Contact() { Id = 99, Value = "qwerty123@icloud.com", ContactType = ContactType.mail, IsDeleted = true };
            
            ContactModel contactModel3 = new ContactModel() { Id = 99, Value = "qwerty123@icloud.com", ContactType = ContactType.mail, IsDeleted = true };

            yield return new object[] { id3, contact3, contactModel3 };
        }
    }
}