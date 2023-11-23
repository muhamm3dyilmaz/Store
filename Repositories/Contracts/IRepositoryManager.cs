using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepo { get; }
        ICategoryRepository CategoryRepo { get; }

        void Save();
    }
}