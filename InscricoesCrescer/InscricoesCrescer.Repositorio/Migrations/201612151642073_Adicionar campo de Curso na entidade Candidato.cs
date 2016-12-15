namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarcampodeCursonaentidadeCandidato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidatoEntidade", "Curso", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CandidatoEntidade", "Curso");
        }
    }
}
