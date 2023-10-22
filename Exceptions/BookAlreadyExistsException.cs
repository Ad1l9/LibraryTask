using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Exceptions
{
    internal class BookAlreadyExistsException:Exception
    {
        public BookAlreadyExistsException(string message="book already exists"):base(message) { }
    }
}
