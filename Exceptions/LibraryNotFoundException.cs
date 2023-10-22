using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Exceptions
{
    internal class LibraryNotFoundException:Exception
    {
        public LibraryNotFoundException(string message = "Library not found") : base(message)
        {

        }
    }
}
