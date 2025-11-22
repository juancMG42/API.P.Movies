using API.P.Movies.DAL.Models;

namespace API.P.Movies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync(); //Me retorna una lista de películas
        Task<Movie> GetMovieAsync(int id); //Me retorna una película por su Id
        Task<bool> MovieExistsByIdAsync(int id); //Me dice si una película existe por su Id
        Task<bool> MovieExistsByNameAsync(string name); //Me dice si una película existe por su nombre
        Task<bool> CreateMovieAsync(Movie movie); //Me crea una película
        Task<bool> UpdateMovieAsync(Movie movie); //Me actualiza una película
        Task<bool> DeleteMovieAsync(int id); //Me elimina una película

    }
}
