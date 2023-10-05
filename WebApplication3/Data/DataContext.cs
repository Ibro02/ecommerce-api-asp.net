﻿
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class DataContext : DbContext
    {


        public DataContext(Microsoft.EntityFrameworkCore.DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Models.User> Users => Set<Models.User>();



    }
}
