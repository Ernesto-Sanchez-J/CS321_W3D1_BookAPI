using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CS321_W3D1_BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        private int _nextId;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public void Delete(Book deletedBook)
        {
            _bookContext.Remove(deletedBook);

            _bookContext.SaveChanges();
        }

        public Book Get(int bookId)
        {
            return _bookContext.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books.ToList();
        }

        public Book Post(Book newBook)
        {
            newBook.Id = _nextId++;

            _bookContext.Add(newBook);

            _bookContext.SaveChanges();

            return newBook;
        }

        public Book Update(Book updatedBook)
        {
            //hold book that is needing to be updated by the Id
            var currentBook = this.Get(updatedBook.Id);

            if (updatedBook.Id == null) return null;
            
               
            

            //assign all new properties to the selected book
            currentBook.Title = updatedBook.Title;
            currentBook.Author = updatedBook.Author;
            currentBook.Category = updatedBook.Category;

            _bookContext.SaveChanges();

            //return the book
            return currentBook;
        }
    }
}