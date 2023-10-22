using ConsoleApp18.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Exception;

namespace ConsoleApp18.Models
{
    internal class Library:Base
    {
        private static int _libraryId = 0;
        List<Book> _books;
        public Library(string name):base(name)
        {
            Id=++_libraryId;
            _books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public bool Contains(Book book)
        {
            if (_books.Contains(book)) return true;
            else return false;
        }


        public void ListAllBooks()
        {
            try
            {
                if (_books.Count > 0)
                {
                    Console.WriteLine($"'{Name}'kitabxanasindaki kitablar");
                    foreach (Book book in _books)
                    {
                        Console.WriteLine(book);
                    }
                }
                else throw new BookNotFoundException("Kitab yoxdur");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return $"Id:{Id} | Name:{Name}";
        }
    }
}
