using BusinessLayer.Interface;
using CommonLayer;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        //private readonly IDistributedCache distributedCache;

        private readonly IBookBL bookBL;

        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        //Api Adding Book
        [HttpPost("Add")]
        public IActionResult AddBook(AddBookModel addbook)
        {
            try
            {
                var book = this.bookBL.AddBook(addbook);
                if (book != null)
                {
                    return this.Ok(new { Success = true, message = "Book Added Sucessfully", Response = book });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to add Book" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpPut("update/{book_Id}")]
        public IActionResult UpdateBook(int book_Id, UpdateBookModel UpdateBookModel)
        {
            try
            {
                var Book = this.bookBL.UpdateBook(book_Id,UpdateBookModel);
                if (Book != null)
                {
                    return this.Ok(new { Success = true, message = "Book Updated successfully", Response = Book });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to update Book" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpDelete("delete/{book_Id}")]
        public IActionResult DeleteBook(int book_Id)
        {
            try
            {
                if (this.bookBL.DeleteBook(book_Id))
                {
                    return this.Ok(new { Success = true, message = "Book Deleted Sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to Delete Book" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpGet("Get/{book_Id}")]
        public IActionResult GetBookByBookId(int book_Id)
        {
            try
            {
                var book = this.bookBL.GetBookByBookId(book_Id);
                if (book != null)
                {
                    return this.Ok(new { Success = true, message = "Books are displayed", Response = book });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to display books" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }

        [HttpGet("GetBooks")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var allbooks = this.bookBL.GetAllBooks();
                if (allbooks != null)
                {
                    return this.Ok(new { Success = true, message = "All Book are fetched successfully", Response = allbooks });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "failed to fetch books" });
                }
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, message = ex.Message });
            }
        }
      
    }
}
