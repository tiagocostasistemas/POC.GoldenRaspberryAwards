﻿using POC.GoldenRaspberryAwards.API.Domain.Entities;

namespace POC.GoldenRaspberryAwards.API.Data.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAll();
    Task<Movie> GetById(Guid id);
    Task<Movie> Insert(Movie movie);
    Task<Movie> Update(Movie movie);
    Task Delete(Movie movie);
}
