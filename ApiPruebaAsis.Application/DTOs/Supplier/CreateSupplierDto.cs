using System.ComponentModel.DataAnnotations;

public class CreateSupplierDto
{
    [Required(ErrorMessage = "El nombre de la compañía es obligatorio.")]
    [StringLength(40, ErrorMessage = "El nombre de la compañía no puede superar los 40 caracteres.")]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(30, ErrorMessage = "El nombre del contacto no puede superar los 30 caracteres.")]
    public string? ContactName { get; set; }

    [StringLength(30, ErrorMessage = "El cargo del contacto no puede superar los 30 caracteres.")]
    public string? ContactTitle { get; set; }

    [StringLength(60, ErrorMessage = "La dirección no puede superar los 60 caracteres.")]
    public string? Address { get; set; }

    [StringLength(15, ErrorMessage = "La ciudad no puede superar los 15 caracteres.")]
    public string? City { get; set; }

    [StringLength(15, ErrorMessage = "La región no puede superar los 15 caracteres.")]
    public string? Region { get; set; }

    [StringLength(10, ErrorMessage = "El código postal no puede superar los 10 caracteres.")]
    public string? PostalCode { get; set; }

    [StringLength(15, ErrorMessage = "El país no puede superar los 15 caracteres.")]
    public string? Country { get; set; }

    [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
    [StringLength(24, ErrorMessage = "El teléfono no puede superar los 24 caracteres.")]
    public string? Phone { get; set; }

    [Phone(ErrorMessage = "El fax no tiene un formato válido.")]
    [StringLength(24, ErrorMessage = "El fax no puede superar los 24 caracteres.")]
    public string? Fax { get; set; }

    [Url(ErrorMessage = "La página web debe ser una URL válida.")]
    [StringLength(255, ErrorMessage = "La página web no puede superar los 255 caracteres.")]
    public string? HomePage { get; set; }
}