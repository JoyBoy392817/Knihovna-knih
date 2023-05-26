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
        public void CreateNewBook()//creating new book
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
        public void ShowEveryBook()//shows every book
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
                    int index = bookshelf.IndexOf(i) + 1;
                    Console.WriteLine($"{index}) Book's name: {i.Name}  |    Author's name: {i.Author}   |   Year of release: {i.Year}");//how it will show every book
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("         **Bookshelf is empty**");
                Console.ResetColor();
            }
        }
        public void AuthorBook()
        {
            InfoBook info = new InfoBook();
            Console.Clear();
            if (bookshelf.Count > 0)
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
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Book's name: {Authors.Name}");
                        Console.WriteLine($"Name of author: {Authors.Author}");
                        Console.WriteLine($"Year of release: {Authors.Year}");
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
                Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.WriteLine("--------------------------");
                        Console.WriteLine($"Book's name: {foundYear.Name}");
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
        public void Save(string bookMark)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(bookMark))
                {
                    foreach (InfoBook i in bookshelf)
                    {
                        string line = $"{i.Name}, {i.Author}, {i.Year}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
        public void Load(string bookMark)
        {
            try
            {
                if (File.Exists(bookMark))//load test
                {
                    Console.WriteLine(" File was succefuly loaded/saved");
                    using (StreamReader sr = new StreamReader(bookMark))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 3)
                            {
                                string name = parts[0];
                                string author = parts[1];
                                int year = int.Parse(parts[2]);
                                InfoBook book = new InfoBook()
                                {
                                    Name = name,
                                    Author = author,
                                    Year = year
                                };
                                bookshelf.Add(book);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"****FATAL ERROR****");
                                Console.ResetColor();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  File does not exist");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
        public void Remove()
        {
            Console.Clear();
            InfoBook info = new InfoBook();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                   Remove book");
            Console.WriteLine("----------------------------------------------------");
            Console.ResetColor();
            try
            {
                Console.WriteLine("Write book's name: ");
                string removedBookName = Console.ReadLine();
                InfoBook removedBook = bookshelf.Find(info => info.Name.Contains(removedBookName));// nefunguje maže když je to prázdný
                if (removedBook != null)
                {
                    bookshelf.Remove(removedBook);
                    Console.WriteLine("Book was removed");
                }
                else
                {
                    Console.WriteLine("Book's name does not exist");
                }
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
