namespace MoviesAPI.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<Movie>> GetAll();
        Task<Movie> GetById(int id);
        Task<Movie> Post(Movie movie);
        Movie Put(Movie movie);
        Movie Delete(Movie movie);
    }
}
