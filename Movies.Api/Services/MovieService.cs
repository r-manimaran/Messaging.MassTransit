using MassTransit;
using Movies.Api.Models;
using MoviesMessaging.Contracts;
using System.Collections.Concurrent;

namespace Movies.Api.Services;

public class MovieService : IMovieService
{
    private readonly ConcurrentDictionary<Guid, Movie> _movies = new();
    private readonly IBus _bus;

    //if the MovieSerive is registered as Scope,use the below instead of IBus
    //IPublishEndpoint is registered as Scope so it will suits. 
    //private readonly IPublishEndpoint _publishEndpoint;

    //Here MovieService is registerd as Singleton, so using IBus

    public MovieService(IBus bus)
    {
        _bus = bus;
    }


    public async Task<Movie> CreateAsync(Movie movie)
    {
        _movies[movie.Id] = movie;
        
        //Publish the new Movie created information using MassTransit
        var newMovieMessage = new MovieCreated(movie.Id, movie.Name, movie.Genre, movie.YearReleased);
        await _bus.Publish(newMovieMessage);
        
        return movie;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        _movies.Remove(id, out var movie);

        if(movie is null)
        {
            return false;
        }
        
        //Send Message
        var deletedMessageMovie = new MovieDeleted(id, movie.Name, movie.Genre, movie.YearReleased);
        await _bus.Publish(deletedMessageMovie);
        
        return true;
    }

    public async Task<Movie?> GetAsync(Guid id)
    {
        return _movies.GetValueOrDefault(id);
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {
        var movieToUpdate = _movies.GetValueOrDefault(movie.Id);
        if(movieToUpdate is not null)
        {
            _movies[movieToUpdate.Id] = movie;
        }


        //Publish the movie updated using
        var messageMovieUpdated = new MovieUpdated(movie.Id, movie.Name, movie.Genre, movie.YearReleased);
        await _bus.Publish(messageMovieUpdated);
        return movie;
    }


}
