using W8BookTest.Models;
using W8BookTest.Repositories;

namespace W8BookTest.Services
{
    public class BookService : IBookService
    {
        readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateBookAsync(Book book)
        {
            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentException("Title cannot be empty", nameof(book.Title));
            }   
            await _repository.CreateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _repository.GetAllAsync();
            return books.OrderBy(Book => Book.Title);
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            if (string.IsNullOrEmpty(book.Title))
            {
                throw new ArgumentException("Title cannot be empty", nameof(book.Title));
            }
            await _repository.UpdateAsync(book);
        }
    }
}
