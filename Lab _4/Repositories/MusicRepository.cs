﻿using Lab_4.DB;
using Lab_4.Models;
using Lab_4.Serviecs;

namespace Lab_4.Repositories;

public class MusicRepository:IMusicRepository {
    private readonly MusicCatalogContext _dbContext;
    public MusicRepository(MusicCatalogContext dbContext)
    {
        _dbContext = dbContext;
        //_dbContext.Database.EnsureCreated(); // true если база данных создана, false если она уже существует.
    }
    
    public List<MusicModel> GetAll() { 
        if (_dbContext.Musics == null) return new List<MusicModel>();
        return _dbContext.Musics.ToList();
    }
     
    // list
    public Task AddMusic(MusicModel music) { 
        _dbContext.Musics.Add(music); 
        return _dbContext.SaveChangesAsync(); 
    }
    
    //searchByAuthor
    public List<MusicModel> FindByPartOfName(string PartOfName) {
        return new List<MusicModel>(GetAll().Where(m => m.composition.Contains(PartOfName)));
    }
    //delete
    public Task DeleteMusic(string title) { 
        var elements = title.Split("-");
        MusicModel music = _dbContext.Musics.FirstOrDefault(music => music.author == elements[0] && music.composition == elements[1]);
        _dbContext.Remove(music);
        return _dbContext.SaveChangesAsync();
    }
}