using Microsoft.EntityFrameworkCore;
using POC.GoldenRaspberryAwards.API.Data.Contexts;
using POC.GoldenRaspberryAwards.API.Domain.Entities;

namespace POC.GoldenRaspberryAwards.API.Data.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly DataContext _context;

    public MovieRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> GetAll() => await GetAllMovies();

    public async Task<Movie> GetById(Guid id)
    {
        var producers = await GetAllMovies();
        return producers.Where(producer => producer.Id.Equals(id)).FirstOrDefault()!;
    }

    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        return await _context.Movies.ToListAsync();
    }

    public async Task<Movie> Insert(Movie movie)
    {
        movie.Id = Guid.NewGuid();
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task<Movie> Update(Movie movie)
    {
        _context.Attach(movie);
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return movie;
    }

    public async Task Delete(Movie movie)
    {
        _context.Remove(movie);
        await _context.SaveChangesAsync();
    }
}
