namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mudarDataNascimentoParaAnulavel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CandidatoEntidade", "DataNascimento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CandidatoEntidade", "DataNascimento", c => c.DateTime(nullable: false));
        }
    }
}
