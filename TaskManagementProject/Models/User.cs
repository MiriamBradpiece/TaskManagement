using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementProject.Enums;
using TaskManagementProject.Interfaces;

namespace TaskManagementProject.Models;

public class User : IUsers
{
    ITypeOfNotification _notification;
    public string Name { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    public User(string Name, string Email, Role Role, ITypeOfNotification notification)
    {
        this.Name = Name;
        this.Email = Email;
        this.Role = Role;
        _notification = notification;
    }

    public void SendMessage(string message)
    {
        _notification.notify($"Name: {Name}, message: {message}");
    }
}
