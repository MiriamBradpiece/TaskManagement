using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Interfaces;

namespace TaskManagementProject.Models.TypesOfSorting;

public class SortingTaskManager
{
    public static List<Task1> tasks { get; set; }= new List<Task1>();

    private ISortingOptions sortingOptions;

    public void SetSortingStrategy(ISortingOptions sortingOptions)
    {
        this.sortingOptions = sortingOptions;
    }

    public List<Task1> SortTasks(Func<Task1, bool> criteria)
    {
        if (sortingOptions != null)
        {
            return sortingOptions.Sort(tasks,criteria);
        }
        return tasks;
    }
}
