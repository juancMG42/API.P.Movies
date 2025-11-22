using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models
{
    public class Movie : AuditBase //se crea la clase Movie
    {
        
        [Required] //este decorator me obliga a que el campo no sea nulo

        [MaxLength(100)] // este decorator me limita la cantidad de caracteres a 100

        [Display(Name = "Nombre")] //Este decorator me permite cambiar el nombre de la propiedad en las vistas
        public string name { get; set; }



        [Required] //este decorator me obliga a que el campo no sea nulo

        [Display(Name = "duracion")] //Este decorator me permite cambiar el nombre de la propiedad en las vistas
        public int duration { get; set; }


        [Display(Name = "descripcion")] //Este decorator me permite cambiar el nombre de la propiedad en las vistas
        public string? description { get; set; }



        [Required] //este decorator me obliga a que el campo no sea nulo

        [MaxLength(10)]// este decorator me limita la cantidad de caracteres a 10

        [Display(Name = "clasificacion")] //Este decorator me permite cambiar el nombre de la propiedad en las vistas
        public string clasification { get; set; }

    }
}
