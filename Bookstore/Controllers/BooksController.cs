using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Repositories;
using Bookstore.RepositoriesImpl;

namespace Bookstore.Controllers
{
    public class BooksController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BooksController()
        {
            _unitOfWork = new UnitOfWork(new BookstoreContext());
        }

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Books
        public ActionResult Index(string search = "")
        {
            IEnumerable<Book> books;
            if (!string.IsNullOrEmpty(search))
                books = _unitOfWork.Books.GetAllBooksByTitleOrAuthorName(search);
            else
                books = _unitOfWork.Books.GetBooksWithAuthor();
            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = _unitOfWork.Books.GetBookWithAuthor(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(_unitOfWork.Authors.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Count,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Books.Add(book);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_unitOfWork.Authors.GetAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = _unitOfWork.Books.Get(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            ViewBag.AuthorId = new SelectList(_unitOfWork.Authors.GetAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Count,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Books.Update(book);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(_unitOfWork.Authors.GetAll(), "Id", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = _unitOfWork.Books.GetBookWithAuthor(id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = _unitOfWork.Books.GetBookWithAuthor(id);
            _unitOfWork.Books.Remove(book);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
