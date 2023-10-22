using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Exceptions
{
    internal class WrongInputException:Exception
    {
        public WrongInputException(string message="Input is wrong"):base(message)
        {

        }
    }
}
