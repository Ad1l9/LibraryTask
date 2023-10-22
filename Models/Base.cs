using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18.Models
{
    internal abstract class Base
    {
        private static int _id=0;
        public int Id { get; protected set; }
        public string Name { get; protected set; }

        public Base(string name)
        {
            Id = ++_id;
            Name = name;
        }
    }
}
