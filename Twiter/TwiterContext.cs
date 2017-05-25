using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Twiter
{
    public partial class TwiterContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseNpgsql(@"Host=localhost;Database=Twiter;Username=postgres;Password=chris");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}