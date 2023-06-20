namespace MoviesAPI.Models.DomainModels
{
    [Index(nameof(Title), IsUnique = true)]
    public class Movie : MovieBaseModel
    {
        public Genre Genre { get; set; }
    }
}
