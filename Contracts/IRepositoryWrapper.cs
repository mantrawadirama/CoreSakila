using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task Save();
    }
}
