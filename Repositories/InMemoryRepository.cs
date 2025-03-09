using W8BookTest.Models;

namespace W8BookTest.Repositories
{
    public class InMemoryRepository : IBookRepository
    {
        List<Book> books;

        public InMemoryRepository()
        {
            books = new List<Book>
            {
                new(1, "James", "Never"),
                new(2, "Charles", "Anyway"),
                new(3, "The Third", "Not Yet"),
            };
        }

        public Task CreateAsync(Book book)
        {
            books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            books.RemoveAll(b => b.Id == id);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(books);
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            Book? book = books.Find(b => b.Id == id);
            return Task.FromResult(book);
        }

        public Task UpdateAsync(Book book)
        {
            var existingBook = books.Find(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
            }
            return Task.CompletedTask;
        }
    }
}
