namespace Linq_C_;

public class LinqQueries
{
    private List<Book> librosCollections = new List<Book>();
   public LinqQueries()
   {
        using StreamReader reader = new StreamReader("books.json");
        string json = reader.ReadToEnd();
        this.librosCollections = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
    }
   public IEnumerable<Book> TodaLaColeccion()
   {
    return librosCollections;
   }

   public IEnumerable<Book> LibrosDespuesdel2000()
   {
    //extension method
    // return librosCollections.Where(p => p.PublishedDate.Year > 2000);

    //query expresion
    return from l in librosCollections where l.PublishedDate.Year > 2000 select l;
   }

   public IEnumerable<Book> LibrosConMasde250PagConPlabraInAction()
   {
    return librosCollections.Where(p => p.PageCount > 250 && (p.Title ?? String.Empty).Contains("in Action"));
   }
}
