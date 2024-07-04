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
   public IEnumerable<Book> Libros3RecientesJava()
   {
    return librosCollections.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
   }
   public IEnumerable<Book> TercerCuartLibro400Pag()
   {
        return librosCollections.Where(p => p.PageCount > 400).Take(4).Skip(2);
   }
   public IEnumerable<Book> TresPrimerosLibrosDeLaColeccion()
   {
        return librosCollections.Take(3)
        .Select(p =>  new Book() { Title = p.Title, PageCount = p.PageCount });
   }
   public int Entre200Y500PagCount()
   {
        return librosCollections.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
   }
   public DateTime MenorFecha()
   {
        return librosCollections.Min(p => p.PublishedDate);
   }
   public int MayorNumPaginas()
   {
        return librosCollections.Max(p => p.PageCount);
   }
   public Book MenorCantPagMayor0()
   {
         return librosCollections.MinBy(p => p.PageCount);
   }
   public Book LibroMayorfecha()
   {
        return librosCollections.MaxBy(p => p.PublishedDate);
   }
}
