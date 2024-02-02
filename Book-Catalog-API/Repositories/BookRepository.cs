using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book_Catalog_API.Models;
using Book_Catalog_API.Repositories.Interfaces;
using Book_Catalog_API.Data;
using Book_Catalog_API.Helpers;

namespace Book_Catalog_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(BookParameters bookParameters)
        {
            IQueryable<Book> booksQuery = _context.Books.AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(bookParameters.Title))
            {
                booksQuery = booksQuery.Where(b => b.Title.Contains(bookParameters.Title));
            }

            if (bookParameters.CategoryId.HasValue)
            {
                booksQuery = booksQuery.Where(b => b.CategoryId == bookParameters.CategoryId.Value);
            }

            // Paging
            return await booksQuery
                .Skip((bookParameters.PageNumber - 1) * bookParameters.PageSize)
                .Take(bookParameters.PageSize)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task CreateBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

}
