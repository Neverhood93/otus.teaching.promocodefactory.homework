﻿using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
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
            Context.SaveChanges();

            Context.AddRange(FakeDataFactory.Employees);
            Context.SaveChanges();
        }
    }
}
