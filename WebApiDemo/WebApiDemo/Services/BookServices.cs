using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Modals;
using System.Text.RegularExpressions;

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
         using (StreamReader r = new StreamReader("C:/Users/vitripathi/Desktop/API/WebApiDemo/WebApiDemo/Repository/BookData.json"))
          { string json = r.ReadToEnd();
           _bookList = JsonConvert.DeserializeObject<List<Book>>(json);
           }
        }

        public void SaveJson()
        {
            string json = JsonConvert.SerializeObject(_bookList.ToArray());
            System.IO.File.WriteAllText("C:/Users/vitripathi/Desktop/API/WebApiDemo/WebApiDemo/Repository/BookData.json", json);
        }


        public bool AddBook(Book book)
        {
           if(Regex.IsMatch(book.Title,"^[a-zA-Z0-9!@#$&()-`.+,/\" ]+$") && Regex.IsMatch(book.Author, "^[a-zA-Z ]+$")&& book.Price>0)
            {
                _bookList.Add(book);
                SaveJson();
                return true;
            }
            return false;
        }

        public List<Book> GetAllBook()
        {
            if (_bookList.Count == 0)
            {
                return null;
            }
            else
            {
                return _bookList;
            }
        }


        public Book GetBookByName(string name)
        { if (Regex.IsMatch(name, "^[a-zA-Z0-9!@#$&()-`.+,/\" ]+$"))
            {
                var book= _bookList.Where(b => b.Title == name).FirstOrDefault();
                if (book == null)
                {
                    return null;
                }
                else
                {
                    return book;
                }
            }
            else
            {
                return null;
            }
        
        }

        public bool UpdateBook(string name, Book book)
        {
            bool status = false;
            if (Regex.IsMatch(name, "^[a-zA-Z0-9!@#$&()-`.+,/\" ]+$") && Regex.IsMatch(book.Title, "^[a-zA-Z 0-9]+$") && Regex.IsMatch(book.Author, "^[a-zA-Z ]+$") && book.Price > 0)
            {
                foreach (var item in _bookList.Where(w => w.Title == name))
                {
                    item.Price = book.Price;
                    item.Author = book.Author;
                    status = true;
                    SaveJson();
                }
            }
            else{
                status = false ;
            }
            return status;
        }
    }

       
 }

