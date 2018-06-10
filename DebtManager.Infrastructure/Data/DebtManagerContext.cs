using DebtManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtManager.Infrastructure.Data
{
    public class DebtManagerContext : DbContext
    {
        public DebtManagerContext (DbContextOptions<DebtManagerContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MyDebit> MyDebts { get; set; }
        public DbSet<TheirDebt> TheirDebts { get; set; }
    }
}
