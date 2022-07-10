using System;
using System.Linq;
using todo_domain_entities.Models;

namespace todo_domain_entities.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        IQueryable<ToDoItem> GetToDoItems();
        void AddToDoItem(string title, string description, DateTime? dueDate);
        void ChangeStatusToDoItem(int id, ToDoStatus status);
        void HideToDoItem(int id);
        void RemoveToDoItem(int id);
        void UpdateToDoItemTitle(int id, string title);
        void CopyToDoItem(int id);
        void ShowToDoItem(int id);
    }
}
