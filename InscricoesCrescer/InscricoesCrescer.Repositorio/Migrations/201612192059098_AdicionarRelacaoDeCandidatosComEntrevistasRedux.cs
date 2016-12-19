namespace InscricoesCrescer.Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarRelacaoDeCandidatosComEntrevistasRedux : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcessoSeletivo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DataInicioEntrevistas = c.DateTime(nullable: false),
                        DataSelecaoFinal = c.DateTime(nullable: false),
                        DataInicioAulas = c.DateTime(nullable: false),
                        DataFinalAulas = c.DateTime(nullable: false),
                        AnoEdicao = c.Int(nullable: false),
                        SemestreEdicao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProcessoSeletivo");
        }
    }
}
