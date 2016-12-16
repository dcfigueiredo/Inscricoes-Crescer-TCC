namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdionarNovosCamposCandidato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidatoEntidade", "Telefone", c => c.Int(nullable: false));
            AddColumn("dbo.CandidatoEntidade", "Linkedin", c => c.String());
            AddColumn("dbo.CandidatoEntidade", "DataNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.CandidatoEntidade", "Cidade", c => c.String());
            AddColumn("dbo.CandidatoEntidade", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CandidatoEntidade", "Senha");
            DropColumn("dbo.CandidatoEntidade", "Cidade");
            DropColumn("dbo.CandidatoEntidade", "DataNascimento");
            DropColumn("dbo.CandidatoEntidade", "Linkedin");
            DropColumn("dbo.CandidatoEntidade", "Telefone");
        }
    }
}
