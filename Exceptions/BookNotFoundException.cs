using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Exceptions
{
    internal class BookNotFoundException:Exception
    {
        public BookNotFoundException(string message="Book not found"):base(message)
        {

        }
    }
}
