namespace MoviesAPI.Models.DomainModels
{
    [Index(nameof(Name), IsUnique = true)]
    public class Genre 
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
