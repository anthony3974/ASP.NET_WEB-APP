using Microsoft.EntityFrameworkCore;
using W8BookTest.Data;
using W8BookTest.Models;

namespace W8BookTest.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly W8BookTestContext _context;

        public BookRepository(W8BookTestContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var toDelete = await _context.Book.FindAsync(id);
            if (toDelete != null)
            {
                _context.Book.Remove(toDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Book.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Book.FindAsync(id);
        }

        public async Task UpdateAsync(Book book)
        {
            var toUpdate = await _context.Book.FindAsync(book.Id);
            
            if (toUpdate != null)
            {
                toUpdate.Title = book.Title;
                toUpdate.Author = book.Author;
                //_context.Book.Update(toUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}
