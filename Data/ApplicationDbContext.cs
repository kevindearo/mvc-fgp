using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdutosWeb.Models;

namespace ProdutosWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public static readonly ILoggerFactory loggerFactory = LoggerFactory
            .Create(builder => builder.AddConsole());


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
