using Lab_4.Models;
using Lab_4.Serviecs;

namespace Lab_4.Repositories;

public interface IMusicRepository {
    //вывести информацию обо всех существующих в каталоге композициях
    public List<MusicModel> GetAll();   
    //добавить информацию о композиции в каталог 
    public Task AddMusic(MusicModel music); 
    public List<MusicModel> FindByPartOfName(string PartOfName); 
    public Task DeleteMusic(string title); 
}