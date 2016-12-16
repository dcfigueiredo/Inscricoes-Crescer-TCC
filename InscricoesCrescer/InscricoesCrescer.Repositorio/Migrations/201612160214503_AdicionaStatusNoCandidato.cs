namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionaStatusNoCandidato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidatoEntidade", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CandidatoEntidade", "Status");
        }
    }
}
