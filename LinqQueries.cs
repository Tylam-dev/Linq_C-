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

   public bool TodosLosLibrosTienenStatus()
   {
    return librosCollections.All(p => p.Status!= string.Empty);
   }
   public bool AlgunLibroFuePublicadoEn2005()
   {
    return librosCollections.Any(p => p.PublishedDate.Year == 2005);
   }
   public IEnumerable<Book> LibrosDePython()
   {
    return librosCollections.Where(p => p.Categories.Contains("Python"));
   }

   public IEnumerable<Book> LibrosDeJavaPorNombreAsc()
   {
    return librosCollections.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
   }
   public IEnumerable<Book> LibroMasDe450PagDes()
   {
    return librosCollections.Where(p => p.PageCount > 450).OrderByDescending(p => p.Title);
   }
}
