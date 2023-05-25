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
            Console.Clear();
            InfoBook info = new InfoBook();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       ADD NEW BOOK");
            Console.WriteLine("--------------------------");
            Console.ResetColor();
            try
            {
                Console.Write("Book name: ");
                info.Name = Console.ReadLine().ToLower();
                Console.Write("Author: ");
                info.Author = Console.ReadLine().ToLower();
                Console.Write("Release date: ");
                info.Year = int.Parse(Console.ReadLine().ToLower());
                bookshelf.Add(info);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }           
        }
        public void ShowEveryBook()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("               BOOKSHELF");
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();
            if (bookshelf.Count > 0)
            {
                foreach (InfoBook i in bookshelf)
                {
                    Console.WriteLine($"Book's name: {i.Name}   ,   Author's name: {i.Author}   ,   Year of release: {i.Year}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         **Bookshelf is empty**");
                Console.ResetColor ();
            }          
        }
        public void AuthorBook()
        {
            InfoBook info = new InfoBook();
            Console.Clear();
            if(bookshelf.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("         Search for a book by Author's name");
                Console.WriteLine("----------------------------------------------------");
                Console.ResetColor();
                try
                {
                    Console.Write("Enter author's name: ");
                    string AuthorsName = Console.ReadLine().ToLower();
                    InfoBook Authors = bookshelf.Find(info => info.Author.Contains(AuthorsName));
                    if (Authors != null)
                    {
                        Console.WriteLine($"Book's name: {Authors.Name}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Year of release: {Authors.Year}");
                        Console.WriteLine($"Name of author: {Authors.Author}");
                    }
                    else
                    {
                        Console.WriteLine("**Author wasn't found**");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("  **Enter book first**");
                Console.ResetColor();
            }       
        }
        public void YearBook()
        {
            InfoBook info = new InfoBook();
            Console.Clear();
            if (bookshelf.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("            Search for a book by year");
                Console.WriteLine("----------------------------------------------------");
                Console.ResetColor();
                try
                {
                    Console.Write("Enter year of release: ");
                    int year = int.Parse(Console.ReadLine());
                    InfoBook foundYear = bookshelf.Find(info => info.Year == year);
                    if (foundYear != null)
                    {
                        Console.WriteLine($"Book's name: {foundYear.Name}");
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Year of release: {foundYear.Year}");
                        Console.WriteLine($"Name of author: {foundYear.Author}");
                    }
                    else
                    {
                        Console.WriteLine("**Book wasn't found**");
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  **Enter book first**");
                Console.ResetColor();
            }           
        }
    }
}
