using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class CustomerLoginTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Customer> Customers = new List<Customer>()
            {
              new Customer()
              {   FirstName = "FirstName1",
                  LastName = "LastName1",
                  Password = "Password1" ,
                  Contacts = new List<Contact>()
                  {
                      new Contact {
                          Value = "Value1",
                          ContactType = ContactType.Phone}
                  },
                  IsDeleted = false },
                new Customer()
              {
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Password = "Password2",
                    Contacts = new List<Contact>()
                    {
                      new Contact
                    {
                          Value ="Value2",
                          ContactType = ContactType.Mail}
                    },
                    IsDeleted = false
                },
                new Customer()
                {
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    Password = "Password3",
                    IsDeleted = true }
            };

            Contact contact = new Contact()
            {
                Id = 1,
                Value = "Value1",
                ContactType = ContactType.Phone
            };

            string pass = "Password1";

            Customer expected = new Customer()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                Password = "Password1",
                Contacts = new List<Contact>()
                  {
                      new Contact {
                          Value = "Value1",
                          ContactType = ContactType.Phone}
                  },
                IsDeleted = false
            };

            yield return new object[] { Customers, contact, pass, expected };
        }
    }
}
