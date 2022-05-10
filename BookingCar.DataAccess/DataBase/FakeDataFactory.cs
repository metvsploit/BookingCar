using BookingCar.Core.Domain.Drivers;
using BookingCar.Core.Domain.Employee;
using BookingCar.Core.Domain.Enum;
using BookingCar.Core.Domain.Helpers;
using System;
using System.Collections.Generic;

namespace BookingCar.DataAccess.DataBase
{
    public static class FakeDataFactory
    {
        public static IEnumerable<User> Users => new List<User>()
        {
            new User() { Id = Guid.NewGuid(), Email = "admin@mail.ru", Name = "Базаров Пацан Братович",
                Password = "123456".HashPassword(), Role = Role.Admin},

            new User() { Id = Guid.NewGuid(), Email = "user@mail.ru", Name = "Друган Отморозов Отбросович",
                Password = "123456".HashPassword(), Role = Role.User},
        };

        public static IEnumerable<Driver> Drivers => new List<Driver>()
        {
            new Driver() { Id = new Guid("874d64f3-1f18-4ae6-8f44-627039dc9a80"), FirstName = "Максим",
                LastName = "Солонин", Patronymic = "Александрович", IsBusy = false},

            new Driver() { Id = new Guid("87eed312-d6a9-4ce0-b0c6-955326133227"), FirstName = "Владислав",
                LastName = "Тарасов", Patronymic = "Егорович", IsBusy = false},

            new Driver() { Id = new Guid("b15c792d-43f7-4497-b409-b9f5df37f13c"), FirstName = "Виктор",
                LastName = "Сергеев", Patronymic = "Витальевич", IsBusy = false},

            new Driver() { Id = new Guid("b71ec76c-3bc8-4e80-9c30-388221e653eb"), FirstName = "Евгений",
                LastName = "Поздняков", Patronymic = "Иванович", IsBusy = false},

            new Driver() { Id = new Guid("b7f6cb5d-2132-4aef-bc76-0c7d7be1630a"), FirstName = "Иван",
                LastName = "Коломейцев", Patronymic = "Сергеевич", IsBusy = false},
        };
    }
}
