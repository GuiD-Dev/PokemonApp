using Microsoft.EntityFrameworkCore;

namespace PokemonApp.src;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly Context _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(Context context) {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void InsertOne(T entity) => _dbSet.Add(entity);
    public void InsertMany(IEnumerable<T> entities) => _dbSet.AddRange(entities);
    public void UpdateOne(T entity) => _dbSet.Update(entity);
    public void UpdateMany(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
    public void DeleteOne(T entity) => _dbSet.Remove(entity);
    public void DeleteMany(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

    public async Task SaveChanges() => await _context.SaveChangesAsync();
}