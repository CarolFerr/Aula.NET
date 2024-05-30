using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Imobiliaria.Models;
//Arquivo que faz conexão com o banco de dados
    public class ImobiliariaContext : DbContext
    {
        public ImobiliariaContext (DbContextOptions<ImobiliariaContext> options)
            : base(options)
        {
        }

        public DbSet<Imobiliaria.Models.Cliente> Cliente { get; set; }

        public DbSet<Imobiliaria.Models.Imoveis> Imoveis { get; set; }

        public DbSet<Imobiliaria.Models.Contrato> Contrato { get; set; }
    }
