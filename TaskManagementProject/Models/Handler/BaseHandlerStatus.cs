using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementProject.Models.Handler;
//design patterns-Chain of responsbility
public class BaseHandlerStatus
{
    private BaseHandlerStatus _next;
    public void SetNext(BaseHandlerStatus next)
    {
        _next = next;
    }

    public virtual bool Handle(Task1 task, User user)
    {

        if (_next != null)
        {
            return _next.Handle(task, user);
        }

        return false;
    }
}
