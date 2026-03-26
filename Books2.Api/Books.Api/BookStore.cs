using BooksApi.Models;

public static class BookStore
{
    public static List<Book> books = new List<Book>
    {
        new Book { Id = 1, Title = "война и мир", Author = "толстой", Year = 1869 },
        new Book { Id = 2, Title = "преступление и наказание", Author = "достоевский", Year = 1866 },
        new Book { Id = 3, Title = "мастер и маргарита", Author = "булгаков", Year = 1967 }
    };
}