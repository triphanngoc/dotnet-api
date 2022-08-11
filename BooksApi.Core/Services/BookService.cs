using System.Collections.Generic;
using global::BooksApi.Core.Models;
using global::BooksApi.Models;
using MongoDB.Driver;
using System.Linq;

namespace BooksApi.Core.Services
{

    /*namespace BooksApi.Services
    {*/
    public class BookService : IBookService
        {
            private readonly IMongoCollection<Book> _books;

            public BookService(IDatabaseSettings settings)
            {
                var client = new MongoClient(settings.ConnectionString);
                var database = client.GetDatabase(settings.DatabaseName);

                _books = database.GetCollection<Book>(settings.BooksCollectionName);
            }

            public List<Book> Get() =>
                _books.Find(book => true).ToList();

            public Book Get(string id) =>
                _books.Find<Book>(book => book.Id.ToString() == id).FirstOrDefault();

            public Book Create(Book book)
            {
                _books.InsertOne(book);
                return book;
            }

            public void Update(string id, Book bookIn) =>
                _books.ReplaceOne(book => book.Id.ToString() == id, bookIn);

            public void Remove(Book bookIn) =>
                _books.DeleteOne(book => book.Id.ToString() == bookIn.Id.ToString());

            public void Remove(string id) =>
                _books.DeleteOne(book => book.Id.ToString() == id);
        }
   }
