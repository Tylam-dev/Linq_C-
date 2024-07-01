// See https://aka.ms/new-console-template for more information
using Linq_C_;

Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

ImprimirValores(queries.TodaLaColeccion());

void ImprimirValores(IEnumerable<Book> listdelibros)
{
    Console.WriteLine("{0, -70} {1,7} {2,11}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listdelibros)
    {
        Console.WriteLine("{0, -70} {1,7} {2,11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}