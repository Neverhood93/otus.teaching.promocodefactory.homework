using Domain.Entities;

namespace Infrastructure.EntityFramework
{
    public static class FakeDataFactory
    {
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

        public static IEnumerable<Employee> Employees => new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.Parse("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"),
                Email = "owner@somemail.ru",
                FirstName = "Иван",
                LastName = "Сергеев",
                RoleId = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                AppliedPromocodesCount = 5
            },
            new Employee()
            {
                Id = Guid.Parse("f766e2bf-340a-46ea-bff3-f1700b435895"),
                Email = "andreev@somemail.ru",
                FirstName = "Петр",
                LastName = "Андреев",
                RoleId = Guid.Parse("53729686-a368-4eeb-8bfa-cc69b6050d02"),
                AppliedPromocodesCount = 10
            }
        };

        public static IEnumerable<Preference> Preferences => new List<Preference>()
        {
            new Preference()
            {
                Id = Guid.Parse("C1B3B585-C4B2-4CA8-9AC8-BC403D8A86D3"),
                Name = "Кино"
            },
            new Preference()
            {
                Id = Guid.Parse("86DD90E6-12BE-45B0-A637-EA82B04B1FCA"),
                Name = "Рестораны"
            }
        };

        public static IEnumerable<Customer> Customers => new List<Customer>()
        {
            new Customer()
            {
                Id = Guid.Parse("1F815DDD-5E3A-4D8A-A9BE-F30FE2197F7C"),
                Email = "petrov.r@somemail.ru",
                FirstName = "Роман",
                LastName = "Петров"
            },
            new Customer()
            {
                Id = Guid.Parse("8F08107E-BE11-4278-A40B-FC8C78B6C2CF"),
                Email = "gusev.a@somemail.ru",
                FirstName = "Алексей",
                LastName = "Гусев"
            }
        };

        public static IEnumerable<CustomerPreference> CustomerPreferences => new List<CustomerPreference>()
        {
            new CustomerPreference()
            {
                CustomerId = Guid.Parse("1F815DDD-5E3A-4D8A-A9BE-F30FE2197F7C"),    // Роман Петров
                PreferenceId = Guid.Parse("C1B3B585-C4B2-4CA8-9AC8-BC403D8A86D3")   // Кино
            },
            new CustomerPreference()
            {
                CustomerId = Guid.Parse("1F815DDD-5E3A-4D8A-A9BE-F30FE2197F7C"),    // Роман Петров
                PreferenceId = Guid.Parse("86DD90E6-12BE-45B0-A637-EA82B04B1FCA")   // Кино
            },
            new CustomerPreference()
            {
                CustomerId = Guid.Parse("8F08107E-BE11-4278-A40B-FC8C78B6C2CF"),    // Алексей Гусев
                PreferenceId = Guid.Parse("86DD90E6-12BE-45B0-A637-EA82B04B1FCA")   // Кино
            }
        };
    }
}