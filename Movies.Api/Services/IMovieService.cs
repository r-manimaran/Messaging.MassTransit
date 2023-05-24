using Movies.Api.Models;

namespace Movies.Api.Services;

public interface IMovieService
{
    Task<Movie> CreateAsync(Movie movie);
    Task<Movie> UpdateAsync(Movie movie);
    Task<bool> DeleteAsync(Guid id);
    Task<Movie?> GetAsync(Guid id);
}
