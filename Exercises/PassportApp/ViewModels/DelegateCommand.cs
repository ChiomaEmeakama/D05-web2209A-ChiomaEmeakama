using System;

namespace PassportApp.ViewModels
{
    public class DelegateCommand
    {
        private Action<object> travel;

        public DelegateCommand(Action<object> travel)
        {
            this.travel = travel;
        }
    }
}