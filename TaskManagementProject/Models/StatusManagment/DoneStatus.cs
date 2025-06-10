using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models;



public class DoneStatus : IStatus
{
    public DoneStatus(Task1 task) : base(task) { }
    public override void ChangeStatus()
    {
        Console.WriteLine("The task is completed!!!");
    }

    public override Task_status GetStatus()
    {
        return Task_status.Done;
    }

}
