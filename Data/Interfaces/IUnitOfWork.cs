using Models.Interfaces;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<T> Repository<T>() where T : class, IEntity;
        void Save();
        void Dispose();
    }
}
