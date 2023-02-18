using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.ViewModels
{
    internal class StudentListViewModel
    {
        public ObservableCollection<Student> Students { get; }

        public StudentListViewModel() 
        {
            Students = new ObservableCollection<Student>();

            
;        }
       
    }
}
