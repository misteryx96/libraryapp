using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IGetReserervationsCommand _getReserervationsCommand;
        private readonly IGetReservationCommand _getReservationCommand;
        private readonly IDeleteReservationCommand _deleteReservationCommand;
        private readonly ICreateReservationCommand _createReservationCommand;
        private readonly IGetReservationForWebCommand _getReservationForWebCommand;
        private readonly IEditReservationCommand _editReservationCommand;
        private readonly ITookABookCommand _tookABookCommand;

        public ReservationsController(IGetReserervationsCommand getReserervationsCommand, IGetReservationCommand getReservationCommand, IDeleteReservationCommand deleteReservationCommand, ICreateReservationCommand createReservationCommand, IGetReservationForWebCommand getReservationForWebCommand, IEditReservationCommand editReservationCommand, ITookABookCommand tookABookCommand)
        {
            _getReserervationsCommand = getReserervationsCommand;
            _getReservationCommand = getReservationCommand;
            _deleteReservationCommand = deleteReservationCommand;
            _createReservationCommand = createReservationCommand;
            _getReservationForWebCommand = getReservationForWebCommand;
            _editReservationCommand = editReservationCommand;
            _tookABookCommand = tookABookCommand;
        }

        // GET: Reservations
        public ActionResult Index(ReservationSearch search)
        {
            try
            {
                var result = _getReserervationsCommand.Execute(search);
                return View(result);
            }
            catch (Exception e)
            {
                TempData["error"] = "An error has occurred";
                return View();
            }
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var result = _getReservationCommand.Execute(id);
                return View(result);
            }
            catch (Exception e)
            {
                TempData["error"] = "An error has occurred";
                return View();
            }
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationDto dto)
        {
            try
            {
                // TODO: Add insert logic here
                _createReservationCommand.Execute(dto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var reservation = _getReservationForWebCommand.Execute(id);
                return View(reservation);
            }
            catch (EntityNotFoundException e)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Reservations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReservationDto dto)
        {
            try
            {
                _editReservationCommand.Execute(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (EntityAlreadyExistsException e)
            {
                return View();
            }
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteReservationCommand.Execute(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return View();
            }
        }

        public ActionResult TookABook(int id)
        {
            try
            {
                _tookABookCommand.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                return View();
            }
        }

        

    }
}