using System;

namespace ListApp.Models.Domain
{
    public class ToDoItem
    {
        public ToDoItemStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
