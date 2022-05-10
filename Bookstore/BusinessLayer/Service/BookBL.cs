using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        private readonly IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        //Adding Book MEthod Calling
        public AddBookModel AddBook(AddBookModel addBook)
        {
            try
            {
                return this.bookRL.AddBook(addBook);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public UpdateBookModel UpdateBook(int book_Id, UpdateBookModel bookModel)
        {
            try
            {
                return this.bookRL.UpdateBook(book_Id, bookModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteBook(int book_Id)
        {
            try
            {
                return this.bookRL.DeleteBook(book_Id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BookModel GetBookByBookId(int bookId)
        {
            try
            {
                return this.bookRL.GetBookByBookId(bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<BookModel> GetAllBooks()
        {
            try
            {
                return this.bookRL.GetAllBooks();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
