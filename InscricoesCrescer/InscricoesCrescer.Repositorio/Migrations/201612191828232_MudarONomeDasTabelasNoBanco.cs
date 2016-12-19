namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudarONomeDasTabelasNoBanco : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AdministradorEntidade", newName: "Administrador");
            RenameTable(name: "dbo.CandidatoEntidade", newName: "Candidato");
            RenameTable(name: "dbo.EntrevistaEntidade", newName: "Entrevista");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Entrevista", newName: "EntrevistaEntidade");
            RenameTable(name: "dbo.Candidato", newName: "CandidatoEntidade");
            RenameTable(name: "dbo.Administrador", newName: "AdministradorEntidade");
        }
    }
}
