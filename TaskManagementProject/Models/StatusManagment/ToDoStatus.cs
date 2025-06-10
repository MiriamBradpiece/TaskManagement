using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models;


public class ToDoStatus : IStatus
{
    public ToDoStatus(Task1 task) : base(task) { }


    public override void ChangeStatus()
    {
        
        _task.Change(new InProgressStatus(_task));
        _task.GetEvent("Status changed to InProgress");
    }
    public override Task_status GetStatus()
    {
        return Task_status.ToDo;
    }

  
}
