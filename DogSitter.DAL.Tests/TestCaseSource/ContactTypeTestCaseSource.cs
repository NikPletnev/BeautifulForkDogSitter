using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogSitter.DAL.Tests.TestCaseSource
{
    public class ContactTypeTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<ContactType> contactTypes = new List<ContactType>() {
              new ContactType() { Name = "телефон"},
              new ContactType() { Name = "телеграмм"},
              new ContactType() { Name = "почта", IsDeleted = true}
            };

            yield return new object[] { contactTypes };
        }
            
    }
}
