using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Models
{
    internal class Book:Base
    {
        private static int _bookId = 0;
        public string Author { get; set; }
        Category category { get; set; }

        public Book(string name,string author, Category category):base(name)
        {
            Id = ++_bookId;
            Author = author;
            this.category = category;
        }

        public override string ToString()
        {
            return $"Id:{Id}  |  Name:{Name}  |  Author:{Author}";
        }
    }
}
