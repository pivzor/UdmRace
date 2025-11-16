 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdmurtRace.Domain.Entities;

namespace UdmurtRace.DAL
{
    public class AppDbContext : DbContext
    {

            public DbSet<RaceEntity> Races { get; set; }
            public DbSet<SaleEntity> Sales { get; set; }
            public DbSet<ClientEntity> Clients { get; set; }

            public AppDbContext(DbContextOptions options) : base(options)
            {

            }
    }
}
