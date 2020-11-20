using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DipsApi.Models;
using Microsoft.EntityFrameworkCore;


namespace DipsApi.Models
{
    public class BpContext : DbContext
    {
        public BpContext(DbContextOptions<BpContext> options)
            : base(options)
        {
        }

        public DbSet<Measurement> Measurements { get; set; }
    }
}
