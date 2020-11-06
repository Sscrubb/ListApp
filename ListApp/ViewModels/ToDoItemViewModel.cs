using ListApp.Models.Domain;
using System;

namespace ListApp.ViewModels
{
    public class ToDoItemViewModel : BaseViewModel
    {
        public ToDoItemViewModel(ToDoItem model)
        {
            Model = model;
        }

        public ToDoItem Model { get; private set; }

        public string Description 
        { 
            get => Model.Description;
            set 
            {
                if (Model.Description != value)
                {
                    Model.Description = value;
                    GeneratePropertyChangedEvent(nameof(Description));
                }
            }
        }

        public ToDoItemStatus Status
        {
            get => Model.Status;
            set
            {
                if (Model.Status != value)
                {
                    Model.Status = value;
                    GeneratePropertyChangedEvent(nameof(Status));
                }
            }
        }

        public DateTime CreationDate
        {
            get => Model.CreationDate;
            set
            {
                if (Model.CreationDate != value)
                {
                    Model.CreationDate = value;
                    GeneratePropertyChangedEvent(nameof(CreationDate));
                }
            }
        }
    }
}
