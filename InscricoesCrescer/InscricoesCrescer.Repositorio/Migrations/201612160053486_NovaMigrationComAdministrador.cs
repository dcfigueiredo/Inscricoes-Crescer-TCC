namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaMigrationComAdministrador : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorEntidade",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdministradorEntidade");
        }
    }
}
