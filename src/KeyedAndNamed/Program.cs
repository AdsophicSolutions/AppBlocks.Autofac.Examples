using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace AppBlocks.Autofac.Examples.KeyedAndNamed
{
    class Program
    {
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            new Example().Run();
        }
    }
}
