using Newtonsoft.Json;
using StYouDent.Models;
using StYouDent.Persistance;
using StYouDent.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace StYouDent.ViewModels
{
    public class LoginPageViewModel
    {
        private IServerService _serverConnect;
        public LoginPageViewModel(IServerService serverConnect)
        {
            _serverConnect = serverConnect;
        }

        public async Task SendLogin(string email, string pass)
        {
            string json = await _serverConnect.SendLogin(email, pass);
            System.Diagnostics.Debug.Write(json);
            await DeserializeJson(json);
        }

        private async Task DeserializeJson(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(User));
                User user = new User();
                user = (User)deserializer.ReadObject(ms);
                await Logged(user);
            }           
        }

        private async Task Logged(User user)
        { 
            var mainViewModel = new MainPageViewModel(user, _serverConnect);
            var leftViewModel = new LeftHelpPageViewModel(user, _serverConnect);
            var rightViewModel = new RightHandPageViewModel(user, _serverConnect);

            CarouselPage carouselPage = new CarouselPage();
            carouselPage.Children.Add(new LeftHelpPage(leftViewModel));
            carouselPage.Children.Add(new MainPage(mainViewModel));
            carouselPage.Children.Add(new RightHandPage(rightViewModel));
            carouselPage.CurrentPage = carouselPage.Children[1];

            App.Current.MainPage = carouselPage;
        }
    }
}
