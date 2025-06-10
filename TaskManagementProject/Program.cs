using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;
using TaskManagementProject.Models;
using TaskManagementProject.Models.Handler;
using TaskManagementProject.Models.TypesOfSorting;

ConsoleManager consoleManager = new ConsoleManager();

#region Build tasks
User manager = new User("Roni", "roni3456@gmail.com", Role.Manager, consoleManager);
#region subTask1
Task1 task4 = new Task1();
User user6 = new User("Dani", "d53474@gmail.com", Role.Developer,consoleManager);
TaskCreator taskCreator4 = new TaskCreator("Develop Feature", DateTime.Now);
taskCreator4.CreatePriority(Priority.Low);
taskCreator4.CreateReporter(manager);
taskCreator4.CreateAssignee(user6);
taskCreator4.CreateEstimationTime(4);
taskCreator4.CreateLoggedTime(5);
taskCreator4.CreateDescription("Develope the DataBase");
task4 = taskCreator4.Create();
#endregion
#region subTask2
Task1 task3 = new Task1();
User user3 = new User("Chaim", "6767839465@gmail.com", Role.Developer,consoleManager);
TaskCreator taskCreator3 = new TaskCreator("Develop Feature", DateTime.Now);
taskCreator3.CreatePriority(Priority.Low);
taskCreator3.CreateReporter(manager);
taskCreator3.CreateAssignee(user3);
taskCreator3.CreateEstimationTime(4);
taskCreator3.CreateLoggedTime(5);
taskCreator3.CreateDescription("Develope the Client side");
task3 = taskCreator3.Create();
#endregion
#region subTask3
Task1 task2 = new Task1();
User user1 = new User("Moshe", "nn454@gmail.com", Role.Developer, consoleManager);
TaskCreator taskCreator2 = new TaskCreator("Develop Feature", DateTime.Now);
taskCreator2.CreatePriority(Priority.Low);
taskCreator2.CreateReporter(manager);
taskCreator2.CreateAssignee(user1);
taskCreator2.CreateDescription("Develope the server side");
taskCreator2.CreateSubTask(task4);
task2 = taskCreator2.Create();
#endregion
#region main Task
Task1 mainTask = new Task1();
User user = new User("yohav", "yrtdg545@gmail.com", Role.QA,consoleManager);
TaskCreator taskCreator1 = new TaskCreator("Develop Feature", DateTime.Now);
taskCreator1.CreatePriority(Priority.Low);
taskCreator1.CreateReporter(manager);
taskCreator1.CreateAssignee(user);
taskCreator1.CreateDescription("Build a webSite");
taskCreator1.CreateSubTask(task2);
taskCreator1.CreateSubTask(task3);
mainTask = taskCreator1.Create();
mainTask.PrintTask();
#endregion
#endregion

#region task 6 
Task1 task6 = new Task1();
User user8 = new User("Dani", "d53474@gmail.com", Role.Developer,consoleManager);
TaskCreator taskCreator6 = new TaskCreator("Develop Feature", DateTime.Now);
taskCreator6.CreatePriority(Priority.High);
taskCreator6.CreateReporter(manager);
taskCreator6.CreateAssignee(user8);
taskCreator6.CreateEstimationTime(4);
taskCreator6.CreateLoggedTime(5);
taskCreator6.CreateDescription("Develope the DataBase");
task6 = taskCreator6.Create();
#endregion 
#region task 5
Task1 task5 = new Task1();
User user7 = new User("Dani", "d53474@gmail.com", Role.Developer, consoleManager);
TaskCreator taskCreator5 = new TaskCreator("Develop Feature", DateTime.Now);
taskCreator5.CreatePriority(Priority.High);
taskCreator5.CreateReporter(manager);
taskCreator5.CreateAssignee(user7);
taskCreator5.CreateEstimationTime(5);
taskCreator5.CreateLoggedTime(5);
taskCreator5.CreateDescription("Develope the DataBase");
task5 = taskCreator5.Create();
#endregion

#region ניהול זרימת עבודה

DeveloperHandler devHandler2 = new DeveloperHandler();
ManagerHandler managerHandler2 = new ManagerHandler();
QAHandler qaHandler2 = new QAHandler();

devHandler2.SetNext(managerHandler2);
managerHandler2.SetNext(qaHandler2);

devHandler2.Handle(task5, user1);
devHandler2.Handle(task5, user1);
task5.AddLogTime(9);

#endregion

#region מיון משימות 
#region מיון לפי עדיפות
ISortingOptions sortingOptions1 = new SortByPriority();
SortingTaskManager sortingTaskManager = new SortingTaskManager();
SortingTaskManager.tasks.Add(mainTask);
SortingTaskManager.tasks.Add(task5);
List<Task1> sortedTasks1 = sortingOptions1.Sort(SortingTaskManager.tasks, task => task.Priority!=Priority.Medium);
Console.WriteLine("Sorting by Priority");
foreach (var task12 in sortedTasks1)
{
    Console.WriteLine($"{task12.Title} - {task12.Priority}");
}
#endregion
#region מיון לפי זמן משוער
ISortingOptions sortingOptions2 = new SortByEstimationTime();
SortingTaskManager sortingTaskManager2 = new SortingTaskManager();
//SortingTaskManager.tasks.Add(mainTask);
//SortingTaskManager.tasks.Add(task5);
SortingTaskManager.tasks.Add(task6);
List<Task1> sortedTasks2 = sortingOptions2.Sort(SortingTaskManager.tasks, task => task.EstimationTime >3);
Console.WriteLine("Sorting by Estimation Time");
foreach (var task12 in sortedTasks2)
{
    Console.WriteLine($"{task12.Title} - {task12.EstimationTime}");
}
#endregion
#region מיון לפי סטטוס
ISortingOptions sortingOptions3 = new SortByStatus();
SortingTaskManager sortingTaskManager3 = new SortingTaskManager();
List<Task1> sortedTasks3 = sortingOptions3.Sort(SortingTaskManager.tasks, task => task.Status.GetStatus() !=Task_status.QA);
Console.WriteLine("Sorting by Status");
foreach (var task12 in sortedTasks3)
{
    Console.WriteLine($"{task12.Title} - {task12.Status.GetStatus()}");
}
#endregion
#endregion

