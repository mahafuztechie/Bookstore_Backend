using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
   public class AddBookModel
    {
        public string bookName { get; set; }
        public string authorName { get; set; }
        public int rating { get; set; }
        public int ratingCount { get; set; }
        public int discountPrice { get; set; }
        public int actualPrice { get; set; }
        public string description { get; set; }
        public string bookImage { get; set; }
        public int bookQuantity { get; set; }
    }
}
