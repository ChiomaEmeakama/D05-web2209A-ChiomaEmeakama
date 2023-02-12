using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PassportApp.ViewModels
{
    internal class PassportListViewModel
    {
        public ObservableCollection<Passport> Passports { get; }

        public PassportListViewModel()
        {
            Passports = new ObservableCollection<Passport>();
            {
                Passports.Add(new Passport(2220001, "Chioma", "Emeakama", new DateTime(1996, 08, 26), "Nigeria"));
                Passports.Add(new Passport(2220002, "Gabriella", "Franco", new DateTime(1992, 09, 24), "Colombiaia"));
                Passports.Add(new Passport(2220003, "Alfredo", "Silva", new DateTime(1990, 09, 19), "Brazil"));
                Passports.Add(new Passport(2220004, "Atete", "Esperence", new DateTime(1992, 03, 03), "Rwanda"));
                Passports.Add(new Passport(2220005, "Danial", "Bhezdad", new DateTime(2004, 12, 28), "Iran"));

            }

            TravelCommand = new ObservableCollection<DelegateCommand>();
            {
                 // TODO
            }
        }


        public ObservableCollection<Passport> SelectedPassports { get; set; }
        public ObservableCollection<Passport> DestinationCountry { get; set; }

        public void Travel (object _)
        {
            Trace.WriteLine("Travel");
        }

        public ObservableCollection<DelegateCommand> TravelCommand { get; }

    }
}
