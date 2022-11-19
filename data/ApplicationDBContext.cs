using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project2.Models;
using Microsoft.EntityFrameworkCore;

namespace project2.data;
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {       
        }

        public DbSet<Category> Categories {get; set;}
    }
