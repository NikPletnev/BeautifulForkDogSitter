using DogSitter.DAL.Entity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DogSitter.BLL.Tests.TestCaseSource
{
    public class GetAllSittersWithServicesTestCaseSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            List<Sitter> sitters = new List<Sitter>()
                {
                    new Sitter()
                      {
                        Id = 17,
                        FirstName ="Иннокентий",
                        LastName ="Пипидастров",
                        Password = "qwe123",
                        Information ="GOOD SITTER",
                        Verified = true,
                        Orders = new List<Order>(),
                        WorkTime = new List<WorkTime>(),
                        Contacts = new List<Contact>(),
                        Passport = new Passport()
                        {
                            Id = 46,
                            FirstName = "a",
                            LastName = "a",
                            DateOfBirth = DateTime.Now,
                            Seria = "a",
                            Number = "a",
                            IssueDate = DateTime.Now,
                            Division = "a",
                            DivisionCode = "a"
                        },
                          Services = new List<Serviсe>()
                          {
                              new Serviсe()
                              {
                                   Id = 4,
                                   Name = "Name1",
                                   Description = "Description1",
                                   Price = 1000m,
                                   DurationHours = 1.0,
                                   IsDeleted = false
                              },
                              new Serviсe()
                              {
                                  Id = 5,
                                  Name = "Name2",
                                  Description = "Description2",
                                  Price = 2000m,
                                  DurationHours = 2.0,
                                  IsDeleted = true
                              }
                          },
                          IsDeleted = false
                    },
                     new Sitter()
                      {
                          Id = 22,
                          FirstName ="Иннокентий2",
                          LastName ="Пипидастров4",
                          Password = "qwe123",
                          Information ="GOOD SITTER1",
                          Verified = true,
                          Orders = new List<Order>(),
                          WorkTime = new List<WorkTime>(),
                          Contacts = new List<Contact>(),
                          Passport = new Passport()
                          {
                              Id = 33,
                              FirstName = "s",
                              LastName = "s",
                              DateOfBirth = DateTime.Now,
                              Seria = "s",
                              Number = "s",
                              IssueDate = DateTime.Now,
                              Division = "s",
                              DivisionCode = "s"
                          },
                          Services = new List<Serviсe>()
                          {
                              new Serviсe()
                              {
                                   Id = 12,
                                   Name = "Name3",
                                   Description = "Description3",
                                   Price = 1001m,
                                   DurationHours = 3.0,
                                   IsDeleted = false
                              },
                              new Serviсe()
                              {
                                  Id = 13,
                                  Name = "Name4",
                                  Description = "Description4",
                                  Price = 2001m,
                                  DurationHours = 3.0,
                                  IsDeleted = true
                              },
                              new Serviсe()
                              {
                                  Id = 14,
                                  Name = "Name5",
                                  Description = "Description5",
                                  Price = 2003m,
                                  DurationHours = 3.0,
                                  IsDeleted = false
                              }
                          },
                          IsDeleted = false
                    }
                };

            yield return new object[] { sitters };
        }
    }
}
