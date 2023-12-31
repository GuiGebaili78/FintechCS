﻿using Fintech.Models;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<UsuarioModel> tb_usuario { get; set; }

        public DbSet<CategoriaModel> tb_categoria { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
