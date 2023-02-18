using StudentApp.Models;
using StudentApp.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StudentRepository repository = new StudentRepository();
            Student student = repository.GetStudent(id: 1000001);
        }
    }
}
