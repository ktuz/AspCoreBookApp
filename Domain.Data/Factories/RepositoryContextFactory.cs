using Domain.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
       public RepositoryContext CreateDbContext(string connectingString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlServer(connectingString);
            return new RepositoryContext(optionsBuilder.Options);
        }


    }
}
