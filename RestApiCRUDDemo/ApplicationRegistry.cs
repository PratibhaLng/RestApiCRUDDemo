
using Lamar;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;


namespace RestApiCRUDDemo
{
    public class ApplicationRegistry : ServiceRegistry
    {
        public ApplicationRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
                assembly.GetName().Name.StartsWith("RestApiCRUDDemo."));
            });
            IConfigurationBuilder builder = new ConfigurationBuilder()
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            string path = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).Location);
        }
    

    
    }
}
