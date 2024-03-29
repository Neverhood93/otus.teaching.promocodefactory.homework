﻿using Infrastructure.EntityFramework;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations
{
    public class EFDataInitializer : IDataInitializer
    {
        protected readonly DatabaseContext Context;

        public EFDataInitializer(DatabaseContext context) 
        {
            Context = context;
        }

        public void InitData()
        {
            Context.Database.EnsureDeleted();

            Context.Database.EnsureCreated();

            Context.AddRange(FakeDataFactory.Roles);
            Context.AddRange(FakeDataFactory.Employees);
            Context.AddRange(FakeDataFactory.Customers);
            Context.AddRange(FakeDataFactory.Preferences);
            Context.AddRange(FakeDataFactory.CustomerPreferences);

            Context.SaveChanges();
        }
    }
}
