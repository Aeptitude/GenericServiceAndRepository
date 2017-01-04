using TestingGenerics.Models.Interfaces;

namespace TestingGenerics.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Repository<T> Repository<T>() where T : class, IEntity;
        void Save();
        void Dispose();
    }
}
