using Microsoft.AspNetCore.Mvc;

namespace BooksWeb.Controllers;

// https://localhost:1234/book/
public class BookController : Controller
{
    // https://localhost:1234/book/read
    // controller = classe
    // action = método
    public ActionResult Read()
    {
        return View();
    }
}