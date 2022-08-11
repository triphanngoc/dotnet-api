using BooksApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApi.Core.Services
{
    public interface IBookService
    {
        List<Book> Get();
        Book Get(string id);
        Book Create(Book book);        
        void Update(string id, Book bookIn);
        void Remove(string id);
        void Remove(Book bookIn);
    }
}
