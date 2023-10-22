using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Models
{
    internal class Category:Base
    {
        private static int _categoryId = 0;
        public Category(string name):base(name)
        {
            Id = ++_categoryId;
        }

        public override string ToString()
        {
            return $"Id:{Id} | Name:{Name}";
        }
    }
}
