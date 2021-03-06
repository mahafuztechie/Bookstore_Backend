using CommonLayer;
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IBookRL
    {
        public AddBookModel AddBook(AddBookModel add_Book);
        public UpdateBookModel UpdateBook(int book_Id, UpdateBookModel book);
        public bool DeleteBook(int book_Id);
        public BookModel GetBookByBookId(int book_Id);
        public List<BookModel> GetAllBooks();
    }
}
