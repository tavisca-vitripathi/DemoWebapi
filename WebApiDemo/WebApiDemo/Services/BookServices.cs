using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Modals;

namespace WebApiDemo.Services
{
    public class BookServices : IBook
    {

         private  List<Book> _bookList= new List<Book>();
        public BookServices()
        {
            LoadJson();
        }
        
       public void LoadJson()
        {
         using (StreamReader r = new StreamReader("C:/Users/vitripathi/source/repos/WebApiDemo/WebApiDemo/Repository/BookData.json"))
          { string json = r.ReadToEnd();
           _bookList = JsonConvert.DeserializeObject<List<Book>>(json);
           }
        }
        public void SaveJson()
        {
            string json = JsonConvert.SerializeObject(_bookList.ToArray());
            System.IO.File.WriteAllText("C:/Users/vitripathi/source/repos/WebApiDemo/WebApiDemo/Repository/BookData.json", json);
        }

        public void AddBook(Book book)
        {
            _bookList.Add(book);
            SaveJson();
          //  return "Adddition Done!";
        }

        public List<Book> GetAllBook()
        {
            return _bookList;
        }


        public Book GetBookByName(string name)
        {
           return _bookList.Where(b => b.Title == name).FirstOrDefault();
            
        }

        public void UpdateBook(string name, Book book)
        {
            //foreach(var item in _bookList)
            //{
            //    if(item.Title == name)
            //    {
            //        item.Price = book.Price;
            //        item.Author = book.Author;
            //    }
            //}
            foreach (var item in _bookList.Where(w => w.Title==name))
            {
                item.Price = book.Price;
                item.Author = book.Author;
            }
            SaveJson();
        }
    }

       
 }

