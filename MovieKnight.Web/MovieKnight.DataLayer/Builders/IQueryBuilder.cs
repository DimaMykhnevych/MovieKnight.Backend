using System.Linq;

namespace MovieKnight.DataLayer.Builders
{
    public interface IQueryBuilder<TEntity>
    {
        IQueryable<TEntity> Build();
    }
}
