using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary
{
    internal class BookInfo
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
