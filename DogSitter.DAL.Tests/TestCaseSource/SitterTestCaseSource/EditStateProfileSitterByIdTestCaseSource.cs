using DogSitter.DAL.Entity;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.DAL.Tests
{
    public class EditStateProfileSitterByIdTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int id = 4;

            bool verify = true;

            List<Sitter> sitters = new List<Sitter>() {
              new Sitter() { FirstName = "Иван", LastName = "Иванов", Password = "VANYA1234" ,
                  IsDeleted = false, AddressId = 1, PassportId = 2, Verified = false },
              new Sitter() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  IsDeleted = false, AddressId = 3, PassportId = 4, Verified = true  },
              new Sitter() { FirstName = "Иван2", LastName = "Иванов2", Password = "2VANYA1234",
                  IsDeleted = true, AddressId = 5, PassportId = 6, Verified = false  }
            };


            yield return new object[] { id, verify, sitters };
        }
    }
}