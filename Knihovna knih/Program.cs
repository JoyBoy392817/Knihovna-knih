using Knihovna_knih;
BookBookshelf bookBookshelf = new BookBookshelf();
bool loop = true;
string bookMark = "SavedBooks.txt";
bookBookshelf.Load(bookMark);
while (loop)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("------------------------");
    Console.WriteLine("          MENU");
    Console.WriteLine("------------------------");
    Console.ResetColor();
    Console.WriteLine("1) Add book");
    Console.WriteLine("2) Show every saved book");
    Console.WriteLine("3) Search for a book (by Author)");
    Console.WriteLine("4) Search for a book (by Year)");
    Console.WriteLine("5) Close program");
    ConsoleKeyInfo key = Console.ReadKey(true);
    switch (key.Key)
    {
        case ConsoleKey.D1:
            bookBookshelf.CreateNewBook();
            break;
        case ConsoleKey.D2:
            bookBookshelf.ShowEveryBook();
            break;
        case ConsoleKey.D3:
            bookBookshelf.AuthorBook();
            break;
        case ConsoleKey.D4:
            bookBookshelf.YearBook();
            break;
        case ConsoleKey.D5:
            bookBookshelf.Save(bookMark);
            loop = false;
            break;
        default:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**Error with selection**");
            Console.ResetColor();
            break;
    }
}

