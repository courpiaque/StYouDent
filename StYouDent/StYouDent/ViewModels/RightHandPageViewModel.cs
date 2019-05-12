using StYouDent.Models;
using StYouDent.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace StYouDent.ViewModels
{
    public class RightHandPageViewModel : BaseViewModel
    {
        private string _category = "Wybierz kategorię";
        public string Category
        {
            get { return _category; }
            set { SetValue(ref _category, value); }
        }

        private User _user;
        public RightHandPageViewModel(User user, IServerService serverConnect)
        {
            _user = user;
        }

        public void ChangeCategory(string name)
        {
            Category = name;
            System.Diagnostics.Debug.Write(Category);
        }
    }
}
