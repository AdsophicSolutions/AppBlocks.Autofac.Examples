using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBlocks.Autofac.Examples.QuickStart
{
    public interface IAsyncService
    {
        public Task<int> Run();
    }
}
