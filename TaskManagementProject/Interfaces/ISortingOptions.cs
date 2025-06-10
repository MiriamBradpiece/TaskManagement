using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Models;

namespace TaskManagementProject.Interfaces;

//Design Patterns - Strategy
public interface ISortingOptions
{
    public List<Task1> Sort(List<Task1> items, Func<Task1, bool> criteria);
}
