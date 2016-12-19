using InscricoesCrescer.Dominio.Administrador;
using InscricoesCrescer.Dominio.Candidato;
using InscricoesCrescer.Dominio.Entrevista;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace InscricoesCrescer.Repositorio
{
    public class ContextoDeDados : DbContext
    {
        public ContextoDeDados() : base("inscricoes")
        {

        }

        public DbSet<CandidatoEntidade> Candidato { get; set; }

        public DbSet<AdministradorEntidade> Administrador { get; set; }

        public DbSet<EntrevistaEntidade> Entrevista { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}