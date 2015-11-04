using BookStore.Services.Models;
using BookStore.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class BooksService : IBooksService
    {
        private IRepository<Author> authorsData;
        private IRepository<Book> booksData;

        public BooksService()
            : this(new InMemoryRepository<Book>(), new InMemoryRepository<Author>())
        {
        }

        public BooksService(IRepository<Book> booksData, IRepository<Author> authorsData)
        {
            this.booksData = booksData;
            this.authorsData = authorsData;
        }

        public Book Add(Book book)
        {
            Author author = this.authorsData.Search(a => a.Name.ToLower() == book.Author.Name.ToLower())
                                            .FirstOrDefault();
            if (author == null)
            {
                author = book.Author;
                this.authorsData.Add(author);
            }
            book.Author = author;

            this.booksData.Add(book);
            return book;
        }

        public IQueryable<Book> GetAll()
        {
            return this.booksData.All();
        }

        public Book GetById(string id)
        {
            return this.booksData.Find(int.Parse(id));
        }
    }
}
