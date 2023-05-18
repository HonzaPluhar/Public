
public class Program
{
    public static void Main(string[] args)
    {
        //vytvoření nové knihovny
        Library library = new Library();

        //vytvoření několika knih
        Book book1 = new Book("Honza ze světa bramborových lidí", "Jan Pluhař", 1994);
        Book book2 = new Book("Anity sekvence", "Anita Prošková", 1993);
        Book book3 = new Book("Život pod hladinou", "Natálie Pluhařová", 2014);

        //přidání knih do knihovny
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);


        //vypsání všech knih v knihovně 
        library.ListAvailableBooks();


        //Vypůjčení knihy 
        library.BorrowBook("Honza ze světa bramborových lidí");


        //zkouška vypůjčit ji znovu
        library.BorrowBook("Honza ze světa bramborových lidí");

        //vypsání všech knih v knihovně
        library.ListAvailableBooks();

        //vrácení knihy do knihovny
        library.ReturnBook("Honza ze světa bramborových lidí");

        //vypsání všech knih v knihovně
        library.ListAvailableBooks();




        Console.ReadKey();
    }
}




public class Book
{
    public string Title;
    public string Author;
    public int PublicationYear;
    public bool IsAvailable;

    public Book(string title, string author, int publicationyear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationyear;
        IsAvailable = true;
    }

    //BorrowBook
    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
        }
        else
        {
            Console.WriteLine("Kniha je momentálně vypůjčená.");
        }
    }
    //Return book
    public void ReturnBook()
    {
        IsAvailable = true;
    }
}

public class Library
{
    //vlastnost
    List<Book> books = new List<Book>();



    //add book
    public void AddBook(Book book)
    {

        books.Add(book);

    }

    //remove book by title
    public void RemoveBook(string title)
    {
        Book bookToRemove = books.Find(book => book.Title == title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
        }
    }

    //borrowbook by title
    public void BorrowBook(string title)
    {
        Book bookToBorrow = books.Find(book => book.Title == title);
        if (bookToBorrow != null)
        {
            if (bookToBorrow.IsAvailable)
            {
                bookToBorrow.BorrowBook();
                Console.WriteLine($"Kniha {title} byla úspěšně vypůjčena.");
            }
            else
            {
                Console.WriteLine($"Kniha {title} je momentálně vypůjčená.");
            }

        }
        else
        {
            Console.WriteLine($"Kniha {title} není v knihovně.");
        }
    }

    //return book
    public void ReturnBook(string title)
    {
        Book bookToReturn = books.Find(book => book.Title == title);
        if (bookToReturn != null)
        {
            if (!bookToReturn.IsAvailable)
            {
                bookToReturn.ReturnBook();
                Console.WriteLine($"Kniha {title} byla vrácena.");
            }
            else
            {
                Console.WriteLine($"Kniha {title} nebyla vypůjčena.");
            }
        }
        else
        {
            Console.WriteLine($"Kniha {title} není v knihovně.");
        }
    }

    //list of books
    public void ListAvailableBooks()
    {
        Console.WriteLine("List:");
        foreach (Book book in books)
        {

            Console.WriteLine($"Název: {book.Title}, Autor: {book.Author}, Rok vydání: {book.PublicationYear}");
        }
        Console.WriteLine("");
    }
}