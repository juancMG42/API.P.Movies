using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la película es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración de la película es obligatoria.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres es de 10.")]
        public string Clasification { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
