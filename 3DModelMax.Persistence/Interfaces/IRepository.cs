namespace _3DModelMax.Persistence.Services
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> Get3DmodelsListAsync();
        Task<T> Get3DmodelByIdAsync(int id);
        Task Delete3DmodelByIdAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task SaveAsync();
    }
}
