using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;

namespace TaskManagementProject.Models.Handler;

public class DeveloperHandler : BaseHandlerStatus
{
    public override bool Handle(Task1 task, User user)
    {
        if (user?.Role == Role.Developer && (task?.Status?.GetType() == typeof(ToDoStatus)||
            task?.Status?.GetType() == typeof(InProgressStatus)))
        {
            task.Call(task.Status);
            return true;
        }

        return base.Handle(task, user);
    }
}
