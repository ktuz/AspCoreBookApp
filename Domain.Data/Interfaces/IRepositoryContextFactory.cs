using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Data.Interfaces
{
    public interface IRepositoryContextFactory
    {
        RepositoryContext CreateDbContext(string connectionString);
    }
}
