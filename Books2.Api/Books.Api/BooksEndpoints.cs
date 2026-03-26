using BooksApi.Models;

public static class BooksEndpoints
{
    public static void MapBooksEndpoints(this WebApplication app)
    {
        // получить все книги
        app.MapGet("/api/books", () =>
        {
            return Results.Ok(BookStore.books);
        });

        // получить книгу по id
        app.MapGet("/api/books/{id:int}", (int id) =>
        {
            var book = BookStore.books.FirstOrDefault(x => x.Id == id);

            if (book == null)
                return Results.NotFound("Book not found");

            return Results.Ok(book);
        });

        // поиск
        app.MapGet("/api/books/search", (string title, string? author) =>
        {
            if (string.IsNullOrWhiteSpace(title))
                return Results.BadRequest("title is required");

            var result = BookStore.books
                .Where(x => x.Title.ToLower().Contains(title.ToLower()));

            if (!string.IsNullOrWhiteSpace(author))
            {
                result = result.Where(x => x.Author.ToLower().Contains(author.ToLower()));
            }

            return Results.Ok(result.ToList());
        });
    }
}