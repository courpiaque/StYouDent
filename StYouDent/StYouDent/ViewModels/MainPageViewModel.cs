using Newtonsoft.Json;
using StYouDent.Models;
using StYouDent.Persistance;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace StYouDent.ViewModels
{
    public class MainPageViewModel
    {
        public string Index { get; private set; } 
        public string School { get; private set; }

        public ObservableCollection<Item> Items { get; private set; } = new ObservableCollection<Item>();

        private IServerService _serverService;

        private User _user;

        public MainPageViewModel(User user, IServerService serverService)
        {
            _serverService = serverService;
            _user = user;
            Index = _user.index;
            School = _user.school;
        }

        public async Task LoadList()
        {
            var json = await _serverService.GetRequest("https://hackathon-student-backend.herokuapp.com/offers/" + _user.Id);
            var list = JsonConvert.DeserializeObject<List<Item>>(json);     

            foreach (var i in list)
                Items.Add(i);

            System.Diagnostics.Debug.Write("Chuj");               
        }
    }
}
