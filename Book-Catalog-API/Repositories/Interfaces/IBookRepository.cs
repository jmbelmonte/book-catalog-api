using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Book_Catalog_API.Helpers;
using Book_Catalog_API.Models;

namespace Book_Catalog_API.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(BookParameters bookParameters);
        Task<Book> GetBookByIdAsync(int id);
        Task CreateBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Book book);
    }
}
