using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using todo_domain_entities.Models;
using todo_domain_entities.Repositories.Interfaces;

namespace todo_domain_entities.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private ToDoContext context;

        public ToDoRepository(ToDoContext context)
        {
            this.context = context;
        }

        public IQueryable<ToDoItem> GetToDoItems()
        {
            return context.ToDoItems;
        }

        public void AddToDoItem(string title, string description, DateTime? dueDate)
        {
            var toDoItem = new ToDoItem()
            {
                Title = title,
                DueDate = dueDate,
                Description = description
            };

            context.ToDoItems.Add(toDoItem);
            context.SaveChanges();
        }

        public void ChangeStatusToDoItem(int id, ToDoStatus status)
        {
            var toDoItem = context.ToDoItems.Where(x => x.ID == id).FirstOrDefault();

            if (toDoItem != null)
            {
                toDoItem.Status = status;
                context.SaveChanges();
            }
        }

        public void HideToDoItem(int id)
        {
            var toDoItem = context.ToDoItems.Where(x => x.ID == id).FirstOrDefault();

            if (toDoItem != null)
            {
                toDoItem.IsHidden = true;
                context.SaveChanges();
            }
        }

        public void ShowToDoItem(int id)
        {
            var toDoItem = context.ToDoItems.Where(x => x.ID == id).FirstOrDefault();

            if (toDoItem != null)
            {
                toDoItem.IsHidden = false;
                context.SaveChanges();
            }

        }

        public void RemoveToDoItem(int id)
        {
            var toDoItem = context.ToDoItems.Where(x => x.ID == id).FirstOrDefault();

            if (toDoItem != null)
            {
                context.ToDoItems.Remove(toDoItem);
                context.SaveChanges();
            }
        }

        public void UpdateToDoItemTitle(int id, string title)
        {
            var toDoItem = context.ToDoItems.Where(x => x.ID == id).FirstOrDefault();

            if (toDoItem != null)
            {
                toDoItem.Title = title;
                context.SaveChanges();
            }
        }

        public void CopyToDoItem(int id)
        {
            var toDoItem = context.ToDoItems.Where(x => x.ID == id).FirstOrDefault();
            if (toDoItem != null)
            {
                ToDoItem copyToDoItem = new ToDoItem()
                {
                    Title = toDoItem.Title,
                    DueDate = toDoItem.DueDate
                };
                context.ToDoItems.Add(copyToDoItem);
                context.SaveChanges();
            }
        }
    }
}
