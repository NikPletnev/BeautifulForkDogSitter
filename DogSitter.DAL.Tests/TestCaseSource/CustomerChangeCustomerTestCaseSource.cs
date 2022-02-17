using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class CustomerChangeCustomerTestCaseSource: IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            Customer customer = new Customer()
            {
                Id = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Password = "Password2",
                Contacts = new List<Contact>()
                    {
                      new Contact
                    {
                          Value ="Value2",
                          ContactType = ContactType.mail}
                    },
                IsDeleted = false
            };

            Address address = new Address
            {
                Id = 2,
                Name = "TestName2",
                City = "TestCity2",
                Street = "TestStreet2",
                House = 2,
                Apartament = 2,
                IsDeleted = false
            };

            Customer expected = new Customer()
            {
                Id = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                Password = "Password2",
                Contacts = new List<Contact>()
                    {
                      new Contact
                    {
                          Value ="Value2",
                          ContactType = ContactType.mail}
                    },
                Address = address,
                IsDeleted = false
            };


            yield return new object[] { customer, expected, address };
        }
    }
}
