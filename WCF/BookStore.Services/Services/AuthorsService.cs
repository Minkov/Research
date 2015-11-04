using BookStore.Services.Models;
using BookStore.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Services
{
    public class AuthorsService : IAuthorsService
    {
        private IRepository<Author> data;

        public AuthorsService()
            : this(new InMemoryRepository<Author>())
        {
        }

        public AuthorsService(IRepository<Author> data)
        {
            this.data = data;
        }

        public Author Add(Author author)
        {
            this.data.Add(author);
            return author;
        }

        public IQueryable<Author> GetAll()
        {
            return this.data.All();
        }

        public Author GetById(string id)
        {
            return this.data.Find(int.Parse(id));
        }
    }
}
