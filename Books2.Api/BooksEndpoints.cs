using Books.Api.Models;

namespace Books.Api
{
    public static class BooksEndpoints
    {
        public static void MapBooksEndpoints(this WebApplication app)
        {
            // GET /api/books
            app.MapGet("/api/books", () =>
            {
                return Results.Ok(BookStore.knigi);
            });

            // GET /api/books/{id}
            app.MapGet("/api/books/{id:int}", (int id) =>
            {
                var kniga = BookStore.knigi.FirstOrDefault(x => x.Id == id);

                if (kniga == null)
                    return Results.NotFound("Book not found");

                return Results.Ok(kniga);
            });

            // GET /api/books/search
            app.MapGet("/api/books/search", (string title, string? author) =>
            {
                if (string.IsNullOrWhiteSpace(title))
                    return Results.BadRequest("title is required");

                var result = BookStore.knigi
                    .Where(x => x.Title.ToLower().Contains(title.ToLower()));

                if (!string.IsNullOrWhiteSpace(author))
                {
                    result = result.Where(x =>
                        x.Author.ToLower().Contains(author.ToLower()));
                }

                return Results.Ok(result.ToList());
            });
        }
    }
}