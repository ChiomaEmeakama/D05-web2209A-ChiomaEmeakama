using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PassportApp.Models;
using PassportApp.Repository;

namespace PassportApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            PassportRepository repository = new PassportRepository();
            //var alfredo = repository.GetPassport(100);
            List<Passport> passport = repository.GetPassports("Alfredo","Parreira");

        }
    }
}
