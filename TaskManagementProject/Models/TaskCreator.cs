using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models.TypesOfSorting;

namespace TaskManagementProject.Models;

public class TaskCreator
{
    //Design Patterns - Builder
    
    DateTime creationDate = DateTime.Now;
    string title = null;
    string description = null;
    User assignee = null;
    User reporter = null;
    IStatus status =null;
    Priority priority = Priority.High;
    float estimationTime = 0;
    float loggedTime = 0;
    List<Task1> subtasks = null;


    public TaskCreator( string Title, DateTime CreationDate)
    {
       
        this.title = Title;
        this.creationDate = CreationDate;
    }
    public void CreateDescription(string Description)
    {
        this.description = Description;
    }
    public void CreateAssignee(User Assignee)
    {
        this.assignee = Assignee;
    }
    public void CreateStatus(IStatus Status)
    {
        this.status = Status;
    }
    public void CreatePriority(Priority Priority)
    {
        this.priority = Priority;
    }
    public void CreateEstimationTime(float EstimationTime)
    {
        this.estimationTime = EstimationTime;
    }
    public void CreateLoggedTime(float LoggedTime)
    {
        this.loggedTime = LoggedTime;
    }
    public void CreateReporter(User Reporter)
    {
        this.reporter = Reporter;
    }
    public void CreateSubTask(Task1 task)
    {
        if (subtasks == null)
        {
            subtasks = new List<Task1>();
        }
        subtasks.Add(task);
        estimationTime += task.ReturnEstimationTime();
        loggedTime += task.ReturnLoggedTime();

        //SortingTaskManager.tasks.Add(task);
    }

    public Task1 Create()
    {
        return new Task1()
        {
            CreationDate = this.creationDate,
            Title = this.title,
            Description = this.description,
            Assignee = this.assignee,
            Reporter = this.reporter,
            Priority = this.priority,
            EstimationTime = this.estimationTime,
            LoggedTime = this.loggedTime,
            Subtasks = this.subtasks
        };
     
    }
}
