using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;

namespace TaskManagementProject.Models.Handler;

public class ManagerHandler : BaseHandlerStatus
{
    public override bool Handle(Task1 task, User user)
    {
        if (user.Role == Role.Manager && task.Status.GetType() != typeof(QAStatus))
        {
            task.Call(task.Status);
            return true;
        }
        return base.Handle(task, user);
    }
}
