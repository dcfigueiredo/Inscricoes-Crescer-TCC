namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarNomeAdministrador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdministradorEntidade", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdministradorEntidade", "Nome");
        }
    }
}
