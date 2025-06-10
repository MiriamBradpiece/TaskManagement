using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Interfaces;

namespace TaskManagementProject.Models;

public class ConsoleManager : ITypeOfNotification

{
    //private static ConsoleManager instance;
    //public ConsoleManager()
    //{
        
    //}
    //public static ConsoleManager InstanceNotify
    //{
    //    get
    //    {
    //        if (instance == null)
    //            instance = new ConsoleManager();
    //        return instance;

    //    }
    //}

    public void notify(string message)
    {
        Console.WriteLine(message);
    }

}
