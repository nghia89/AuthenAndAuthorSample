using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Data.Entity
{
    public class Books
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
    }
}
