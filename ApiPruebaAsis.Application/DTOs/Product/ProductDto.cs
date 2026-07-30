using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.DTOs.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public short UnitsInStock { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string SupplierName { get; set; } = string.Empty;
    }
}
