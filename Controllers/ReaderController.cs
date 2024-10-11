using Microsoft.AspNetCore.Mvc;
using BooksWeb.Models;

namespace BooksWeb.Controllers;

// https://localhost:1234/book/
public class ReaderController : Controller
{
    private readonly BookDatabase db;

    public ReaderController(BookDatabase db) {
        this.db = db;
    }

    // https://localhost:1234/book/read
    // controller = classe
    // action = método
    public ActionResult Read()
    {        
        return View(db.Readers.ToList()); // ~ SELECT * FROM Readers
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Reader model)
    {
        db.Readers.Add(model); // ~ INSERT INTO Readers VALUES (mode.Title...)
        db.SaveChanges(); // ~ commit
        return RedirectToAction("Read");
    }

    public ActionResult Delete(int id) 
    {
        // realizar a exclusão
        var book = db.Readers.Single(e => e.ReaderId == id); // SELECT * FROM Readers WHERE ReaderId = id

        db.Readers.Remove(book); // DELETE FROM Readers WHERE ReaderId = id

        db.SaveChanges(); // commit

        // redirecionar para página de read novamente.
        return RedirectToAction("Read");
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        return View(db.Readers.Single(e => e.ReaderId == id));
    }

    [HttpPost]
    public ActionResult Update(int id, Reader model)
    {
        var reader = db.Readers.Single(e => e.ReaderId == id);

        reader.Name = model.Name;
        reader.Email = model.Email;

        db.SaveChanges();

        return RedirectToAction("Read");
    }

    public ActionResult Login() {
        return View();
    }

    [HttpPost]
    public ActionResult Login(ReaderViewModel model)
    {
        var user = db.Readers.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);

        if(user == null) 
        {
            ViewBag.Autenticado = false;
            return View(model);
        }
        else 
        {
            // login (sessão)
            HttpContext.Session.SetInt32("userId", user.ReaderId);
            HttpContext.Session.SetString("userName", user.Name);
            
            return RedirectToAction("Read", "Book");
        }

    }
}