using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<Todo> todos = new List<Todo>();

        public IActionResult Index()
        {
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            todo.Id = Guid.NewGuid().GetHashCode();
            todo.CreatedAt = DateTime.Now;
            todos.Add(todo);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var todoToRemove = todos.Find(todo => todo.Id == id);
            if (todoToRemove != null)
            {
                todos.Remove(todoToRemove);
            }
            return RedirectToAction("Index");
        }
    }
}
