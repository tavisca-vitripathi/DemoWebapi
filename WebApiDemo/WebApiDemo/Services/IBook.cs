using System.Collections.Generic;
using WebApiDemo.Modals;

namespace WebApiDemo.Services
{
    public interface IBook
    {
       List<Book> GetAllBook();
        Book GetBookByName( string name);
        void AddBook(Book book);
       void UpdateBook(string name,Book book);

    }
}