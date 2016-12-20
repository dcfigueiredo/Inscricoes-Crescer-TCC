namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarForeignKeyNaTabelaEntrevistas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entrevista", "CandidatoEntidadeId", "dbo.Candidato");
            DropIndex("dbo.Entrevista", new[] { "CandidatoEntidadeId" });
            AlterColumn("dbo.Entrevista", "CandidatoEntidadeId", c => c.Long(nullable: false));
            CreateIndex("dbo.Entrevista", "CandidatoEntidadeId");
            AddForeignKey("dbo.Entrevista", "CandidatoEntidadeId", "dbo.Candidato", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entrevista", "CandidatoEntidadeId", "dbo.Candidato");
            DropIndex("dbo.Entrevista", new[] { "CandidatoEntidadeId" });
            AlterColumn("dbo.Entrevista", "CandidatoEntidadeId", c => c.Long());
            CreateIndex("dbo.Entrevista", "CandidatoEntidadeId");
            AddForeignKey("dbo.Entrevista", "CandidatoEntidadeId", "dbo.Candidato", "Id");
        }
    }
}
