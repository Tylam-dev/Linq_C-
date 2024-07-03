// See https://aka.ms/new-console-template for more information
using Linq_C_;

Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

// ImprimirValores(queries.LibrosConMasde250PagConPlabraInAction());
// Console.WriteLine(queries.TodosLosLibrosTienenStatus());
// Console.WriteLine(queries.AlgunLibroFuePublicadoEn2005());
// ImprimirValores(queries.LibrosDePython());
// ImprimirValores(queries.LibrosDeJavaPorNombreAsc());
ImprimirValores(queries.LibroMasDe450PagDes());

void ImprimirValores(IEnumerable<Book> listdelibros)
{
    Console.WriteLine("{0, -70} {1,7} {2,11}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listdelibros)
    {
        Console.WriteLine("{0, -70} {1,7} {2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

