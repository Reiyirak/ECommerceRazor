using System.Linq.Expressions;

namespace ECommerce.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    // Metodos para CRUD. Leer registros, registro individual
    // Crear registro, Borrar, Borrar Masivo
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
    IEnumerable<T> GetAll();
    T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
    bool NameExists(string name);
}
