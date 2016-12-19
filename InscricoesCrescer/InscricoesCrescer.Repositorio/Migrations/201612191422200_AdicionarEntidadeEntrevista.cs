namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarEntidadeEntrevista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntrevistaEntidade",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmailAdministrador = c.String(),
                        DataEntrevista = c.DateTime(nullable: false),
                        ParecerRH = c.String(),
                        ParecerTecnico = c.String(),
                        ProvaG36 = c.Double(nullable: false),
                        ProvaAC = c.Double(nullable: false),
                        ProvaTecnica = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntrevistaEntidade");
        }
    }
}
