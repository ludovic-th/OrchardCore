using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using OrchardCore.Recipes.Services;

namespace OrchardCore.Demo
{
    public class Migrations : DataMigration
    {
        private IContentDefinitionManager _contentDefinitionManager;
        private readonly IRecipeMigrator _recipeMigrator;

        public Migrations(IContentDefinitionManager contentDefinitionManager, IRecipeMigrator recipeMigrator)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _recipeMigrator = recipeMigrator;
        }
        
        public async Task<int> CreateAsync()
        {
            _contentDefinitionManager.AlterTypeDefinition("Foo", builder => builder
                .WithPart("TestContentPartA")
                .WithPart("TestContentPartB")
            );

            await _recipeMigrator.ExecuteAsync("migration.recipe.json" ,this);

            return 1;
        }
    }
}
