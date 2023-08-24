using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Persistence
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }


    }
}