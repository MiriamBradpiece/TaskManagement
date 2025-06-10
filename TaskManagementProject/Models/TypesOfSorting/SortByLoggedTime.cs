using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Interfaces;

namespace TaskManagementProject.Models.TypesOfSorting;

public class SortByLoggedTime : ISortingOptions
{
    public List<Task1> Sort(List<Task1> tasks, Func<Task1, bool> criteria)
    {
        tasks.Sort((task1, task2) => task1.LoggedTime.CompareTo(task2.LoggedTime));
        return tasks.Where(criteria).ToList(); 

    }
}
