using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.DTOs.Category
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [StringLength(15, ErrorMessage = "El nombre de la categoría no puede superar los 15 caracteres.")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "La descripción no puede superar los 255 caracteres.")]
        public string? Description { get; set; }

        [Url(ErrorMessage = "La imagen debe ser una URL válida.")]
        [StringLength(255, ErrorMessage = "La URL de la imagen no puede superar los 255 caracteres.")]
        public string? Picture { get; set; }
    }
}
