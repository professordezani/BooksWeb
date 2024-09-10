using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;

namespace BooksWeb.Controllers;

// https://localhost:1234/book/
public class BookController : Controller
{
    // https://localhost:1234/book/read
    // controller = classe
    // action = método
    public ActionResult Read()
    {
        Book book1 = new Book();
        book1.Title = "Código da Vinci";
        book1.Author = "Dan Brown";

        Book book2 = new Book();
        book2.Title = "Símbolo Perdido";
        book2.Author = "Dan Brown";

        List<Book> books = new List<Book>();
        books.Add(book1);
        books.Add(book2);
        
        return View(books);
    }
}