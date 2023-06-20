using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMoviesService _moviesService;
        private readonly IGenresService _genresService;

        private new List<string> _allowedExtensions = new()
        {
            ".jpg",".png"
        };

        private static long _sizeinMB = 5;

        private long _maxAllowedPosterSize = _sizeinMB * 1024 * 1024;

        public MoviesController(IMoviesService moviesService, IGenresService genresService, IMapper mapper)
        {
            _moviesService = moviesService;
            _genresService = genresService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _moviesService.GetAll();
            var data = _mapper.Map<IEnumerable<MovieDetailsDto>>(movies);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm]MovieDto dto)
        {
            if (dto.Poster == null)
                return BadRequest("Poster is requird");
            
            if (!_allowedExtensions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("jpg and png only");
            if (dto.Poster.Length > _maxAllowedPosterSize)
                return BadRequest($"The max allowed size is {_sizeinMB} MB");

            var isValidGenre = await _genresService.GetById(dto.GenreId);

            if (isValidGenre is null)
                return NotFound("Genre not found");
          
            using var dataStream = new MemoryStream();

            await dto.Poster.CopyToAsync(dataStream);

            Movie movie = _mapper.Map<Movie>(dto);
            movie.Poster = dataStream.ToArray();
            await _moviesService.Post(movie);
            return Ok("element added");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromForm] MovieDto dto)
        {
            var movie = await _moviesService.GetById(id);
            if (movie is null)
                return NotFound("element not found");

            var isValidGenre = await _genresService.GetById(dto.GenreId);

            if (isValidGenre is null)
                return NotFound("Genre not found");

            if (dto.Poster != null)
            {
                if (!_allowedExtensions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("jpg and png only");
                if (dto.Poster.Length > _maxAllowedPosterSize)
                    return BadRequest($"The max allowed size is {_sizeinMB} MB");

                using var dataStream = new MemoryStream();

                await dto.Poster.CopyToAsync(dataStream);

                movie.Poster = dataStream.ToArray();
            }
            movie.Title = dto.Title;
            movie.ReleaseDate = dto.ReleaseDate;
            movie.Rate = dto.Rate;
            movie.StoryLine = dto.StoryLine;
            movie.GenreId = dto.GenreId;

            _moviesService.Put(movie);
            return Ok("element Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var movie = await _moviesService.GetById(id);
            if (movie is null)
                return NotFound("element not found");
            _moviesService.Delete(movie);
            return Ok("element deleted");
        }
    }
}
