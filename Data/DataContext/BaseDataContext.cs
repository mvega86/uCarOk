using uCarOk.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace uCarOk.Data.DataContext
{
    public class BaseDataContext: DbContext
    {
        public BaseDataContext(DbContextOptions<BaseDataContext> options)
            : base(options)
        {
        }

        public DbSet<Mechanic> Mechanics{ get; set; }
    }
}
