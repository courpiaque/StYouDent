using StYouDent.Models;
using StYouDent.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StYouDent.ViewModels
{
    public class RightHandPageViewModel : BaseViewModel
    {
        private string _category = "Wybierz kategorię";
        private IServerService _serverService;
        public string Category
        {
            get { return _category; }
            set { SetValue(ref _category, value); }
        }

        private User _user;
        public RightHandPageViewModel(User user, IServerService serverService)
        {
            _user = user;
            _serverService = serverService;
        }

        public void ChangeCategory(string name)
        {
            Category = name;
            System.Diagnostics.Debug.Write(Category);
        }

        public async Task AddNote(string name, string category, string description)
        {
            string json = "{\"name\":\"" + name + "\",\"category\":\"" + category + "\",\"description\":\"" + description + "\",\"author\":\"" + _user.Id + "\"}";
            await _serverService.SendRequest(json, "https://hackathon-student-backend.herokuapp.com/create_ad");
        }
    }
}
