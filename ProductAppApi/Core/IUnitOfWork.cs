using ProductAppApi.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Core
{
    /// <summary>
    /// this is the Iunitofwork interface to determine the guidlines for the unitofwork class
    /// and it implements IDisposible so that we dispose the context when the work is done and not take much space in memory
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// property Products that we can get through the unitofwork
        /// </summary>
        IProduct Products { get; }

        /// <summary>
        /// complete method that saves changes to the context and therefor the Database
        /// </summary>
        /// <returns></returns>
        int complete();
    }
}
