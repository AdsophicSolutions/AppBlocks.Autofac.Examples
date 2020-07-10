using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.CustomServiceLogger
{
    public interface IAsyncService
    {
        Task<int> Run();
    }
}
