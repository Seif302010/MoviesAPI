using System.Xml.Linq;
namespace MoviesAPI.Models.DomainModels
{
    [Index(nameof(Title), IsUnique = true)]
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        public int ReleaseDate { get; set; }

        public double Rate { get; set; }

        [MaxLength(2500)]
        public string StoryLine { get; set; }

        public byte[] Poster { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
