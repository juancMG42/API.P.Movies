using API.P.Movies.DAL.Models;
using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Repository.IRepository;
using API.P.Movies.Services.IServices;
using AutoMapper;

namespace API.P.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _movieRepository.MovieExistsByIdAsync(id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _movieRepository.MovieExistsByNameAsync(name);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto dto)
        {
            // Verificar si ya existe una película con ese nombre
            var movieExists = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException(
                    $"Ya existe una película con el nombre '{dto.Name}'");
            }

            // Mapear de DTO → Modelo Movie
            var movie = _mapper.Map<Movie>(dto);

            // Crear película en BD
            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new InvalidOperationException(
                    "Ocurrió un error al crear la película");
            }

            // Convertir a DTO para retornar
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            // Validar si la película existe
            var existingMovie = await _movieRepository.GetMovieAsync(id);

            if (existingMovie == null)
            {
                throw new KeyNotFoundException(
                    $"No se encontró la película con Id {id}");
            }

            // Validar si el nuevo nombre ya existe
            var movieExistsByName = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (movieExistsByName)
            {
                throw new InvalidOperationException(
                    $"Ya existe una película con el nombre '{dto.Name}'");
            }

            // Mapear DTO → entidad existente
            _mapper.Map(dto, existingMovie);

            // Actualizar película
            var movieUpdated = await _movieRepository.UpdateMovieAsync(existingMovie);

            if (!movieUpdated)
            {
                throw new InvalidOperationException(
                    "Ocurrió un error al actualizar la película");
            }

            return _mapper.Map<MovieDto>(existingMovie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            // Validar si existe
            var existingMovie = await _movieRepository.GetMovieAsync(id);

            if (existingMovie == null)
            {
                throw new InvalidOperationException(
                    $"No se encontró la película con Id {id}");
            }

            // Eliminar
            var movieDeleted = await _movieRepository.DeleteMovieAsync(id);

            if (!movieDeleted)
            {
                throw new InvalidOperationException(
                    "Ocurrió un error al eliminar la película");
            }

            return movieDeleted;

        }

        
    }
}
