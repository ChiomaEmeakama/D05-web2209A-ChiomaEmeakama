﻿using PassportApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace PassportApp.ViewModels
{
    internal class PassportListViewModel : ViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<Passport> Passports { get; }
        
        public DelegateCommand TravelCommand { get; }
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

            TravelCommand = new DelegateCommand(Travel);
            {
                 // TODO
            }
        }


        public Passport SelectedPassports 
            {
                get => SelectedPassports;
                set
                {
                    SelectedPassports = value;
                    NotifyPropertyChanged(nameof(SelectedPassports))
                }
            }
        public Passport DestinationCountry { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Travel (object _)
        {
            Trace.WriteLine("Travel");
        }


    }
}
