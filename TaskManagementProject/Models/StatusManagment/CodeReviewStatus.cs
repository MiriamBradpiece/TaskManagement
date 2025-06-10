using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models;



public class CodeReviewStatus : IStatus
{
    public CodeReviewStatus(Task1 task) : base(task) { }

    public override void ChangeStatus()
    {
   
        _task.Change(new QAStatus(_task));
        _task.GetEvent("Status changed to QA");
    }

    public override Task_status GetStatus()
    {
        return Task_status.CodeReview;
    }

}


