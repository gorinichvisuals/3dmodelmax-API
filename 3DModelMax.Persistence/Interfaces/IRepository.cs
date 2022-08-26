namespace _3DModelMax.Persistence.Services
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get3DmodelsList();
        Task<T> Get3DmodelsById(int id);
        Task Delete3DmodelsById(int id);
        Task Create(T item);
        Task Update(T item);
        Task Save();
    }
}
