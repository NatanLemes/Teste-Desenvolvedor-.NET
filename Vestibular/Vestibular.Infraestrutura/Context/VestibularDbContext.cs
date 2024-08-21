using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Vestibular.Domain.Entities;

namespace Vestibular.Infraestrutura.Context
{
    public class VestibularDbContext : DbContext
    {
        private IConfiguration _configuration;

        public VestibularDbContext(IConfiguration  configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("MySql");
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inscricao>()
                .HasOne(x => x.Candidato)
                .WithMany(x => x.Inscricoes)
                .HasForeignKey(x => x.IdCandidato)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Inscricao>()
                .HasOne(x => x.ProcessoSeletivo)
                .WithMany(x => x.Inscricoes)
                .HasForeignKey(x => x.IdProcessoSeletivo)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Inscricao>()
                .HasOne(x => x.Oferta)
                .WithMany(x => x.Inscricoes)
                .HasForeignKey(x => x.IdOferta)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<ProcessoSeletivo> ProcessosSeletivos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
