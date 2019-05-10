using ProductAppApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAppApi.Core.IRepository
{
    /// <summary>
    /// this is the IProduct interface
    /// it's needed when having behaviers that is spacific to this entity
    /// </summary>
    public interface IProduct:IRepository<Product>
    {
    }
}
