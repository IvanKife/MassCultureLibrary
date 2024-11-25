
﻿using MassCultureLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassCultureLibrary.Animes

{
    public class AnimeService : IAnimeService
    {
        IAnimeRepository _repository;
        public AnimeService(IAnimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Anime> AddAnimeAsync(Anime anime) => await _repository.AddAsync(anime);

        public async Task<IEnumerable<Anime>> GetAnimeAsync() => await _repository.GetAllAsync();

        public async Task<Anime?> GetAnimeByIdAsync(Guid animeId) => await _repository.GetByIdAsync(animeId);

        public async Task<IEnumerable<Anime>> GetAnimeByStatusAsync(string status)

        public async Task DeleteAnimeByIdAsync(Guid animeId) // реализация удаления по Id
        {
            var anime = _repository.GetByIdAsync(animeId);
            if (anime == null)
                throw new KeyNotFoundException($"Аниме с Id: {animeId} не найдена. ");

            await _repository.DeleteAsync(animeId);
        }

        public Task DeleteAnimeAsync(Anime anime) // реализация удаления всего объекта

        public async Task DeleteAnimeAsync(Guid animeId)
        {
            await _repository.DeleteAsync(animeId);
        }

        public Task<Guid> GetAnimeIdByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
        
        public Task<string> GetAnimeTitleById(Guid animeId)
        {
            throw new NotImplementedException();
        }
        
        public Task<Anime?> GetAnimeByIdAsync(Guid animeId) 
        {
            return await _repository.GetByIdAsync(animeId);
        }
        
        public Task<Anime?> GetAnimeByTitleAsync(string title) // получение аниме по названию
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<Anime>> GetAnimeByGenreAsync(string genre) // получение списка аниме по выбранному жанру
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Anime>> GetAnimeByGenreAsync(string status)
        {
            throw new NotImplementedException();
        }

        public Task<List<Anime>> GetAnimesByGenreAsync(string genre)
        {
            throw new NotImplementedException();
        }

        public async Task<Anime> UpdateAnimeAsync(Guid animeId, AnimeUpdateDto updateInfo)
        {
            var anime = await _repository.GetByIdAsync(animeId);
            anime.Status = updateInfo.Status;
            await _repository.UpdateAsync(anime);
            return anime;
        }
    }
}
