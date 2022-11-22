using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace todo_domain_entities.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            Status = ToDoStatus.NotStarted;
            IsHidden = false;
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(80, ErrorMessage = "Title must not exceed 80 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
        public string Description { get; set; }

        public ToDoStatus Status { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsHidden { get; set; }
    }

    public enum ToDoStatus
    {
        NotStarted = 10,
        InProgress = 20,
        Completed = 30
    }
}
