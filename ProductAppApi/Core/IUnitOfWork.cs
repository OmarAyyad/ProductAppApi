using ProductAppApi.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProduct Products { get; }

        int complete();
    }
}
