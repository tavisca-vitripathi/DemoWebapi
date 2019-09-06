using System.Collections.Generic;
using WebApiDemo.Modals;

namespace WebApiDemo.Services
{
    public interface IBook
    {
       List<Book> GetAllBook();
        Book GetBookByName( string name);
        bool AddBook(Book book);
       bool UpdateBook(string name,Book book);

    }
}