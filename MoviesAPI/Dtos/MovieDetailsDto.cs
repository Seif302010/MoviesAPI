namespace MoviesAPI.Dtos
{
    public class MovieDetailsDto
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int ReleaseDate { get; set; }

        public double Rate { get; set; }
        public string StoryLine { get; set; }

        public byte[] Poster { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
