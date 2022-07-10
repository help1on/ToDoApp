using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using todo_domain_entities.Models;
using todo_domain_entities.Repositories.Interfaces;

namespace ToDoWebApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repository;

        public ToDoController(ILogger<ToDoController> logger, IToDoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IActionResult Index()
        {
            var toDoItems = _repository.GetToDoItems()
                .Where(x => x.IsHidden == false && (x.Status == ToDoStatus.NotStarted || x.Status == ToDoStatus.InProgress));

            return View(toDoItems);
        }

        [HttpPost]
        public IActionResult AddToDoItem(string title,string description, DateTime? dueDate)
        {
            _repository.AddToDoItem(title, description, dueDate);
            return RedirectToAction("Index");
        }

        public IActionResult CompleteToDoItem(int id)
        {
            _repository.ChangeStatusToDoItem(id, ToDoStatus.Completed);
            return RedirectToAction("Index");
        }

        public IActionResult HideToDoItem(int id)
        {
            _repository.HideToDoItem(id);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveToDoItem(int id, string redirectAction = "Index")
        {
            _repository.RemoveToDoItem(id);
            return RedirectToAction(redirectAction);
        }

        [HttpPost]
        public JsonResult UpdateToDoItemTitle(int id, string title)
        {
            try
            {
                _repository.UpdateToDoItemTitle(id, title);
                return Json(new { Success = true });
            }
            catch (Exception)
            {
                return Json(new { Success = false });
            }
        }

        public IActionResult CompletedToDoItem()
        {
            var toDoItems = _repository.GetToDoItems()
                .Where(x => x.IsHidden == false && x.Status == ToDoStatus.Completed);

            return View(toDoItems);
        }

        public IActionResult HiddenToDoItem()
        {
            var toDoItems = _repository.GetToDoItems()
                .Where(x => x.IsHidden == true);

            return View(toDoItems);
        }
        public IActionResult CopyToDoItem(int id)
        {
            _repository.CopyToDoItem(id);
            return RedirectToAction("Index");
        }
        public IActionResult InProgressToDoItem(int id)
        {
            _repository.ChangeStatusToDoItem(id, ToDoStatus.InProgress);
            return RedirectToAction("Index");
        }

        public IActionResult ShowToDoItem(int id)
        {
            _repository.ShowToDoItem(id);
            return RedirectToAction("HiddenToDoItem");
        }
        public IActionResult DueToday()
        {
            DateTime calcDate = DateTime.Now;
            DateTime startDate = new DateTime(calcDate.Year, calcDate.Month, calcDate.Day);
            DateTime endDate = new DateTime(calcDate.Year, calcDate.Month, calcDate.Day + 1).AddSeconds(-1);
            var toDoItems = _repository.GetToDoItems()
                .Where(x => x.IsHidden == false && startDate <= x.DueDate && x.DueDate <= endDate);

            return View(toDoItems);
        }


    }
}
