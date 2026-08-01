using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.DTOs.Product
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(40, ErrorMessage = "El nombre no puede superar los 40 caracteres.")]
        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una categoría válida.")]
        public int CategoryId { get; set; }

        public int? SupplierId { get; set; }

        [Required(ErrorMessage = "La cantidad por unidad es obligatoria.")]
        [StringLength(20, ErrorMessage = "La cantidad por unidad no puede superar los 20 caracteres.")]
        public string? QuantityPerUnit { get; set; }

        [Range(0.01, double.MaxValue,
         ErrorMessage = "El precio debe ser mayor a cero.")]
        public decimal UnitPrice { get; set; }

        [Range(0, short.MaxValue,
            ErrorMessage = "El stock no puede ser negativo.")]
        public short UnitsInStock { get; set; }

        [Range(0, short.MaxValue,
            ErrorMessage = "Las unidades en orden no pueden ser negativas.")]
        public short UnitsOnOrder { get; set; }

        [Range(0, short.MaxValue,
            ErrorMessage = "El nivel de reorden no puede ser negativo.")]
        public short ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
