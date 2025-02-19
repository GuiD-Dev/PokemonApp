namespace PokemonApp.src;

public interface IBaseRepository<T> where T : class
{
    void InsertOne(T entity);
    void InsertMany(IEnumerable<T> entities);
    void UpdateOne(T entity);
    void UpdateMany(IEnumerable<T> entities);
    void DeleteOne(T entity);
    void DeleteMany(IEnumerable<T> entities);
    Task SaveChanges();
}
