using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models.TypesOfSorting;

namespace TaskManagementProject.Models;

public class Task1
{

    public Task1()
    {
        Status = new ToDoStatus(this);
    }

    List<IUsers> users = new List<IUsers>();
    public DateTime CreationDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    private User assinee;
    public User Assignee
    {
        get
        {
            return assinee;
        }
        set
        {
            assinee = value;
            users.Add(assinee);

        }
    }
    private User reporter;
    public User Reporter
    {
        get
        {
            return reporter;
        }
        set
        {
            reporter = value;
            users.Add(reporter);
        }
    }
    public IStatus Status { get; set; }
    public Priority Priority { get; set; }
    public float EstimationTime { get; set; }
    public float LoggedTime { get; set; }
    public List<Task1> Subtasks { get; set; }
    public void AddSubTask(Task1 task)
    {
        if (Subtasks == null)
        {
            Subtasks = new List<Task1>();
            EstimationTime = 0;
            LoggedTime = 0;
        }
        Subtasks.Add(task);
        EstimationTime += task.ReturnEstimationTime();
        LoggedTime += task.ReturnLoggedTime();
        //SortingTaskManager.tasks.Add(task);
    }
    public void PrintTask()
    {
        Console.WriteLine($"Creation date: {CreationDate}, Title: {Title}, Description: {Description}, " +
                          $"Assignee: {Assignee.Name}, Reporter: {Reporter.Name}, " +
                          $"Priority: {Priority}, Estimation Time: {EstimationTime}, Logged Time: {LoggedTime}, Status:{Status}");
    }
    public void Call(IStatus status)
    {
        status.ChangeStatus();
    }
    public void Change(IStatus status)
    {
        this.Status = status;
    }
    //Design Patterns - Composite
    public float ReturnEstimationTime()
    {
        float totalEstimationTime = 0;
        if (Subtasks != null)
        {
            foreach (var task in Subtasks)
            {
                totalEstimationTime += task.EstimationTime;
            }
            return totalEstimationTime;
        }
        else return EstimationTime;
    }
    public float ReturnLoggedTime()
    {
        float sum = 0;
        if (Subtasks == null)
        {
            return LoggedTime;
        }
        else
        {
            foreach (var task in Subtasks)
            {
                sum += task.LoggedTime;
            }

        }
        return sum;
    }
    public void AddLogTime(float hours)
    {
        LoggedTime += hours;
        this.GetEvent($"LoggedTime changed to: {LoggedTime}");
    }
    //Design Patterns - Observer
    public void AddSubscriber(IUsers user)
    {
        users.Add(user);
    }
    public void RemoveSubscriber(IUsers user)
    {
        users.Remove(user);
    }
    public void GetEvent(string message)
    {
        foreach (var user in users)
        {
            user.SendMessage(message);
        }
    }
}
