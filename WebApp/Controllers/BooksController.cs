using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IGetBooksCommand _getBooksCommand;
        private readonly IGetGenresCommand _getGenresCommand;
        private readonly IGetPagedBooksCommand _getPagedBooksCommand;
        private readonly IGetBookCommand _getBookCommand;
        private readonly ICreateBookCommand _createBookCommand;
        private readonly IUpdateBookCommand _updateBookCommand;
        private readonly IGetForWebCommand _getForWebCommand;
        private readonly IEditBookCommand _editBookCommand;
        private readonly IDeleteBookCommand _deleteBookCommand;

        public BooksController(IGetBooksCommand getBooksCommand, IGetGenresCommand getGenresCommand, IGetPagedBooksCommand getPagedBooksCommand, IGetBookCommand getBookCommand, ICreateBookCommand createBookCommand, IUpdateBookCommand updateBookCommand, IGetForWebCommand getForWebCommand, IEditBookCommand editBookCommand, IDeleteBookCommand deleteBookCommand)
        {
            _getBooksCommand = getBooksCommand;
            _getGenresCommand = getGenresCommand;
            _getPagedBooksCommand = getPagedBooksCommand;
            _getBookCommand = getBookCommand;
            _createBookCommand = createBookCommand;
            _updateBookCommand = updateBookCommand;
            _getForWebCommand = getForWebCommand;
            _editBookCommand = editBookCommand;
            _deleteBookCommand = deleteBookCommand;
        }

        // GET: Books
        public ActionResult Index(BookSearch search)
        {
            try
            {
                var result = _getBooksCommand.Execute(search);
                return View(result);
            }
            catch(Exception e)
            {
                TempData["error"] = "An error has occurred";
                return View();
            }
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _getBookCommand.Execute(id);
                return View(result);
            }
            catch(Exception e)
            {
                TempData["error"] = "An error has occurred";
                return View();
            }
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                _createBookCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var book = _getForWebCommand.Execute(id);
                return View(book);
            }
            catch (EntityNotFoundException e)
            {

                return RedirectToAction("Index");
            }
            
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookDto dto)
        {
            try
            {
                _editBookCommand.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Books/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                _deleteBookCommand.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return View();
            }
        }
        

        public IActionResult Catalog([FromQuery] BookSearch search)
        {
            var vm = new CatalogViewModel();

            vm.Genres = _getGenresCommand.Execute(new Application.Searches.GenreSearch { OnlyActive = true});

            vm.Books = _getPagedBooksCommand.Execute(search);

            return View(vm);
        }
    }
}