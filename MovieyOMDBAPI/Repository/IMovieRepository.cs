using MovieyOMDBAPI.Models;
using System.Collections.Generic;

namespace MovieyOMDBAPI.Repository
{
    public interface IMovieRepository
    {
        void AddMovie(Movie movie);
        List<Movie> GetMovie();
        void DeleteMovie(string id);
    }
}
