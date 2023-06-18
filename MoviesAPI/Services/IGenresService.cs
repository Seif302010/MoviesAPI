namespace MoviesAPI.Services
{
    public interface IGenresService
    {
        Task<IEnumerable<Genre>> GetAll();
        Task<Genre> GetById(int id);
        Task<Genre> Post(Genre genre);
        Genre Put(Genre genre);
        Genre Delete(Genre genre);
    }
}
