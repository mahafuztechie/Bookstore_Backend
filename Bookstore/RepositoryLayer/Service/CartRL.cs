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
   public class CartRL : ICartRL
    {
        private SqlConnection sqlConnection;

        private IConfiguration Configuration { get; }
        public CartRL(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        //Adding Cart Api
        public CartModel AddCart(CartModel cartModel, int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("AddCart", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.orderQuantity);
                    cmd.Parameters.AddWithValue("@BookId", cartModel.bookId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    sqlConnection.Open();
                    int i = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {
                        return cartModel;
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
        //get cart by userid and cartid 
        public List<ViewCartModel> GetCartDetailsByUserid(int userId)
        {
            sqlConnection = new SqlConnection(this.Configuration["ConnectionString:BookStore"]);
            try
            {
                using (sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("GetCartByUserId", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        List<ViewCartModel> cartmodels = new List<ViewCartModel>();
                        while (reader.Read())
                        {
                            BookModel bookModel = new BookModel();
                            ViewCartModel cartModel = new ViewCartModel();
                            bookModel.bookId = Convert.ToInt32(reader["BookId"]);
                            bookModel.bookName = reader["BookName"].ToString();
                            bookModel.authorName = reader["AuthorName"].ToString();
                            bookModel.actualPrice = Convert.ToInt32(reader["ActualPrice"]);
                            bookModel.discountPrice = Convert.ToInt32(reader["DiscountPrice"]);
                            bookModel.bookImage = reader["BookImage"].ToString();
                            cartModel.userId = Convert.ToInt32(reader["UserId"]);
                            cartModel.bookId = Convert.ToInt32(reader["BookId"]);
                            cartModel.cartId = Convert.ToInt32(reader["CartId"]);
                            cartModel.orderQuantity = Convert.ToInt32(reader["OrderQuantity"]);
                            cartModel.Bookmodel = bookModel;
                            cartmodels.Add(cartModel);
                        }

                        sqlConnection.Close();
                        return cartmodels;
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
