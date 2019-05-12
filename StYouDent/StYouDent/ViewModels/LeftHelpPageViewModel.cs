using StYouDent.Models;
using StYouDent.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StYouDent.ViewModels
{
    public class LeftHelpPageViewModel : BaseViewModel
    {
        private string _category = "Wybierz kategorię";
        private IServerService _serverService;
        public string Category
        {
            get { return _category; }
            set { SetValue(ref _category, value); }
        }

        private User _user;
        public LeftHelpPageViewModel(User user, IServerService serverService)
        {
            _user = user;
            _serverService = serverService;
        }

        public void ChangeCategory(string name)
        {
            Category = name;
        }

        public async Task AddNote(string name, string category, string description)
        {
            string json = "{\"name\":\"" + name + "\",\"category\":\"" + category + "\",\"description\":\"" + description + "\",\"author\":\"" + _user.Id +"\"}";
            System.Diagnostics.Debug.Write(json);
            await _serverService.SendRequest(json, "https://hackathon-student-backend.herokuapp.com/create_help");
        }
    }
}
