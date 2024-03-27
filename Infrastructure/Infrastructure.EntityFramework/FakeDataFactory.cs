﻿using Domain.Entities;

namespace Infrastructure.EntityFramework
{
    public static class FakeDataFactory
    {
        public static IEnumerable<Employee> Employees => new List<Employee>()
        {
            new Employee()
            {
                //Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                Email = "owner@somemail.ru",
                FirstName = "Иван",
                LastName = "Сергеев",
                RoleId = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                AppliedPromocodesCount = 5
            },
            new Employee()
            {
                //Id = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                Email = "andreev@somemail.ru",
                FirstName = "Петр",
                LastName = "Андреев",
                RoleId = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                AppliedPromocodesCount = 10
            },
        };

        public static IEnumerable<Role> Roles => new List<Role>()
        {
            new Role()
            {
                Id = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                Name = "Admin",
                Description = "Администратор",
            },
            new Role()
            {
                Id = Guid.Parse("b0ae7aac-5493-45cd-ad16-87426a5e7665"),
                Name = "PartnerManager",
                Description = "Партнерский менеджер"
            }
        };
    }
}