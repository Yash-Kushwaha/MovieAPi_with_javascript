using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieyOMDBAPI.Models
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
