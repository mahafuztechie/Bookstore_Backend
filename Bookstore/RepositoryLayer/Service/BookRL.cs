using CommonLayer;
using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class BookRL : IBookRL
    {
        private SqlConnection sqlConnection;
        private IConfiguration Configuration { get; }
        public BookRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        //Adding Book APi Method Calling Store Procedure
        public AddBookModel AddBook(AddBookModel add_Book)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookName", add_Book.bookName);
                    cmd.Parameters.AddWithValue("@AuthorName", add_Book.authorName);
                    cmd.Parameters.AddWithValue("@Rating", add_Book.rating);
                    cmd.Parameters.AddWithValue("@RatingCount", add_Book.ratingCount);
                    cmd.Parameters.AddWithValue("@DiscountPrice", add_Book.discountPrice);
                    cmd.Parameters.AddWithValue("@ActualPrice", add_Book.actualPrice);
                    cmd.Parameters.AddWithValue("@Description", add_Book.description);
                    cmd.Parameters.AddWithValue("@BookImage", add_Book.bookImage);
                    cmd.Parameters.AddWithValue("@BookQuantity", add_Book.bookQuantity);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return add_Book;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public UpdateBookModel UpdateBook(int book_id, UpdateBookModel book)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", book_id);
                    cmd.Parameters.AddWithValue("@BookName", book.bookName);
                    cmd.Parameters.AddWithValue("@AuthorName", book.authorName);
                    cmd.Parameters.AddWithValue("@Rating", book.rating);
                    cmd.Parameters.AddWithValue("@RatingCount", book.ratingCount);
                    cmd.Parameters.AddWithValue("@DiscountPrice", book.discountPrice);
                    cmd.Parameters.AddWithValue("@ActualPrice", book.actualPrice);
                    cmd.Parameters.AddWithValue("@Description", book.description);
                    cmd.Parameters.AddWithValue("@BookImage", book.bookImage);
                    cmd.Parameters.AddWithValue("@BookQuantity", book.bookQuantity);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool DeleteBook(int book_Id)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteBook", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", book_Id);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public BookModel GetBookByBookId(int book_Id)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("GetBookById", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", book_Id);
                    sqlConnection.Open();
                    BookModel book = new BookModel();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            book.bookId = Convert.ToInt32(reader["BookId"]);
                            book.bookName = reader["BookName"].ToString();
                            book.authorName = reader["AuthorName"].ToString();
                            book.rating = Convert.ToInt32(reader["Rating"]);
                            book.ratingCount = Convert.ToInt32(reader["RatingCount"]);
                            book.discountPrice = Convert.ToInt32(reader["DiscountPrice"]);
                            book.actualPrice = Convert.ToInt32(reader["ActualPrice"]);
                            book.description = reader["Description"].ToString();
                            book.bookImage = reader["BookImage"].ToString();
                            book.bookQuantity = Convert.ToInt32(reader["BookQuantity"]);
                        }
                        sqlConnection.Close();
                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<BookModel> GetAllBooks()
        {
            List<BookModel> book = new List<BookModel>();
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);

            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("GetAllBooks", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            book.Add(new BookModel
                            {
                                bookId = Convert.ToInt32(reader["BookId"]),
                                bookName = reader["BookName"].ToString(),
                                authorName = reader["AuthorName"].ToString(),
                                rating = Convert.ToInt32(reader["Rating"]),
                                ratingCount = Convert.ToInt32(reader["RatingCount"]),
                                discountPrice = Convert.ToInt32(reader["DiscountPrice"]),
                                actualPrice = Convert.ToInt32(reader["ActualPrice"]),
                                description = reader["Description"].ToString(),
                                bookImage = reader["BookImage"].ToString(),
                                bookQuantity = Convert.ToInt32(reader["BookQuantity"])
                            });
                        }
                        sqlConnection.Close();
                        return book;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
