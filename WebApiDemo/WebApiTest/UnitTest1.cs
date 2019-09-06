using System;
using Xunit;
using System.Collections.Generic;
using WebApiDemo.Services;
using WebApiDemo.Modals;
using FluentAssertions;

namespace XUnitTest
{
    public class TestBookServices
    {
        BookServices bookServices = new BookServices();
        [Fact]
        public  void Test()
        {
            List<Book> list = new List<Book>();
            list = bookServices.GetAllBook();
            var expectedlist = new List<Book>();
            expectedlist.Add(new Book { Title = "India@3998", Author = "chinmay", Price =1000});
            expectedlist.Add(new Book { Title = "India", Author = "chinmayBhatt", Price = 10000});
            expectedlist.Add(new Book { Title = "India@2020", Author = "A P J Kalam", Price = 100});
            expectedlist.Should().BeEquivalentTo(list);
          
        }
        [Fact]
        public void Test2()
        {
            Book list = new Book();
            list = bookServices.GetBookByName("India@3998");
          //  var expectedlist = new List<Book>();
           Book book =new Book{ Title = "India@3998", Author = "chinmay", Price = 1000};
            book.Should().BeEquivalentTo(list);

        }

        [Fact]
        public void test3()
        {
            bool status = true;
            bool expected = bookServices.UpdateBook("India@3998", new Book { Title = "India@3998", Author = "chinmay", Price = 1000 });
            Assert.Equal(status, expected);
        }


        [Theory]
        [InlineData("India","hururu",-90,false)]
        [InlineData("India","hururu",0,false)]
        [InlineData("India","hururu90",100,false)]
        [InlineData("India","",100,false)]
        [InlineData("India","90",100,false)]
        [InlineData("India@myage","Vikas Tripathi",100,true)]
        [InlineData("India from my View$","Vikas Tripathi",100,true)]
        [InlineData("India from my View","Vikas Tripathi$",100,false)]
        public void Test_Add_Method(string title,string author,int price,bool expected)
        {
            bool actual;
            Book book = new Book { Title=title,Price=price,Author=author };
            actual=bookServices.AddBook(book);
            Assert.Equal(actual, expected);
        }
    }
}


