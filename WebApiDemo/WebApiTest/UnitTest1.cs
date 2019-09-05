

using System;
using Xunit;
using System.Collections.Generic;
using WebApiDemo.Services;
using WebApiDemo.Modals;

namespace XUnitTest
{
    public class TestBookServices
    {
        BookServices bookServices = new BookServices();
        [Fact]
        public  void Test_of_search()
        {
            List<Book> list = new List<Book>();
            list.Add(new Book { Title = "A God thought", Author = "Vikas tripathi", Price = 100 });
            bookServices.AddBook(new Book { Title = "A God thought", Author = "Vikas tripathi", Price = 100 });
            var x = bookServices.GetBookByName("A God thought");
            Assert.True(list.Contains(x));
        }
    }
}


