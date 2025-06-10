using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Interfaces;

namespace TaskManagementProject.Models.TypesOfSorting;

public class SortByStatus : ISortingOptions
{
    public List<Task1> Sort(List<Task1> tasks, Func<Task1, bool> criteria)
    {
        Task1 task = new Task1();
        
        tasks.Sort((task1, task2) => task1.Status.GetStatus().CompareTo(task2.Status.GetStatus()));
        return tasks.Where(criteria).ToList();
    }
}
