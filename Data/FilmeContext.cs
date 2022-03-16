using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmeAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}