using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo;

namespace StudentApp.ViewModels
{
    internal class StudentListViewModel
    {
        public ObservableCollection<Student> Students { get; }

        public StudentListViewModel() 
        {
            Students = new ObservableCollection<Student>();
            Students.Add(new Student(1, "Anna", false, 2, new DateTime(1999, 1, 31)));
            Students.Add(new Student(2, "Bella", false, 2, new DateTime(1998, 2, 30)));
            Students.Add(new Student(3, "Grace", false, 2, new DateTime(1997, 3, 29)));

            
;        }
       
    }
}
