namespace _3DModelMax.Persistence.Services
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> Get3DModelsListAsync();
        Task<T> Get3DModelByIdAsync(int id);
        Task Delete3DModelByIdAsync(int id);
        Task CreateAsync(T item);
        void Update(T item);
        Task SaveAsync();
    }
}
