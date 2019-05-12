using StYouDent.Persistance;
using StYouDent.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StYouDent.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var _serverConnect = new ServerService();
            BindingContext = new LoginPageViewModel(_serverConnect);
        }

        LoginPageViewModel viewModel
        {
            get { return BindingContext as LoginPageViewModel; }
            set { BindingContext = value; }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await viewModel.SendLogin(email_lbl.Text, pass_lbl.Text);
        }
    }
}