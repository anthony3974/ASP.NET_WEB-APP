using W8BookTest.Models;

namespace W8BookTest.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
    }
}
