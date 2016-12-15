namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InserirCandidatoEntidade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidatoEntidade",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Instituicao = c.String(),
                        Conclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CandidatoEntidade");
        }
    }
}
