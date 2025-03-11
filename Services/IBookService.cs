using W8BookTest.Models;

namespace W8BookTest.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task DeleteBookAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
    }
}
