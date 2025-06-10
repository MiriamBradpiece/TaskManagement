using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models;


public class QAStatus : IStatus
{
    public QAStatus(Task1 task) : base(task) { }

    public override void ChangeStatus()
    {
        
        _task.Change(new DoneStatus(_task));
        _task.GetEvent("Status changed to Done");
    }

    public override Task_status GetStatus()
    {
        return Task_status.QA;
    }
}
