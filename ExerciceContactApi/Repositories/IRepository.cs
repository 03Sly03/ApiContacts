using ExerciceContactApi.Models;
using System.Linq.Expressions;

namespace ExerciceContactApi.Repositories
{
    public interface IRepository<TEntity>
    {
        bool Post(TEntity entity);
        List<TEntity> Get();
        TEntity? GetById(int id);
        List<TEntity>? GetByFirstname(string @string);
        bool Put(TEntity entity);
        bool Delete(int id);
    }
}
