using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using todo_domain_entities.Models;

namespace todo_domain_entities
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {

        }

        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options) { }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
