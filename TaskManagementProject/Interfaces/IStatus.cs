using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Models;

namespace TaskManagementProject.Interfaces;
//design patterns-state
public abstract class IStatus
{
    protected Task1 _task;
    protected IStatus(Task1 task)
    {
        _task = task;
    }
    abstract public void ChangeStatus();
    public abstract Task_status GetStatus();

}
