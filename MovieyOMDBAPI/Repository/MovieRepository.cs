using MovieyOMDBAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieyOMDBAPI.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Datacontext db;

        public MovieRepository(Datacontext db)
        {
            this.db = db;
        }

        public void AddMovie(Movie movie)
        {
            db.Movie.Add(movie);
            db.SaveChanges();
        }

        public void DeleteMovie(string id)
        {
            var Mov = db.Movie.Where(x => x.ImdbID == id).FirstOrDefault();
            db.Movie.Remove(Mov);
            db.SaveChanges();
        }

        public List<Movie> GetMovie()
        {
            return db.Movie.ToList();
        }
    }
}
