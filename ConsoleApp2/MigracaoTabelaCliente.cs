using FluentMigrator;

namespace projetoWebPuc
{
    [Migration(20230927)]
    public class MigracaoTabelaCliente : Migration
    {
        public override void Up()
        {
            Create.Table("ClientePUC")
                .WithColumn("CPF").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Data_Nascimento").AsDate().NotNullable()
                .WithColumn("Email").AsString().NotNullable()
                .WithColumn("Profissao").AsString().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Times");
        }
    }
}
