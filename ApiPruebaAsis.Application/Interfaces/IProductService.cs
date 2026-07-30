using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Interfaces
{
    public interface IProductService
    {
        Task GenerateProductsService(int quantity);
    }
}
