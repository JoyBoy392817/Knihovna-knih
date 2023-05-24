using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knihovna_knih
{
    class BookBookshelf
    {
        List<InfoBook> bookshelf = new List<InfoBook>();
        public void CreateNewBook()
        {
            InfoBook info = new InfoBook();
            Console.WriteLine("       ADD NEW BOOK");
            Console.WriteLine("--------------------------");
            try
            {
                Console.Write("Book name: ");
                info.Name = Console.ReadLine();
                Console.WriteLine("Author: ");
                info.Author = Console.ReadLine();
                Console.Write("Release date: ");
                info.Year = int.Parse(Console.ReadLine());
                bookshelf.Add(info);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ShowEveryBook()
        {
            foreach(InfoBook i in bookshelf)
            {
                Console.WriteLine($"{i.Name} - {i.Author} - {i.Year}");
            }
        }
    }
}
