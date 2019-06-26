using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sedc.OnionArchitecture.Repositories
{
    class SchoolContextFactory: IDesignTimeDbContextFactory<SchoolContext>
    {
        public SchoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            optionsBuilder.UseInMemoryDatabase("ContosoUniversity");

            return new SchoolContext(optionsBuilder.Options);
        }
    }
}
