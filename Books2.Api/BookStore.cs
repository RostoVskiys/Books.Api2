using Books.Api.Models;

namespace Books.Api
{
    public static class BookStore
    {
        public static List<Book> knigi = new List<Book>
        {
            new Book { Id = 1, Title = "Война и мир", Author = "Толстой", Year = 1869 },
            new Book { Id = 2, Title = "1984", Author = "Оруэлл", Year = 1949 },
            new Book { Id = 3, Title = "Мастер и Маргарита", Author = "Булгаков", Year = 1967 }
        };
    }
}