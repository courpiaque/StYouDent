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
    public partial class LeftHelpPage : ContentPage
    {
        public LeftHelpPage(LeftHelpPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        LeftHelpPageViewModel _viewModel
        {
            get { return BindingContext as LeftHelpPageViewModel; }
            set { _viewModel = value; }
        }

        private void Category_Button(object sender, EventArgs e)
        { 
            Navigation.PushModalAsync(new LeftCategoryPage(_viewModel));
        }

        private async void Add_Button(object sender, EventArgs e)
        {
            await _viewModel.AddNote(name_lbl.Text, category_lbl.Text, description_lbl.Text);
            await DisplayAlert("Ogłoszenie dodane!", "Wkrótce pojawi się w aktualnościach", "OK");
            name_lbl.Text = "";
            category_lbl.Text = "Wybierz kategorię";
            description_lbl.Text = "";
        }
    }
}