using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;

        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _genresService.GetAll();
            return Ok(genres);
        }        
        [HttpPost]
        public async Task<IActionResult> PostAsync(GenreDto dto)
        {
            Genre genre = new() {Name = dto.Name };
            await _genresService.Post(genre);
            return Ok("element added");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] GenreDto dto)
        {
            var genre = await _genresService.GetById(id);
            if (genre is null)
                return NotFound("element not found");
            genre.Name = dto.Name;
            _genresService.Put(genre);
            return Ok("element Updated");
        }        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var genre = await _genresService.GetById(id);
            if (genre is null)
                return NotFound("element not found");
            _genresService.Delete(genre);
            return Ok("element deleted");
        }
    }
}
